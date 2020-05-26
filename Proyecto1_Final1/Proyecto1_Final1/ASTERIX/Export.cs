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
        List<string> listaNombresCAT10 = new List<string>();

        List<CAT10> listaMLAT = new List<CAT10>();
        List<CAT10> listaSMR = new List<CAT10>();

        // CoordenadasSMR
        double LatSMR = 41.295618;
        double LonSMR = 2.095114;

        // Coordenadas MLAT
        double LatMLAT = 41.297063;
        double LonMLAT = 2.078447;

        public Export(List<CAT10> listaCAT10, List<CAT21> listaCAT21, List<CAT21v23> listaCAT21v23)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT21 = listaCAT21;
            this.listaCAT21v23 = listaCAT21v23;

            if(listaCAT10.Count>0)
            {
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
            }

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
            //...................................................................................................................... CAT21v23

            //Lo hacemos una vez para el primer avion

            if(listaCAT21v23.Count>0)
            {
                listaNombresCAT21v23.Clear();

                string Nombre1 = listaCAT21v23[0].TargetIdentification_decoded;
                listaNombresCAT21v23.Add(Nombre1);

                f.WriteLine("\t\t<name>" + Nombre1 + "</name>");
                f.WriteLine("\t\t <styleUrl>#" + "red" + "</styleUrl>");
                f.WriteLine(body[3]);
                f.WriteLine("\t\t\t<coordinates>");

                int i = 0;
                while (i < listaCAT21v23.Count)
                {
                    if (listaCAT21v23[i].TargetIdentification_decoded == Nombre1 && listaCAT21v23[i].TargetIdentification.Length>0)
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

                //Ahora lo hacemos para el resto
                i = 1;
                while (i < listaCAT21v23.Count)
                {
                    string Nombre = listaCAT21v23[i].TargetIdentification_decoded;

                    if (Nombre == "VLG1291")
                    {
                        int a = 0;
                    }

                    if (listaNombresCAT21v23.Contains(Nombre) == false && Nombre != "") // Si el numero no esta en la lista tenemos que dinujarlo
                    {
                        listaNombresCAT21v23.Add(Nombre);

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
                                double a = listaCAT21v23[j].latWGS84;
                                double b = listaCAT21v23[j].lonWGS84;

                                string latWGS84 = listaCAT21v23[j].latWGS84.ToString();
                                string lonWGS84 = listaCAT21v23[j].lonWGS84.ToString();

                                latWGS84 = latWGS84.Replace(",", ".");
                                lonWGS84 = lonWGS84.Replace(",", ".");

                                if(a != Double.NaN && b!=Double.NaN)
                                {
                                    f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84);
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
            }

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------- CAT21

            if(listaCAT21.Count>0)
            {
                listaNombresCAT21.Clear();

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
                i = 0;
                while (i < listaCAT21.Count)
                {
                    string Nombre = listaCAT21[i].TargetIdentification_decoded;

                    if (listaNombresCAT21.Contains(Nombre) == true && Nombre != "") // si numero esta ern la lista quiere decir que ya lo hemos dibujado y pasamos al siguiente nombre
                    {
                    }

                    if (listaNombresCAT21.Contains(Nombre) == false && Nombre != "") // Si el numero no esta en la lista tenemos que dinujarlo
                    {
                        listaNombresCAT21.Add(Nombre);

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

                                if(latWGS84 != "0" && lonWGS84 != "0") { f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84); }
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

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------- MLAT

            if (listaMLAT.Count > 0)
            {
                listaNombresCAT10.Count();

                int i = 0;
                while(listaMLAT[i].TargetIdentification_decoded == "") { i = i + 1; }

                string Nombre1 = listaCAT10[i].TargetIdentification_decoded;
                listaNombresCAT10.Add(Nombre1);

                f.WriteLine("\t\t<name>" + Nombre1 + "</name>");
                f.WriteLine("\t\t <styleUrl>#" + "blue" + "</styleUrl>");
                f.WriteLine(body[3]);
                f.WriteLine("\t\t\t<coordinates>");

                int j = 0;
                while (j < listaMLAT.Count)
                {
                    if (listaMLAT[j].TargetIdentification_decoded == Nombre1)
                    {
                        double rho = Math.Sqrt((listaCAT10[j].X_cartesian) * (listaCAT10[j].X_cartesian) + (listaCAT10[j].Y_cartesian) * (listaCAT10[j].Y_cartesian));
                        double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[j].X_cartesian, listaCAT10[j].Y_cartesian);
                        double[] coordenadas = NewCoordinatesMLAT(rho, theta);

                        string latWGS84 = coordenadas[0].ToString();
                        string lonWGS84 = coordenadas[1].ToString();

                        latWGS84 = latWGS84.Replace(",", ".");
                        lonWGS84 = lonWGS84.Replace(",", ".");

                        f.WriteLine("\t\t\t" + lonWGS84 + "," + latWGS84);
                    }
                    j = j + 1;
                }

                f.WriteLine("\t\t\t</coordinates>");
                f.WriteLine("\t\t</LineString>");
                f.WriteLine("\t</Placemark>");

                //Ahora lo hacemos para el resto

                while (i < listaMLAT.Count)
                {
                    string Nombre = listaMLAT[i].TargetIdentification_decoded;

                    if (listaNombresCAT10.Contains(Nombre) == true && Nombre != "") // si numero esta ern la lista quiere decir que ya lo hemos dibujado y pasamos al siguiente nombre
                    {
                    }

                    if (listaNombresCAT10.Contains(Nombre) == false && Nombre != "") // Si el numero no esta en la lista tenemos que dinujarlo
                    {
                        listaNombresCAT10.Add(Nombre);

                        f.WriteLine("\t<Placemark>");
                        f.WriteLine("\t\t<name>" + Nombre + "</name>");
                        f.WriteLine("\t\t <styleUrl>#" + "blue" + "</styleUrl>");
                        f.WriteLine(body[3]);
                        f.WriteLine("\t\t\t<coordinates>");

                        j = 0;
                        while (j < listaMLAT.Count)
                        {
                            if (listaMLAT[j].TargetIdentification_decoded == Nombre)
                            {
                                double rho = Math.Sqrt((listaCAT10[j].X_cartesian) * (listaCAT10[j].X_cartesian) + (listaCAT10[j].Y_cartesian) * (listaCAT10[j].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[j].X_cartesian, listaCAT10[j].Y_cartesian);
                                double[] coordenadas = NewCoordinatesMLAT(rho, theta);

                                string latWGS84 = coordenadas[0].ToString();
                                string lonWGS84 = coordenadas[1].ToString();

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

        public double toRadians(double grados)
        {
            return grados * Math.PI / 180;
        }
        public double toDegrees(double radians)
        {
            return radians * 180 / (Math.PI);
        }

        public double[] NewCoordinatesMLAT(double distance, double initialBearing)
        {
            double[] listaCoordenadas = new double[2];


            double φ1 = toRadians(LatMLAT);
            double λ1 = toRadians(LonMLAT);
            double α1 = toRadians(initialBearing);
            double s = distance;

            // allow alternative ellipsoid to be specified
            double a = 6378137.0;
            double b = 6356752.314245;
            double f = 1 / 298.257223563;

            double sinα1 = Math.Sin(α1);
            double cosα1 = Math.Cos(α1);

            double tanU1 = (1 - f) * Math.Tan(φ1), cosU1 = 1 / Math.Sqrt((1 + tanU1 * tanU1)), sinU1 = tanU1 * cosU1;
            double σ1 = Math.Atan2(tanU1, cosα1); // σ1 = angular distance on the sphere from the equator to P1
            double sinα = cosU1 * sinα1;          // α = azimuth of the geodesic at the equator
            double cosSqα = 1 - sinα * sinα;
            double uSq = cosSqα * (a * a - b * b) / (b * b);
            double A = 1 + uSq / 16384 * (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)));
            double B = uSq / 1024 * (256 + uSq * (-128 + uSq * (74 - 47 * uSq)));

            double σ = s / (b * A);
            double sinσ;
            double cosσ;
            double Δσ; // σ = angular distance P₁ P₂ on the sphere
            double cos2σₘ; // σₘ = angular distance on the sphere from the equator to the midpoint of the line

            double σ_prima; int iterations = 0;
            do
            {
                cos2σₘ = Math.Cos(2 * σ1 + σ);
                sinσ = Math.Sin(σ);
                cosσ = Math.Cos(σ);
                Δσ = B * sinσ * (cos2σₘ + B / 4 * (cosσ * (-1 + 2 * cos2σₘ * cos2σₘ) -
                    B / 6 * cos2σₘ * (-3 + 4 * sinσ * sinσ) * (-3 + 4 * cos2σₘ * cos2σₘ)));
                σ_prima = σ;
                σ = s / (b * A) + Δσ;
            } while (Math.Abs(σ - σ_prima) > 1e-12 && ++iterations < 100);
            //if (iterations >= 100) throw new EvalError('Vincenty formula failed to converge'); // not possible?

            double x = sinU1 * sinσ - cosU1 * cosσ * cosα1;
            double φ2 = Math.Atan2(sinU1 * cosσ + cosU1 * sinσ * cosα1, (1 - f) * Math.Sqrt(sinα * sinα + x * x));
            double λ = Math.Atan2(sinσ * sinα1, cosU1 * cosσ - sinU1 * sinσ * cosα1);
            double C = f / 16 * cosSqα * (4 + f * (4 - 3 * cosSqα));
            double L = λ - (1 - C) * f * sinα * (σ + C * sinσ * (cos2σₘ + C * cosσ * (-1 + 2 * cos2σₘ * cos2σₘ)));
            double λ2 = λ1 + L;

            double α2 = Math.Atan2(sinα, -x);

            listaCoordenadas[0] = toDegrees(φ2);
            listaCoordenadas[1] = toDegrees(λ2);

            double coord1 = φ2;
            int sec1 = (int)Math.Round(coord1 * 3600);
            int deg1 = sec1 / 3600;
            sec1 = Math.Abs(sec1 % 3600);
            int min1 = sec1 / 60;
            sec1 %= 60;

            double coord2 = λ2;
            int sec2 = (int)Math.Round(coord2 * 3600);
            int deg2 = sec2 / 3600;
            sec2 = Math.Abs(sec2 % 3600);
            int min2 = sec2 / 60;
            sec2 %= 60;


            return listaCoordenadas;
        }

    }
}
