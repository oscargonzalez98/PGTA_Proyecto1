using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Clases
{
    public class CAT10
    {
        int i = 0;
        public string[] paquete;
        public string[] arrayFSPEC;
        public string FSPEC;
        public string FSPEC_fake;
        public int data_position = 0;

        public string DataSourceIdentifier = "";
        public int SIC;
        public int SAC;

        public string MessageType = "";
        public string MessageType_decodified;

        public string TargetReportDescriptor = "";
        public string TYP = "";
        public string DCR = "";
        public string CHN = "";
        public string GBS = "";
        public string CRT = "";
        public string SIM = "";
        public string TST = "";
        public string RAB = "";
        public string LOP = "";
        public string TOT = "";
        public string SPI = "";

        public string TimeofDay = "";
        public int TimeofDay_seconds;

        public string PositioninWGS84_coordinates;
        public double latWGS84 = 0;
        public double lonWGS84 = 0;

        public string MeasuredPositioninPolarCoordinates = "";
        public double Theta;
        public double Rho;

        public string PositioninCartesianCoordinates = "";
        public double X_cartesian;
        public double Y_cartesian;

        public string CalculatedTrackVelocityinPolarCoordinates = "";
        public double GroundSpeed;
        public double TrackAngle;

        public string CalculatedTrackVelocityinCartesianCoordinates = "";
        public double Vx_cartesian;
        public double Vy_cartesian;

        public string TrackNumber = "";
        public double Tracknumber_value;

        public string TrackStatus = "";
        public string CNF="";
        public string TRE = "";
        public string CST = "";
        public string MAH = "";
        public string TCC = "";
        public string STH = "";
        public string TOM = "";
        public string DOU = "";
        public string MRS = "";
        public string GHO = "";








        public CAT10(string[] packet)
        {
            this.paquete = packet;
        }

        public string AddZeros(string octeto)
        {
            while (octeto.Length < 8)
            {
                octeto = octeto.Insert(0, "0");
            }

            return octeto;
        }
        public double Calculate_ComplementoA2(string bits)
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
            SIC = Convert.ToInt32(string2, 2);

        }
        public void Calculate_MessageType(string paquete)
        {
            int int1 = Convert.ToInt32(paquete);
            if (int1 == 1) { MessageType_decodified = "Target Report"; }
            if (int1 == 2) { MessageType_decodified = "Start of Update Cycle";}
            if (int1 == 3) { MessageType_decodified = "Periodic Status Message"; }
            if (int1 == 4) { MessageType_decodified = "Event-triggered Status Message"; }
        }
        public void Calculate_TargetReportDescriptor(string paquete) 
        {
            string typ = paquete.Substring(0, 3);
            int typ1 = Convert.ToInt32(typ[0]);
            int typ2 = Convert.ToInt32(typ[1]);
            int typ3 = Convert.ToInt32(typ[2]);
            if (typ1 == 0 && typ2==0 && typ3==0) { TYP="SSR multilateration."; }
            if (typ1 == 0 && typ2 == 0 && typ3 == 1) { TYP = "Mode S multilateration."; }
            if (typ1 == 0 && typ2 == 1 && typ3 == 0) { TYP = "ADS-B."; }
            if (typ1 == 0 && typ2 == 1 && typ3 == 1) { TYP = "PSR."; }
            if (typ1 == 1 && typ2 == 0 && typ3 == 0) { TYP = "Magnetic Loop System."; }
            if (typ1 == 1 && typ2 == 0 && typ3 == 1) { TYP = "HF multilateration."; }
            if (typ1 == 1 && typ2 == 1 && typ3 == 0) { TYP = "Not defined."; }
            if (typ1 == 1 && typ2 == 1 && typ3 == 1) { TYP = "Other types."; }

            int dcr1 = Convert.ToInt32(paquete[3]);
            if (dcr1 == 0) { DCR = "No differential correction (ADS-B)."; }
            else { DCR = "Differential correction (ADS-B)."; }

            int chn1 = Convert.ToInt32(paquete[4]);
            if (chn1 == 0) { CHN = "Chain 1."; }
            else { CHN = "Chain2."; }

            int gbs1 = Convert.ToInt32(paquete[5]);
            if (gbs1 == 0) { GBS = "Transponder Ground bit not set."; }
            else { GBS = "Transponder Ground bit set."; }

            int crt1 = Convert.ToInt32(paquete[6]);
            if (crt1 == 0) { CRT = "No Corrupted reply in multilateration."; }
            else { CRT = "Corrupted reply in multilateration."; }


            if (paquete.Length > 8)
            {
                int sim1 = Convert.ToInt32(paquete[8]);
                if (sim1 == 0) { SIM = "Actual target report."; }
                else { SIM = "Simulated target report."; }

                int tst1 = Convert.ToInt32(paquete[9]);
                if (tst1 == 0) { TST = "Default."; }
                else { TST = "Test target."; }

                int rab1 = Convert.ToInt32(paquete[10]);
                if (rab1 == 0) { RAB = "Report from target transponder."; }
                else { RAB = "Report from field monitor (fixed transponder)."; }

                string lop = paquete.Substring(11, 2);
                int lop1 = Convert.ToInt32(lop[0]);
                int lop2 = Convert.ToInt32(lop[1]);

                if(lop1==0 && lop2 == 0) { LOP = "Undeterminated."; }
                if (lop1==0 && lop2 == 1) { LOP = "Loop start."; }
                else { LOP = "Loop finish."; }

                string tot = paquete.Substring(13, 2);
                int tot1 = Convert.ToInt32(tot[0]);
                int tot2 = Convert.ToInt32(tot[1]);
                int tot3 = Convert.ToInt32(tot[2]);

                if(tot1==0 && tot2 == 0) { TOT = "Undetermined."; }
                if(tot1==0 && tot2 == 1) { TOT = "Aircraft."; }
                if (tot1 == 1 && tot2 == 0) { TOT = "Ground Vehicle."; }
                else { TOT = "Helicopter."; }


                if (paquete.Length > 16)
                {
                    int spi1 = Convert.ToInt32(paquete[6]);
                    if (spi1 == 0) { SPI = "Absence of SPI"; }
                    else { SPI = "Special Position Identification."; }
                }



            }


        }
        public void Calculate_PositionWGS84_coordinates(string paquete)
        {
            string str1 = paquete.Substring(0, 32);
            string str2 = paquete.Substring(32, 32);

            double a1 = Calculate_ComplementoA2(str1);
            double b1 = Calculate_ComplementoA2(str2);

            latWGS84 = a1 * (180 / Math.Pow(2, 31));
            lonWGS84 = b1 * (180 / Math.Pow(2, 31));
        }

        public void Calculate_TrackStatus(string paquete)
        {
            int cnf = Convert.ToInt32(paquete[0]);
            if (cnf == 0) { CNF = "Confirmed track."; }
            else { CNF = "Track initialisation phase."; }

            int tre = Convert.ToInt32(paquete[1]);
            if (tre == 0) { TRE = "Default."; }
            else { TRE = "Last report for a track."; }

            string cst = paquete.Substring(2, 2);
            int cst1 = Convert.ToInt32(cst[0]);
            int cst2 = Convert.ToInt32(cst[1]);

            if(cst1==0 && cst2==0) { CST = "No extrapolation."; }
            if(cst1==0 && cst2==1) { CST = "Predictable extrapolation due to sensor refresh period."; }
            if(cst1==1 && cst2 == 0) { CST = " Predictable extrapolation in masked area."; }
            if(cst1==1 && cst2 == 1) { CST = "Extrapolation due to unpredictable absence of detection."; }

            int mah = Convert.ToInt32(paquete[4]);
            if (mah == 0) { MAH = "Default."; }
            else { MAH = "Horizontal manoeuvre."; }

            int tcc = Convert.ToInt32(paquete[5]);
            if (tcc == 0) { TCC = "Tracking performed in 'Sensor Plane', i.e. neither slant range correction nor projection was applied."; }
            else { TCC = "Slant range correction and a suitable projection technique are used to track in a 2D.reference plane, tangential to the earth model at the Sensor Site co-ordinates."; }

            int sth = Convert.ToInt32(paquete[6]);
            if (sth == 0) { STH = "Measured position."; }
            else { STH = "Smoothed position."; }

            if (paquete.Length>8)
            {
                string tom = paquete.Substring(8, 2);
                int tom1 = Convert.ToInt32(tom[0]);
                int tom2 = Convert.ToInt32(tom[1]);
                if(tom1==0 && tom2 == 0) { TOM = "Unknown type of movement."; }
                if (tom1==0 && tom2 == 1) { TOM = "Taking-off."; }
                if(tom1==1 && tom2 == 0) { TOM = "Landing."; }
                if(tom1==1 && tom2 == 1) { TOM = "Other types of movement."; }

                string dou = paquete.Substring(10, 3);
                int dou1 = Convert.ToInt32(dou[0]);
                int dou2 = Convert.ToInt32(dou[1]);
                int dou3 = Convert.ToInt32(dou[2]);

                if(dou1==0 && dou2==0 && dou3 == 0) { DOU = "No doubt."; }
                if(dou1==0 && dou2==0 && dou3 == 1) { DOU = " Doubtful correlation (undetermined reason)."; }
                if(dou1==0 && dou2==1 && dou3 == 0) { DOU = " Doubtful correlation in clutter."; }
                if(dou1==0 && dou2==1 && dou3 == 1) { DOU = " Loss of accuracy."; }
                if(dou1==1 && dou2==0 && dou3 == 0) { DOU = " Loss of accuracy in clutter."; }
                if(dou1==1 && dou2==0 && dou3 == 1) { DOU = "Unstable track."; }
                if(dou1==1 && dou2==1 && dou3 == 0) { DOU = "Previously coasted."; }

                string mrs = paquete.Substring(13, 2);
                int mrs1 = Convert.ToInt32(mrs[0]);
                int mrs2 = Convert.ToInt32(mrs[1]);

                if(mrs1==0 && mrs2 == 0) { MRS = "Merge or split indication undetermined."; }
                if(mrs1==0 && mrs2 == 1) { MRS = "Track merged by association to plot."; }
                if(mrs1==1 && mrs2 == 0) { MRS = "Track merged by non-association to ."; }
                if(mrs1==1 && mrs2 == 1) { MRS = "Split track."; }

                if (paquete.Length > 16)
                {
                    int gho = Convert.ToInt32(paquete[16]);
                    if (gho == 0) { GHO = "default."; }
                    else { GHO = "Ghost track."; }
                }


            }

        }

        public void Calculate_FSPEC(string[] paquete)
        {
            int j = 3;
            bool found = false;

            while (found == false)
            {
                FSPEC = Convert.ToString(Convert.ToInt32(paquete[j], 16), 2);// Convertir de hex a binario paquete [3]
                FSPEC = AddZeros(FSPEC);

                if (Char.ToString(FSPEC[FSPEC.Length - 1]) == "1")
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

            while (FSPEC_fake.Length < (7 * 8))
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
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    DataSourceIdentifier = String.Concat(DataSourceIdentifier, string2);
                    i = i + 1;

                }
                data_position = data_position + 2;

                Calculate_DataSourceIdentification(DataSourceIdentifier);

            }

            if (Char.ToString(FSPEC_fake[1]) == "1") // 2 I010/000 Message Type 
            {
                int i = 0;
                while (i < 1)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    MessageType = String.Concat(MessageType, string2);
                    i = i + 1;

                }
                data_position = data_position + 1;

                Calculate_MessageType(MessageType);

            }

            if (Char.ToString(FSPEC_fake[2]) == "1") // 3 I010/020 Target Report Descriptor  
            {

                string string_packet = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                string_packet = AddZeros(string_packet);
                TargetReportDescriptor = string_packet;


                //
                int i = 0;
                while (Char.ToString(string_packet[string_packet.Length - 1]) == "1")
                {
                    string string1 = Convert.ToString(paquete[data_position + i+1]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TargetReportDescriptor = String.Concat(TargetReportDescriptor, string2);
                    string_packet = TargetReportDescriptor;
                    i = i + 1;
                }
                data_position = data_position + i;

                if ((string_packet.Length) == 8)
                {
                    data_position = data_position + 1;
                }

                Calculate_TargetReportDescriptor(TargetReportDescriptor);

            }

            if (Char.ToString(FSPEC_fake[3]) == "1") // 4 I010 / 140 Time of Day
            {
                int i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TimeofDay = String.Concat(TimeofDay, string2);
                    i = i + 1;

                }
                data_position = data_position + 3;

                TimeofDay_seconds = Convert.ToInt32(TimeofDay,2)/128;

            }

            if (Char.ToString(FSPEC_fake[4]) == "1") // 5 I010 / 041  Position in WGS-84 Co-ordinates 
            {
                int i = 0;
                while (i < 8)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    PositioninWGS84_coordinates = String.Concat(PositioninWGS84_coordinates, string2);
                    i = i + 1;

                }
                data_position = data_position + 8;

                Calculate_PositionWGS84_coordinates(PositioninWGS84_coordinates);

            }

            if (Char.ToString(FSPEC_fake[5]) == "1") // 6 I010/040  Measured Position in Polar Co-ordinates 
            {
                int i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    MeasuredPositioninPolarCoordinates = String.Concat(MeasuredPositioninPolarCoordinates, string2);
                    i = i + 1;

                }
                data_position = data_position + 4;

                string rho1 = (MeasuredPositioninPolarCoordinates.Substring(0, 16));
                string theta1 = (MeasuredPositioninPolarCoordinates.Substring(16, 16));

                Rho = Convert.ToInt32(rho1, 2);
                Theta = Convert.ToInt32(theta1, 2) * 360 / (Math.Pow(2, 16));

            }

            if (Char.ToString(FSPEC_fake[6]) == "1") // 7 I010/042  Position in Cartesian Co-ordinates
            {
                int i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    PositioninCartesianCoordinates = String.Concat(PositioninCartesianCoordinates, string2);
                    i = i + 1;

                }
                data_position = data_position + 4;

                string xcartesian = (PositioninCartesianCoordinates.Substring(0, 16));
                string ycartesian = (PositioninCartesianCoordinates.Substring(16, 16));

                X_cartesian = Calculate_ComplementoA2(xcartesian);
                Y_cartesian = Calculate_ComplementoA2(ycartesian);

            }

            if (Char.ToString(FSPEC_fake[7]) == "1") // 8 - _FX
            {

            } // FX

            if (Char.ToString(FSPEC_fake[8]) == "1") // 8 I010/200  Calculated Track Velocity in Polar Co-ordinates
            {
                int i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    CalculatedTrackVelocityinPolarCoordinates = String.Concat(CalculatedTrackVelocityinPolarCoordinates, string2);
                    i = i + 1;

                }
                data_position = data_position + 4;

                string gs1 = CalculatedTrackVelocityinPolarCoordinates.Substring(0, 16);
                string ta1 = CalculatedTrackVelocityinPolarCoordinates.Substring(16, 16);

                GroundSpeed = Convert.ToInt32(gs1, 2) * (Math.Pow(2, -14));
                TrackAngle = Convert.ToInt32(ta1, 2) * 360/(Math.Pow(2, 16));
            }

            if (Char.ToString(FSPEC_fake[9]) == "1") // 9 I010/202  Calculated Track Velocity in Cartesian Coord
            {
                int i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    CalculatedTrackVelocityinCartesianCoordinates = String.Concat(CalculatedTrackVelocityinCartesianCoordinates, string2);
                    i = i + 1;

                }
                data_position = data_position + 4;

                string vx = CalculatedTrackVelocityinCartesianCoordinates.Substring(0, 16);
                string vy = CalculatedTrackVelocityinCartesianCoordinates.Substring(16, 16);

                Vx_cartesian = Calculate_ComplementoA2(vx) * 0.25;
                Vy_cartesian = Calculate_ComplementoA2(vy) * 0.25;
            }

            if (Char.ToString(FSPEC_fake[10]) == "1") // 10 I010/161  Track Number 
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

                string tn = TrackNumber.Substring(4, 12);
                Tracknumber_value = Convert.ToInt32(tn,2);

            }

            if (Char.ToString(FSPEC_fake[11]) == "1") // 11 I010/170  Track Status 
            {
                string string_packet = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                string_packet = AddZeros(string_packet);
                TrackStatus = string_packet;


                //
                int i = 0;
                while (Char.ToString(string_packet[string_packet.Length - 1]) == "1")
                {
                    string string1 = Convert.ToString(paquete[data_position + i+1]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TrackStatus = String.Concat(TrackStatus, string2);
                    string_packet = TrackStatus;
                    i = i + 1;
                }
                data_position = data_position + i;

                if ((string_packet.Length) == 8)
                {
                    data_position = data_position + 1;
                }

                Calculate_TrackStatus(TrackStatus);

            }























        }






























    }
}
