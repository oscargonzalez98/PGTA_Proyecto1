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
    public partial class Portada : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        public List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();

        public Portada()
        {
            InitializeComponent();

            // Fondo
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\portada.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            lb_Instructions.Text = "Please click Browse File to decode.";

        }

        private void bt_BrowseFile_Click(object sender, EventArgs e)
        {
            BrowseFile BrowseFile1 = new BrowseFile();
            BrowseFile1.ShowDialog();
            listaCAT10 = BrowseFile1.ListaCAT10;
            listaCAT20 = BrowseFile1.ListaCAT20;
            listaCAT21 = BrowseFile1.ListaCAT21;
            listaCAT21v23= BrowseFile1.ListaCAT21v23;

            lb_Instructions.Text = "The file has been processed successfully.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tables Tables1 = new Tables(listaCAT10, listaCAT20, listaCAT21, listaCAT21v23);
            Tables1.Show();
        }

        private void Portada_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MapView1 MapView = new MapView1(listaCAT10, listaCAT21, listaCAT21v23);
            MapView.Show();
        }

        private void lbErrores_Click(object sender, EventArgs e)
        {

        }

        private void bt_ED_Click(object sender, EventArgs e)
        {
            List<CAT10> listaMLAT = new List<CAT10>();
            List<CAT10> listaSMR = new List<CAT10>();

            int i = 0;
            while (i < listaCAT10.Count)
            {
                int SAC = listaCAT10[i].SAC;
                int SIC = listaCAT10[i].SIC;

                if (SAC == 0 && SIC == 7)
                {
                    listaSMR.Add(listaCAT10[i]);
                }
                if (SAC == 0 && SIC == 107)
                {
                    listaMLAT.Add(listaCAT10[i]);
                }
                i = i + 1;
            }

            if(listaMLAT.Count>0 && listaCAT21.Count>0)
            {
                ED newED = new ED(listaCAT10, listaCAT21);
                newED.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoreInfo MoreInfo1 = new MoreInfo();
            MoreInfo1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Export export1 = new Export(listaCAT10, listaCAT21, listaCAT21v23);
            export1.Show();
        }
    }
}
