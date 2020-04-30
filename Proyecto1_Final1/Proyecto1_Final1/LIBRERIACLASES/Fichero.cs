using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Clases;
using LIBRERIACLASES;



namespace LIBRERIACLASES
{
    public class Fichero
    {
        string path;
        List<CAT10> listaCAT10 = new List<CAT10>();
        List<CAT20> listaCAT20 = new List<CAT20>();
        List<CAT21> listaCAT21 = new List<CAT21>();
        List<CAT21v23> listaCAT21v23 = new List<CAT21v23>();
        DataTable tablaCAT10 = new DataTable();
        DataTable tablaCAT20 = new DataTable();
        DataTable tablaCAT21 = new DataTable();

        int SAC = 0;
        int SIC = 0;

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

        public List<CAT21v23> GetListCAT21v23()
        {
            return listaCAT21v23;
        }

        public string AddZeros(string octeto)
        {
            while (octeto.Length < 8)
            {
                octeto = octeto.Insert(0, "0");
            }
            return octeto;
        }

        public void Calculate_DataSourceIdentification(string paquete)
        {
            string string1 = paquete.Substring(0, 8);
            string string2 = paquete.Substring(8, 8);

            SAC = Convert.ToInt32(string1, 2);
            SIC = Convert.ToInt32(string2, 2);
        }
        public void leer()
        {

            byte[] fileBytes = File.ReadAllBytes(path);
            List<byte[]> listabyte = new List<byte[]>();
            int i = 0;
            int contador = fileBytes[2];

            while (i < fileBytes.Length)
            {
                byte[] array = new byte[contador];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = fileBytes[i];
                    i++;
                }
                listabyte.Add(array);
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


                if (CAT == 21)
                {

                    string FSPEC = "";

                    int j = 3;
                    bool found = false;

                    while (found == false)
                    {
                        FSPEC = Convert.ToString(Convert.ToInt32(arraystring[j], 16), 2);// Convertir de hex a binario paquete [3]
                        FSPEC = AddZeros(FSPEC);

                        if (Char.ToString(FSPEC[FSPEC.Length - 1]) == "1")
                        {
                            while (Char.ToString(FSPEC[FSPEC.Length - 1]) != "0")
                            {
                                j = j + 1;
                                string parte2 = Convert.ToString(Convert.ToInt32(arraystring[j], 16), 2);
                                parte2 = AddZeros(parte2);

                                FSPEC = String.Concat(FSPEC, parte2);
                            }

                            found = true;
                        }

                        found = true;
                    }

                    int data_position = 1 + 2 + ((FSPEC.Length) / 8);

                    string string1 = Convert.ToString(arraystring[data_position]);
                    string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string1 = AddZeros(string1);

                    string string2 = Convert.ToString(arraystring[data_position + 1]);
                    string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                    string2 = AddZeros(string2);

                    data_position = data_position + 2;

                    string DataSourceIdentification = String.Concat(string1, string2);

                    Calculate_DataSourceIdentification(DataSourceIdentification);

                    // ahora que sabemos que version es cada paquete los metemos en su lista correspondiente.

                    if (SAC == 20 && SIC == 219)
                    {
                        CAT21 newcat21 = new CAT21(arraystring);
                        newcat21.Calculate_FSPEC(newcat21.paquete);
                        listaCAT21.Add(newcat21);
                    }

                    if (SAC == 0 && SIC == 107)
                    {
                        CAT21v23 newcat21v23 = new CAT21v23(arraystring);
                        newcat21v23.Calculate_FSPEC(newcat21v23.paquete);
                        listaCAT21v23.Add(newcat21v23);
                    }
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
 
