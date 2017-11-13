// <copyright file="EntityConversion.cs" company="[None]">
//     Copyright (c) Michael DeBinder. All rights reserved.
// </copyright>

namespace DataServices.DataAccess.Data
{
    using System.Collections.Generic;
    using System.Data;
    using SDK.Data;

    /// <summary>
    /// Methods to convert data results into Entity classes.
    /// </summary>
    public static class DSEntityConversion
    {
        /// <summary>
        /// Conversion method to generate a list of generic entities from basic data table.
        /// </summary>
        /// <param name="dataTable">Table of results that can be converted to the dictionary.</param>
        /// <returns>List of Entity classes containing the supplied data.</returns>
        public static List<DSEntity> ToEntityList(this DataTable dataTable)
        {
            return ToEntityList<DSEntity>(dataTable);
        }

        /// <summary>
        /// Conversion method to generate a list of specified entities from basic data table.
        /// </summary>
        /// <typeparam name="T">Entity subclass the result list should contain.</typeparam>
        /// <param name="dataTable">Table of results that can be converted to the dictionary.</param>
        /// <returns>List of Entity classes containing the supplied data.</returns>
        public static List<DSEntity> ToEntityList<T>(this DataTable dataTable) where T : DSEntity, new() 
        {
            var entityList = new List<DSEntity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                var newEntity = new T();
                foreach (DataColumn col in dataTable.Columns)
                {
                    newEntity[col.ColumnName] = dr[col.ColumnName];
                }

                entityList.Add(newEntity);
            }

            return entityList;
        }
    }
}
