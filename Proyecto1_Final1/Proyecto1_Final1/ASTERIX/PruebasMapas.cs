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
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        List<List<int>> lista_listaviones = new List<List<int>>();
        List<double> listaseconds = new List<double>();
        List<int> listavuelos = new List<int>();
        int counter;

        public int filaseleeccionada = 0;
        public double LatInicial;
        public double LonInicial;


        public PruebasMapas(List<CAT10> listaCAT10, List<CAT20> listaCAT20, List<CAT21> listaCAT21)
        {
            InitializeComponent();
            this.listaCAT10 = listaCAT10;
            this.listaCAT21 = listaCAT21;
        }

        private void PruebasMapas_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(41.302505, 2.072210);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 4;

            var markerOverLay = new GMapOverlay("Marcador");


            int j = 0;
            while (j < listaCAT21.Count)
            {

                if (listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
                {
                    var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84_HR, listaCAT21[j].lonWGS84_HR), GMarkerGoogleType.green);
                    markerOverLay.Markers.Add(marker);
                }

                if (listaCAT21[j].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
                {
                    var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[j].latWGS84, listaCAT21[j].lonWGS84), GMarkerGoogleType.green);
                    markerOverLay.Markers.Add(marker);
                }
                j = j + 1;
            }
            gMapControl1.Overlays.Add(markerOverLay);

            //// Añadimos la primera posicion a la lista:
            //double sec = Math.Round(listaCAT21[0].TimeofMessageReception_Position_seconds);
            //listaseconds.Add(sec);

            //// recorremos listaCAT21 buscando todos los paquetes con ese tiempo
            //int i = 0;
            //while (i < listaCAT21.Count)
            //{
            //    double sec1 = Math.Round(listaCAT21[i].TimeofMessageReception_Position_seconds);
            //    if (sec1 == sec) { listavuelos.Add(i); }
            //    i = i + 1;
            //}
            //lista_listaviones.Add(listavuelos);


            //i = 0;
            //while(i<listaCAT21.Count) // recorremos toda la listaCAT21
            //{
            //    sec = Math.Round(listaCAT21[i].TimeofMessageReception_Position_seconds); // sacamos tiempo de ese paquete
            //    if(sec>listaseconds[listaseconds.Count-1]) // es mayot que el alterior de la lista? Lo añadimos
            //    {
            //        List<int> listavuelos1 = new List<int>();
            //        listaseconds.Add(sec);

            //        int j = 0;
            //        // hemos encontrado un nuevo segundo, ahora recomrremos listaCAT21 buscando los paquetes con ese tiempo.
            //        while (j < listaCAT21.Count)
            //        {
            //            double sec1 = Math.Round(listaCAT21[j].TimeofMessageReception_Position_seconds);
            //            if (sec1 == sec) { listavuelos1.Add(j); }
            //            j = j + 1;
            //        }
            //        lista_listaviones.Add(listavuelos1);
            //    }
            //    i = i + 1;

            //}

            //counter = Convert.ToInt32(listaseconds[0]);
            //int a = 0;


            //gMapControl1.DragButton = MouseButtons.Left;
            //gMapControl1.CanDragMap = true;
            //gMapControl1.MapProvider = GMapProviders.GoogleMap;
            //gMapControl1.Position = new PointLatLng(41.302505, 2.072210);
            //gMapControl1.MinZoom = 0;
            //gMapControl1.MaxZoom = 24;
            //gMapControl1.Zoom = 4;
            ////gMapControl1.AutoScroll = true;

            //i = 0;
            //var markerOverLay = new GMapOverlay("Marcador");

            //while (i < listaCAT21.Count)
            //{
            //    if (listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0)
            //    {
            //        var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[i].latWGS84_HR, listaCAT21[i].lonWGS84_HR), GMarkerGoogleType.green);
            //        markerOverLay.Markers.Add(marker);
            //    }

            //    if (listaCAT21[i].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0)
            //    {
            //        var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[i].latWGS84, listaCAT21[i].lonWGS84), GMarkerGoogleType.green);
            //        markerOverLay.Markers.Add(marker);
            //    }

            //    i = i + 1;

            //}


            //gMapControl1.Overlays.Add(markerOverLay);
        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }

        private void btPlay_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //// buscamos si el counter de segundos es igual que un valor dentro de la lista de segundos

            //int i = 0;
            //bool booleano = false;
            //while (i < listaseconds.Count)
            //{
            //    if (listaseconds[i] == counter)
            //    {
            //        booleano=true;
            //        break;
            //    }
            //    i = i + 1;
            //}

            //// si lo hemos encontrado

            //if (booleano == true)
            //{
            //    gMapControl1.DragButton = MouseButtons.Left;
            //    gMapControl1.CanDragMap = true;
            //    gMapControl1.MapProvider = GMapProviders.GoogleMap;
            //    gMapControl1.Position = new PointLatLng(41.302505, 2.072210);
            //    gMapControl1.MinZoom = 0;
            //    gMapControl1.MaxZoom = 24;
            //    gMapControl1.Zoom = 4;

            //    var markerOverLay = new GMapOverlay("Marcador");


            //    var listadevuelos = lista_listaviones[i];

            //    int j = 0;
            //    while (j < listavuelos.Count)
            //    {

            //        if (listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0)
            //        {
            //            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[listadevuelos[j]].latWGS84_HR, listaCAT21[listadevuelos[j]].lonWGS84_HR), GMarkerGoogleType.green);
            //            markerOverLay.Markers.Add(marker);
            //        }

            //        if (listaCAT21[j].PositioninWGS_HRcoordinates.Length < 1 && listaCAT21[j].PositioninWGS_HRcoordinates.Length > 0)
            //        {
            //            var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[listadevuelos[j]].latWGS84, listaCAT21[listadevuelos[j]].lonWGS84), GMarkerGoogleType.green);
            //            markerOverLay.Markers.Add(marker);
            //        }
            //        j = j + 1;
            //    }
            //    gMapControl1.Overlays.Clear();
            //    gMapControl1.Overlays.Add(markerOverLay);


            //}

            //counter = counter + 1;
        }
    }
}
