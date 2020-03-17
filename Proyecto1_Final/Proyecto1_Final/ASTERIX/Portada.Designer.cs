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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btBrowsefile = new System.Windows.Forms.Button();
            this.tb_direction = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btCAT21 = new System.Windows.Forms.Button();
            this.btTables = new System.Windows.Forms.Button();
            this.btCAT20 = new System.Windows.Forms.Button();
            this.btCAT10 = new System.Windows.Forms.Button();
            this.panelTablaCAT21 = new System.Windows.Forms.Panel();
            this.dgvCAT21 = new System.Windows.Forms.DataGridView();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Background = new System.Windows.Forms.TableLayoutPanel();
            this.btProcessData = new System.Windows.Forms.Button();
            this.panelTablaCAT10 = new System.Windows.Forms.Panel();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSourceIdentification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetReportDescriptor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeofApplicabilityPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WGS84Coordinates_LAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WGS84Coordinates_LATHR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositioninCartedianCoordinates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositioninPolarCoordinates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionWGS84Coordinates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeofDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetReportDescriptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataSourceIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCAT10 = new System.Windows.Forms.DataGridView();
            this.panelFondo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTablaCAT21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAT21)).BeginInit();
            this.tableLayoutPanel_Background.SuspendLayout();
            this.panelTablaCAT10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAT10)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btBrowsefile
            // 
            this.btBrowsefile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btBrowsefile.Location = new System.Drawing.Point(3, 78);
            this.btBrowsefile.Name = "btBrowsefile";
            this.btBrowsefile.Size = new System.Drawing.Size(187, 23);
            this.btBrowsefile.TabIndex = 8;
            this.btBrowsefile.Text = "Browse File";
            this.btBrowsefile.UseVisualStyleBackColor = true;
            this.btBrowsefile.Click += new System.EventHandler(this.btBrowsefile_Click_1);
            // 
            // tb_direction
            // 
            this.tb_direction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_direction.Location = new System.Drawing.Point(196, 78);
            this.tb_direction.Name = "tb_direction";
            this.tb_direction.Size = new System.Drawing.Size(574, 22);
            this.tb_direction.TabIndex = 7;
            this.tb_direction.TextChanged += new System.EventHandler(this.tb_direction_TextChanged);
            // 
            // lblError
            // 
            this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(196, 225);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(574, 77);
            this.lblError.TabIndex = 13;
            this.lblError.Text = "label2";
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
            // 
            // panelFondo
            // 
            this.panelFondo.Controls.Add(this.tableLayoutPanel1);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(0, 0);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(1192, 448);
            this.panelFondo.TabIndex = 15;
            this.panelFondo.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btCAT21, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btTables, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btCAT20, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btCAT10, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelTablaCAT21, 6, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1151, 384);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // btCAT21
            // 
            this.btCAT21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCAT21.Location = new System.Drawing.Point(243, 53);
            this.btCAT21.Name = "btCAT21";
            this.btCAT21.Size = new System.Drawing.Size(114, 44);
            this.btCAT21.TabIndex = 9;
            this.btCAT21.Text = "CAT21";
            this.btCAT21.UseVisualStyleBackColor = true;
            this.btCAT21.Visible = false;
            this.btCAT21.Click += new System.EventHandler(this.btCAT21_Click);
            // 
            // btTables
            // 
            this.btTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btTables.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btTables.Location = new System.Drawing.Point(3, 3);
            this.btTables.Name = "btTables";
            this.btTables.Size = new System.Drawing.Size(114, 44);
            this.btTables.TabIndex = 16;
            this.btTables.Text = "Table";
            this.btTables.UseVisualStyleBackColor = false;
            // 
            // btCAT20
            // 
            this.btCAT20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCAT20.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCAT20.Location = new System.Drawing.Point(123, 53);
            this.btCAT20.Name = "btCAT20";
            this.btCAT20.Size = new System.Drawing.Size(114, 44);
            this.btCAT20.TabIndex = 8;
            this.btCAT20.Text = "CAT20";
            this.btCAT20.UseVisualStyleBackColor = true;
            this.btCAT20.Visible = false;
            // 
            // btCAT10
            // 
            this.btCAT10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btCAT10.Location = new System.Drawing.Point(3, 53);
            this.btCAT10.Name = "btCAT10";
            this.btCAT10.Size = new System.Drawing.Size(114, 44);
            this.btCAT10.TabIndex = 7;
            this.btCAT10.Text = "CAT10";
            this.btCAT10.UseVisualStyleBackColor = true;
            this.btCAT10.Visible = false;
            this.btCAT10.Click += new System.EventHandler(this.btCAT10_Click);
            // 
            // panelTablaCAT21
            // 
            this.panelTablaCAT21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTablaCAT21.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel1.SetColumnSpan(this.panelTablaCAT21, 97);
            this.panelTablaCAT21.Controls.Add(this.panelTablaCAT10);
            this.panelTablaCAT21.Controls.Add(this.dgvCAT21);
            this.panelTablaCAT21.Location = new System.Drawing.Point(3, 103);
            this.panelTablaCAT21.Name = "panelTablaCAT21";
            this.panelTablaCAT21.Size = new System.Drawing.Size(1145, 278);
            this.panelTablaCAT21.TabIndex = 17;
            this.panelTablaCAT21.Visible = false;
            // 
            // dgvCAT21
            // 
            this.dgvCAT21.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCAT21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCAT21.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.DataSourceIdentification,
            this.TargetReportDescriptor1,
            this.TrackNumber,
            this.TimeofApplicabilityPosition,
            this.WGS84Coordinates_LAT,
            this.WGS84Coordinates_LATHR});
            this.dgvCAT21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCAT21.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCAT21.Location = new System.Drawing.Point(0, 0);
            this.dgvCAT21.Name = "dgvCAT21";
            this.dgvCAT21.RowHeadersWidth = 51;
            this.dgvCAT21.RowTemplate.Height = 24;
            this.dgvCAT21.Size = new System.Drawing.Size(1145, 278);
            this.dgvCAT21.TabIndex = 0;
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lbl_Title.Location = new System.Drawing.Point(213, 20);
            this.lbl_Title.Margin = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(540, 55);
            this.lbl_Title.TabIndex = 6;
            this.lbl_Title.Text = "ASTERIX DECODER";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_Title.Click += new System.EventHandler(this.lbl_Title_Click);
            // 
            // tableLayoutPanel_Background
            // 
            this.tableLayoutPanel_Background.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_Background.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel_Background.ColumnCount = 3;
            this.tableLayoutPanel_Background.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Background.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel_Background.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel_Background.Controls.Add(this.btBrowsefile, 0, 1);
            this.tableLayoutPanel_Background.Controls.Add(this.lbl_Title, 1, 0);
            this.tableLayoutPanel_Background.Controls.Add(this.tb_direction, 1, 1);
            this.tableLayoutPanel_Background.Controls.Add(this.lblError, 1, 3);
            this.tableLayoutPanel_Background.Controls.Add(this.btProcessData, 1, 2);
            this.tableLayoutPanel_Background.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel_Background.Name = "tableLayoutPanel_Background";
            this.tableLayoutPanel_Background.RowCount = 4;
            this.tableLayoutPanel_Background.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Background.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Background.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Background.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Background.Size = new System.Drawing.Size(967, 302);
            this.tableLayoutPanel_Background.TabIndex = 16;
            this.tableLayoutPanel_Background.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Background_Paint);
            // 
            // btProcessData
            // 
            this.btProcessData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btProcessData.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btProcessData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btProcessData.Location = new System.Drawing.Point(196, 153);
            this.btProcessData.Name = "btProcessData";
            this.btProcessData.Size = new System.Drawing.Size(574, 69);
            this.btProcessData.TabIndex = 14;
            this.btProcessData.Text = "Process Data";
            this.btProcessData.UseVisualStyleBackColor = true;
            this.btProcessData.Click += new System.EventHandler(this.btProcessData_Click_1);
            // 
            // panelTablaCAT10
            // 
            this.panelTablaCAT10.Controls.Add(this.dgvCAT10);
            this.panelTablaCAT10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTablaCAT10.Location = new System.Drawing.Point(0, 0);
            this.panelTablaCAT10.Name = "panelTablaCAT10";
            this.panelTablaCAT10.Size = new System.Drawing.Size(1145, 278);
            this.panelTablaCAT10.TabIndex = 1;
            this.panelTablaCAT10.Visible = false;
            // 
            // Number
            // 
            this.Number.HeaderText = "#";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 125;
            // 
            // DataSourceIdentification
            // 
            this.DataSourceIdentification.HeaderText = "SAC/SIC";
            this.DataSourceIdentification.MinimumWidth = 6;
            this.DataSourceIdentification.Name = "DataSourceIdentification";
            this.DataSourceIdentification.Width = 125;
            // 
            // TargetReportDescriptor1
            // 
            this.TargetReportDescriptor1.HeaderText = "Target Report Descriptor";
            this.TargetReportDescriptor1.MinimumWidth = 6;
            this.TargetReportDescriptor1.Name = "TargetReportDescriptor1";
            this.TargetReportDescriptor1.Width = 125;
            // 
            // TrackNumber
            // 
            this.TrackNumber.HeaderText = "Track Number";
            this.TrackNumber.MinimumWidth = 6;
            this.TrackNumber.Name = "TrackNumber";
            this.TrackNumber.Width = 125;
            // 
            // TimeofApplicabilityPosition
            // 
            this.TimeofApplicabilityPosition.HeaderText = "Time of Applicability for Position";
            this.TimeofApplicabilityPosition.MinimumWidth = 6;
            this.TimeofApplicabilityPosition.Name = "TimeofApplicabilityPosition";
            this.TimeofApplicabilityPosition.Width = 125;
            // 
            // WGS84Coordinates_LAT
            // 
            this.WGS84Coordinates_LAT.HeaderText = "WGS-84 Co-ordinates LAT/LON";
            this.WGS84Coordinates_LAT.MinimumWidth = 6;
            this.WGS84Coordinates_LAT.Name = "WGS84Coordinates_LAT";
            this.WGS84Coordinates_LAT.Width = 125;
            // 
            // WGS84Coordinates_LATHR
            // 
            this.WGS84Coordinates_LATHR.HeaderText = "WGS-84 Co-ordinates (HR) LAT/LON";
            this.WGS84Coordinates_LATHR.MinimumWidth = 6;
            this.WGS84Coordinates_LATHR.Name = "WGS84Coordinates_LATHR";
            this.WGS84Coordinates_LATHR.Width = 125;
            // 
            // PositioninCartedianCoordinates
            // 
            this.PositioninCartedianCoordinates.HeaderText = "Position in Cartesian Coordinates X/Y";
            this.PositioninCartedianCoordinates.MinimumWidth = 6;
            this.PositioninCartedianCoordinates.Name = "PositioninCartedianCoordinates";
            this.PositioninCartedianCoordinates.Width = 125;
            // 
            // PositioninPolarCoordinates
            // 
            this.PositioninPolarCoordinates.HeaderText = "Measured Position in Polar Coordinates Rho/Theta";
            this.PositioninPolarCoordinates.MinimumWidth = 6;
            this.PositioninPolarCoordinates.Name = "PositioninPolarCoordinates";
            this.PositioninPolarCoordinates.Width = 125;
            // 
            // PositionWGS84Coordinates
            // 
            this.PositionWGS84Coordinates.HeaderText = "WGS-84 Co-ordinates LAT/LON";
            this.PositionWGS84Coordinates.MinimumWidth = 6;
            this.PositionWGS84Coordinates.Name = "PositionWGS84Coordinates";
            this.PositionWGS84Coordinates.Width = 125;
            // 
            // TimeofDay
            // 
            this.TimeofDay.HeaderText = "Time of Day";
            this.TimeofDay.MinimumWidth = 6;
            this.TimeofDay.Name = "TimeofDay";
            this.TimeofDay.Width = 125;
            // 
            // TargetReportDescriptor
            // 
            this.TargetReportDescriptor.HeaderText = "Target Report Descriptor";
            this.TargetReportDescriptor.MinimumWidth = 6;
            this.TargetReportDescriptor.Name = "TargetReportDescriptor";
            this.TargetReportDescriptor.Width = 125;
            // 
            // MessageType
            // 
            this.MessageType.HeaderText = "Message Type";
            this.MessageType.MinimumWidth = 6;
            this.MessageType.Name = "MessageType";
            this.MessageType.Width = 125;
            // 
            // DataSourceIdentifier
            // 
            this.DataSourceIdentifier.HeaderText = "SAC/SIC";
            this.DataSourceIdentifier.MinimumWidth = 6;
            this.DataSourceIdentifier.Name = "DataSourceIdentifier";
            this.DataSourceIdentifier.Width = 125;
            // 
            // Number1
            // 
            this.Number1.HeaderText = "#";
            this.Number1.MinimumWidth = 6;
            this.Number1.Name = "Number1";
            this.Number1.Width = 125;
            // 
            // dgvCAT10
            // 
            this.dgvCAT10.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCAT10.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCAT10.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number1,
            this.DataSourceIdentifier,
            this.MessageType,
            this.TargetReportDescriptor,
            this.TimeofDay,
            this.PositionWGS84Coordinates,
            this.PositioninPolarCoordinates,
            this.PositioninCartedianCoordinates});
            this.dgvCAT10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCAT10.Location = new System.Drawing.Point(0, 0);
            this.dgvCAT10.Name = "dgvCAT10";
            this.dgvCAT10.RowHeadersWidth = 51;
            this.dgvCAT10.RowTemplate.Height = 24;
            this.dgvCAT10.Size = new System.Drawing.Size(1145, 278);
            this.dgvCAT10.TabIndex = 0;
            // 
            // Portada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 448);
            this.Controls.Add(this.panelFondo);
            this.Controls.Add(this.tableLayoutPanel_Background);
            this.Name = "Portada";
            this.Text = "Asterix DECODER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Portada_Resize);
            this.panelFondo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTablaCAT21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAT21)).EndInit();
            this.tableLayoutPanel_Background.ResumeLayout(false);
            this.tableLayoutPanel_Background.PerformLayout();
            this.panelTablaCAT10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAT10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btBrowsefile;
        private System.Windows.Forms.TextBox tb_direction;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Panel panelTableCAT21;
        private System.Windows.Forms.Button btCAT21;
        private System.Windows.Forms.Button btCAT20;
        private System.Windows.Forms.Button btCAT10;
        private System.Windows.Forms.Button btTables;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Background;
        private System.Windows.Forms.Button btProcessData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelTablaCAT21;
        private System.Windows.Forms.DataGridView dgvCAT21;
        private System.Windows.Forms.Panel panelTablaCAT10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSourceIdentification;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetReportDescriptor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeofApplicabilityPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn WGS84Coordinates_LAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn WGS84Coordinates_LATHR;
        private System.Windows.Forms.DataGridView dgvCAT10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataSourceIdentifier;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetReportDescriptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeofDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionWGS84Coordinates;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositioninPolarCoordinates;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositioninCartedianCoordinates;
    }
}

