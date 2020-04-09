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
    public partial class MetInfov23 : Form
    {
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        int i;

        public MetInfov23(List<CAT21v23> listaCAT21v23, int i)
        {
            this.listaCAT21v23 = listaCAT21v23;
            this.i = i;
        }

        private void MetInfov23_Load(object sender, EventArgs e)
        {
            if(listaCAT21v23[i].WindSpeed != 10e10) { lbWS.Text = listaCAT21v23[i].WindSpeed.ToString(); }
            else { lbWS.Text = "No info."; }

            if (listaCAT21v23[i].WindDirection != 10e10) { lbWD.Text = listaCAT21v23[i].WindDirection.ToString(); }
            else { lbWD.Text = "No info."; }

            if (listaCAT21v23[i].Temperature != 10e10) { lbTemp.Text = listaCAT21v23[i].Temperature.ToString(); }
            else { lbTemp.Text = "No info."; }

            if (listaCAT21v23[i].Turbulence != 10e10) { lbTurb.Text = listaCAT21v23[i].Turbulence.ToString(); }
            else { lbTurb.Text = "No info."; }

        }
    }
}
