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
    public partial class QualityIndicatorsCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public QualityIndicatorsCAT21(List<CAT21> listaCAT21,int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void QualityIndicatorsCAT21_Load(object sender, EventArgs e)
        {
            lbNUCr.Text = listaCAT21[i].NACv.ToString();
            lbNUCp.Text= listaCAT21[i].NUCp.ToString();

            if(listaCAT21.Count>8)
            {
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                lbNICbaro.Visible = true;
                lbSIL.Visible = true;
                lbNACp.Visible = true;

                lbNICbaro.Text = listaCAT21[i].NIC_Baro.ToString();
                lbSIL.Text = listaCAT21[i].SIL;
                lbNACp.Text = listaCAT21[i].NACp.ToString();

                if(listaCAT21.Count>16)
                {
                    label7.Visible = true;
                    label8.Visible = true;

                    lbSDA.Visible = true;
                    lbGVA.Visible = true;

                    lbSDA.Text = listaCAT21[i].SDA.ToString();
                    lbGVA.Text = listaCAT21[i].GVA.ToString();
                }
            }
        }
    }
}
