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
    public partial class TargetReportDescriptorCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public TargetReportDescriptorCAT21(List<CAT21> listaCAT21,int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel_PrimarySubfield_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelFirstExtension_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TargetReportDescriptorCAT21_Load(object sender, EventArgs e)
        {

            if (listaCAT21[i].TargetReportDescriptor.Length == 8) // Si solo tenemos octeto principal
            {
                panel_PrimarySubfield.Visible = true;
                lbATP.Text = listaCAT21[i].ATP;
                lbARC.Text = listaCAT21[i].ARC;
                lbRC.Text = listaCAT21[i].RC;
                lbRAB.Text = listaCAT21[i].RAB;
            }

            if (listaCAT21[i].TargetReportDescriptor.Length == 16) // Si tenemos octeto principal + 1 extension
            {
                panel_PrimarySubfield.Visible = true;
                panelFirstExtension.Visible = true;

                lbATP1.Text = listaCAT21[i].ATP;
                lbARC1.Text = listaCAT21[i].ARC;
                lbRC1.Text = listaCAT21[i].RC;
                lbRAB1.Text = listaCAT21[i].RAB;

                lbDCR1.Text = listaCAT21[i].DCR;
                lbGBS1.Text = listaCAT21[i].GBS;
                lbSIM1.Text = listaCAT21[i].SIM;
                lbTST1.Text = listaCAT21[i].TST;
                lbSAA1.Text = listaCAT21[i].SAA;
                lbCL1.Text = listaCAT21[i].CL;
            }

            else
            {
                panel_PrimarySubfield.Visible = true;
                panelFirstExtension.Visible = true;
                panelSecondExtension.Visible = true;

                lbATP2.Text = listaCAT21[i].ATP;
                lbARC2.Text = listaCAT21[i].ARC;
                lbRC2.Text = listaCAT21[i].RC;
                lbRAB2.Text = listaCAT21[i].RAB;

                lbDCR2.Text = listaCAT21[i].DCR;
                lbGBS2.Text = listaCAT21[i].GBS;
                lbSIM2.Text = listaCAT21[i].SIM;
                lbTST2.Text = listaCAT21[i].TST;
                lbSAA2.Text = listaCAT21[i].SAA;
                lbCL2.Text = listaCAT21[i].CL;

                lbIPC2.Text = listaCAT21[i].IPC;
                lbNOGO2.Text = listaCAT21[i].NOGO;
                lbCPR2.Text = listaCAT21[i].CPR;
                lbLDPJ2.Text = listaCAT21[i].LDPJ;
                lbRCF2.Text = listaCAT21[i].RCF;
            }
        }


        // Target report descriptor tiene 1 primaria y dos extensiones:
        // Pondremos 3 paneles(uno para cada opcion) y segun la longitud de TargetReportDescriptor se pondra visible uno u otro.



    }
}
