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
    public partial class ModeSMBDataCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public ModeSMBDataCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void ModeSMBDataCAT21_Load(object sender, EventArgs e)
        {
            lbMBData1.Text = listaCAT21[i].MBDATA.ToString();
            lbBDS1.Text = listaCAT21[i].BDS1.ToString();
            lbBDS2.Text = listaCAT21[i].BDS2.ToString();
        }
    }
}
