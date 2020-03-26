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
    public partial class DataAgesCAT21 : Form
    {
        public List<CAT10> listaCAT10 = new List<CAT10>();
        public List<CAT20> listaCAT20 = new List<CAT20>();
        public List<CAT21> listaCAT21 = new List<CAT21>();
        int i;

        public DataAgesCAT21(List<CAT21> listaCAT21, int i)
        {
            InitializeComponent();
            this.listaCAT21 = listaCAT21;
            this.i = i;
        }

        private void DataAgesCAT21_Load(object sender, EventArgs e)
        {
            if(listaCAT21[i].AOS != -1) { lbAOS.Text = listaCAT21[i].AOS.ToString(); }
            else { lbAOS.Text = "No info."; }

            if (listaCAT21[i].TRD != -1) { lbTRD.Text = listaCAT21[i].TRD.ToString(); }
            else { lbTRD.Text = "No info."; }

            if (listaCAT21[i].M3A != -1) { lbM3A.Text = listaCAT21[i].M3A.ToString(); }
            else { lbM3A.Text = "No info."; }

            if (listaCAT21[i].QI != -1) { lbQI.Text = listaCAT21[i].QI.ToString(); }
            else { lbQI.Text = "No info."; }

            if (listaCAT21[i].TI != -1) { lbTI.Text = listaCAT21[i].TI.ToString(); }
            else { lbTI.Text = "No info."; }

            if (listaCAT21[i].MAM != -1) { lbMAM.Text = listaCAT21[i].MAM.ToString(); }
            else { lbMAM.Text = "No info."; }

            if (listaCAT21[i].GH != -1) { lbGH.Text = listaCAT21[i].GH.ToString(); }
            else { lbGH.Text = "No info."; }

            if (listaCAT21[i].FL != -1) { lbFL.Text = listaCAT21[i].FL.ToString(); }
            else { lbFL.Text = "No info."; }

            if (listaCAT21[i].ISA != -1) { lbISA.Text = listaCAT21[i].ISA.ToString(); }
            else { lbISA.Text = "No info."; }

            if (listaCAT21[i].FSA != -1) { lbFSA.Text = listaCAT21[i].FSA.ToString(); }
            else { lbFSA.Text = "No info."; }

            if (listaCAT21[i].AS != -1) { lbAS.Text = listaCAT21[i].AS.ToString(); }
            else { lbAS.Text = "No info."; }

            if (listaCAT21[i].TAS != -1) { lbTAS.Text = listaCAT21[i].TAS.ToString(); }
            else { lbTAS.Text = "No info."; }

            if (listaCAT21[i].MH != -1) { lbMH.Text = listaCAT21[i].MH.ToString(); }
            else { lbMH.Text = "No info."; }

            if (listaCAT21[i].BVR != -1) { lbBVR.Text = listaCAT21[i].BVR.ToString(); }
            else { lbBVR.Text = "No info."; }

            if (listaCAT21[i].GVR != -1) { lbGVR.Text = listaCAT21[i].GVR.ToString(); }
            else { lbGVR.Text = "No info."; }

            if (listaCAT21[i].GV != -1) { lbGV.Text = listaCAT21[i].GV.ToString(); }
            else { lbGV.Text = "No info."; }

            if (listaCAT21[i].TAR != -1) { lbTAR.Text = listaCAT21[i].TAR.ToString(); }
            else { lbTAR.Text = "No info."; }

            if (listaCAT21[i].TI_DA != -1) { lbTI1.Text = listaCAT21[i].TI_DA.ToString(); }
            else { lbTI1.Text = "No info."; }

            if (listaCAT21[i].TS_DA != -1) { lbTS.Text = listaCAT21[i].TS_DA.ToString(); }
            else { lbTS.Text = "No info."; }

            if (listaCAT21[i].MET != -1) { lbMET.Text = listaCAT21[i].MET.ToString(); }
            else { lbMET.Text = "No info."; }

            if (listaCAT21[i].ROA != -1) { lbROA.Text = listaCAT21[i].ROA.ToString(); }
            else { lbROA.Text = "No info."; }

            if (listaCAT21[i].ARA != -1) { lbARA.Text = listaCAT21[i].ARA.ToString(); }
            else { lbARA.Text = "No info."; }

            if (listaCAT21[i].SCC != -1) { lbSCC.Text = listaCAT21[i].SCC.ToString(); }
            else { lbSCC.Text = "No info."; }
        }
    }
}
