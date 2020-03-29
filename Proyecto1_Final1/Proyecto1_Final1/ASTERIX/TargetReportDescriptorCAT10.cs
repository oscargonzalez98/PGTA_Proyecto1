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
    public partial class TargetReportDescriptorCAT10 : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public TargetReportDescriptorCAT10(List<CAT10> listaCAT10, int i)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.i = i;
        }

        private void TargetReportDescriptorCAT10_Load(object sender, EventArgs e)
        {
            lbTYP1.Text = listaCAT10[i].TYP;
            lbDCR1.Text = listaCAT10[i].DCR;
            lbCHN1.Text = listaCAT10[i].CHN;
            lbGBS1.Text = listaCAT10[i].GBS;
            lbCRT1.Text = listaCAT10[i].CRT;

            if (listaCAT10[i].TargetReportDescriptor.Length>8)
            {
                lbSIM.Visible = true;
                lbTST.Visible = true;
                lbRAB.Visible = true;
                lbLOP.Visible = true;
                lbTOT.Visible = true;

                lbSIM1.Visible = true;
                lbTST1.Visible = true;
                lbRAB1.Visible = true;
                lbLOP1.Visible = true;
                lbTOT1.Visible = true;

                lbSIM1.Text = listaCAT10[i].SIM;
                lbTST1.Text = listaCAT10[i].TST;
                lbRAB1.Text = listaCAT10[i].RAB;
                lbLOP1.Text = listaCAT10[i].LOP;
                lbTOT1.Text = listaCAT10[i].TOT;

                if(listaCAT10[i].TargetReportDescriptor.Length>16)
                {
                    lbSPI.Visible = true;
                    lbSPI1.Visible = true;

                    lbSPI1.Text = listaCAT10[i].SPI;
                }

            }
        }
    }
}
