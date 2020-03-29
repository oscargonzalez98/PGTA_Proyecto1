namespace ASTERIX
{
    partial class SystemStatusCAT10
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNOGO = new System.Windows.Forms.Label();
            this.lbOVL = new System.Windows.Forms.Label();
            this.lbTSV = new System.Windows.Forms.Label();
            this.lbDIV = new System.Windows.Forms.Label();
            this.lbTTF = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.68561F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.31438F));
            this.tableLayoutPanel1.Controls.Add(this.lbTTF, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbDIV, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbTSV, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbOVL, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNOGO, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1126, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operational Release Status of the System :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Overload indicator:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(317, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time Source Validity:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Normal Operation:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(317, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Test Target Operative:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbNOGO
            // 
            this.lbNOGO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNOGO.AutoSize = true;
            this.lbNOGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbNOGO.Location = new System.Drawing.Point(326, 0);
            this.lbNOGO.Name = "lbNOGO";
            this.lbNOGO.Size = new System.Drawing.Size(797, 30);
            this.lbNOGO.TabIndex = 5;
            this.lbNOGO.Text = "Operational Release Status of the System :";
            this.lbNOGO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOVL
            // 
            this.lbOVL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOVL.AutoSize = true;
            this.lbOVL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbOVL.Location = new System.Drawing.Point(326, 30);
            this.lbOVL.Name = "lbOVL";
            this.lbOVL.Size = new System.Drawing.Size(797, 30);
            this.lbOVL.TabIndex = 6;
            this.lbOVL.Text = "Operational Release Status of the System :";
            this.lbOVL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTSV
            // 
            this.lbTSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTSV.AutoSize = true;
            this.lbTSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTSV.Location = new System.Drawing.Point(326, 60);
            this.lbTSV.Name = "lbTSV";
            this.lbTSV.Size = new System.Drawing.Size(797, 30);
            this.lbTSV.TabIndex = 7;
            this.lbTSV.Text = "Operational Release Status of the System :";
            this.lbTSV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbDIV
            // 
            this.lbDIV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDIV.AutoSize = true;
            this.lbDIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDIV.Location = new System.Drawing.Point(326, 90);
            this.lbDIV.Name = "lbDIV";
            this.lbDIV.Size = new System.Drawing.Size(797, 30);
            this.lbDIV.TabIndex = 8;
            this.lbDIV.Text = "Operational Release Status of the System :";
            this.lbDIV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTTF
            // 
            this.lbTTF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTTF.AutoSize = true;
            this.lbTTF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTTF.Location = new System.Drawing.Point(326, 120);
            this.lbTTF.Name = "lbTTF";
            this.lbTTF.Size = new System.Drawing.Size(797, 30);
            this.lbTTF.TabIndex = 9;
            this.lbTTF.Text = "Operational Release Status of the System :";
            this.lbTTF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SystemStatusCAT10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 159);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SystemStatusCAT10";
            this.Text = "SystemStatusCAT10";
            this.Load += new System.EventHandler(this.SystemStatusCAT10_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbTTF;
        private System.Windows.Forms.Label lbDIV;
        private System.Windows.Forms.Label lbTSV;
        private System.Windows.Forms.Label lbOVL;
        private System.Windows.Forms.Label lbNOGO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}