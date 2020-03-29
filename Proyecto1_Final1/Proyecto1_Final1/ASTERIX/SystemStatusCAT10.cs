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
    public partial class SystemStatusCAT10 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public SystemStatusCAT10(List<CAT10> listaCAT10, int i)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.i = i;
        }

        private void SystemStatusCAT10_Load(object sender, EventArgs e)
        {
            lbNOGO.Text = listaCAT10[i].NOGO;
            lbOVL.Text = listaCAT10[i].OVL;
            lbTSV.Text = listaCAT10[i].TSV;
            lbDIV.Text = listaCAT10[i].DIV;
            lbTTF.Text = listaCAT10[i].TTF;
        }
    }
}
