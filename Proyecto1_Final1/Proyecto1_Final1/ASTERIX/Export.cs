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
using System.IO;


namespace ASTERIX
{
    public partial class Export : Form
    {
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        List<string> listaNombresCAT21v23 = new List<string>();
        List<string> listaNombresCAT21 = new List<string>();

        public Export(List<CAT10> listaCAT10, List<CAT21> listaCAT21, List<CAT21v23> listaCAT21v23)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT21 = listaCAT21;
            this.listaCAT21v23 = listaCAT21v23;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Generamos el nuevo documento
            // Generamos el nuevo documento
            StreamWriter f = File.CreateText(tb_direction.Text);

            // Leemos las partes del documento 
            string[] startinglines = File.ReadAllLines("docs/start.txt");
            string[] blue_style = File.ReadAllLines("docs/1Blue_style.txt");
            string[] green_style = File.ReadAllLines("docs/1Green_style.txt");
            string[] red_style = File.ReadAllLines("docs/1Red_style.txt");
            string[] white_style = File.ReadAllLines("docs/1White_style.txt");
            string[] body = File.ReadAllLines("docs/body.txt");


            f.WriteLine(startinglines[0]);
            f.WriteLine(startinglines[1]);
            f.WriteLine(startinglines[2]);
            f.WriteLine(startinglines[3]);

            f.WriteLine(blue_style[0]);
            f.WriteLine(blue_style[1]);
            f.WriteLine(blue_style[2]);
            f.WriteLine(blue_style[3]);
            f.WriteLine(blue_style[4]);
            f.WriteLine(blue_style[5]);
            f.WriteLine(blue_style[6]);
            f.WriteLine(blue_style[7]);
            f.WriteLine(blue_style[8]);

            f.WriteLine(green_style[0]);
            f.WriteLine(green_style[1]);
            f.WriteLine(green_style[2]);
            f.WriteLine(green_style[3]);
            f.WriteLine(green_style[4]);
            f.WriteLine(green_style[5]);
            f.WriteLine(green_style[6]);
            f.WriteLine(green_style[7]);
            f.WriteLine(green_style[8]);

            f.WriteLine(red_style[0]);
            f.WriteLine(red_style[1]);
            f.WriteLine(red_style[2]);
            f.WriteLine(red_style[3]);
            f.WriteLine(red_style[4]);
            f.WriteLine(red_style[5]);
            f.WriteLine(red_style[6]);
            f.WriteLine(red_style[7]);
            f.WriteLine(red_style[8]);

            f.WriteLine(white_style[0]);
            f.WriteLine(white_style[1]);
            f.WriteLine(white_style[2]);
            f.WriteLine(white_style[3]);
            f.WriteLine(white_style[4]);
            f.WriteLine(white_style[5]);
            f.WriteLine(white_style[6]);
            f.WriteLine(white_style[7]);
            f.WriteLine(white_style[8]);

            f.WriteLine(body[0]);

            //Codigo para plotear todos los aviones
            //......................................................................................................................

            //Lo hacemos una vez para el primer avion

            if(listaCAT21v23.Count>0)
            {
                string Nombre1 = listaCAT21v23[0].TargetIdentification_decoded;
                listaNombresCAT21v23.Add(Nombre1);

                f.WriteLine("\t\t<name>" + Nombre1 + "</name>");
                f.WriteLine("\t\t <styleUrl>#" + "red" + "</styleUrl>");
                f.WriteLine(body[3]);
                f.WriteLine("\t\t\t<coordinates>");

                int i = 0;
                while (i < listaCAT21v23.Count)
                {
                    if (listaCAT21v23[i].TargetIdentification_decoded == Nombre1)
                    {
                        string latWGS84 = listaCAT21v23[i].latWGS84.ToString();
                        string lonWGS84 = listaCAT21v23[i].lonWGS84.ToString();

                        latWGS84 = latWGS84.Replace(",", ".");
                        lonWGS84 = lonWGS84.Replace(",", ".");

                        f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84);
                    }
                    i = i + 1;
                }

                f.WriteLine("\t\t\t</coordinates>");
                f.WriteLine("\t\t</LineString>");
                f.WriteLine("\t</Placemark>");

                List<double> lat = new List<double>();
                List<double> lon = new List<double>();

                //Ahora lo hacemos para el resto
                i = 1;
                while (i < listaCAT21v23.Count)
                {
                    string Nombre = listaCAT21v23[i].TargetIdentification_decoded;

                    if (listaNombresCAT21v23.Contains(Nombre) == true && Nombre != "") // si numero esta ern la lista quiere decir que ya lo hemos dibujado y pasamos al siguiente nombre
                    {
                    }

                    if (listaNombresCAT21v23.Contains(Nombre) == false && Nombre != "") // Si el numero no esta en la lista tenemos que dinujarlo
                    {
                        listaNombresCAT21v23.Add(Nombre);

                        if (Nombre == "IBK5503")
                        {
                        }

                        f.WriteLine("\t<Placemark>");
                        f.WriteLine("\t\t<name>" + Nombre + "</name>");
                        f.WriteLine("\t\t <styleUrl>#" + "red" + "</styleUrl>");
                        f.WriteLine(body[3]);
                        f.WriteLine("\t\t\t<coordinates>");

                        int j = 0;
                        while (j < listaCAT21v23.Count)
                        {
                            if (listaCAT21v23[j].TargetIdentification_decoded == Nombre)
                            {
                                string latWGS84 = listaCAT21v23[j].latWGS84.ToString();
                                string lonWGS84 = listaCAT21v23[j].lonWGS84.ToString();

                                latWGS84 = latWGS84.Replace(",", ".");
                                lonWGS84 = lonWGS84.Replace(",", ".");

                                f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84);

                                if (Nombre == "RYR64JR")
                                {
                                    lat.Add(Convert.ToDouble(latWGS84.Replace(".", ",")));
                                    lon.Add(Convert.ToDouble(lonWGS84.Replace(".", ",")));
                                }
                            }
                            j = j + 1;
                        }

                        f.WriteLine("\t\t\t</coordinates>");
                        f.WriteLine("\t\t</LineString>");
                        f.WriteLine("\t</Placemark>");
                    }

                    i = i + 1;
                }

                double a = lat.Max();
                double b = lat.Min();
                double c = lon.Max();
                double d = lon.Min();
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------

            if(listaCAT21.Count>0)
            {
                string Nombre1 = listaCAT21[0].TargetIdentification_decoded;
                listaNombresCAT21.Add(Nombre1);

                f.WriteLine("\t\t<name>" + Nombre1 + "</name>");
                f.WriteLine("\t\t <styleUrl>#" + "green" + "</styleUrl>");
                f.WriteLine(body[3]);
                f.WriteLine("\t\t\t<coordinates>");

                int i = 0;
                while (i < listaCAT21.Count)
                {
                    if (listaCAT21[i].TargetIdentification_decoded == Nombre1)
                    {
                        string latWGS84 = listaCAT21[i].latWGS84.ToString();
                        string lonWGS84 = listaCAT21[i].lonWGS84.ToString();

                        latWGS84 = latWGS84.Replace(",", ".");
                        lonWGS84 = lonWGS84.Replace(",", ".");

                        f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84);
                    }
                    i = i + 1;
                }

                f.WriteLine("\t\t\t</coordinates>");
                f.WriteLine("\t\t</LineString>");
                f.WriteLine("\t</Placemark>");

                //Ahora lo hacemos para el resto
                i = 1;
                while (i < listaCAT21.Count)
                {
                    string Nombre = listaCAT21[i].TargetIdentification_decoded;

                    if (listaNombresCAT21.Contains(Nombre) == true && Nombre != "") // si numero esta ern la lista quiere decir que ya lo hemos dibujado y pasamos al siguiente nombre
                    {
                    }

                    if (listaNombresCAT21.Contains(Nombre) == false && Nombre != "") // Si el numero no esta en la lista tenemos que dinujarlo
                    {
                        listaNombresCAT21.Add(Nombre);

                        if (Nombre == "IBK5503")
                        {
                        }

                        f.WriteLine("\t<Placemark>");
                        f.WriteLine("\t\t<name>" + Nombre + "</name>");
                        f.WriteLine("\t\t <styleUrl>#" + "green" + "</styleUrl>");
                        f.WriteLine(body[3]);
                        f.WriteLine("\t\t\t<coordinates>");

                        int j = 0;
                        while (j < listaCAT21.Count)
                        {
                            if (listaCAT21[j].TargetIdentification_decoded == Nombre)
                            {
                                string latWGS84 = listaCAT21[j].latWGS84.ToString();
                                string lonWGS84 = listaCAT21[j].lonWGS84.ToString();

                                latWGS84 = latWGS84.Replace(",", ".");
                                lonWGS84 = lonWGS84.Replace(",", ".");

                                f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84);
                            }
                            j = j + 1;
                        }

                        f.WriteLine("\t\t\t</coordinates>");
                        f.WriteLine("\t\t</LineString>");
                        f.WriteLine("\t</Placemark>");
                    }

                    i = i + 1;
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------

            f.WriteLine(" </Document> </kml>");
            f.Close();

        }

        private void textBoxtb_direction_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_Browse_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string direccion = saveFileDialog1.FileName;
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

                tb_direction.Text = direccion.Replace(char1, char2);
            }


        }

    }
}
