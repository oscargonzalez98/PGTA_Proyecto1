namespace ASTERIX
{
    partial class PruebasMapas
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
            this.gMapControl2 = new GMap.NET.WindowsForms.GMapControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Errores = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_20 = new System.Windows.Forms.RadioButton();
            this.rb_10 = new System.Windows.Forms.RadioButton();
            this.rb_4 = new System.Windows.Forms.RadioButton();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_1 = new System.Windows.Forms.RadioButton();
            this.rb_05 = new System.Windows.Forms.RadioButton();
            this.rb_025 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_AllFlightsByTime = new System.Windows.Forms.RadioButton();
            this.rb_SimulateSingleFlightbyTime = new System.Windows.Forms.RadioButton();
            this.tb_targetIdentification = new System.Windows.Forms.TextBox();
            this.lbPlot = new System.Windows.Forms.Button();
            this.lb_tiempo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbPlay_Pause = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl2
            // 
            this.gMapControl2.Bearing = 0F;
            this.gMapControl2.CanDragMap = true;
            this.gMapControl2.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl2.GrayScaleMode = false;
            this.gMapControl2.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl2.LevelsKeepInMemmory = 5;
            this.gMapControl2.Location = new System.Drawing.Point(973, 0);
            this.gMapControl2.Margin = new System.Windows.Forms.Padding(4);
            this.gMapControl2.MarkersEnabled = true;
            this.gMapControl2.MaxZoom = 2;
            this.gMapControl2.MinZoom = 2;
            this.gMapControl2.MouseWheelZoomEnabled = true;
            this.gMapControl2.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl2.Name = "gMapControl2";
            this.gMapControl2.NegativeMode = false;
            this.gMapControl2.PolygonsEnabled = true;
            this.gMapControl2.RetryLoadTile = 0;
            this.gMapControl2.RoutesEnabled = true;
            this.gMapControl2.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl2.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl2.ShowTileGridLines = false;
            this.gMapControl2.Size = new System.Drawing.Size(200, 185);
            this.gMapControl2.TabIndex = 1;
            this.gMapControl2.Zoom = 0D;
            this.gMapControl2.Load += new System.EventHandler(this.gMapControl2_Load);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.map, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPlay_Pause, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lb_Errores, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_targetIdentification, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbPlot, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.lb_tiempo, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1506, 771);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // map
            // 
            this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(4, 4);
            this.map.Margin = new System.Windows.Forms.Padding(4);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.tableLayoutPanel1.SetRowSpan(this.map, 10);
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1003, 765);
            this.map.TabIndex = 1;
            this.map.Zoom = 0D;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 3);
            this.label2.Location = new System.Drawing.Point(1087, 372);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 34);
            this.label2.TabIndex = 13;
            this.label2.Text = "IMPORTANT: Sometimes you have to Zoom in and Zoom out to update the map!!!";
            // 
            // lb_Errores
            // 
            this.lb_Errores.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_Errores, 3);
            this.lb_Errores.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.lb_Errores.ForeColor = System.Drawing.Color.Red;
            this.lb_Errores.Location = new System.Drawing.Point(1087, 434);
            this.lb_Errores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Errores.Name = "lb_Errores";
            this.lb_Errores.Size = new System.Drawing.Size(141, 20);
            this.lb_Errores.TabIndex = 14;
            this.lb_Errores.Text = "label para errores";
            this.lb_Errores.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(1015, 500);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 54);
            this.panel1.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rb_20);
            this.groupBox2.Controls.Add(this.rb_10);
            this.groupBox2.Controls.Add(this.rb_4);
            this.groupBox2.Controls.Add(this.rb_2);
            this.groupBox2.Controls.Add(this.rb_1);
            this.groupBox2.Controls.Add(this.rb_05);
            this.groupBox2.Controls.Add(this.rb_025);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(-3, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(425, 50);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // rb_20
            // 
            this.rb_20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_20.AutoSize = true;
            this.rb_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_20.Location = new System.Drawing.Point(374, 18);
            this.rb_20.Margin = new System.Windows.Forms.Padding(4);
            this.rb_20.Name = "rb_20";
            this.rb_20.Size = new System.Drawing.Size(56, 24);
            this.rb_20.TabIndex = 15;
            this.rb_20.Text = "x20";
            this.rb_20.UseVisualStyleBackColor = true;
            // 
            // rb_10
            // 
            this.rb_10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_10.AutoSize = true;
            this.rb_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_10.Location = new System.Drawing.Point(312, 18);
            this.rb_10.Margin = new System.Windows.Forms.Padding(4);
            this.rb_10.Name = "rb_10";
            this.rb_10.Size = new System.Drawing.Size(56, 24);
            this.rb_10.TabIndex = 14;
            this.rb_10.Text = "x10";
            this.rb_10.UseVisualStyleBackColor = true;
            // 
            // rb_4
            // 
            this.rb_4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_4.AutoSize = true;
            this.rb_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_4.Location = new System.Drawing.Point(257, 18);
            this.rb_4.Margin = new System.Windows.Forms.Padding(4);
            this.rb_4.Name = "rb_4";
            this.rb_4.Size = new System.Drawing.Size(47, 24);
            this.rb_4.TabIndex = 13;
            this.rb_4.Text = "x4";
            this.rb_4.UseVisualStyleBackColor = true;
            // 
            // rb_2
            // 
            this.rb_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_2.AutoSize = true;
            this.rb_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_2.Location = new System.Drawing.Point(208, 18);
            this.rb_2.Margin = new System.Windows.Forms.Padding(4);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(47, 24);
            this.rb_2.TabIndex = 12;
            this.rb_2.Text = "x2";
            this.rb_2.UseVisualStyleBackColor = true;
            this.rb_2.CheckedChanged += new System.EventHandler(this.rb_2_CheckedChanged);
            // 
            // rb_1
            // 
            this.rb_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_1.AutoSize = true;
            this.rb_1.Checked = true;
            this.rb_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_1.Location = new System.Drawing.Point(153, 18);
            this.rb_1.Margin = new System.Windows.Forms.Padding(4);
            this.rb_1.Name = "rb_1";
            this.rb_1.Size = new System.Drawing.Size(47, 24);
            this.rb_1.TabIndex = 11;
            this.rb_1.TabStop = true;
            this.rb_1.Text = "x1";
            this.rb_1.UseVisualStyleBackColor = true;
            // 
            // rb_05
            // 
            this.rb_05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_05.AutoSize = true;
            this.rb_05.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_05.Location = new System.Drawing.Point(85, 18);
            this.rb_05.Margin = new System.Windows.Forms.Padding(4);
            this.rb_05.Name = "rb_05";
            this.rb_05.Size = new System.Drawing.Size(60, 24);
            this.rb_05.TabIndex = 10;
            this.rb_05.Text = "x0.5";
            this.rb_05.UseVisualStyleBackColor = true;
            // 
            // rb_025
            // 
            this.rb_025.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_025.AutoSize = true;
            this.rb_025.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_025.Location = new System.Drawing.Point(8, 18);
            this.rb_025.Margin = new System.Windows.Forms.Padding(4);
            this.rb_025.Name = "rb_025";
            this.rb_025.Size = new System.Drawing.Size(69, 24);
            this.rb_025.TabIndex = 9;
            this.rb_025.Text = "x0.25";
            this.rb_025.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(8, 59);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(225, 24);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.Text = "SIMULATE ALL FLIGHTS";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.rb_AllFlightsByTime);
            this.groupBox1.Controls.Add(this.rb_SimulateSingleFlightbyTime);
            this.groupBox1.Location = new System.Drawing.Point(1087, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(354, 116);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // rb_AllFlightsByTime
            // 
            this.rb_AllFlightsByTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_AllFlightsByTime.AutoSize = true;
            this.rb_AllFlightsByTime.Checked = true;
            this.rb_AllFlightsByTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_AllFlightsByTime.Location = new System.Drawing.Point(8, 23);
            this.rb_AllFlightsByTime.Margin = new System.Windows.Forms.Padding(4);
            this.rb_AllFlightsByTime.Name = "rb_AllFlightsByTime";
            this.rb_AllFlightsByTime.Size = new System.Drawing.Size(225, 24);
            this.rb_AllFlightsByTime.TabIndex = 8;
            this.rb_AllFlightsByTime.TabStop = true;
            this.rb_AllFlightsByTime.Text = "SIMULATE ALL FLIGHTS";
            this.rb_AllFlightsByTime.UseVisualStyleBackColor = true;
            // 
            // rb_SimulateSingleFlightbyTime
            // 
            this.rb_SimulateSingleFlightbyTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rb_SimulateSingleFlightbyTime.AutoSize = true;
            this.rb_SimulateSingleFlightbyTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rb_SimulateSingleFlightbyTime.Location = new System.Drawing.Point(8, 70);
            this.rb_SimulateSingleFlightbyTime.Margin = new System.Windows.Forms.Padding(4);
            this.rb_SimulateSingleFlightbyTime.Name = "rb_SimulateSingleFlightbyTime";
            this.rb_SimulateSingleFlightbyTime.Size = new System.Drawing.Size(244, 24);
            this.rb_SimulateSingleFlightbyTime.TabIndex = 9;
            this.rb_SimulateSingleFlightbyTime.Text = "SIMULATE SINGLE FLIGHT";
            this.rb_SimulateSingleFlightbyTime.UseVisualStyleBackColor = true;
            // 
            // tb_targetIdentification
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tb_targetIdentification, 2);
            this.tb_targetIdentification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tb_targetIdentification.Location = new System.Drawing.Point(1087, 128);
            this.tb_targetIdentification.Margin = new System.Windows.Forms.Padding(4);
            this.tb_targetIdentification.Name = "tb_targetIdentification";
            this.tb_targetIdentification.Size = new System.Drawing.Size(165, 24);
            this.tb_targetIdentification.TabIndex = 0;
            this.tb_targetIdentification.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbPlot
            // 
            this.lbPlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlot.Location = new System.Drawing.Point(1303, 128);
            this.lbPlot.Margin = new System.Windows.Forms.Padding(4);
            this.lbPlot.Name = "lbPlot";
            this.lbPlot.Size = new System.Drawing.Size(138, 54);
            this.lbPlot.TabIndex = 8;
            this.lbPlot.Text = "Plot Path";
            this.lbPlot.UseVisualStyleBackColor = true;
            this.lbPlot.Click += new System.EventHandler(this.lbPlot_Click);
            // 
            // lb_tiempo
            // 
            this.lb_tiempo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_tiempo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lb_tiempo, 3);
            this.lb_tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lb_tiempo.Location = new System.Drawing.Point(1087, 186);
            this.lb_tiempo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tiempo.Name = "lb_tiempo";
            this.lb_tiempo.Size = new System.Drawing.Size(354, 62);
            this.lb_tiempo.TabIndex = 12;
            this.lb_tiempo.Text = "para el tiempo";
            this.lb_tiempo.Click += new System.EventHandler(this.lb_tiempo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Location = new System.Drawing.Point(1086, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 51);
            this.label1.TabIndex = 16;
            this.label1.Text = "To simulate a single flight select the option above, write the target identificat" +
    "ion of the plane and plot it\'s path. Then press play.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Location = new System.Drawing.Point(1086, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 34);
            this.label4.TabIndex = 17;
            this.label4.Text = "To restart the simulation once the time is over click the Play/Pause button twice" +
    ".";
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // lbPlay_Pause
            // 
            this.lbPlay_Pause.Location = new System.Drawing.Point(1159, 562);
            this.lbPlay_Pause.Margin = new System.Windows.Forms.Padding(4);
            this.lbPlay_Pause.Name = "lbPlay_Pause";
            this.lbPlay_Pause.Size = new System.Drawing.Size(136, 92);
            this.lbPlay_Pause.TabIndex = 10;
            this.lbPlay_Pause.Text = "Play/Pause";
            this.lbPlay_Pause.UseVisualStyleBackColor = true;
            this.lbPlay_Pause.Click += new System.EventHandler(this.lbPlay_Pause_Click);
            // 
            // PruebasMapas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 782);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gMapControl2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PruebasMapas";
            this.Text = "PruebasMapas";
            this.Load += new System.EventHandler(this.PruebasMapas_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tb_targetIdentification;
        private System.Windows.Forms.Button lbPlot;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_AllFlightsByTime;
        private System.Windows.Forms.RadioButton rb_SimulateSingleFlightbyTime;
        private System.Windows.Forms.Label lb_tiempo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_Errores;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_10;
        private System.Windows.Forms.RadioButton rb_4;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_1;
        private System.Windows.Forms.RadioButton rb_05;
        private System.Windows.Forms.RadioButton rb_025;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rb_20;
        private System.Windows.Forms.Button lbPlay_Pause;
    }
}