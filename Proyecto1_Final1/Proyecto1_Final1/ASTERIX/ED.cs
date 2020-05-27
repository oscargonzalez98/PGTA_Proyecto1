using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;
using LIBRERIACLASES;

namespace ASTERIX
{
    public partial class ED : Form
    {
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT21> listaCAT21 = new List<CAT21>();

        List<CAT10> listaMLAT = new List<CAT10>();
        List<CAT10> listaSMR = new List<CAT10>();

        //Listas de Aviones en cada segundo por categoria
        List<double> listasecondsMLAT = new List<double>(); // lista de segundos en los que se envia un paquete de la categoria CAT10
        List<List<int>> lista_listavionesCAT10 = new List<List<int>>(); // lista de paquetes CAT10 que hay en cada segundo de la lista de segundos CAT10

        List<double> listasecondsCAT21 = new List<double>(); // lista de segundos en los que se envia un paquete de la categoria CAT21
        List<List<int>> lista_listavionesCAT21 = new List<List<int>>(); // lista de paquetes CAT21 que hay en cada segundo de la lista de segundos CAT21

        public double secondCounter;
        public double secondCounterInicial;
        public double secondCounterFinal;

        // Coordenadas MLAT
        double LatMLAT = 41.297063;
        double LonMLAT = 2.078447;

        //CoordenadasARP
        double latARP = 41.1749;
        double lonARP = 02.0442;
        double[] coord_ARP = new double[2];

        public ED(List<CAT10> listaCAT10, List<CAT21> listaCAT21)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT21 = listaCAT21;
        }

        private void EDcs_Load(object sender, EventArgs e)
        {
            //Definimos Coordenadas ARP
            coord_ARP[0] = latARP;
            coord_ARP[1] = lonARP;

            //Cargamos vectores tiempo

            if (listaCAT10.Count > 0) { CalculateListaSecondsMLAT(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT10
            if (listaCAT21.Count > 0) { CalculateListaSecondsCAT21(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21

            // Establecemos el primer segundo como el minimo de los 3.
            double db1;
            double db2;

            if (listasecondsMLAT.Count == 0) { db1 = 10e6; }
            else { db1 = listasecondsMLAT.First(); }

            if (listasecondsCAT21.Count == 0) { db2 = 10e6; }
            else { db2 = listasecondsCAT21.First(); }

            secondCounterInicial = new[] { db1, db2 }.Min();

            if (listasecondsMLAT.Count == 0) { db1 = 0; }
            else { db1 = listasecondsMLAT.Last(); }

            if (listasecondsCAT21.Count == 0) { db2 = 0; }
            else { db2 = listasecondsCAT21.Last(); }

            secondCounterFinal = new[] { db1, db2 }.Max();

            // Definimos valor inicial del contador contador

            secondCounter = secondCounterInicial;

            // separamos listaCAT10 en listaMLAT y listaSMR;
            int i = 0;
            while(i<listaCAT10.Count)
            {
                int SAC = listaCAT10[i].SAC;
                int SIC = listaCAT10[i].SIC;

                if(SAC == 0 && SIC == 7)
                {
                    listaSMR.Add(listaCAT10[i]);
                }
                if(SAC == 0 && SIC == 107)
                {
                    listaMLAT.Add(listaCAT10[i]);
                }
                i = i + 1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pb_PrecissionAccuracy.Maximum = Convert.ToInt32(secondCounterFinal - secondCounterInicial);
            pb_PrecissionAccuracy.Value = 0;

            List<double> lista_distancias = new List<double>();

            if(listaCAT10.Count > 0 && listaCAT21.Count > 0) // Si en el .AST hay CAT10 y CAT21
            {
                int i = 0;//recorre todos los segundos
                while (secondCounter < secondCounterFinal) // Mientras no hayamos hecho todos los segunds
                {
                    List<int> vuelosMLAT = VuelosMLATAhora(secondCounter); // Lista de vuelos en CAT10 con ese tiempo
                    List<int> vuelosCAT21 = VuelosCAT21Ahora(secondCounter); // Lista de vuelos en CAT21 con ese tiempo

                    int j = 0;//recorre los vuelos CAT21
                    while (j < vuelosCAT21.Count) // Recorremos todos los vuelos CAT21 en este segundo y los recorremos
                    {
                        int k = 0;//recorre los vuelos MLAT
                        while (k < vuelosMLAT.Count) //Recorremos tods los MLAt y cojemos solo los que tienen el mismo Target Adress o Target identification que el CAT21
                        {
                            string TIdentCAT21 = "";
                            string stringTAddr = "";
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded.Length > 0) { TIdentCAT21 = listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded; }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { stringTAddr = listaCAT21[vuelosCAT21[j]].TargetAdress_real; }

                            if ((listaMLAT[vuelosMLAT[k]].TargetIdentification_decoded == TIdentCAT21 && TIdentCAT21 != "") || (listaMLAT[vuelosMLAT[k]].TargetAdress_decoded == stringTAddr && stringTAddr != "")) // Si tienen el mismo target Add o Target ident (si son el mismo avion que el CAT21) y es diferente de ""
                            {
                                double[] coord_iniciales = new double[2];
                                if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0) { coord_iniciales[0] = listaCAT21[vuelosCAT21[j]].latWGS84_HR; coord_iniciales[1] = listaCAT21[vuelosCAT21[j]].lonWGS84_HR; }
                                else if (listaCAT21[j].PositioninWGS_coordinates.Length > 0) { coord_iniciales[0] = listaCAT21[vuelosCAT21[j]].latWGS84; coord_iniciales[1] = listaCAT21[vuelosCAT21[j]].lonWGS84; }

                                double rho = Math.Sqrt((listaCAT10[vuelosMLAT[k]].X_cartesian) * (listaCAT10[vuelosMLAT[k]].X_cartesian) + (listaCAT10[vuelosMLAT[k]].Y_cartesian) * (listaCAT10[vuelosMLAT[k]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosMLAT[k]].X_cartesian, listaCAT10[vuelosMLAT[k]].Y_cartesian);
                                double[] coord_finales = NewCoordinatesMLAT(rho, theta);

                                double distanciaADSB = CalculateDistanceBetweenCoordinates(coord_ARP, coord_finales);
                                double distanciaMLAT = CalculateDistanceBetweenCoordinates(coord_ARP, coord_finales);

                                if (distanciaADSB <= (10 * 1852) && distanciaMLAT <= (10 * 1852))
                                {
                                    double distancia = CalculateDistanceBetweenCoordinates(coord_iniciales, coord_finales)/1000 ; // en metros
                                    lista_distancias.Add(distancia);
                                }
                            }
                            k = k + 1;
                        }
                        j = j + 1;
                    }
                    i = i + 1;
                    secondCounter = secondCounter + 1;
                    pb_PrecissionAccuracy.Value = pb_PrecissionAccuracy.Value + 1;
                }
            }
            else { /* Enseñamos un error */}

            double distancia_media = lista_distancias.Sum() / lista_distancias.Count();
            lb_meandistance.Text = Math.Round(distancia_media, 3) + " m";
            lb_meandistance.Visible = true;

            lista_distancias.Sort();

            double p = lista_distancias.Count;
            lista_distancias.Reverse();

            p = p + 1;
            p = p * 0.95;
            p = p - 1;
            int p_ceil = Convert.ToInt32(Math.Ceiling(p));
            int p_floor = Convert.ToInt32(Math.Floor(p));

            double precentile95 = (lista_distancias[p_ceil] + lista_distancias[p_floor])/2;
            lb_95percentile.Text =Math.Round(precentile95, 3) + " m";
            lb_95percentile.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        //----------------------------------------------------------------------------------------------
        public double toRadians(double grados)
        {
            return grados * Math.PI / 180;
        }
        public double toDegrees(double radians)
        {
            return radians * 180 / (Math.PI);
        }

        public double CalculateDistanceBetweenCoordinates(double[] initial_coordinates, double[] final_coordinates)
        {
            double φ1 = toRadians(initial_coordinates[0]);
            double φ2 = toRadians(final_coordinates[0]);
            double λ1 = toRadians(initial_coordinates[1]);
            double λ2 = toRadians(final_coordinates[1]);

            double lat1 = φ1;
            double lon1 = λ1;
            double lat2 = φ2;
            double lon2 = λ2;

            double a = 6378137.0;
            double b = 6356752.314245;
            double f = 1 / 298.257223563;

            double L = (lon2 - lon1);
            double U1 = Math.Atan((1 - f) * Math.Tan(lat1));
            double U2 = Math.Atan((1 - f) * Math.Tan(lat2));
            double sinU1 = Math.Sin(U1),
            cosU1 = Math.Cos(U1);
            double sinU2 = Math.Sin(U2),
            cosU2 = Math.Cos(U2);

            double lambda = L, lambdaP, iterLimit = 100;

            double cosSqAlpha;
            double sinSigma;
            double cos2SigmaM;
            double cosSigma;
            double sigma;

            do
            {
                double sinLambda = Math.Sin(lambda),
                cosLambda = Math.Cos(lambda);
                sinSigma = Math.Sqrt((cosU2 * sinLambda) * (cosU2 * sinLambda) + (cosU1 * sinU2 - sinU1 * cosU2 * cosLambda) * (cosU1 * sinU2 - sinU1 * cosU2 * cosLambda));
                if (sinSigma == 0) return 0; // co-incident points
                cosSigma = sinU1 * sinU2 + cosU1 * cosU2 * cosLambda;
                sigma = Math.Atan2(sinSigma, cosSigma);
                double sinAlpha = cosU1 * cosU2 * sinLambda / sinSigma;
                cosSqAlpha = 1 - sinAlpha * sinAlpha;
                cos2SigmaM = cosSigma - 2 * sinU1 * sinU2 / cosSqAlpha;
                double C = f / 16 * cosSqAlpha * (4 + f * (4 - 3 * cosSqAlpha));
                lambdaP = lambda;
                lambda = L + (1 - C) * f * sinAlpha * (sigma + C * sinSigma * (cos2SigmaM + C * cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM)));
            } while (Math.Abs(lambda - lambdaP) > 1e-12 && --iterLimit > 0);

            var uSq = cosSqAlpha * (a * a - b * b) / (b * b);
            var A = 1 + uSq / 16384 * (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)));
            var B = uSq / 1024 * (256 + uSq * (-128 + uSq * (74 - 47 * uSq)));
            var deltaSigma = B * sinSigma * (cos2SigmaM + B / 4 * (cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM) - B / 6 * cos2SigmaM * (-3 + 4 * sinSigma * sinSigma) * (-3 + 4 * cos2SigmaM * cos2SigmaM)));
            var s = b * A * (sigma - deltaSigma);

            return s;
        }

        public double CalculateDistanceBetweenCoordinates2(double[] initial_coordinates, double[] final_coordinates)
        {
            double φ1 = toRadians(initial_coordinates[0]);
            double φ2 = toRadians(final_coordinates[0]);
            double λ1 = toRadians(initial_coordinates[1]);
            double λ2 = toRadians(final_coordinates[1]);

            double lat1 = φ1;
            double lon1 = λ1;
            double lat2 = φ2;
            double lon2 = λ2;

            double a = 6378137.0;
            double b = 6356752.314245;
            double f = 1 / 298.257223563;
            double e_sq = 1 - ((b / a) * (b / a));
            double tmp = Math.Sqrt(1 - e_sq * Math.Sin(lat1));

            double lat = lat2 - lat1;
            double lon = lon2 - lon1;

            double x = (a * lon / tmp) * (Math.Cos(lat1) - ((1 - e_sq) / (tmp * tmp)) * Math.Sin(lat1) * lat);
            double y = (a * (1 - e_sq) / (tmp * tmp * tmp)) * lat + Math.Cos(lat1) * Math.Sin(lat1) * ((3 / 2) * e_sq * lat * lat + ((lon*lon) / (2*tmp)));

            double s = Math.Sqrt(x * x + y * y);

            return s;
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

        public void CalculateListaSecondsMLAT()
        {
            listasecondsMLAT.Clear();

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT10[0].TimeofDay_seconds)));
            listasecondsMLAT.Add(sec);

            int i = 1;
            while (i < listaMLAT.Count)
            {
                int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaMLAT[i].TimeofDay_seconds)));
                if (second > listasecondsMLAT.Last())
                {
                    listasecondsMLAT.Add(second);
                }
                i = i + 1;
            }
        }
        public void CalculateListaSecondsCAT21()
        {
            listasecondsCAT21.Clear();

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21[0].TimeofASTERIXReportTransmission_seconds)));
            listasecondsCAT21.Add(sec);

            int i = 1;
            while (i < listaCAT21.Count)
            {
                int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21[i].TimeofASTERIXReportTransmission_seconds)));
                if (second > listasecondsCAT21.Last())
                {
                    listasecondsCAT21.Add(second);
                }
                i = i + 1;
            }
        }

        public List<int> VuelosMLATAhora(double second)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaMLAT.Count)
            {
                if ((Math.Floor(listaMLAT[j].TimeofDay_seconds)) == second && listaMLAT[j].TOT != "Ground Vehicle." && listaMLAT[j].Mode3ACodeinOctal.Length >= 0)
                {
                    lista.Add(j);
                }
                j = j + 1;
            }
            return lista;
        }
        public List<int> VuelosCAT21Ahora(double second)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaCAT21.Count)
            {
                if (Math.Floor(listaCAT21[j].TimeofASTERIXReportTransmission_seconds) == second && listaCAT21[j].ECAT != "Surface emergency vehicle" && listaCAT21[j].ECAT != "Surface service vehicle." && listaCAT21[j].ECAT != "Fixed ground or tethered obstruction." && listaCAT21[j].VN == "ED102A/DO-260B [Ref. 11].")
                {
                    lista.Add(j);
                }
                j = j + 1;
            }
            return lista;
        }

        private void lb_meandistance_Click(object sender, EventArgs e)
        {

        }
    }
}
