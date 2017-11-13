// <copyright file="DSSearchParser.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Search
{
    using System.Linq;
    using Data;
    using Exceptions;
    using SDK.Data;
    using SDK.Search;

    /// <summary>
    /// Class to parse a DSSearch and build out an actual search based on the supplied builder and entity data.
    /// </summary>
    public class DSSearchParser
    {
        /// <summary>
        /// Base entity definition that we are starting from.
        /// </summary>
        private DSEntityType _entity;

        /// <summary>
        /// List of entity definitions known to the system.
        /// </summary>
        private IDSEntityTypeRepository _entityTypeRepository;

        /// <summary>
        /// Builder that will handle putting together the search from the parts.
        /// </summary>
        private IDSSearchBuilder _searchBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="DSSearchParser"/> class.
        /// </summary>
        /// <param name="entityTypeRepository">List of entity definitions known to the system.</param>
        /// <param name="searchBuilder">Builder that will handle putting together the search from the parts.</param>
        public DSSearchParser(IDSEntityTypeRepository entityTypeRepository, IDSSearchBuilder searchBuilder)
        {
            _entityTypeRepository = entityTypeRepository;
            _searchBuilder = searchBuilder;
        }

        /// <summary>
        /// Build out the supplied search.
        /// </summary>
        /// <param name="search">Search definition to build.</param>
        public void BuildSearch(DSSearch search)
        {
            _entity = _entityTypeRepository.Get(search.Type);

            if (_entity == null)
            {
                throw new SearchBuilderException(string.Format("Entity type '{0}' not found.", search.Type));
            }
            
            _searchBuilder.AddTable(_entity.StorageName);
            _searchBuilder.Distinct = search.Distinct;

            foreach (var item in search.Select)
            {
                ParseSelect(item);
            }

            if (search.ShouldSerializeWhere())
            {
                BuildFilter(search.Where);
            }

            if (search.ShouldSerializeOrder())
            {
                foreach (var item in search.Order)
                {
                    _searchBuilder.AddSort(GetQualifiedName(item.Name), item.Desc);
                }
            }

            // Have to add in default sort by the Key to ensure we will be paging consistently
            _searchBuilder.AddSort(GetQualifiedName(_entity.KeyName), false);

            // Apply paging
            _searchBuilder.AddPaging(search.Page, search.PageSize);

            _searchBuilder.Complete();
        }

        /// <summary>
        /// Build out the supplied filter.
        /// </summary>
        /// <param name="predicate">Filter to build out.</param>
        private void BuildFilter(DSPredicate predicate)
        {
            if (!predicate.IsValid)
            {
                return;
            }

            ProcessPredicate(predicate, predicate.OrGroup, true);

            _searchBuilder.WhereBuilder.Complete();
        }

        /// <summary>
        /// Add the supplied element to the select list along with any necessary tables needed to reach it.
        /// </summary>
        /// <param name="select">Element to add to select list.</param>
        private void ParseSelect(string select)
        {
            string path, columnAlias;
            var column = ParseColumn(select, out path, out columnAlias);
            _searchBuilder.AddSelect(path, column, columnAlias);
        }

        /// <summary>
        /// Ensure that the supplied field path is accessible and add necessary tables if it is not.
        /// </summary>
        /// <param name="fieldPath">Field path to inspect.</param>
        /// <param name="tablePath">Output parameter containing the resulting table path to the supplied field path.</param>
        /// <param name="columnAlias">Output parameter containing the resulting alias for the element.</param>
        /// <returns>Name of the element at the end of the supplied field path.</returns>
        private string ParseColumn(string fieldPath, out string tablePath, out string columnAlias)
        {
            tablePath = _entity.StorageName;
            columnAlias = null;

            var nameParts = fieldPath.Split('.');
            string column = fieldPath;

            //// TODO - properly validate all columns against actual element lists

            if (nameParts.Length == 1)
            {
                // Check to see if this is a VirtualPath
                var element = _entity.Elements[fieldPath];
                if (!string.IsNullOrEmpty(element.VirtualPath))
                {
                    nameParts = element.VirtualPath.Split('.');
                }
                else if (element.StorageName != fieldPath)
                {
                    column = element.StorageName;
                    columnAlias = string.Format("[{0}]", fieldPath);
                }
            }

            if (nameParts.Length > 1)
            {
                // This must require some table joins, need to verify they are all there
                tablePath = AddTableJoin(nameParts, out column);

                columnAlias = string.Format("[{0}]", fieldPath);
            }

            return column;
        }

        /// <summary>
        /// Get the name from the Search Builder that identifies the element for the supplied element.
        /// </summary>
        /// <param name="fieldPath">The element path to get.</param>
        /// <returns>Name from the Search Builder that identifies the element for the supplied element.</returns>
        private string GetQualifiedName(string fieldPath)
        {
            string tablePath, columnAlias;
            string name = ParseColumn(fieldPath, out tablePath, out columnAlias);
            return _searchBuilder.GetQualifiedName(tablePath, name);
        }

        /// <summary>
        /// Add all necessary tables to the search builder to reach supplied column path.
        /// </summary>
        /// <param name="columnPath">Path to the column desired.</param>
        /// <param name="column">Ultimate name of the element at the end of the path.</param>
        /// <returns>Table path to the supplied element.</returns>
        private string AddTableJoin(string[] columnPath, out string column)
        {
            var currentEntity = _entity; // All Paths must start from the base entity
            string tablePath = _entity.StorageName;

            // Unless we need to expand it, the column name will be the last item in the array
            column = columnPath[columnPath.Length - 1];

            // Convert to List so it can be expanded as needed
            var columnList = columnPath.ToList();

            for (int i = 0; i < columnList.Count; i++)
            {
                //// TODO - properly validate all columns against actual element lists

                var entityName = columnList[i];
                var element = currentEntity.Elements[entityName];
                if (!string.IsNullOrEmpty(element.VirtualPath))
                {
                    // This item is actually not a column, but a path with additional possible joins
                    var newParts = element.VirtualPath.Split('.');

                    entityName = newParts[0];
                    element = currentEntity.Elements[entityName];

                    for (int j = 1; j < newParts.Length; j++)
                    {
                        columnList.Insert(i + j, newParts[j]);

                        if (i + j == columnList.Count - 1)
                        {
                            // We have changed the column
                            column = newParts[j];
                        }
                    }
                }

                if (i == columnList.Count - 1)
                {
                    // We're at the last element, so need to stop
                    column = element.StorageName;
                    break;
                }

                if (element.DataType != DSElementTypeEnum.Reference)
                {
                    throw new SearchBuilderException(string.Format("Column not a valid reference {0} in {1}.", entityName, string.Join(".", columnPath)));
                }

                var refEntity = _entityTypeRepository.Get(element.ReferenceTypeName);
                if (refEntity == null)
                {
                    throw new SearchBuilderException(string.Format("Entity {0} not found for {1}.", element.ReferenceTypeName, string.Join(".", columnPath)));
                }

                _searchBuilder.AddTable(refEntity.StorageName, tablePath, element.StorageName, refEntity.KeyName, element.AllowNull);

                if (!string.IsNullOrEmpty(tablePath))
                {
                    tablePath += ".";
                }

                tablePath += refEntity.StorageName;

                currentEntity = refEntity;
            }

            return tablePath;
        }

        /// <summary>
        /// Helper function to recursively build out the supplied filter.
        /// </summary>
        /// <param name="clause">Current filter clause to parse.</param>
        /// <param name="orGroup">When true, then currently in an "or" grouping, otherwise in an "and" group.</param>
        /// <param name="first">When true, this is the first clause, otherwise it is not.</param>
        private void ProcessPredicate(DSPredicate clause, bool orGroup, bool first = false)
        {
            var filterBuilder = _searchBuilder.WhereBuilder;
            if (clause.IsGroup)
            {
                filterBuilder.StartGroup(orGroup, first);

                bool firstInGroup = true;
                foreach (var predicate in clause.Predicates)
                {
                    ProcessPredicate(predicate, clause.OrGroup, firstInGroup);
                    firstInGroup = false;
                }

                filterBuilder.CloseGroup();
            }
            else
            {
                filterBuilder.AppendPredicate(GetQualifiedName(clause.Column), clause.Operator, clause.Value, orGroup, first);
            }
        }
    }
}
