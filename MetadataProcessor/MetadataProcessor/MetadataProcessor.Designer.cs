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
            this.SuspendLayout();
            // 
            // currentContext
            // 
            this.currentContext.AutoSize = true;
            this.currentContext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentContext.Location = new System.Drawing.Point(13, 13);
            this.currentContext.Name = "currentContext";
            this.currentContext.Size = new System.Drawing.Size(116, 16);
            this.currentContext.TabIndex = 0;
            this.currentContext.Text = "Current Context:";
            // 
            // context
            // 
            this.context.AutoSize = true;
            this.context.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.context.Location = new System.Drawing.Point(136, 13);
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(59, 16);
            this.context.TabIndex = 1;
            this.context.Text = "Context";
            // 
            // availableEntities
            // 
            this.availableEntities.AutoSize = true;
            this.availableEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.availableEntities.Location = new System.Drawing.Point(16, 33);
            this.availableEntities.Name = "availableEntities";
            this.availableEntities.Size = new System.Drawing.Size(114, 16);
            this.availableEntities.TabIndex = 2;
            this.availableEntities.Text = "Available Entities:";
            // 
            // entityCheckboxes
            // 
            this.entityCheckboxes.CheckOnClick = true;
            this.entityCheckboxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityCheckboxes.FormattingEnabled = true;
            this.entityCheckboxes.Location = new System.Drawing.Point(19, 53);
            this.entityCheckboxes.Name = "entityCheckboxes";
            this.entityCheckboxes.Size = new System.Drawing.Size(273, 395);
            this.entityCheckboxes.TabIndex = 3;
            this.entityCheckboxes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.entityCheckboxes_ItemCheck);
            // 
            // selectAllEntities
            // 
            this.selectAllEntities.AutoSize = true;
            this.selectAllEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectAllEntities.Location = new System.Drawing.Point(209, 32);
            this.selectAllEntities.Name = "selectAllEntities";
            this.selectAllEntities.Size = new System.Drawing.Size(83, 20);
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
            this.tableSql.Location = new System.Drawing.Point(329, 53);
            this.tableSql.Name = "tableSql";
            this.tableSql.Size = new System.Drawing.Size(151, 20);
            this.tableSql.TabIndex = 5;
            this.tableSql.Text = "Generate Table SQL";
            this.tableSql.UseVisualStyleBackColor = true;
            // 
            // tableSqlLoc
            // 
            this.tableSqlLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableSqlLoc.Location = new System.Drawing.Point(348, 80);
            this.tableSqlLoc.Name = "tableSqlLoc";
            this.tableSqlLoc.Size = new System.Drawing.Size(622, 22);
            this.tableSqlLoc.TabIndex = 6;
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(895, 445);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(75, 23);
            this.execute.TabIndex = 7;
            this.execute.Text = "Execute";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // entityTypesLoc
            // 
            this.entityTypesLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypesLoc.Location = new System.Drawing.Point(348, 149);
            this.entityTypesLoc.Name = "entityTypesLoc";
            this.entityTypesLoc.Size = new System.Drawing.Size(622, 22);
            this.entityTypesLoc.TabIndex = 9;
            // 
            // entityTypes
            // 
            this.entityTypes.AutoSize = true;
            this.entityTypes.Checked = true;
            this.entityTypes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entityTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityTypes.Location = new System.Drawing.Point(329, 122);
            this.entityTypes.Name = "entityTypes";
            this.entityTypes.Size = new System.Drawing.Size(211, 20);
            this.entityTypes.TabIndex = 8;
            this.entityTypes.Text = "Generate Entity Type Definition";
            this.entityTypes.UseVisualStyleBackColor = true;
            // 
            // entitiyPOCOsLoc
            // 
            this.entitiyPOCOsLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entitiyPOCOsLoc.Location = new System.Drawing.Point(348, 223);
            this.entitiyPOCOsLoc.Name = "entitiyPOCOsLoc";
            this.entitiyPOCOsLoc.Size = new System.Drawing.Size(622, 22);
            this.entitiyPOCOsLoc.TabIndex = 11;
            // 
            // entitiyPOCOs
            // 
            this.entitiyPOCOs.AutoSize = true;
            this.entitiyPOCOs.Checked = true;
            this.entitiyPOCOs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entitiyPOCOs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entitiyPOCOs.Location = new System.Drawing.Point(329, 196);
            this.entitiyPOCOs.Name = "entitiyPOCOs";
            this.entitiyPOCOs.Size = new System.Drawing.Size(162, 20);
            this.entitiyPOCOs.TabIndex = 10;
            this.entitiyPOCOs.Text = "Generate POCO (SDK)";
            this.entitiyPOCOs.UseVisualStyleBackColor = true;
            // 
            // entityPOCOAttrsLoc
            // 
            this.entityPOCOAttrsLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityPOCOAttrsLoc.Location = new System.Drawing.Point(348, 300);
            this.entityPOCOAttrsLoc.Name = "entityPOCOAttrsLoc";
            this.entityPOCOAttrsLoc.Size = new System.Drawing.Size(622, 22);
            this.entityPOCOAttrsLoc.TabIndex = 13;
            // 
            // entityPOCOAttrs
            // 
            this.entityPOCOAttrs.AutoSize = true;
            this.entityPOCOAttrs.Checked = true;
            this.entityPOCOAttrs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.entityPOCOAttrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.entityPOCOAttrs.Location = new System.Drawing.Point(329, 273);
            this.entityPOCOAttrs.Name = "entityPOCOAttrs";
            this.entityPOCOAttrs.Size = new System.Drawing.Size(191, 20);
            this.entityPOCOAttrs.TabIndex = 12;
            this.entityPOCOAttrs.Text = "Generate POCO Attrs (SDK)";
            this.entityPOCOAttrs.UseVisualStyleBackColor = true;
            // 
            // MetadataProcessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 480);
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
    }
}

