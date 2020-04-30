namespace ASTERIX
{
    partial class BrowseFile
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
            this.components = new System.ComponentModel.Container();
            this.bt_SelectFile = new System.Windows.Forms.Button();
            this.tbDirection = new System.Windows.Forms.TextBox();
            this.bt_Decode = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblError = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_SelectFile
            // 
            this.bt_SelectFile.Location = new System.Drawing.Point(41, 199);
            this.bt_SelectFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_SelectFile.Name = "bt_SelectFile";
            this.bt_SelectFile.Size = new System.Drawing.Size(168, 32);
            this.bt_SelectFile.TabIndex = 0;
            this.bt_SelectFile.Text = "Select File";
            this.bt_SelectFile.UseVisualStyleBackColor = true;
            this.bt_SelectFile.Click += new System.EventHandler(this.bt_SelectFile_Click);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(228, 204);
            this.tbDirection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(435, 22);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.TextChanged += new System.EventHandler(this.tbDirection_TextChanged);
            // 
            // bt_Decode
            // 
            this.bt_Decode.Location = new System.Drawing.Point(342, 312);
            this.bt_Decode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Decode.Name = "bt_Decode";
            this.bt_Decode.Size = new System.Drawing.Size(131, 43);
            this.bt_Decode.TabIndex = 2;
            this.bt_Decode.Text = "Decode";
            this.bt_Decode.UseVisualStyleBackColor = true;
            this.bt_Decode.Click += new System.EventHandler(this.bt_Decode_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.Color.White;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblError.Location = new System.Drawing.Point(368, 267);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(86, 31);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "label1";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.White;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lbTitle.Location = new System.Drawing.Point(24, 80);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(109, 39);
            this.lbTitle.TabIndex = 4;
            this.lbTitle.Text = "label1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // BrowseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.bt_Decode);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.bt_SelectFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BrowseFile";
            this.Text = "BrowseFile";
            this.Load += new System.EventHandler(this.BrowseFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_SelectFile;
        private System.Windows.Forms.TextBox tbDirection;
        private System.Windows.Forms.Button bt_Decode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}