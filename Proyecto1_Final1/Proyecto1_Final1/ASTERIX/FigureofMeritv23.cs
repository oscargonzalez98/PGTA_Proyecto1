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
    public partial class FigureofMeritv23 : Form
    {
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        int i;

        public FigureofMeritv23(
        List<CAT21v23> listaCAT21v23, int i)
        {
            InitializeComponent();
            this.listaCAT21v23 = listaCAT21v23;
            this.i = i;
        }

        private void FigureofMeritv23_Load(object sender, EventArgs e)
        {
            lbAC.Text = listaCAT21v23[i].AC;
            lbMN.Text = listaCAT21v23[i].MN;
            lbDC.Text = listaCAT21v23[i].DC;
            lbPA.Text = listaCAT21v23[i].PA.ToString(); ;

        }
    }
}
