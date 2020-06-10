namespace ASTERIX
{
    partial class ED
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
            this.pb_PrecissionAccuracy = new System.Windows.Forms.ProgressBar();
            this.bt_CalcularPrecissionAccuracy = new System.Windows.Forms.Button();
            this.lb_meandistance = new System.Windows.Forms.Label();
            this.lb_95percentile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_ProbabilityofUpdate = new System.Windows.Forms.Button();
            this.pb_probabilityofupdate = new System.Windows.Forms.ProgressBar();
            this.lb_aviones_mal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_PD = new System.Windows.Forms.Label();
            this.pb_PD = new System.Windows.Forms.Button();
            this.pb_ProbDetect = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_PA = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_PrecissionAccuracy
            // 
            this.pb_PrecissionAccuracy.Location = new System.Drawing.Point(40, 256);
            this.pb_PrecissionAccuracy.Name = "pb_PrecissionAccuracy";
            this.pb_PrecissionAccuracy.Size = new System.Drawing.Size(232, 21);
            this.pb_PrecissionAccuracy.Step = 1;
            this.pb_PrecissionAccuracy.TabIndex = 0;
            // 
            // bt_CalcularPrecissionAccuracy
            // 
            this.bt_CalcularPrecissionAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_CalcularPrecissionAccuracy.Location = new System.Drawing.Point(40, 215);
            this.bt_CalcularPrecissionAccuracy.Name = "bt_CalcularPrecissionAccuracy";
            this.bt_CalcularPrecissionAccuracy.Size = new System.Drawing.Size(232, 30);
            this.bt_CalcularPrecissionAccuracy.TabIndex = 1;
            this.bt_CalcularPrecissionAccuracy.Text = "Calculate Precission Accuracy";
            this.bt_CalcularPrecissionAccuracy.UseVisualStyleBackColor = true;
            this.bt_CalcularPrecissionAccuracy.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_meandistance
            // 
            this.lb_meandistance.AutoSize = true;
            this.lb_meandistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_meandistance.Location = new System.Drawing.Point(418, 215);
            this.lb_meandistance.Name = "lb_meandistance";
            this.lb_meandistance.Size = new System.Drawing.Size(124, 20);
            this.lb_meandistance.TabIndex = 2;
            this.lb_meandistance.Text = "Mean Distance: ";
            this.lb_meandistance.Visible = false;
            this.lb_meandistance.Click += new System.EventHandler(this.lb_meandistance_Click);
            // 
            // lb_95percentile
            // 
            this.lb_95percentile.AutoSize = true;
            this.lb_95percentile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_95percentile.Location = new System.Drawing.Point(408, 256);
            this.lb_95percentile.Name = "lb_95percentile";
            this.lb_95percentile.Size = new System.Drawing.Size(109, 20);
            this.lb_95percentile.TabIndex = 6;
            this.lb_95percentile.Text = "95 Percentile: ";
            this.lb_95percentile.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mean Distance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "95 Percentile: ";
            // 
            // lb_ProbabilityofUpdate
            // 
            this.lb_ProbabilityofUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ProbabilityofUpdate.Location = new System.Drawing.Point(40, 128);
            this.lb_ProbabilityofUpdate.Name = "lb_ProbabilityofUpdate";
            this.lb_ProbabilityofUpdate.Size = new System.Drawing.Size(232, 30);
            this.lb_ProbabilityofUpdate.TabIndex = 10;
            this.lb_ProbabilityofUpdate.Text = "Calculate Probability of Update";
            this.lb_ProbabilityofUpdate.UseVisualStyleBackColor = true;
            this.lb_ProbabilityofUpdate.Click += new System.EventHandler(this.lb_ProbabilityofUpdate_Click);
            // 
            // pb_probabilityofupdate
            // 
            this.pb_probabilityofupdate.Location = new System.Drawing.Point(40, 169);
            this.pb_probabilityofupdate.Name = "pb_probabilityofupdate";
            this.pb_probabilityofupdate.Size = new System.Drawing.Size(232, 21);
            this.pb_probabilityofupdate.Step = 1;
            this.pb_probabilityofupdate.TabIndex = 9;
            // 
            // lb_aviones_mal
            // 
            this.lb_aviones_mal.AutoSize = true;
            this.lb_aviones_mal.Location = new System.Drawing.Point(279, 169);
            this.lb_aviones_mal.Name = "lb_aviones_mal";
            this.lb_aviones_mal.Size = new System.Drawing.Size(35, 13);
            this.lb_aviones_mal.TabIndex = 11;
            this.lb_aviones_mal.Text = "label1";
            this.lb_aviones_mal.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Planes that don\'t update position at least once every second at least 95% of time" +
    "s:\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(278, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Probability of Detection:";
            // 
            // lb_PD
            // 
            this.lb_PD.AutoSize = true;
            this.lb_PD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PD.Location = new System.Drawing.Point(476, 40);
            this.lb_PD.Name = "lb_PD";
            this.lb_PD.Size = new System.Drawing.Size(124, 20);
            this.lb_PD.TabIndex = 15;
            this.lb_PD.Text = "Mean Distance: ";
            this.lb_PD.Visible = false;
            // 
            // pb_PD
            // 
            this.pb_PD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pb_PD.Location = new System.Drawing.Point(40, 38);
            this.pb_PD.Name = "pb_PD";
            this.pb_PD.Size = new System.Drawing.Size(232, 30);
            this.pb_PD.TabIndex = 14;
            this.pb_PD.Text = "Calculate Probability of Detection";
            this.pb_PD.UseVisualStyleBackColor = true;
            this.pb_PD.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // pb_ProbDetect
            // 
            this.pb_ProbDetect.Location = new System.Drawing.Point(40, 79);
            this.pb_ProbDetect.Name = "pb_ProbDetect";
            this.pb_ProbDetect.Size = new System.Drawing.Size(232, 21);
            this.pb_ProbDetect.Step = 1;
            this.pb_ProbDetect.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Horizontal Precission Accuracy:";
            // 
            // lb_PA
            // 
            this.lb_PA.AutoSize = true;
            this.lb_PA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PA.Location = new System.Drawing.Point(548, 295);
            this.lb_PA.Name = "lb_PA";
            this.lb_PA.Size = new System.Drawing.Size(109, 20);
            this.lb_PA.TabIndex = 18;
            this.lb_PA.Text = "95 Percentile: ";
            this.lb_PA.Visible = false;
            // 
            // ED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 337);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_PA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_PD);
            this.Controls.Add(this.pb_PD);
            this.Controls.Add(this.pb_ProbDetect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_aviones_mal);
            this.Controls.Add(this.lb_ProbabilityofUpdate);
            this.Controls.Add(this.pb_probabilityofupdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_95percentile);
            this.Controls.Add(this.lb_meandistance);
            this.Controls.Add(this.bt_CalcularPrecissionAccuracy);
            this.Controls.Add(this.pb_PrecissionAccuracy);
            this.Name = "ED";
            this.Text = "EDcs";
            this.Load += new System.EventHandler(this.EDcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_PrecissionAccuracy;
        private System.Windows.Forms.Button bt_CalcularPrecissionAccuracy;
        private System.Windows.Forms.Label lb_meandistance;
        private System.Windows.Forms.Label lb_95percentile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button lb_ProbabilityofUpdate;
        private System.Windows.Forms.ProgressBar pb_probabilityofupdate;
        private System.Windows.Forms.Label lb_aviones_mal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_PD;
        private System.Windows.Forms.Button pb_PD;
        private System.Windows.Forms.ProgressBar pb_ProbDetect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_PA;
    }
}