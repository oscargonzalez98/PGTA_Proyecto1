namespace ASTERIX
{
    partial class Export
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
            this.bt_ExportKML = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_direction = new System.Windows.Forms.TextBox();
            this.bt_Browse = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_ExportKML
            // 
            this.bt_ExportKML.Location = new System.Drawing.Point(243, 112);
            this.bt_ExportKML.Name = "bt_ExportKML";
            this.bt_ExportKML.Size = new System.Drawing.Size(231, 37);
            this.bt_ExportKML.TabIndex = 0;
            this.bt_ExportKML.Text = "Export to .kml (Google Earth)";
            this.bt_ExportKML.UseVisualStyleBackColor = true;
            this.bt_ExportKML.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name and direction to save the file:";
            // 
            // tb_direction
            // 
            this.tb_direction.Location = new System.Drawing.Point(243, 64);
            this.tb_direction.Name = "tb_direction";
            this.tb_direction.Size = new System.Drawing.Size(231, 20);
            this.tb_direction.TabIndex = 4;
            // 
            // bt_Browse
            // 
            this.bt_Browse.Location = new System.Drawing.Point(480, 61);
            this.bt_Browse.Name = "bt_Browse";
            this.bt_Browse.Size = new System.Drawing.Size(75, 23);
            this.bt_Browse.TabIndex = 5;
            this.bt_Browse.Text = "Browse";
            this.bt_Browse.UseVisualStyleBackColor = true;
            this.bt_Browse.Click += new System.EventHandler(this.bt_Browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "IMPORTANT: When creating a file to export finish the name with \".kml\". Otherwise " +
    "it won\'t work";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_Browse);
            this.Controls.Add(this.tb_direction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_ExportKML);
            this.Name = "Export";
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ExportKML;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_direction;
        private System.Windows.Forms.Button bt_Browse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
    }
}