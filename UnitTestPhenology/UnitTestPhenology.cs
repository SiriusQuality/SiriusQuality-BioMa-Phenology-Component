using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiriusQualityPhenology;
using System.Collections.Generic;

namespace UnitTestPhenology
{
    [TestClass]
    public class UnitTestPhenology
    {
        #region Instantiation

        private SiriusQualityPhenology.Strategies.Phenology phenologyComponent;
        private SiriusQualityPhenology.PhenologyState phenologyState;
        private SiriusQualityPhenology.PhenologyState previousphenologyState;

        #endregion

        #region Parameters values

        int SowingDay = 80;
        double Latitude = 33.069;
        double Rp = 0.003;
        double SDsa_sh = 151.0;
        double SDws = 90.0;
        double SDsa_nh = 200.0;
        double Ldecr = 3.0;
        double Lincr = 8.0;
        double Pdecr = 0.4;
        double Pincr = 1.25;
        double Dcd = 100.0;
        double Der = 300.0;
        double slopeTSFLN = 0.9;
        double intTSFLN = 2.6;
        double AMNLFNO = 5.5;
        double AMXLFNO = 24.0;
        double MinTvern = 0.0;
        double IntTvern = 11.0;
        double MaxTvern = 23.0;
        double MaxDL = 15.0;
        double MinDL = 8.0;
        double PFLLAnth = 2.22;
        double PHEADANTH = 1.0;
        double PNini = 4.0;
        double VBEE = 0.01;
        double TTWindowForPTQ = 70.0;
        double SowingDensity = 288.0;
        double TargetFertileShoot = 600.0;
        double P = 120.0;
        double VAI = 0.015;
        double SLDL = 0.85;
        double Dse = 105.0;
        double Dgf = 450.0;
        double Degfm = 0.0;
        double PTQhf = 0.97;
        double Kl = 0.45;
        double LARmin = 0.00252;
        double LARmax = 0.01512;
        double B = 0.315;
        double LNeff = 3.0;
        double AreaSL = 9.0;
        double AreaSS = 1.83;
        bool IgnoreGrainMaturation = false;
        string choosePhyllUse = "Default";

        #endregion

        [TestMethod]
        public void TestMethodWithVerna()
        {
            #region Instantiation

           phenologyComponent=new SiriusQualityPhenology.Strategies.Phenology();
           phenologyState= new SiriusQualityPhenology.PhenologyState();
           previousphenologyState=new SiriusQualityPhenology.PhenologyState();

            #endregion

            #region Load parameters

           phenologyComponent.AMNFLNO = AMNLFNO;
           phenologyComponent.AMXLFNO = AMXLFNO;
           phenologyComponent.Dcd = Dcd;
           phenologyComponent.Degfm = Degfm;
           phenologyComponent.Der = Der;
           phenologyComponent.Dgf = Dgf;
           phenologyComponent.Dse = Dse;
           phenologyComponent.IgnoreGrainMaturation = (IgnoreGrainMaturation) ? 1 : 0;
           phenologyComponent.IntTvern = IntTvern;
           phenologyComponent.IsVernalizable = 1;
           phenologyComponent.Ldecr = Ldecr;
           phenologyComponent.Lincr = Lincr;
           phenologyComponent.MaxDL = MaxDL;
           phenologyComponent.MaxTvern = MaxTvern;
           phenologyComponent.MinDL = MinDL;
           phenologyComponent.MinTvern = MinTvern;
           phenologyComponent.Pdecr = Pdecr;
           phenologyComponent.PFLLAnth = PFLLAnth;
           phenologyComponent.PHEADANTH = PHEADANTH;
           phenologyComponent.Pincr = Pincr;
           phenologyComponent.PNini = PNini;
           phenologyComponent.SLDL = SLDL;
           phenologyComponent.VAI = VAI;
           phenologyComponent.VBEE = VBEE;
           phenologyComponent.SowingDensity = SowingDensity;
           phenologyComponent.TargetFertileShoot = TargetFertileShoot;
           phenologyComponent.slopeTSFLN = slopeTSFLN;
           phenologyComponent.intTSFLN = intTSFLN;
           phenologyComponent.choosePhyllUse = choosePhyllUse;

           phenologyComponent.PTQhf = PTQhf;
           phenologyComponent.Kl = Kl;
           phenologyComponent.LARmin = LARmin;
           phenologyComponent.TTWindowForPTQ = TTWindowForPTQ;
           phenologyComponent.LARmax = LARmax;
           phenologyComponent.B = B;

           phenologyComponent.SowingDay = SowingDay;
           phenologyComponent.Latitude = Latitude;
           phenologyComponent.P = P;
           phenologyComponent.Rp = Rp;
           phenologyComponent.SDsa_sh = SDsa_sh;
           phenologyComponent.SDws = SDws;
           phenologyComponent.SDsa_nh = SDsa_nh;
            


            #endregion

            #region Inputs

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

            double[] cumulTT = {21.3016064396306,40.2402606593823,55.9071909163538,72.7716134973377,91.987111908691,112.330110409888,
                                131.766338184922,144.507557859824,157.969706915664,173.501821892742,192.489500875143,
                                213.957312379378,235.840844118137,258.149102128033,280.570678654207,292.547837558849,
                                309.482943303315,330.422471116653,354.582294511779,378.453152853726,402.042720581446,
                                424.98704708663,443.596560146123,467.23305195298,487.544313430698,505.964639030294,
                                521.670687385396,541.891356128007,560.665248444002,578.86985581448,593.549779540113,
                                611.246633341486,630.705921432785,646.389617338974,664.653055474168,683.803694384064,
                                704.071277481929,722.16776234344,741.510096671757,763.299490579474,782.584903367456,
                                802.789538328232,821.622646354686,839.713139783671,853.999637026622,867.497182793193,
                                883.007176177819,898.812782230252,915.912771653277,934.881600073939,954.59002776961,
                                972.970888983105,990.627881923557,1008.17909107202,1025.12776450052,1043.08351464284,
                                1061.0968393348,1080.45988068211,1098.90912713933,1117.58076997323,1134.94632006267,
                                1151.7591422971,1166.91148593622,1184.6683770075,1204.43746403522,1223.86304898068,
                                1245.08125122249,1266.03899709772,1287.23162106791,1309.64310971569,1332.89723886722,
                                1356.7575804833,1381.87633830872,1406.05383897947,1425.41897075592,1443.76311329807 };

            double[] grainCumulTT = { 0,0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      19.7084276956706,38.0892889091659,55.7462818496178,73.2974909980802,90.2461644265805,
                                      108.2019145689,126.215239260865,145.578280608168,164.027527065393,182.699169899294,
                                      200.064719988733,216.877542223156,232.029885862276,249.786776933565,269.555863961279,
                                      288.98144890674,310.19965114855,331.157397023781,352.350020993969,374.761509641754,
                                      398.015638793276,421.875980409364,446.994738234785,471.172238905534,471.172238905534, };

            DateTime SowingDate = new DateTime(2007, 3, 21);

            double cumulTTatSowing = 0.0;

            #endregion

            #region Ouputs

            double[] LN = { 0,0,0,0,0,0.557647985230187,
                            1.09043931678266,1.43970520699377,1.80873341576133,2.2345041114049,2.75499969754529,
                            3.34348137255173,3.58343237845917,3.82804047067294,4.07389109047749,4.20521958723891,
                            4.39091153619138,4.62051162186396,4.88542196610876,5.14716383389326,5.40582137476738,
                            5.6574039022365,5.86145558052042,6.12062763980613,6.34333884021971,6.54531609460124,
                            6.71753153709139,6.93924939611125,7.14510347852348,7.34471540144539,7.50567947738435,
                            7.69972392696081,7.91309331392681,8.08506366377536,8.24526926145251,8.41325732206563,
                            8.59104313871357,8.74978423398998,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,
                            8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118,8.91945383336118};


            double[] FLN = { 0,0,0,0,0,0,
                             0,0,0,0,0,
                             0,0,0,0,0,
                             0,0,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,
                             8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948,8.79758201319948};


            double[] PV = { 0,0,0,0,0,1,
                            1,1,1,1,1,
                            1,1,1,1,1,
                            1,1,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,3,3,
                            3,3,3,3,4,
                            4,4,4,4,4,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,5,6 };

            string[] ZS = { "Unknown","Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","ZC_21_MainShootPlus1Tiller","ZC_21_MainShootPlus1Tiller",
                            "ZC_21_MainShootPlus1Tiller","ZC_21_MainShootPlus1Tiller","ZC_21_MainShootPlus1Tiller","ZC_22_MainShootPlus2Tiller","BeginningStemExtension",
                            "TerminalSpikelet","ZC_30_PseudoStemErection","ZC_23_MainShootPlus3Tiller","ZC_31_1stNodeDetectable","ZC_31_1stNodeDetectable",
                            "ZC_31_1stNodeDetectable","ZC_31_1stNodeDetectable","ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable",
                            "ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling",
                            "ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling" };

            double[] PH = { 36.48,36.48,36.48,36.48,36.48,36.48,
                            36.48,36.48,36.48,36.48,36.48,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114,
                            114,114,114,114,114 };

            double[] VP = { 0.0863084257037371,0.192393692314103,0.326547334966024,0.449801765048609,0.551725418737689,0.642954494510562,
                            0.741713491635679,0.90085374182204,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,
                            1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716,1.05325268295716 };

            int[] TN = { 1,1,1,1,1,1,
                         1,1,1,1,1,
                         2,2,2,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3,
                         3,3,3,3,3};


            double[] CSN = { 288,288,288,288,288,288,
                             288,288,288,288,288,
                             576,576,576,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600 };

            double[] FP = { 91.2,91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2 };

            List<List<double>> TP = new List<List<double>>();
            TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>());

                    TP[0].Add(288);
                    TP[1].Add(288);
                    TP[2].Add(288);
                    TP[3].Add(288);
                    TP[4].Add(288);
                    TP[5].Add(288);
                    TP[6].Add(288);
                    TP[7].Add(288);
                    TP[8].Add(288);
                    TP[9].Add(288);
                    TP[10].Add(288);
                    TP[11].Add(288); TP[11].Add(288);
                    TP[12].Add(288); TP[12].Add(288);
                    TP[13].Add(288); TP[13].Add(288);
                    TP[14].Add(288); TP[14].Add(288); TP[14].Add(24);
                    TP[15].Add(288); TP[15].Add(288); TP[15].Add(24);
                    TP[16].Add(288); TP[16].Add(288); TP[16].Add(24);
                    TP[17].Add(288); TP[17].Add(288); TP[17].Add(24);
                    TP[18].Add(288); TP[18].Add(288); TP[18].Add(24);
                    TP[19].Add(288); TP[19].Add(288); TP[19].Add(24);
                    TP[20].Add(288); TP[20].Add(288); TP[20].Add(24);
                    TP[21].Add(288); TP[21].Add(288); TP[21].Add(24);
                    TP[22].Add(288); TP[22].Add(288); TP[22].Add(24);
                    TP[23].Add(288); TP[23].Add(288); TP[23].Add(24);
                    TP[24].Add(288); TP[24].Add(288); TP[24].Add(24);
                    TP[25].Add(288); TP[25].Add(288); TP[25].Add(24);
                    TP[26].Add(288); TP[26].Add(288); TP[26].Add(24);
                    TP[27].Add(288); TP[27].Add(288); TP[27].Add(24);
                    TP[28].Add(288); TP[28].Add(288); TP[28].Add(24);
                    TP[29].Add(288); TP[29].Add(288); TP[29].Add(24);
                    TP[30].Add(288); TP[30].Add(288); TP[30].Add(24);
                    TP[31].Add(288); TP[31].Add(288); TP[31].Add(24);
                    TP[32].Add(288); TP[32].Add(288); TP[32].Add(24);
                    TP[33].Add(288); TP[33].Add(288); TP[33].Add(24);
                    TP[34].Add(288); TP[34].Add(288); TP[34].Add(24);
                    TP[35].Add(288); TP[35].Add(288); TP[35].Add(24);
                    TP[36].Add(288); TP[36].Add(288); TP[36].Add(24);
                    TP[37].Add(288); TP[37].Add(288); TP[37].Add(24);
                    TP[38].Add(288); TP[38].Add(288); TP[38].Add(24);
                    TP[39].Add(288); TP[39].Add(288); TP[39].Add(24);
                    TP[40].Add(288); TP[40].Add(288); TP[40].Add(24);
                    TP[41].Add(288); TP[41].Add(288); TP[41].Add(24);
                    TP[42].Add(288); TP[42].Add(288); TP[42].Add(24);
                    TP[43].Add(288); TP[43].Add(288); TP[43].Add(24);
                    TP[44].Add(288); TP[44].Add(288); TP[44].Add(24);
                    TP[45].Add(288); TP[45].Add(288); TP[45].Add(24);
                    TP[46].Add(288); TP[46].Add(288); TP[46].Add(24);
                    TP[47].Add(288); TP[47].Add(288); TP[47].Add(24);
                    TP[48].Add(288); TP[48].Add(288); TP[48].Add(24);
                    TP[49].Add(288); TP[49].Add(288); TP[49].Add(24);
                    TP[50].Add(288); TP[50].Add(288); TP[50].Add(24);
                    TP[51].Add(288); TP[51].Add(288); TP[51].Add(24);
                    TP[52].Add(288); TP[52].Add(288); TP[52].Add(24);
                    TP[53].Add(288); TP[53].Add(288); TP[53].Add(24);
                    TP[54].Add(288); TP[54].Add(288); TP[54].Add(24);
                    TP[55].Add(288); TP[55].Add(288); TP[55].Add(24);
                    TP[56].Add(288); TP[56].Add(288); TP[56].Add(24);
                    TP[57].Add(288); TP[57].Add(288); TP[57].Add(24);
                    TP[58].Add(288); TP[58].Add(288); TP[58].Add(24);
                    TP[59].Add(288); TP[59].Add(288); TP[59].Add(24);
                    TP[60].Add(288); TP[60].Add(288); TP[60].Add(24);
                    TP[61].Add(288); TP[61].Add(288); TP[61].Add(24);
                    TP[62].Add(288); TP[62].Add(288); TP[62].Add(24);
                    TP[63].Add(288); TP[63].Add(288); TP[63].Add(24);
                    TP[64].Add(288); TP[64].Add(288); TP[64].Add(24);
                    TP[65].Add(288); TP[65].Add(288); TP[65].Add(24);
                    TP[66].Add(288); TP[66].Add(288); TP[66].Add(24);
                    TP[67].Add(288); TP[67].Add(288); TP[67].Add(24);
                    TP[68].Add(288); TP[68].Add(288); TP[68].Add(24);
                    TP[69].Add(288); TP[69].Add(288); TP[69].Add(24);
                    TP[70].Add(288); TP[70].Add(288); TP[70].Add(24);
                    TP[71].Add(288); TP[71].Add(288); TP[71].Add(24);
                    TP[72].Add(288); TP[72].Add(288); TP[72].Add(24);
                    TP[73].Add(288); TP[73].Add(288); TP[73].Add(24);
                    TP[74].Add(288); TP[74].Add(288); TP[74].Add(24);
                    TP[75].Add(288); TP[75].Add(288); TP[75].Add(24);

            List<List<double>> LTA = new List<List<double>>();
            LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>());
           
            LTA[5].Add(1);
            LTA[6].Add(1);LTA[6].Add(1);
            LTA[7].Add(1);LTA[7].Add(1);
            LTA[8].Add(1);LTA[8].Add(1);
            LTA[9].Add(1);LTA[9].Add(1);LTA[9].Add(1);
            LTA[10].Add(1);LTA[10].Add(1);LTA[10].Add(1);
            LTA[11].Add(1);LTA[11].Add(1);LTA[11].Add(1);LTA[11].Add(2);
            LTA[12].Add(1);LTA[12].Add(1);LTA[12].Add(1);LTA[12].Add(2);
            LTA[13].Add(1);LTA[13].Add(1);LTA[13].Add(1);LTA[13].Add(2);
            LTA[14].Add(1);LTA[14].Add(1);LTA[14].Add(1);LTA[14].Add(2);LTA[14].Add(3);
            LTA[15].Add(1);LTA[15].Add(1);LTA[15].Add(1);LTA[15].Add(2);LTA[15].Add(3);
            LTA[16].Add(1);LTA[16].Add(1);LTA[16].Add(1);LTA[16].Add(2);LTA[16].Add(3);
            LTA[17].Add(1);LTA[17].Add(1);LTA[17].Add(1);LTA[17].Add(2);LTA[17].Add(3);
            LTA[18].Add(1);LTA[18].Add(1);LTA[18].Add(1);LTA[18].Add(2);LTA[18].Add(3);
            LTA[19].Add(1);LTA[19].Add(1);LTA[19].Add(1);LTA[19].Add(2);LTA[19].Add(3);LTA[19].Add(3);
            LTA[20].Add(1);LTA[20].Add(1);LTA[20].Add(1);LTA[20].Add(2);LTA[20].Add(3);LTA[20].Add(3);
            LTA[21].Add(1);LTA[21].Add(1);LTA[21].Add(1);LTA[21].Add(2);LTA[21].Add(3);LTA[21].Add(3);
            LTA[22].Add(1);LTA[22].Add(1);LTA[22].Add(1);LTA[22].Add(2);LTA[22].Add(3);LTA[22].Add(3);
            LTA[23].Add(1);LTA[23].Add(1);LTA[23].Add(1);LTA[23].Add(2);LTA[23].Add(3);LTA[23].Add(3);LTA[23].Add(3);
            LTA[24].Add(1);LTA[24].Add(1);LTA[24].Add(1);LTA[24].Add(2);LTA[24].Add(3);LTA[24].Add(3);LTA[24].Add(3);
            LTA[25].Add(1);LTA[25].Add(1);LTA[25].Add(1);LTA[25].Add(2);LTA[25].Add(3);LTA[25].Add(3);LTA[25].Add(3);
            LTA[26].Add(1);LTA[26].Add(1);LTA[26].Add(1);LTA[26].Add(2);LTA[26].Add(3);LTA[26].Add(3);LTA[26].Add(3);
            LTA[27].Add(1);LTA[27].Add(1);LTA[27].Add(1);LTA[27].Add(2);LTA[27].Add(3);LTA[27].Add(3);LTA[27].Add(3);
            LTA[28].Add(1);LTA[28].Add(1);LTA[28].Add(1);LTA[28].Add(2);LTA[28].Add(3);LTA[28].Add(3);LTA[28].Add(3);LTA[28].Add(3);
            LTA[29].Add(1);LTA[29].Add(1);LTA[29].Add(1);LTA[29].Add(2);LTA[29].Add(3);LTA[29].Add(3);LTA[29].Add(3);LTA[29].Add(3);
            LTA[30].Add(1);LTA[30].Add(1);LTA[30].Add(1);LTA[30].Add(2);LTA[30].Add(3);LTA[30].Add(3);LTA[30].Add(3);LTA[30].Add(3);
            LTA[31].Add(1);LTA[31].Add(1);LTA[31].Add(1);LTA[31].Add(2);LTA[31].Add(3);LTA[31].Add(3);LTA[31].Add(3);LTA[31].Add(3);
            LTA[32].Add(1);LTA[32].Add(1);LTA[32].Add(1);LTA[32].Add(2);LTA[32].Add(3);LTA[32].Add(3);LTA[32].Add(3);LTA[32].Add(3);
            LTA[33].Add(1);LTA[33].Add(1);LTA[33].Add(1);LTA[33].Add(2);LTA[33].Add(3);LTA[33].Add(3);LTA[33].Add(3);LTA[33].Add(3);LTA[33].Add(3);
            LTA[34].Add(1);LTA[34].Add(1);LTA[34].Add(1);LTA[34].Add(2);LTA[34].Add(3);LTA[34].Add(3);LTA[34].Add(3);LTA[34].Add(3);LTA[34].Add(3);
            LTA[35].Add(1);LTA[35].Add(1);LTA[35].Add(1);LTA[35].Add(2);LTA[35].Add(3);LTA[35].Add(3);LTA[35].Add(3);LTA[35].Add(3);LTA[35].Add(3);
            LTA[36].Add(1);LTA[36].Add(1);LTA[36].Add(1);LTA[36].Add(2);LTA[36].Add(3);LTA[36].Add(3);LTA[36].Add(3);LTA[36].Add(3);LTA[36].Add(3);
            LTA[37].Add(1);LTA[37].Add(1);LTA[37].Add(1);LTA[37].Add(2);LTA[37].Add(3);LTA[37].Add(3);LTA[37].Add(3);LTA[37].Add(3);LTA[37].Add(3);
            LTA[38].Add(1);LTA[38].Add(1);LTA[38].Add(1);LTA[38].Add(2);LTA[38].Add(3);LTA[38].Add(3);LTA[38].Add(3);LTA[38].Add(3);LTA[38].Add(3);
            LTA[39].Add(1);LTA[39].Add(1);LTA[39].Add(1);LTA[39].Add(2);LTA[39].Add(3);LTA[39].Add(3);LTA[39].Add(3);LTA[39].Add(3);LTA[39].Add(3);
            LTA[40].Add(1);LTA[40].Add(1);LTA[40].Add(1);LTA[40].Add(2);LTA[40].Add(3);LTA[40].Add(3);LTA[40].Add(3);LTA[40].Add(3);LTA[40].Add(3);
            LTA[41].Add(1);LTA[41].Add(1);LTA[41].Add(1);LTA[41].Add(2);LTA[41].Add(3);LTA[41].Add(3);LTA[41].Add(3);LTA[41].Add(3);LTA[41].Add(3);
            LTA[42].Add(1);LTA[42].Add(1);LTA[42].Add(1);LTA[42].Add(2);LTA[42].Add(3);LTA[42].Add(3);LTA[42].Add(3);LTA[42].Add(3);LTA[42].Add(3);
            LTA[43].Add(1);LTA[43].Add(1);LTA[43].Add(1);LTA[43].Add(2);LTA[43].Add(3);LTA[43].Add(3);LTA[43].Add(3);LTA[43].Add(3);LTA[43].Add(3);
            LTA[44].Add(1);LTA[44].Add(1);LTA[44].Add(1);LTA[44].Add(2);LTA[44].Add(3);LTA[44].Add(3);LTA[44].Add(3);LTA[44].Add(3);LTA[44].Add(3);
            LTA[45].Add(1);LTA[45].Add(1);LTA[45].Add(1);LTA[45].Add(2);LTA[45].Add(3);LTA[45].Add(3);LTA[45].Add(3);LTA[45].Add(3);LTA[45].Add(3);
            LTA[46].Add(1);LTA[46].Add(1);LTA[46].Add(1);LTA[46].Add(2);LTA[46].Add(3);LTA[46].Add(3);LTA[46].Add(3);LTA[46].Add(3);LTA[46].Add(3);
            LTA[47].Add(1);LTA[47].Add(1);LTA[47].Add(1);LTA[47].Add(2);LTA[47].Add(3);LTA[47].Add(3);LTA[47].Add(3);LTA[47].Add(3);LTA[47].Add(3);
            LTA[48].Add(1);LTA[48].Add(1);LTA[48].Add(1);LTA[48].Add(2);LTA[48].Add(3);LTA[48].Add(3);LTA[48].Add(3);LTA[48].Add(3);LTA[48].Add(3);
            LTA[49].Add(1);LTA[49].Add(1);LTA[49].Add(1);LTA[49].Add(2);LTA[49].Add(3);LTA[49].Add(3);LTA[49].Add(3);LTA[49].Add(3);LTA[49].Add(3);
            LTA[50].Add(1);LTA[50].Add(1);LTA[50].Add(1);LTA[50].Add(2);LTA[50].Add(3);LTA[50].Add(3);LTA[50].Add(3);LTA[50].Add(3);LTA[50].Add(3);
            LTA[51].Add(1);LTA[51].Add(1);LTA[51].Add(1);LTA[51].Add(2);LTA[51].Add(3);LTA[51].Add(3);LTA[51].Add(3);LTA[51].Add(3);LTA[51].Add(3);
            LTA[52].Add(1);LTA[52].Add(1);LTA[52].Add(1);LTA[52].Add(2);LTA[52].Add(3);LTA[52].Add(3);LTA[52].Add(3);LTA[52].Add(3);LTA[52].Add(3);
            LTA[53].Add(1);LTA[53].Add(1);LTA[53].Add(1);LTA[53].Add(2);LTA[53].Add(3);LTA[53].Add(3);LTA[53].Add(3);LTA[53].Add(3);LTA[53].Add(3);
            LTA[54].Add(1);LTA[54].Add(1);LTA[54].Add(1);LTA[54].Add(2);LTA[54].Add(3);LTA[54].Add(3);LTA[54].Add(3);LTA[54].Add(3);LTA[54].Add(3);
            LTA[55].Add(1);LTA[55].Add(1);LTA[55].Add(1);LTA[55].Add(2);LTA[55].Add(3);LTA[55].Add(3);LTA[55].Add(3);LTA[55].Add(3);LTA[55].Add(3);
            LTA[56].Add(1);LTA[56].Add(1);LTA[56].Add(1);LTA[56].Add(2);LTA[56].Add(3);LTA[56].Add(3);LTA[56].Add(3);LTA[56].Add(3);LTA[56].Add(3);
            LTA[57].Add(1);LTA[57].Add(1);LTA[57].Add(1);LTA[57].Add(2);LTA[57].Add(3);LTA[57].Add(3);LTA[57].Add(3);LTA[57].Add(3);LTA[57].Add(3);
            LTA[58].Add(1);LTA[58].Add(1);LTA[58].Add(1);LTA[58].Add(2);LTA[58].Add(3);LTA[58].Add(3);LTA[58].Add(3);LTA[58].Add(3);LTA[58].Add(3);
            LTA[59].Add(1);LTA[59].Add(1);LTA[59].Add(1);LTA[59].Add(2);LTA[59].Add(3);LTA[59].Add(3);LTA[59].Add(3);LTA[59].Add(3);LTA[59].Add(3);
            LTA[60].Add(1);LTA[60].Add(1);LTA[60].Add(1);LTA[60].Add(2);LTA[60].Add(3);LTA[60].Add(3);LTA[60].Add(3);LTA[60].Add(3);LTA[60].Add(3);
            LTA[61].Add(1);LTA[61].Add(1);LTA[61].Add(1);LTA[61].Add(2);LTA[61].Add(3);LTA[61].Add(3);LTA[61].Add(3);LTA[61].Add(3);LTA[61].Add(3);
            LTA[62].Add(1);LTA[62].Add(1);LTA[62].Add(1);LTA[62].Add(2);LTA[62].Add(3);LTA[62].Add(3);LTA[62].Add(3);LTA[62].Add(3);LTA[62].Add(3);
            LTA[63].Add(1);LTA[63].Add(1);LTA[63].Add(1);LTA[63].Add(2);LTA[63].Add(3);LTA[63].Add(3);LTA[63].Add(3);LTA[63].Add(3);LTA[63].Add(3);
            LTA[64].Add(1);LTA[64].Add(1);LTA[64].Add(1);LTA[64].Add(2);LTA[64].Add(3);LTA[64].Add(3);LTA[64].Add(3);LTA[64].Add(3);LTA[64].Add(3);
            LTA[65].Add(1);LTA[65].Add(1);LTA[65].Add(1);LTA[65].Add(2);LTA[65].Add(3);LTA[65].Add(3);LTA[65].Add(3);LTA[65].Add(3);LTA[65].Add(3);
            LTA[66].Add(1);LTA[66].Add(1);LTA[66].Add(1);LTA[66].Add(2);LTA[66].Add(3);LTA[66].Add(3);LTA[66].Add(3);LTA[66].Add(3);LTA[66].Add(3);
            LTA[67].Add(1);LTA[67].Add(1);LTA[67].Add(1);LTA[67].Add(2);LTA[67].Add(3);LTA[67].Add(3);LTA[67].Add(3);LTA[67].Add(3);LTA[67].Add(3);
            LTA[68].Add(1);LTA[68].Add(1);LTA[68].Add(1);LTA[68].Add(2);LTA[68].Add(3);LTA[68].Add(3);LTA[68].Add(3);LTA[68].Add(3);LTA[68].Add(3);
            LTA[69].Add(1);LTA[69].Add(1);LTA[69].Add(1);LTA[69].Add(2);LTA[69].Add(3);LTA[69].Add(3);LTA[69].Add(3);LTA[69].Add(3);LTA[69].Add(3);
            LTA[70].Add(1);LTA[70].Add(1);LTA[70].Add(1);LTA[70].Add(2);LTA[70].Add(3);LTA[70].Add(3);LTA[70].Add(3);LTA[70].Add(3);LTA[70].Add(3);
            LTA[71].Add(1);LTA[71].Add(1);LTA[71].Add(1);LTA[71].Add(2);LTA[71].Add(3);LTA[71].Add(3);LTA[71].Add(3);LTA[71].Add(3);LTA[71].Add(3);
            LTA[72].Add(1);LTA[72].Add(1);LTA[72].Add(1);LTA[72].Add(2);LTA[72].Add(3);LTA[72].Add(3);LTA[72].Add(3);LTA[72].Add(3);LTA[72].Add(3);
            LTA[73].Add(1);LTA[73].Add(1);LTA[73].Add(1);LTA[73].Add(2);LTA[73].Add(3);LTA[73].Add(3);LTA[73].Add(3);LTA[73].Add(3);LTA[73].Add(3);
            LTA[74].Add(1);LTA[74].Add(1);LTA[74].Add(1);LTA[74].Add(2);LTA[74].Add(3);LTA[74].Add(3);LTA[74].Add(3);LTA[74].Add(3);LTA[74].Add(3);
            LTA[75].Add(1);LTA[75].Add(1);LTA[75].Add(1);LTA[75].Add(2);LTA[75].Add(3);LTA[75].Add(3);LTA[75].Add(3);LTA[75].Add(3);LTA[75].Add(3);


            
            
            #endregion

            #region Call Component

            phenologyComponent.Init(cumulTTatSowing, SowingDate, phenologyState);

            for (int iday = 0; iday < dayLength.Length; iday++)
            {
                LoadPreviousStates();

                phenologyState.DayLength = dayLength[iday];
                phenologyState.DeltaTT = deltaTTShoot[iday];
                phenologyState.cumulTT = cumulTT[iday];
                phenologyState.GrainCumulTT = grainCumulTT[iday];
                phenologyState.GAI = GAI[iday];
                phenologyState.PAR = PAR[iday];
                phenologyState.IsLatestLeafInternodeLengthPotPositive = (isLatestLeafInternodeLengthPotPositive[iday]) ? 1 : 0;
                phenologyState.currentdate =  SowingDate.AddDays(iday);

                phenologyComponent.Estimate(phenologyState, previousphenologyState, null);


                #region Tests



                Assert.AreEqual(LN[iday], phenologyState.LeafNumber, 0.00001);
                Assert.AreEqual(FLN[iday], phenologyState.FinalLeafNumber, 0.00001);
                Assert.AreEqual(PV[iday], phenologyState.phase_.phaseValue, 0.00001);
                Assert.AreEqual(ZS[iday], phenologyState.currentZadokStage.ToString());
                Assert.AreEqual(PH[iday], phenologyState.Phyllochron, 0.00001);
                Assert.AreEqual(VP[iday], phenologyState.Vernaprog, 0.00001);
                Assert.AreEqual(TN[iday], phenologyState.TillerNumber);
                Assert.AreEqual(CSN[iday], phenologyState.CanopyShootNumber, 0.00001);
                Assert.AreEqual(FP[iday], phenologyState.Fixphyll, 0.00001);

                for (int itp = 0; itp < TP[iday].Count; itp++) Assert.AreEqual(TP[iday][itp], phenologyState.tilleringProfile[itp], 0.00001);

                for (int ilta = 0; ilta < LTA[iday].Count; ilta++) Assert.AreEqual(LTA[iday][ilta], phenologyState.leafTillerNumberArray[ilta], 0.00001);

                //TODO
                //GAImean
                //PTQ
                //TODO

                #endregion

            }



            #endregion

        }

        [TestMethod]
        public void TestMethodWithoutVerna()
        {
            #region Instantiation

            phenologyComponent = new SiriusQualityPhenology.Strategies.Phenology();
            phenologyState = new SiriusQualityPhenology.PhenologyState();
            previousphenologyState = new SiriusQualityPhenology.PhenologyState();

            #endregion

            #region Load parameters

            phenologyComponent.AMNFLNO = AMNLFNO;
            phenologyComponent.AMXLFNO = AMXLFNO;
            phenologyComponent.Dcd = Dcd;
            phenologyComponent.Degfm = Degfm;
            phenologyComponent.Der = Der;
            phenologyComponent.Dgf = Dgf;
            phenologyComponent.Dse = Dse;
            phenologyComponent.IgnoreGrainMaturation = (IgnoreGrainMaturation) ? 1 : 0;
            phenologyComponent.IntTvern = IntTvern;
            phenologyComponent.IsVernalizable = 0;
            phenologyComponent.Ldecr = Ldecr;
            phenologyComponent.Lincr = Lincr;
            phenologyComponent.MaxDL = MaxDL;
            phenologyComponent.MaxTvern = MaxTvern;
            phenologyComponent.MinDL = MinDL;
            phenologyComponent.MinTvern = MinTvern;
            phenologyComponent.Pdecr = Pdecr;
            phenologyComponent.PFLLAnth = PFLLAnth;
            phenologyComponent.PHEADANTH = PHEADANTH;
            phenologyComponent.Pincr = Pincr;
            phenologyComponent.PNini = PNini;
            phenologyComponent.SLDL = SLDL;
            phenologyComponent.VAI = VAI;
            phenologyComponent.VBEE = VBEE;
            phenologyComponent.SowingDensity = SowingDensity;
            phenologyComponent.TargetFertileShoot = TargetFertileShoot;
            phenologyComponent.slopeTSFLN = slopeTSFLN;
            phenologyComponent.intTSFLN = intTSFLN;
            phenologyComponent.choosePhyllUse = choosePhyllUse;

            phenologyComponent.PTQhf = PTQhf;
            phenologyComponent.Kl = Kl;
            phenologyComponent.LARmin = LARmin;
            phenologyComponent.TTWindowForPTQ = TTWindowForPTQ;
            phenologyComponent.LARmax = LARmax;
            phenologyComponent.B = B;

            phenologyComponent.SowingDay = SowingDay;
            phenologyComponent.Latitude = Latitude;
            phenologyComponent.P = P;
            phenologyComponent.Rp = Rp;
            phenologyComponent.SDsa_sh = SDsa_sh;
            phenologyComponent.SDws = SDws;
            phenologyComponent.SDsa_nh = SDsa_nh;



            #endregion

            #region Inputs

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
                                   14.078181588288,14.0963827166422,14.114001095373};

            double[] deltaTTShoot ={ 21.3016064396306,18.9386542197517,15.6669302569715,16.8644225809839,19.2154984113532,20.3429985011972,
                                     19.4362277750342,12.7412196749015,13.4621490558403,15.5321149770776,18.9876789824015,
                                     21.4678115042348,21.8835317387586,22.3082580098962,22.4215765261747,11.9771589046418,
                                     17.1396149838417,21.1018463192995,24.2184965615814,23.8758511794508,23.5463901354042,
                                     22.8280484047799,18.3156031877673,23.2713843249052,19.9224155082458,17.3961018973515,
                                     14.7399777611726,19.4576872210572,17.8355588634174,16.7955289080356,13.4911065798809,
                                     15.9665715976205,17.3476329206458,14.3007154635672,16.8947166842933,18.0100725639367,
                                     19.4182210322909,17.6317908368544,19.2290406737953,21.7179098109666,19.5665761088835,
                                     20.5981283008892,19.0576165983071,13.8419238779875,10.2538117278921,9.07152010689486,
                                     11.6977593358673,13.5458822059351,14.8617527974084,17.8121493599317,19.0232149068643,
                                     19.5190771448324,18.8046702471772,18.8015752990519,18.3112327977625,19.4435926671327,
                                     19.6266232233941,21.1673679138324,20.7207195388526,21.4321461314574,20.6116469822048,
                                     20.5765332984349,19.412019231359,23.4929467358684,26.0941080859233,25.800004732322,
                                     22.0655780665117,20.7821728699118,25.7546674624943};

            double[] GAI ={0,0,0,0,0,0,
                           0,0.0307692307692308,0.0615384615384615,0.0714659697105823,0.0946619351127146,
                           0.128178958499091,0.174268339300665,0.226659194443595,0.2137397152819,0.279874189539498,
                           0.347962005864195,0.347962005864195,0.347962005864195,0.403707247565324,0.595860708388019,
                           0.80975545620957,0.998814563572088,1.13022030611332,1.41342790903781,1.68233016057472,
                           1.9403239784038,2.24006353195205,2.52252047466569,2.83080816209598,3.13395683197933,
                           3.44685222349265,3.75934236501415,4.0722329591178,4.38433080353508,4.66012287326858,
                           4.9408910148395,5.21871385352431,5.47122938401876,5.75767009284122,6.0493491756998,
                           6.0493491756998,6.0493491756998,6.0493491756998,6.0493491756998,6.0493491756998,
                           6.0493491756998,6.0493491756998,6.0493491756998,6.0493491756998,6.0493491756998,
                           6.01469528810145,5.97539658330821,5.93350748667424,5.85835550585369,5.66854436375733,
                           5.49089703581771,5.2983294579546,5.09557421767937,4.64183091846359,4.19750647864212,
                           3.78347291593961,3.23719574849982,2.7816334573676,2.34212948923561,1.46447206773063,
                           0.219782785156399,0,0};

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
                           14.304,15.024,15.216};


            bool[] isLatestLeafInternodeLengthPotPositive = { 
                                false,false,false,false,false,false,
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
                                true,true,true};

            double[] cumulTT = {21.3016064396306,40.2402606593823,55.9071909163538,72.7716134973377,91.987111908691,112.330110409888,
                                131.766338184922,144.507557859824,157.969706915664,173.501821892742,192.489500875143,
                                213.957312379378,235.840844118137,258.149102128033,280.570678654207,292.547837558849,
                                309.687452542691,330.78929886199,355.007795423572,378.883646603023,402.430036738427,
                                425.258085143207,443.573688330974,466.845072655879,486.767488164125,504.163590061476,
                                518.903567822649,538.361255043706,556.196813907124,572.992342815159,586.48344939504,
                                602.45002099266,619.797653913306,634.098369376874,650.993086061167,669.003158625103,
                                688.421379657394,706.053170494249,725.282211168044,747.000120979011,766.566697087894,
                                787.164825388783,806.222441987091,820.064365865078,830.31817759297,839.389697699865,
                                851.087457035732,864.633339241667,879.495092039076,897.307241399007,916.330456305872,
                                935.849533450704,954.654203697881,973.455778996933,991.767011794696,1011.21060446183,
                                1030.83722768522,1052.00459559905,1072.72531513791,1094.15746126936,1114.76910825157,
                                1135.34564155,1154.75766078136,1178.25060751723,1204.34471560315,1230.14472033548,
                                1252.21029840199,1272.9924712719,1298.74713873439 };

            double[] grainCumulTT = { 0,0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,0,0,0,
                                      0,0,19.0576165983071,32.8995404762947,43.1533522041867,
                                      52.2248723110816,63.9226316469489,77.468513852884,92.3302666502923,110.142416010224,
                                      129.165630917088,148.684708061921,167.489378309098,186.29095360815,204.602186405912,
                                      224.045779073045,243.672402296439,264.839770210271,285.560489749124,306.992635880581,
                                      327.604282862786,348.180816161221,367.59283539258,391.085782128449,417.179890214372,
                                      442.979894946694,465.045473013205,465.045473013205 };

            DateTime SowingDate = new DateTime(2007, 3, 21);

            double cumulTTatSowing = 0.0;

            #endregion

            #region Ouputs

            double[] LN = { 0,0,0,0,0,0.557647985230187,
                            1.09043931678266,1.43970520699377,1.80873341576133,2.2345041114049,2.75499969754529,
                            3.34348137255173,3.58343237845917,3.82804047067294,4.07389109047749,4.20521958723891,
                            4.39315396206174,4.6245338559137,4.89008754628192,5.15188416009169,5.41006826245358,
                            5.6603758107516,5.86120479307361,6.11637348084669,6.3348210193143,6.52556775064491,
                            6.68719031381566,6.90054214737989,7.09610748579455,7.28026898697915,7.42819778719714,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,7.6032698441886,
                            7.6032698441886,7.6032698441886,7.6032698441886};


            double[] FLN = { 0,0,0,0,0,0,
                             0,0,0,0,0,
                             0,0,0,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,7.53204488038549,
                             7.53204488038549,7.53204488038549,7.53204488038549};


            double[] PV = { 0,0,0,0,0,1,
                            1,1,1,1,1,
                            1,1,1,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,3,3,3,
                            3,4,4,4,4,
                            4,4,4,4,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,5,6 };

            string[] ZS = { "Unknown","Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","ZC_21_MainShootPlus1Tiller","BeginningStemExtension",
                            "TerminalSpikelet","ZC_30_PseudoStemErection","ZC_30_PseudoStemErection","ZC_22_MainShootPlus2Tiller","ZC_31_1stNodeDetectable",
                            "ZC_31_1stNodeDetectable","ZC_31_1stNodeDetectable","ZC_23_MainShootPlus3Tiller","ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable",
                            "ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_85_MidGrainFilling",
                            "ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling",
                            "ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling" };

            double[] PH = { 36.48,36.48,36.48,36.48,36.48,36.48,
                            36.48,36.48,36.48,36.48,36.48,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2 };

            double[] VP = { 0,0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0 };

            int[] TN = {1,1,1,1,1,1,
                        1,1,1,1,1,
                        2,2,2,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3,3,3,
                        3,3,3 };


            double[] CSN = { 288,288,288,288,288,288,
                             288,288,288,288,288,
                             576,576,576,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600,600,600,
                             600,600,600 };

            double[] FP = { 91.2,91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2 };

            List<List<double>> TP = new List<List<double>>();
            TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>());

            TP[0].Add(288);
            TP[1].Add(288);
            TP[2].Add(288);
            TP[3].Add(288);
            TP[4].Add(288);
            TP[5].Add(288);
            TP[6].Add(288);
            TP[7].Add(288);
            TP[8].Add(288);
            TP[9].Add(288);
            TP[10].Add(288);
            TP[11].Add(288); TP[11].Add(288);
            TP[12].Add(288); TP[12].Add(288);
            TP[13].Add(288); TP[13].Add(288);
            TP[14].Add(288); TP[14].Add(288); TP[14].Add(24);
            TP[15].Add(288); TP[15].Add(288); TP[15].Add(24);
            TP[16].Add(288); TP[16].Add(288); TP[16].Add(24);
            TP[17].Add(288); TP[17].Add(288); TP[17].Add(24);
            TP[18].Add(288); TP[18].Add(288); TP[18].Add(24);
            TP[19].Add(288); TP[19].Add(288); TP[19].Add(24);
            TP[20].Add(288); TP[20].Add(288); TP[20].Add(24);
            TP[21].Add(288); TP[21].Add(288); TP[21].Add(24);
            TP[22].Add(288); TP[22].Add(288); TP[22].Add(24);
            TP[23].Add(288); TP[23].Add(288); TP[23].Add(24);
            TP[24].Add(288); TP[24].Add(288); TP[24].Add(24);
            TP[25].Add(288); TP[25].Add(288); TP[25].Add(24);
            TP[26].Add(288); TP[26].Add(288); TP[26].Add(24);
            TP[27].Add(288); TP[27].Add(288); TP[27].Add(24);
            TP[28].Add(288); TP[28].Add(288); TP[28].Add(24);
            TP[29].Add(288); TP[29].Add(288); TP[29].Add(24);
            TP[30].Add(288); TP[30].Add(288); TP[30].Add(24);
            TP[31].Add(288); TP[31].Add(288); TP[31].Add(24);
            TP[32].Add(288); TP[32].Add(288); TP[32].Add(24);
            TP[33].Add(288); TP[33].Add(288); TP[33].Add(24);
            TP[34].Add(288); TP[34].Add(288); TP[34].Add(24);
            TP[35].Add(288); TP[35].Add(288); TP[35].Add(24);
            TP[36].Add(288); TP[36].Add(288); TP[36].Add(24);
            TP[37].Add(288); TP[37].Add(288); TP[37].Add(24);
            TP[38].Add(288); TP[38].Add(288); TP[38].Add(24);
            TP[39].Add(288); TP[39].Add(288); TP[39].Add(24);
            TP[40].Add(288); TP[40].Add(288); TP[40].Add(24);
            TP[41].Add(288); TP[41].Add(288); TP[41].Add(24);
            TP[42].Add(288); TP[42].Add(288); TP[42].Add(24);
            TP[43].Add(288); TP[43].Add(288); TP[43].Add(24);
            TP[44].Add(288); TP[44].Add(288); TP[44].Add(24);
            TP[45].Add(288); TP[45].Add(288); TP[45].Add(24);
            TP[46].Add(288); TP[46].Add(288); TP[46].Add(24);
            TP[47].Add(288); TP[47].Add(288); TP[47].Add(24);
            TP[48].Add(288); TP[48].Add(288); TP[48].Add(24);
            TP[49].Add(288); TP[49].Add(288); TP[49].Add(24);
            TP[50].Add(288); TP[50].Add(288); TP[50].Add(24);
            TP[51].Add(288); TP[51].Add(288); TP[51].Add(24);
            TP[52].Add(288); TP[52].Add(288); TP[52].Add(24);
            TP[53].Add(288); TP[53].Add(288); TP[53].Add(24);
            TP[54].Add(288); TP[54].Add(288); TP[54].Add(24);
            TP[55].Add(288); TP[55].Add(288); TP[55].Add(24);
            TP[56].Add(288); TP[56].Add(288); TP[56].Add(24);
            TP[57].Add(288); TP[57].Add(288); TP[57].Add(24);
            TP[58].Add(288); TP[58].Add(288); TP[58].Add(24);
            TP[59].Add(288); TP[59].Add(288); TP[59].Add(24);
            TP[60].Add(288); TP[60].Add(288); TP[60].Add(24);
            TP[61].Add(288); TP[61].Add(288); TP[61].Add(24);
            TP[62].Add(288); TP[62].Add(288); TP[62].Add(24);
            TP[63].Add(288); TP[63].Add(288); TP[63].Add(24);
            TP[64].Add(288); TP[64].Add(288); TP[64].Add(24);
            TP[65].Add(288); TP[65].Add(288); TP[65].Add(24);
            TP[66].Add(288); TP[66].Add(288); TP[66].Add(24);
            TP[67].Add(288); TP[67].Add(288); TP[67].Add(24);
            TP[68].Add(288); TP[68].Add(288); TP[68].Add(24);

            List<List<double>> LTA = new List<List<double>>();
            LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>());

            LTA[5].Add(1);
            LTA[6].Add(1); LTA[6].Add(1);
            LTA[7].Add(1); LTA[7].Add(1);
            LTA[8].Add(1); LTA[8].Add(1);
            LTA[9].Add(1); LTA[9].Add(1); LTA[9].Add(1);
            LTA[10].Add(1); LTA[10].Add(1); LTA[10].Add(1);
            LTA[11].Add(1); LTA[11].Add(1); LTA[11].Add(1); LTA[11].Add(2);
            LTA[12].Add(1); LTA[12].Add(1); LTA[12].Add(1); LTA[12].Add(2);
            LTA[13].Add(1); LTA[13].Add(1); LTA[13].Add(1); LTA[13].Add(2);
            LTA[14].Add(1); LTA[14].Add(1); LTA[14].Add(1); LTA[14].Add(2); LTA[14].Add(3);
            LTA[15].Add(1); LTA[15].Add(1); LTA[15].Add(1); LTA[15].Add(2); LTA[15].Add(3);
            LTA[16].Add(1); LTA[16].Add(1); LTA[16].Add(1); LTA[16].Add(2); LTA[16].Add(3);
            LTA[17].Add(1); LTA[17].Add(1); LTA[17].Add(1); LTA[17].Add(2); LTA[17].Add(3);
            LTA[18].Add(1); LTA[18].Add(1); LTA[18].Add(1); LTA[18].Add(2); LTA[18].Add(3);
            LTA[19].Add(1); LTA[19].Add(1); LTA[19].Add(1); LTA[19].Add(2); LTA[19].Add(3); LTA[19].Add(3);
            LTA[20].Add(1); LTA[20].Add(1); LTA[20].Add(1); LTA[20].Add(2); LTA[20].Add(3); LTA[20].Add(3);
            LTA[21].Add(1); LTA[21].Add(1); LTA[21].Add(1); LTA[21].Add(2); LTA[21].Add(3); LTA[21].Add(3);
            LTA[22].Add(1); LTA[22].Add(1); LTA[22].Add(1); LTA[22].Add(2); LTA[22].Add(3); LTA[22].Add(3);
            LTA[23].Add(1); LTA[23].Add(1); LTA[23].Add(1); LTA[23].Add(2); LTA[23].Add(3); LTA[23].Add(3); LTA[23].Add(3);
            LTA[24].Add(1); LTA[24].Add(1); LTA[24].Add(1); LTA[24].Add(2); LTA[24].Add(3); LTA[24].Add(3); LTA[24].Add(3);
            LTA[25].Add(1); LTA[25].Add(1); LTA[25].Add(1); LTA[25].Add(2); LTA[25].Add(3); LTA[25].Add(3); LTA[25].Add(3);
            LTA[26].Add(1); LTA[26].Add(1); LTA[26].Add(1); LTA[26].Add(2); LTA[26].Add(3); LTA[26].Add(3); LTA[26].Add(3);
            LTA[27].Add(1); LTA[27].Add(1); LTA[27].Add(1); LTA[27].Add(2); LTA[27].Add(3); LTA[27].Add(3); LTA[27].Add(3);
            LTA[28].Add(1); LTA[28].Add(1); LTA[28].Add(1); LTA[28].Add(2); LTA[28].Add(3); LTA[28].Add(3); LTA[28].Add(3); LTA[28].Add(3);
            LTA[29].Add(1); LTA[29].Add(1); LTA[29].Add(1); LTA[29].Add(2); LTA[29].Add(3); LTA[29].Add(3); LTA[29].Add(3); LTA[29].Add(3);
            LTA[30].Add(1); LTA[30].Add(1); LTA[30].Add(1); LTA[30].Add(2); LTA[30].Add(3); LTA[30].Add(3); LTA[30].Add(3); LTA[30].Add(3);
            LTA[31].Add(1); LTA[31].Add(1); LTA[31].Add(1); LTA[31].Add(2); LTA[31].Add(3); LTA[31].Add(3); LTA[31].Add(3); LTA[31].Add(3);
            LTA[32].Add(1); LTA[32].Add(1); LTA[32].Add(1); LTA[32].Add(2); LTA[32].Add(3); LTA[32].Add(3); LTA[32].Add(3); LTA[32].Add(3);
            LTA[33].Add(1); LTA[33].Add(1); LTA[33].Add(1); LTA[33].Add(2); LTA[33].Add(3); LTA[33].Add(3); LTA[33].Add(3); LTA[33].Add(3);
            LTA[34].Add(1); LTA[34].Add(1); LTA[34].Add(1); LTA[34].Add(2); LTA[34].Add(3); LTA[34].Add(3); LTA[34].Add(3); LTA[34].Add(3);
            LTA[35].Add(1); LTA[35].Add(1); LTA[35].Add(1); LTA[35].Add(2); LTA[35].Add(3); LTA[35].Add(3); LTA[35].Add(3); LTA[35].Add(3);
            LTA[36].Add(1); LTA[36].Add(1); LTA[36].Add(1); LTA[36].Add(2); LTA[36].Add(3); LTA[36].Add(3); LTA[36].Add(3); LTA[36].Add(3);
            LTA[37].Add(1); LTA[37].Add(1); LTA[37].Add(1); LTA[37].Add(2); LTA[37].Add(3); LTA[37].Add(3); LTA[37].Add(3); LTA[37].Add(3);
            LTA[38].Add(1); LTA[38].Add(1); LTA[38].Add(1); LTA[38].Add(2); LTA[38].Add(3); LTA[38].Add(3); LTA[38].Add(3); LTA[38].Add(3);
            LTA[39].Add(1); LTA[39].Add(1); LTA[39].Add(1); LTA[39].Add(2); LTA[39].Add(3); LTA[39].Add(3); LTA[39].Add(3); LTA[39].Add(3);
            LTA[40].Add(1); LTA[40].Add(1); LTA[40].Add(1); LTA[40].Add(2); LTA[40].Add(3); LTA[40].Add(3); LTA[40].Add(3); LTA[40].Add(3);
            LTA[41].Add(1); LTA[41].Add(1); LTA[41].Add(1); LTA[41].Add(2); LTA[41].Add(3); LTA[41].Add(3); LTA[41].Add(3); LTA[41].Add(3);
            LTA[42].Add(1); LTA[42].Add(1); LTA[42].Add(1); LTA[42].Add(2); LTA[42].Add(3); LTA[42].Add(3); LTA[42].Add(3); LTA[42].Add(3);
            LTA[43].Add(1); LTA[43].Add(1); LTA[43].Add(1); LTA[43].Add(2); LTA[43].Add(3); LTA[43].Add(3); LTA[43].Add(3); LTA[43].Add(3);
            LTA[44].Add(1); LTA[44].Add(1); LTA[44].Add(1); LTA[44].Add(2); LTA[44].Add(3); LTA[44].Add(3); LTA[44].Add(3); LTA[44].Add(3);
            LTA[45].Add(1); LTA[45].Add(1); LTA[45].Add(1); LTA[45].Add(2); LTA[45].Add(3); LTA[45].Add(3); LTA[45].Add(3); LTA[45].Add(3);
            LTA[46].Add(1); LTA[46].Add(1); LTA[46].Add(1); LTA[46].Add(2); LTA[46].Add(3); LTA[46].Add(3); LTA[46].Add(3); LTA[46].Add(3);
            LTA[47].Add(1); LTA[47].Add(1); LTA[47].Add(1); LTA[47].Add(2); LTA[47].Add(3); LTA[47].Add(3); LTA[47].Add(3); LTA[47].Add(3);
            LTA[48].Add(1); LTA[48].Add(1); LTA[48].Add(1); LTA[48].Add(2); LTA[48].Add(3); LTA[48].Add(3); LTA[48].Add(3); LTA[48].Add(3);
            LTA[49].Add(1); LTA[49].Add(1); LTA[49].Add(1); LTA[49].Add(2); LTA[49].Add(3); LTA[49].Add(3); LTA[49].Add(3); LTA[49].Add(3);
            LTA[50].Add(1); LTA[50].Add(1); LTA[50].Add(1); LTA[50].Add(2); LTA[50].Add(3); LTA[50].Add(3); LTA[50].Add(3); LTA[50].Add(3);
            LTA[51].Add(1); LTA[51].Add(1); LTA[51].Add(1); LTA[51].Add(2); LTA[51].Add(3); LTA[51].Add(3); LTA[51].Add(3); LTA[51].Add(3);
            LTA[52].Add(1); LTA[52].Add(1); LTA[52].Add(1); LTA[52].Add(2); LTA[52].Add(3); LTA[52].Add(3); LTA[52].Add(3); LTA[52].Add(3);
            LTA[53].Add(1); LTA[53].Add(1); LTA[53].Add(1); LTA[53].Add(2); LTA[53].Add(3); LTA[53].Add(3); LTA[53].Add(3); LTA[53].Add(3);
            LTA[54].Add(1); LTA[54].Add(1); LTA[54].Add(1); LTA[54].Add(2); LTA[54].Add(3); LTA[54].Add(3); LTA[54].Add(3); LTA[54].Add(3);
            LTA[55].Add(1); LTA[55].Add(1); LTA[55].Add(1); LTA[55].Add(2); LTA[55].Add(3); LTA[55].Add(3); LTA[55].Add(3); LTA[55].Add(3);
            LTA[56].Add(1); LTA[56].Add(1); LTA[56].Add(1); LTA[56].Add(2); LTA[56].Add(3); LTA[56].Add(3); LTA[56].Add(3); LTA[56].Add(3);
            LTA[57].Add(1); LTA[57].Add(1); LTA[57].Add(1); LTA[57].Add(2); LTA[57].Add(3); LTA[57].Add(3); LTA[57].Add(3); LTA[57].Add(3);
            LTA[58].Add(1); LTA[58].Add(1); LTA[58].Add(1); LTA[58].Add(2); LTA[58].Add(3); LTA[58].Add(3); LTA[58].Add(3); LTA[58].Add(3);
            LTA[59].Add(1); LTA[59].Add(1); LTA[59].Add(1); LTA[59].Add(2); LTA[59].Add(3); LTA[59].Add(3); LTA[59].Add(3); LTA[59].Add(3);
            LTA[60].Add(1); LTA[60].Add(1); LTA[60].Add(1); LTA[60].Add(2); LTA[60].Add(3); LTA[60].Add(3); LTA[60].Add(3); LTA[60].Add(3);
            LTA[61].Add(1); LTA[61].Add(1); LTA[61].Add(1); LTA[61].Add(2); LTA[61].Add(3); LTA[61].Add(3); LTA[61].Add(3); LTA[61].Add(3);
            LTA[62].Add(1); LTA[62].Add(1); LTA[62].Add(1); LTA[62].Add(2); LTA[62].Add(3); LTA[62].Add(3); LTA[62].Add(3); LTA[62].Add(3);
            LTA[63].Add(1); LTA[63].Add(1); LTA[63].Add(1); LTA[63].Add(2); LTA[63].Add(3); LTA[63].Add(3); LTA[63].Add(3); LTA[63].Add(3);
            LTA[64].Add(1); LTA[64].Add(1); LTA[64].Add(1); LTA[64].Add(2); LTA[64].Add(3); LTA[64].Add(3); LTA[64].Add(3); LTA[64].Add(3);
            LTA[65].Add(1); LTA[65].Add(1); LTA[65].Add(1); LTA[65].Add(2); LTA[65].Add(3); LTA[65].Add(3); LTA[65].Add(3); LTA[65].Add(3);
            LTA[66].Add(1); LTA[66].Add(1); LTA[66].Add(1); LTA[66].Add(2); LTA[66].Add(3); LTA[66].Add(3); LTA[66].Add(3); LTA[66].Add(3);
            LTA[67].Add(1); LTA[67].Add(1); LTA[67].Add(1); LTA[67].Add(2); LTA[67].Add(3); LTA[67].Add(3); LTA[67].Add(3); LTA[67].Add(3);
            LTA[68].Add(1); LTA[68].Add(1); LTA[68].Add(1); LTA[68].Add(2); LTA[68].Add(3); LTA[68].Add(3); LTA[68].Add(3); LTA[68].Add(3);



            #endregion

            #region Call Component

            phenologyComponent.Init(cumulTTatSowing, SowingDate, phenologyState);

            for (int iday = 0; iday < dayLength.Length; iday++)
            {
                LoadPreviousStates();

                phenologyState.DayLength = dayLength[iday];
                phenologyState.DeltaTT = deltaTTShoot[iday];
                phenologyState.cumulTT = cumulTT[iday];
                phenologyState.GrainCumulTT = grainCumulTT[iday];
                phenologyState.GAI = GAI[iday];
                phenologyState.PAR = PAR[iday];
                phenologyState.IsLatestLeafInternodeLengthPotPositive = (isLatestLeafInternodeLengthPotPositive[iday]) ? 1 : 0;
                phenologyState.currentdate = SowingDate.AddDays(iday);

                phenologyComponent.Estimate(phenologyState, previousphenologyState, null);


                #region Tests



                Assert.AreEqual(LN[iday], phenologyState.LeafNumber, 0.00001);
                Assert.AreEqual(FLN[iday], phenologyState.FinalLeafNumber, 0.00001);
                Assert.AreEqual(PV[iday], phenologyState.phase_.phaseValue, 0.00001);
                Assert.AreEqual(ZS[iday], phenologyState.currentZadokStage.ToString());
                Assert.AreEqual(PH[iday], phenologyState.Phyllochron, 0.00001);
                Assert.AreEqual(VP[iday], phenologyState.Vernaprog, 0.00001);
                Assert.AreEqual(TN[iday], phenologyState.TillerNumber);
                Assert.AreEqual(CSN[iday], phenologyState.CanopyShootNumber, 0.00001);
                Assert.AreEqual(FP[iday], phenologyState.Fixphyll, 0.00001);

                for (int itp = 0; itp < TP[iday].Count; itp++) Assert.AreEqual(TP[iday][itp], phenologyState.tilleringProfile[itp], 0.00001);

                for (int ilta = 0; ilta < LTA[iday].Count; ilta++) Assert.AreEqual(LTA[iday][ilta], phenologyState.leafTillerNumberArray[ilta], 0.00001);

                //TODO
                //GAImean
                //PTQ
                //TODO

                #endregion

            }



            #endregion

        }

        #region Utilities

        #region Load Previous States

        private void LoadPreviousStates()
        {



            previousphenologyState.Calendar = phenologyState.Calendar;

            previousphenologyState.LeafNumber = phenologyState.LeafNumber;

            previousphenologyState.phase_ = phenologyState.phase_;

            previousphenologyState.Vernaprog = phenologyState.Vernaprog;

            previousphenologyState.MinFinalNumber = phenologyState.MinFinalNumber;

            previousphenologyState.tilleringProfile = new List<double>();
            for (int i = 0; i < phenologyState.tilleringProfile.Count; i++) previousphenologyState.tilleringProfile.Add(phenologyState.tilleringProfile[i]);

            previousphenologyState.leafTillerNumberArray = new List<double>();
            for (int i = 0; i < phenologyState.leafTillerNumberArray.Count; i++) previousphenologyState.leafTillerNumberArray.Add(phenologyState.leafTillerNumberArray[i]);

            previousphenologyState.CanopyShootNumber = phenologyState.CanopyShootNumber;

            previousphenologyState.pastGAI = phenologyState.pastGAI;

            previousphenologyState.ListGAITTWindowForPTQ = new List<double>();
            for (int i = 0; i < phenologyState.ListGAITTWindowForPTQ.Count; i++) previousphenologyState.ListGAITTWindowForPTQ.Add(phenologyState.ListGAITTWindowForPTQ[i]);

            previousphenologyState.ListTTShootTTWindowForPTQ = new List<double>();
            for (int i = 0; i < phenologyState.ListTTShootTTWindowForPTQ.Count; i++) previousphenologyState.ListTTShootTTWindowForPTQ.Add(phenologyState.ListTTShootTTWindowForPTQ[i]);

            previousphenologyState.ListPARTTWindowForPTQ = new List<double>();
            for (int i = 0; i < phenologyState.ListPARTTWindowForPTQ.Count; i++) previousphenologyState.ListPARTTWindowForPTQ.Add(phenologyState.ListPARTTWindowForPTQ[i]);

        }
        #endregion
        #endregion


    }

}
