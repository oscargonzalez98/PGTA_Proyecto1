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
    public partial class LinkTechnologyv23 : Form
    {
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        int i;
        public LinkTechnologyv23(List<CAT21v23> listaCAT21v23, int i)
        {
            InitializeComponent();
            this.listaCAT21v23 = listaCAT21v23;
            this.i = i;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LinkTechnologyv23_Load(object sender, EventArgs e)
        {
            lbDTI.Text = listaCAT21v23[i].DTI;
            lbMDS.Text = listaCAT21v23[i].MDS;
            lbUAT.Text = listaCAT21v23[i].UAT;
            lbVDL.Text = listaCAT21v23[i].VDL;
            lbOTR.Text = listaCAT21v23[i].OTR;
        }
    }
}
