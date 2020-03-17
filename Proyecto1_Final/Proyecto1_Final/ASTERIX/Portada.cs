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

        public DataTable tablaCAT10 = new DataTable();
        public DataTable tablaCAT20 = new DataTable();
        public DataTable tablaCAT21 = new DataTable();

        public Portada()
        {
            InitializeComponent();

            // Fondo
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\portada.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Mensaje de error lo dejamos vacio
            lblError.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //panelStart.Visible == false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btBrowsefile_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string direccion = openFileDialog1.FileName;
                char char1;
                int i = 0;
                bool bool1 = false;
                while (i < direccion.Length && direccion[i]!=Convert.ToChar(":") && bool1==false)
                {
                    try
                    {
                        char1 = Convert.ToChar(direccion[i]);
                    }
                    catch
                    {
                        bool1 = true;
                    }
                    i=i+1;
                }
                char1 = Convert.ToChar(direccion[i+1]);
                char char2 = Convert.ToChar("/");

                tb_direction.Text = direccion.Replace(char1,char2);
            }
        }

        private void btProcessData_Click(object sender, EventArgs e)
        {


        }
        private void Portada_Resize(object sender, EventArgs e)
        {

        }

        private void btTables_Click(object sender, EventArgs e)
        {
            // Cada vez que activemos boton de tablas

            panelTableCAT21.Visible = true; // hacemos el panael de las tablas visible
            btTables.BackColor = SystemColors.ActiveCaption; // le cambiamos el color a visible (el boton del panel que esta activo en ese momento tiene que tener ese color)

            // Ponemos el resto de botones a color de no activos 
            //btMap.BackColor = SystemColors.Control;
            //btViewFligths.BackColor = SystemColors.Control;
            //btIntroduction.BackColor = SystemColors.Control;

        }

        private void lbl_Title_Click(object sender, EventArgs e)
        {

        }

        private void tb_direction_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void btProcessData_Click_1(object sender, EventArgs e)
        {
            if (tb_direction.Text.Length > 0)
            {
                try
                {
                    string path = tb_direction.Text;
                    string path1 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/adsb_v21_bcn.ast"; // CAT21
                    string path2 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/smr_160510-lebl-220001.ast"; // SMR
                    string path3 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/mlat_160510-lebl-220001.ast"; // MLAT
                    string path4 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/smr_mlat_160510-lebl-220001.ast"; // SMR + MLAT;

                    Fichero newfichero = new Fichero(path);
                    newfichero.leer();

                    listaCAT21 = newfichero.GetListCAT21(); // devuelve lista de clases CAT21, cada una con un paquete
                    listaCAT20 = newfichero.GetListCAT20();
                    listaCAT10 = newfichero.getListCAT10();

                    panelFondo.Visible = true;
                    btTables.BackColor = SystemColors.ActiveCaption;

                    btCAT10.Visible = true;
                    btCAT20.Visible = true;
                    btCAT21.Visible = true;

                    if (listaCAT10.Count > 0)
                    {
                        btCAT10.BackColor = SystemColors.ActiveCaption;
                    }
                    if (listaCAT20.Count > 0)
                    {
                        btCAT20.BackColor = SystemColors.ActiveCaption;
                    }
                    if (listaCAT21.Count > 0) 
                    {
                        btCAT21.BackColor = SystemColors.ActiveCaption;
                    }

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

        private void panelTableCAT21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btCAT21_Click(object sender, EventArgs e)
        {
            panelTablaCAT21.Visible = true;
            panelTablaCAT10.Visible = false;
            panelTablaCAT21.BackColor = SystemColors.ActiveCaption;

            int i = 0;
            while (i < 50 && i<listaCAT21.Count)
            {
                int n = dgvCAT21.Rows.Add();

                dgvCAT21.Rows[n].Cells[0].Value = i+1;
                dgvCAT21.Rows[n].Cells[1].Value = String.Concat(listaCAT21[i].SAC,"/", listaCAT21[i].SIC);
                dgvCAT21.Rows[n].Cells[2].Value = "Click Here for more information.";
                dgvCAT21.Rows[n].Cells[3].Value = listaCAT21[i].TrackNumber_number;
                dgvCAT21.Rows[n].Cells[4].Value = listaCAT21[i].TimeofApplicability_Position_seconds;
                dgvCAT21.Rows[n].Cells[5].Value = String.Concat(listaCAT21[i].latWGS84.ToString(),"/", listaCAT21[i].lonWGS84.ToString());
                dgvCAT21.Rows[n].Cells[6].Value = String.Concat(listaCAT21[i].latWGS84_HR.ToString(), "/", listaCAT21[i].lonWGS84_HR.ToString());

                i = i + 1;
            }

        }

        private void btCAT10_Click(object sender, EventArgs e)
        {
            panelTablaCAT21.Visible = true;
            panelTablaCAT10.Visible = true;
            panelTablaCAT10.BackColor = SystemColors.ActiveCaption;

            int i = 0;
            while (i < 50 && i<listaCAT10.Count)
            {
                int n = dgvCAT10.Rows.Add();

                dgvCAT10.Rows[n].Cells[0].Value = i + 1;
                dgvCAT10.Rows[n].Cells[1].Value = String.Concat(listaCAT10[i].SAC, "/", listaCAT10[i].SIC);
                dgvCAT10.Rows[n].Cells[2].Value = listaCAT10[i].MessageType_decodified;
                dgvCAT10.Rows[n].Cells[3].Value = "Click Here for more information.";
                dgvCAT10.Rows[n].Cells[4].Value = listaCAT10[i].TimeofDay_seconds;
                dgvCAT10.Rows[n].Cells[5].Value = String.Concat(listaCAT10[i].latWGS84.ToString(), "/", listaCAT10[i].lonWGS84.ToString());
                dgvCAT10.Rows[n].Cells[6].Value = String.Concat(listaCAT10[i].Rho.ToString(), "/", listaCAT10[i].Theta.ToString());
                dgvCAT10.Rows[n].Cells[7].Value = String.Concat(listaCAT10[i].X_cartesian.ToString(), "/", listaCAT10[i].Y_cartesian.ToString());

                i = i + 1;
            }
        }
    }
}
    