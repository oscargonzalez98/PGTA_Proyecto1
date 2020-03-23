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
    public partial class FinalStateSelectedAltitudeCAT21 : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public FinalStateSelectedAltitudeCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void FinalStateSelectedAltitudeCAT21_Load(object sender, EventArgs e)
        {
            lbMV1.Text = listaCAT21[i].MV;
            lbAH1.Text = listaCAT21[i].AH;
            lbAM1.Text = listaCAT21[i].AM;
        }
    }
}
