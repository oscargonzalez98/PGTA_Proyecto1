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
    public partial class BrowseFile : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();

        public BrowseFile()
        {
            InitializeComponent();

            Bitmap img = new Bitmap(Application.StartupPath + @"\img\Captura.png");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            lblError.Text = "";
            lbTitle.Text = "BROWSE A FILE AND SELECT IT TO DECODE";
        }

        public List<CAT21> ListaCAT21
        {
            get { return listaCAT21; }
        }

        public List<CAT20> ListaCAT20
        {
            get { return listaCAT20; }
        }

        public List<CAT10> ListaCAT10
        {
            get { return listaCAT10; }
        }

        private void bt_SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string direccion = openFileDialog1.FileName;
                char char1;
                int i = 0;
                bool bool1 = false;
                while (i < direccion.Length && direccion[i] != Convert.ToChar(":") && bool1 == false)
                {
                    try
                    {
                        char1 = Convert.ToChar(direccion[i]);
                    }
                    catch
                    {
                        bool1 = true;
                    }
                    i = i + 1;
                }
                char1 = Convert.ToChar(direccion[i + 1]);
                char char2 = Convert.ToChar("/");

                tbDirection.Text = direccion.Replace(char1, char2);
            }
        }

        private void bt_Decode_Click(object sender, EventArgs e)
        {
            if (tbDirection.Text.Length > 0)
            {
                try
                {
                    string path = tbDirection.Text;
                    string path1 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/adsb_v21_bcn.ast"; // CAT21
                    string path2 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/smr_160510-lebl-220001.ast"; // SMR
                    string path3 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/mlat_160510-lebl-220001.ast"; // MLAT
                    string path4 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/smr_mlat_160510-lebl-220001.ast"; // SMR + MLAT;

                    Fichero newfichero = new Fichero(path);
                    newfichero.leer();

                    listaCAT21 = newfichero.GetListCAT21(); // devuelve lista de clases CAT21, cada una con un paquete
                    listaCAT20 = newfichero.GetListCAT20();
                    listaCAT10 = newfichero.getListCAT10();

                    //panelFondo.Visible = true;
                    //btTables.BackColor = SystemColors.ActiveCaption;

                    this.Close();

                }
                catch
                {
                    lblError.Text = "Error. Please select a valid file.";
                }
            }

            else
            {
                lblError.Text = "Please select a file.";
            }


        }

        private void tbDirection_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
