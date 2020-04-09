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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ASTERIX
{
    public partial class PruebasMapas : Form
    {
        // variables para enviar info entre forms
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();

        // variables para rellenar listas de aviones 
        List<List<int>> lista_listaviones = new List<List<int>>();
        List<double> listaseconds = new List<double>();
        List<int> listavuelos = new List<int>();

        // variables para timer
        int counter;
        int counter_playpause_button = 0;
        double timer_speed = 1000;

        // variables para mapas en general
        public int filaseleeccionada = 0;
        public double LatInicial = 41.2969444;
        public double LongInicial = 2.0783333333333336;

        // mas variables para mapas al plotear por tiempo
        GMapOverlay markerOverLay = new GMapOverlay("Marcador"); // declaramos uno nuevo para vuelos de ahora
        GMapOverlay markerOverLay_antiguo = new GMapOverlay("Marcador"); // declaramos uno nuevo para guardar el overlay antiguo

        // icono1 de los pointers del mapa
        //Bitmap bmpMarker = (Bitmap)Image.FromFile("img/plane4.png");

        // Variables para plotear un solo vuelo por tiempo
        string TargetIdentification;
        List<int> listaunvuelo = new List<int>();
        GMapOverlay mapoverlay1vuelo = new GMapOverlay("Marcador");
        GMapOverlay mapoverlay1vuelo_antiguo = new GMapOverlay("Marcador");

        int counter_1vuelo;


        public PruebasMapas(List<CAT10> listaCAT10, List<CAT20> listaCAT20, List<CAT21> listaCAT21)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT21 = listaCAT21;


        }

        private void PruebasMapas_Load(object sender, EventArgs e)
        {
            // Declaramos mapa y lus proiedades
            map.DragButton = MouseButtons.Left;
            map.CanDragMap = true;
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(LatInicial, LongInicial);
            map.MinZoom = 0;
            map.MaxZoom = 24;
            map.Zoom = 15;

            if (listaCAT21.Count > 0)
            {
                // declaramos propiedades timer
                timer1.Interval = Convert.ToInt32(timer_speed);

                // Pedimos un target identification:
                tb_targetIdentification.Text = listaCAT21[2].TargetIdentification_decoded.ToString();

                // al cargar hacemos que se ploteen toods los puntos en el mapa

                var markerOverLay = new GMapOverlay("markers");

                int j = 0;
                while (j < listaCAT21.Count)
                {

                    if (listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
                    {
                        var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84_HR, listaCAT21[j].lonWGS84_HR), GMarkerGoogleType.green_dot);
                        markerOverLay.Markers.Add(marker);
                    }

                    if (listaCAT21[j].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
                    {
                        var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84, listaCAT21[j].lonWGS84), GMarkerGoogleType.green_dot);
                        markerOverLay.Markers.Add(marker);
                    }
                    j = j + 1;
                }
                map.Overlays.Add(markerOverLay);

                // Ahora hacemos las listas de aviones y segundos

                // Añadimos la primera posicion a la lista:
                double sec = Math.Round(listaCAT21[0].TimeofMessageReception_Position_seconds);
                listaseconds.Add(sec);

                // recorremos listaCAT21 buscando todos los paquetes con ese tiempo
                int i = 0;
                while (i < listaCAT21.Count)
                {
                    double sec1 = Math.Round(listaCAT21[i].TimeofMessageReception_Position_seconds);
                    if (sec1 == sec) { listavuelos.Add(i); }
                    i = i + 1;
                }
                lista_listaviones.Add(listavuelos);


                i = 0;
                while (i < listaCAT21.Count) // recorremos toda la listaCAT21
                {
                    sec = Math.Round(listaCAT21[i].TimeofMessageReception_Position_seconds); // sacamos tiempo de ese paquete
                    if (sec > listaseconds[listaseconds.Count - 1]) // es mayor que el alterior de la lista? Lo añadimos
                    {
                        List<int> listavuelos1 = new List<int>();
                        listaseconds.Add(sec);

                        j = 0;
                        // hemos encontrado un nuevo segundo, ahora recomrremos listaCAT21 buscando los paquetes con ese tiempo.
                        while (j < listaCAT21.Count)
                        {
                            double sec1 = Math.Round(listaCAT21[j].TimeofMessageReception_Position_seconds);
                            if (sec1 == sec) { listavuelos1.Add(j); }
                            j = j + 1;
                        }
                        lista_listaviones.Add(listavuelos1);
                    }
                    i = i + 1;

                }


                counter = Convert.ToInt32(listaseconds[0]);

                TimeSpan t = TimeSpan.FromSeconds(counter);

                string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);

                lb_tiempo.Text = String.Concat(t.Hours, ":", t.Minutes, ":", t.Seconds);
            }

            if (listaCAT10.Count > 0)
            {
                var markerOverLay = new GMapOverlay("markers");


                int j = 0;
                while (j < listaCAT10.Count)
                {

                    if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length > 0)
                    {
                        double[] coordenadas = NewCoordinatesSMR(listaCAT10[j].Theta, listaCAT10[j].Rho);
                        var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), GMarkerGoogleType.red_dot);
                        markerOverLay.Markers.Add(marker);
                    }

                    j = j + 1;
                }
                map.Overlays.Add(markerOverLay);


            }
        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            // establecemos timer speed
            if (rb_025.Checked == true) { timer1.Interval = Convert.ToInt32(1000/0.25); }
            if (rb_05.Checked == true) { timer1.Interval = Convert.ToInt32(1000 / 0.5); }
            if (rb_1.Checked == true) { timer1.Interval = Convert.ToInt32(1000 / 1); }
            if (rb_2.Checked == true) { timer1.Interval = Convert.ToInt32(1000 / 2); }
            if (rb_4.Checked == true) { timer1.Interval = Convert.ToInt32(1000 / 4); }
            if (rb_10.Checked == true) { timer1.Interval = Convert.ToInt32(1000 / 10); }
            if (rb_20.Checked == true) { timer1.Interval = Convert.ToInt32(1000 / 20); }


            if (rb_AllFlightsByTime.Checked==true)
            {
                // hacemos calculos

                //// buscamos si el counter de segundos es igual que un valor dentro de la lista de segundos
                /// si esta con un break sacamos 

                map.Overlays.Clear();


                int i = 0;
                bool booleano = false;
                while (i < listaseconds.Count)
                {
                    if (listaseconds[i] == counter)
                    {
                        booleano = true;
                        break;
                    }
                    i = i + 1;
                }

                //// si lo hemos encontrado (si bool=true)

                if (booleano == true)
                {
                    markerOverLay.Clear();

                    var listadevuelos = lista_listaviones[i];

                    int j = 0;
                    while (j < listadevuelos.Count)
                    {

                        if (listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[listadevuelos[j]].latWGS84_HR, listaCAT21[listadevuelos[j]].lonWGS84_HR), GMarkerGoogleType.green_dot);
                            markerOverLay.Markers.Add(marker);
                        }

                        if (listaCAT21[j].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[j].PositioninWGS_coordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[listadevuelos[j]].latWGS84, listaCAT21[listadevuelos[j]].lonWGS84), GMarkerGoogleType.green_dot);
                            markerOverLay.Markers.Add(marker);
                        }
                        j = j + 1;
                    }

                    if (counter == Convert.ToInt32(listaseconds[0]))
                    {
                        markerOverLay_antiguo = markerOverLay;
                        map.Overlays.Add(markerOverLay);
                    }

                    else
                    {
                        map.Overlays.Remove(markerOverLay_antiguo);
                        map.Overlays.Add(markerOverLay);
                        markerOverLay_antiguo = markerOverLay;
                    }
                }


                if (counter > listaseconds[listaseconds.Count - 1]) // si counter llega al segundo final (hemos pasado por todos los segundos)
                {
                    timer1.Enabled = false; // paramos el timer
                    counter = Convert.ToInt32(listaseconds[0]); // reiniciamos el contador por si queremos volver a empezar.
                    counter_playpause_button = counter_playpause_button + 1;
                }
            }

            if(rb_SimulateSingleFlightbyTime.Checked==true)
            {
                if (counter==listaseconds[0])
                {
                    mapoverlay1vuelo.Clear();
                    map.Overlays.Clear();

                    try
                    {
                        counter = Convert.ToInt32(listaCAT21[listaunvuelo[0]].TimeofMessageReception_Position_seconds);
                    }
                    catch
                    {
                        lb_Errores.Visible = true;
                        lb_Errores.Text = "For the simulator to work you have to Plot Path before pressing Play/Pause button. To plot a path please close this window and open it again.";
                    }

                }

                int i = 0;
                while (i<listaunvuelo.Count) // recorre toda la lista de paquetes de ese vuelo
                {
                    int position1 = listaunvuelo[i];
                    //mapoverlay1vuelo.Clear();

                    if (Math.Round(listaCAT21[position1].TimeofMessageReception_Position_seconds)==counter)  // si el tiempo de algun paquetee es igual que el tiempo del reloj(counter) añadelo para plotear
                    {
                        // Coge las coordenadas de ese paquete y añadelas al overlay
                        if (listaCAT21[position1].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[position1].latWGS84_HR, listaCAT21[position1].lonWGS84_HR), GMarkerGoogleType.green_dot);
                            mapoverlay1vuelo.Markers.Add(marker);
                        }

                        if (listaCAT21[position1].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[position1].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[position1].latWGS84, listaCAT21[position1].lonWGS84), GMarkerGoogleType.green_dot);
                            mapoverlay1vuelo.Markers.Add(marker);
                        }
                    }
                    i = i + 1;
                }
                map.Overlays.Add(mapoverlay1vuelo);

                if (counter >= listaseconds[listaseconds.Count - 1]) // si counter llega al segundo final (hemos pasado por todos los segundos)
                {
                    timer1.Enabled = false; // paramos el timer
                    counter = Convert.ToInt32(listaseconds[0])-1; // reiniciamos el contador por si queremos volver a empezar.
                    counter_playpause_button = counter_playpause_button + 1;
                }
            }

            TimeSpan t = TimeSpan.FromSeconds(counter);
            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            lb_tiempo.Text = String.Concat(t.Hours, ":", t.Minutes, ":", t.Seconds);
            counter = counter + 1;

        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbPlay_Pause_Click(object sender, EventArgs e)
        {
            counter_playpause_button = counter_playpause_button + 1;

            // primer caso: es la primera vez que le damos

            if (counter_playpause_button == 1)
            {
                timer1.Enabled = true;
                map.Overlays.Clear();
                counter = Convert.ToInt32(listaseconds[0]);

            }

            if(counter==listaseconds[0])
            {
                map.Overlays.Clear();
                mapoverlay1vuelo.Clear();
            }

            // segundo caso: le damos para pausar
            if(timer1.Enabled==true)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }

            // tercer caso: le damos para que al acabarse, vuelva a empezar: esta solucionado ya en el timer_tick 
        }

        private void lbPlot_Click(object sender, EventArgs e)
        {
            if (rb_SimulateSingleFlightbyTime.Checked == true)
            {
                if (counter_1vuelo == 0) // si es el primer vuelo que buscamos:
                {
                    map.Overlays.Clear();
                    map.Overlays.Remove(markerOverLay);

                    map.Overlays.Clear();
                    map.Overlays.Remove(markerOverLay);
                    map.Overlays.Remove(mapoverlay1vuelo);
                    mapoverlay1vuelo.Clear();
                }

                else
                {
                    map.Overlays.Clear();
                    map.Overlays.Remove(markerOverLay);
                    map.Overlays.Remove(mapoverlay1vuelo);
                    mapoverlay1vuelo.Clear();
                }

                // cogemos el target identification del texto
                TargetIdentification = tb_targetIdentification.Text;
                listaunvuelo.Clear();

                // buscamos todos los paquetes que tienen ese target identification en listaCAT21
                int i = 0;
                while (i < listaCAT21.Count)
                {
                    if (listaCAT21[i].TargetIdentification_decoded.ToString() == TargetIdentification)
                    {
                        listaunvuelo.Add(i);
                    }
                    i = i + 1;
                }

                // Una vez hemos buscado todos los paquetes con ese target identification buscamos errores
                if(listaunvuelo.Count==0)
                {
                    lb_Errores.Visible = true;
                    lb_Errores.Text = "Target Identification not found. Please Try a different one.";
                }

                else
                {
                    lb_Errores.Visible = false;

                    int j = 0;
                    while (j < listaunvuelo.Count)
                    {

                        if (listaCAT21[listaunvuelo[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[listaunvuelo[j]].latWGS84_HR, listaCAT21[listaunvuelo[j]].lonWGS84_HR), GMarkerGoogleType.green_dot);
                            mapoverlay1vuelo.Markers.Add(marker);
                        }

                        if (listaCAT21[listaunvuelo[j]].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[listaunvuelo[j]].PositioninWGS_coordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[listaunvuelo[j]].latWGS84, listaCAT21[listaunvuelo[j]].lonWGS84), GMarkerGoogleType.green_dot);
                            mapoverlay1vuelo.Markers.Add(marker);
                        }
                        j = j + 1;
                    }

                    if (counter_1vuelo == 0)
                    {
                        mapoverlay1vuelo_antiguo = mapoverlay1vuelo;
                        map.Overlays.Add(mapoverlay1vuelo);
                    }

                    else
                    {
                        map.Overlays.Remove(mapoverlay1vuelo_antiguo);
                        map.Overlays.Add(mapoverlay1vuelo);
                        mapoverlay1vuelo_antiguo = mapoverlay1vuelo;
                    }
                }

                counter_1vuelo = counter_1vuelo + 1;
                counter = Convert.ToInt32(listaseconds[0]);
            }

            else
            {
                lb_Errores.Visible = true;
                lb_Errores.Text = "To plot a flight first you have to select the SIMULATE SINGLE FLIGHT option above."; 
            }

        }

        private void lb_tiempo_Click(object sender, EventArgs e)
        {

        }

        private void rb_2_CheckedChanged(object sender, EventArgs e)
        {

        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Funciones para que todo esto rule

        public double toRadians(double grados)
        {
            return grados * Math.PI / 180;
        }

        public double toDegrees(double radians)
        {
            return radians * 180 / (Math.PI);
        }

        public double[] NewCoordinatesSMR1(double initialBearing, double distance)
        {
            double[] listaCoordenadas = new double[2];



            double φ1 = toRadians(41 + (17 / 60) + (44.226 / 3600));
            double λ1 = toRadians(2 + (5 / 60) + (42.411 / 3600));
            double α1 = toRadians(initialBearing);
            double s = distance;

            // allow alternative ellipsoid to be specified
            double a = 6378137.0;
            double b = 6356752.314245;
            double f = 1 / 298.257223563;

            double sinα1 = Math.Sin(α1);
            double cosα1 = Math.Cos(α1);

            double tanU1 = (1 - f) * Math.Tan(φ1);
            double cosU1 = 1 / Math.Sqrt((1 + tanU1 * tanU1));
            double sinU1 = tanU1 * cosU1;
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
                Δσ = B * sinσ * (cos2σₘ + (B / 4) * (cosσ * (-1 + 2 * cos2σₘ * cos2σₘ) - (B / 6) * cos2σₘ * (-3 + 4 * sinσ * sinσ) * (-3 + 4 * cos2σₘ * cos2σₘ)));
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

            double coord1 = toDegrees(φ2);
            int sec1 = (int)Math.Round(coord1 * 3600);
            int deg1 = sec1 / 3600;
            sec1 = Math.Abs(sec1 % 3600);
            int min1 = sec1 / 60;
            sec1 %= 60;

            double coord2 = toDegrees(λ2);
            int sec2 = (int)Math.Round(coord2 * 3600);
            int deg2 = sec2 / 3600;
            sec2 = Math.Abs(sec2 % 3600);
            int min2 = sec2 / 60;
            sec2 %= 60;

            return listaCoordenadas;
        }

        public double[] NewCoordinatesSMR(double initialBearing, double distance)
        {
            double[] listaCoordenadas = new double[2];



            double φ1 = toRadians(41.295618);
            double λ1 = toRadians(2.095114);
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
