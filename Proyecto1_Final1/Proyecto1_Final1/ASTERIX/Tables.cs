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
                dgvCAT21.Rows[n].Cells[4].Value = listaCAT21[i].TimeofApplicability_Position_seconds;
                dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(), "/", listaCAT21[i].lonWGS84.ToString());
                dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString());

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
                    dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                    dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;
                    dgvCAT21.Rows[n].Cells[4].Value = listaCAT21[i].TimeofApplicability_Position_seconds;
                    dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(), "/", listaCAT21[i].lonWGS84.ToString());
                    dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString());

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
                    dgvCAT21.Rows[n].Cells[4].Value = listaCAT21[i].TimeofApplicability_Position_seconds;
                    dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(), "/", listaCAT21[i].lonWGS84.ToString());
                    dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString());

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
                    dgvCAT21.Rows[n].Cells[4].Value = listaCAT21[i].TimeofApplicability_Position_seconds;
                    dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(), "/", listaCAT21[i].lonWGS84.ToString());
                    dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString());

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
                    dgvCAT21.Rows[n].Cells[4].Value = listaCAT21[i].TimeofApplicability_Position_seconds;
                    dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(), "/", listaCAT21[i].lonWGS84.ToString());
                    dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString());

                    i = i + 1;
                }

                if (listaCAT21.Count > 0)
                {
                    lb_Pages.Text = "1 - 50";
                }
            }
        }
    }
}
