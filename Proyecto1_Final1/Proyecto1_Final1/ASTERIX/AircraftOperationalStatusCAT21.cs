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
    public partial class AircraftOperationalStatusCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public AircraftOperationalStatusCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void AircraftOperationalStatusCAT21_Load(object sender, EventArgs e)
        {
            lbTC.Text = listaCAT21[i].TC;
            lbTS.Text = listaCAT21[i].TS;
            lbARV.Text = listaCAT21[i].ARV;
            lbCDTIA.Text = listaCAT21[i].CDTI_A;
            lbTCAS.Text = listaCAT21[i].TCAS;
            lbSA.Text = listaCAT21[i].SA;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
