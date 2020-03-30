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

        int filaseleeccionada = 0;
        double LatInicial = 20.9688132813096;
        double LonInicial = -89.6250915527344;

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
            gMapControl1.Position = new PointLatLng(LatInicial, LonInicial);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;

            int i = 0;
            var markerOverLay = new GMapOverlay("Marcador");

            while (i<listaCAT21.Count)
            {
                if (listaCAT21[i].PositioninWGS_HRcoordinates.Length > 0)
                {
                    var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[i].latWGS84_HR, listaCAT21[i].lonWGS84_HR), GMarkerGoogleType.green);
                    markerOverLay.Markers.Add(marker);
                }

                if(listaCAT21[i].PositioninWGS_HRcoordinates.Length<1 && listaCAT21[i].PositioninWGS_HRcoordinates.Length >0)
                {
                    var marker = new GMarkerGoogle(new PointLatLng(listaCAT21[i].latWGS84, listaCAT21[i].lonWGS84), GMarkerGoogleType.green);
                    markerOverLay.Markers.Add(marker);
                }

                i = i + 1;

            }


            gMapControl1.Overlays.Add(markerOverLay);
        }

        private void gMapControl2_Load(object sender, EventArgs e)
        {

        }
    }
}
