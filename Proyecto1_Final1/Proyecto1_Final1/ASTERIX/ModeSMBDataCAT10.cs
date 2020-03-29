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
    public partial class ModeSMBDataCAT10 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public ModeSMBDataCAT10(List<CAT10> listaCAT10, int i)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.i = i;
        }

        private void ModeSMBDataCAT10_Load(object sender, EventArgs e)
        {
            lbMBData1.Text = listaCAT10[i].MBDATA.ToString();
            lbBDS1.Text = listaCAT10[i].BDS1.ToString();
            lbBDS2.Text = listaCAT10[i].BDS2.ToString();
        }
    }
}
