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
            this.bt_SelectFile = new System.Windows.Forms.Button();
            this.tbDirection = new System.Windows.Forms.TextBox();
            this.bt_Decode = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_SelectFile
            // 
            this.bt_SelectFile.Location = new System.Drawing.Point(41, 199);
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
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(435, 22);
            this.tbDirection.TabIndex = 1;
            // 
            // bt_Decode
            // 
            this.bt_Decode.Location = new System.Drawing.Point(341, 292);
            this.bt_Decode.Name = "bt_Decode";
            this.bt_Decode.Size = new System.Drawing.Size(130, 43);
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
            this.lblError.Location = new System.Drawing.Point(353, 238);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(109, 39);
            this.lblError.TabIndex = 3;
            this.lblError.Text = "label1";
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
            this.Name = "BrowseFile";
            this.Text = "BrowseFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_SelectFile;
        private System.Windows.Forms.TextBox tbDirection;
        private System.Windows.Forms.Button bt_Decode;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblError;
    }
}