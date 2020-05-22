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
            this.lb_PrecissionAccuracy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pb_probabiliyofupdate = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pb_PrecissionAccuracy
            // 
            this.pb_PrecissionAccuracy.Location = new System.Drawing.Point(180, 49);
            this.pb_PrecissionAccuracy.Name = "pb_PrecissionAccuracy";
            this.pb_PrecissionAccuracy.Size = new System.Drawing.Size(100, 20);
            this.pb_PrecissionAccuracy.Step = 1;
            this.pb_PrecissionAccuracy.TabIndex = 0;
            // 
            // bt_CalcularPrecissionAccuracy
            // 
            this.bt_CalcularPrecissionAccuracy.Location = new System.Drawing.Point(286, 49);
            this.bt_CalcularPrecissionAccuracy.Name = "bt_CalcularPrecissionAccuracy";
            this.bt_CalcularPrecissionAccuracy.Size = new System.Drawing.Size(162, 20);
            this.bt_CalcularPrecissionAccuracy.TabIndex = 1;
            this.bt_CalcularPrecissionAccuracy.Text = "Calculate Precission Accuracy";
            this.bt_CalcularPrecissionAccuracy.UseVisualStyleBackColor = true;
            this.bt_CalcularPrecissionAccuracy.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_PrecissionAccuracy
            // 
            this.lb_PrecissionAccuracy.AutoSize = true;
            this.lb_PrecissionAccuracy.Location = new System.Drawing.Point(12, 53);
            this.lb_PrecissionAccuracy.Name = "lb_PrecissionAccuracy";
            this.lb_PrecissionAccuracy.Size = new System.Drawing.Size(123, 13);
            this.lb_PrecissionAccuracy.TabIndex = 2;
            this.lb_PrecissionAccuracy.Text = "Precission Accuracy (%):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Precission Accuracy (%):";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Calculate Probability of Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pb_probabiliyofupdate
            // 
            this.pb_probabiliyofupdate.Location = new System.Drawing.Point(180, 85);
            this.pb_probabiliyofupdate.Name = "pb_probabiliyofupdate";
            this.pb_probabiliyofupdate.Size = new System.Drawing.Size(100, 20);
            this.pb_probabiliyofupdate.Step = 1;
            this.pb_probabiliyofupdate.TabIndex = 3;
            // 
            // ED
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 510);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pb_probabiliyofupdate);
            this.Controls.Add(this.lb_PrecissionAccuracy);
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
        private System.Windows.Forms.Label lb_PrecissionAccuracy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar pb_probabiliyofupdate;
    }
}