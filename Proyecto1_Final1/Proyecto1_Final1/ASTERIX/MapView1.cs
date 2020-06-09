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

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ASTERIX
{
    public partial class MapView1 : Form
    {
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT20> listaCAT20 = new List<CAT20>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();

        double LatInicial = 41.2969444;
        double LongInicial = 2.0783333333333336;
        double zoom = 14;

        // CoordenadasSMR
        double LatSMR = 41.295618;
        double LonSMR = 2.095114;

        // Coordenadas MLAT
        double LatMLAT = 41.297063;
        double LonMLAT = 2.078447;

        //Listas de Aviones en cada segundo por categoria
        List<double> listasecondsCAT10 = new List<double>(); // lista de segundos en los que se envia un paquete de la categoria CAT10

        List<double> listasecondsCAT21 = new List<double>(); // lista de segundos en los que se envia un paquete de la categoria CAT21

        List<double> listasecondsCAT21v23 = new List<double>(); // lista de segundos en los que se envia un paquete de la categoria CAT21v23

        public double secondCounter;
        public double secondCounterInicial;
        public double secondCounterFinal;

        bool boolAllFlights = false;
        bool boolSingleFlight = false;

        GMapOverlay overlay = new GMapOverlay();

        public int markerlimit = 2000;

        Bitmap blue_plane = (Bitmap)Image.FromFile("img/Planes/plane_blue_small.png");
        Bitmap red_plane = (Bitmap)Image.FromFile("img/Planes/plane_red_small.png");
        Bitmap green_plane = (Bitmap)Image.FromFile("img/Planes/plane_green_small.png");
        Bitmap white_plane = (Bitmap)Image.FromFile("img/Planes/plane_white_small.png");

        Bitmap blue_pushback = (Bitmap)Image.FromFile("img/Pushbacks/bushback_blue_small.png");
        Bitmap red_pushback = (Bitmap)Image.FromFile("img/Pushbacks/bushback_red_small.png");
        Bitmap green_pushback = (Bitmap)Image.FromFile("img/Pushbacks/bushback_green_small.png");
        Bitmap white_pushback = (Bitmap)Image.FromFile("img/Pushbacks/bushback_white_small.png");

        Bitmap blue_circle = (Bitmap)Image.FromFile("img/Circles1/circle_blue_small.png");
        Bitmap red_circle = (Bitmap)Image.FromFile("img/Circles1/circle_red_small.png");
        Bitmap green_circle = (Bitmap)Image.FromFile("img/Circles1/circle_green_small.png");
        Bitmap white_circle = (Bitmap)Image.FromFile("img/Circles1/circle_white_small.png");

        int posicion_primer_segundo_1vuelo_CAT10;
        int posicion_primer_segundo_1vuelo_CAT21;
        int posicion_primer_segundo_1vuelo_CAT21v23;

        public MapView1(List<CAT10> listaCAT10, List<CAT21> listaCAT21, List<CAT21v23> listaCAT21v23)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT21 = listaCAT21;
            this.listaCAT21v23 = listaCAT21v23;

        }

        private void MapView1_Load(object sender, EventArgs e)
        {
            // Establecemos timer parado

            timer.Enabled = false;

            //Cargamos mapa

            Mapa.DragButton = MouseButtons.Left;
            Mapa.CanDragMap = true;
            Mapa.MapProvider = GMapProviders.GoogleSatelliteMap;
            Mapa.Position = new PointLatLng(LatInicial, LongInicial);
            Mapa.MinZoom = 6;
            Mapa.MaxZoom = 24;
            Mapa.Zoom = zoom;
            Mapa.AutoScroll = true;
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            // establecemos timer speed
            if (rb_05.Checked == true) { timer.Interval = Convert.ToInt32(500 / 0.5); }
            if (rb_1.Checked == true) { timer.Interval = Convert.ToInt32(500 / 1); }
            if (rb_2.Checked == true) { timer.Interval = Convert.ToInt32(500 / 2); }
            if (rb_4.Checked == true) { timer.Interval = Convert.ToInt32(500 / 4); }
            if (rb_10.Checked == true) { timer.Interval = Convert.ToInt32(500 / 10); }
            if (rb_20.Checked == true) { timer.Interval = Convert.ToInt32(500 / 20); }

            if (boolAllFlights == true && boolSingleFlight == false)
            {
                TimeSpan t = TimeSpan.FromSeconds(secondCounter);
                lb_Hora.Visible = true;
                string hours = t.Hours.ToString();
                string minutes = t.Minutes.ToString();
                string seconds = t.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours;}
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_Hora.Text = String.Concat(hours, ":", minutes, ":", seconds);

                overlay.Clear();
                Mapa.Overlays.Clear();

                overlay = CalcularNuevosPuntos(secondCounter, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter-0.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 1, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 1.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 2, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 2.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 3, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 3.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 4, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 4.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 5.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 6, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 6.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 7, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 7.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 8, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 8.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 9, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 9.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 10, overlay);
                Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 10.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 11, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 11.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 12, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 12.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 13, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 13.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 14, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 14.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 15, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 15.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 16, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 16.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 17, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 17.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 18, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 18.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 19, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 19.5, overlay);
                //Mapa.Overlays.Add(overlay);

                //overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 20, overlay);
                Mapa.Overlays.Add(overlay);


                secondCounter = secondCounter + 0.5;

                if (secondCounter > secondCounterFinal)
                {
                    timer.Enabled = false;
                    overlay.Clear();
                    Mapa.Overlays.Clear();
                    secondCounter = secondCounterInicial;
                }
            }

            if (boolAllFlights == false && boolSingleFlight == true)
            {
                TimeSpan t = TimeSpan.FromSeconds(secondCounter);
                lb_Hora.Visible = true;
                string hours = t.Hours.ToString();
                string minutes = t.Minutes.ToString();
                string seconds = t.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_Hora.Text = String.Concat(hours, ":", minutes, ":", seconds);

                overlay = CalcularNuevosPuntosPorNombre(secondCounter, overlay, tb_TargetIdentification.Text);
                Mapa.Overlays.Clear();
                Mapa.Overlays.Add(overlay);


                secondCounter = secondCounter + 0.5;

                if (secondCounter > secondCounterFinal)
                {
                    timer.Enabled = false;
                    overlay.Clear();
                    Mapa.Overlays.Clear();
                    secondCounter = secondCounterInicial;
                }
            }
        }



        private void lb_FIR_Click(object sender, EventArgs e)
        {
            Mapa.Zoom = 8;
        }

        private void lb_TMA_Click(object sender, EventArgs e)
        {
            Mapa.Zoom = 11;
        }

        private void bt_TWR_Click(object sender, EventArgs e)
        {
            Mapa.Zoom = 13;
        }

        private void bt_AllFlights_Click(object sender, EventArgs e)
        {
            // Limpiamos los mapas
            Mapa.Overlays.Clear();
            overlay.Clear();


            // Establecemos timer
            timer.Enabled = false;

            //Cargamos vectores tiempo

            if (listaCAT10.Count > 0) { CalculateListaSecondsCAT10(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT10
            if (listaCAT21.Count > 0) { CalculateListaSecondsCAT21(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21
            if (listaCAT21v23.Count > 0) { CalculateListaSecondsCAT21v23(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21v23

            // Establecemos el primer segundo como el minimo de los 3.
            double db1;
            double db2;
            double db3;

            if (listasecondsCAT10.Count == 0) { db1 = 10e6; }
            else { db1 = listasecondsCAT10.First(); }

            if (listasecondsCAT21.Count == 0) { db2 = 10e6; }
            else { db2 = listasecondsCAT21.First(); }

            if (listasecondsCAT21v23.Count == 0) { db3 = 10e6; }
            else { db3 = listasecondsCAT21v23.First(); }

            secondCounterInicial = new[] { db1, db2, db3 }.Min();

            if (listasecondsCAT10.Count == 0) { db1 = 0; }
            else { db1 = listasecondsCAT10.Last(); }

            if (listasecondsCAT21.Count == 0) { db2 = 0; }
            else { db2 = listasecondsCAT21.Last(); }

            if (listasecondsCAT21v23.Count == 0) { db3 = 0; }
            else { db3 = listasecondsCAT21v23.Last(); }

            secondCounterFinal = new[] { db1, db2, db3 }.Max();

            // Definimos valor inicial del contador contador

            secondCounter = secondCounterInicial;

            // Labels del tiempo

            TimeSpan t = TimeSpan.FromSeconds(secondCounterInicial);
            lb_HoraInicial.Visible = true;
            string hours = t.Hours.ToString();
            string minutes = t.Minutes.ToString();
            string seconds = t.Seconds.ToString();
            if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
            if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
            if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

            lb_HoraInicial.Text = String.Concat(hours, ":", minutes, ":", seconds);

            TimeSpan t1 = TimeSpan.FromSeconds(secondCounterFinal);
            lb_HoraFinal.Visible = true;
            hours = t1.Hours.ToString();
            minutes = t1.Minutes.ToString();
            seconds = t1.Seconds.ToString();
            if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
            if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
            if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

            lb_HoraFinal.Text = String.Concat(hours, ":", minutes, ":", seconds);

            //  Establecemos que boton esta encendido y cual no
            boolAllFlights = true;
            boolSingleFlight = false;
        }

        private void bt_SingleFlight_Click(object sender, EventArgs e)
        {
            // Limpiamos los mapas
            Mapa.Overlays.Clear();
            overlay.Clear();


            // Establecemos timer
            timer.Enabled = false;

            //Cargamos vectores tiempo

            if (listaCAT10.Count > 0) { CalculateListaSeconds1vueloCAT10(tb_TargetIdentification.Text); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT10 con ese TargetAddress, TargetIdentification o Track Number
            if (listaCAT21.Count > 0) { CalculateListaSeconds1vueloCAT21(tb_TargetIdentification.Text); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21 con ese TargetAddress, TargetIdentification o Track Number
            if (listaCAT21v23.Count > 0) { CalculateListaSeconds1vueloCAT21v23(tb_TargetIdentification.Text); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21v23 con ese TargetAddress, TargetIdentification o Track Number

            // Establecemos el primer segundo como el minimo de los 3.
            double db1;
            double db2;
            double db3;

            if (listasecondsCAT10.Count == 0) { db1 = 10e6; }
            else { db1 = listasecondsCAT10.First(); }

            if (listasecondsCAT21.Count == 0) { db2 = 10e6; }
            else { db2 = listasecondsCAT21.First(); }

            if (listasecondsCAT21v23.Count == 0) { db3 = 10e6; }
            else { db3 = listasecondsCAT21v23.First(); }

            secondCounterInicial = new[] { db1, db2, db3 }.Min();

            if (listasecondsCAT10.Count == 0) { db1 = 0; }
            else { db1 = listasecondsCAT10.Last(); }

            if (listasecondsCAT21.Count == 0) { db2 = 0; }
            else { db2 = listasecondsCAT21.Last(); }

            if (listasecondsCAT21v23.Count == 0) { db3 = 0; }
            else { db3 = listasecondsCAT21v23.Last(); }

            secondCounterFinal = new[] { db1, db2, db3 }.Max();

            // Definimos valor inicial del contador contador

            secondCounter = secondCounterInicial;

            // Labels del tiempo

            TimeSpan t = TimeSpan.FromSeconds(secondCounterInicial);
            lb_HoraInicial.Visible = true;
            string hours = t.Hours.ToString();
            string minutes = t.Minutes.ToString();
            string seconds = t.Seconds.ToString();
            if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
            if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
            if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

            lb_HoraInicial.Text = String.Concat(hours, ":", minutes, ":", seconds);

            TimeSpan t1 = TimeSpan.FromSeconds(secondCounterFinal);
            lb_HoraFinal.Visible = true;
            hours = t1.Hours.ToString();
            minutes = t1.Minutes.ToString();
            seconds = t1.Seconds.ToString();
            if (t1.Hours.ToString().Length == 1) { hours = "0" + t1.Hours; }
            if (t1.Minutes.ToString().Length == 1) { minutes = "0" + t1.Minutes; }
            if (t1.Seconds.ToString().Length == 1) { seconds = "0" + t1.Seconds; }

            lb_HoraFinal.Text = String.Concat(hours, ":", minutes, ":", seconds);


            //  Establecemos que boton esta encendido y cual no

            boolAllFlights = false;
            boolSingleFlight = true;
        }


        private void bt_PlotAllFlights_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            secondCounter = secondCounterInicial;

            Mapa.Overlays.Clear();
            overlay.Clear();

            // creamos un overlay solo para el load
            GMapOverlay overlayLoad = new GMapOverlay();
            overlayLoad.Clear();

            // Ploteamos todos los puntos que tengamos

            if (listaCAT10.Count > 0) // Plot lista CAT10
            {
                int i = 0;

                while (i < listaCAT10.Count)
                {

                    int SAC = listaCAT10[i].SAC;
                    int SIC = listaCAT10[i].SIC;

                    if (SAC == 0 && SIC == 7) //SMR
                    {
                        if (cb_SMR.Checked == true)
                        {
                            if (listaCAT10[i].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesSMR(listaCAT10[i].Rho, listaCAT10[i].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_plane);
                                overlayLoad.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[i].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[i].Tracknumber_value); }
                            }

                            if (listaCAT10[i].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[i].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[i].X_cartesian) * (listaCAT10[i].X_cartesian) + (listaCAT10[i].Y_cartesian) * (listaCAT10[i].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[i].X_cartesian, listaCAT10[i].Y_cartesian);

                                double[] coordenadas = NewCoordinatesSMR(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_plane);
                                overlayLoad.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[i].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[i].Tracknumber_value); }
                            }
                        }
                    }

                    if (SAC == 0 && SIC == 107) //MLAT
                    {

                        if (cb_MLAT.Checked == true)
                        {
                            if (listaCAT10[i].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesMLAT(listaCAT10[i].Rho, listaCAT10[i].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[i].TOT == "Ground Vehicle." || listaCAT10[i].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_pushback);
                                    overlayLoad.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);
                                    overlayLoad.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }



                                if (listaCAT10[i].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[i].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[i].TargetIdentification_decoded); }
                                else if (listaCAT10[i].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[i].TargetAdress_decoded); }
                                else if (listaCAT10[i].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[i].Tracknumber_value); }
                            }

                            if (listaCAT10[i].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[i].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[i].X_cartesian) * (listaCAT10[i].X_cartesian) + (listaCAT10[i].Y_cartesian) * (listaCAT10[i].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[i].X_cartesian, listaCAT10[i].Y_cartesian);

                                double[] coordenadas = NewCoordinatesMLAT(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[i].TOT == "Ground Vehicle." || listaCAT10[i].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_pushback);
                                    overlayLoad.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);
                                    overlayLoad.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }

                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[i].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[i].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[i].TargetIdentification_decoded); }
                                else if (listaCAT10[i].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[i].TargetAdress_decoded); }
                                else if (listaCAT10[i].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[i].Tracknumber_value); }
                            }
                        }
                    }
                    i = i + 1;
                }
            }

            if (listaCAT21.Count > 0) // plot lista CAT21
            {
                int j = 0;
                while (j < listaCAT21.Count)
                {
                    if (CB_CAT21.Checked == true)
                    {
                        if (listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
                        {

                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84_HR, listaCAT21[j].lonWGS84_HR), green_plane);
                            if (listaCAT21[j].ECAT == "Surface emergency vehicle" || listaCAT21[j].ECAT == "Surface service vehicle." || listaCAT21[j].ECAT == "Fixed ground or tethered obstruction.")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84_HR, listaCAT21[j].lonWGS84_HR), green_pushback);
                                overlayLoad.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84_HR, listaCAT21[j].lonWGS84_HR), green_plane);
                                overlayLoad.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[j].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[j].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[j].TargetIdentification_decoded); }
                            else if (listaCAT21[j].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[j].TargetAdress_real); }
                            else if (listaCAT21[j].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[j].TrackNumber_number); }
                        }

                        if (listaCAT21[j].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84, listaCAT21[j].lonWGS84), green_plane);
                            if (listaCAT21[j].ECAT == "Surface emergency vehicle" || listaCAT21[j].ECAT == "Surface service vehicle." || listaCAT21[j].ECAT == "Fixed ground or tethered obstruction.")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84, listaCAT21[j].lonWGS84), green_plane);
                                overlayLoad.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84, listaCAT21[j].lonWGS84), green_pushback);
                                overlayLoad.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[j].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[j].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[j].TargetIdentification_decoded); }
                            else if (listaCAT21[j].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[j].TargetAdress_real); }
                            else if (listaCAT21[j].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[j].TrackNumber_number); }
                        }
                    }

                    j = j + 1;
                }
            }

            if (listaCAT21v23.Count > 0) // Plot lista CAT21v23
            {
                int j = 0;
                while (j < listaCAT21v23.Count)
                {
                    if (cb_CAT21v23.Checked == true)
                    {
                        if (listaCAT21v23[j].PositioninWGS_coordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[j].latWGS84, listaCAT21v23[j].lonWGS84), red_plane); // Genero el marker (no me deja hacerlo de otra manera)
                            if (listaCAT21v23[j].ECAT == "surface emergency vehicle " || listaCAT21v23[j].ECAT == "surface service vehicle" || listaCAT21v23[j].ECAT == "fixed ground or tethered obstruction")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[j].latWGS84, listaCAT21v23[j].lonWGS84), red_pushback);
                            }
                            else { marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[j].latWGS84, listaCAT21v23[j].lonWGS84), red_plane); }

                            overlayLoad.Markers.Add(marker);
                            //var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane);
                            //overlay.Markers.Add(marker);

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21v23[j].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21v23[j].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21v23[j].TargetIdentification_decoded); }
                            else if (listaCAT21v23[j].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21v23[j].TargetAdress_real); }
                        }
                    }

                    j = j + 1;
                }
            }

            Mapa.Overlays.Add(overlayLoad);
        }

        private void bt_PlayPause_Click(object sender, EventArgs e)
        {
            if (boolAllFlights == true || boolSingleFlight == true)
            {
                if (timer.Enabled == false) { timer.Enabled = true; }
                else { timer.Enabled = false; }
            }
        }

        private void bt_Forward_Click_1(object sender, EventArgs e)
        {
            if (boolAllFlights == true && boolSingleFlight == false)
            {
                TimeSpan t = TimeSpan.FromSeconds(secondCounter);
                lb_Hora.Visible = true;
                string hours = t.Hours.ToString();
                string minutes = t.Minutes.ToString();
                string seconds = t.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_Hora.Text = String.Concat(hours, ":", minutes, ":", seconds);

                overlay.Clear();
                Mapa.Overlays.Clear();

                overlay = CalcularNuevosPuntos(secondCounter, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 0.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 1, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 1.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 2, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 2.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 3, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 3.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 4, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 4.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 5.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 6, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 6.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 7, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 7.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 8, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 8.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 9, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 9.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 10, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 10.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 11, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 11.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 12, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 12.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 13, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 13.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 14, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 14.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 15, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 15.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 16, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 16.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 17, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 17.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 18, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 18.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 19, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 19.5, overlay);
                Mapa.Overlays.Add(overlay);

                overlay = CalcularNuevosPuntos_DiubujarBola(secondCounter - 20, overlay);
                Mapa.Overlays.Add(overlay);


                secondCounter = secondCounter + 0.5;

                if (secondCounter > secondCounterFinal)
                {
                    timer.Enabled = false;
                    overlay.Clear();
                    Mapa.Overlays.Clear();
                    secondCounter = secondCounterInicial;
                }
            }

            if (boolAllFlights == false && boolSingleFlight == true)
            {
                TimeSpan t = TimeSpan.FromSeconds(secondCounter);
                lb_Hora.Visible = true;
                string hours = t.Hours.ToString();
                string minutes = t.Minutes.ToString();
                string seconds = t.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_Hora.Text = String.Concat(hours, ":", minutes, ":", seconds);

                overlay = CalcularNuevosPuntosPorNombre(secondCounter, overlay, tb_TargetIdentification.Text); // Saco 3 listas (una por clase) con las posiciones en la listaCAT de los paquetes que hay en ese segundo y con esa identificacion. Luego calculo las coordenadas y las añado al overlay
                Mapa.Overlays.Clear();
                Mapa.Overlays.Add(overlay);

                secondCounter = secondCounter + 0.5;

                if (secondCounter > secondCounterFinal)
                {
                    timer.Enabled = false;
                    overlay.Clear();
                    Mapa.Overlays.Clear();
                    secondCounter = secondCounterInicial;
                }
            }
        }

        private void bt_Restart_Click(object sender, EventArgs e)
        {
            if (boolAllFlights == true && boolSingleFlight == false)
            {
                // Limpiamos los mapas
                Mapa.Overlays.Clear();
                overlay.Clear();


                // Establecemos timer
                timer.Enabled = false;

                //Cargamos vectores tiempo

                if (listaCAT10.Count > 0) { CalculateListaSecondsCAT10(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT10
                if (listaCAT21.Count > 0) { CalculateListaSecondsCAT21(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21
                if (listaCAT21v23.Count > 0) { CalculateListaSecondsCAT21v23(); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21v23

                // Establecemos el primer segundo como el minimo de los 3.
                double db1;
                double db2;
                double db3;

                if (listasecondsCAT10.Count == 0) { db1 = 10e6; }
                else { db1 = listasecondsCAT10.First(); }

                if (listasecondsCAT21.Count == 0) { db2 = 10e6; }
                else { db2 = listasecondsCAT21.First(); }

                if (listasecondsCAT21v23.Count == 0) { db3 = 10e6; }
                else { db3 = listasecondsCAT21v23.First(); }

                secondCounterInicial = new[] { db1, db2, db3 }.Min();

                if (listasecondsCAT10.Count == 0) { db1 = 0; }
                else { db1 = listasecondsCAT10.Last(); }

                if (listasecondsCAT21.Count == 0) { db2 = 0; }
                else { db2 = listasecondsCAT21.Last(); }

                if (listasecondsCAT21v23.Count == 0) { db3 = 0; }
                else { db3 = listasecondsCAT21v23.Last(); }

                secondCounterFinal = new[] { db1, db2, db3 }.Max();

                // Definimos valor inicial del contador contador

                secondCounter = secondCounterInicial;

                // Labels del tiempo

                TimeSpan t = TimeSpan.FromSeconds(secondCounterInicial);
                lb_HoraInicial.Visible = true;
                string hours = t.Hours.ToString();
                string minutes = t.Minutes.ToString();
                string seconds = t.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_HoraInicial.Text = String.Concat(hours, ":", minutes, ":", seconds);

                TimeSpan t1 = TimeSpan.FromSeconds(secondCounterFinal);
                lb_HoraFinal.Visible = true;
                hours = t1.Hours.ToString();
                minutes = t1.Minutes.ToString();
                seconds = t1.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_HoraFinal.Text = String.Concat(hours, ":", minutes, ":", seconds);

                TimeSpan t2 = TimeSpan.FromSeconds(secondCounter);
                lb_Hora.Visible = true;
                hours = t2.Hours.ToString();
                minutes = t2.Minutes.ToString();
                seconds = t2.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_Hora.Text = String.Concat(hours, ":", minutes, ":", seconds);
            }

            if (boolAllFlights == false && boolSingleFlight == true)
            {
                // Limpiamos los mapas
                Mapa.Overlays.Clear();
                overlay.Clear();


                // Establecemos timer
                timer.Enabled = false;

                //Cargamos vectores tiempo

                if (listaCAT10.Count > 0) { CalculateListaSeconds1vueloCAT10(tb_TargetIdentification.Text); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT10 con ese TargetAddress, TargetIdentification o Track Number
                if (listaCAT21.Count > 0) { CalculateListaSeconds1vueloCAT21(tb_TargetIdentification.Text); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21 con ese TargetAddress, TargetIdentification o Track Number
                if (listaCAT21v23.Count > 0) { CalculateListaSeconds1vueloCAT21v23(tb_TargetIdentification.Text); } // Calcula una lista con todos los segundos en los que se envia un paquete CAT21v23 con ese TargetAddress, TargetIdentification o Track Number

                // Establecemos el primer segundo como el minimo de los 3.
                double db1;
                double db2;
                double db3;

                if (listasecondsCAT10.Count == 0) { db1 = 10e6; }
                else { db1 = listasecondsCAT10.First(); }

                if (listasecondsCAT21.Count == 0) { db2 = 10e6; }
                else { db2 = listasecondsCAT21.First(); }

                if (listasecondsCAT21v23.Count == 0) { db3 = 10e6; }
                else { db3 = listasecondsCAT21v23.First(); }

                secondCounterInicial = new[] { db1, db2, db3 }.Min();

                if (listasecondsCAT10.Count == 0) { db1 = 0; }
                else { db1 = listasecondsCAT10.Last(); }

                if (listasecondsCAT21.Count == 0) { db2 = 0; }
                else { db2 = listasecondsCAT21.Last(); }

                if (listasecondsCAT21v23.Count == 0) { db3 = 0; }
                else { db3 = listasecondsCAT21v23.Last(); }

                secondCounterFinal = new[] { db1, db2, db3 }.Max();

                // Definimos valor inicial del contador contador

                secondCounter = secondCounterInicial;

                // Labels del tiempo

                TimeSpan t = TimeSpan.FromSeconds(secondCounterInicial);
                lb_HoraInicial.Visible = true;
                string hours = t.Hours.ToString();
                string minutes = t.Minutes.ToString();
                string seconds = t.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_HoraInicial.Text = String.Concat(hours, ":", minutes, ":", seconds);

                TimeSpan t1 = TimeSpan.FromSeconds(secondCounterFinal);
                lb_HoraFinal.Visible = true;
                hours = t1.Hours.ToString();
                minutes = t1.Minutes.ToString();
                seconds = t1.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_HoraFinal.Text = String.Concat(hours, ":", minutes, ":", seconds);

                TimeSpan t2 = TimeSpan.FromSeconds(secondCounter);
                lb_Hora.Visible = true;
                hours = t2.Hours.ToString();
                minutes = t2.Minutes.ToString();
                seconds = t2.Seconds.ToString();
                if (t.Hours.ToString().Length == 1) { hours = "0" + t.Hours; }
                if (t.Minutes.ToString().Length == 1) { minutes = "0" + t.Minutes; }
                if (t.Seconds.ToString().Length == 1) { seconds = "0" + t.Seconds; }

                lb_Hora.Text = String.Concat(hours, ":", minutes, ":", seconds);
            }
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

        public double[] NewCoordinatesSMR(double distance, double bearing)
        {
            double[] listaCoordenadas = new double[2];

            double φ1 = toRadians(LatSMR);
            double λ1 = toRadians(LonSMR);
            double α1 = toRadians(bearing);
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

        public List<int> VuelosCAT10Ahora(double second)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaCAT10.Count)
            {
                if (Math.Floor(listaCAT10[j].TimeofDay_seconds) == second)
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
                if (Math.Floor(listaCAT21[j].TimeofASTERIXReportTransmission_seconds) == second)
                {
                    lista.Add(j);
                }
                j = j + 1;
            }
            return lista;
        }
        public List<int> VuelosCAT21v23Ahora(double second)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaCAT21v23.Count)
            {
                if (Math.Floor(2*listaCAT21v23[j].TimeofDay_seconds)/2 == second)
                {
                    lista.Add(j);
                }
                j = j + 1;
            }
            return lista;
        }

        public List<int> VuelosCAT10AhoraPorNombre(double second, string targetidentification)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaCAT10.Count)
            {
                if (listaCAT10[j].SAC == 0 && listaCAT10[j].SIC == 107)
                {
                    string TargetIdentificationActual = listaCAT10[j].TargetIdentification_decoded;
                    string TargetAddressActual = listaCAT10[j].TargetAdress_decoded.ToString();
                    string TrackAngleActual = listaCAT10[j].Tracknumber_value.ToString();

                    if (Math.Floor(listaCAT10[j].TimeofDay_seconds) == second && TargetIdentificationActual == targetidentification)
                    {
                        lista.Add(j);
                    }

                    else if (Math.Floor(listaCAT10[j].TimeofDay_seconds) == second && TargetAddressActual == targetidentification)
                    {
                        lista.Add(j);
                    }

                    else if (Math.Floor(listaCAT10[j].TimeofDay_seconds) == second && TrackAngleActual == targetidentification)
                    {
                        lista.Add(j);
                    }
                }

                if (listaCAT10[j].SAC == 0 && listaCAT10[j].SIC == 7)
                {
                    string TrackAngleActual = listaCAT10[j].Tracknumber_value.ToString();

                    if (Math.Floor(listaCAT10[j].TimeofDay_seconds) == second && TrackAngleActual == targetidentification)
                    {
                        lista.Add(j);
                    }
                }

                j = j + 1;
            }
            return lista;
        }
        public List<int> VuelosCAT21AhoraPorNombre(double second, string targetidentification)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaCAT21.Count)
            {
                string TargetIdentificationActual = listaCAT21[j].TargetIdentification_decoded;
                string TargetAddressActual = listaCAT21[j].TargetAdress_real;
                string TrackNumberActual = listaCAT21[j].TrackNumber_number.ToString();

                if (Math.Floor(listaCAT21[j].TimeofASTERIXReportTransmission_seconds) == second && TargetIdentificationActual == targetidentification)
                {
                    lista.Add(j);
                }

                else if (Math.Floor(listaCAT21[j].TimeofASTERIXReportTransmission_seconds) == second && TargetAddressActual == targetidentification)
                {
                    lista.Add(j);
                }

                else if (Math.Floor(listaCAT21[j].TimeofASTERIXReportTransmission_seconds) == second && TrackNumberActual == targetidentification)
                {
                    lista.Add(j);
                }

                j = j + 1;
            }
            return lista;
        }
        public List<int> VuelosCAT21v23AhoraPorNombre(double second, string targetidentification)
        {
            List<int> lista = new List<int>();

            int j = 0;
            while (j < listaCAT21v23.Count)
            {
                string TargetIdentificationActual = listaCAT21v23[j].TargetIdentification_decoded;
                string TargetAddressActual = listaCAT21v23[j].TargetAdress_real;

                if (Math.Floor(2*listaCAT21v23[j].TimeofDay_seconds)/2 == second && TargetIdentificationActual == targetidentification)
                {
                    lista.Add(j);
                }

                else if (Math.Floor(2*listaCAT21v23[j].TimeofDay_seconds)/2 == second && TargetAddressActual == targetidentification)
                {
                    lista.Add(j);
                }

                j = j + 1;
            }
            return lista;
        }

        public void CalculateListaSecondsCAT10()
        {
            listasecondsCAT10.Clear();

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT10[0].TimeofDay_seconds)));
            listasecondsCAT10.Add(sec);

            int i = 1;
            while (i < listaCAT10.Count)
            {
                int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT10[i].TimeofDay_seconds)));
                if (second > listasecondsCAT10.Last())
                {
                    listasecondsCAT10.Add(second);
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
        public void CalculateListaSecondsCAT21v23()
        {
            listasecondsCAT21v23.Clear();

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21v23[0].TimeofDay_seconds)));
            listasecondsCAT21v23.Add(sec);

            int i = 1;
            while (i < listaCAT21v23.Count)
            {
                int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21v23[i].TimeofDay_seconds)));
                if (second > listasecondsCAT21v23.Last())
                {
                    listasecondsCAT21v23.Add(second);
                }
                i = i + 1;
            }
        }

        public void CalculateListaSeconds1vueloCAT10(string TargetIdentification)
        {
            listasecondsCAT10.Clear();

            int j = 0;
            while (j < listaCAT10.Count)
            {
                if (listaCAT10[j].TargetIdentification_decoded.ToString() == TargetIdentification || listaCAT10[j].TargetAdress_decoded.ToString() == TargetIdentification || listaCAT10[j].Tracknumber_value.ToString() == TargetIdentification)
                {
                    posicion_primer_segundo_1vuelo_CAT10 = j;
                    break;
                }
                j = j + 1;
            }

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT10[posicion_primer_segundo_1vuelo_CAT10].TimeofDay_seconds)));
            listasecondsCAT10.Add(sec);

            int i = posicion_primer_segundo_1vuelo_CAT10 + 1;
            while (i < listaCAT10.Count)
            {

                if (listaCAT10[i].SAC == 0 && listaCAT10[i].SIC == 107)
                {
                    string TargetIdentificationActual = listaCAT10[i].TargetIdentification_decoded.ToString(); ;
                    string TargetAddressActual = listaCAT10[i].TargetAdress_decoded.ToString();
                    string TrackNumberActual = listaCAT10[i].Tracknumber_value.ToString();

                    int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT10[i].TimeofDay_seconds)));
                    if (second > listasecondsCAT10.Last() && TargetIdentificationActual == TargetIdentification)
                    {
                        listasecondsCAT10.Add(second);
                    }

                    if (second > listasecondsCAT10.Last() && TargetAddressActual == TargetIdentification)
                    {
                        listasecondsCAT10.Add(second);
                    }

                    if (second > listasecondsCAT10.Last() && TrackNumberActual == TargetIdentification)
                    {
                        listasecondsCAT10.Add(second);
                    }
                }

                if (listaCAT10[i].SAC == 0 && listaCAT10[i].SIC == 7)
                {
                    string TrackNumberActual = listaCAT10[i].Tracknumber_value.ToString();

                    int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT10[i].TimeofDay_seconds)));
                    if (second > listasecondsCAT10.Last() && TrackNumberActual == TargetIdentification)
                    {
                        listasecondsCAT10.Add(second);
                    }
                }

                i = i + 1;
            }
        }
        public void CalculateListaSeconds1vueloCAT21(string TargetIdentification)
        {
            listasecondsCAT21.Clear();

            int j = 0;
            while (j < listaCAT21.Count)
            {
                if (listaCAT21[j].TargetIdentification_decoded.ToString() == TargetIdentification || listaCAT21[j].TargetAdress_real.ToString() == TargetIdentification || listaCAT21[j].TrackNumber_number.ToString() == TargetIdentification)
                {
                    posicion_primer_segundo_1vuelo_CAT21 = j;
                    break;
                }
                j = j + 1;
            }

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21[posicion_primer_segundo_1vuelo_CAT21].TimeofASTERIXReportTransmission_seconds)));
            listasecondsCAT21.Add(sec);

            int i = posicion_primer_segundo_1vuelo_CAT21 + 1;
            while (i < listaCAT21.Count)
            {
                string TargetIdentificationActual = listaCAT21[i].TargetIdentification_decoded;
                string TargetAddressActual = listaCAT21[i].TargetAdress_real;
                string TrackNumberActual = listaCAT21[i].TrackNumber_number.ToString();

                int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21[i].TimeofASTERIXReportTransmission_seconds)));
                if (second > listasecondsCAT21.Last() && TargetIdentification == TargetIdentificationActual)
                {
                    listasecondsCAT21.Add(second);
                }

                else if (second > listasecondsCAT21.Last() && TargetIdentification == TargetAddressActual)
                {
                    listasecondsCAT21.Add(second);
                }

                else if (second > listasecondsCAT21.Last() && TargetIdentification == TrackNumberActual)
                {
                    listasecondsCAT21.Add(second);
                }

                i = i + 1;
            }
        }
        public void CalculateListaSeconds1vueloCAT21v23(string TargetIdentification)
        {
            listasecondsCAT21v23.Clear();

            int j = 0;
            while (j < listaCAT21v23.Count)
            {
                if (listaCAT21v23[j].TargetIdentification_decoded.ToString() == TargetIdentification || listaCAT21v23[j].TargetAdress_real.ToString() == TargetIdentification)
                {
                    posicion_primer_segundo_1vuelo_CAT21v23 = j;
                    break;
                }
                j = j + 1;
            }

            double sec = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21v23[posicion_primer_segundo_1vuelo_CAT21v23].TimeofDay_seconds)));
            listasecondsCAT21v23.Add(sec);

            int i = posicion_primer_segundo_1vuelo_CAT21v23 + 1;
            while (i < listaCAT21v23.Count)
            {
                string TargetIdentificationActual = listaCAT21v23[i].TargetIdentification_decoded;
                string TargetAddressActual = listaCAT21v23[i].TargetAdress_real;

                int second = Convert.ToInt32(Math.Floor(Convert.ToDouble(listaCAT21v23[i].TimeofDay_seconds)));
                if (second > listasecondsCAT21v23.Last() && TargetIdentificationActual == TargetIdentification)
                {
                    listasecondsCAT21v23.Add(second);
                }

                if (second > listasecondsCAT21v23.Last() && TargetAddressActual == TargetIdentification)
                {
                    listasecondsCAT21v23.Add(second);
                }

                i = i + 1;
            }
        }


        public GMapOverlay CalcularNuevosPuntos(double secondCounter, GMapOverlay overlay)
        {
            List<int> vuelosCAT10 = VuelosCAT10Ahora(secondCounter); // Lista de vuelos en CAT10 con ese tiempo
            List<int> vuelosCAT21 = VuelosCAT21Ahora(secondCounter); // Lista de vuelos en CAT21 con ese tiempo
            List<int> vuelosCAT21v23 = VuelosCAT21v23Ahora(secondCounter); // Lista de vuelos en CAT21v23 con ese tiempo

            if (vuelosCAT10.Count > 0) // Plot lista CAT10
            {
                int i = 0;

                while (i < vuelosCAT10.Count)
                {
                    int j = vuelosCAT10[i];

                    int SAC = listaCAT10[vuelosCAT10[i]].SAC;
                    int SIC = listaCAT10[vuelosCAT10[i]].SIC;

                    if (SAC == 0 && SIC == 7) //SMR
                    {
                        if (cb_SMR.Checked == true)
                        {
                            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesSMR(listaCAT10[vuelosCAT10[i]].Rho, listaCAT10[vuelosCAT10[i]].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_plane);
                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }

                            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[j].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[vuelosCAT10[i]].X_cartesian) * (listaCAT10[vuelosCAT10[i]].X_cartesian) + (listaCAT10[vuelosCAT10[i]].Y_cartesian) * (listaCAT10[vuelosCAT10[i]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosCAT10[i]].X_cartesian, listaCAT10[vuelosCAT10[i]].Y_cartesian);

                                double[] coordenadas = NewCoordinatesSMR(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_plane);
                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }
                        }
                    }

                    if (SAC == 0 && SIC == 107) //MLAT
                    {

                        if (cb_MLAT.Checked == true)
                        {
                            if (listaCAT10[vuelosCAT10[i]].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesMLAT(listaCAT10[vuelosCAT10[i]].Rho, listaCAT10[vuelosCAT10[i]].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[vuelosCAT10[i]].TOT == "Ground Vehicle." || listaCAT10[vuelosCAT10[i]].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_pushback);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }



                                if (listaCAT10[vuelosCAT10[i]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[vuelosCAT10[i]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[vuelosCAT10[i]].TargetIdentification_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[vuelosCAT10[i]].TargetAdress_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }

                            if (listaCAT10[vuelosCAT10[i]].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[vuelosCAT10[i]].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[vuelosCAT10[i]].X_cartesian) * (listaCAT10[vuelosCAT10[i]].X_cartesian) + (listaCAT10[vuelosCAT10[i]].Y_cartesian) * (listaCAT10[vuelosCAT10[i]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosCAT10[i]].X_cartesian, listaCAT10[vuelosCAT10[i]].Y_cartesian);

                                double[] coordenadas = NewCoordinatesMLAT(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[i].TOT == "Ground Vehicle." || listaCAT10[vuelosCAT10[i]].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_pushback);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }

                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[vuelosCAT10[i]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[vuelosCAT10[i]].TargetIdentification_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[vuelosCAT10[i]].TargetAdress_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }
                        }
                    }
                    i = i + 1;
                }
            }

            if (listaCAT21.Count > 0) // plot lista CAT21
            {
                int j = 0;
                while (j < vuelosCAT21.Count)
                {
                    if (CB_CAT21.Checked == true)
                    {
                        if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {

                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_plane);
                            if (listaCAT21[vuelosCAT21[j]].ECAT == "Surface emergency vehicle" || listaCAT21[vuelosCAT21[j]].ECAT == "Surface service vehicle." || listaCAT21[vuelosCAT21[j]].ECAT == "Fixed ground or tethered obstruction.")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_pushback);
                                overlay.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_plane);
                                overlay.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[vuelosCAT21[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded); }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[vuelosCAT21[j]].TargetAdress_real); }
                            else if (listaCAT21[vuelosCAT21[j]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[vuelosCAT21[j]].TrackNumber_number); }
                        }

                        if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_plane);
                            if (listaCAT21[vuelosCAT21[j]].ECAT == "Surface emergency vehicle" || listaCAT21[vuelosCAT21[j]].ECAT == "Surface service vehicle." || listaCAT21[vuelosCAT21[j]].ECAT == "Fixed ground or tethered obstruction.")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_plane);
                                overlay.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_pushback);
                                overlay.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[vuelosCAT21[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded); }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[vuelosCAT21[j]].TargetAdress_real); }
                            else if (listaCAT21[vuelosCAT21[j]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[vuelosCAT21[j]].TrackNumber_number); }
                        }
                    }

                    j = j + 1;
                }
            }

            if (vuelosCAT21v23.Count > 0) // Plot lista CAT21v23
            {
                int j = 0;
                while (j < vuelosCAT21v23.Count)
                {
                    if (cb_CAT21v23.Checked == true)
                    {
                        if (listaCAT21v23[vuelosCAT21v23[j]].PositioninWGS_coordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane); // Genero el marker (no me deja hacerlo de otra manera)
                            if (listaCAT21v23[vuelosCAT21v23[j]].ECAT == "surface emergency vehicle " || listaCAT21v23[vuelosCAT21v23[j]].ECAT == "surface service vehicle" || listaCAT21v23[vuelosCAT21v23[j]].ECAT == "fixed ground or tethered obstruction")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_pushback);
                            }
                            else { marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane); }

                            overlay.Markers.Add(marker);

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification_decoded); }
                            else if (listaCAT21v23[vuelosCAT21v23[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21v23[vuelosCAT21v23[j]].TargetAdress_real); }
                        }
                    }

                    j = j + 1;
                }
            }

            return overlay;
        }
        public GMapOverlay CalcularNuevosPuntosPorNombre(double secondCounter, GMapOverlay overlay, string TargetIdentification)
        {
            List<int> vuelosCAT10 = VuelosCAT10AhoraPorNombre(secondCounter, TargetIdentification);
            List<int> vuelosCAT21 = VuelosCAT21AhoraPorNombre(secondCounter, TargetIdentification);
            List<int> vuelosCAT21v23 = VuelosCAT21v23AhoraPorNombre(secondCounter, TargetIdentification);

            if (vuelosCAT10.Count > 0) // Plot lista CAT10
            {
                int i = 0;

                while (i < vuelosCAT10.Count)
                {
                    int j = vuelosCAT10[i];

                    int SAC = listaCAT10[vuelosCAT10[i]].SAC;
                    int SIC = listaCAT10[vuelosCAT10[i]].SIC;

                    if (SAC == 0 && SIC == 7) //SMR
                    {
                        if (cb_SMR.Checked == true)
                        {
                            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesSMR(listaCAT10[vuelosCAT10[i]].Rho, listaCAT10[vuelosCAT10[i]].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_plane);
                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }

                            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[j].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[vuelosCAT10[i]].X_cartesian) * (listaCAT10[vuelosCAT10[i]].X_cartesian) + (listaCAT10[vuelosCAT10[i]].Y_cartesian) * (listaCAT10[vuelosCAT10[i]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosCAT10[i]].X_cartesian, listaCAT10[vuelosCAT10[i]].Y_cartesian);

                                double[] coordenadas = NewCoordinatesSMR(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_plane);
                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }
                        }
                    }

                    if (SAC == 0 && SIC == 107) //MLAT
                    {

                        if (cb_MLAT.Checked == true)
                        {
                            if (listaCAT10[vuelosCAT10[i]].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesMLAT(listaCAT10[vuelosCAT10[i]].Rho, listaCAT10[vuelosCAT10[i]].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[vuelosCAT10[i]].TOT == "Ground Vehicle." || listaCAT10[vuelosCAT10[i]].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_pushback);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }

                                if (listaCAT10[vuelosCAT10[i]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[vuelosCAT10[i]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[vuelosCAT10[i]].TargetIdentification_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[vuelosCAT10[i]].TargetAdress_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }

                            if (listaCAT10[vuelosCAT10[i]].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[vuelosCAT10[i]].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[vuelosCAT10[i]].X_cartesian) * (listaCAT10[vuelosCAT10[i]].X_cartesian) + (listaCAT10[vuelosCAT10[i]].Y_cartesian) * (listaCAT10[vuelosCAT10[i]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosCAT10[i]].X_cartesian, listaCAT10[vuelosCAT10[i]].Y_cartesian);

                                double[] coordenadas = NewCoordinatesMLAT(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[i].TOT == "Ground Vehicle." || listaCAT10[vuelosCAT10[i]].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_pushback);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }

                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[vuelosCAT10[i]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[vuelosCAT10[i]].TargetIdentification_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[vuelosCAT10[i]].TargetAdress_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }
                        }
                    }
                    i = i + 1;
                }
            }

            if (listaCAT21.Count > 0) // plot lista CAT21
            {
                int j = 0;
                while (j < vuelosCAT21.Count)
                {
                    if (CB_CAT21.Checked == true)
                    {
                        if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {

                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_plane);
                            if (listaCAT21[vuelosCAT21[j]].ECAT == "Surface emergency vehicle" || listaCAT21[vuelosCAT21[j]].ECAT == "Surface service vehicle." || listaCAT21[vuelosCAT21[j]].ECAT == "Fixed ground or tethered obstruction.")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_pushback);
                                overlay.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_plane);
                                overlay.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[vuelosCAT21[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded); }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[vuelosCAT21[j]].TargetAdress_real); }
                            else if (listaCAT21[vuelosCAT21[j]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[vuelosCAT21[j]].TrackNumber_number); }
                        }

                        if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_plane);
                            if (listaCAT21[vuelosCAT21[j]].ECAT == "Surface emergency vehicle" || listaCAT21[vuelosCAT21[j]].ECAT == "Surface service vehicle." || listaCAT21[vuelosCAT21[j]].ECAT == "Fixed ground or tethered obstruction.")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_plane);
                                overlay.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_pushback);
                                overlay.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[vuelosCAT21[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded); }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[vuelosCAT21[j]].TargetAdress_real); }
                            else if (listaCAT21[vuelosCAT21[j]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[vuelosCAT21[j]].TrackNumber_number); }
                        }
                    }

                    j = j + 1;
                }
            }

            if (vuelosCAT21v23.Count > 0) // Plot lista CAT21v23
            {
                int j = 0;
                while (j < vuelosCAT21v23.Count)
                {
                    if (cb_CAT21v23.Checked == true)
                    {
                        if (listaCAT21v23[vuelosCAT21v23[j]].PositioninWGS_coordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane); // Genero el marker (no me deja hacerlo de otra manera)
                            if (listaCAT21v23[vuelosCAT21v23[j]].ECAT == "surface emergency vehicle " || listaCAT21v23[vuelosCAT21v23[j]].ECAT == "surface service vehicle" || listaCAT21v23[vuelosCAT21v23[j]].ECAT == "fixed ground or tethered obstruction")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_pushback);
                            }
                            else { marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane); }

                            overlay.Markers.Add(marker);
                            //var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane);
                            //overlay.Markers.Add(marker);

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification_decoded); }
                            else if (listaCAT21v23[vuelosCAT21v23[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21v23[vuelosCAT21v23[j]].TargetAdress_real); }
                        }
                    }

                    j = j + 1;
                }
            }

            return overlay;
        }

        public GMapOverlay CalcularNuevosPuntos_DiubujarBola(double secondCounter, GMapOverlay overlay)
        {
            List<int> vuelosCAT10 = VuelosCAT10Ahora(secondCounter); // Lista de vuelos en CAT10 con ese tiempo
            List<int> vuelosCAT21 = VuelosCAT21Ahora(secondCounter); // Lista de vuelos en CAT21 con ese tiempo
            List<int> vuelosCAT21v23 = VuelosCAT21v23Ahora(secondCounter); // Lista de vuelos en CAT21v23 con ese tiempo

            if (vuelosCAT10.Count > 0) // Plot lista CAT10
            {
                int i = 0;

                while (i < vuelosCAT10.Count)
                {
                    int j = vuelosCAT10[i];

                    int SAC = listaCAT10[vuelosCAT10[i]].SAC;
                    int SIC = listaCAT10[vuelosCAT10[i]].SIC;

                    if (SAC == 0 && SIC == 7) //SMR
                    {
                        if (cb_SMR.Checked == true)
                        {
                            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesSMR(listaCAT10[vuelosCAT10[i]].Rho, listaCAT10[vuelosCAT10[i]].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_circle);
                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }

                            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[j].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[vuelosCAT10[i]].X_cartesian) * (listaCAT10[vuelosCAT10[i]].X_cartesian) + (listaCAT10[vuelosCAT10[i]].Y_cartesian) * (listaCAT10[vuelosCAT10[i]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosCAT10[i]].X_cartesian, listaCAT10[vuelosCAT10[i]].Y_cartesian);

                                double[] coordenadas = NewCoordinatesSMR(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), white_circle);
                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }
                        }
                    }

                    if (SAC == 0 && SIC == 107) //MLAT
                    {

                        if (cb_MLAT.Checked == true)
                        {
                            if (listaCAT10[vuelosCAT10[i]].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
                            {
                                double[] coordenadas = NewCoordinatesMLAT(listaCAT10[vuelosCAT10[i]].Rho, listaCAT10[vuelosCAT10[i]].Theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[vuelosCAT10[i]].TOT == "Ground Vehicle." || listaCAT10[vuelosCAT10[i]].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_circle);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_circle);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }



                                if (listaCAT10[vuelosCAT10[i]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[vuelosCAT10[i]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[vuelosCAT10[i]].TargetIdentification_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[vuelosCAT10[i]].TargetAdress_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }

                            if (listaCAT10[vuelosCAT10[i]].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[vuelosCAT10[i]].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
                            {
                                double rho = Math.Sqrt((listaCAT10[vuelosCAT10[i]].X_cartesian) * (listaCAT10[vuelosCAT10[i]].X_cartesian) + (listaCAT10[vuelosCAT10[i]].Y_cartesian) * (listaCAT10[vuelosCAT10[i]].Y_cartesian));
                                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[vuelosCAT10[i]].X_cartesian, listaCAT10[vuelosCAT10[i]].Y_cartesian);

                                double[] coordenadas = NewCoordinatesMLAT(rho, theta);
                                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_plane);

                                if (listaCAT10[i].TOT == "Ground Vehicle." || listaCAT10[vuelosCAT10[i]].Mode3ACodeinOctal.Length == 0)
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_circle);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), blue_circle);
                                    overlay.Markers.Add(marker);
                                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                }

                                overlay.Markers.Add(marker);

                                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                                if (listaCAT10[vuelosCAT10[i]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT10[vuelosCAT10[i]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT10[vuelosCAT10[i]].TargetIdentification_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TargetAdress.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT10[vuelosCAT10[i]].TargetAdress_decoded); }
                                else if (listaCAT10[vuelosCAT10[i]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT10[vuelosCAT10[i]].Tracknumber_value); }
                            }
                        }
                    }
                    i = i + 1;
                }
            }

            if (listaCAT21.Count > 0) // plot lista CAT21
            {
                int j = 0;
                while (j < vuelosCAT21.Count)
                {
                    if (CB_CAT21.Checked == true)
                    {
                        if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {

                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_plane);
                            if (listaCAT21[vuelosCAT21[j]].ECAT == "Surface emergency vehicle" || listaCAT21[vuelosCAT21[j]].ECAT == "Surface service vehicle." || listaCAT21[vuelosCAT21[j]].ECAT == "Fixed ground or tethered obstruction." )
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_circle);
                                overlay.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84_HR, listaCAT21[vuelosCAT21[j]].lonWGS84_HR), green_circle);
                                overlay.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[vuelosCAT21[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded); }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[vuelosCAT21[j]].TargetAdress_real); }
                            else if (listaCAT21[vuelosCAT21[j]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[vuelosCAT21[j]].TrackNumber_number); }
                        }

                        if (listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[vuelosCAT21[j]].PositioninWGS_HRcoordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_plane);
                            if (listaCAT21[vuelosCAT21[j]].ECAT == "Surface emergency vehicle" || listaCAT21[vuelosCAT21[j]].ECAT == "Surface service vehicle." || listaCAT21[vuelosCAT21[j]].ECAT == "Fixed ground or tethered obstruction." )
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_circle);
                                overlay.Markers.Add(marker);
                            }
                            else
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21[vuelosCAT21[j]].latWGS84, listaCAT21[vuelosCAT21[j]].lonWGS84), green_circle);
                                overlay.Markers.Add(marker);
                            }

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21[vuelosCAT21[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21[vuelosCAT21[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21[vuelosCAT21[j]].TargetIdentification_decoded); }
                            else if (listaCAT21[vuelosCAT21[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21[vuelosCAT21[j]].TargetAdress_real); }
                            else if (listaCAT21[vuelosCAT21[j]].TrackNumber.Length > 0) { marker.ToolTipText = string.Concat("Track Number: ", listaCAT21[vuelosCAT21[j]].TrackNumber_number); }
                        }
                    }

                    j = j + 1;
                }
            }

            if (vuelosCAT21v23.Count > 0) // Plot lista CAT21v23
            {
                int j = 0;
                while (j < vuelosCAT21v23.Count)
                {
                    if (cb_CAT21v23.Checked == true)
                    {
                        if (listaCAT21v23[vuelosCAT21v23[j]].PositioninWGS_coordinates.Length > 0)
                        {
                            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane); // Genero el marker (no me deja hacerlo de otra manera)
                            if (listaCAT21v23[vuelosCAT21v23[j]].ECAT == "surface emergency vehicle " || listaCAT21v23[vuelosCAT21v23[j]].ECAT == "surface service vehicle" || listaCAT21v23[vuelosCAT21v23[j]].ECAT == "fixed ground or tethered obstruction")
                            {
                                marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_circle);
                            }
                            else { marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_circle); }

                            overlay.Markers.Add(marker);
                            //var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[vuelosCAT21v23[j]].latWGS84, listaCAT21v23[vuelosCAT21v23[j]].lonWGS84), red_plane);
                            //overlay.Markers.Add(marker);

                            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                            if (listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification.Length > 0 && Convert.ToInt64(listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification, 2) > 1) { marker.ToolTipText = string.Concat("Target Identification: ", listaCAT21v23[vuelosCAT21v23[j]].TargetIdentification_decoded); }
                            else if (listaCAT21v23[vuelosCAT21v23[j]].TargetAddress_bin.Length > 0) { marker.ToolTipText = string.Concat("Target Address: ", listaCAT21v23[vuelosCAT21v23[j]].TargetAdress_real); }
                        }
                    }

                    j = j + 1;
                }
            }

            return overlay;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



















        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //// creamos un overlay solo para el load
        //GMapOverlay overlayLoad = new GMapOverlay();

        //// Ploteamos todos los puntos que tengamos

        //if (listaCAT10.Count > 0) // Plot lista CAT10
        //{
        //    int j = 0;
        //    while (j < listaCAT10.Count)
        //    {
        //        int SAC = listaCAT10[j].SAC;
        //        int SIC = listaCAT10[j].SIC;

        //        if (SAC == 0 && SIC == 7) //SMR
        //        {
        //            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
        //            {
        //                double[] coordenadas = NewCoordinatesSMR(listaCAT10[j].Rho, listaCAT10[j].Theta);
        //                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), GMarkerGoogleType.blue_dot);
        //                overlayLoad.Markers.Add(marker);
        //            }

        //            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[j].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
        //            {
        //                double rho = Math.Sqrt((listaCAT10[j].X_cartesian) * (listaCAT10[j].X_cartesian) + (listaCAT10[j].Y_cartesian) * (listaCAT10[j].Y_cartesian));
        //                double theta = (180 / Math.PI) * Math.Atan2(listaCAT10[j].X_cartesian, listaCAT10[j].Y_cartesian);

        //                double[] coordenadas = NewCoordinatesSMR(rho, theta);
        //                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), GMarkerGoogleType.blue_dot);
        //                overlayLoad.Markers.Add(marker);
        //            }
        //        }

        //        if (SAC == 0 && SIC == 107) //MLAT
        //        {
        //            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length > 0) // si tenemos coordenadas polares
        //            {
        //                double[] coordenadas = NewCoordinates(listaCAT10[j].X_cartesian, listaCAT10[j].Y_cartesian, LatMLAT, LonMLAT);
        //                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), GMarkerGoogleType.blue_dot);
        //                overlayLoad.Markers.Add(marker);
        //            }

        //            if (listaCAT10[j].MeasuredPositioninPolarCoordinates.Length == 0 && listaCAT10[j].PositioninCartesianCoordinates.Length > 0) // si no tenemos coordenadas polares pero si coordenadas cartesianas
        //            {
        //                double rho = Math.Sqrt((listaCAT10[j].X_cartesian) * (listaCAT10[j].X_cartesian) + (listaCAT10[j].Y_cartesian) * (listaCAT10[j].Y_cartesian));
        //                double theta = (180 / Math.PI) * Math.Atan2( listaCAT10[j].X_cartesian, listaCAT10[j].Y_cartesian);

        //                double[] coordenadas = NewCoordinatesMLAT(rho, theta);
        //                var marker = new GMarkerGoogle(new PointLatLng(coordenadas[0], coordenadas[1]), GMarkerGoogleType.blue_dot);
        //                overlayLoad.Markers.Add(marker);
        //            }
        //        }

        //        j = j + 1;
        //    }
        //}

        //if (listaCAT21.Count > 0) // plot lista CAT21
        //{
        //    int j = 0;
        //    while (j < listaCAT21.Count)
        //    {
        //        if (listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
        //        {
        //            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84_HR, listaCAT21[j].lonWGS84_HR), GMarkerGoogleType.green_dot);
        //            overlayLoad.Markers.Add(marker);
        //        }

        //        if (listaCAT21[j].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
        //        {
        //            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84, listaCAT21[j].lonWGS84), GMarkerGoogleType.green_dot);
        //            overlayLoad.Markers.Add(marker);
        //        }

        //        j = j + 1;
        //    }
        //}

        //if (listaCAT21v23.Count > 0) // Plot lista CAT21v23
        //{
        //    int j = 0;
        //    while (j < listaCAT21v23.Count)
        //    {
        //        if (listaCAT21v23[j].PositioninWGS_coordinates.Length > 0)
        //        {
        //            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21v23[j].latWGS84, listaCAT21v23[j].lonWGS84), GMarkerGoogleType.red_dot);
        //            overlayLoad.Markers.Add(marker);
        //        }

        //        j = j + 1;
        //    }
        //}

        //Mapa.Overlays.Add(overlayLoad);


        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //    // calculamos las listas de paquetes y vuelos y tiempos para cada categoria

        //    if(listaCAT21.Count>0)
        //    {
        //        List<int> listavuelosCAT21 = new List<int>();

        //        // Añadimos la primera posicion a la lista:
        //        double sec = Math.Round(Convert.ToDouble(listaCAT21[0].TimeofASTERIXReportTransmission_seconds));
        //        listasecondsCAT21.Add(sec);

        //        // recorremos listaCAT21 buscando todos los paquetes con ese tiempo
        //        int i = 0;
        //        while (i < listaCAT21.Count)
        //        {
        //            double sec1 = Math.Round(Convert.ToDouble(listaCAT21[i].TimeofASTERIXReportTransmission_seconds));
        //            if (sec1 == sec) { listavuelosCAT21.Add(i); }
        //            i = i + 1;
        //        }
        //        lista_listavionesCAT21.Add(listavuelosCAT21);


        //        i = 0;
        //        while (i < listaCAT21.Count) // recorremos toda la listaCAT21
        //        {
        //            sec = Math.Round(Convert.ToDouble(listaCAT21[i].TimeofASTERIXReportTransmission_seconds)); // sacamos tiempo de ese paquete
        //            if (sec > listasecondsCAT21[listasecondsCAT21.Count - 1]) // es mayor que el alterior de la lista? Lo añadimos
        //            {
        //                List<int> listavuelos1 = new List<int>();
        //                listasecondsCAT21.Add(sec);

        //                int j = 0;
        //                // hemos encontrado un nuevo segundo, ahora recomrremos listaCAT21 buscando los paquetes con ese tiempo.
        //                while (j < listaCAT21.Count)
        //                {
        //                    double sec1 = Math.Round(Convert.ToDouble(listaCAT21[j].TimeofASTERIXReportTransmission_seconds));
        //                    if (sec1 == sec) { listavuelos1.Add(j); }
        //                    j = j + 1;
        //                }
        //                lista_listavionesCAT21.Add(listavuelos1);
        //            }
        //            i = i + 1;

        //        }
        //    }

        //    if(listaCAT21v23.Count>0)
        //    {
        //        List<int> listavuelosCAT21v23 = new List<int>();

        //        // Añadimos la primera posicion a la lista:
        //        double sec = Math.Round(Convert.ToDouble(listaCAT21v23[0].TimeofDay_seconds));
        //        listasecondsCAT21v23.Add(sec);

        //        // recorremos listaCAT21 buscando todos los paquetes con ese tiempo
        //        int i = 0;
        //        while (i < listaCAT21v23.Count)
        //        {
        //            double sec1 = Math.Round(Convert.ToDouble(listaCAT21v23[i].TimeofDay_seconds));
        //            if (sec1 == sec) { listavuelosCAT21v23.Add(i); }
        //            i = i + 1;
        //        }
        //        lista_listavionesCAT21v23.Add(listavuelosCAT21v23);


        //        i = 0;
        //        while (i < listaCAT21v23.Count) // recorremos toda la listaCAT21
        //        {
        //            sec = Math.Round(Convert.ToDouble(listaCAT21v23[i].TimeofDay_seconds)); // sacamos tiempo de ese paquete
        //            if (sec > listasecondsCAT21v23[listasecondsCAT21v23.Count-1]) // es mayor que el alterior de la lista? Lo añadimos
        //            {
        //                List<int> listavuelos1 = new List<int>();
        //                listasecondsCAT21v23.Add(sec);

        //                int j = 0;
        //                // hemos encontrado un nuevo segundo, ahora recomrremos listaCAT21 buscando los paquetes con ese tiempo.
        //                while (j < listaCAT21v23.Count)
        //                {
        //                    double sec1 = Math.Round(Convert.ToDouble(listaCAT21v23[j].TimeofDay_seconds));
        //                    if (sec1 == sec) { listavuelos1.Add(j); }
        //                    j = j + 1;
        //                }
        //                lista_listavionesCAT21v23.Add(listavuelos1);
        //            }
        //            i = i + 1;
        //        }
        //    }

        //    if (listaCAT10.Count > 0)
        //    {
        //        List<int> listavuelosCAT10 = new List<int>();

        //        // Añadimos la primera posicion a la lista:
        //        double sec = Math.Round(Convert.ToDouble(listaCAT10[0].TimeofDay_seconds));
        //        listasecondsCAT10.Add(sec);

        //        // recorremos listaCAT21 buscando todos los paquetes con ese tiempo
        //        int i = 0;
        //        while (i < listaCAT10.Count)
        //        {
        //            double sec1 = Math.Round(Convert.ToDouble(listaCAT10[i].TimeofDay_seconds));
        //            if (sec1 == sec) { listavuelosCAT10.Add(i); }
        //            i = i + 1;
        //        }
        //        lista_listavionesCAT10.Add(listavuelosCAT10);


        //        i = 0;
        //        while (i < listaCAT10.Count) // recorremos toda la listaCAT21
        //        {
        //            sec = Math.Round(Convert.ToDouble(listaCAT10[i].TimeofDay_seconds)); // sacamos tiempo de ese paquete
        //            if (sec > listasecondsCAT10[listasecondsCAT10.Count - 1]) // es mayor que el alterior de la lista? Lo añadimos
        //            {
        //                List<int> listavuelos1 = new List<int>();
        //                listasecondsCAT10.Add(sec);

        //                int j = 0;
        //                // hemos encontrado un nuevo segundo, ahora recomrremos listaCAT21 buscando los paquetes con ese tiempo.
        //                while (j < listaCAT10.Count)
        //                {
        //                    double sec1 = Math.Round(Convert.ToDouble(listaCAT10[j].TimeofDay_seconds));
        //                    if (sec1 == sec) { listavuelos1.Add(j); }
        //                    j = j + 1;
        //                }
        //                lista_listavionesCAT10.Add(listavuelos1);
        //            }
        //            i = i + 1;
        //        }
        //    }

        //}

    }
}