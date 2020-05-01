namespace ASTERIX
{
    partial class Portada
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Title = new System.Windows.Forms.Label();
            this.bt_BrowseFile = new System.Windows.Forms.Button();
            this.lb_Instructions = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.lbErrores = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_Export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Title
            // 
            this.lb_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Title.AutoSize = true;
            this.lb_Title.BackColor = System.Drawing.Color.White;
            this.lb_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lb_Title.Location = new System.Drawing.Point(98, 61);
            this.lb_Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(403, 46);
            this.lb_Title.TabIndex = 0;
            this.lb_Title.Text = "ASTERIX DECODER";
            // 
            // bt_BrowseFile
            // 
            this.bt_BrowseFile.Location = new System.Drawing.Point(57, 235);
            this.bt_BrowseFile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_BrowseFile.Name = "bt_BrowseFile";
            this.bt_BrowseFile.Size = new System.Drawing.Size(76, 32);
            this.bt_BrowseFile.TabIndex = 4;
            this.bt_BrowseFile.Text = "Browse File";
            this.bt_BrowseFile.UseVisualStyleBackColor = true;
            this.bt_BrowseFile.Click += new System.EventHandler(this.bt_BrowseFile_Click);
            // 
            // lb_Instructions
            // 
            this.lb_Instructions.AutoSize = true;
            this.lb_Instructions.Location = new System.Drawing.Point(310, 164);
            this.lb_Instructions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Instructions.Name = "lb_Instructions";
            this.lb_Instructions.Size = new System.Drawing.Size(35, 13);
            this.lb_Instructions.TabIndex = 5;
            this.lb_Instructions.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tables";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbErrores
            // 
            this.lbErrores.AutoSize = true;
            this.lbErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbErrores.ForeColor = System.Drawing.Color.Red;
            this.lbErrores.Location = new System.Drawing.Point(53, 312);
            this.lbErrores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbErrores.Name = "lbErrores";
            this.lbErrores.Size = new System.Drawing.Size(46, 18);
            this.lbErrores.TabIndex = 8;
            this.lbErrores.Text = "label1";
            this.lbErrores.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(218, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 32);
            this.button3.TabIndex = 9;
            this.button3.Text = "Map Simulation";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(420, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "More Info";
            // 
            // bt_Export
            // 
            this.bt_Export.Location = new System.Drawing.Point(319, 235);
            this.bt_Export.Name = "bt_Export";
            this.bt_Export.Size = new System.Drawing.Size(95, 32);
            this.bt_Export.TabIndex = 11;
            this.bt_Export.Text = "Export";
            this.bt_Export.Click += new System.EventHandler(this.bt_Export_Click);
            // 
            // Portada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 405);
            this.Controls.Add(this.bt_Export);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbErrores);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_Instructions);
            this.Controls.Add(this.bt_BrowseFile);
            this.Controls.Add(this.lb_Title);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Portada";
            this.Load += new System.EventHandler(this.Portada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Button bt_BrowseFile;
        private System.Windows.Forms.Label lb_Instructions;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbErrores;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bt_Export;
    }
}

