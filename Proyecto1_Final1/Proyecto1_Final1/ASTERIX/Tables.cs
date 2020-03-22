using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LIBRERIACLASES;

namespace ASTERIX
{
    public partial class Tables : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();

        int contador_forward = 1;
        int contador_backward = 0;

        public Tables(List<CAT10> listaCAT10, List<CAT20> listaCAT20, List<CAT21> listaCAT21)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT20 = listaCAT20;
            this.listaCAT21 = listaCAT21;

            if (listaCAT10.Count > 0)
            {
                btCAT10.BackColor = SystemColors.ActiveCaption;
            }
            if (listaCAT20.Count > 0)
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

            dgvCAT10.Rows.Clear();

            int i = 0;
            while (i < 50 && i < listaCAT10.Count)
            {
                int n = dgvCAT10.Rows.Add();

                dgvCAT10.Rows[n].Cells[0].Value = i + 1;
                dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC);
                dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified;
                dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information.";
                dgvCAT10.Rows[n].Cells[4].Value = listaCAT10[i].TimeofDay_seconds;
                dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString());
                dgvCAT10.Rows[n].Cells[6].Value = String.Concat(listaCAT10[i].Rho.ToString(), "/", listaCAT10[i].Theta.ToString());
                dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString());

                i = i + 1;
            }

            if (listaCAT10.Count > 0)
            {
                lb_Pages.Text = "1 - 50";
            }

        }

        private void btCAT21_Click(object sender, EventArgs e)
        {

            panelCAT10.Visible = true;
            panelCAT20.Visible = true;
            panelCAT21.Visible = true;

            panelCAT21.BackColor = SystemColors.ActiveCaption;
            dgvCAT21.Rows.Clear();

            int i = 0;
            while (i < 50 && i < listaCAT21.Count)
            {
                int n = dgvCAT21.Rows.Add();

                dgvCAT21.Rows[n].Cells[0].Value = i + 1;
                dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC, "/", listaCAT21[i].SIC);
                dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;

                // Convertimos en horas:mins:secs
                double TOA_Position_seconds= listaCAT21[i].TimeofApplicability_Position_seconds;

                double double1 = (TOA_Position_seconds / 3600);
                int horas = Convert.ToInt32(Math.Floor(double1));

                double double2 = (double1 - horas)*60;
                int mins = Convert.ToInt32(Math.Floor(double2));

                double secs = (double2 - mins) * 60;
                
                if (listaCAT21[i].TimeofApplicability_Position.Length > 0)
                {
                    dgvCAT21.Rows[n].Cells[4].Value = horas + ":" + mins + ":" + secs;
                }
                else { dgvCAT21.Rows[n].Cells[4].Value = "No info."; }

                if(listaCAT21[i].PositioninWGS_coordinates.Length>0) { dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(), "/", listaCAT21[i].lonWGS84.ToString()); }
                else { dgvCAT21.Rows[n].Cells[5].Value = "No info."; }

                if (listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0) { dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString()); }
                else { dgvCAT21.Rows[n].Cells[6].Value = "No info."; }

                // --------------------------------------------------------------------------------------------------------------------------------------------------------------FX

                double TOA_Velocity_seconds = listaCAT21[i].TimeofApplicability_Velocity_seconds;

                // Convertimos en horas:mins:secs
                double1 = (TOA_Velocity_seconds / 3600);
                horas = Convert.ToInt32(Math.Floor(double1));

                double2 = (double1 - horas) * 60;
                mins = Convert.ToInt32(Math.Floor(double2));

                secs = (double2 - mins) * 60;

                if (listaCAT21[i].TimeofApplicability_Position.Length > 0)
                {
                    dgvCAT21.Rows[n].Cells[7].Value = horas + ":" + mins + ":" + secs;
                }
                else { dgvCAT21.Rows[n].Cells[7].Value = "No info."; }

                if (listaCAT21[i].AirSpeed.Length>0)
                {

                    string str1 = listaCAT21[i].IM;
                    if (str1 == "0")
                    {
                        dgvCAT21.Rows[n].Cells[8].Value = (listaCAT21[i].AirSpeed_velocity).ToString() + " (IAS)";
                    }

                    else { dgvCAT21.Rows[n].Cells[8].Value = (listaCAT21[i].AirSpeed_Mach).ToString() + " (Mach)"; }
                }

                else { dgvCAT21.Rows[n].Cells[8].Value = "No info."; }

                if (listaCAT21[i].TrueAirSpeed.Length>0)
                {
                    if (listaCAT21[i].RE_TAS=="0")
                    {
                        dgvCAT21.Rows[n].Cells[9].Value = listaCAT21[i].TrueAirSpeed_number;
                    }
                    else { dgvCAT21.Rows[n].Cells[9].Value = listaCAT21[i].TrueAirSpeed_number.ToString() + "(Value excedes defined range.)"; }

                }
                else { dgvCAT21.Rows[n].Cells[9].Value = "No info."; }

                dgvCAT21.Rows[n].Cells[10].Value = listaCAT21[i].TargetAdress_real;


                double TOMR_Position_seconds = listaCAT21[i].TimeofMessageReception_Position_seconds;

                // Convertimos en horas:mins:secs
                double1 = (TOMR_Position_seconds / 3600);
                horas = Convert.ToInt32(Math.Floor(double1));

                double2 = (double1 - horas) * 60;
                mins = Convert.ToInt32(Math.Floor(double2));

                secs = (double2 - mins) * 60;
                if (listaCAT21[i].TimeofMessageReception_Position.Length>0)
                {
                    dgvCAT21.Rows[n].Cells[11].Value = horas + ":" + mins + ":" + secs;
                }
                else { dgvCAT21.Rows[n].Cells[11].Value = "No info."; }


                double TOMR_HPPosition_seconds = listaCAT21[i].TimeofMessageReception_HRPosition_seconds;

                // Convertimos en horas:mins:secs
                double1 = (TOMR_HPPosition_seconds / 3600);
                horas = Convert.ToInt32(Math.Floor(double1));

                double2 = (double1 - horas) * 60;
                mins = Convert.ToInt32(Math.Floor(double2));

                secs = (double2 - mins) * 60;
                if (listaCAT21[i].TimeofMessageReception_HRPosition.Length > 0)
                {
                    dgvCAT21.Rows[n].Cells[12].Value = horas + ":" + mins + ":" + secs;
                }
                else { dgvCAT21.Rows[n].Cells[12].Value = "No info."; }

                double TOMR_HPPVelocity_seconds = listaCAT21[i].TimeofMessageReception_Velocity_seconds;

                // Convertimos en horas:mins:secs
                double1 = (TOMR_HPPVelocity_seconds / 3600);
                horas = Convert.ToInt32(Math.Floor(double1));

                double2 = (double1 - horas) * 60;
                mins = Convert.ToInt32(Math.Floor(double2));

                secs = (double2 - mins) * 60;
                if (listaCAT21[i].TimeofMessageReception_Velocity.Length > 0)
                {
                    dgvCAT21.Rows[n].Cells[13].Value = horas + ":" + mins + ":" + secs;
                }
                else { dgvCAT21.Rows[n].Cells[13].Value = "No info."; }

                // --------------------------------------------------------------------------------------------------------------------------------------------------------------FX

                double TOA_HRVelocity_seconds = listaCAT21[i].TimeofMessageReception_HRVelocity_seconds;

                // Convertimos en horas:mins:secs
                double1 = (TOA_HRVelocity_seconds / 3600);
                horas = Convert.ToInt32(Math.Floor(double1));

                double2 = (double1 - horas) * 60;
                mins = Convert.ToInt32(Math.Floor(double2));

                secs = (double2 - mins) * 60;

                if (listaCAT21[i].TimeofMessageReception_HRVelocity.Length > 0) //----------------------------------------------------------------------------------------------------------------------------------------------- 14
                {
                    dgvCAT21.Rows[n].Cells[14].Value = horas + ":" + mins + ":" + secs;
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
                    int n = dgvCAT10.Rows.Add();

                    dgvCAT10.Rows[n].Cells[0].Value = i + 1; //---------------------------------------------------------------------------------------------------------------
                    dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC); //------------------------------------------------------------
                    dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified; //--------------------------------------------------------------------------------
                    dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information."; //----------------------------------------------------------------------------------
                    dgvCAT10.Rows[n].Cells[4].Value = listaCAT10[i].TimeofDay_seconds; //-------------------------------------------------------------------------------------
                    dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString()); //----------------------------
                    dgvCAT10.Rows[n].Cells[6].Value = String.Concat(listaCAT10[i].Rho.ToString(), "/", listaCAT10[i].Theta.ToString()); //------------------------------------
                    dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString()); //----------------------

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
                    int n = dgvCAT21.Rows.Add();

                    dgvCAT21.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC, "/", listaCAT21[i].SIC);

                    if (listaCAT21[i].TargetReportDescriptor.Length>0)
                    {
                        dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                    }
                    else { dgvCAT21.Rows[n].Cells[2].Value = "No info."; }

                    if (listaCAT21[i].TrackNumber.Length > 0)
                    {
                        dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;
                    }
                    else { dgvCAT21.Rows[n].Cells[3].Value = "No info."; }

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
                    int n = dgvCAT10.Rows.Add();

                    dgvCAT10.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC);
                    dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified;
                    dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information.";
                    dgvCAT10.Rows[n].Cells[4].Value = listaCAT10[i].TimeofDay_seconds;
                    dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString());
                    dgvCAT10.Rows[n].Cells[6].Value = String.Concat(listaCAT10[i].Rho.ToString(), "/", listaCAT10[i].Theta.ToString());
                    dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString());

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
                    int n = dgvCAT21.Rows.Add();


                    dgvCAT21.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC, "/", listaCAT21[i].SIC);
                    dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                    dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;

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
                    int n = dgvCAT10.Rows.Add();

                    dgvCAT10.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC);
                    dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified;
                    dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information.";
                    dgvCAT10.Rows[n].Cells[4].Value = listaCAT10[i].TimeofDay_seconds;
                    dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString());
                    dgvCAT10.Rows[n].Cells[6].Value = String.Concat(listaCAT10[i].Rho.ToString(), "/", listaCAT10[i].Theta.ToString());
                    dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString());

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
                    int n = dgvCAT21.Rows.Add();

                    dgvCAT21.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC, "/", listaCAT21[i].SIC);
                    dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                    dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;


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
                    int n = dgvCAT10.Rows.Add();

                    dgvCAT10.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC);
                    dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified;
                    dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information.";
                    dgvCAT10.Rows[n].Cells[4].Value = listaCAT10[i].TimeofDay_seconds;
                    dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString());
                    dgvCAT10.Rows[n].Cells[6].Value = String.Concat(listaCAT10[i].Rho.ToString(), "/", listaCAT10[i].Theta.ToString());
                    dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString());

                    i = i + 1;
                }

                if (listaCAT10.Count > 0)
                {
                    lb_Pages.Text = "1 - 50";
                }

            }

            if (panelCAT10.Visible == true && panelCAT20.Visible == true && panelCAT21.Visible == true)
            {
                dgvCAT21.Rows.Clear();
                int i = 0;
                while (i < 50 && i < listaCAT21.Count)
                {
                    int n = dgvCAT21.Rows.Add();

                    dgvCAT21.Rows[n].Cells[0].Value = i + 1;
                    dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC, "/", listaCAT21[i].SIC);
                    dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                    dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;

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
            int c = e.ColumnIndex;
            int r = e.RowIndex;
            int i = (int)dgvCAT21.Rows[r].Cells[0].Value-1;

            if(listaCAT21[i].TargetReportDescriptor.Length>0)
            {
                if (c == 2)
                {
                    TargetReportDescriptorCAT21 TRP1 = new TargetReportDescriptorCAT21(listaCAT21, i);
                    TRP1.ShowDialog();
                }
            }


        }
    }
}
