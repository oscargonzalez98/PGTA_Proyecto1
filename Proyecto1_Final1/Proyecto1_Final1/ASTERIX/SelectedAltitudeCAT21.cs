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
    public partial class SelectedAltitudeCAT21 : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public SelectedAltitudeCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void SelectedAltitudeCAT21_Load(object sender, EventArgs e)
        {
            lbSAS.Visible = true;
            lbSource.Visible = true;
            lbSAS1.Text=listaCAT21[i].SAS;
            lbSource1.Text=listaCAT21[i].Source;
        }
    }
}
