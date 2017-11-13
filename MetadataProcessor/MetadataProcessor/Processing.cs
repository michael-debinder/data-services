
namespace MetadataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using Data;

    public partial class Processing : Form
    {
        private const string PREFIX = "DS";

        private BackgroundWorker _backgroundWorker;

        public Processing()
        {
            InitializeComponent();

            InitializeBackgroundWorker();
        }

        delegate void AppendMessageCallback(string message);

        public IEnumerable<string> EntityList { get; set; }

        public string TableSqlLoc { get; set; }

        public string EntityPOCOsLoc { get; set; }

        public string EntityPOCOAttrsLoc { get; set; }

        public string EntityTypesLoc { get; set; }

        private void InitializeBackgroundWorker()
        {
            _backgroundWorker = new BackgroundWorker();

            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            _backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void Processing_Load(object sender, EventArgs e)
        {
            results.Text = string.Empty;
        }

        private void Processing_Shown(object sender, EventArgs e)
        {
            _backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            var metadata = new Metadata();
            var query = from entity in metadata.EntityTypes
                        select entity;

            appendMessage("Starting Process");

            foreach (var item in EntityList)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    appendMessage("Canceled by user.");
                    break;
                }

                appendMessage("Starting " + item);

                var entityType = query.FirstOrDefault(et => et.Name == item);
                if (entityType == null)
                {
                    appendMessage(string.Format("ERROR: {0} not found.", item));
                    continue;
                }

                GenerateTableSql(entityType);

                GenerateEntityPOCOs(entityType);

                GeneratePOCOAttrs(entityType);

                GenerateEntityTypes(entityType);
            }

            appendMessage("Complete");
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cancel.Enabled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            _backgroundWorker.CancelAsync();
        }

        private void GenerateTableSql(EntityTypes entityType)
        {
            if (string.IsNullOrEmpty(TableSqlLoc))
            {
                return;
            }

            var content = new StringBuilder();
            var constraints = new StringBuilder();

            appendMessage(string.Format("Generating {0} Table SQL.", entityType.Name));

            content.AppendFormat(@"CREATE TABLE [dbo].[{0}]", entityType.StorageName);
            content.AppendLine();
            content.AppendLine(@"(");

            var maxColLength = entityType.EntityTypeElements.Max(c => c.StorageName.Length);
            var first = true;
            foreach (var column in entityType.EntityTypeElements.Where(c => string.IsNullOrEmpty(c.VirtualPath)).OrderBy(c => c.SortOrder))
            {
                if (!first)
                {
                    content.AppendLine(",");
                    first = false;
                }

                var colType = GetDataTypeStringForSQL(column);
                content.AppendFormat(
                    "\t[{0}]{1}{2}{3}{4}NULL",
                    column.StorageName,
                    new string(' ', maxColLength - column.StorageName.Length + 3),
                    colType,
                    column.Name == entityType.KeyName ? " IDENTITY(1,1) " : new string(' ', 20 - colType.Length),
                    column.AllowNull ? string.Empty : "NOT ");

                // TODO - Allow for custom Identity Seed
            }

            content.AppendLine();

            if (constraints.Length > 0)
            {
                content.AppendLine(constraints.ToString());
            }

            content.AppendLine(@")");
            content.AppendLine("GO");
            content.AppendLine();

            WriteFile(TableSqlLoc, string.Format("{0}.sql", entityType.StorageName), content);
        }

        private void GenerateEntityPOCOs(EntityTypes entityType)
        {
            if (string.IsNullOrEmpty(EntityPOCOsLoc))
            {
                return;
            }

            var content = new StringBuilder();

            appendMessage(string.Format("Generating {0} POCOs.", entityType.Name));

            content.AppendFormat(
                @"// <copyright file=""{0}{1}.cs"" company=""Brightree LLC"">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities
{{
    using System;
    using Attrs;
    using Data;

    /// <summary>
    /// Represents a specific instance of the {1} entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class {0}{1} : {0}Entity
    {{
        /// <summary>
        /// The public name identifying this entity.
        /// </summary>
        public const string EntityName = ""{1}"";

        /// <summary>
        /// List of all available attribute names for this entity.
        /// </summary>
        private static {0}{1}Attrs _attrs = new {0}{1}Attrs();

        /// <summary>
        /// Initializes a new instance of the <see cref=""{0}{1}""/> class.
        /// </summary>
        public {0}{1}()
        {{
            Type = EntityName;
        }}

        /// <summary>
        /// Gets list of all available attribute names for this entity.
        /// </summary>
        public static {0}{1}Attrs Attrs
        {{
            get {{ return _attrs; }}
        }}
",
                PREFIX,
                entityType.Name);

            foreach (var column in entityType.EntityTypeElements.Where(c => string.IsNullOrEmpty(c.VirtualPath)).OrderBy(c => c.SortOrder))
            {
                content.AppendFormat(
                    @"
        /// <summary>
        /// Gets or sets the {0} attribute.
        /// </summary>
        public {1} {0}
        {{
            get {{ return Get<{1}>(""{0}""); }}
            set {{ this[""{0}""] = value; }}
        }}
",
                    column.Name,
                    GetDataTypeStringForCode(column));
            }

            content.AppendLine(@"    }
}");

            WriteFile(EntityPOCOsLoc, string.Format("{0}{1}.cs", PREFIX, entityType.Name), content);
        }

        private void GeneratePOCOAttrs(EntityTypes entityType)
        {
            if (string.IsNullOrEmpty(EntityPOCOAttrsLoc))
            {
                return;
            }

            var content = new StringBuilder();

            appendMessage(string.Format("Generating {0} POCO Attributes.", entityType.Name));

            var refContent = new StringBuilder();

            foreach (var column in entityType.EntityTypeElements.Where(c => !string.IsNullOrEmpty(c.ReferenceTypeName)).OrderBy(c => c.Name))
            {
                refContent.AppendFormat(
                    @"
        /// <summary>Storage for the linked {0} attributes. Note we will be lazy loading to avoid infinite loops.</summary>
        private {1}{2}Attrs _{3};
",
                    column.Name,
                    PREFIX,
                    column.ReferenceTypeName,
                    column.Name.Substring(0,1).ToLower() + column.Name.Substring(1));
            }

            content.AppendFormat(
                @"// <copyright file=""{0}{1}Attrs.cs"" company=""Brightree LLC"">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

namespace DataServices.SDK.Entities.Attrs
{{
    using Data;

    /// <summary>
    /// Represents a specific instance of the {1} entity type with strongly typed attributes.
    /// Generated from code.
    /// </summary>
    public class {0}{1}Attrs : {0}Attrs
    {{
        /// <summary>
        /// Initializes a new instance of the <see cref=""{0}{1}Attrs""/> class.
        /// </summary>
        public {0}{1}Attrs() : base()
        {{
        }}

        /// <summary>
        /// Initializes a new instance of the <see cref=""{0}{1}Attrs""/> class with its value with an alias and path.
        /// </summary>
        /// <param name=""alias"">Alias name for this attribute in the current tree.</param>
        /// <param name=""fromPath"">Path to this attribute in the current tree.</param>
        public {0}{1}Attrs(string alias, string fromPath) : base(alias, fromPath)
        {{
        }}
        {2}
",
                PREFIX,
                entityType.Name,
                refContent);

            foreach (var column in entityType.EntityTypeElements.OrderBy(c => c.Name))
            {
                if (!string.IsNullOrEmpty(column.ReferenceTypeName))
                {
                    content.AppendFormat(
                        @"
        /// <summary>Gets the {1} attribute.</summary>
        public {0}{2}Attrs {1}
        {{
            get
            {{
                if (_{3} == null)
                {{
                    _{3} = new {0}{2}Attrs(""{1}"", Path);
                }}

                return _{3};
            }}
        }}
",
                        PREFIX,
                        column.Name,
                        column.ReferenceTypeName,
                        column.Name.Substring(0, 1).ToLower() + column.Name.Substring(1));
                }
                else
                {
                    content.AppendFormat(
                        @"
        /// <summary>Gets the {0} attribute name.</summary>
        public string {0}
        {{
            get {{ return GetName(""{0}""); }}
        }}
            ",
                        column.Name);
                }
            }

            content.AppendLine(@"
    }
}");

            WriteFile(EntityPOCOAttrsLoc, string.Format("{0}{1}Attrs.cs", PREFIX, entityType.Name), content);
        }

        private void GenerateEntityTypes(EntityTypes entityType)
        {
            if (string.IsNullOrEmpty(EntityTypesLoc))
            {
                return;
            }

            var content = new StringBuilder();

            appendMessage(string.Format("Generating {0} Entity Type definition.", entityType.Name));
            content.AppendFormat(
                @"// <copyright file=""{0}.cs"" company=""Brightree LLC"">
//     Copyright (c) Brightree LLC. All rights reserved.
// </copyright>

    namespace DataServices.DataAccess.EntityTypes
    {{
        using Data;
        using SDK.Data;

        /// <summary>
        /// Entity definition for the {0} object.
        /// </summary>
        public class {0} : {1}EntityType
        {{
            /// <summary>Class name for this Entity Type.</summary>
            public const string ClassName = ""{0}"";

            /// <summary>
            /// Initializes a new instance of the <see cref=""{0}"" /> class.
            /// </summary>
            public {0}() : base()
            {{
                Name = ""{0}"";
                StorageName = ""{2}"";
                KeyName = ""{3}"";

                Add(KeyName, {1}ElementTypeEnum.Integer);
                ",
        entityType.Name,
        PREFIX,
        entityType.StorageName,
        entityType.KeyName);

            foreach (var column in entityType.EntityTypeElements.OrderBy(c => c.Name))
            {
                if (!string.IsNullOrEmpty(column.VirtualPath))
                {
                    content.AppendFormat(
                        @"
                AddVirtualElement(""{0}"", ""{1}"", {2});",
                        column.Name,
                        column.VirtualPath,
                        GetDataTypeEnumString(column));
                }
                else if (column.DataType == 7)
                {
                    content.AppendFormat(
                        @"
                AddReference(""{0}"", ""{1}"", ""{2}"");",
                        column.Name,
                        column.StorageName,
                        column.ReferenceTypeName);
                }
                else if (entityType.KeyName != column.StorageName)
                {
                    content.AppendFormat(
                        @"
                Add(""{0}"", {1}{2});",
                        column.Name,
                        GetDataTypeEnumString(column),
                        column.AllowNull ? ", true" : string.Empty);
                }
            }

            content.AppendLine(@"
        }
    }
}");
            
            WriteFile(EntityTypesLoc, string.Format("{0}.cs", entityType.Name), content);
        }

        private void appendMessage(string message)
        {
            if (results.InvokeRequired)
            {
                var d = new AppendMessageCallback(appendMessage);
                Invoke(d, new object[] { message });
            }
            else
            {
                results.Text += string.Format(
                    "{0}: {1}{2}",
                    DateTime.Now,
                    message,
                    Environment.NewLine);
            }
        }

        private void WriteFile(string path, string filename, StringBuilder content)
        {
            if (!path.EndsWith(@"\"))
            {
                path += @"\";
            }

            System.IO.File.WriteAllText(path + filename, content.ToString());
        }

        private string GetDataTypeStringForSQL(EntityTypeElements column)
        {
            switch (column.DataType)
            {
                // Integer
                case 1:
                    return string.IsNullOrEmpty(column.DataSize) ? "INT" : FormatSqlType(column.DataSize);

                // String
                case 2:
                    return column.DataSize.Contains("CHAR") || column.DataSize.Contains("Type") ? FormatSqlType(column.DataSize) : string.Format("VARCHAR ({0})", column.DataSize);

                // Boolean
                case 3:
                    return "BIT";

                // Date and DateTime
                case 4:
                case 5:
                    return "DATETIME";

                // Decimal
                case 6:
                    return column.DataSize == "MONEY" ? column.DataSize : string.Format("DECIMAL ({0})", column.DataSize);

                // Reference
                case 7:
                    return FormatSqlType("KeyType");

                // Enum
                case 8:
                    return "INT";
            }

            return null;
        }

        private string FormatSqlType(string type)
        {
            return new List<string>{ "KeyType", "NameType", "NoteType", "DescrType" }.Contains(type) ? string.Format("[dbo].[{0}]", type) : type;
        }

        private string GetDataTypeStringForCode(EntityTypeElements column)
        {
            switch (column.DataType)
            {
                // Integer
                case 1:
                    return "int";

                // String
                case 2:
                    return "string";
                    
                // Boolean
                case 3:
                    return "bool";

                // Date and DateTime
                case 4:
                case 5:
                    return "DateTime";

                // Decimal
                case 6:
                    return "decimal";

                // Reference
                case 7:
                    return "int";

                // Enum
                case 8:
                    return "int";
            }

            return null;
        }

        private string GetDataTypeEnumString(EntityTypeElements column)
        {
            switch (column.DataType)
            {
                // Integer
                case 1:
                    return PREFIX + "ElementTypeEnum.Integer";

                // String
                case 2:
                    return PREFIX + "ElementTypeEnum.String";

                // Boolean
                case 3:
                    return PREFIX + "ElementTypeEnum.Boolean";

                // Date
                case 4:
                    return PREFIX + "ElementTypeEnum.Date";

                // DateTime
                case 5:
                    return PREFIX + "ElementTypeEnum.DateTime";

                // Decimal
                case 6:
                    return PREFIX + "ElementTypeEnum.Decimal";

                // Reference
                case 7:
                    return PREFIX + "ElementTypeEnum.Reference";

                // Enum
                case 8:
                    return PREFIX + "ElementTypeEnum.Enum";
            }

            return null;
        }
    }
}
