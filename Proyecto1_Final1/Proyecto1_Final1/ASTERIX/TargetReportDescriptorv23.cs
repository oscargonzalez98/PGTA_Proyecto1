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
    public partial class TargetReportDescriptorv23 : Form
    {
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        int i;

        public TargetReportDescriptorv23(List<CAT21v23> listaCAT21v23, int i)
        {
            InitializeComponent();
            this.listaCAT21v23 = listaCAT21v23;
            this.i = i;
        }

        private void TargetReportDescriptorv23_Load(object sender, EventArgs e)
        {
            lbDCR.Text = listaCAT21v23[i].DCR;
            lbGBS.Text = listaCAT21v23[i].GBS;
            lbSIM.Text = listaCAT21v23[i].SIM;
            lbTST.Text = listaCAT21v23[i].TST;
            lbRAB.Text = listaCAT21v23[i].RAB;
            lbSAA.Text = listaCAT21v23[i].SAA;
            lbSPI.Text = listaCAT21v23[i].SPI;
            lbATP.Text = listaCAT21v23[i].ATP;
            lbARC.Text = listaCAT21v23[i].ARC;
        }
    }
}
