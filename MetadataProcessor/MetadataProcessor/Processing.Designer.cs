namespace MetadataProcessor
{
    partial class Processing
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
            this.results = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(13, 13);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.results.Size = new System.Drawing.Size(611, 261);
            this.results.TabIndex = 0;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(548, 282);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Processing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 317);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.results);
            this.Name = "Processing";
            this.Text = "Processing";
            this.Load += new System.EventHandler(this.Processing_Load);
            this.Shown += new System.EventHandler(this.Processing_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.Button cancel;
    }
}