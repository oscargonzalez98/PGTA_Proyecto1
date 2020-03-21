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
            this.btn_mapviewer = new System.Windows.Forms.Button();
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
            this.bt_BrowseFile.Margin = new System.Windows.Forms.Padding(2);
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
            this.lb_Instructions.Location = new System.Drawing.Point(257, 177);
            this.lb_Instructions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Instructions.Name = "lb_Instructions";
            this.lb_Instructions.Size = new System.Drawing.Size(35, 13);
            this.lb_Instructions.TabIndex = 5;
            this.lb_Instructions.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tables";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_mapviewer
            // 
            this.btn_mapviewer.Location = new System.Drawing.Point(218, 235);
            this.btn_mapviewer.Name = "btn_mapviewer";
            this.btn_mapviewer.Size = new System.Drawing.Size(95, 32);
            this.btn_mapviewer.TabIndex = 0;
            this.btn_mapviewer.Text = "Map Viewer";
            this.btn_mapviewer.Click += new System.EventHandler(this.btn_mapviewer_Click);
            // 
            // Portada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_mapviewer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lb_Instructions);
            this.Controls.Add(this.bt_BrowseFile);
            this.Controls.Add(this.lb_Title);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Portada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Title;
        private System.Windows.Forms.Button bt_BrowseFile;
        private System.Windows.Forms.Label lb_Instructions;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_mapviewer;
    }
}

