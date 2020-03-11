﻿using System;
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

        public string Mode3ACodeinOctal = "";
        public string V = "";
        public string G = "";
        public string L = "";
        public string Mode3ACodeinOctal_decodified = "";

        public string TargetAdress = "";
        public double TargetAdress_decoded;

        public string TargetIdentification = "";
        public string TargetIdentification_decoded = "";
        public string STI = "";

        public string ModeSMBData = "";

        public string VehicleFleetIdentification = "";
        public string VFI = "";

        public string FlightLevelInBinaryRepresentation = "";
        public string V_fl = "";
        public string G_fl = "";
        public double FlightLevel;

        public string MeasuredHeight;
        public double MeasuredHeight_ft;

        public string TargetSizeOrientation = "";
        public double Length;
        public double Orientation;
        public double Width;

        public string SystemStatus ="";
        public string NOGO = "";
        public string OVL = "";
        public string TSV = "";
        public string DIV = "";
        public string TTF = "";

        public string PreProgrammedMessage = "";
        public string TRB = "";
        public string MSG = "";

        public string StandardDeviationofPosition = "";
        public double StdDeviation_x;
        public double StdDeviation_y;
        public double StdDeviation_xy;

        public string Presence = "";
        public int REP;
        public double DRHO;
        public double DTHETA;

        public string AmplitudeofPrimaryPlot = "";
        public double AmplitudeofPrimaryPlot_value;

        public string CalculatedAcceleration;
        public double CalculatedAcceleration_X;
        public double CalculatedAcceleration_Y;



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
        public void Calculate_Mode3ACode_octal(string paquete)
        {
            int v1 = Convert.ToInt32(paquete[0]);
            if (v1 == 0) { V = "Code validated."; }
            else { V = "Code not validated."; }

            int g1 = Convert.ToInt32(paquete[1]);
            if (g1 == 0) { G = "Default."; }
            else { G = "Garbled code."; }

            int l1 = Convert.ToInt32(paquete[2]);
            if (l1 == 0) { L = "Mode-3/A code derived from the reply of the transponder."; }
            else { L = "Mode-3/A code not extracted during the last scan."; }

            string str1 = paquete.Substring(4, 12);
            Mode3ACodeinOctal_decodified = Convert.ToString(Convert.ToInt32(str1, 2), 8);
        }
        public void Calculate_TargetIdentification(string paquete)
        {
            int i = 0;
            while (i < 8)
            {
                string str1 = paquete.Substring(i * 6, 6);

                int b1 = Convert.ToInt32(Convert.ToString(str1[5]));
                int b2 = Convert.ToInt32(Convert.ToString(str1[4]));
                int b3 = Convert.ToInt32(Convert.ToString(str1[3]));
                int b4 = Convert.ToInt32(Convert.ToString(str1[2]));
                int b5 = Convert.ToInt32(Convert.ToString(str1[1]));
                int b6 = Convert.ToInt32(Convert.ToString(str1[0]));

                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "A");
                }
                if (b4 == 0 && b3 == 0 && b2 == 1 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "B");
                }
                if (b4 == 0 && b3 == 0 && b2 == 1 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "C");
                }
                if (b4 == 0 && b3 == 1 && b2 == 0 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "D");
                }
                if (b4 == 0 && b3 == 1 && b2 == 0 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "E");
                }
                if (b4 == 0 && b3 == 1 && b2 == 1 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "F");
                }
                if (b4 == 0 && b3 == 1 && b2 == 1 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "G");
                }
                if (b4 == 1 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "H");
                }
                if (b4 == 1 && b3 == 0 && b2 == 0 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "I");
                }
                if (b4 == 1 && b3 == 0 && b2 == 1 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "J");
                }
                if (b4 == 1 && b3 == 0 && b2 == 1 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "K");
                }
                if (b4 == 1 && b3 == 1 && b2 == 0 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "L");
                }
                if (b4 == 1 && b3 == 1 && b2 == 0 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "M");
                }
                if (b4 == 1 && b3 == 1 && b2 == 1 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "N");
                }
                if (b4 == 1 && b3 == 1 && b2 == 1 && b1 == 1 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "O");
                }
                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "P");
                }
                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 1 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "Q");
                }
                if (b4 == 0 && b3 == 0 && b2 == 1 && b1 == 0 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "R");
                }
                if (b4 == 0 && b3 == 0 && b2 == 1 && b1 == 1 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "S");
                }
                if (b4 == 0 && b3 == 1 && b2 == 0 && b1 == 0 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "T");
                }
                if (b4 == 0 && b3 == 1 && b2 == 0 && b1 == 1 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "U");
                }
                if (b4 == 0 && b3 == 1 && b2 == 1 && b1 == 0 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "V");
                }
                if (b4 == 0 && b3 == 1 && b2 == 1 && b1 == 1 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "W");
                }
                if (b4 == 1 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "X");
                }
                if (b4 == 1 && b3 == 0 && b2 == 0 && b1 == 1 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "Y");
                }
                if (b4 == 1 && b3 == 0 && b2 == 1 && b1 == 0 && b5 == 1 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "Z");
                }
                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "0");
                }
                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 1 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "1");
                }
                if (b4 == 0 && b3 == 0 && b2 == 1 && b1 == 0 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "2");
                }
                if (b4 == 0 && b3 == 0 && b2 == 1 && b1 == 1 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "3");
                }
                if (b4 == 0 && b3 == 1 && b2 == 0 && b1 == 0 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "4");
                }
                if (b4 == 0 && b3 == 1 && b2 == 0 && b1 == 1 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "5");
                }
                if (b4 == 0 && b3 == 1 && b2 == 1 && b1 == 0 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "6");
                }
                if (b4 == 0 && b3 == 1 && b2 == 1 && b1 == 1 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "7");
                }
                if (b4 == 1 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "8");
                }
                if (b4 == 1 && b3 == 0 && b2 == 0 && b1 == 1 && b5 == 1 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "9");
                }
                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 0 && b6 == 1)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "");
                }
                if (b4 == 0 && b3 == 0 && b2 == 0 && b1 == 0 && b5 == 0 && b6 == 0)
                {
                    TargetIdentification_decoded = String.Concat(TargetIdentification_decoded, "");
                }

                i = i + 1;

            }

        }
        public void Calculate_VehicleFleetIdentification(string paquete)
        {
            int vfi1 = Convert.ToInt32(paquete, 2);
            if (vfi1 == 0) { VFI = "Unknown."; }
            if (vfi1 == 1) { VFI = "ATC equipment maintenance."; }
            if (vfi1 == 2) { VFI = "Airport maintenance."; }
            if (vfi1 == 3) { VFI = "Fire."; }
            if (vfi1 == 4) { VFI = "Bird scarer."; }
            if (vfi1 == 5) { VFI = "Snow plough."; }
            if (vfi1 == 6) { VFI = "Runway sweeper."; }
            if (vfi1 == 7) { VFI = "Emergency."; }
            if (vfi1 == 8) { VFI = "Police."; }
            if (vfi1 == 9) { VFI = "Bus."; }
            if (vfi1 == 10) { VFI = "Tug(push/tow)."; }
            if (vfi1 == 11) { VFI = "Grass cuttert."; }
            if (vfi1 == 12) { VFI = "Fuel."; }
            if (vfi1 == 13) { VFI = "Baggage."; }
            if (vfi1 == 14) { VFI = "Catering."; }
            if (vfi1 == 15) { VFI = "Aircraft maintenance."; }
            if (vfi1 == 16) { VFI = "Flyco(follow me)."; }
        }
        public void Calculate_TargetSizeOrientation(string paquete)
        {
            string length = paquete.Substring(0, 7);
            Length = Convert.ToInt32(length,2);

            if(paquete.Length>8)
            {
                string orientation = paquete.Substring(8, 7);
                Orientation = Convert.ToInt32(orientation,2) * 360 / 128;

                if(paquete.Length>16)
                {
                    string width = paquete.Substring(16, 7);
                    Width = Convert.ToInt32(width, 2);
                }
            }
        }
        public void Calculate_SystemStatus(string paquete)
        {
            string nogo = paquete.Substring(0, 2);
            if (nogo == "00") { NOGO = "Operational."; }
            if (nogo == "01") { NOGO = "Degraded."; }
            if (nogo == "10") { NOGO = "NOGO"; }

            string ovl = paquete.Substring(2, 1);
            if (ovl == "0") { OVL = "No overload."; }
            else { OVL = "Overload."; }

            string tsv = paquete.Substring(3, 1);
            if (tsv == "0") { TSV = "Valid."; }
            else { TSV = "Invalid."; }

            string div = paquete.Substring(4, 1);
            if (div == "0") { DIV = "Normal operation."; }
            else { DIV = "Diversity degraded."; }

            string ttf = paquete.Substring(5, 0);
            if (ttf == "0") { TTF = "Test Target Operative."; }
            else { TTF = "Test Target Failure."; }
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

            while (FSPEC_fake.Length < (4 * 8))
            {
                FSPEC_fake = String.Concat(FSPEC_fake, "0");
            }

            data_position = 1 + 2 + ((FSPEC.Length) / 8);

            //-------------------------------------------------------------------------------------------------------------
            // Aqui porocesamos los parametros que hemos encontrado en el FSPEC
            //-------------------------------------------------------------------------------------------------------------

            if (Char.ToString(FSPEC_fake[0]) == "1") // 1 I021/010 Data Source Identification
            {

                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position+1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                DataSourceIdentifier = String.Concat(string1, string2);

                data_position = data_position + 2;

                Calculate_DataSourceIdentification(DataSourceIdentifier);

            } // 1 I021/010 Data Source Identification

            if (Char.ToString(FSPEC_fake[1]) == "1") // 2 I010/000 Message Type 
            {

                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                MessageType = string1;

                data_position = data_position + 1;

                Calculate_MessageType(MessageType);

            }// 2 I010/000 Message Type 

            if (Char.ToString(FSPEC_fake[2]) == "1") // 3 I010/020 Target Report Descriptor  
            {
                // primero leemos el primer paquete y lo pasamos a binario

                string string_packet = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                string_packet = AddZeros(string_packet);

                if ((Convert.ToString(string_packet[7])) == "0") // si ultima posicion es un 0 guardamos el octeto y pasamos al siguiente
                {
                    TargetReportDescriptor = string_packet;
                    data_position = data_position + 1;
                }
                if ((Convert.ToString(string_packet[7])) == "1") // si ultimo valor =1 hacemos un bucle que vaya concatenando todos los octetos acabados en 1
                {
                    i = 0;
                    data_position = data_position + 1;
                    while ((Convert.ToString(string_packet[string_packet.Length - 1])) == "1")
                    {
                        string string_packet2 = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                        string_packet2 = AddZeros(string_packet2);
                        string_packet = string.Concat(string_packet, string_packet2);
                        data_position = data_position + 1;
                        i = i + 1;
                    }
                }

                TargetReportDescriptor = string_packet;

                Calculate_TargetReportDescriptor(TargetReportDescriptor);

            } // 3 I010/020 Target Report Descriptor  

            if (Char.ToString(FSPEC_fake[3]) == "1") // 4 I010 / 140 Time of Day
            {

                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position +1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string2);

                data_position = data_position + 3;

                TimeofDay = String.Concat(string1, string2, string3);

                TimeofDay_seconds = Convert.ToInt32(TimeofDay,2)/128;

            }// 4 I010 / 140 Time of Day

            if (Char.ToString(FSPEC_fake[4]) == "1") // 5 I010 / 041  Position in WGS-84 Co-ordinates 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                string string5 = Convert.ToString(paquete[data_position + 4]);
                string5 = Convert.ToString(Convert.ToInt32(string5, 16), 2);
                string5 = AddZeros(string5);

                string string6 = Convert.ToString(paquete[data_position + 5]);
                string6 = Convert.ToString(Convert.ToInt32(string6, 16), 2);
                string6 = AddZeros(string6);

                string string7 = Convert.ToString(paquete[data_position + 6]);
                string7 = Convert.ToString(Convert.ToInt32(string7, 16), 2);
                string7 = AddZeros(string7);

                string string8 = Convert.ToString(paquete[data_position + 7]);
                string8 = Convert.ToString(Convert.ToInt32(string8, 16), 2);
                string8 = AddZeros(string8);

                PositioninWGS84_coordinates = String.Concat(string1, string2, string3, string4, string5, string6, string7, string8);

                data_position = data_position + 8;

                Calculate_PositionWGS84_coordinates(PositioninWGS84_coordinates);

            } // 5 I010 / 041  Position in WGS-84 Co-ordinates 

            if (Char.ToString(FSPEC_fake[5]) == "1") // 6 I010/040  Measured Position in Polar Co-ordinates 
            {

                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                data_position = data_position + 4;

                MeasuredPositioninPolarCoordinates = String.Concat(string1, string2, string3, string4);

                string rho1 = (MeasuredPositioninPolarCoordinates.Substring(0, 16));
                string theta1 = (MeasuredPositioninPolarCoordinates.Substring(16, 16));

                Rho = Convert.ToInt32(rho1, 2);
                Theta = Convert.ToInt32(theta1, 2) * 360 / (Math.Pow(2, 16));

            }// 6 I010/040  Measured Position in Polar Co-ordinates 

            if (Char.ToString(FSPEC_fake[6]) == "1") // 7 I010/042  Position in Cartesian Co-ordinates
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                PositioninCartesianCoordinates = String.Concat(string1, string2, string3, string4);

                data_position = data_position + 4;

                string xcartesian = (PositioninCartesianCoordinates.Substring(0, 16));
                string ycartesian = (PositioninCartesianCoordinates.Substring(16, 16));

                X_cartesian = Calculate_ComplementoA2(xcartesian);
                Y_cartesian = Calculate_ComplementoA2(ycartesian);

            }// 7 I010/042  Position in Cartesian Co-ordinates

            if (Char.ToString(FSPEC_fake[7]) == "1") // 8 - _FX
            {

            } // FX

            if (Char.ToString(FSPEC_fake[8]) == "1") // 8 I010/200  Calculated Track Velocity in Polar Co-ordinates
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                CalculatedTrackVelocityinPolarCoordinates = String.Concat(string1, string2, string3, string4);

                data_position = data_position + 4;

                string gs1 = CalculatedTrackVelocityinPolarCoordinates.Substring(0, 16);
                string ta1 = CalculatedTrackVelocityinPolarCoordinates.Substring(16, 16);

                GroundSpeed = Convert.ToInt32(gs1, 2) * (Math.Pow(2, -14));
                TrackAngle = Convert.ToInt32(ta1, 2) * 360/(Math.Pow(2, 16));
            }// 8 I010/200  Calculated Track Velocity in Polar Co-ordinates

            if (Char.ToString(FSPEC_fake[9]) == "1") // 9 I010/202  Calculated Track Velocity in Cartesian Coord
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                CalculatedTrackVelocityinCartesianCoordinates = String.Concat(string1, string2, string3, string4);
                data_position = data_position + 4;

                string vx = CalculatedTrackVelocityinCartesianCoordinates.Substring(0, 16);
                string vy = CalculatedTrackVelocityinCartesianCoordinates.Substring(16, 16);

                Vx_cartesian = Calculate_ComplementoA2(vx) * 0.25;
                Vy_cartesian = Calculate_ComplementoA2(vy) * 0.25;
            } // 9 I010/202  Calculated Track Velocity in Cartesian Coord

            if (Char.ToString(FSPEC_fake[10]) == "1") // 10 I010/161  Track Number 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                TrackNumber = String.Concat(string1, string2);

                data_position = data_position + 2;

                string tn = TrackNumber.Substring(4, 12);
                Tracknumber_value = Convert.ToInt32(tn,2);

            } // 10 I010/161  Track Number 

            if (Char.ToString(FSPEC_fake[11]) == "1") // 11 I010/170  Track Status 
            {
                // primero leemos el primer paquete y lo pasamos a binario

                string string_packet = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                string_packet = AddZeros(string_packet);

                if ((Convert.ToString(string_packet[7])) == "0") // si ultima posicion es un 0 guardamos el octeto y pasamos al siguiente
                {
                    TrackStatus = string_packet;
                    data_position = data_position + 1;
                }
                if ((Convert.ToString(string_packet[7])) == "1") // si ultimo valor =1 hacemos un bucle que vaya concatenando todos los octetos acabados en 1
                {
                    i = 0;
                    data_position = data_position + 1;
                    while ((Convert.ToString(string_packet[string_packet.Length - 1])) == "1")
                    {
                        string string_packet2 = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                        string_packet2 = AddZeros(string_packet2);
                        string_packet = string.Concat(string_packet, string_packet2);
                        data_position = data_position + 1;
                        i = i + 1;
                    }
                }

                TrackStatus = string_packet;

                Calculate_TrackStatus(TrackStatus);

            }// 11 I010/170  Track Status 

            if (Char.ToString(FSPEC_fake[12]) == "1") // 12  I010/060  Mode-3/A Code in Octal Representation 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                Mode3ACodeinOctal = String.Concat(string1, string2);

                data_position = data_position + 2;

                Calculate_Mode3ACode_octal(Mode3ACodeinOctal);

            }// 12  I010/060  Mode-3/A Code in Octal Representation 

            if (Char.ToString(FSPEC_fake[13]) == "1") // 13  I010 / 220 Target Adress 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                TargetAdress = String.Concat(string1, string2,string3);

                data_position = data_position + 3;

                TargetAdress_decoded = Convert.ToInt32(TargetAdress, 2);
            }// 13  I010 / 220 Target Adress 

            if (Char.ToString(FSPEC_fake[14]) == "1") // 14  I010/245 Target Identification   
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                string string5 = Convert.ToString(paquete[data_position + 4]);
                string5 = Convert.ToString(Convert.ToInt32(string5, 16), 2);
                string5 = AddZeros(string5);

                string string6 = Convert.ToString(paquete[data_position + 5]);
                string6 = Convert.ToString(Convert.ToInt32(string6, 16), 2);
                string6 = AddZeros(string6);

                string string7 = Convert.ToString(paquete[data_position + 6]);
                string7 = Convert.ToString(Convert.ToInt32(string7, 16), 2);
                string7 = AddZeros(string7);

                TargetIdentification = String.Concat(string1, string2, string3,string4,string5,string6,string7);

                data_position = data_position + 7;

                string sti1 = TargetIdentification.Substring(0, 2);
                if (sti1 == "00") { STI = "Callsign or registration downlinked from transponder."; }
                if (sti1 == "01") { STI = "Callsign not downlinked from transponder."; }
                else { STI = "Registration not downlinked from transponder."; }

                string todecode = TargetIdentification.Substring(2, 48);

                Calculate_TargetIdentification(todecode);

            } // 14  I010/245 Target Identification 

            if (Char.ToString(FSPEC_fake[15]) == "1")  // FX - Field Extension Indicator
            {

            } // FX

            if (Char.ToString(FSPEC_fake[16]) == "1") // 15  I010/250  Mode S MB Data
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                string string5 = Convert.ToString(paquete[data_position + 4]);
                string5 = Convert.ToString(Convert.ToInt32(string5, 16), 2);
                string5 = AddZeros(string5);

                string string6 = Convert.ToString(paquete[data_position + 5]);
                string6 = Convert.ToString(Convert.ToInt32(string6, 16), 2);
                string6 = AddZeros(string6);

                string string7 = Convert.ToString(paquete[data_position + 6]);
                string7 = Convert.ToString(Convert.ToInt32(string7, 16), 2);
                string7 = AddZeros(string7);

                string string8 = Convert.ToString(paquete[data_position + 6]);
                string8 = Convert.ToString(Convert.ToInt32(string8, 16), 2);
                string8 = AddZeros(string8);

                string string9 = Convert.ToString(paquete[data_position + 6]);
                string9 = Convert.ToString(Convert.ToInt32(string9, 16), 2);
                string9 = AddZeros(string9);

                ModeSMBData = String.Concat(string1, string2, string3, string4, string5, string6, string7,string8,string9);

                data_position = data_position + 9;

            }// 15  I010/250  Mode S MB Data

            if (Char.ToString(FSPEC_fake[17]) == "1") // 16  I010/300 Vehicle Fleet Identification 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                data_position = data_position + 1;

                VehicleFleetIdentification = string1;
                Calculate_VehicleFleetIdentification(VehicleFleetIdentification);
            } // 16  I010/300 Vehicle Fleet Identification 

            if (Char.ToString(FSPEC_fake[18]) == "1") // 17  I010/090 Flight Level in Binary Representation 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);


                data_position = data_position + 2;

                FlightLevelInBinaryRepresentation = String.Concat(string1, string2);

                string v1 = FlightLevelInBinaryRepresentation.Substring(0, 1);
                if (v1 == "0") { V_fl = "Code validated."; }
                else { V_fl = "Code not validated."; }

                string g1 = FlightLevelInBinaryRepresentation.Substring(1, 1);
                if (g1 == "0") { G_fl = "Default."; }
                else { G_fl = "Garbled code."; }

                string fl = FlightLevelInBinaryRepresentation.Substring(2, 14);
                FlightLevel = Calculate_ComplementoA2(fl) * 0.25;

            }// 17  I010/090 Flight Level in Binary Representation 

            if (Char.ToString(FSPEC_fake[19]) == "1") // 18  I010/091 Measured Height 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);


                data_position = data_position + 2;

                MeasuredHeight = String.Concat(string1, string2);

                MeasuredHeight_ft =Calculate_ComplementoA2(MeasuredHeight) * 6.26;

            }// 18  I010/091 Measured Height 

            if (Char.ToString(FSPEC_fake[20]) == "1") // 19  I010/270 Target Size & Orientation
            {
                // primero leemos el primer paquete y lo pasamos a binario

                string string_packet = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                string_packet = AddZeros(string_packet);

                if ((Convert.ToString(string_packet[7])) == "0") // si ultima posicion es un 0 guardamos el octeto y pasamos al siguiente
                {
                    TargetSizeOrientation = string_packet;
                    data_position = data_position + 1;
                }
                if ((Convert.ToString(string_packet[7])) == "1") // si ultimo valor =1 hacemos un bucle que vaya concatenando todos los octetos acabados en 1
                {
                    i = 0;
                    data_position = data_position + 1;
                    while ((Convert.ToString(string_packet[string_packet.Length - 1])) == "1")
                    {
                        string string_packet2 = Convert.ToString(Convert.ToInt32(paquete[data_position], 16), 2);
                        string_packet2 = AddZeros(string_packet2);
                        string_packet = string.Concat(string_packet, string_packet2);
                        data_position = data_position + 1;
                        i = i + 1;
                    }
                }

                TargetSizeOrientation = string_packet;

                Calculate_TargetSizeOrientation(TargetSizeOrientation);
            }// 19  I010/270 Target Size & Orientation

            if (Char.ToString(FSPEC_fake[21]) == "1") // 20  I010/550 System Status
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);


                data_position = data_position + 1;

                SystemStatus = string1;

                Calculate_SystemStatus(SystemStatus);
            } // 20  I010/550 System Status

            if (Char.ToString(FSPEC_fake[22]) == "1") // 21  I010/310 Pre-programmed Message
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                data_position = data_position + 1;

                PreProgrammedMessage = string1;

                string trb = PreProgrammedMessage.Substring(0, 1);
                if (trb == "0") { TRB = "Default."; }
                else { TRB = "In Trouble."; }

                string msg = PreProgrammedMessage.Substring(1, 7);
                int msg1 = Convert.ToInt32(msg, 2);
                if (msg1 == 1) { MSG = "Towing aircraft."; }
                if (msg1 == 2) { MSG = "“Follow me” operation."; }
                if (msg1 == 3) { MSG = "Runway check."; }
                if (msg1 == 4) { MSG = "Emergency operation (fire, medical…)."; }
                if (msg1 == 5) { MSG = "Work in progress (maintenance, birds scarer, sweepers…)"; }

            }// 21  I010/310 Pre-programmed Message

            if (Char.ToString(FSPEC_fake[23]) == "1")  // FX - Field Extension Indicator
            {

            } // FX

            if (Char.ToString(FSPEC_fake[24]) == "1") // 22 I010/500   Standard Deviation of Position 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                string string4 = Convert.ToString(paquete[data_position + 3]);
                string4 = Convert.ToString(Convert.ToInt32(string4, 16), 2);
                string4 = AddZeros(string4);

                StandardDeviationofPosition = String.Concat(string1, string2, string3, string4);

                data_position = data_position + 4;

                string sdx = StandardDeviationofPosition.Substring(0, 8);
                string sdy = StandardDeviationofPosition.Substring(8, 8);
                string sdxy = StandardDeviationofPosition.Substring(16, 16);

                StdDeviation_x = Convert.ToInt32(sdx,2) * 0.25;
                StdDeviation_y = Convert.ToInt32(sdy, 2) * 0.25;
                StdDeviation_xy = Convert.ToInt32(sdxy, 2) * 0.25;
            } // 22 I010/500   Standard Deviation of Position 

            if (Char.ToString(FSPEC_fake[25]) == "1") // 23  I010/280  Presence 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position + 1]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                string string3 = Convert.ToString(paquete[data_position + 2]);
                string3 = Convert.ToString(Convert.ToInt32(string3, 16), 2);
                string3 = AddZeros(string3);

                Presence = String.Concat(string1, string2, string3);

                data_position = data_position + 3;

                string rep1 = Presence.Substring(0, 8);
                REP = Convert.ToInt32(rep1, 2);

                string drho = Presence.Substring(8, 8);
                DRHO = Convert.ToInt32(drho, 2);

                string dtheta = Presence.Substring(16, 8);
                DRHO = Convert.ToInt32(dtheta, 2)*0.15;
            }// 23  I010/280  Presence 

            if (Char.ToString(FSPEC_fake[26]) == "1") // 24  I010/131  Amplitude of Primary Plot 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                AmplitudeofPrimaryPlot = string1;

                data_position = data_position + 1;

                AmplitudeofPrimaryPlot_value = Convert.ToInt32(AmplitudeofPrimaryPlot, 2);
            }// 24  I010/131  Amplitude of Primary Plot 

            if (Char.ToString(FSPEC_fake[27]) == "1") // 25  I010/210  Calculated Acceleration 
            {
                string string1 = Convert.ToString(paquete[data_position]);
                string1 = Convert.ToString(Convert.ToInt32(string1, 16), 2);
                string1 = AddZeros(string1);

                string string2 = Convert.ToString(paquete[data_position]);
                string2 = Convert.ToString(Convert.ToInt32(string2, 16), 2);
                string2 = AddZeros(string2);

                CalculatedAcceleration = String.Concat(string1, string2);

                data_position = data_position + 2;

                CalculatedAcceleration_X = Calculate_ComplementoA2(CalculatedAcceleration.Substring(0, 8));
                CalculatedAcceleration_Y = Calculate_ComplementoA2(CalculatedAcceleration.Substring(8, 8));
            } // 25  I010/210  Calculated Acceleration 
        }
    }
}
