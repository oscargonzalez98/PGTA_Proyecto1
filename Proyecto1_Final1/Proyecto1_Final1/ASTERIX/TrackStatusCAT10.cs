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
    public partial class TrackStatusCAT10 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public TrackStatusCAT10(List<CAT10> listaCAT10, int i)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.i = i;
        }

        private void TrackStatusCAT10_Load(object sender, EventArgs e)
        {
            lbCNF1.Text = listaCAT10[i].CNF;
            lbTRE1.Text = listaCAT10[i].TRE;
            lbCST1.Text = listaCAT10[i].CST;
            lbMAH1.Text = listaCAT10[i].MAH;
            lbTCC1.Text = listaCAT10[i].TCC;
            lbSTH1.Text = listaCAT10[i].STH;

            if(listaCAT10[i].TrackStatus.Length>8)
            {
                lbTOM.Visible = true;
                lbDOU.Visible = true;
                lbMRS.Visible = true;

                lbTOM1.Visible = true;
                lbDOU1.Visible = true;
                lbMRS1.Visible = true;

                lbTOM1.Text = listaCAT10[i].TOM;
                lbDOU1.Text = listaCAT10[i].DOU;
                lbMRS1.Text = listaCAT10[i].MRS;

                if (listaCAT10[i].TrackStatus.Length > 16)
                {
                    lbGHO.Visible = true;
                    lbGHO1.Visible = true;

                    lbGHO1.Text = listaCAT10[i].GHO;
                }
            }
        }
    }
}
