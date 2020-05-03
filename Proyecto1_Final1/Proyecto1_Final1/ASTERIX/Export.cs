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
            StreamWriter f = File.CreateText(tb_direction.Text);

            // Leemos las partes del documento 
            string[] startinglines = File.ReadAllLines("img/docs/start.txt");
            string[] red_StyleMap = File.ReadAllLines("img/docs/red_StyleMap.txt");
            string[] green_StyleMap = File.ReadAllLines("img/docs/green_StyleMap.txt");
            string[] blue_StyleMap = File.ReadAllLines("img/docs/blue_StyleMap.txt");
            string[] PlaceMarks = File.ReadAllLines("img/docs/PlaceMark.txt");
            string[] end = File.ReadAllLines("img/docs/end.txt");

            // Escribimos todo en el documento
            // primera parte
            f.WriteLine(startinglines[0]);
            f.WriteLine(startinglines[1]);
            f.WriteLine(startinglines[2]);
            f.WriteLine(startinglines[3]);
            f.WriteLine(startinglines[4]);
            f.WriteLine(startinglines[5]);
            f.WriteLine(startinglines[6]);
            f.WriteLine(startinglines[7]);
            f.WriteLine(startinglines[8]);
            f.WriteLine(startinglines[9]);
            f.WriteLine(startinglines[10]);
            f.WriteLine(startinglines[11]);
            f.WriteLine(startinglines[12]);
            f.WriteLine(startinglines[13]);
            // parte StyleMap rojo
            f.WriteLine(red_StyleMap[0]);
            f.WriteLine(red_StyleMap[1]);
            f.WriteLine(red_StyleMap[2]);
            f.WriteLine(red_StyleMap[3]);
            f.WriteLine(red_StyleMap[4]);
            f.WriteLine(red_StyleMap[5]);
            f.WriteLine(red_StyleMap[6]);
            f.WriteLine(red_StyleMap[7]);
            f.WriteLine(red_StyleMap[8]);
            f.WriteLine(red_StyleMap[9]);
            f.WriteLine(red_StyleMap[10]);
            //parte StyleMap verde
            f.WriteLine(green_StyleMap[0]);
            f.WriteLine(green_StyleMap[1]);
            f.WriteLine(green_StyleMap[2]);
            f.WriteLine(green_StyleMap[3]);
            f.WriteLine(green_StyleMap[4]);
            f.WriteLine(green_StyleMap[5]);
            f.WriteLine(green_StyleMap[6]);
            f.WriteLine(green_StyleMap[7]);
            f.WriteLine(green_StyleMap[8]);
            f.WriteLine(green_StyleMap[9]);
            f.WriteLine(green_StyleMap[10]);
            // parte StyleMap azul
            f.WriteLine(blue_StyleMap[0]);
            f.WriteLine(blue_StyleMap[1]);
            f.WriteLine(blue_StyleMap[2]);
            f.WriteLine(blue_StyleMap[3]);
            f.WriteLine(blue_StyleMap[4]);
            f.WriteLine(blue_StyleMap[5]);
            f.WriteLine(blue_StyleMap[6]);
            f.WriteLine(blue_StyleMap[7]);
            f.WriteLine(blue_StyleMap[8]);
            f.WriteLine(blue_StyleMap[9]);
            f.WriteLine(blue_StyleMap[10]);


            //Parte Placemarks

            if (listaCAT21v23.Count > 0) // Plot lista CAT21v23
            {
                int j = 0;
                while (j < 100)
                {
                    if(listaCAT21v23[j].PositioninWGS_coordinates.Length>0)
                    {
                        f.WriteLine(PlaceMarks[0]);

                        string Name = "";
                        if (listaCAT21v23[j].TargetIdentification.Length > 0) { Name = "Target Identification: " + listaCAT21v23[j].TargetIdentification_decoded; }
                        if (listaCAT21v23[j].TargetIdentification.Length == 0 && listaCAT21v23[j].TargetAddress_bin.Length > 0) { Name = "Target Address: " + listaCAT21v23[j].TargetAdress_real; }

                        string NameFinal = "\t\t<name>" + Name + "</name>";

                        f.WriteLine(NameFinal);

                        string StyleMap = "stylesel_01";
                        PlaceMarks[2].Replace("stylesel_00", StyleMap);

                        f.WriteLine(PlaceMarks[2]);

                        f.WriteLine(PlaceMarks[3]);

                        string lat = listaCAT21v23[j].lonWGS84.ToString().Replace(",", ".");
                        string lon = listaCAT21v23[j].latWGS84.ToString().Replace(",", ".");
                        string alt = (listaCAT21v23[j].GeometricAltitude_ft / 3.28).ToString().Replace(",", ".");


                        string coordinates = "\t\t\t<coordinates>" + lat + "," + lon + "," + alt + "</coordinates>";
                        f.WriteLine(coordinates);

                        f.WriteLine(PlaceMarks[5]);
                        f.WriteLine(PlaceMarks[6]);
                    }

                    j = j + 1;
                }
            }

            f.WriteLine(end[0]);
            f.WriteLine(end[1]);



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
