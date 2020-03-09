using System;
using Clases;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using LibreriaClases;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<CAT10> listaCAT10 = new List<CAT10>();
            List<CAT21> listaCAT21 = new List<CAT21>();

            string path= "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/adsb_v21_bcn.ast"; // CAT21
            string path2 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/smr_160510-lebl-220001"; // SMR
            string path3 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/mlat_160510-lebl-220001"; // MLAT
            string path4 = "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/smr_mlat_160510-lebl-220001"; // SMR + MLAT;


            Fichero newfichero = new Fichero(path1);
            newfichero.leer();




            listaCAT21 = newfichero.GetListCAT21(); // devuelve lista de clases CAT21, cada una con un paquete



            ///// esto ira dentro de un while (al final no, pero no tocar)
            //CAT21 newCAT21 = listaCAT21[2];
            //string[] paquete = newCAT21.paquete;
            //newCAT21.Calculate_FSPEC(paquete);
            //int i = 1;



        }
    }
}
