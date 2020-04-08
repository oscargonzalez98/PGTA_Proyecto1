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
    public partial class Portada : Form
    {

        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();

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

            lb_Instructions.Text = "The file has been processed successfully.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tables Tables1 = new Tables(listaCAT10, listaCAT20, listaCAT21);
            Tables1.ShowDialog();
        }

        private void btn_mapviewer_Click(object sender, EventArgs e)
        {
            MapView mapView = new MapView(listaCAT10, listaCAT20, listaCAT21);
            mapView.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PruebasMapas PM1 = new PruebasMapas(listaCAT10, listaCAT20, listaCAT21);
            PM1.ShowDialog();
            lbErrores.Visible = false;
        }

        private void Portada_Load(object sender, EventArgs e)
        {

        }
    }
}
