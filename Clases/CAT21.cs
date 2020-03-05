using System;
using System.Collections.Generic;
using System.Text;
using Clases;
using LibreriaClases;

namespace Clases
{
    public class CAT21
    {
        int i = 0;
        public string[] paquete;
        public string[] arrayFSPEC;
        public string FSPEC;
        public string FSPEC_fake;
        public int data_position = 0;

        public string DataSourseIdentification="";
        public int SAC;
        public int SIC;

        public string TargetReportDescriptor = "";
        public string ATP = "";
        public string ARC = "";
        public string RC = "";
        public string RAB = "";
        public string DCR;
        public string GBS;
        public string SIM;
        public string TST;
        public string SAA;
        public string CL;
        public string IPC;
        public string NOGO;
        public string CPR;
        public string LDPJ;
        public string RCF;

        public string TrackNumber = "";
        public int TrackNumber_number;

        public string ServiceIdentification = "";
        public int ServiceIdentification_number;

        public string TimeofApplicability_Position = "";
        public double TimeofApplicability_Position_seconds;

        public string PositioninWGS_coordinates;
        public double latWGS84 = 0;
        public double lonWGS84 = 0;

        public string PositioninWGS_HRcoordinates = "";
        public double latWGS84_HR = 0;
        public double lonWGS84_HR = 0;

        public string TimeofApplicability_Velocity = "";
        public double TimeofApplicability_Velocity_seconds;

        public string AirSpeed = "";
        public string IM = "";
        public double AirSpeed_velocity;
        public double AirSpeed_Mach;

        public string AircraftOperationalStatus = "";
        public string RA = "";
        public string TC = "";
        public string TS = "";
        public string ARV = "";
        public string CDTI_A = "";
        public string TCAS = "";
        public string SA = "";



        public CAT21(string[] packet)
        {
            this.paquete = packet;
            this.SAC = SAC;
        }

        public string AddZeros(string octeto)
        {
            while (octeto.Length < 8)
            {
                octeto = octeto.Insert(0, "0");
            }

            return octeto;
        }

        public string ComplementoA2(string paquete)
        {
            if (Convert.ToString(paquete[paquete.Length - 1]) == "1")
            {
                var aStringBuilder = new StringBuilder(paquete);
                aStringBuilder.Remove(paquete.Length - 1, 1);
                aStringBuilder.Insert(paquete.Length - 1, "0");
                paquete = aStringBuilder.ToString();
            }

            else
            {
                var aStringBuilder = new StringBuilder(paquete);
                aStringBuilder.Remove(paquete.Length - 1, 1);
                aStringBuilder.Insert(paquete.Length - 1, "1");
                paquete = aStringBuilder.ToString();
            }

            i = 0;
            while (i < paquete.Length)
            {
                if (Convert.ToString(paquete[i]) == "0")
                {
                    var aStringBuilder = new StringBuilder(paquete);
                    aStringBuilder.Remove(i, 1);
                    aStringBuilder.Insert(i, "1");
                    paquete = aStringBuilder.ToString();
                }

                else
                {
                    var aStringBuilder = new StringBuilder(paquete);
                    aStringBuilder.Remove(i, 1);
                    aStringBuilder.Insert(i, "0");
                    paquete = aStringBuilder.ToString();
                }
                i = i + 1;
            }

            return paquete;

        }

        public double ComputeComplementoA2(string bits) //hace el complemento A2
        {
            if (bits == "1")
                return -1;
            if (bits == "0")
                return 0;
            else
            {
                if (Convert.ToString(bits[0]) == "0")
                {
                    int num = Convert.ToInt32(bits, 2);
                    return Convert.ToSingle(num);
                }
                else
                {
                    //elimino primer bit
                    string bitss = bits.Substring(1, bits.Length - 1);

                    //creo nuevo string cambiando 0s por 1s y viceversa
                    string newbits = "";
                    int i = 0;
                    while (i < bitss.Length)
                    {
                        if (Convert.ToString(bitss[i]) == "1")
                            newbits = newbits + "0";
                        if (Convert.ToString(bitss[i]) == "0")
                            newbits = newbits + "1";
                        i++;
                    }

                    //convertimos a int
                    double num = Convert.ToInt32(newbits, 2);

                    return -(num + 1);
                }
            }
        }

        public void Calculate_DataSourceIdentification(string paquete)
        {
            string string1 = paquete.Substring(0, 8);
            string string2 = paquete.Substring(8, 8);

            SAC = Convert.ToInt32(string1, 2);
            SIC= Convert.ToInt32(string2, 2);

        }

        public void Calculate_TargetReportDescriptor(string paquete)
        {
            string str1 = paquete.Substring(0, 3);
            int atp1 = Convert.ToInt32(str1, 2);

            if (atp1 == 0)
            {
                ATP = "24-Bit ICAO address.";
            }

            if (atp1 == 1)
            {
                ATP = "Duplicate address.";
            }

            if (atp1 == 2)
            {
                ATP = "Surface vehicle address.";
            }

            if (atp1 == 3)
            {
                ATP = "Anonymous address.";
            }

            str1 = paquete.Substring(3, 2);
            int arc1 = Convert.ToInt32(str1, 2);

            if (arc1 == 0)
            {
                ARC = "25 ft.";
            }

            if (arc1 == 1)
            {
                ARC = "100 ft.";
            }

            if (arc1 == 2)
            {
                ARC = "Unknown.";
            }

            if (arc1 == 3)
            {
                ARC = "Invalid .";
            }

            int rc1 = Convert.ToInt32(paquete[5]);

            if (rc1 == 0)
            {
                RC = "Default.";
            }

            else
            {
                RC = "Range Check passed, CPR Validation pending.";
            }

            int rab1 = Convert.ToInt32(paquete[6]);

            if (rab1 == 0)
            {
                RAB = "Report from target transponder.";
            }

            else
            {
                RAB = "Report from field monitor (fixed transponder).";
            }

            if (paquete.Length > 8)
            {
                int dcr1 = Convert.ToInt32(paquete[8]);

                if (dcr1 == 0)
                {
                    DCR = "No differential correction (ADS-B).";
                }

                else 
                {
                    DCR = "Differential correction (ADS-B)"; 
                }

                int gbs1 = Convert.ToInt32(paquete[9]);

                if (gbs1 == 0)
                {
                    GBS = "Ground Bit not set.";
                }

                else
                {
                    GBS= "Ground Bit set.";
                }

                int sim1 = Convert.ToInt32(paquete[10]);

                if (sim1 == 0)
                {
                    SIM = "Actual target report.";
                }

                else
                {
                    SIM = "Simulated target report.";
                }

                int tst1 = Convert.ToInt32(paquete[11]);

                if (tst1 == 0)
                {
                    TST = "Default.";
                }

                else
                {
                    TST = "Test Target.";
                }

                int saa1 = Convert.ToInt32(paquete[12]);

                if (saa1 == 0)
                {
                    SAA = "Equipment capable to provide Selected Altitude.";
                }

                else
                {
                    SAA = "Equipment not capable to provide Selected Altitude.";
                }

                str1 = paquete.Substring(13, 2);
                int cl1 = Convert.ToInt32(str1, 2);

                if (cl1 == 0)
                {
                    CL = "Report valid.";
                }

                if (cl1 == 1)
                {
                    CL = "Report suspect.";
                }

                if (cl1 == 2)
                {
                    CL = "No information.";
                }

                if (paquete.Length > 16)
                {
                    int ipc1 = Convert.ToInt32(paquete[18]);

                    if (ipc1 == 0)
                    {
                        IPC = "Independent Position Check = 0 default";
                    }

                    else 
                    {
                        IPC = "Independent Position Check failed.";
                    }

                    int nogo1 = Convert.ToInt32(paquete[18]);

                    if (nogo1 == 0)
                    {
                        NOGO = "NOGO-bit not set.";
                    }

                    else
                    {
                        NOGO = "NOGO-bit set.";
                    }

                    int cpr1 = Convert.ToInt32(paquete[19]);

                    if (cpr1 == 0)
                    {
                        CPR = "CPR Validation correct.";
                    }

                    else
                    {
                        CPR = "CPR Validation failed.";
                    }

                    int ldpj1 = Convert.ToInt32(paquete[20]);

                    if (ldpj1 == 0)
                    {
                        LDPJ = "LDPJ not detected.";
                    }

                    else
                    {
                        LDPJ = "LDPJ detected.";
                    }

                    int rcf1 = Convert.ToInt32(paquete[21]);

                    if (rcf1 == 0)
                    {
                        RCF = "Default.";
                    }

                    else
                    {
                        RCF = "Range Check failed .";
                    }

                }
            }


        }

        public void Calculate_TrackNumber(string paquete)
        {
            string string1 = paquete.Substring(4, 12);
            TrackNumber_number = Convert.ToInt32(string1,2);
        }

        public double Calculate_TimeofAppliability_Position(string paquete)
        {
            double time = 0;
            i = 0;
            while (i < (paquete.Length))
            {
                int bin = int.Parse(Char.ToString(paquete[i]));
                time = time + Math.Pow(2, 16 - i) * bin;
                i = i + 1;
            }
            return time;
        }

        public void CalculatePositionWGS84_coordinates(string paquete)
        {


            string lat = PositioninWGS_coordinates.Substring(0, 24);    
            string lon = PositioninWGS_coordinates.Substring(24, 24);
            int compA2_lat = 1;
            int compA2_lon = 1;

            if (Convert.ToString(lat[0]) == "1")
            {
                lat = ComplementoA2(lat);
                compA2_lat = -1;
            }

            if (Convert.ToString(lon[0]) == "1")
            {
                lon = ComplementoA2(lon);
                compA2_lon = -1;
            }


            int i = 0;
            int exp = 0;
            while (i < lat.Length)
            {
                int bin = int.Parse(Char.ToString(lat[i]));
                latWGS84 = latWGS84 + (180 / (Math.Pow(2, exp))) * bin;
                i = i + 1;
                exp = exp + 1;
            }

            i = 0;
            exp = 0;
            while (i < lon.Length)
            {
                int bin = int.Parse(Char.ToString(lon[i]));
                lonWGS84 = lonWGS84 + (180 / (Math.Pow(2, exp))) * bin;
                i = i + 1;
                exp = exp + 1;
            }

            latWGS84 = latWGS84 * compA2_lat;
            lonWGS84 = lonWGS84 * compA2_lon;
        }

        public void CalculatePositionWGS84_HRcoordinates(string paquete)
        {
            string lat = paquete.Substring(0, 32);
            string lon = paquete.Substring(32, 32);
            int compA2_lat = 1;
            int compA2_lon = 1;

            if (Convert.ToString(lat[0]) == "1")
            {
                lat = ComplementoA2(lat);
                compA2_lat = -1;
            }

            if (Convert.ToString(lon[0]) == "1")
            {
                lon = ComplementoA2(lon);
                compA2_lon = -1;
            }

            int i = 1;
            int exp = 0;
            while (i < lat.Length)
            {
                int bin = int.Parse(Char.ToString(lat[i]));
                latWGS84_HR = latWGS84_HR + (180 / (Math.Pow(2, exp))) * bin;
                i = i + 1;
                exp = exp + 1;
            }

            i = 1;
            exp = 0;
            while (i < lon.Length)
            {
                int bin = int.Parse(Char.ToString(lon[i]));
                lonWGS84_HR = lonWGS84_HR + (180 / (Math.Pow(2, exp))) * bin;
                i = i + 1;
                exp = exp + 1;
            }

            latWGS84_HR = latWGS84_HR * compA2_lat;
            lonWGS84_HR = lonWGS84_HR * compA2_lon;
        }

        public double Calculate_TimeofAppliability_Velocity(string paquete)
        {
            double time = 0;
            i = 0;
            while (i < (paquete.Length))
            {
                int bin = int.Parse(Char.ToString(paquete[i]));
                time = time + Math.Pow(2, 16 - i) * bin;
                i = i + 1;
            }
            return time;
        }

        public void Calculate_AirSpeed(string paquete)
        {

            string velocity = paquete.Substring(1, 15);

            if (Convert.ToInt32(paquete[0]) == 0)
            {
                IM = "IAS";
                int i = 1;
                int exp = 0;

                while (i < paquete.Length)
                {
                    int bin = Convert.ToInt32(paquete[i]);
                    AirSpeed_velocity = AirSpeed_velocity + (Math.Pow(2, -exp)) * bin;
                    exp = exp - 1;
                    i = i + 1;
                }

            }
            else
            {
                IM = "Mach";

                AirSpeed_Mach = Convert.ToInt32(velocity);
                AirSpeed_Mach = AirSpeed_Mach * 0.001;
            }


        }

        public void Calculate_AircraftOperationalStatus(string paquete)
        {

            if (int.Parse(Char.ToString(paquete[1])) == 1)
            {
                RA = "TCAS RA active";
            }

            else
            {
                RA = "TCAS II or ACAS RA not active";
            }


            string TC1 = Convert.ToString(((paquete.Substring(1, 2)), 2));

            if (Convert.ToInt32(TC1, 2) == 0)
            {
                TC = "No capability for Trajectory Change Reports.";
            }

            if (Convert.ToInt32(TC1, 2) == 1)
            {
                TC = "Support for TC+0 reports only.";
            }

            if (Convert.ToInt32(TC1, 2) == 2)
            {
                TC = "Support for multiple TC reports.";
            }

            if (Convert.ToInt32(TC1, 2) == 3)
            {
                TC = "Reserved.";
            }

            if (int.Parse(Char.ToString(paquete[3])) == 0)
            {
                TS = "No capability to support Target State Reports.";
            }

            if (int.Parse(Char.ToString(paquete[3])) == 1)
            {
                TS = "Capable of supporting target State Reports.";
            }

            if (int.Parse(Char.ToString(paquete[4])) == 0)
            {
                ARV = "No capability to generate ARV-reports.";
            }

            if (int.Parse(Char.ToString(paquete[4])) == 1)
            {
                ARV = "Capable of generate ARV-reports.";
            }

            if (int.Parse(Char.ToString(paquete[5])) == 0)
            {
                CDTI_A = "CDTI not operational.";
            }

            if (int.Parse(Char.ToString(paquete[5])) == 1)
            {
                CDTI_A = "CDTI operational.";
            }

            if (int.Parse(Char.ToString(paquete[6])) == 0)
            {
                TCAS = "TCAS operational.";
            }

            if (int.Parse(Char.ToString(paquete[6])) == 1)
            {
                TCAS = "TCAS not operational.";
            }

            if (int.Parse(Char.ToString(paquete[7])) == 0)
            {
                SA = "Antenna Diversity.";
            }

            if (int.Parse(Char.ToString(paquete[7])) == 1)
            {
                SA = "Single Antenna only.";
            }


        }


        public string Calculate_FSPEC(string[] paquete)
        {
            int j = 3;
            bool found = false;

            while (found ==false)
            { 
                FSPEC = Convert.ToString(Convert.ToInt32(paquete[j], 16), 2);// Convertir de hex a binario paquete [3]
                FSPEC = AddZeros(FSPEC);

                if (Char.ToString(FSPEC[FSPEC.Length-1]) == "1")
                {
                    while (Char.ToString(FSPEC[FSPEC.Length - 1]) != "0")
                    {
                        j = j + 1;
                        string parte2 = Convert.ToString(Convert.ToInt32(paquete[j], 16), 2);
                        parte2 = AddZeros(parte2);

                        FSPEC = String.Concat(FSPEC, parte2);
                    }

                    found = true;
                }

                found = true;
            }

            FSPEC_fake = FSPEC;

            while (FSPEC_fake.Length < (7*8))
            {
                FSPEC_fake = String.Concat(FSPEC_fake, "0");
            }

            data_position = 1 + 2 + ((FSPEC.Length) / 8);

            //-------------------------------------------------------------------------------------------------------------
            // Aqui porocesamos los parametros que hemos encontrado en el FSPEC
            //-------------------------------------------------------------------------------------------------------------

            if (Char.ToString(FSPEC_fake[0]) == "1") // 1 I021/010 Data Source Identification
            {
                int i = 0;
                while (i < 2)
                {
                    string string1= Convert.ToString(paquete[data_position + i]);
                    string string2=Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2=AddZeros(string2);
                    DataSourseIdentification = String.Concat(DataSourseIdentification, string2);
                    i = i + 1;

                }
                data_position = data_position + 2;

                Calculate_DataSourceIdentification(DataSourseIdentification);

            } 

            if (Char.ToString(FSPEC_fake[1]) == "1") // 2 I021/040 Target Report Descriptor
            {
                string string_packet = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                string_packet = AddZeros(string_packet);


                //
                int i = 0;
                while (Char.ToString(string_packet[string_packet.Length - 1]) == "1")
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TargetReportDescriptor = String.Concat(TargetReportDescriptor, string2);
                    string_packet = TargetReportDescriptor;
                    i = i + 1;
                }
                data_position = data_position +i;

                Calculate_TargetReportDescriptor(TargetReportDescriptor);

                if ((TargetReportDescriptor.Length) == 8)
                {
                    data_position = data_position + 1;
                }

            }

            if (Char.ToString(FSPEC_fake[2]) == "1") // 3 I021/161 Track Number 
            {
                int i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TrackNumber = String.Concat(TrackNumber, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                Calculate_TrackNumber(TrackNumber);
            }

            if (Char.ToString(FSPEC_fake[3]) == "1") // 4 I021/015 Service Identification 
            {
                int i = 0;
                while (i < 1)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    ServiceIdentification = String.Concat(ServiceIdentification, string2);
                    i = i + 1;
                }

                data_position = data_position + 1;

                ServiceIdentification_number = Convert.ToInt32(ServiceIdentification, 2);

            }

            if (Char.ToString(FSPEC_fake[4]) == "1") // 5 I021/071 Time of Applicability for Position
            {
                int i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2=AddZeros(string2);

                    TimeofApplicability_Position = String.Concat(TimeofApplicability_Position, string2);
                    i = i + 1;
                }
                data_position = data_position + 3;

                TimeofApplicability_Position_seconds=Calculate_TimeofAppliability_Position(TimeofApplicability_Position);
            }

            if (Char.ToString(FSPEC_fake[5]) == "1") // 6 I021/130 Position in WGS-84 coordinates
            {

                int i = 0;
                while (i < 6)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);

                    PositioninWGS_coordinates = String.Concat(PositioninWGS_coordinates, string2);
                    i = i + 1;
                }

                data_position = data_position + 6;

                CalculatePositionWGS84_coordinates(PositioninWGS_coordinates);

            }

            if (Char.ToString(FSPEC_fake[6]) == "1") // 7 I021/131 Position in WGS-84 co-ordinates, high res
            {
                i = 0;
                while (i < 8)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);

                    PositioninWGS_HRcoordinates = String.Concat(PositioninWGS_HRcoordinates, string2);
                    i = i + 1;
                }

                data_position = data_position + 8;

                CalculatePositionWGS84_HRcoordinates(PositioninWGS_HRcoordinates);
                // calculado con funcion

            }

            if (Char.ToString(FSPEC_fake[7]) == "1") //FX
            {
                data_position = data_position + 3;
            }

            if (Char.ToString(FSPEC_fake[8]) == "1") // 8 I021/072 Time of Applicability for Velocity
            {
                i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TimeofApplicability_Velocity = String.Concat(TimeofApplicability_Velocity, string2);
                    i = i + 1;
                }

                data_position = data_position + 3;

                TimeofApplicability_Velocity_seconds=Calculate_TimeofAppliability_Velocity(TimeofApplicability_Velocity);

            }

            if (Char.ToString(FSPEC_fake[9]) == "1") // 9 I021/150 Air Speed 
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    AirSpeed = String.Concat(AirSpeed, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                Calculate_AirSpeed(AirSpeed);

            }

            if (Char.ToString(FSPEC_fake[10]) == "1") // 10 I021/151 True Air Speed
            {
                data_position = data_position + 2;
            }


            if (Char.ToString(FSPEC_fake[11]) == "1") // 11 I021/080 Target Address
            {
                data_position = data_position + 3;
            }

            if (Char.ToString(FSPEC_fake[12]) == "1") // 12 I021/073 Time of Message Reception of Position
                {
                data_position = data_position + 3;
            }

            if (Char.ToString(FSPEC_fake[13]) == "1") // 13 I021 / 074 Time of Message Reception of Position-High
            {
                data_position = data_position + 3;
            }

            if (Char.ToString(FSPEC_fake[14]) == "1") // 14 I021/075 Time of Message Reception of Velocity 
            {
                data_position = data_position + 3;
            }

            if (Char.ToString(FSPEC_fake[15]) == "1") // FX - Field extension indicator 
            {
                data_position = data_position + 3;
            }

            return FSPEC;

        }

    }

    


}
