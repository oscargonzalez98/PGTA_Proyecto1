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
    public partial class MetInfoCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public MetInfoCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void MetInfoCAT21_Load(object sender, EventArgs e)
        {
            lbWS.Visible = false;
            lbWD.Visible = false;
            lbT.Visible = false;
            lbTURB.Visible = false;

            lbWS1.Visible = false;
            lbWD1.Visible = false;
            lbT1.Visible = false;
            lbTURB1.Visible = false;


            if (listaCAT21[i].MetInformation.Length>0)
            {
                lbWS.Visible = true;
                lbWS1.Visible = true;
                lbWS1.Text = listaCAT21[i].WindSpeed.ToString();

                if(listaCAT21[i].MetInformation.Length>16)
                {
                    lbWD.Visible = true;
                    lbWD1.Visible = true;
                    lbWD1.Text = listaCAT21[i].WindDirection.ToString();

                    if (listaCAT21[i].MetInformation.Length > 32)
                    {
                        lbT.Visible = true;
                        lbT1.Visible = true;
                        lbT1.Text = listaCAT21[i].Temperature.ToString();

                        if (listaCAT21[i].MetInformation.Length > 48)
                        {
                            lbTURB.Visible = true;
                            lbTURB1.Visible = true;
                            lbTURB1.Text = listaCAT21[i].Temperature.ToString();
                        }
                    }
                }
            }
        }
    }
}
