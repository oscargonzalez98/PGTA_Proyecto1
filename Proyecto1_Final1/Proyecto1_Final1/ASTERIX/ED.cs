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

        public List<string> listanombres = new List<string>();
        public List<int> lista_paquetes_precisión = new List<int>();

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
            else { db1 = listasecondsMLAT.Min(); }

            if (listasecondsCAT21.Count == 0) { db2 = 10e6; }
            else { db2 = listasecondsCAT21.Min(); }

            secondCounterInicial = new[] { db1, db2 }.Min();

            if (listasecondsMLAT.Count == 0) { db1 = 0; }
            else { db1 = listasecondsMLAT.Max(); }

            if (listasecondsCAT21.Count == 0) { db2 = 0; }
            else { db2 = listasecondsCAT21.Max(); }

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

            // Calculamos todos los nombres MLAT que hay para hacer la progress bar

            i = 0;
            while(i<listaMLAT.Count)
            {
                string name = listaMLAT[i].TargetAdress_decoded;
                if(listanombres.Contains(name) == false && name!="")
                {
                    listanombres.Add(name);
                }
                i = i + 1;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<CAT21> listaCAT21TransponderV2 = new List<CAT21>();
            List<double> listadistancias = new List<double>();

            double contador_bien = 0;
            double contador_total = 0;

            int k = 0;
            while(k<listaCAT21.Count)
            {
                if(listaCAT21[k].VN == "ED102A/DO-260B [Ref. 11]." && listaCAT21[k].QualityIndicators.Length>8)
                {
                    listaCAT21TransponderV2.Add(listaCAT21[k]);
                }
                k = k + 1;
            }
              
            pb_PrecissionAccuracy.Maximum = listaCAT21TransponderV2.Count;
            pb_PrecissionAccuracy.Value = 0;

            int i = 0;
            k = 0;
            while (i<listaCAT21TransponderV2.Count)
            {
                // Declaro las variables a usar que canvian para cada paqueteCAT21

                string TI_CAT21 = "";
                string TA_CAT21 = "";
                double timeCAT21=0;

                int posición = 0;
                double diferenciadetiempo = 1e6;

                if (listaCAT21TransponderV2[i].TargetIdentification.Length > 0) { TI_CAT21 = listaCAT21TransponderV2[i].TargetIdentification_decoded; }
                if (listaCAT21TransponderV2[i].TargetAddress_bin.Length > 0) { TA_CAT21 = listaCAT21TransponderV2[i].TargetAdress_real; }
                if (listaCAT21TransponderV2[i].TimeofASTERIXReportTransmission.Length > 0) { timeCAT21 = listaCAT21TransponderV2[i].TimeofASTERIXReportTransmission_seconds; }

                if((TI_CAT21.Length>0 && timeCAT21> 0) || (TA_CAT21.Length > 0 && timeCAT21 > 0))
                {
                    int j = k;
                    while (listaMLAT[j].TimeofDay_seconds<= (timeCAT21+2) && j<(listaMLAT.Count-1))
                    {
                        string TI_MLAT = "";
                        string TA_MLAT = "";
                        double timeMLAT = 0;

                        if (listaMLAT[j].TargetIdentification.Length > 0) { TI_MLAT = listaMLAT[j].TargetIdentification_decoded; }
                        if (listaMLAT[j].TargetAdress_decoded.Length > 0) { TA_MLAT = listaMLAT[j].TargetAdress_decoded; }
                        if (listaMLAT[j].TimeofDay.Length > 0) { timeMLAT = listaMLAT[j].TimeofDay_seconds; }

                        if ((TI_MLAT.Length > 0 && timeMLAT > 0) || (TA_MLAT.Length > 0 && timeMLAT >= 0)) // si tiene info de Target Addres o Target identification ytiempo
                        {
                            double time = Math.Abs(timeCAT21 - timeMLAT);

                            if ( time < diferenciadetiempo && TI_CAT21 == TI_MLAT) // si target address o target ident coinciden con TA o TI de CAT21
                            {
                                diferenciadetiempo = timeMLAT - timeCAT21;
                                if (Math.Abs(time) > 1) { diferenciadetiempo = 1e6; }
                                posición = j;
                            }

                            else if(time < diferenciadetiempo && TA_CAT21 == TA_MLAT)
                            {
                                diferenciadetiempo = timeMLAT - timeCAT21;
                                if (Math.Abs(time) > 1) { diferenciadetiempo = 1e6; }
                                posición = j;
                            }
                        }
                        j = j + 1;
                    }

                    k = posición + 1;

                    double[] coord_inicial = new double[2];
                    coord_inicial[0] = latARP;
                    coord_inicial[1] = lonARP;


                    double distanciaMLAT = 0;
                    double distanciaCAT21 = 0;
                    double distanciaCAT21vsMLAT = 0;

                    if (diferenciadetiempo == 0 && listaMLAT[posición].CalculatedTrackVelocityinCartesianCoordinates.Length>0 && diferenciadetiempo != 1e6)
                    {
                        double rho = Math.Sqrt((listaMLAT[posición].X_cartesian) * (listaMLAT[posición].X_cartesian) + (listaMLAT[posición].Y_cartesian) * (listaMLAT[posición].Y_cartesian));
                        double theta = (180 / Math.PI) * Math.Atan2(listaMLAT[posición].X_cartesian, listaMLAT[posición].Y_cartesian);

                        double[] coord_inicialess = new double[2];
                        coord_inicialess[0] = LatMLAT;
                        coord_inicialess[1] = LonMLAT;

                        double[] newcoord = NewCoordinatesMLAT(rho,theta);

                        if(listaCAT21[i].PositioninWGS_coordinates.Length>0)
                        {
                            double[] ARPcoord = new double[2];
                            ARPcoord[0] = latARP;
                            ARPcoord[1] = lonARP;

                            double[] CAT21coord = new double[2];
                            CAT21coord[0] = listaCAT21TransponderV2[i].latWGS84;
                            CAT21coord[1] = listaCAT21TransponderV2[i].lonWGS84;

                            distanciaMLAT = CalculateDistanceBetweenCoordinates(ARPcoord, newcoord);
                            distanciaCAT21 = CalculateDistanceBetweenCoordinates(ARPcoord, CAT21coord);

                            if(distanciaMLAT < 1852*10 && distanciaCAT21 < 1852*10)
                            {
                                distanciaCAT21vsMLAT = CalculateDistanceBetweenCoordinates(CAT21coord, newcoord);
                                listadistancias.Add(distanciaCAT21vsMLAT);
                            }
                        }

                        else if(listaCAT21TransponderV2[i].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            double[] ARPcoord = new double[2];
                            ARPcoord[0] = latARP;
                            ARPcoord[1] = lonARP;

                            double[] CAT21coord = new double[2];
                            CAT21coord[0] = listaCAT21TransponderV2[i].latWGS84_HR;
                            CAT21coord[1] = listaCAT21TransponderV2[i].lonWGS84_HR;

                            distanciaMLAT = CalculateDistanceBetweenCoordinates(ARPcoord, newcoord);
                            distanciaCAT21 = CalculateDistanceBetweenCoordinates(ARPcoord, CAT21coord);

                            if (distanciaMLAT < 1852 * 10 && distanciaCAT21 < 1852 * 10)
                            {
                                distanciaCAT21vsMLAT = CalculateDistanceBetweenCoordinates(CAT21coord, newcoord);
                                listadistancias.Add(distanciaCAT21vsMLAT);
                            }
                        }
                    }

                    if (diferenciadetiempo > 0 && listaMLAT[posición].CalculatedTrackVelocityinCartesianCoordinates.Length > 0 && diferenciadetiempo != 1e6)
                    {
                        double[] coord_inicialess = new double[2];
                        coord_inicialess[0] = LatMLAT;
                        coord_inicialess[1] = LonMLAT;

                        double X_real = listaMLAT[posición].X_cartesian - listaMLAT[posición].Vx_cartesian * Math.Abs(diferenciadetiempo);
                        double Y_real = listaMLAT[posición].Y_cartesian - listaMLAT[posición].Vy_cartesian * Math.Abs(diferenciadetiempo);

                        double rho = Math.Sqrt((X_real) * (X_real) + (Y_real) * (Y_real));
                        double theta = (180 / Math.PI) * Math.Atan2(listaMLAT[posición].X_cartesian, listaMLAT[posición].Y_cartesian);

                        double[] newcoord = NewCoordinatesMLAT(rho, theta);
                        if (listaCAT21TransponderV2[i].PositioninWGS_coordinates.Length > 0)
                        {
                            double[] ARPcoord = new double[2];
                            ARPcoord[0] = latARP;
                            ARPcoord[1] = lonARP;

                            double[] CAT21coord = new double[2];
                            CAT21coord[0] = listaCAT21TransponderV2[i].latWGS84;
                            CAT21coord[1] = listaCAT21TransponderV2[i].lonWGS84;

                            distanciaMLAT = CalculateDistanceBetweenCoordinates(ARPcoord, newcoord);
                            distanciaCAT21 = CalculateDistanceBetweenCoordinates(ARPcoord, CAT21coord);

                            if (distanciaMLAT < 1852 * 10 && distanciaCAT21 < 1852 * 10)
                            {
                                distanciaCAT21vsMLAT = CalculateDistanceBetweenCoordinates(CAT21coord, newcoord);
                                listadistancias.Add(distanciaCAT21vsMLAT);
                            }
                        }

                        else if (listaCAT21TransponderV2[i].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            double[] ARPcoord = new double[2];
                            ARPcoord[0] = latARP;
                            ARPcoord[1] = lonARP;

                            double[] CAT21coord = new double[2];
                            CAT21coord[0] = listaCAT21TransponderV2[i].latWGS84_HR;
                            CAT21coord[1] = listaCAT21TransponderV2[i].lonWGS84_HR;

                            distanciaMLAT = CalculateDistanceBetweenCoordinates(ARPcoord, newcoord);
                            distanciaCAT21 = CalculateDistanceBetweenCoordinates(ARPcoord, CAT21coord);

                            if (distanciaMLAT < 1852 * 10 && distanciaCAT21 < 1852 * 10)
                            {
                                distanciaCAT21vsMLAT = CalculateDistanceBetweenCoordinates(CAT21coord, newcoord);
                                listadistancias.Add(distanciaCAT21vsMLAT);
                            }
                        }
                    }

                    if (diferenciadetiempo < 0 && listaMLAT[posición].CalculatedTrackVelocityinCartesianCoordinates.Length > 0 && diferenciadetiempo != 1e6)
                    {
                        double[] coord_inicialess = new double[2];
                        coord_inicialess[0] = LatMLAT;
                        coord_inicialess[1] = LonMLAT;

                        double X_real = listaMLAT[posición].X_cartesian + listaMLAT[posición].Vx_cartesian * Math.Abs(diferenciadetiempo);
                        double Y_real = listaMLAT[posición].Y_cartesian + listaMLAT[posición].Vy_cartesian * Math.Abs(diferenciadetiempo);

                        double rho = Math.Sqrt((X_real) * (X_real) + (Y_real) * (Y_real));
                        double theta = (180 / Math.PI) * Math.Atan2(listaMLAT[posición].X_cartesian, listaMLAT[posición].Y_cartesian);

                        double[] newcoord = NewCoordinatesMLAT(rho, theta);
                        if (listaCAT21TransponderV2[i].PositioninWGS_coordinates.Length > 0)
                        {
                            double[] ARPcoord = new double[2];
                            ARPcoord[0] = latARP;
                            ARPcoord[1] = lonARP;

                            double[] CAT21coord = new double[2];
                            CAT21coord[0] = listaCAT21TransponderV2[i].latWGS84;
                            CAT21coord[1] = listaCAT21TransponderV2[i].lonWGS84;

                            distanciaMLAT = CalculateDistanceBetweenCoordinates(ARPcoord, newcoord);
                            distanciaCAT21 = CalculateDistanceBetweenCoordinates(ARPcoord, CAT21coord);

                            if (distanciaMLAT < 1852 * 10 && distanciaCAT21 < 1852 * 10)
                            {
                                distanciaCAT21vsMLAT = CalculateDistanceBetweenCoordinates(CAT21coord, newcoord);
                                listadistancias.Add(distanciaCAT21vsMLAT);
                            }
                        }

                        else if (listaCAT21TransponderV2[i].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            double[] ARPcoord = new double[2];
                            ARPcoord[0] = latARP;
                            ARPcoord[1] = lonARP;

                            double[] CAT21coord = new double[2];
                            CAT21coord[0] = listaCAT21TransponderV2[i].latWGS84_HR;
                            CAT21coord[1] = listaCAT21TransponderV2[i].lonWGS84_HR;

                            distanciaMLAT = CalculateDistanceBetweenCoordinates(ARPcoord, newcoord);
                            distanciaCAT21 = CalculateDistanceBetweenCoordinates(ARPcoord, CAT21coord);

                            if (distanciaMLAT < 1852 * 10 && distanciaCAT21 < 1852 * 10)
                            {
                                distanciaCAT21vsMLAT = CalculateDistanceBetweenCoordinates(CAT21coord, newcoord);
                                listadistancias.Add(distanciaCAT21vsMLAT);
                            }
                        }
                    }

                    if(listaCAT21TransponderV2[i].NACp == 0 && distanciaCAT21vsMLAT>18520)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if(listaCAT21TransponderV2[i].NACp == 1 && distanciaCAT21vsMLAT < 18520)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 2 && distanciaCAT21vsMLAT < 7408)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 3 && distanciaCAT21vsMLAT < 3704)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }
                    else if (listaCAT21TransponderV2[i].NACp == 4 && distanciaCAT21vsMLAT < 1852)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 5 && distanciaCAT21vsMLAT < 926)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 6 && distanciaCAT21vsMLAT < 555.6)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 7 && distanciaCAT21vsMLAT < 185.2)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 8 && distanciaCAT21vsMLAT < 92.6)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 9 && distanciaCAT21vsMLAT < 30)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 10 && distanciaCAT21vsMLAT < 10)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }

                    else if (listaCAT21TransponderV2[i].NACp == 11 && distanciaCAT21vsMLAT < 3)
                    {
                        contador_bien = contador_bien + 1;
                        contador_total = contador_total + 1;
                    }
                    else
                    {
                        contador_total = contador_total + 1;
                    }
                }

                pb_PrecissionAccuracy.Value = pb_PrecissionAccuracy.Value + 1;

                i = i + 1;
            }

            listadistancias.Sort();

            lb_meandistance.Text = Convert.ToString(Math.Round(listadistancias.Sum() / Convert.ToDouble(listadistancias.Count),3)) + " m";
            lb_meandistance.Visible = true;

            double position = (listadistancias.Count + 1) * 0.95;
            int position_mas = Convert.ToInt32(Math.Ceiling(position+1));
            int position_menos = Convert.ToInt32(Math.Floor(position+1));

            lb_95percentile.Text = Math.Round((Convert.ToDouble(listadistancias[position_mas]) + Convert.ToDouble(listadistancias[position_menos]))/2,3).ToString() + " m";
            lb_95percentile.Visible = true;

            lb_PA.Text = Math.Round((contador_bien / contador_total) * 100, 3).ToString() + " %";
            lb_PA.Visible = true;

            int a = 0;
        }

        private void lb_ProbabilityofUpdate_Click(object sender, EventArgs e)
        {
            pb_probabilityofupdate.Maximum =listanombres.Count;
            pb_probabilityofupdate.Value = 0;

            List<string> aviones_mal = new List<string>();

            int i = 0;
            while(i<listanombres.Count) // Bucle que vaya avion por avion
            {
                // primero sacamosel nombre de ese avion
                string nombre = listanombres[i];

                //Ahora sacamos su segundo maximo y su segundo minimo de ese avion
                var lista_seconds_de_este_avion = CalculateListaSecondsMLATporNombre(nombre);

                double secondinicial = lista_seconds_de_este_avion.Min();
                double secondfinal = lista_seconds_de_este_avion.Max();
                double secondactual = lista_seconds_de_este_avion[1];

                int counter_bien = 0;
                int counter_total = 0;

                //Bucle que pase pr todos los segundos y compruebe que entre un mensaje y otro hay 1 seg como max
                int j = 1;
                while(j< lista_seconds_de_este_avion.Count)
                {
                    if(lista_seconds_de_este_avion[j] - lista_seconds_de_este_avion[j-1]<=1)
                    {
                        counter_bien = counter_bien + 1;
                    }
                    j = j + 1;
                    counter_total = counter_total + 1;
                }

                if (Convert.ToDouble(counter_bien) / Convert.ToDouble(counter_total) < 0.95) { aviones_mal.Add(nombre); }
                i = i + 1;
                pb_probabilityofupdate.Value = pb_probabilityofupdate.Value + 1;
            }

            i = 0;

            lb_aviones_mal.Text = "Target Address: ";
            while(i<aviones_mal.Count)
            {
                lb_aviones_mal.Visible = true;
                lb_aviones_mal.Text = "     " + lb_aviones_mal.Text + aviones_mal[i] + ". ";
                i = i + 1;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            pb_ProbDetect.Maximum = listanombres.Count;
            pb_ProbDetect.Value = 0;

            List<double> lista_porcentajes = new List<double>();
            List<double> lista_secgundos_utiles = new List<double>();

            int i = 0;
            while (i < listanombres.Count)
            {
                lista_secgundos_utiles.Clear();
                int j = 0;
                while(j<listaMLAT.Count)
                {
                    if(listaMLAT[j].GBS == "Transponder Ground bit not set." && listaMLAT[j].TargetAdress.Length>0 && listaMLAT[j].TargetAdress_decoded == listanombres[i])
                    {
                        lista_secgundos_utiles.Add(listaMLAT[j].TimeofDay_seconds);
                        lista_paquetes_precisión.Add(j);
                    }
                    j = j + 1;
                }

                double counter_bien = 0;
                double counter_total = 0;

                lista_secgundos_utiles.Sort();
                int k = 1;
                while(k<lista_secgundos_utiles.Count)
                {
                    if((lista_secgundos_utiles[k] - lista_secgundos_utiles[k-1])<2)
                    {
                        counter_bien = counter_bien + 1;
                        counter_total = counter_total + 1;
                    }

                    else
                    {
                        counter_total = counter_total + 1;
                    }
                    k = k + 1;
                }

                double porcentaje = (counter_bien / lista_secgundos_utiles.Count) * 100;
                if(counter_bien !=0 && counter_total !=0) { lista_porcentajes.Add(porcentaje); }


                i = i + 1;
                pb_ProbDetect.Value = pb_ProbDetect.Value + 1;
            }

            double mean = (Convert.ToDouble(lista_porcentajes.Sum()) / lista_porcentajes.Count);
            lb_PD.Visible = true;
            lb_PD.Text = Math.Round(mean, 3) + " %";
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

        public List<double> CalculateListaSecondsMLATporNombre(string nombre)
        {
            int i = 0;

            List<double> lista = new List<double>();
            List<double> listaquedevolvemos = new List<double>();
             
            while(i<listaMLAT.Count)
            {
                if(listaMLAT[i].TYP == "Mode S multilateration.")
                {
                    lista.Add(listaMLAT[i].TimeofDay_seconds);
                }
                i = i + 1;
            }

            double sec = lista.Min(); ;
            listaquedevolvemos.Add(sec);

            i = 0;
            while (i < listaMLAT.Count)
            {
                double second = listaMLAT[i].TimeofDay_seconds;
                if (second > listasecondsMLAT.Last() && listaMLAT[i].TargetAdress.Length>0 && listaMLAT[i].TargetAdress_decoded == nombre)
                {
                    listaquedevolvemos.Add(second);
                }
                i = i + 1;
            }

            return listaquedevolvemos;

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

        public List<int> VuelosMLATAhoraporNombre(double second,string nombre)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaMLAT.Count)
            {
                if ((Math.Floor(listaMLAT[j].TimeofDay_seconds)) == second && listaMLAT[j].TOT != "Ground Vehicle." && listaMLAT[j].Mode3ACodeinOctal.Length >= 0 && listaMLAT[j].TargetAdress.Length>0 && listaMLAT[j].TargetAdress_decoded == nombre)
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
