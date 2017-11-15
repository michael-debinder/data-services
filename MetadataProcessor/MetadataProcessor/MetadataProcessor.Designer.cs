namespace MetadataProcessor
{
    partial class MetadataProcessor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.currentContext = new System.Windows.Forms.Label();
            this.context = new System.Windows.Forms.Label();
            this.availableEntities = new System.Windows.Forms.Label();
            this.entityCheckboxes = new System.Windows.Forms.CheckedListBox();
            this.selectAllEntities = new System.Windows.Forms.CheckBox();
            this.tableSql = new System.Windows.Forms.CheckBox();
            this.tableSqlLoc = new System.Windows.Forms.TextBox();
            this.execute = new System.Windows.Forms.Button();
            this.entityTypesLoc = new System.Windows.Forms.TextBox();
            this.entityTypes = new System.Windows.Forms.CheckBox();
            this.entitiyPOCOsLoc = new System.Windows.Forms.TextBox();
            this.entitiyPOCOs = new System.Windows.Forms.CheckBox();
            this.entityPOCOAttrsLoc = new System.Windows.Forms.TextBox();
            this.entityPOCOAttrs = new System.Windows.Forms.CheckBox();
            this.entityTypeResolverLoc = new System.Windows.Forms.TextBox();
            this.entityTypeResolver = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // currentContext
            // 
            this.currentContext.AutoSize = true;
            this.currentContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentContext.Location = new System.Drawing.Point(17, 16);
            this.currentContext.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentContext.Name = "currentContext";
            this.currentContext.Size = new System.Drawing.Size(148, 20);
            this.currentContext.TabIndex = 0;
            this.currentContext.Text = "Current Context:";
            // 
            // context
            // 
            this.context.AutoSize = true;
            this.context.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.context.Location = new System.Drawing.Point(181, 16);
            this.context.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(73, 20);
            this.context.TabIndex = 1;
            this.context.Text = "Context";
            // 
            // availableEntities
            // 
            this.availableEntities.AutoSize = true;
            this.availableEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableEntities.Location = new System.Drawing.Point(21, 41);
            this.availableEntities.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.availableEntities.Name = "availableEntities";
            this.availableEntities.Size = new System.Drawing.Size(142, 20);
            this.availableEntities.TabIndex = 2;
            this.availableEntities.Text = "Available Entities:";
            // 
            // entityCheckboxes
            // 
            this.entityCheckboxes.CheckOnClick = true;
            this.entityCheckboxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityCheckboxes.FormattingEnabled = true;
            this.entityCheckboxes.Location = new System.Drawing.Point(25, 65);
            this.entityCheckboxes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entityCheckboxes.Name = "entityCheckboxes";
            this.entityCheckboxes.Size = new System.Drawing.Size(363, 466);
            this.entityCheckboxes.TabIndex = 3;
            this.entityCheckboxes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entityCheckboxes_ItemCheck);
            // 
            // selectAllEntities
            // 
            this.selectAllEntities.AutoSize = true;
            this.selectAllEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllEntities.Location = new System.Drawing.Point(279, 39);
            this.selectAllEntities.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectAllEntities.Name = "selectAllEntities";
            this.selectAllEntities.Size = new System.Drawing.Size(102, 24);
            this.selectAllEntities.TabIndex = 4;
            this.selectAllEntities.Text = "Select All";
            this.selectAllEntities.UseVisualStyleBackColor = true;
            this.selectAllEntities.CheckedChanged += new System.EventHandler(this.selectAllEntities_CheckedChanged);
            // 
            // tableSql
            // 
            this.tableSql.AutoSize = true;
            this.tableSql.Checked = true;
            this.tableSql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableSql.Location = new System.Drawing.Point(439, 65);
            this.tableSql.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableSql.Name = "tableSql";
            this.tableSql.Size = new System.Drawing.Size(185, 24);
            this.tableSql.TabIndex = 5;
            this.tableSql.Text = "Generate Table SQL";
            this.tableSql.UseVisualStyleBackColor = true;
            // 
            // tableSqlLoc
            // 
            this.tableSqlLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableSqlLoc.Location = new System.Drawing.Point(464, 98);
            this.tableSqlLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableSqlLoc.Name = "tableSqlLoc";
            this.tableSqlLoc.Size = new System.Drawing.Size(828, 26);
            this.tableSqlLoc.TabIndex = 6;
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(1193, 548);
            this.execute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(100, 28);
            this.execute.TabIndex = 7;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // entityTypesLoc
            // 
            this.entityTypesLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypesLoc.Location = new System.Drawing.Point(464, 183);
            this.entityTypesLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entityTypesLoc.Name = "entityTypesLoc";
            this.entityTypesLoc.Size = new System.Drawing.Size(828, 26);
            this.entityTypesLoc.TabIndex = 9;
            // 
            // entityTypes
            // 
            this.entityTypes.AutoSize = true;
            this.entityTypes.Checked = true;
            this.entityTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entityTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypes.Location = new System.Drawing.Point(439, 150);
            this.entityTypes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entityTypes.Name = "entityTypes";
            this.entityTypes.Size = new System.Drawing.Size(264, 24);
            this.entityTypes.TabIndex = 8;
            this.entityTypes.Text = "Generate Entity Type Definition";
            this.entityTypes.UseVisualStyleBackColor = true;
            // 
            // entitiyPOCOsLoc
            // 
            this.entitiyPOCOsLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entitiyPOCOsLoc.Location = new System.Drawing.Point(464, 274);
            this.entitiyPOCOsLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entitiyPOCOsLoc.Name = "entitiyPOCOsLoc";
            this.entitiyPOCOsLoc.Size = new System.Drawing.Size(828, 26);
            this.entitiyPOCOsLoc.TabIndex = 11;
            // 
            // entitiyPOCOs
            // 
            this.entitiyPOCOs.AutoSize = true;
            this.entitiyPOCOs.Checked = true;
            this.entitiyPOCOs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entitiyPOCOs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entitiyPOCOs.Location = new System.Drawing.Point(439, 241);
            this.entitiyPOCOs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entitiyPOCOs.Name = "entitiyPOCOs";
            this.entitiyPOCOs.Size = new System.Drawing.Size(206, 24);
            this.entitiyPOCOs.TabIndex = 10;
            this.entitiyPOCOs.Text = "Generate POCO (SDK)";
            this.entitiyPOCOs.UseVisualStyleBackColor = true;
            // 
            // entityPOCOAttrsLoc
            // 
            this.entityPOCOAttrsLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityPOCOAttrsLoc.Location = new System.Drawing.Point(464, 369);
            this.entityPOCOAttrsLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entityPOCOAttrsLoc.Name = "entityPOCOAttrsLoc";
            this.entityPOCOAttrsLoc.Size = new System.Drawing.Size(828, 26);
            this.entityPOCOAttrsLoc.TabIndex = 13;
            // 
            // entityPOCOAttrs
            // 
            this.entityPOCOAttrs.AutoSize = true;
            this.entityPOCOAttrs.Checked = true;
            this.entityPOCOAttrs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entityPOCOAttrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityPOCOAttrs.Location = new System.Drawing.Point(439, 336);
            this.entityPOCOAttrs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.entityPOCOAttrs.Name = "entityPOCOAttrs";
            this.entityPOCOAttrs.Size = new System.Drawing.Size(247, 24);
            this.entityPOCOAttrs.TabIndex = 12;
            this.entityPOCOAttrs.Text = "Generate POCO Attrs (SDK)";
            this.entityPOCOAttrs.UseVisualStyleBackColor = true;
            // 
            // entityTypeResolverLoc
            // 
            this.entityTypeResolverLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypeResolverLoc.Location = new System.Drawing.Point(464, 459);
            this.entityTypeResolverLoc.Margin = new System.Windows.Forms.Padding(4);
            this.entityTypeResolverLoc.Name = "entityTypeResolverLoc";
            this.entityTypeResolverLoc.Size = new System.Drawing.Size(828, 26);
            this.entityTypeResolverLoc.TabIndex = 15;
            // 
            // entityTypeResolver
            // 
            this.entityTypeResolver.AutoSize = true;
            this.entityTypeResolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypeResolver.Location = new System.Drawing.Point(439, 426);
            this.entityTypeResolver.Margin = new System.Windows.Forms.Padding(4);
            this.entityTypeResolver.Name = "entityTypeResolver";
            this.entityTypeResolver.Size = new System.Drawing.Size(238, 24);
            this.entityTypeResolver.TabIndex = 14;
            this.entityTypeResolver.Text = "Update EntityType Resolver";
            this.entityTypeResolver.UseVisualStyleBackColor = true;
            // 
            // MetadataProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 591);
            this.Controls.Add(this.entityTypeResolverLoc);
            this.Controls.Add(this.entityTypeResolver);
            this.Controls.Add(this.entityPOCOAttrsLoc);
            this.Controls.Add(this.entityPOCOAttrs);
            this.Controls.Add(this.entitiyPOCOsLoc);
            this.Controls.Add(this.entitiyPOCOs);
            this.Controls.Add(this.entityTypesLoc);
            this.Controls.Add(this.entityTypes);
            this.Controls.Add(this.execute);
            this.Controls.Add(this.tableSqlLoc);
            this.Controls.Add(this.tableSql);
            this.Controls.Add(this.selectAllEntities);
            this.Controls.Add(this.entityCheckboxes);
            this.Controls.Add(this.availableEntities);
            this.Controls.Add(this.context);
            this.Controls.Add(this.currentContext);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MetadataProcessor";
            this.Text = "Metadata Processor";
            this.Load += new System.EventHandler(this.MetadataProcessor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentContext;
        private System.Windows.Forms.Label context;
        private System.Windows.Forms.Label availableEntities;
        private System.Windows.Forms.CheckedListBox entityCheckboxes;
        private System.Windows.Forms.CheckBox selectAllEntities;
        private System.Windows.Forms.CheckBox tableSql;
        private System.Windows.Forms.TextBox tableSqlLoc;
        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.TextBox entityTypesLoc;
        private System.Windows.Forms.CheckBox entityTypes;
        private System.Windows.Forms.TextBox entitiyPOCOsLoc;
        private System.Windows.Forms.CheckBox entitiyPOCOs;
        private System.Windows.Forms.TextBox entityPOCOAttrsLoc;
        private System.Windows.Forms.CheckBox entityPOCOAttrs;
        private System.Windows.Forms.TextBox entityTypeResolverLoc;
        private System.Windows.Forms.CheckBox entityTypeResolver;
    }
}

