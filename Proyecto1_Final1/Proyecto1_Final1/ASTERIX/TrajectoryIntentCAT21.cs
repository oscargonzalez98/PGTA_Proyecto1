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
    public partial class TrajectoryIntentCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i = 0;

        public TrajectoryIntentCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21=listaCAT21;
            this.i=i;
        }
        private void TrajectoryIntentCAT21_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            lbNAV.Text = listaCAT21[i].NAV;
            lbNVB.Text = listaCAT21[i].NVB;

            if (listaCAT21[i].TrajectoryIntent.Length > 16)
            {
                panel2.Visible = true;

                if (listaCAT21[i].TCA.Length > 0)
                {
                    lbTCA.Text = listaCAT21[i].TCA;
                }
                else { lbTCA.Text = "No info."; }

                if (listaCAT21[i].NC.Length > 0)
                {
                    lbNC.Text = listaCAT21[i].NC;
                }
                else { lbNC.Text = "No info."; }

                lbTCPnum.Text = listaCAT21[i].TCP.ToString();
                lbAlt.Text = listaCAT21[i].TI_ALtitude.ToString();
                lbLAT.Text = listaCAT21[i].TI_Latitude.ToString();
                lbLON.Text = listaCAT21[i].TI_Longitude.ToString();

                if(listaCAT21[i].PointType.Length>0)
                {
                    lbPointType.Text = listaCAT21[i].PointType;
                }
                else { lbPointType.Text = "No info."; }

                if (listaCAT21[i].TD.Length>0)
                {
                    lbTD.Text = listaCAT21[i].TD;
                }
                else { lbTD.Text = "No info."; }

                if(listaCAT21[i].TRA.Length>0)
                {
                    lbTRA.Text = listaCAT21[i].TRA;
                }
                else { lbTRA.Text = "No info."; }

                double TOP1 = listaCAT21[i].TOV;

                // Convertimos en horas:mins:secs
                double double1 = (TOP1 / 3600);
                double horas = Convert.ToInt32(Math.Floor(double1));

                double double2 = (double1 - horas) * 60;
                double mins = Convert.ToInt32(Math.Floor(double2));

                double secs = (double2 - mins) * 60;

                lbTOV.Text = String.Concat(horas, ":", mins, ":", secs);

                lbTTR.Text = listaCAT21[i].TTR.ToString();
            }

        }
    }
}
