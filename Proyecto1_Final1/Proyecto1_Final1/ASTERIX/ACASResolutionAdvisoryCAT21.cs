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
    public partial class ACASResolutionAdvisoryCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public ACASResolutionAdvisoryCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21=listaCAT21;
            this.i=i;
        }

        private void ACASResolutionAdvisoryCAT21_Load(object sender, EventArgs e)
        {
            lbTYP.Text = listaCAT21[i].TYP.ToString();
            lbSTYP.Text = listaCAT21[i].STYP.ToString();
            lbARA.Text = listaCAT21[i].ARA.ToString();
            lbRAC.Text = listaCAT21[i].RAC.ToString();
            lbRAT.Text = listaCAT21[i].RAT.ToString();
            lbMTE.Text = listaCAT21[i].MTE.ToString();
            lbTTI.Text = listaCAT21[i].TTI.ToString();
            lbTID.Text = listaCAT21[i].TID.ToString();
        }
    }
}
