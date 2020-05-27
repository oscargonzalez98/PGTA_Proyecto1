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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pb_probabiliyofupdate = new System.Windows.Forms.ProgressBar();
            this.lb_95percentile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_PrecissionAccuracy
            // 
            this.pb_PrecissionAccuracy.Location = new System.Drawing.Point(275, 39);
            this.pb_PrecissionAccuracy.Name = "pb_PrecissionAccuracy";
            this.pb_PrecissionAccuracy.Size = new System.Drawing.Size(222, 30);
            this.pb_PrecissionAccuracy.Step = 1;
            this.pb_PrecissionAccuracy.TabIndex = 0;
            // 
            // bt_CalcularPrecissionAccuracy
            // 
            this.bt_CalcularPrecissionAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_CalcularPrecissionAccuracy.Location = new System.Drawing.Point(25, 39);
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
            this.lb_meandistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_meandistance.Location = new System.Drawing.Point(623, 48);
            this.lb_meandistance.Name = "lb_meandistance";
            this.lb_meandistance.Size = new System.Drawing.Size(85, 13);
            this.lb_meandistance.TabIndex = 2;
            this.lb_meandistance.Text = "Mean Distance: ";
            this.lb_meandistance.Visible = false;
            this.lb_meandistance.Click += new System.EventHandler(this.lb_meandistance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Precission Accuracy (%):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate Probability of Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pb_probabiliyofupdate
            // 
            this.pb_probabiliyofupdate.Location = new System.Drawing.Point(429, 305);
            this.pb_probabiliyofupdate.Name = "pb_probabiliyofupdate";
            this.pb_probabiliyofupdate.Size = new System.Drawing.Size(100, 20);
            this.pb_probabiliyofupdate.Step = 1;
            this.pb_probabiliyofupdate.TabIndex = 3;
            // 
            // lb_95percentile
            // 
            this.lb_95percentile.AutoSize = true;
            this.lb_95percentile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_95percentile.Location = new System.Drawing.Point(856, 48);
            this.lb_95percentile.Name = "lb_95percentile";
            this.lb_95percentile.Size = new System.Drawing.Size(75, 13);
            this.lb_95percentile.TabIndex = 6;
            this.lb_95percentile.Text = "95 Percentile: ";
            this.lb_95percentile.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(521, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mean Distance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(760, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "95 Percentile: ";
            // 
            // ED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 510);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_95percentile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pb_probabiliyofupdate);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pb_probabiliyofupdate;
        private System.Windows.Forms.Label lb_95percentile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}