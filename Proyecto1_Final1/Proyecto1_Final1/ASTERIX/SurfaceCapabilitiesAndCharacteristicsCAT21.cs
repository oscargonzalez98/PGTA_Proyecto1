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
    public partial class SurfaceCapabilitiesAndCharacteristicsCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public SurfaceCapabilitiesAndCharacteristicsCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21=listaCAT21;
            this.i = i;
        }

        private void SurfaceCapabilitiesAndCharacteristicsCAT21_Load(object sender, EventArgs e)
        {
            lbPOA.Text = listaCAT21[i].POA;
            lbCDTIS.Text = listaCAT21[i].CDTI_S;
            lbB2.Text = listaCAT21[i].B2low;
            lbRAS.Text = listaCAT21[i].RAS;
            lbIDENT.Text = listaCAT21[i].IDENT;

            if(listaCAT21[i].SurfaceCapabilitiesandCharacteristicas.Length>8)
            {
                lbLW.Visible = true;
                label6.Visible = true;

                lbLW.Text = String.Concat(listaCAT21[i].Length, "/", listaCAT21[i].Width);
            }
        }
    }
}
