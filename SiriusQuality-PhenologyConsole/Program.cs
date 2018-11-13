using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiriusQuality_PhenologyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Mandatory Inputs
            //Other Inputs can be deduced from that ones see Main function

            //photoperiod
            double[] dayLength = { 12.132555044855,12.1668362308466,12.2011023194079,12.2353485304588,12.269570082415,12.3037621834005,
                                  12.3379200225299,12.3720387612652,12.4061135248542,12.4401393938565,12.4741113957629,
                                  12.5080244967156,12.5418735933362,12.5756535046696,12.6093589642524,12.6429846123131,
                                  12.6765249881168,12.7099745224613,12.7433275303389,12.7765782037736,12.8097206048485,
                                  12.8427486589353,12.8756561481429,12.908436704999,12.9410838063826,12.9735907677247,
                                  13.0059507374967,13.0381566920056,13.0702014305177,13.1020775707322,13.1337775446285,
                                  13.1652935947095,13.1966177706681,13.2277419265005,13.2586577180936,13.2893566013143,
                                  13.3198298306271,13.3500684582698,13.3800633340141,13.4098051055424,13.4392842194669,
                                  13.468490923022,13.4974152664568,13.5260471061574,13.5543761085236,13.5823917546292,
                                  13.6100833456875,13.6374400093484,13.6644507068463,13.6911042410194,13.7173892652171,
                                  13.7432942931094,13.7688077094101,13.793917781521,13.8186126721012,13.8428804525627,
                                  13.8667091174857,13.8900865999472,13.9130007877478,13.9354395405171,13.9573907076751,
                                  13.9788421472178,13.9997817452917,14.0201974365164,14.0400772250054,14.0594092060334,
                                  14.078181588288,14.0963827166422,14.114001095373,14.1310254117512,14.1474445599174,
                                  14.1632476649571,14.1784241070815,14.1929635458173,14.2068559441032,14.2200915921908 };

            //Thermal Time of the day

            double[] deltaTTShoot ={ 21.3016064396306,18.9386542197517,15.6669302569715,16.8644225809839,19.2154984113532,20.3429985011972,
                                    19.4362277750342,12.7412196749015,13.4621490558403,15.5321149770776,18.9876789824015,
                                    21.4678115042348,21.8835317387586,22.3082580098962,22.4215765261747,11.9771589046418,
                                    16.9351057444655,20.9395278133385,24.1598233951257,23.8708583419468,23.5895677277199,
                                    22.9443265051839,18.609513059493,23.6364918068571,20.3112614777188,18.4203255995954,
                                    15.7060483551019,20.2206687426112,18.773892315995,18.2046073704782,14.679923725633,
                                    17.6968538013731,19.4592880912991,15.6836959061883,18.2634381351946,19.1506389098961,
                                    20.2675830978648,18.0964848615109,19.3423343283172,21.7893939077166,19.2854127879827,
                                    20.2046349607756,18.8331080264541,18.0904934289845,14.2864972429511,13.4975457665717,
                                    15.5099933846258,15.8056060524327,17.0999894230251,18.968828420662,19.7084276956706,
                                    18.3808612134954,17.6569929404518,17.5512091484625,16.9486734285003,17.9557501423195,
                                    18.0133246919647,19.3630413473033,18.4492464572252,18.6716428339012,17.3655500894382,
                                    16.8128222344238,15.1523436391195,17.7568910712895,19.7690870277131,19.4255849454613,
                                    21.2182022418101,20.9577458752311,21.1926239701876,22.4114886477857,23.2541291515213,
                                    23.8603416160884,25.1187578254212,24.1775006707492,19.3651317764506,18.3441425421464};

            //Total Plant Green Area Index

            double[] GAI ={0,0,0,0,0,0,
                          0,0.0307692307692308,0.0615384615384615,0.0714659697105823,0.0946619351127146,
                          0.128178958499091,0.174268339300665,0.226659194443595,0.2137397152819,0.279874189539498,
                          0.3255196285135,0.3255196285135,0.3255196285135,0.357995935829647,0.528754329171576,
                          0.631916148688657,0.766200576278237,0.849676770294943,1.11811376057582,1.29127450724952,
                          1.37330115115515,1.55280204372017,1.78327062095002,2.08829962881175,2.38937396195281,
                          2.6917370697869,3.00552342042113,3.29672061814509,3.59114828887509,3.92276726133061,
                          4.24651116644063,4.5649752026531,4.88389471318169,5.08767042112544,5.34720413306698,
                          5.56204998127326,5.81110486706077,6.05915211009998,6.26770886552299,6.45450059053677,
                          6.63400826139249,6.84028004113759,6.84028004113759,6.84028004113759,6.84028004113759,
                          6.84028004113759,6.84028004113759,6.84028004113759,6.84028004113759,6.78399881545537,
                          6.73838650127907,6.69013292273329,6.64719182175372,6.45177438608201,6.26962378718177,
                          6.05748777772231,5.84756421499098,5.67819202434539,5.49850763720017,5.13376056681224,
                          4.70434672399226,4.2447586243423,3.85717942095424,3.49901549685466,3.13162660152541,
                          2.33258750368702,1.4759692382479,0.329043835030131,0,0};

            //Photosynthetically Active Radiations intercepted by the plant

            double[] PAR ={10.992,4.8,10.128,10.368,12,11.472,
                           12.096,12.672,12.816,12.816,12.912,
                           12.912,12.816,12.48,11.856,9.744,
                           13.008,12.432,11.328,12.576,12.864,
                           12.768,12.576,13.152,13.584,13.728,
                           9.168,13.68,13.68,14.16,9.264,
                           12.576,12.24,14.16,14.256,14.304,
                           14.064,14.112,11.424,13.68,13.344,
                           10.08,13.92,14.688,12.576,14.928,
                           15.024,14.592,14.256,14.448,14.496,
                           14.544,14.448,14.256,14.4,14.592,
                           12.096,14.352,14.688,14.4,14.88,
                           15.456,15.456,15.264,14.928,14.736,
                           14.304,15.024,15.216,15.792,15.696,
                           15.312,14.448,11.472,15.216,14.352};


            //Tag for expantion of last created internode, 1: the stem expand, 0: it doesn't

            bool[] isLatestLeafInternodeLengthPotPositive = { 
                                false,false,false,false,false,false,
                                false,false,false,false,false,
                                false,false,false,false,false,
                                false,false,false,false,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true,
                                true,true,true,true,true};


            //Sowing Date
            DateTime SowingDate = new DateTime(2007, 3, 21);

            //Cumulative Thermal Time day by day before sowing
            double cumulTTatSowing = 0.0;


            #endregion

            #region Initialization of other inputs

            //Date of the Day
            DateTime currentDate;

            //Cumulative Thermal Time
            double cumulTT=0.0;

            //Cumulative thermal Time for Grain
            double grainCumulTT = 0.0;

            #endregion

            //Creation of a Phenology Wrapper object
            //It allows to call the outputs
            //and Call the initialization function and the Estimation one
            PhenologyWrapper phenology_ = new PhenologyWrapper();
            int iday = 0;

            #region Console Write

            string spaceZC = "               ";
            Console.WriteLine("Date" + spaceZC.Substring(0, spaceZC.Length - 4)
                            + "Haun Stage" + spaceZC.Substring(0, spaceZC.Length - 10)
                            + "Phase" + spaceZC.Substring(0, spaceZC.Length - 5) 
                            + "Zadok");
            #endregion

            //Initialization, register sowing moment
            phenology_.Init(cumulTTatSowing, SowingDate);

            //Daily loop
            while (phenology_.phaseValue < 7 && iday<75)//Stop the loop at maturity or before the end of the inputs tables
            {
                #region Calculation of others inputs
                
                currentDate=SowingDate.AddDays(iday);

                cumulTT+=deltaTTShoot[iday];

                //Grain Thermal Time is the plant cumulative thermal time from Anthesis to end of grain filling
                //It can be calculate a other way (special physiologigal response, stress factor multipliying...)
                if(phenology_.phaseValue==4 || phenology_.phaseValue==4.5) grainCumulTT+=deltaTTShoot[iday];

                #endregion

                //Estimate phenology each day
                phenology_.EstimatePhenology(dayLength[iday], deltaTTShoot[iday], cumulTT, grainCumulTT, GAI[iday], isLatestLeafInternodeLengthPotPositive[iday], PAR[iday], currentDate);
                //Set isLatestLeafInternodeLengthPotPositive=false and the stem elongation stage will be ignored
                
                iday++;


                #region Console Write

                // Call an output of the component
                // do phenology_.My output
                // e.g. phenology_.LeafNumber for leaf number
                //      phenology_.phaseValue for the phase value
                //      phenology_.calendar.LastGrowthStageSet for the Zadock stage
                //...

                int lenZC = spaceZC.Length;
                string cdate = currentDate.ToShortDateString();
                string LN = "";
                if (phenology_.LeafNumber != 0) LN = phenology_.LeafNumber.ToString().Substring(0, 5);
                else LN = phenology_.LeafNumber.ToString();
                string Ph=phenology_.phaseValue.ToString();
                string Zad = phenology_.calendar.LastGrowthStageSet.ToString();

                Console.WriteLine(cdate + spaceZC.Substring(0, lenZC - cdate.Length)
                                   + LN + spaceZC.Substring(0, lenZC - LN.Length)
                                   + Ph + spaceZC.Substring(0, lenZC - Ph.Length)
                                   +Zad);

                #endregion
            }


        }


    }
}
