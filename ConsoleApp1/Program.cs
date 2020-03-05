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

            string path= "C:/Users/oscar/Desktop/PGTA_Proyecto1/ConsoleApp1/adsb_v21_bcn.ast";
            Fichero newFichero = new Fichero(path);
            newFichero.leer();
            listaCAT21=newFichero.GetListCAT21(); // devuelve lista de clases CAT21, cada una con un paquete

            

            ///// esto ira dentro de un while (al final no, pero no tocar)
            CAT21 newCAT21 = listaCAT21[3];
            string[] paquete = newCAT21.paquete;
            newCAT21.Calculate_FSPEC(paquete);
            int i = paquete.Length;
            string FSPEC=newCAT21.Calculate_FSPEC(paquete);


            i = 1;



        }
    }
}
