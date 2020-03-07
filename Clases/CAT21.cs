﻿using System;
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

        public string TrueAirSpeed = "";
        public double TrueAirSpeed_number;
        public string RE_TAS="";

        public string TargetAddress_bin = "";
        public string TargetAdress_real = "";

        public string TimeofMessageReception_Position;
        public double TimeofMessageReception_Position_seconds;

        public string TimeofMessageReception_HRPosition = "";
        public double TimeofMessageReception_HRPosition_seconds;
        public string FSI = "";

        public string TimeofMessageReception_Velocity = "";
        public double TimeofMessageReception_Velocity_seconds;

        public string TimeofMessageReception_HRVelocity = "";
        public double TimeofMessageReception_HRVelocity_seconds;

        public string GeometricHeight = "";
        public double GeometricHeight_feet;

        public string QualityIndicators = "";
        public int NACv;
        public int NUCp;
        public string NIC_Baro = "";
        public string SIL = "";
        public string SDA = "";
        public string GVA = "";

        public string MOPSVersion = "";
        public string VNS = "";
        public string VN;
        public string LTT = "";

        public string Mode3ACode_bin = "";
        public string Mode3ACode_oct = "";

        public string RollAngle = "";
        public double RollAngle_degrees;

        public string FlightLevel = "";
        public double FlightLevel_FL;

        public string MagneticHeading = "";
        public double MagneticHeading_degrees;

        public string TargetStatus = "";
        public string ICF = "";
        public string LNAV = "";
        public string PS = "";
        public string SS = "";

        public string BarometricVerticalRate = "";
        public string RE_BVR = "";
        public double BarometricVerticalRate_fmin;

        public string GeometricVerticalRate = "";
        public string RE_GVR = "";
        public double GeometricVerticalRate_fmin;

        public string AirborneGoundVector = "";
        public string RE_AGV = "";
        public double GroundSpeed;
        public double TrackAngle;

        public string TrackAngleRate = "";
        public double TrackAngleRate_degs;

        public string TimeofASTERIXReportTransmission = "";
        public int TimeofASTERIXReportTransmission_seconds;

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
        public void Calculate_TimeofAppliability_Position(string paquete)
        {
            double time = Convert.ToInt32(paquete,2);
            TimeofApplicability_Position_seconds = time * (1 / 128);

        }
        public void CalculatePositionWGS84_coordinates(string paquete)
        {
            string str1 = paquete.Substring(0, 24);
            string str2 = paquete.Substring(24, 24);

            double a1 = Calculate_ComplementoA2(str1);
            double b1 = Calculate_ComplementoA2(str2);

            latWGS84 = a1 * (180 / Math.Pow(2, 23));
            lonWGS84 = b1 * (180 / Math.Pow(2, 23));

        }
        public void CalculatePositionWGS84_HRcoordinates(string paquete)
        {

            string str1 = paquete.Substring(0, 32);
            string str2 = paquete.Substring(32, 32);

            double a1 = Calculate_ComplementoA2(str1);
            double b1 = Calculate_ComplementoA2(str2);

            latWGS84_HR = a1 * (180 / Math.Pow(2, 30));
            lonWGS84_HR = b1 * (180 / Math.Pow(2, 30));
        }
        public void Calculate_TimeofAppliability_Velocity(string paquete)
        {
            double time = Convert.ToInt32(paquete,2);
            TimeofApplicability_Position_seconds = time * (1 / 128);
        }
        public void Calculate_AirSpeed(string paquete)
        {

            string velocity = paquete.Substring(1, 15);

            if (Convert.ToInt32(paquete[0]) == 0)
            {
                IM = "IAS";
                double vel1 = Convert.ToInt32(velocity);
                TimeofApplicability_Position_seconds = vel1 * (1 / Math.Pow(2,14));

            }
            else
            {
                IM = "Mach";

                AirSpeed_Mach = Convert.ToInt32(velocity);
                AirSpeed_Mach = AirSpeed_Mach * 0.001;
            }


        }
        public void Calculate_TrueAirSpeed(string paquete)
        {
            string ra1 = Convert.ToString(paquete[0]);

            if (ra1 == "0")
            {
                RE_TAS = "Value in defined range.";
            }

            else
            {
                RE_TAS = "Value exceeds defined range.";
            }

            string tas = paquete.Substring(1, 15);
            TrueAirSpeed_number = Convert.ToInt32(tas);

        }
        public void Calculate_TimeofMessageReception_HRPosition(string paquete)
        {
            string fsi1 = paquete.Substring(0, 2);
            int fsi2 = Convert.ToInt32(fsi1, 2);

            if (fsi2 == 11)
            {
                FSI = "Reserved.";
            }

            if (fsi2 == 10)
            {
                string seconds = Convert.ToString(TimeofMessageReception_Position_seconds);
                FSI = "TOMRp whole seconds = " + seconds + " Whole seconds -1.";
            }

            if (fsi2 == 01)
            {
                string seconds = Convert.ToString(TimeofMessageReception_Position_seconds);
                FSI = "TOMRp whole seconds = " + seconds + " Whole seconds +1.";
            }

            if (fsi2 == 00)
            {
                string seconds = Convert.ToString(TimeofMessageReception_Position_seconds);
                FSI = "TOMRp whole seconds = " + seconds + " Whole seconds.";
            }

            string str1 = paquete.Substring(2, 30);
            int seconds1 = Convert.ToInt32(str1, 2);
            TimeofMessageReception_HRPosition_seconds = seconds1 * (Math.Pow(2, -30));

        }
        public void Calculate_TimeofMessageReception_HRVelocity(string paquete)
        {
            string fsi1 = paquete.Substring(0, 2);
            int fsi2 = Convert.ToInt32(fsi1, 2);

            if (fsi2 == 11)
            {
                FSI = "Reserved.";
            }

            if (fsi2 == 10)
            {
                string seconds = Convert.ToString(TimeofMessageReception_Velocity_seconds);
                FSI = "TOMRp whole seconds = " + seconds + " Whole seconds -1.";
            }

            if (fsi2 == 01)
            {
                string seconds = Convert.ToString(TimeofMessageReception_Velocity_seconds);
                FSI = "TOMRp whole seconds = " + seconds + " Whole seconds +1.";
            }

            if (fsi2 == 00)
            {
                string seconds = Convert.ToString(TimeofMessageReception_Velocity_seconds);
                FSI = "TOMRp whole seconds = " + seconds + " Whole seconds.";
            }

            string str1 = paquete.Substring(2, 30);
            int seconds1 = Convert.ToInt32(str1, 2);
            TimeofMessageReception_HRVelocity_seconds = seconds1 * (Math.Pow(2, -30));

        }
        public void Calculate_MOPSVersion(string paquete)
        {
            string vns1 = Convert.ToString(paquete[0]);
            if (vns1 == "0")
            {
                VNS = "The MOPS Version is supported by the GS.";
            }

            else
            {
                VNS = "The MOPS Version is not supported by the GS.";
            }

            string vn = paquete.Substring(3, 3);
            int vn1 = Convert.ToInt32(vn, 2);
            if (vn1 == 0)
            {
                VN = "ED102/DO-260 [Ref. 8].";
            }

            if (vn1 == 1)
            {
                VN = "DO-260A [Ref. 9].";
            }

            if (vn1 == 2)
            {
                VN = "ED102A/DO-260B [Ref. 11].";
            }


            string ltt = paquete.Substring(5, 3);
            int ltt1 = Convert.ToInt32(ltt, 2);
            if (ltt1 == 0)
            {
                LTT = "Other.";
            }

            if (ltt1 == 1)
            {
                LTT = "UAT";
            }

            if (ltt1 == 2)
            {
                LTT = "1090 ES.";
            }

            if (ltt1 == 4)
            {
                LTT = "VDL 4.";
            }

            if (ltt1 == 4 || ltt1==5 || ltt1==6 || ltt1==7)
            {
                LTT = "Not Assigned";
            }

        }
        public void Calculate_TargetStatus(string paquete)
        {
            int icf1 = Convert.ToInt32(paquete[0]);
            if (icf1 == 0)
            {
                ICF = "No intent change active.";
            }

            else
            {
                ICF = "Intent change active.";
            }

            int lnav1 = Convert.ToInt32(paquete[1]);
            if (icf1 == 0)
            {
                LNAV = "LNAV Mode engaged.";
            }

            else
            {
                LNAV= "LNAV Mode not engaged.";
            }

            string ps = paquete.Substring(3, 3);
            int ps1 = Convert.ToInt32(ps, 2);
            if (ps1 == 0)
            {
                PS= "No emergency / not reported.";
            }

            if (ps1 == 1)
            {
                PS = "General emergency.";
            }

            if (ps1 == 2)
            {
                PS = "Lifeguard / medical emergency.";
            }

            if (ps1 == 3)
            {
                PS = "Minimum fuel.";
            }

            if (ps1 == 4)
            {
                PS = "No communications.";
            }

            if (ps1 == 5)
            {
                PS = "Unlawful interference.";
            }

            if (ps1 == 6)
            {
                PS = "“Downed” Aircraft.";
            }

            string ss = paquete.Substring(6, 2);
            int ss1 = Convert.ToInt32(ss, 2);
            if (ss1 == 0)
            {
                SS = "No condition reported.";
            }

            if (ss1 == 1)
            {
                SS = "Permanent Alert (Emergency condition).";
            }

            if (ss1 == 2)
            {
                SS = "Temporary Alert (change in Mode 3/A Code other than emergency).";
            }

            if (ss1 == 3)
            {
                SS = "SPI set.";
            }
        }
        public void Calculate_AirborneGroundVector(string paquete)
        {
            string str1 = paquete.Substring(0, 16);
            string str2 = paquete.Substring(16, 16);

            if (str1[0] == Convert.ToChar("0"))
            {
                RE_AGV = "Value in defined range.";
            }

            else
            {
                RE_AGV = "Value exceeds defined range.";
            }

            string str3 = str1.Substring(1, 15);

            GroundSpeed = Convert.ToInt32(str3, 2) * Math.Pow(2, -14);
            TrackAngle = Convert.ToInt32(str2, 2) * (360 / Math.Pow(2, 16));
        }
        public void Calculate_BarometricVerticalRate(string paquete)
        {
            string str1 = Convert.ToString(paquete[0]);
            if (str1 == "0")
            {
                RE_BVR = "Value in defined range.";
            }

            else
            {
                RE_BVR = "Value exceeds defined range.";
            }

            string str2 = paquete.Substring(1, 15);

            BarometricVerticalRate_fmin= Calculate_ComplementoA2(str2)*6.25;
        }
        public void Calculate_GeometricVerticalRate(string paquete)
        {
            string str1 = Convert.ToString(paquete[0]);
            if (str1 == "0")
            {
                RE_GVR = "Value in defined range.";
            }

            else
            {
                RE_GVR = "Value exceeds defined range.";
            }

            string str2 = paquete.Substring(1, 15);

            GeometricVerticalRate_fmin = Calculate_ComplementoA2(str2) * 6.25;
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

                Calculate_TimeofAppliability_Position(TimeofApplicability_Position);
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

            } // FX

            if (Char.ToString(FSPEC_fake[7]) == "1") //FX
            {
                data_position = data_position;
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

                Calculate_TimeofAppliability_Velocity(TimeofApplicability_Velocity);

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
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TrueAirSpeed = String.Concat(TrueAirSpeed, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                Calculate_TrueAirSpeed(TrueAirSpeed);

            }

            if (Char.ToString(FSPEC_fake[11]) == "1") // 11 I021/080 Target Address
            {

                string hexa = "";

                i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    char a = string1[0];
                    char b = string1[1];
                    hexa=string.Concat(hexa,a);
                    hexa= string.Concat(hexa,b);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TargetAddress_bin = String.Concat(TargetAddress_bin, string2);
                    i = i + 1;
                }

                data_position = data_position + 3;

                TargetAdress_real = hexa;


                

            }

            if (Char.ToString(FSPEC_fake[12]) == "1") // 12 I021/073 Time of Message Reception of Position
            {

                i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TrueAirSpeed = String.Concat(TrueAirSpeed, string2);
                    i = i + 1;
                }

                data_position = data_position + 3;

                double time = Convert.ToInt32(TimeofMessageReception_Position, 2);
                TimeofApplicability_Position_seconds = time * (1 / 128);

            }

            if (Char.ToString(FSPEC_fake[13]) == "1") // 13 I021 / 074 Time of Message Reception of Position-High
            {

                i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TimeofMessageReception_HRPosition = String.Concat(TimeofMessageReception_HRPosition, string2);
                    i = i + 1;
                }

                data_position = data_position + 4;

                Calculate_TimeofMessageReception_HRPosition(TimeofMessageReception_HRPosition);
            }

            if (Char.ToString(FSPEC_fake[14]) == "1") // 14 I021/075 Time of Message Reception of Velocity 
            {
                i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TimeofMessageReception_Velocity = String.Concat(TimeofMessageReception_Velocity, string2);
                    i = i + 1;
                }

                data_position = data_position + 3;

                int time = Convert.ToInt32(TimeofMessageReception_Velocity, 2);
                TimeofMessageReception_Velocity_seconds = time * 1 / 128;

            }

            if (Char.ToString(FSPEC_fake[15]) == "1") // FX - Field extension indicator 
            {
                data_position = data_position;
            }// FX

            if (Char.ToString(FSPEC_fake[16]) == "1") // 15 I021 / 076 Time of Message Reception of Velocity-High Precision
            {
                i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TimeofMessageReception_HRVelocity = String.Concat(TimeofMessageReception_HRVelocity, string2);
                    i = i + 1;
                }

                data_position = data_position + 4;

                Calculate_TimeofMessageReception_HRVelocity(TimeofMessageReception_HRVelocity);
            }

            if (Char.ToString(FSPEC_fake[17]) == "1") // 16 I021/140 Geometric Height
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    GeometricHeight = String.Concat(GeometricHeight, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                if (GeometricHeight[0] == Convert.ToChar("0"))
                {
                    string str1 = GeometricHeight.Substring(1, 15);
                    GeometricHeight_feet = Calculate_ComplementoA2(str1);
                    GeometricHeight_feet = GeometricHeight_feet * 6.25;
                }
                else
                {
                    string str1 = GeometricHeight.Substring(1, 15);
                    GeometricHeight_feet = Convert.ToInt32(str1, 2);
                    GeometricHeight_feet = GeometricHeight_feet * 6.25;
                }

            }

            if (Char.ToString(FSPEC_fake[18]) == "1")// 17 I021/090 Quality Indicators
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
                    QualityIndicators = String.Concat(QualityIndicators, string2);
                    string_packet = QualityIndicators;
                    i = i + 1;
                }
                data_position = data_position + i;

                Calculate_TargetReportDescriptor(QualityIndicators);

                if ((QualityIndicators.Length) == 8)
                {
                    data_position = data_position + 1;
                }


            }

            if (Char.ToString(FSPEC_fake[19]) == "1")// 18 I021/210 MOPS Version
            {
                i = 0;
                while (i < 1)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    MOPSVersion = String.Concat(MOPSVersion, string2);
                    i = i + 1;
                }

                data_position = data_position + 1;

                Calculate_MOPSVersion(MOPSVersion);
            }

            if (Char.ToString(FSPEC_fake[20]) == "1") // 19 I021/070 Mode 3/A Code
            {

                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    Mode3ACode_bin = String.Concat(Mode3ACode_bin, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                int int1 = Convert.ToInt32(Mode3ACode_bin, 2); // pasamos de binario a decimal
                Mode3ACode_oct = Convert.ToString(int1, 8); // pasamos de decimal a octal

            }

            if (Char.ToString(FSPEC_fake[21]) == "1") // 20 I021/230 Roll Angle
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    RollAngle = String.Concat(RollAngle, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                int int1 = Convert.ToInt32(RollAngle, 2);
                RollAngle_degrees = int1 * 0.01;
            }

            if (Char.ToString(FSPEC_fake[22]) == "1") // 21 I021/145 Flight Level
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    FlightLevel = String.Concat(FlightLevel, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                FlightLevel_FL = (Calculate_ComplementoA2(FlightLevel)) / 4;

            }

            if (Char.ToString(FSPEC_fake[23]) == "1") // FX - Field extension indicator
            {
                data_position = data_position;
            } // FX

            if (Char.ToString(FSPEC_fake[24]) == "1") // 22 I021/152 Magnetic Heading
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    MagneticHeading = String.Concat(MagneticHeading, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                MagneticHeading_degrees = (Convert.ToInt32(MagneticHeading, 2)) * (360 / Math.Pow(2, 16));
            }

            if (Char.ToString(FSPEC_fake[25]) == "1") // 23 I021/200 Target Status 
            {
                i = 0;
                while (i < 1)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TargetStatus = String.Concat(TargetStatus, string2);
                    i = i + 1;
                }

                data_position = data_position + 1;

                Calculate_TargetStatus(TargetStatus);
            }

            if (Char.ToString(FSPEC_fake[26]) == "1") // 24 I021/155 Barometric Vertical Rate
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    BarometricVerticalRate = String.Concat(BarometricVerticalRate, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                Calculate_BarometricVerticalRate(BarometricVerticalRate);


            }

            if (Char.ToString(FSPEC_fake[27]) == "1") // 25 I021/157 Geometric Vertical Rate
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    GeometricVerticalRate = String.Concat(GeometricVerticalRate, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                Calculate_GeometricVerticalRate(GeometricVerticalRate);

            }

            if (Char.ToString(FSPEC_fake[28]) == "1") // 26 I021/160 Airborne Ground Vector 
            {
                i = 0;
                while (i < 4)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    AirborneGoundVector = String.Concat(AirborneGoundVector, string2);
                    i = i + 1;
                }

                data_position = data_position + 4;

                Calculate_AirborneGroundVector(AirborneGoundVector);
            }

            if (Char.ToString(FSPEC_fake[29]) == "1") // 27 I021/165 Track Angle Rate
            {
                i = 0;
                while (i < 2)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TrackAngleRate = String.Concat(TrackAngleRate, string2);
                    i = i + 1;
                }

                data_position = data_position + 2;

                string str1 = TrackAngleRate.Substring(6, 10);
                TrackAngleRate_degs = (Calculate_ComplementoA2(str1)) / 32;
            }

            if (Char.ToString(FSPEC_fake[30]) == "1") // 28 I021/077 Time of Report Transmission 
            {
                i = 0;
                while (i < 3)
                {
                    string string1 = Convert.ToString(paquete[data_position + i]);
                    string string2 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                    string2 = AddZeros(string2);
                    TimeofASTERIXReportTransmission = String.Concat(TimeofASTERIXReportTransmission, string2);
                    i = i + 1;
                }

                data_position = data_position + 3;

                TimeofASTERIXReportTransmission_seconds = (Convert.ToInt32(TimeofASTERIXReportTransmission, 2)) / 128;

            }

            if (Char.ToString(FSPEC_fake[31]) == "1") // FX - Field extension indicator 
            { 

            }// FX



            return FSPEC;

        }

    }

    


}
