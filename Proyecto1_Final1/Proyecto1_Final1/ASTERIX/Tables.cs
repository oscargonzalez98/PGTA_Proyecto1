using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using LIBRERIACLASES;

namespace ASTERIX
{
    public partial class Tables : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        public List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();

        int contador_forward = 1;
        int contador_backward = 0;

        int numero_de_decimales = 5;

        public Tables(List<CAT10> listaCAT10, List<CAT20> listaCAT20, List<CAT21> listaCAT21, List<CAT21v23> listaCAT21v23)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT20 = listaCAT20;
            this.listaCAT21 = listaCAT21;
            this.listaCAT21v23 = listaCAT21v23;

            if (listaCAT10.Count > 0)
            {
                btCAT10.BackColor = SystemColors.ActiveCaption;
            }
            if (listaCAT21v23.Count > 0)
            {
                btCAT20.BackColor = SystemColors.ActiveCaption;
            }
            if (listaCAT21.Count > 0)
            {
                btCAT21.BackColor = SystemColors.ActiveCaption;
            }

            lb_Pages.Text = "";
        }

        private void btCAT10_Click(object sender, EventArgs e)
        {
            panelCAT10.Visible = true;
            panelCAT20.Visible = false;
            panelCAT21.Visible = false;
            panelCAT10.BackColor = SystemColors.ActiveCaption;

            label1.Visible = true;
            tb_name.Visible = true;
            lb_FilterCAT21.Visible = true;


            dgvCAT10.Rows.Clear();

            int i = 0;
            while (i < 50 && i < listaCAT10.Count)
            {
                EscribirLineaCAT10(i);
                i = i + 1;
            }

            if (listaCAT10.Count > 0)
            {
                lb_Pages.Text = "1 - 50";
            }
        }

        private void btCAT20_Click_1(object sender, EventArgs e)
        {
            panelCAT10.Visible = true;
            panelCAT20.Visible = true;
            panelCAT21.Visible = false;
            panelCAT20.BackColor = SystemColors.ActiveCaption;

            label1.Visible = true;
            tb_name.Visible = true;
            lb_FilterCAT21.Visible = true;

            dgvCAT20.Rows.Clear();

            int i = 0;
            while (i < 50 && i < listaCAT21v23.Count)
            {
                EscribirlineaCAT20(i);
                i = i + 1;
            }

            if (listaCAT21v23.Count > 0)
            {
                lb_Pages.Text = "1 - 50";
            }
        }

        private void btCAT21_Click(object sender, EventArgs e)
        {

            panelCAT10.Visible = true;
            panelCAT20.Visible = true;
            panelCAT21.Visible = true;

            label1.Visible = true;
            tb_name.Visible = true;
            lb_FilterCAT21.Visible = true;


            panelCAT21.BackColor = SystemColors.ActiveCaption;
            dgvCAT21.Rows.Clear();

            int i = 0;
            while (i < 50 && i < listaCAT21.Count)
            {
                EscribirLineaCAT21(i);
                i = i + 1;
            }

            if (listaCAT21.Count > 0)
            {
                lb_Pages.Text = "1 - 50";
            }
        }

        private void bt_Forward_Click(object sender, EventArgs e)
        {
            int i;
            if (panelCAT10.Visible == true && panelCAT20.Visible == false && panelCAT21.Visible == false)
            {
                dgvCAT10.Rows.Clear();
                contador_forward = contador_forward + 1;
                int valorinicial = 50 * (contador_forward - contador_backward - 1);
                i = valorinicial;
                if (valorinicial < 0) { valorinicial = 0; }
                int valorfinal = 50 * (contador_forward - contador_backward);
                if (valorfinal > listaCAT10.Count - 1) { valorfinal = listaCAT10.Count - 1; }

                if (valorinicial == 0 && valorfinal == 0)
                {
                    valorinicial = 0;
                    valorfinal = 50;
                    i = valorinicial;
                    contador_forward = contador_forward - 1;
                }

                while (i < valorfinal /*&& i < listaCAT10.Count*/ && i >= 0)
                {
                    EscribirLineaCAT10(i);
                    i = i + 1;
                }
                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;
            }


            if(panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == false)
            {
                dgvCAT20.Rows.Clear();
                contador_forward = contador_forward + 1;
                int valorinicial = 50 * (contador_forward - contador_backward - 1);
                i = valorinicial;
                if (valorinicial < 0) { valorinicial = 0; }
                int valorfinal = 50 * (contador_forward - contador_backward);
                if (valorfinal > listaCAT21v23.Count - 1) { valorfinal = listaCAT21v23.Count - 1; }

                if (valorinicial == 0 && valorfinal == 0)
                {
                    valorinicial = 0;
                    valorfinal = 50;
                    i = valorinicial;
                    contador_forward = contador_forward - 1;
                }

                while (i < valorfinal && i < listaCAT21v23.Count && i >= 0)
                {
                    EscribirlineaCAT20(i);

                    i = i + 1;
                }

                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;

            }



            if (panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == true)
            {
                dgvCAT21.Rows.Clear();
                contador_forward = contador_forward + 1;
                int valorinicial = 50 * (contador_forward - contador_backward - 1);
                i = valorinicial;
                if (valorinicial < 0) { valorinicial = 0; }
                int valorfinal = 50 * (contador_forward - contador_backward);
                if (valorfinal > listaCAT21.Count - 1) { valorfinal = listaCAT21.Count - 1; }

                if (valorinicial == 0 && valorfinal == 0)
                {
                    valorinicial = 0;
                    valorfinal = 50;
                    i = valorinicial;
                    contador_forward = contador_forward - 1;
                }

                while (i < valorfinal && i < listaCAT21.Count && i >= 0)
                {
                    EscribirLineaCAT21(i);
                    i = i + 1;
                }

                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;
            }
        }

        public void bt_Backward_Click(object sender, EventArgs e)
        {
            int i;
            if (panelCAT10.Visible == true && panelCAT20.Visible == false && panelCAT21.Visible == false)
            {

                dgvCAT10.Rows.Clear();
                contador_backward = contador_backward + 1;
                int valorinicial = 50 * (contador_forward - contador_backward - 1);
                i = valorinicial;
                if (valorinicial < 0) { valorinicial = 0; }
                int valorfinal = 50 * (contador_forward - contador_backward);
                if (valorfinal > listaCAT10.Count - 1) { valorfinal = listaCAT10.Count - 1; }

                if (valorinicial == 0 && valorfinal == 0)
                {
                    valorinicial = 0;
                    valorfinal = 50;
                    i = valorinicial;
                    contador_backward = contador_backward - 1;
                }

                while (i < valorfinal && i >= 0)
                {
                    EscribirLineaCAT10(i);
                    i = i + 1;
                }

                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;
            }


            if (panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == false)
            {
                dgvCAT20.Rows.Clear();
                contador_backward = contador_backward + 1;
                int valorinicial = 50 * (contador_forward - contador_backward - 1);
                i = valorinicial;
                if (valorinicial < 0) { valorinicial = 0; }
                int valorfinal = 50 * (contador_forward - contador_backward);
                if (valorfinal > listaCAT21v23.Count - 1) { valorfinal = listaCAT21v23.Count - 1; }

                if (valorinicial <= 0 && valorfinal <= 0)
                {
                    valorinicial = 0;
                    valorfinal = 50;
                    i = valorinicial;
                    contador_backward = contador_backward - 1;
                }

                while (i < valorfinal && i < listaCAT21v23.Count && i >= 0)
                {
                    EscribirlineaCAT20(i);
                    i = i + 1;
                }

                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;
            }

            if (panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == true)
            { 
                dgvCAT21.Rows.Clear();
                contador_backward = contador_backward + 1;
                int valorinicial = 50 * (contador_forward - contador_backward - 1);
                i = valorinicial;
                if (valorinicial < 0) { valorinicial = 0; }
                int valorfinal = 50 * (contador_forward - contador_backward);
                if (valorfinal > listaCAT21.Count - 1) { valorfinal = listaCAT21.Count - 1; }

                if(valorinicial <= 0 && valorfinal <= 0)
                {
                    valorinicial = 0;
                    valorfinal = 50;
                    i = valorinicial;
                    contador_backward = contador_backward - 1;
                }

                while (i < valorfinal && i < listaCAT21.Count && i >= 0)
                {
                    EscribirLineaCAT21(i);
                    i = i + 1;
                }

                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;
            }
        }

        private void bt_FastForward_Click(object sender, EventArgs e)
        {
            if (panelCAT10.Visible == true && panelCAT20.Visible == false && panelCAT21.Visible == false)
            {
                dgvCAT10.Rows.Clear();

                double distance = listaCAT10.Count - 1;
                double numerode50 = Math.Floor(distance / 50);
                double numerofinal = ((distance / 50) - numerode50) * 50;

                double valorfinal1 = distance;
                double valorinicial1 = valorfinal1 - numerofinal;
                int i = Convert.ToInt32(valorinicial1);

                int valorinicial = 0;
                int valorfinal = 0;

                while (valorinicial != valorinicial1)
                {
                    dgvCAT10.Rows.Clear();
                    contador_forward = contador_forward + 1;
                    valorinicial = 50 * (contador_forward - contador_backward - 1);
                    i = valorinicial;
                    if (valorinicial < 0) { valorinicial = 0; }
                    valorfinal = 50 * (contador_forward - contador_backward);
                    if (valorfinal > listaCAT10.Count - 1) { valorfinal = listaCAT10.Count - 1; }

                    if (valorinicial == 0 && valorfinal == 0)
                    {
                        valorinicial = 0;
                        valorfinal = 50;
                        i = valorinicial;
                        contador_forward = contador_forward - 1;
                    }
                }

                while (i < valorfinal && i < listaCAT10.Count && i >= 0)
                {
                    EscribirLineaCAT10(i);
                    i = i + 1;
                }

                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;

            }

            if(panelCAT10.Visible==true && panelCAT20.Visible==true && panelCAT21.Visible==false)
            {
                dgvCAT20.Rows.Clear();

                double distance = listaCAT21v23.Count - 1;
                double numerode50 = Math.Floor(distance / 50);
                double numerofinal = ((distance / 50) - numerode50) * 50;

                double valorfinal1 = distance;
                double valorinicial1 = valorfinal1 - numerofinal;
                int i = Convert.ToInt32(valorinicial1);

                int valorinicial = 0;
                int valorfinal = 0;

                while (valorinicial != valorinicial1)
                {
                    EscribirlineaCAT20(i);
                    i = i + 1;
                }

                while (i < valorfinal && i < listaCAT21v23.Count && i >= 0)
                {
                    int n = dgvCAT20.Rows.Add();

                    dgvCAT20.Rows[n].Cells[0].Value = i + 1; // ----------------------------------------------------------------------------------------- 0
                    dgvCAT20.Rows[n].Cells[1].Value = String.Concat(listaCAT21v23[i].SAC, "/", listaCAT21v23[i].SIC); //---------------------------------------- 1

                    if (listaCAT21v23[i].TargetReportDescriptor.Length > 0) // ---------------------------------------------------------------------------------------- 2
                    {
                        dgvCAT20.Rows[n].Cells[2].Value = "Clcik here for more information";
                    }
                    else { dgvCAT20.Rows[n].Cells[2].Value = "No info"; }


                    TimeSpan t = TimeSpan.FromSeconds(listaCAT21v23[i].TimeofDay_seconds);

                    if (listaCAT21v23[i].TimeofDay.Length > 0) // ---------------------------------------------------------------------------------------- 3
                    {
                        dgvCAT20.Rows[n].Cells[3].Value = String.Concat(t.Hours, ":", t.Minutes, ":", t.Seconds);
                    }
                    else { dgvCAT20.Rows[n].Cells[3].Value = "No info"; }

                    if (listaCAT21v23[i].PositioninWGS_coordinates.Length > 0) // ---------------------------------------------------------------------------------------- 4
                    {
                        dgvCAT20.Rows[n].Cells[4].Value = String.Concat(listaCAT21v23[i].latWGS84, "/", listaCAT21v23[i].lonWGS84);
                    }
                    else { dgvCAT20.Rows[n].Cells[4].Value = "No info"; }

                    if (listaCAT21v23[i].TargetAddress_bin.Length > 0) // ---------------------------------------------------------------------------------------- 5
                    {
                        dgvCAT20.Rows[n].Cells[5].Value = listaCAT21v23[i].TargetAdress_real;
                    }
                    else { dgvCAT20.Rows[n].Cells[5].Value = "No info"; }

                    if (listaCAT21v23[i].GeometricAltitude.Length > 0) // ---------------------------------------------------------------------------------------- 6
                    {
                        dgvCAT20.Rows[n].Cells[6].Value = listaCAT21v23[i].GeometricAltitude_ft;
                    }
                    else { dgvCAT20.Rows[n].Cells[6].Value = "No info"; }

                    if (listaCAT21v23[i].FigureofMerit.Length > 0) // ---------------------------------------------------------------------------------------- 7
                    {
                        dgvCAT20.Rows[n].Cells[7].Value = "Clcik here for more information";
                    }
                    else { dgvCAT20.Rows[n].Cells[7].Value = "No info"; }

                    // -------------------------------------------------------------------------------------------------------------------------------- FX  

                    if (listaCAT21v23[i].LinkTechnologyIndicator.Length > 0) // ---------------------------------------------------------------------------------------- 8
                    {
                        dgvCAT20.Rows[n].Cells[8].Value = "Clcik here for more information";
                    }
                    else { dgvCAT20.Rows[n].Cells[8].Value = "No info"; }

                    if (listaCAT21v23[i].RollAngle.Length > 0) // ---------------------------------------------------------------------------------------- 9
                    {
                        dgvCAT20.Rows[n].Cells[10].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].RollAngle_degrees; ;
                    }
                    else { dgvCAT20.Rows[n].Cells[9].Value = "No info"; }

                    if (listaCAT21v23[i].FlightLevel.Length > 0) // ---------------------------------------------------------------------------------------- 10
                    {
                        dgvCAT20.Rows[n].Cells[10].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].FlightLevel_FL; ;
                    }
                    else { dgvCAT20.Rows[n].Cells[10].Value = "No info"; }

                    if (listaCAT21v23[i].AirSpeed.Length > 0) // ---------------------------------------------------------------------------------------- 11
                    {
                        dgvCAT20.Rows[n].Cells[11].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].AirSpeed_velocity;
                    }
                    else { dgvCAT20.Rows[n].Cells[11].Value = "No info"; }

                    if (listaCAT21v23[i].TrueAirSpeed.Length > 0) // ---------------------------------------------------------------------------------------- 12
                    {
                        dgvCAT20.Rows[n].Cells[12].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TrueAirSpeed_number;
                    }
                    else { dgvCAT20.Rows[n].Cells[12].Value = "No info"; }

                    if (listaCAT21v23[i].MagneticHeading.Length > 0) // ---------------------------------------------------------------------------------------- 13
                    {
                        dgvCAT20.Rows[n].Cells[13].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].MagneticHeading_degrees;
                    }
                    else { dgvCAT20.Rows[n].Cells[13].Value = "No info"; }

                    if (listaCAT21v23[i].BarometricVerticalRate.Length > 0) // ---------------------------------------------------------------------------------------- 14
                    {
                        dgvCAT20.Rows[n].Cells[14].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].BarometricVerticalRate_fmin;
                    }
                    else { dgvCAT20.Rows[n].Cells[14].Value = "No info"; }

                    // -------------------------------------------------------------------------------------------------------------------------------- FX 

                    if (listaCAT21v23[i].GeometricVerticalRate.Length > 0) // ---------------------------------------------------------------------------------------- 15
                    {
                        dgvCAT20.Rows[n].Cells[15].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].GeometricVerticalRate_fmin;
                    }
                    else { dgvCAT20.Rows[n].Cells[15].Value = "No info"; }

                    if (listaCAT21v23[i].GroundVector.Length > 0) // ---------------------------------------------------------------------------------------- 16
                    {
                        dgvCAT20.Rows[n].Cells[16].Value = dgvCAT20.Rows[n].Cells[9].Value = String.Concat(listaCAT21v23[i].GroundSpeed, "/", listaCAT21v23[i].TrackAngle);
                    }
                    else { dgvCAT20.Rows[n].Cells[16].Value = "No info"; }

                    if (listaCAT21v23[i].RateofTurn.Length > 0) // ---------------------------------------------------------------------------------------- 17
                    {
                        dgvCAT20.Rows[n].Cells[17].Value = dgvCAT20.Rows[n].Cells[9].Value = String.Concat(listaCAT21v23[i].RateofTurn_deg, "/", listaCAT21v23[i].TI);
                    }
                    else { dgvCAT20.Rows[n].Cells[17].Value = "No info"; }

                    if (listaCAT21v23[i].TargetIdentification.Length > 0) // ---------------------------------------------------------------------------------------- 18
                    {
                        dgvCAT20.Rows[n].Cells[18].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TargetIdentification_decoded;
                    }
                    else { dgvCAT20.Rows[n].Cells[18].Value = "No info"; }

                    if (listaCAT21v23[i].TimeofDayAccuracy.Length > 0) // ---------------------------------------------------------------------------------------- 20
                    {
                        dgvCAT20.Rows[n].Cells[19].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TimeofDayAccuracy_sec;
                    }
                    else { dgvCAT20.Rows[n].Cells[19].Value = "No info"; }

                    if (listaCAT21v23[i].TargetStatus.Length > 0) // ---------------------------------------------------------------------------------------- 21
                    {
                        dgvCAT20.Rows[n].Cells[20].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TargetStatus_decoded;
                    }
                    else { dgvCAT20.Rows[n].Cells[20].Value = "No info"; }

                    // -------------------------------------------------------------------------------------------------------------------------------- FX  

                    if (listaCAT21v23[i].EmitterCategory.Length > 0) // ---------------------------------------------------------------------------------------- 22
                    {
                        dgvCAT20.Rows[n].Cells[21].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].ECAT;
                    }
                    else { dgvCAT20.Rows[n].Cells[21].Value = "No info"; }

                    if (listaCAT21v23[i].MetInfo.Length > 0) // ---------------------------------------------------------------------------------------- 23
                    {
                        dgvCAT20.Rows[n].Cells[22].Value = "Clcik here for more information";
                    }
                    else { dgvCAT20.Rows[n].Cells[22].Value = "No info"; }

                    if (listaCAT21v23[i].IntermediateStateSelectedAltitude.Length > 0) // ---------------------------------------------------------------------------------------- 24
                    {
                        dgvCAT20.Rows[n].Cells[23].Value = listaCAT21v23[i].Altitude;
                    }
                    else { dgvCAT20.Rows[n].Cells[23].Value = "No info"; }

                    if (listaCAT21v23[i].FinalStateSelectedAltitude.Length > 0) // ---------------------------------------------------------------------------------------- 25
                    {
                        dgvCAT20.Rows[n].Cells[24].Value = listaCAT21v23[i].FSS_Altitude;
                    }
                    else { dgvCAT20.Rows[n].Cells[24].Value = "No info"; }

                    i = i + 1;
                }
                lb_Pages.Text = (valorinicial + 1) + " - " + valorfinal;
            }

            if (panelCAT10.Visible==true && panelCAT20.Visible==true && panelCAT21.Visible==true)
            {
                dgvCAT21.Rows.Clear();

                double distance = listaCAT21.Count-1;
                double numerode50 =Math.Floor(distance / 50);
                double numerofinal = ((distance/50)-numerode50)*50;

                double valorfinal1 = distance;
                double valorinicial1 = valorfinal1 - numerofinal;
                int i= Convert.ToInt32(valorinicial1);

                int valorinicial = 0;
                int valorfinal = 0;

                while (valorinicial != valorinicial1)
                {
                    dgvCAT21.Rows.Clear();
                    contador_forward = contador_forward + 1;
                    valorinicial = 50 * (contador_forward - contador_backward - 1);
                    i = valorinicial;
                    if (valorinicial < 0) { valorinicial = 0; }
                    valorfinal = 50 * (contador_forward - contador_backward);
                    if (valorfinal > listaCAT21.Count - 1) { valorfinal = listaCAT21.Count - 1; }

                    if (valorinicial == 0 && valorfinal == 0)
                    {
                        valorinicial = 0;
                        valorfinal = 50;
                        i = valorinicial;
                        contador_forward = contador_forward - 1;
                    }
                }


                while (i < valorfinal && i < listaCAT21.Count && i >= 0)
                {
                    EscribirLineaCAT21(i);
                    i = i + 1;
                }
                lb_Pages.Text = (valorinicial+1) + " - " + valorfinal;
            }
        }

        private void bt_FastBackward_Click(object sender, EventArgs e)
        {
            contador_forward = 1;
            contador_backward = 0;


            if (panelCAT10.Visible == true && panelCAT20.Visible == false && panelCAT21.Visible == false)
            {
                dgvCAT10.Rows.Clear();
                int i = 0;
                while (i < 50 && i < listaCAT10.Count)
                {
                    EscribirLineaCAT10(i);
                    i = i + 1;
                }

                if (listaCAT10.Count > 0)
                {
                    lb_Pages.Text = "1 - 50";
                }

            }

            if (panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == false)
            {
                dgvCAT20.Rows.Clear();
                int i = 0;

                while (i < 50 && i < listaCAT21v23.Count)
                {
                    EscribirlineaCAT20(i);
                    i = i + 1;
                }

                lb_Pages.Text = "1 - 50";
            }

            if (panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == true)
            {
                dgvCAT21.Rows.Clear();
                int i = 0;
                while (i < 50 && i < listaCAT21.Count)
                {
                    EscribirLineaCAT21(i);
                    i = i + 1;
                }

                if (listaCAT21.Count > 0)
                {
                    lb_Pages.Text = "1 - 50";
                }
            }
        }

        private void dgvCAT21_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                int c = e.ColumnIndex;
                int r = e.RowIndex;
                int i = (int)dgvCAT21.Rows[r].Cells[0].Value - 1;

                if (listaCAT21[i].TargetReportDescriptor.Length > 0)
                {
                    if (c == 2)
                    {
                        TargetReportDescriptorCAT21 TRP1 = new TargetReportDescriptorCAT21(listaCAT21, i);
                        TRP1.ShowDialog();
                    }
                }

                if (listaCAT21[i].QualityIndicators.Length > 0)
                {
                    if (c == 16)
                    {
                        QualityIndicatorsCAT21 QICAT21 = new QualityIndicatorsCAT21(listaCAT21, i);
                        QICAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].MOPSVersion.Length>0)
                {
                    if (c == 17)
                    {
                        MOPSVersionCAT21 MVCAT21 = new MOPSVersionCAT21(listaCAT21, i);
                        MVCAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].TargetStatus.Length > 0)
                {
                    if (c == 22)
                    {
                        TargetStatusCAT21 TS1CAT21 = new TargetStatusCAT21(listaCAT21, i);
                        TS1CAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].MetInformation.Length > 0)
                {
                    if (c == 30)
                    {
                        MetInfoCAT21 METCAT21 = new MetInfoCAT21(listaCAT21, i);
                        METCAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].SelectedAltitude.Length > 0)
                {
                    if (c == 31)
                    {
                        SelectedAltitudeCAT21 SACAT21 = new SelectedAltitudeCAT21(listaCAT21, i);
                        SACAT21.ShowDialog();
                    }
                }

                if(listaCAT21[i].FinalStateSelectedAltitude.Length>0)
                {
                    if(c == 32)
                    {
                        FinalStateSelectedAltitudeCAT21 FSACAT21 = new FinalStateSelectedAltitudeCAT21(listaCAT21, i);
                        FSACAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].TrajectoryIntent.Length > 0)
                {
                    if (c == 33)
                    {
                        TrajectoryIntentCAT21 TACAT21 = new TrajectoryIntentCAT21(listaCAT21, i);
                        TACAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].AircraftOperationalStatus.Length > 0)
                {
                    if (c == 35)
                    {
                        AircraftOperationalStatusCAT21 AOSCAT21 = new AircraftOperationalStatusCAT21(listaCAT21, i);
                        AOSCAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].SurfaceCapabilitiesandCharacteristicas.Length > 0)
                {
                    if (c == 36)
                    {
                        SurfaceCapabilitiesAndCharacteristicsCAT21 SCACCAT21 = new SurfaceCapabilitiesAndCharacteristicsCAT21(listaCAT21, i);
                        SCACCAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].ModeSMBData.Length > 0)
                {
                    if (c == 38)
                    {
                        ModeSMBDataCAT21 MSMBdataCAT21 = new ModeSMBDataCAT21(listaCAT21, i);
                        MSMBdataCAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].ACASResolutionAdvisoryReport.Length > 0)
                {
                    if (c == 39)
                    {
                        ACASResolutionAdvisoryCAT21 ACASRACAT21 = new ACASResolutionAdvisoryCAT21(listaCAT21, i);
                        ACASRACAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].ACASResolutionAdvisoryReport.Length > 0)
                {
                    if (c == 39)
                    {
                        ACASResolutionAdvisoryCAT21 ACASRACAT21 = new ACASResolutionAdvisoryCAT21(listaCAT21, i);
                        ACASRACAT21.ShowDialog();
                    }
                }

                if (listaCAT21[i].DataAges.Length > 0)
                {
                    if (c == 41)
                    {
                        DataAgesCAT21 DACAT21 = new DataAgesCAT21(listaCAT21, i);
                        DACAT21.ShowDialog();
                    }
                }
            }
            catch { }
        }

        private void dgvCAT10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int c = e.ColumnIndex;
                int r = e.RowIndex;
                int i = (int)dgvCAT10.Rows[r].Cells[0].Value - 1;

                if (listaCAT10[i].TargetReportDescriptor.Length > 0)
                {
                    if (c == 3)
                    {
                        TargetReportDescriptorCAT10 TRP2 = new TargetReportDescriptorCAT10(listaCAT10, i);
                        TRP2.ShowDialog();
                    }
                }

                if (listaCAT10[i].TrackStatus.Length > 0)
                {
                    if (c == 11)
                    {
                        TrackStatusCAT10 TS2 = new TrackStatusCAT10(listaCAT10, i);
                        TS2.ShowDialog();
                    }
                }

                if (listaCAT10[i].Mode3ACodeinOctal.Length > 0)
                {
                    if (c == 12)
                    {
                        Mode3ACodeCAT10 M3ACodeCAT10 = new Mode3ACodeCAT10(listaCAT10, i);
                        M3ACodeCAT10.ShowDialog();
                    }
                }

                if (listaCAT10[i].ModeSMBData.Length > 0)
                {
                    if (c == 15)
                    {
                        ModeSMBDataCAT10 MSMBDataCAT10 = new ModeSMBDataCAT10(listaCAT10, i);
                        MSMBDataCAT10.ShowDialog();
                    }
                }

                if (listaCAT10[i].FlightLevelInBinaryRepresentation.Length > 0)
                {
                    if (c == 17)
                    {
                        FlightLevelinBinaryRepresentationCAT10 FLBRCAT10 = new FlightLevelinBinaryRepresentationCAT10(listaCAT10, i);
                        FLBRCAT10.ShowDialog();
                    }
                }

                if (listaCAT10[i].TargetSizeOrientation.Length > 0)
                {
                    if (c == 19)
                    {
                        TargetSizeOrientationCAT10 TSOCAT10 = new TargetSizeOrientationCAT10(listaCAT10, i);
                        TSOCAT10.ShowDialog();
                    }
                }

                if (listaCAT10[i].SystemStatus.Length > 0)
                {
                    if (c == 20)
                    {
                        SystemStatusCAT10 SSCAT10 = new SystemStatusCAT10(listaCAT10, i);
                        SSCAT10.ShowDialog();
                    }
                }
            }
            catch { }
        }

        private void dgvCAT20_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int c = e.ColumnIndex;
                int r = e.RowIndex;
                int i = (int)dgvCAT20.Rows[r].Cells[0].Value - 1;

                if (listaCAT21v23[i].TargetReportDescriptor.Length > 0)
                {
                    if (c == 2)
                    {
                        TargetReportDescriptorv23 TRPv23 = new TargetReportDescriptorv23(listaCAT21v23, i);
                        TRPv23.ShowDialog();
                    }
                }

                if (listaCAT21v23[i].TargetReportDescriptor.Length > 0)
                {
                    if (c == 7)
                    {
                        FigureofMeritv23 FOMv23 = new FigureofMeritv23(listaCAT21v23, i);
                        FOMv23.ShowDialog();
                    }
                }

                if (listaCAT21v23[i].LinkTechnologyIndicator.Length > 0)
                {
                    if (c == 8)
                    {
                        LinkTechnologyv23 LTv23 = new LinkTechnologyv23(listaCAT21v23, i);
                        LTv23.ShowDialog();
                    }
                }

                if (listaCAT21v23[i].MetInfo.Length > 0)
                {
                    if (c == 23)
                    {
                        MetInfov23 LTv23 = new MetInfov23(listaCAT21v23, i);
                        LTv23.ShowDialog();
                    }
                }

                if (listaCAT21v23[i].IntermediateStateSelectedAltitude.Length > 0)
                {
                    if (c == 24)
                    {
                        IntermediateStateSelectedAltitudev23 ISSAv23 = new IntermediateStateSelectedAltitudev23(listaCAT21v23, i);
                        ISSAv23.ShowDialog();
                    }
                }

                if (listaCAT21v23[i].FinalStateSelectedAltitude.Length > 0)
                {
                    if (c == 25)
                    {
                        FinalStateSelectedAltitudev23 FSSAv23 = new FinalStateSelectedAltitudev23(listaCAT21v23, i);
                        FSSAv23.ShowDialog();
                    }
                }

            }
            catch { }
        }

        private void Tables_Load(object sender, EventArgs e)
        {

        }

        private void lb_Filter_Click(object sender, EventArgs e)
        {
            if(listaCAT10.Count>0 && panelCAT10.Visible==true && panelCAT20.Visible == false && panelCAT21.Visible == false)
            {
                dgvCAT10.Rows.Clear();
                int i = 0;
                int j = 0;
                while (i < listaCAT10.Count)
                {

                    string TargetIdentification = "";
                    string TargetAddress = "";
                    string TrackNumber = "";

                    if (listaCAT10[i].TargetIdentification.Length > 0) { TargetIdentification = listaCAT10[i].TargetIdentification_decoded; }
                    if (listaCAT10[i].TargetAdress.Length > 0) { TargetAddress = listaCAT10[i].TargetAdress_decoded; }
                    if (listaCAT10[i].TrackNumber.Length > 0) { TrackNumber = listaCAT10[i].Tracknumber_value.ToString(); }

                    if (TargetIdentification != "" || TargetAddress != "" || TrackNumber != "")
                    {
                        if (TargetIdentification == tb_name.Text)
                        {
                            EscribirLineaCAT10(i);
                            j = j + 1;
                        }

                        else if (TargetAddress == tb_name.Text)
                        {
                            EscribirLineaCAT10(i);
                            j = j + 1;
                        }

                        else if (TrackNumber == tb_name.Text)
                        {
                            EscribirLineaCAT10(i);
                            j = j + 1;
                        }
                    }

                    i = i + 1;
                }

                lb_Pages.Text = "1 - " + j;
            }

            if(listaCAT21v23.Count>0 && panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == false)
            {
                dgvCAT20.Rows.Clear();
                int i = 0;
                int j = 0;
                while (i < listaCAT21v23.Count)
                {
                    string TargetIdentification = "";
                    string TargetAddress = "";

                    if (listaCAT21v23[i].TargetIdentification.Length > 0) { TargetIdentification = listaCAT21v23[i].TargetIdentification_decoded; }
                    if (listaCAT21v23[i].TargetAddress_bin.Length > 0) { TargetAddress = listaCAT21v23[i].TargetAdress_real; }

                    if (TargetIdentification != "" || TargetAddress != "")
                    {
                        if (TargetIdentification == tb_name.Text)
                        {
                            EscribirlineaCAT20(i);
                            j = j + 1;
                        }

                        else if (TargetAddress == tb_name.Text)
                        {
                            EscribirlineaCAT20(i);
                            j = j + 1;
                        }
                    }

                    i = i + 1;
                }

                lb_Pages.Text = "1 - " + j;
            }

            if(listaCAT21.Count>0 && panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == true)
            {
                dgvCAT21.Rows.Clear();
                int i = 0;
                int j = 0;
                while (i < listaCAT21.Count)
                {

                    string TargetIdentification = "";
                    string TargetAddress = "";
                    string TrackNumber = "";

                    if (listaCAT21[i].TargetIdentification.Length > 0) { TargetIdentification = listaCAT21[i].TargetIdentification_decoded; }
                    if (listaCAT21[i].TargetAddress_bin.Length > 0) { TargetAddress = listaCAT21[i].TargetAdress_real; }
                    if (listaCAT21[i].TrackNumber.Length > 0) { TrackNumber = listaCAT21[i].TrackNumber_number.ToString(); }

                    if (TargetIdentification != "" || TargetAddress != "" || TrackNumber != "")
                    {
                        if (TargetIdentification == tb_name.Text)
                        {
                            EscribirLineaCAT21(i);
                            j = j + 1;
                        }

                        else if (TargetAddress == tb_name.Text)
                        {
                            EscribirLineaCAT21(i);
                            j = j + 1;
                        }

                        else if (TrackNumber == tb_name.Text)
                        {
                            EscribirLineaCAT21(i);
                            j = j + 1;
                        }
                    }

                    i = i + 1;
                }

                lb_Pages.Text = "1 - " + j;
            }
        }

        public void EscribirLineaCAT21(int i)
        {
            int n = dgvCAT21.Rows.Add();

            dgvCAT21.Rows[n].Cells[0].Value = i + 1;
            dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC, "/", listaCAT21[i].SIC);
            dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
            dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;

            // Convertimos en horas:mins:secs
            double TOA_Position_seconds = listaCAT21[i].TimeofApplicability_Position_seconds;

            TimeSpan t = TimeSpan.FromSeconds(TOA_Position_seconds);

            if (listaCAT21[i].TimeofApplicability_Position.Length > 0)
            {
                dgvCAT21.Rows[n].Cells[4].Value = t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;
            }
            else { dgvCAT21.Rows[n].Cells[4].Value = "No info."; }

            if (listaCAT21[i].PositioninWGS_coordinates.Length > 0)
            {
                double latWGS84 = listaCAT21[i].latWGS84;
                latWGS84 = Math.Round(latWGS84, numero_de_decimales);

                double lonWGS84 = listaCAT21[i].lonWGS84;
                lonWGS84 = Math.Round(lonWGS84, numero_de_decimales);

                dgvCAT21.Rows[n].Cells[5].Value = String.Concat(latWGS84.ToString(), "/", lonWGS84.ToString());
            }
            else { dgvCAT21.Rows[n].Cells[5].Value = "No info."; }

            if (listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0)
            {
                double latWGS84_HR = listaCAT21[i].latWGS84_HR;
                latWGS84_HR = Math.Round(latWGS84_HR, numero_de_decimales);

                double lonWGS84_HR = listaCAT21[i].lonWGS84_HR;
                lonWGS84_HR = Math.Round(lonWGS84_HR, numero_de_decimales);

                dgvCAT21.Rows[n].Cells[6].Value = String.Concat(latWGS84_HR.ToString(), "/", lonWGS84_HR.ToString());
            }
            else { dgvCAT21.Rows[n].Cells[6].Value = "No info."; }

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------FX

            double TOA_Velocity_seconds = listaCAT21[i].TimeofApplicability_Velocity_seconds;

            // Convertimos en horas:mins:secs
            t = TimeSpan.FromSeconds(TOA_Velocity_seconds);

            if (listaCAT21[i].TimeofApplicability_Position.Length > 0)
            {
                dgvCAT21.Rows[n].Cells[7].Value = t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;
            }
            else { dgvCAT21.Rows[n].Cells[7].Value = "No info."; }

            if (listaCAT21[i].AirSpeed.Length > 0)
            {

                string str1 = listaCAT21[i].IM;
                if (str1 == "0")
                {
                    dgvCAT21.Rows[n].Cells[8].Value = (listaCAT21[i].AirSpeed_velocity).ToString() + " (IAS)";
                }

                else { dgvCAT21.Rows[n].Cells[8].Value = (listaCAT21[i].AirSpeed_Mach).ToString() + " (Mach)"; }
            }

            else { dgvCAT21.Rows[n].Cells[8].Value = "No info."; }

            if (listaCAT21[i].TrueAirSpeed.Length > 0)
            {
                if (listaCAT21[i].RE_TAS == "0")
                {
                    dgvCAT21.Rows[n].Cells[9].Value = listaCAT21[i].TrueAirSpeed_number;
                }
                else { dgvCAT21.Rows[n].Cells[9].Value = listaCAT21[i].TrueAirSpeed_number.ToString() + "(Value excedes defined range.)"; }

            }
            else { dgvCAT21.Rows[n].Cells[9].Value = "No info."; }

            dgvCAT21.Rows[n].Cells[10].Value = listaCAT21[i].TargetAdress_real;


            double TOMR_Position_seconds = listaCAT21[i].TimeofMessageReception_Position_seconds;

            //// Convertimos en horas:mins:secs
            t = TimeSpan.FromSeconds(TOMR_Position_seconds);


            if (listaCAT21[i].TimeofMessageReception_Position.Length > 0)
            {
                dgvCAT21.Rows[n].Cells[11].Value = t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;
            }
            else { dgvCAT21.Rows[n].Cells[11].Value = "No info."; }


            double TOMR_HPPosition_seconds = listaCAT21[i].TimeofMessageReception_HRPosition_seconds;

            // Convertimos en horas:mins:secs
            t = TimeSpan.FromSeconds(TOMR_HPPosition_seconds);

            if (listaCAT21[i].TimeofMessageReception_HRPosition.Length > 0)
            {
                dgvCAT21.Rows[n].Cells[12].Value = String.Concat(t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds, "/", listaCAT21[i].FSI1);
            }
            else { dgvCAT21.Rows[n].Cells[12].Value = "No info."; }

            double TOMR_Velocity_seconds = listaCAT21[i].TimeofMessageReception_Velocity_seconds;

            // Convertimos en horas:mins:secs
            t = TimeSpan.FromSeconds(TOMR_Velocity_seconds);
            if (listaCAT21[i].TimeofMessageReception_Velocity.Length > 0)
            {
                dgvCAT21.Rows[n].Cells[13].Value = String.Concat(t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds, "/", listaCAT21[i].FSI2);
            }
            else { dgvCAT21.Rows[n].Cells[13].Value = "No info."; }

            // --------------------------------------------------------------------------------------------------------------------------------------------------------------FX

            double TOA_HRVelocity_seconds = listaCAT21[i].TimeofMessageReception_HRVelocity_seconds;

            // Convertimos en horas:mins:secs
            t = TimeSpan.FromSeconds(TOA_HRVelocity_seconds);

            if (listaCAT21[i].TimeofMessageReception_HRVelocity.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 14
            {
                dgvCAT21.Rows[n].Cells[14].Value = t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;
            }
            else { dgvCAT21.Rows[n].Cells[14].Value = "No info."; }

            if (listaCAT21[i].GeometricHeight.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 15
            {
                dgvCAT21.Rows[n].Cells[15].Value = listaCAT21[i].GeometricHeight_feet;
            }
            else { dgvCAT21.Rows[n].Cells[15].Value = "No info."; }

            if (listaCAT21[i].QualityIndicators.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 16
            {
                dgvCAT21.Rows[n].Cells[16].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[16].Value = "No info."; }

            if (listaCAT21[i].MOPSVersion.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 17
            {
                dgvCAT21.Rows[n].Cells[17].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[17].Value = "No info."; }

            if (listaCAT21[i].Mode3ACode_bin.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 18
            {
                dgvCAT21.Rows[n].Cells[18].Value = listaCAT21[i].Mode3ACode_oct;
            }
            else { dgvCAT21.Rows[n].Cells[18].Value = "No info."; }

            if (listaCAT21[i].RollAngle.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 19
            {
                dgvCAT21.Rows[n].Cells[19].Value = listaCAT21[i].RollAngle_degrees;
            }
            else { dgvCAT21.Rows[n].Cells[19].Value = "No info."; }

            if (listaCAT21[i].FlightLevel.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 20
            {
                dgvCAT21.Rows[n].Cells[20].Value = String.Concat("FL" + listaCAT21[i].FlightLevel_FL.ToString());
            }
            else { dgvCAT21.Rows[n].Cells[20].Value = "No info."; }

            if (listaCAT21[i].MagneticHeading.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 21
            {
                dgvCAT21.Rows[n].Cells[21].Value = listaCAT21[i].MagneticHeading_degrees;
            }
            else { dgvCAT21.Rows[n].Cells[21].Value = "No info."; }

            if (listaCAT21[i].TargetStatus.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 22
            {
                dgvCAT21.Rows[n].Cells[22].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[22].Value = "No info."; }

            if (listaCAT21[i].BarometricVerticalRate.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 23
            {
                if (listaCAT21[i].RE_BVR == "Value in defined range.")
                {
                    dgvCAT21.Rows[n].Cells[23].Value = listaCAT21[i].BarometricVerticalRate_fmin;
                }
                else { dgvCAT21.Rows[n].Cells[23].Value = String.Concat(Convert.ToInt32(listaCAT21[i].BarometricVerticalRate_fmin), "(Range exceeded.)"); }
            }
            else { dgvCAT21.Rows[n].Cells[23].Value = "No info."; }

            if (listaCAT21[i].GeometricVerticalRate.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 24
            {
                if (listaCAT21[i].RE_GVR == "Value in defined range.")
                {
                    dgvCAT21.Rows[n].Cells[24].Value = listaCAT21[i].GeometricVerticalRate_fmin;
                }
                else { dgvCAT21.Rows[n].Cells[24].Value = String.Concat(Convert.ToInt32(listaCAT21[i].GeometricVerticalRate_fmin), "(Range exceeded.)"); }
            }
            else { dgvCAT21.Rows[n].Cells[24].Value = "No info."; }

            if (listaCAT21[i].AirborneGoundVector.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 25
            {
                if (listaCAT21[i].RE_AGV == "Value in defined range.")
                {
                    double GroundSpeed = listaCAT21[i].GroundSpeed;
                    GroundSpeed = Math.Round(GroundSpeed, numero_de_decimales);

                    double TrackAngle = listaCAT21[i].TrackAngle;
                    TrackAngle = Math.Round(TrackAngle, numero_de_decimales);

                    dgvCAT21.Rows[n].Cells[25].Value = String.Concat(GroundSpeed.ToString(), "/", TrackAngle.ToString());
                }
                else { dgvCAT21.Rows[n].Cells[25].Value = String.Concat(listaCAT21[i].GroundSpeed.ToString(), "/", listaCAT21[i].TrackAngle.ToString(), "(Range exceeded.)"); }
            }
            else { dgvCAT21.Rows[n].Cells[25].Value = "No info."; }

            if (listaCAT21[i].TrackAngleRate.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 26
            {
                dgvCAT21.Rows[n].Cells[26].Value = listaCAT21[i].TrackAngleRate_degs;
            }
            else { dgvCAT21.Rows[n].Cells[26].Value = "No info."; }


            double TORT_seconds = listaCAT21[i].TimeofASTERIXReportTransmission_seconds;

            // Convertimos en horas:mins:secs
            t = TimeSpan.FromSeconds(TORT_seconds);

            if (listaCAT21[i].TimeofASTERIXReportTransmission.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 27
            {
                dgvCAT21.Rows[n].Cells[27].Value = String.Concat(t.Hours, ":", t.Minutes, ":", t.Seconds + "." + t.Milliseconds);
            }
            else { dgvCAT21.Rows[n].Cells[27].Value = "No info."; }

            if (listaCAT21[i].TargetIdentification.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 28
            {
                dgvCAT21.Rows[n].Cells[28].Value = listaCAT21[i].TargetIdentification_decoded;
            }
            else { dgvCAT21.Rows[n].Cells[28].Value = "No info."; }

            if (listaCAT21[i].EmitterCategory.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 29
            {
                dgvCAT21.Rows[n].Cells[29].Value = listaCAT21[i].ECAT;
            }
            else { dgvCAT21.Rows[n].Cells[29].Value = "No info."; }

            if (listaCAT21[i].MetInformation.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 30
            {
                dgvCAT21.Rows[n].Cells[30].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[30].Value = "No info."; }

            if (listaCAT21[i].SelectedAltitude.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 31
            {
                dgvCAT21.Rows[n].Cells[31].Value = listaCAT21[i].SelectedAltitude_ft;
            }
            else { dgvCAT21.Rows[n].Cells[31].Value = "No info."; }

            if (listaCAT21[i].FinalStateSelectedAltitude.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 32
            {
                dgvCAT21.Rows[n].Cells[32].Value = listaCAT21[i].FinalStateSelectedAltitude_ft;
            }
            else { dgvCAT21.Rows[n].Cells[32].Value = "No info."; }

            if (listaCAT21[i].TrajectoryIntent.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 33
            {
                dgvCAT21.Rows[n].Cells[33].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[33].Value = "No info."; }

            if (listaCAT21[i].ServiceManagement.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 34
            {
                dgvCAT21.Rows[n].Cells[34].Value = listaCAT21[i].RP;
            }
            else { dgvCAT21.Rows[n].Cells[34].Value = "No info."; }

            if (listaCAT21[i].AircraftOperationalStatus.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 35
            {
                dgvCAT21.Rows[n].Cells[35].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[35].Value = "No info."; }

            if (listaCAT21[i].SurfaceCapabilitiesandCharacteristicas.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 36
            {
                dgvCAT21.Rows[n].Cells[36].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[36].Value = "No info."; }

            if (listaCAT21[i].MessageAmplitude.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 37
            {
                dgvCAT21.Rows[n].Cells[37].Value = listaCAT21[i].MessageAmplitude_dBm;
            }
            else { dgvCAT21.Rows[n].Cells[37].Value = "No info."; }

            if (listaCAT21[i].ModeSMBData.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 38
            {
                dgvCAT21.Rows[n].Cells[38].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[38].Value = "No info."; }

            if (listaCAT21[i].ACASResolutionAdvisoryReport.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 39
            {
                dgvCAT21.Rows[n].Cells[39].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[39].Value = "No info."; }

            if (listaCAT21[i].ReceiverID.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 40
            {
                dgvCAT21.Rows[n].Cells[40].Value = listaCAT21[i].ReceiverID_number;
            }
            else { dgvCAT21.Rows[n].Cells[40].Value = "No info."; }

            if (listaCAT21[i].DataAges.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 41
            {
                dgvCAT21.Rows[n].Cells[41].Value = "Click Here for more information.";
            }
            else { dgvCAT21.Rows[n].Cells[41].Value = "No info."; }
        }

        public void EscribirLineaCAT10(int i)
        {
            int n = dgvCAT10.Rows.Add();

            dgvCAT10.Rows[n].Cells[0].Value = i + 1; // ----------------------------------------------------------------------------------------- 0
            dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC); //---------------------------------------- 1

            if (listaCAT10[i].MessageType.Length > 0) // ----------------------------------------------------------------------------------------- 2
            {
                dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified;
            }
            else { dgvCAT10.Rows[n].Cells[2].Value = "No info."; }

            if (listaCAT10[i].TargetReportDescriptor.Length > 0) //-------------------------------------------------------------------------------- 3
            {
                dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information.";
            }
            else { dgvCAT10.Rows[n].Cells[3].Value = "No info."; }


            double TimeofDay = listaCAT10[i].TimeofDay_seconds;
            TimeSpan t = TimeSpan.FromSeconds(TimeofDay);

            if (listaCAT10[i].TimeofDay.Length > 0) //-------------------------------------------------------------------------------- 4
            {
                dgvCAT10.Rows[n].Cells[4].Value = t.Hours + ":" + t.Minutes + ":" + t.Seconds + "." + t.Milliseconds;
            }
            else { dgvCAT10.Rows[n].Cells[4].Value = "No info."; }

            if (listaCAT10[i].PositioninWGS84_coordinates.Length > 0) //-------------------------------------------------------------------------------- 5
            {
                dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString());
            }
            else { dgvCAT10.Rows[n].Cells[5].Value = "No info."; }

            if (listaCAT10[i].MeasuredPositioninPolarCoordinates.Length > 0) //-------------------------------------------------------------------------------- 6
            {
                double Rho = listaCAT10[i].Rho;
                Rho = Math.Round(Rho, numero_de_decimales);
                double Theta = listaCAT10[i].Theta;
                Theta = Math.Round(Theta, numero_de_decimales);

                dgvCAT10.Rows[n].Cells[6].Value = String.Concat(Rho.ToString(), "/", Theta.ToString());
            }
            else { dgvCAT10.Rows[n].Cells[6].Value = "No info."; }

            if (listaCAT10[i].PositioninCartesianCoordinates.Length > 0) //-------------------------------------------------------------------------------- 7
            {
                dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString());
            }
            else { dgvCAT10.Rows[n].Cells[7].Value = "No info."; }

            if (listaCAT10[i].CalculatedTrackVelocityinPolarCoordinates.Length > 0) //-------------------------------------------------------------------------------- 8
            {

                double GroundSpeed = Math.Round(listaCAT10[i].GroundSpeed, numero_de_decimales);
                double TrackAngle = Math.Round(listaCAT10[i].TrackAngle, numero_de_decimales);

                dgvCAT10.Rows[n].Cells[8].Value = String.Concat(GroundSpeed.ToString(), "/", TrackAngle.ToString());
            }
            else { dgvCAT10.Rows[n].Cells[8].Value = "No info."; }

            if (listaCAT10[i].CalculatedTrackVelocityinCartesianCoordinates.Length > 0) //-------------------------------------------------------------------------------- 9
            {
                double GroundSpeed = Math.Round(listaCAT10[i].Vx_cartesian, numero_de_decimales);
                double TrackAngle = Math.Round(listaCAT10[i].Vy_cartesian, numero_de_decimales);

                dgvCAT10.Rows[n].Cells[9].Value = String.Concat(listaCAT10[i].Vx_cartesian.ToString(), "/", listaCAT10[i].Vy_cartesian.ToString());
            }
            else { dgvCAT10.Rows[n].Cells[9].Value = "No info."; }

            if (listaCAT10[i].TrackNumber.Length > 0) //-------------------------------------------------------------------------------- 10
            {
                dgvCAT10.Rows[n].Cells[10].Value = listaCAT10[i].Tracknumber_value.ToString();
            }
            else { dgvCAT10.Rows[n].Cells[10].Value = "No info."; }

            if (listaCAT10[i].TrackStatus.Length > 0) //-------------------------------------------------------------------------------- 11
            {
                dgvCAT10.Rows[n].Cells[11].Value = "Click Here for more information.";
            }
            else { dgvCAT10.Rows[n].Cells[11].Value = "No info."; }

            if (listaCAT10[i].Mode3ACodeinOctal.Length > 0) //-------------------------------------------------------------------------------- 12
            {
                dgvCAT10.Rows[n].Cells[12].Value = listaCAT10[i].Mode3ACodeinOctal_decodified;
            }
            else { dgvCAT10.Rows[n].Cells[12].Value = "No info."; }

            if (listaCAT10[i].TargetAdress.Length > 0) //-------------------------------------------------------------------------------- 13
            {
                dgvCAT10.Rows[n].Cells[13].Value = listaCAT10[i].TargetAdress_decoded;
            }
            else { dgvCAT10.Rows[n].Cells[13].Value = "No info."; }

            if (listaCAT10[i].TargetIdentification.Length > 0) //-------------------------------------------------------------------------------- 14
            {
                dgvCAT10.Rows[n].Cells[14].Value = listaCAT10[i].TargetIdentification_decoded;
            }
            else { dgvCAT10.Rows[n].Cells[14].Value = "No info."; }

            if (listaCAT10[i].ModeSMBData.Length > 0) //-------------------------------------------------------------------------------- 15
            {
                dgvCAT10.Rows[n].Cells[15].Value = "Click Here for more information.";
            }
            else { dgvCAT10.Rows[n].Cells[15].Value = "No info."; }

            if (listaCAT10[i].VehicleFleetIdentification.Length > 0) //-------------------------------------------------------------------------------- 16
            {
                dgvCAT10.Rows[n].Cells[16].Value = listaCAT10[i].VFI;
            }
            else { dgvCAT10.Rows[n].Cells[16].Value = "No info."; }

            if (listaCAT10[i].FlightLevelInBinaryRepresentation.Length > 0) //-------------------------------------------------------------------------------- 17
            {
                dgvCAT10.Rows[n].Cells[17].Value = listaCAT10[i].FlightLevel;
            }
            else { dgvCAT10.Rows[n].Cells[17].Value = "No info."; }

            if (listaCAT10[i].MeasuredHeight.Length > 0) //-------------------------------------------------------------------------------- 18
            {
                dgvCAT10.Rows[n].Cells[18].Value = listaCAT10[i].MeasuredHeight_ft;
            }
            else { dgvCAT10.Rows[n].Cells[18].Value = "No info."; }

            if (listaCAT10[i].TargetSizeOrientation.Length > 0) //-------------------------------------------------------------------------------- 19
            {
                dgvCAT10.Rows[n].Cells[19].Value = "Click Here for more information.";
            }
            else { dgvCAT10.Rows[n].Cells[19].Value = "No info."; }

            if (listaCAT10[i].SystemStatus.Length > 0) //-------------------------------------------------------------------------------- 20
            {
                dgvCAT10.Rows[n].Cells[20].Value = "Click Here for more information.";
            }
            else { dgvCAT10.Rows[n].Cells[20].Value = "No info."; }

            if (listaCAT10[i].PreProgrammedMessage.Length > 0) //-------------------------------------------------------------------------------- 21
            {
                dgvCAT10.Rows[n].Cells[21].Value = String.Concat(listaCAT10[i].MSG, "(", listaCAT10[i].TRB, ")");
            }
            else { dgvCAT10.Rows[n].Cells[21].Value = "No info."; }

            if (listaCAT10[i].StandardDeviationofPosition.Length > 0) //-------------------------------------------------------------------------------- 22
            {
                dgvCAT10.Rows[n].Cells[22].Value = String.Concat(listaCAT10[i].StdDeviation_x, "/", listaCAT10[i].StdDeviation_y, "/", listaCAT10[i].StdDeviation_xy);
            }
            else { dgvCAT10.Rows[n].Cells[22].Value = "No info."; }

            if (listaCAT10[i].Presence.Length > 0) //-------------------------------------------------------------------------------- 23
            {
                dgvCAT10.Rows[n].Cells[23].Value = String.Concat(listaCAT10[i].DRHO.ToString(), "/", listaCAT10[i].DTHETA.ToString());
            }
            else { dgvCAT10.Rows[n].Cells[23].Value = "No info."; }

            if (listaCAT10[i].AmplitudeofPrimaryPlot.Length > 0) //-------------------------------------------------------------------------------- 24
            {
                dgvCAT10.Rows[n].Cells[24].Value = listaCAT10[i].AmplitudeofPrimaryPlot_value;
            }
            else { dgvCAT10.Rows[n].Cells[24].Value = "No info."; }

            if (listaCAT10[i].CalculatedAcceleration.Length > 0) //-------------------------------------------------------------------------------- 25
            {
                dgvCAT10.Rows[n].Cells[25].Value = String.Concat(listaCAT10[i].CalculatedAcceleration_X, "/", listaCAT10[i].CalculatedAcceleration_Y);
            }
            else { dgvCAT10.Rows[n].Cells[25].Value = "No info."; }
        }

        public void EscribirlineaCAT20(int i)
        {
            int n = dgvCAT20.Rows.Add();

            dgvCAT20.Rows[n].Cells[0].Value = i + 1; // ----------------------------------------------------------------------------------------- 0
            dgvCAT20.Rows[n].Cells[1].Value = String.Concat(listaCAT21v23[i].SAC, "/", listaCAT21v23[i].SIC); //---------------------------------------- 1

            if (listaCAT21v23[i].TargetReportDescriptor.Length > 0) // ---------------------------------------------------------------------------------------- 2
            {
                dgvCAT20.Rows[n].Cells[2].Value = "Clcik here for more information";
            }
            else { dgvCAT20.Rows[n].Cells[2].Value = "No info"; }


            TimeSpan t = TimeSpan.FromSeconds(listaCAT21v23[i].TimeofDay_seconds);

            if (listaCAT21v23[i].TimeofDay.Length > 0) // ---------------------------------------------------------------------------------------- 3
            {
                dgvCAT20.Rows[n].Cells[3].Value = String.Concat(t.Hours, ":", t.Minutes, ":", t.Seconds + "." + t.Milliseconds);
            }
            else { dgvCAT20.Rows[n].Cells[3].Value = "No info"; }

            if (listaCAT21v23[i].PositioninWGS_coordinates.Length > 0) // ---------------------------------------------------------------------------------------- 4
            {
                double latWGS84 = listaCAT21v23[i].latWGS84;
                latWGS84 = Math.Round(latWGS84, numero_de_decimales);
                double lonWGS84 = listaCAT21v23[i].lonWGS84;
                lonWGS84 = Math.Round(lonWGS84, numero_de_decimales);

                dgvCAT20.Rows[n].Cells[4].Value = String.Concat(latWGS84, "/", lonWGS84);
            }
            else { dgvCAT20.Rows[n].Cells[4].Value = "No info"; }

            if (listaCAT21v23[i].TargetAddress_bin.Length > 0) // ---------------------------------------------------------------------------------------- 5
            {
                dgvCAT20.Rows[n].Cells[5].Value = listaCAT21v23[i].TargetAdress_real;
            }
            else { dgvCAT20.Rows[n].Cells[5].Value = "No info"; }

            if (listaCAT21v23[i].GeometricAltitude.Length > 0) // ---------------------------------------------------------------------------------------- 6
            {
                dgvCAT20.Rows[n].Cells[6].Value = listaCAT21v23[i].GeometricAltitude_ft;
            }
            else { dgvCAT20.Rows[n].Cells[6].Value = "No info"; }

            if (listaCAT21v23[i].FigureofMerit.Length > 0) // ---------------------------------------------------------------------------------------- 7
            {
                dgvCAT20.Rows[n].Cells[7].Value = "Clcik here for more information";
            }
            else { dgvCAT20.Rows[n].Cells[7].Value = "No info"; }

            // -------------------------------------------------------------------------------------------------------------------------------- FX  

            if (listaCAT21v23[i].LinkTechnologyIndicator.Length > 0) // ---------------------------------------------------------------------------------------- 8
            {
                dgvCAT20.Rows[n].Cells[8].Value = "Clcik here for more information";
            }
            else { dgvCAT20.Rows[n].Cells[8].Value = "No info"; }

            if (listaCAT21v23[i].RollAngle.Length > 0) // ---------------------------------------------------------------------------------------- 9
            {
                dgvCAT20.Rows[n].Cells[10].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].RollAngle_degrees; ;
            }
            else { dgvCAT20.Rows[n].Cells[9].Value = "No info"; }

            if (listaCAT21v23[i].FlightLevel.Length > 0) // ---------------------------------------------------------------------------------------- 10
            {
                dgvCAT20.Rows[n].Cells[10].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].FlightLevel_FL; ;
            }
            else { dgvCAT20.Rows[n].Cells[10].Value = "No info"; }

            if (listaCAT21v23[i].AirSpeed.Length > 0) // ---------------------------------------------------------------------------------------- 11
            {
                dgvCAT20.Rows[n].Cells[11].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].AirSpeed_velocity;
            }
            else { dgvCAT20.Rows[n].Cells[11].Value = "No info"; }

            if (listaCAT21v23[i].TrueAirSpeed.Length > 0) // ---------------------------------------------------------------------------------------- 12
            {
                dgvCAT20.Rows[n].Cells[12].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TrueAirSpeed_number;
            }
            else { dgvCAT20.Rows[n].Cells[12].Value = "No info"; }

            if (listaCAT21v23[i].MagneticHeading.Length > 0) // ---------------------------------------------------------------------------------------- 13
            {
                dgvCAT20.Rows[n].Cells[13].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].MagneticHeading_degrees;
            }
            else { dgvCAT20.Rows[n].Cells[13].Value = "No info"; }

            if (listaCAT21v23[i].BarometricVerticalRate.Length > 0) // ---------------------------------------------------------------------------------------- 14
            {
                dgvCAT20.Rows[n].Cells[14].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].BarometricVerticalRate_fmin;
            }
            else { dgvCAT20.Rows[n].Cells[14].Value = "No info"; }

            // -------------------------------------------------------------------------------------------------------------------------------- FX 

            if (listaCAT21v23[i].GeometricVerticalRate.Length > 0) // ---------------------------------------------------------------------------------------- 15
            {
                dgvCAT20.Rows[n].Cells[15].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].GeometricVerticalRate_fmin;
            }
            else { dgvCAT20.Rows[n].Cells[15].Value = "No info"; }

            if (listaCAT21v23[i].GroundVector.Length > 0) // ---------------------------------------------------------------------------------------- 16
            {
                double GroundSpeed = listaCAT21v23[i].GroundSpeed;
                GroundSpeed = Math.Round(GroundSpeed, numero_de_decimales);
                double TrackAngle = listaCAT21v23[i].TrackAngle;
                TrackAngle = Math.Round(TrackAngle, numero_de_decimales);

                dgvCAT20.Rows[n].Cells[16].Value = dgvCAT20.Rows[n].Cells[9].Value = String.Concat(GroundSpeed, "/", TrackAngle);
            }
            else { dgvCAT20.Rows[n].Cells[16].Value = "No info"; }

            if (listaCAT21v23[i].RateofTurn.Length > 0) // ---------------------------------------------------------------------------------------- 17
            {
                dgvCAT20.Rows[n].Cells[17].Value = dgvCAT20.Rows[n].Cells[9].Value = String.Concat(listaCAT21v23[i].RateofTurn_deg, "/", listaCAT21v23[i].TI);
            }
            else { dgvCAT20.Rows[n].Cells[17].Value = "No info"; }

            if (listaCAT21v23[i].TargetIdentification.Length > 0) // ---------------------------------------------------------------------------------------- 18
            {
                dgvCAT20.Rows[n].Cells[18].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TargetIdentification_decoded;
            }
            else { dgvCAT20.Rows[n].Cells[18].Value = "No info"; }

            if (listaCAT21v23[i].TimeofDayAccuracy.Length > 0) // ---------------------------------------------------------------------------------------- 20
            {
                dgvCAT20.Rows[n].Cells[19].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TimeofDayAccuracy_sec;
            }
            else { dgvCAT20.Rows[n].Cells[19].Value = "No info"; }

            if (listaCAT21v23[i].TargetStatus.Length > 0) // ---------------------------------------------------------------------------------------- 21
            {
                dgvCAT20.Rows[n].Cells[20].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].TargetStatus_decoded;
            }
            else { dgvCAT20.Rows[n].Cells[20].Value = "No info"; }

            // -------------------------------------------------------------------------------------------------------------------------------- FX  

            if (listaCAT21v23[i].EmitterCategory.Length > 0) // ---------------------------------------------------------------------------------------- 22
            {
                dgvCAT20.Rows[n].Cells[21].Value = dgvCAT20.Rows[n].Cells[9].Value = listaCAT21v23[i].ECAT;
            }
            else { dgvCAT20.Rows[n].Cells[21].Value = "No info"; }

            if (listaCAT21v23[i].MetInfo.Length > 0) // ---------------------------------------------------------------------------------------- 23
            {
                dgvCAT20.Rows[n].Cells[22].Value = "Clcik here for more information";
            }
            else { dgvCAT20.Rows[n].Cells[22].Value = "No info"; }

            if (listaCAT21v23[i].IntermediateStateSelectedAltitude.Length > 0) // ---------------------------------------------------------------------------------------- 24
            {
                dgvCAT20.Rows[n].Cells[23].Value = listaCAT21v23[i].Altitude;
            }
            else { dgvCAT20.Rows[n].Cells[23].Value = "No info"; }

            if (listaCAT21v23[i].FinalStateSelectedAltitude.Length > 0) // ---------------------------------------------------------------------------------------- 25
            {
                dgvCAT20.Rows[n].Cells[24].Value = listaCAT21v23[i].FSS_Altitude;
            }
            else { dgvCAT20.Rows[n].Cells[24].Value = "No info"; }
        }

    }
}
