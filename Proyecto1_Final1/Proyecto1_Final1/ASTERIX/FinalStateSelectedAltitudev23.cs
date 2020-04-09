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
    public partial class FinalStateSelectedAltitudev23 : Form
    {
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        int i;

        public FinalStateSelectedAltitudev23(List<CAT21v23> listaCAT21v23, int i)
        {
            InitializeComponent();
            this.listaCAT21v23 = listaCAT21v23;
            this.i = i;
        }

        private void FinalStateSelectedAltitudev23_Load(object sender, EventArgs e)
        {
            lbMV.Text = listaCAT21v23[i].MV;
            lbAH.Text = listaCAT21v23[i].AH;
            lbAM.Text = listaCAT21v23[i].AM;
        }
    }
}
