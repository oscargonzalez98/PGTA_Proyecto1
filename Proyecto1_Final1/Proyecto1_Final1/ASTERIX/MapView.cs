using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using LIBRERIACLASES;

namespace ASTERIX
{
    public partial class MapView : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;

        double LatInicial = 41.2969444;
        double LongInicial = 2.0783333333333336;
        public List<CAT10> listaCAT10;
        public List<CAT20> listaCAT20;
        public List<CAT21> listaCAT21;
        public MapView(List<CAT10> listaCAT10, List<CAT20> listaCAT20, List<CAT21> listaCAT21)
        {
            this.listaCAT10 = listaCAT10;
            this.listaCAT20 = listaCAT20;
            this.listaCAT21 = listaCAT21;

            InitializeComponent();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider = GMapProviders.GoogleSatelliteMap;
            gMapControl1.Position = new PointLatLng(LatInicial, LongInicial);
            gMapControl1.MinZoom = 6;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 14;
            gMapControl1.AutoScroll = true;
            
        }


        

        private void btnTWR_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 13;
        }

        private void btn_TMA_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 11;

        }

        private void btnFIR_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 8;

        }
    }
}
