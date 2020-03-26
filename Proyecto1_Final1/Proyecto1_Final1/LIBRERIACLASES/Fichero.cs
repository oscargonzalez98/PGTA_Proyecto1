using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;



namespace LIBRERIACLASES
{
    public class Fichero
    {
        string path;
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT20> listaCAT20 = new List<CAT20>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT20 = new DataTable();
        DataTable tablaCAT21 = new DataTable();


        public Fichero(string nombre)
        {
            this.path = nombre;
        }

        public List<CAT10> getListCAT10()
        {
            return listaCAT10;
        }

        public List<CAT20> GetListCAT20()
        {
            return listaCAT20;
        }

        public List<CAT21> GetListCAT21()
        {
            return listaCAT21;
        }
        public void leer()
        {

            //StreamReader fichero = new StreamReader(path);
            //string linea_1 = fichero.ReadLine();
            byte[] fileBytes = File.ReadAllBytes(path);
            List<byte[]> listabyte = new List<byte[]>();
            int i = 0;
            int contador = fileBytes[2];
            //int length = 0;

            while (i < fileBytes.Length)
            {
                byte[] array = new byte[contador];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = fileBytes[i];
                    i++;
                }
                listabyte.Add(array);
                //length += array.Length;
                if (i + 2 < fileBytes.Length)
                {
                    contador = fileBytes[i + 2];
                }


            }


            List<string[]> listahex = new List<string[]>();
            for (int x = 0; x < listabyte.Count; x++)
            {
                byte[] buffer = listabyte[x];
                string[] arrayhex = new string[buffer.Length];
                for (int y = 0; y < buffer.Length; y++)
                {
                    arrayhex[y] = buffer[y].ToString("X");
                    if (arrayhex[y].Length != 2)
                    {
                        arrayhex[y] = String.Concat("0", arrayhex[y]);
                    }
                }
                listahex.Add(arrayhex);
            }

            for (int q = 0; q < listahex.Count; q++)
            {
                string[] arraystring = listahex[q];
                int CAT = int.Parse(arraystring[0], System.Globalization.NumberStyles.HexNumber);

                if (CAT == 10)
                {
                    try
                    {
                        CAT10 newcat10 = new CAT10(arraystring);
                        newcat10.Calculate_FSPEC(newcat10.paquete);
                        listaCAT10.Add(newcat10);

                    }
                    catch
                    {
                        Console.WriteLine(q);
                        Console.ReadKey();
                    }


                }

                if (CAT == 20)
                {
                    try
                    {
                        CAT20 newcat20 = new CAT20(arraystring);
                        listaCAT20.Add(newcat20);

                    }
                    catch
                    {
                        Console.WriteLine(q);
                        Console.ReadKey();
                    }


                }

                if (CAT == 21)
                {
                    //try
                    //{

                    CAT21 newcat21 = new CAT21(arraystring);
                    newcat21.Calculate_FSPEC(newcat21.paquete);
                    listaCAT21.Add(newcat21);

                    //tablaCAT21.Rows.Add(a1, b, c);
                    //}
                    //catch
                    //{
                    //    Console.WriteLine(q);
                    //    Console.ReadKey();
                    //}
                }

            }

        }

        public DataTable getTablaCAT10()
        {
            return tablaCAT10;
        }
        public DataTable getTablaCAT20()
        {
            return tablaCAT20;
        }
        public DataTable getTablaCAT21()
        {
            return tablaCAT21;
        }

    }
}
 
