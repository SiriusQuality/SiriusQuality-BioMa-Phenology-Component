using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestPhenology
{
    [TestClass]
    public class UnitTestPhenologyPhyllPTQ
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
        string choosePhyllUse = "PTQ";

        #endregion

        [TestMethod]
        public void TestMethodWithVernaPTQ()
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
            phenologyComponent.AreaSL = AreaSL;
            phenologyComponent.AreaSS = AreaSS;
            phenologyComponent.LNeff = LNeff;

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
                                   14.1632476649571,14.1784241070815,14.1929635458173,14.2068559441032,14.2200915921908,
                                   14.2326611312416,14.2445555765116,14.2557663400147,14.2662852525528,14.2761045850053 };

            double[] deltaTTShoot ={21.3016064396306,18.9386542197517,15.6669302569715,16.8644225809839,19.2154984113532,20.3429985011972,
                                    19.4362277750342,12.7412196749015,13.4525169947632,15.532794523,18.9806393014372,
                                    21.4675751989885,21.8818089678365,22.3002184216827,22.4369274042779,23.1978897261478,
                                    23.3000084641036,23.0848378224574,23.6197674226258,23.5033180143591,23.6841093808293,
                                    24.2351618201564,21.8594069550356,18.6237418184521,19.9602885296793,16.7728025846592,
                                    14.1636648771131,18.691449717049,17.518432378614,17.2412635842752,13.9583474554482,
                                    17.0792844983149,18.6782873936218,14.9111560710998,17.9396466670479,19.0193635385841,
                                    20.2369393861993,18.1488179075296,19.3422442430488,21.9872406343456,19.5862516730802,
                                    20.5406764955776,19.337206843823,18.6742646552592,14.7933563741618,14.0515924900392,
                                    16.6796807413745,16.491604006274,17.6402709851199,19.5397093535647,20.16786881959,
                                    20.5955526896238,20.047874068094,20.2723582687506,20.5147135952626,20.8842560150352,
                                    21.6295861950756,22.3566811309376,19.6801157273138,19.375989003513,18.3173199377234,
                                    17.8266448102765,15.8755888001038,18.08132978677,20.3611989892253,20.0147403014172,
                                    21.4498311849656,20.8479304759584,20.874098634018,21.8367349499735,22.0669929511902,
                                    21.8878249259349,22.2985402066146,23.3600462904839,24.1504276196995,24.4158830440103,
                                    26.0733188699982,23.1206745811241,22.8334387170361,23.8653783898623,25.6389224003089 };

            double[] GAI ={0,0,0,0,0,0,
                           0,0.0307692307692308,0.0549675009591187,0.0682394465708567,0.0942177229272894,
                           0.12443357691197,0.168955273507727,0.21262001528802,0.240775343175555,0.271194073067303,
                           0.301412566145392,0.346250727767042,0.392785613426331,0.446777050668466,0.638707139089605,
                           0.80440175523015,0.918571908869618,1.00960087051347,1.31671251803181,1.631391532674,
                           1.80495106880646,2.05463016039731,2.37225358991489,2.6995971767269,3.01809492055855,
                           3.20481410154387,3.46811151561337,3.8476405649951,4.13946710320416,4.46903310484925,
                           4.7926029192158,5.09693511815302,5.14981082374684,5.22776583587182,5.34464212439289,
                           5.42621658837996,5.5594618453706,5.7081458445511,5.82522355006718,5.97006866652171,
                           6.12338883032618,6.30538467067572,6.48007810632147,6.66253522703832,6.66253522703832,
                           6.66253522703832,6.42364309682627,6.1936844662076,5.96192555108298,5.74380365555793,
                           5.55980933439624,5.36752321316732,5.30828466808795,5.30828466808795,5.08731927449747,
                           4.86688330056256,4.6843857761316,4.54809122907184,4.44125312965967,4.26686341946871,
                           4.02815082670384,3.76600141996164,3.47647450671417,3.16342551621127,3.02657150081349,
                           3.02657150081349,3.02657150081349,3.02657150081349,2.71131384861285,2.33482193138571,
                           1.84655152245629,1.22838626574869,0.813054583403423,0.556569264062232,0.556569264062232};

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
                           15.312,14.448,11.472,15.216,14.352,
                           14.16,16.032,16.224,15.552,15.312};


            bool[] isLatestLeafInternodeLengthPotPositive = {false,false,false,false,false,false,
                                                             false,false,false,false,false,
                                                             false,false,false,false,false,
                                                             false,false,false,false,false,
                                                             false,false,false,true,true,
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
                                131.766338184922,144.507557859824,157.960074854587,173.492869377587,192.473508679024,
                                213.941083878013,235.822892845849,258.123111267532,280.56003867181,303.757928397958,
                                327.057936862061,350.142774684519,373.762542107144,397.265860121503,420.949969502333,
                                445.185131322489,467.044538277525,485.668280095977,505.628568625656,522.401371210315,
                                536.565036087429,555.256485804478,572.774918183092,590.016181767367,603.974529222815,
                                621.05381372113,639.732101114752,654.643257185852,672.5829038529,691.602267391484,
                                711.839206777683,729.988024685213,749.330268928261,771.317509562607,790.903761235687,
                                811.444437731265,830.781644575088,849.455909230347,864.249265604509,878.300858094548,
                                894.980538835923,911.472142842196,929.112413827316,948.652123180881,968.819992000471,
                                989.415544690095,1009.46341875819,1029.73577702694,1050.2504906222,1071.13474663724,
                                1092.76433283231,1115.12101396325,1134.80112969056,1154.17711869408,1172.4944386318,
                                1190.32108344208,1206.19667224218,1224.27800202895,1244.63920101818,1264.65394131959,
                                1286.10377250456,1306.95170298052,1327.82580161454,1349.66253656451,1371.7295295157,
                                1393.61735444163,1415.91589464825,1439.27594093873,1463.42636855843,1487.84225160244,
                                1513.91557047244,1537.03624505357,1559.8696837706,1583.73506216046,1609.37398456077};

            double[] grainCumulTT = {0,0,0,0,0,0,
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
                                     0,0,22.3566811309376,42.0367968582515,61.4127858617645,
                                     79.7301057994879,97.5567506097644,113.432339409868,131.513669196638,151.874868185863,
                                     171.889608487281,193.339439672246,214.187370148205,235.061468782223,256.898203732196,
                                     278.965196683386,300.853021609321,323.151561815936,346.51160810642,370.662035726119,
                                     395.077918770129,421.151237640128,444.271912221252,467.105350938288,467.105350938288};

            DateTime SowingDate = new DateTime(2007, 3, 21);

            double cumulTTatSowing = 0.0;

            #endregion

            #region Ouputs

            double[] LN = {0,0,0,0,0,0.17392529753768,
                           0.340098032524806,0.449030863779735,0.566005271305754,0.703823779469997,0.877893452129973,
                           1.08290752280746,1.29617644259334,1.51997383931538,1.75192386513791,1.99836178450385,
                           2.24747027205228,2.50036471721002,2.76624414185721,3.04170262828537,3.32801186389401,
                           3.64641828441697,3.95699649005574,4.2305444241938,4.54699921234118,4.79830932582305,
                           4.99208289987363,5.22834774469354,5.4269697028121,5.60641456907352,5.73891186651311,
                           5.88506124651107,6.03241117533546,6.13972408973848,6.26188696886059,6.38484363047236,
                           6.50526158745801,6.60264527895424,6.70004374555925,6.8031099024803,6.89120770225155,
                           6.98069044669972,7.06174592582382,7.14019554859746,7.20239655199045,7.26414413790179,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941 };


            double[] FLN = {0,0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,0,0,0,
                            0,0,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                            7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085};


            double[] PV = {0,0,0,0,0,1,
                           1,1,1,1,1,
                           1,1,1,1,1,
                           1,1,1,1,1,
                           1,1,2,2,2,
                           2,2,2,2,2,
                           2,2,2,2,2,
                           2,2,2,2,2,
                           2,2,2,2,2,
                           2,2,2,2,2,
                           2,3,3,3,3,
                           3,4,4,4,4,
                           4,4,4.5,4.5,4.5,
                           4.5,4.5,4.5,4.5,4.5,
                           4.5,4.5,4.5,4.5,4.5,
                           4.5,4.5,4.5,5,6 };

            string[] ZS = { "Unknown","Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","Unknown","Unknown","Unknown",
                            "Unknown","Unknown","ZC_21_MainShootPlus1Tiller","BeginningStemExtension","TerminalSpikelet",
                            "ZC_30_PseudoStemErection","ZC_22_MainShootPlus2Tiller","ZC_31_1stNodeDetectable","ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable",
                            "ZC_32_2ndNodeDetectable","ZC_23_MainShootPlus3Tiller","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                            "ZC_37_FlagLeafJustVisible","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling",
                            "ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling" };

            double[] PH = { 116.964,116.964,116.964,116.964,116.964,116.964,
                            116.964,115.003933589241,112.704706573148,109.040472193646,104.712691807186,
                            102.601959018716,99.6446730315644,96.7317305730509,94.1327933048365,93.533579258611,
                            91.2825025004339,88.8363868470379,85.3243562001817,82.7221285072467,76.1139231437355,
                            70.382939170111,68.0821877786589,63.0746927437351,66.7414548196008,73.0938929444322,
                            79.1122764425519,88.1998775188623,96.0811191954525,105.348167284787,116.861833410125,
                            126.76142800098,138.950248011152,146.850228121388,154.68347374815,168.055827326585,
                            186.364037229288,198.588796284546,213.331332914521,222.323959553321,229.549022241668,
                            238.567547225492,238.041484394908,237.831474850908,227.565050238835,223.614291591169,
                            223.490767026633,225.918425504592,233.00519006654,253.126166010807,264.399903109985,
                            271.292227137723,272.407742779772,273.635758962,274.571316564065,276.489483529999,
                            285.514384334566,289.951939906107,288.219080318214,278.235990008387,269.996312063157,
                            265.5351323448,257.705602192427,257.451081005602,264.313863877858,274.811897360763,
                            285.009413937885,287.924772370986,291.296058711626,291.961241020561,296.225425283027,
                            300.365431330702,305.762747997351,321.025117949197,328.496046643214,334.049091108022,
                            361.067646859975,381.393392546949,407.227071988609,434.276433771681,513.052301025614 };

            double[] VP = {0.0863084257037371,0.192393692314103,0.326547334966024,0.449801765048609,0.551725418737689,0.642954494510562,
                            0.741713491635679,0.90085374182204,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,
                            1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921,1.05334109952921 };

            int[] TN = {1,1,1,1,1,1,
                        1,1,1,1,1,
                        1,1,1,1,1,
                        1,1,1,2,2,
                        2,2,3,3,3,
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
                            288,288,288,288,288,
                            288,288,288,576,576,
                            576,576,600,600,600,
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
                            600,600,600,600,600};

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
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2 };

            List<List<double>> TP = new List<List<double>>();
            #region Valorize
            TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>());
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
            TP[11].Add(288);
            TP[12].Add(288);
            TP[13].Add(288);
            TP[14].Add(288);
            TP[15].Add(288);
            TP[16].Add(288);
            TP[17].Add(288);
            TP[18].Add(288);
            TP[19].Add(288); TP[19].Add(288);
            TP[20].Add(288); TP[20].Add(288);
            TP[21].Add(288); TP[21].Add(288);
            TP[22].Add(288); TP[22].Add(288);
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
            TP[76].Add(288); TP[76].Add(288); TP[76].Add(24);
            TP[77].Add(288); TP[77].Add(288); TP[77].Add(24);
            TP[78].Add(288); TP[78].Add(288); TP[78].Add(24);
            TP[79].Add(288); TP[79].Add(288); TP[79].Add(24);
            TP[80].Add(288); TP[80].Add(288); TP[80].Add(24);
            #endregion

            List<List<double>> LTA = new List<List<double>>();
            #region Valorize
            LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>());
            LTA[5].Add(1);
            LTA[6].Add(1);
            LTA[7].Add(1);
            LTA[8].Add(1);
            LTA[9].Add(1);
            LTA[10].Add(1);
            LTA[11].Add(1); LTA[11].Add(1);
            LTA[12].Add(1); LTA[12].Add(1);
            LTA[13].Add(1); LTA[13].Add(1);
            LTA[14].Add(1); LTA[14].Add(1);
            LTA[15].Add(1); LTA[15].Add(1);
            LTA[16].Add(1); LTA[16].Add(1); LTA[16].Add(1);
            LTA[17].Add(1); LTA[17].Add(1); LTA[17].Add(1);
            LTA[18].Add(1); LTA[18].Add(1); LTA[18].Add(1);
            LTA[19].Add(1); LTA[19].Add(1); LTA[19].Add(1); LTA[19].Add(2);
            LTA[20].Add(1); LTA[20].Add(1); LTA[20].Add(1); LTA[20].Add(2);
            LTA[21].Add(1); LTA[21].Add(1); LTA[21].Add(1); LTA[21].Add(2);
            LTA[22].Add(1); LTA[22].Add(1); LTA[22].Add(1); LTA[22].Add(2);
            LTA[23].Add(1); LTA[23].Add(1); LTA[23].Add(1); LTA[23].Add(2); LTA[23].Add(3);
            LTA[24].Add(1); LTA[24].Add(1); LTA[24].Add(1); LTA[24].Add(2); LTA[24].Add(3);
            LTA[25].Add(1); LTA[25].Add(1); LTA[25].Add(1); LTA[25].Add(2); LTA[25].Add(3);
            LTA[26].Add(1); LTA[26].Add(1); LTA[26].Add(1); LTA[26].Add(2); LTA[26].Add(3);
            LTA[27].Add(1); LTA[27].Add(1); LTA[27].Add(1); LTA[27].Add(2); LTA[27].Add(3); LTA[27].Add(3);
            LTA[28].Add(1); LTA[28].Add(1); LTA[28].Add(1); LTA[28].Add(2); LTA[28].Add(3); LTA[28].Add(3);
            LTA[29].Add(1); LTA[29].Add(1); LTA[29].Add(1); LTA[29].Add(2); LTA[29].Add(3); LTA[29].Add(3);
            LTA[30].Add(1); LTA[30].Add(1); LTA[30].Add(1); LTA[30].Add(2); LTA[30].Add(3); LTA[30].Add(3);
            LTA[31].Add(1); LTA[31].Add(1); LTA[31].Add(1); LTA[31].Add(2); LTA[31].Add(3); LTA[31].Add(3);
            LTA[32].Add(1); LTA[32].Add(1); LTA[32].Add(1); LTA[32].Add(2); LTA[32].Add(3); LTA[32].Add(3); LTA[32].Add(3);
            LTA[33].Add(1); LTA[33].Add(1); LTA[33].Add(1); LTA[33].Add(2); LTA[33].Add(3); LTA[33].Add(3); LTA[33].Add(3);
            LTA[34].Add(1); LTA[34].Add(1); LTA[34].Add(1); LTA[34].Add(2); LTA[34].Add(3); LTA[34].Add(3); LTA[34].Add(3);
            LTA[35].Add(1); LTA[35].Add(1); LTA[35].Add(1); LTA[35].Add(2); LTA[35].Add(3); LTA[35].Add(3); LTA[35].Add(3);
            LTA[36].Add(1); LTA[36].Add(1); LTA[36].Add(1); LTA[36].Add(2); LTA[36].Add(3); LTA[36].Add(3); LTA[36].Add(3);
            LTA[37].Add(1); LTA[37].Add(1); LTA[37].Add(1); LTA[37].Add(2); LTA[37].Add(3); LTA[37].Add(3); LTA[37].Add(3);
            LTA[38].Add(1); LTA[38].Add(1); LTA[38].Add(1); LTA[38].Add(2); LTA[38].Add(3); LTA[38].Add(3); LTA[38].Add(3);
            LTA[39].Add(1); LTA[39].Add(1); LTA[39].Add(1); LTA[39].Add(2); LTA[39].Add(3); LTA[39].Add(3); LTA[39].Add(3);
            LTA[40].Add(1); LTA[40].Add(1); LTA[40].Add(1); LTA[40].Add(2); LTA[40].Add(3); LTA[40].Add(3); LTA[40].Add(3);
            LTA[41].Add(1); LTA[41].Add(1); LTA[41].Add(1); LTA[41].Add(2); LTA[41].Add(3); LTA[41].Add(3); LTA[41].Add(3);
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
            LTA[69].Add(1); LTA[69].Add(1); LTA[69].Add(1); LTA[69].Add(2); LTA[69].Add(3); LTA[69].Add(3); LTA[69].Add(3); LTA[69].Add(3);
            LTA[70].Add(1); LTA[70].Add(1); LTA[70].Add(1); LTA[70].Add(2); LTA[70].Add(3); LTA[70].Add(3); LTA[70].Add(3); LTA[70].Add(3);
            LTA[71].Add(1); LTA[71].Add(1); LTA[71].Add(1); LTA[71].Add(2); LTA[71].Add(3); LTA[71].Add(3); LTA[71].Add(3); LTA[71].Add(3);
            LTA[72].Add(1); LTA[72].Add(1); LTA[72].Add(1); LTA[72].Add(2); LTA[72].Add(3); LTA[72].Add(3); LTA[72].Add(3); LTA[72].Add(3);
            LTA[73].Add(1); LTA[73].Add(1); LTA[73].Add(1); LTA[73].Add(2); LTA[73].Add(3); LTA[73].Add(3); LTA[73].Add(3); LTA[73].Add(3);
            LTA[74].Add(1); LTA[74].Add(1); LTA[74].Add(1); LTA[74].Add(2); LTA[74].Add(3); LTA[74].Add(3); LTA[74].Add(3); LTA[74].Add(3);
            LTA[75].Add(1); LTA[75].Add(1); LTA[75].Add(1); LTA[75].Add(2); LTA[75].Add(3); LTA[75].Add(3); LTA[75].Add(3); LTA[75].Add(3);
            LTA[76].Add(1); LTA[76].Add(1); LTA[76].Add(1); LTA[76].Add(2); LTA[76].Add(3); LTA[76].Add(3); LTA[76].Add(3); LTA[76].Add(3);
            LTA[77].Add(1); LTA[77].Add(1); LTA[77].Add(1); LTA[77].Add(2); LTA[77].Add(3); LTA[77].Add(3); LTA[77].Add(3); LTA[77].Add(3);
            LTA[78].Add(1); LTA[78].Add(1); LTA[78].Add(1); LTA[78].Add(2); LTA[78].Add(3); LTA[78].Add(3); LTA[78].Add(3); LTA[78].Add(3);
            LTA[79].Add(1); LTA[79].Add(1); LTA[79].Add(1); LTA[79].Add(2); LTA[79].Add(3); LTA[79].Add(3); LTA[79].Add(3); LTA[79].Add(3);
            LTA[80].Add(1); LTA[80].Add(1); LTA[80].Add(1); LTA[80].Add(2); LTA[80].Add(3); LTA[80].Add(3); LTA[80].Add(3); LTA[80].Add(3);
            #endregion




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


                #endregion

            }



            #endregion

        }

        [TestMethod]
        public void TestMethodWithoutVernaPTQ()
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
            phenologyComponent.AreaSL = AreaSL;
            phenologyComponent.AreaSS = AreaSS;
            phenologyComponent.LNeff = LNeff;

            phenologyComponent.SowingDay = SowingDay;
            phenologyComponent.Latitude = Latitude;
            phenologyComponent.P = P;
            phenologyComponent.Rp = Rp;
            phenologyComponent.SDsa_sh = SDsa_sh;
            phenologyComponent.SDws = SDws;
            phenologyComponent.SDsa_nh = SDsa_nh;



            #endregion

            #region Inputs

            double[] dayLength = {12.132555044855,12.1668362308466,12.2011023194079,12.2353485304588,12.269570082415,12.3037621834005,
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
                                  14.1632476649571,14.1784241070815,14.1929635458173,14.2068559441032,14.2200915921908,
                                  14.2326611312416,14.2445555765116,14.2557663400147,14.2662852525528,14.2761045850053 };

            double[] deltaTTShoot ={21.3016064396306,18.9386542197517,15.6669302569715,16.8644225809839,19.2154984113532,20.3429985011972,
                                    19.4362277750342,12.7412196749015,13.4525169947632,15.532794523,18.9806393014372,
                                    21.4675751989885,21.8818089678365,22.3002184216827,22.4369274042779,23.1978897261478,
                                    23.3000084641036,23.0848378224574,23.6197674226258,23.5033180143591,23.6841093808293,
                                    24.2351618201564,21.8594069550356,18.6237418184521,19.9602885296793,16.7728025846592,
                                    14.1636648771131,18.691449717049,17.518432378614,17.2412635842752,13.9583474554482,
                                    17.0792844983149,18.6782873936218,14.9111560710998,17.9396466670479,19.0193635385841,
                                    20.2369393861993,18.1488179075296,19.3422442430488,21.9872406343456,19.5862516730802,
                                    20.5406764955776,19.337206843823,18.6742646552592,14.7933563741618,14.0515924900392,
                                    16.6796807413745,16.491604006274,17.6402709851199,19.5397093535647,20.16786881959,
                                    20.5955526896238,20.047874068094,20.2723582687506,20.5147135952626,20.8842560150352,
                                    21.6295861950756,22.3566811309376,19.6801157273138,19.375989003513,18.3173199377234,
                                    17.8266448102765,15.8755888001038,18.08132978677,20.3611989892253,20.0147403014172,
                                    21.4498311849656,20.8479304759584,20.874098634018,21.8367349499735,22.0669929511902,
                                    21.8878249259349,22.2985402066146,23.3600462904839,24.1504276196995,24.4158830440103,
                                    26.0733188699982,23.1206745811241,22.8334387170361,23.8653783898623,25.6389224003089 };

            double[] GAI ={0,0,0,0,0,0,
                           0,0.0307692307692308,0.0549675009591187,0.0682394465708567,0.0942177229272894,
                           0.12443357691197,0.168955273507727,0.21262001528802,0.240775343175555,0.271194073067303,
                           0.301412566145392,0.346250727767042,0.392785613426331,0.446777050668466,0.638707139089605,
                           0.80440175523015,0.918571908869618,1.00960087051347,1.31671251803181,1.631391532674,
                           1.80495106880646,2.05463016039731,2.37225358991489,2.6995971767269,3.01809492055855,
                           3.20481410154387,3.46811151561337,3.8476405649951,4.13946710320416,4.46903310484925,
                           4.7926029192158,5.09693511815302,5.14981082374684,5.22776583587182,5.34464212439289,
                           5.42621658837996,5.5594618453706,5.7081458445511,5.82522355006718,5.97006866652171,
                           6.12338883032618,6.30538467067572,6.48007810632147,6.66253522703832,6.66253522703832,
                           6.66253522703832,6.42364309682627,6.1936844662076,5.96192555108298,5.74380365555793,
                           5.55980933439624,5.36752321316732,5.30828466808795,5.30828466808795,5.08731927449747,
                           4.86688330056256,4.6843857761316,4.54809122907184,4.44125312965967,4.26686341946871,
                           4.02815082670384,3.76600141996164,3.47647450671417,3.16342551621127,3.02657150081349,
                           3.02657150081349,3.02657150081349,3.02657150081349,2.71131384861285,2.33482193138571,
                           1.84655152245629,1.22838626574869,0.813054583403423,0.556569264062232,0.556569264062232};

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
                           15.312,14.448,11.472,15.216,14.352,
                           14.16,16.032,16.224,15.552,15.312};


            bool[] isLatestLeafInternodeLengthPotPositive = {false,false,false,false,false,false,
                                                             false,false,false,false,false,
                                                             false,false,false,false,false,
                                                             false,false,false,false,false,
                                                             false,false,false,true,true,
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
                                                             true,true,true,true,true };

            double[] cumulTT = {21.3016064396306,40.2402606593823,55.9071909163538,72.7716134973377,91.987111908691,112.330110409888,
                                131.766338184922,144.507557859824,157.960074854587,173.492869377587,192.473508679024,
                                213.941083878013,235.822892845849,258.123111267532,280.56003867181,303.757928397958,
                                327.057936862061,350.142774684519,373.762542107144,397.265860121503,420.949969502333,
                                445.185131322489,467.044538277525,485.668280095977,505.628568625656,522.401371210315,
                                536.565036087429,555.256485804478,572.774918183092,590.016181767367,603.974529222815,
                                621.05381372113,639.732101114752,654.643257185852,672.5829038529,691.602267391484,
                                711.839206777683,729.988024685213,749.330268928261,771.317509562607,790.903761235687,
                                811.444437731265,830.781644575088,849.455909230347,864.249265604509,878.300858094548,
                                894.980538835923,911.472142842196,929.112413827316,948.652123180881,968.819992000471,
                                989.415544690095,1009.46341875819,1029.73577702694,1050.2504906222,1071.13474663724,
                                1092.76433283231,1115.12101396325,1134.80112969056,1154.17711869408,1172.4944386318,
                                1190.32108344208,1206.19667224218,1224.27800202895,1244.63920101818,1264.65394131959,
                                1286.10377250456,1306.95170298052,1327.82580161454,1349.66253656451,1371.7295295157,
                                1393.61735444163,1415.91589464825,1439.27594093873,1463.42636855843,1487.84225160244,
                                1513.91557047244,1537.03624505357,1559.8696837706,1583.73506216046,1609.37398456077};

            double[] grainCumulTT = {0,0,0,0,0,0,
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
                                     0,0,22.3566811309376,42.0367968582515,61.4127858617645,
                                     79.7301057994879,97.5567506097644,113.432339409868,131.513669196638,151.874868185863,
                                     171.889608487281,193.339439672246,214.187370148205,235.061468782223,256.898203732196,
                                     278.965196683386,300.853021609321,323.151561815936,346.51160810642,370.662035726119,
                                     395.077918770129,421.151237640128,444.271912221252,467.105350938288,467.105350938288};

            DateTime SowingDate = new DateTime(2007, 3, 21);

            double cumulTTatSowing = 0.0;

            #endregion

            #region Ouputs

            double[] LN = {0,0,0,0,0,0.17392529753768,
                           0.340098032524806,0.449030863779735,0.566005271305754,0.703823779469997,0.877893452129973,
                           1.08290752280746,1.29617644259334,1.51997383931538,1.75192386513791,1.99836178450385,
                           2.24747027205228,2.50036471721002,2.76624414185721,3.04170262828537,3.32801186389401,
                           3.64641828441697,3.95699649005574,4.2305444241938,4.54699921234118,4.79830932582305,
                           4.99208289987363,5.22834774469354,5.4269697028121,5.60641456907352,5.73891186651311,
                           5.88506124651107,6.03241117533546,6.13972408973848,6.26188696886059,6.38484363047236,
                           6.50526158745801,6.60264527895424,6.70004374555925,6.8031099024803,6.89120770225155,
                           6.98069044669972,7.06174592582382,7.14019554859746,7.20239655199045,7.26414413790179,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,
                           7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941,7.33873543804941 };


            double[] FLN = {0,0,0,0,0,0,
                           0,0,0,0,0,
                           0,0,0,0,0,
                           0,0,0,0,0,
                           0,0,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,
                           7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085,7.27782880075085 };


            double[] PV = { 0,0,0,0,0,1,
                            1,1,1,1,1,
                            1,1,1,1,1,
                            1,1,1,1,1,
                            1,1,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,2,2,2,2,
                            2,3,3,3,3,
                            3,4,4,4,4,
                            4,4,4.5,4.5,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,4.5,4.5,
                            4.5,4.5,4.5,5,6};

            string[] ZS = {"Unknown","Unknown","Unknown","Unknown","Unknown","Unknown",
                           "Unknown","Unknown","Unknown","Unknown","Unknown",
                           "Unknown","Unknown","Unknown","Unknown","Unknown",
                           "Unknown","Unknown","Unknown","Unknown","Unknown",
                           "Unknown","Unknown","ZC_21_MainShootPlus1Tiller","BeginningStemExtension","TerminalSpikelet",
                           "ZC_30_PseudoStemErection","ZC_22_MainShootPlus2Tiller","ZC_31_1stNodeDetectable","ZC_32_2ndNodeDetectable","ZC_32_2ndNodeDetectable",
                           "ZC_32_2ndNodeDetectable","ZC_23_MainShootPlus3Tiller","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible","ZC_37_FlagLeafJustVisible",
                           "ZC_37_FlagLeafJustVisible","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling",
                           "ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling","ZC_85_MidGrainFilling"};

            double[] PH = { 116.964,116.964,116.964,116.964,116.964,116.964,
                            116.964,115.003933589241,112.704706573148,109.040472193646,104.712691807186,
                            102.601959018716,99.6446730315644,96.7317305730509,94.1327933048365,93.533579258611,
                            91.2825025004339,88.8363868470379,85.3243562001817,82.7221285072467,76.1139231437355,
                            70.382939170111,68.0821877786589,63.0746927437351,66.7414548196008,73.0938929444322,
                            79.1122764425519,88.1998775188623,96.0811191954525,105.348167284787,116.861833410125,
                            126.76142800098,138.950248011152,146.850228121388,154.68347374815,168.055827326585,
                            186.364037229288,198.588796284546,213.331332914521,222.323959553321,229.549022241668,
                            238.567547225492,238.041484394908,237.831474850908,227.565050238835,223.614291591169,
                            223.490767026633,225.918425504592,233.00519006654,253.126166010807,264.399903109985,
                            271.292227137723,272.407742779772,273.635758962,274.571316564065,276.489483529999,
                            285.514384334566,289.951939906107,288.219080318214,278.235990008387,269.996312063157,
                            265.5351323448,257.705602192427,257.451081005602,264.313863877858,274.811897360763,
                            285.009413937885,287.924772370986,291.296058711626,291.961241020561,296.225425283027,
                            300.365431330702,305.762747997351,321.025117949197,328.496046643214,334.049091108022,
                            361.067646859975,381.393392546949,407.227071988609,434.276433771681,513.052301025614};

            double[] VP = {0,0,0,0,0,0,
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
                           0,0,0,0,0,
                           0,0,0,0,0,
                           0,0,0,0,0};

            int[] TN = {1,1,1,1,1,1,
                        1,1,1,1,1,
                        1,1,1,1,1,
                        1,1,1,2,2,
                        2,2,3,3,3,
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


            double[] CSN = {288,288,288,288,288,288,
                            288,288,288,288,288,
                            288,288,288,288,288,
                            288,288,288,576,576,
                            576,576,600,600,600,
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
                            600,600,600,600,600};

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
                            91.2,91.2,91.2,91.2,91.2,
                            91.2,91.2,91.2,91.2,91.2};

            List<List<double>> TP = new List<List<double>>();
            #region Valorize
            TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>()); TP.Add(new List<double>());
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
            TP[11].Add(288);
            TP[12].Add(288);
            TP[13].Add(288);
            TP[14].Add(288);
            TP[15].Add(288);
            TP[16].Add(288);
            TP[17].Add(288);
            TP[18].Add(288);
            TP[19].Add(288); TP[19].Add(288);
            TP[20].Add(288); TP[20].Add(288);
            TP[21].Add(288); TP[21].Add(288);
            TP[22].Add(288); TP[22].Add(288);
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
            TP[76].Add(288); TP[76].Add(288); TP[76].Add(24);
            TP[77].Add(288); TP[77].Add(288); TP[77].Add(24);
            TP[78].Add(288); TP[78].Add(288); TP[78].Add(24);
            TP[79].Add(288); TP[79].Add(288); TP[79].Add(24);
            TP[80].Add(288); TP[80].Add(288); TP[80].Add(24);
            
            #endregion


            List<List<double>> LTA = new List<List<double>>();
            #region Valorize
            LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>()); LTA.Add(new List<double>());
            LTA[5].Add(1);
            LTA[6].Add(1);
            LTA[7].Add(1);
            LTA[8].Add(1);
            LTA[9].Add(1);
            LTA[10].Add(1);
            LTA[11].Add(1); LTA[11].Add(1);
            LTA[12].Add(1); LTA[12].Add(1);
            LTA[13].Add(1); LTA[13].Add(1);
            LTA[14].Add(1); LTA[14].Add(1);
            LTA[15].Add(1); LTA[15].Add(1);
            LTA[16].Add(1); LTA[16].Add(1); LTA[16].Add(1);
            LTA[17].Add(1); LTA[17].Add(1); LTA[17].Add(1);
            LTA[18].Add(1); LTA[18].Add(1); LTA[18].Add(1);
            LTA[19].Add(1); LTA[19].Add(1); LTA[19].Add(1); LTA[19].Add(2);
            LTA[20].Add(1); LTA[20].Add(1); LTA[20].Add(1); LTA[20].Add(2);
            LTA[21].Add(1); LTA[21].Add(1); LTA[21].Add(1); LTA[21].Add(2);
            LTA[22].Add(1); LTA[22].Add(1); LTA[22].Add(1); LTA[22].Add(2);
            LTA[23].Add(1); LTA[23].Add(1); LTA[23].Add(1); LTA[23].Add(2); LTA[23].Add(3);
            LTA[24].Add(1); LTA[24].Add(1); LTA[24].Add(1); LTA[24].Add(2); LTA[24].Add(3);
            LTA[25].Add(1); LTA[25].Add(1); LTA[25].Add(1); LTA[25].Add(2); LTA[25].Add(3);
            LTA[26].Add(1); LTA[26].Add(1); LTA[26].Add(1); LTA[26].Add(2); LTA[26].Add(3);
            LTA[27].Add(1); LTA[27].Add(1); LTA[27].Add(1); LTA[27].Add(2); LTA[27].Add(3); LTA[27].Add(3);
            LTA[28].Add(1); LTA[28].Add(1); LTA[28].Add(1); LTA[28].Add(2); LTA[28].Add(3); LTA[28].Add(3);
            LTA[29].Add(1); LTA[29].Add(1); LTA[29].Add(1); LTA[29].Add(2); LTA[29].Add(3); LTA[29].Add(3);
            LTA[30].Add(1); LTA[30].Add(1); LTA[30].Add(1); LTA[30].Add(2); LTA[30].Add(3); LTA[30].Add(3);
            LTA[31].Add(1); LTA[31].Add(1); LTA[31].Add(1); LTA[31].Add(2); LTA[31].Add(3); LTA[31].Add(3);
            LTA[32].Add(1); LTA[32].Add(1); LTA[32].Add(1); LTA[32].Add(2); LTA[32].Add(3); LTA[32].Add(3); LTA[32].Add(3);
            LTA[33].Add(1); LTA[33].Add(1); LTA[33].Add(1); LTA[33].Add(2); LTA[33].Add(3); LTA[33].Add(3); LTA[33].Add(3);
            LTA[34].Add(1); LTA[34].Add(1); LTA[34].Add(1); LTA[34].Add(2); LTA[34].Add(3); LTA[34].Add(3); LTA[34].Add(3);
            LTA[35].Add(1); LTA[35].Add(1); LTA[35].Add(1); LTA[35].Add(2); LTA[35].Add(3); LTA[35].Add(3); LTA[35].Add(3);
            LTA[36].Add(1); LTA[36].Add(1); LTA[36].Add(1); LTA[36].Add(2); LTA[36].Add(3); LTA[36].Add(3); LTA[36].Add(3);
            LTA[37].Add(1); LTA[37].Add(1); LTA[37].Add(1); LTA[37].Add(2); LTA[37].Add(3); LTA[37].Add(3); LTA[37].Add(3);
            LTA[38].Add(1); LTA[38].Add(1); LTA[38].Add(1); LTA[38].Add(2); LTA[38].Add(3); LTA[38].Add(3); LTA[38].Add(3);
            LTA[39].Add(1); LTA[39].Add(1); LTA[39].Add(1); LTA[39].Add(2); LTA[39].Add(3); LTA[39].Add(3); LTA[39].Add(3);
            LTA[40].Add(1); LTA[40].Add(1); LTA[40].Add(1); LTA[40].Add(2); LTA[40].Add(3); LTA[40].Add(3); LTA[40].Add(3);
            LTA[41].Add(1); LTA[41].Add(1); LTA[41].Add(1); LTA[41].Add(2); LTA[41].Add(3); LTA[41].Add(3); LTA[41].Add(3);
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
            LTA[69].Add(1); LTA[69].Add(1); LTA[69].Add(1); LTA[69].Add(2); LTA[69].Add(3); LTA[69].Add(3); LTA[69].Add(3); LTA[69].Add(3);
            LTA[70].Add(1); LTA[70].Add(1); LTA[70].Add(1); LTA[70].Add(2); LTA[70].Add(3); LTA[70].Add(3); LTA[70].Add(3); LTA[70].Add(3);
            LTA[71].Add(1); LTA[71].Add(1); LTA[71].Add(1); LTA[71].Add(2); LTA[71].Add(3); LTA[71].Add(3); LTA[71].Add(3); LTA[71].Add(3);
            LTA[72].Add(1); LTA[72].Add(1); LTA[72].Add(1); LTA[72].Add(2); LTA[72].Add(3); LTA[72].Add(3); LTA[72].Add(3); LTA[72].Add(3);
            LTA[73].Add(1); LTA[73].Add(1); LTA[73].Add(1); LTA[73].Add(2); LTA[73].Add(3); LTA[73].Add(3); LTA[73].Add(3); LTA[73].Add(3);
            LTA[74].Add(1); LTA[74].Add(1); LTA[74].Add(1); LTA[74].Add(2); LTA[74].Add(3); LTA[74].Add(3); LTA[74].Add(3); LTA[74].Add(3);
            LTA[75].Add(1); LTA[75].Add(1); LTA[75].Add(1); LTA[75].Add(2); LTA[75].Add(3); LTA[75].Add(3); LTA[75].Add(3); LTA[75].Add(3);
            LTA[76].Add(1); LTA[76].Add(1); LTA[76].Add(1); LTA[76].Add(2); LTA[76].Add(3); LTA[76].Add(3); LTA[76].Add(3); LTA[76].Add(3);
            LTA[77].Add(1); LTA[77].Add(1); LTA[77].Add(1); LTA[77].Add(2); LTA[77].Add(3); LTA[77].Add(3); LTA[77].Add(3); LTA[77].Add(3);
            LTA[78].Add(1); LTA[78].Add(1); LTA[78].Add(1); LTA[78].Add(2); LTA[78].Add(3); LTA[78].Add(3); LTA[78].Add(3); LTA[78].Add(3);
            LTA[79].Add(1); LTA[79].Add(1); LTA[79].Add(1); LTA[79].Add(2); LTA[79].Add(3); LTA[79].Add(3); LTA[79].Add(3); LTA[79].Add(3);
            LTA[80].Add(1); LTA[80].Add(1); LTA[80].Add(1); LTA[80].Add(2); LTA[80].Add(3); LTA[80].Add(3); LTA[80].Add(3); LTA[80].Add(3);
            
            #endregion



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
