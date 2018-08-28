using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiriusQualityPhenology;

namespace SiriusQuality_PhenologyConsole
{
    class PhenologyWrapper
    {
        #region outputs
        //Outputs of the component

        // Calendar where The stage, the thermal time at the begining of the stage and the date are registerd for the day d-1
        public Calendar previousCalendar { get { return previousphenologyState.Calendar; } }
        //Calendar for the current day (d)
        public Calendar calendar { get { return phenologyState.Calendar; } }
        //Haun Stage
        public double LeafNumber { get { return phenologyState.LeafNumber; } }
        
        public double FinalLeafNumber { get { return phenologyState.FinalLeafNumber; } }
        public double phaseValue { get { return phenologyState.phase_.phaseValue; } }
        public int RoundedFinalLeafNumber { get { return (int)(phenologyState.FinalLeafNumber + 0.5); } }
        public double Phyllochron { get { return phenologyState.Phyllochron; } }

        //Progression of the Vernalization
        public double VernaProg { get { return phenologyState.Vernaprog; } }
        //Store the density of new tiller (main-stem +tillers) created at each time a new tiller appears
        public List<double> tilleringProfile { get { return phenologyState.tilleringProfile; } }
        //Store the number of tillers (main-stem +tillers) for each leaf layer
        public List<double> leafTillerNumberArray { get { return phenologyState.leafTillerNumberArray; } }
        //Tiller Number (main-stem + tillers)
        public int TillerNumber { get { return phenologyState.TillerNumber; } }
        //Shoot density (Tillers + main-stem) (shoot/m²)
        public double CanopyShootNumber { get { return phenologyState.CanopyShootNumber; } }
        
        public double AverageShootNumberPerPlant { get { return phenologyState.AverageShootNumberPerPlant; } }
        //Sowing date correction factor for Phyllochron (dimmensionless)
        public double FixPhyll { get { return phenologyState.Fixphyll; } }

        public double PTQ { get { return phenologyState.PTQ; } }
        public double GAImean { get { return phenologyState.GAImean; } }

        #endregion

        #region parameters
        //See "Documentation\SQ-Phenology: BioMA-SiriusQuality component of phenology" document Table A2 for definitions
        //Exemple of parameter set for spring wheat and Yecora Rojo variety. 

        //Non-Varietal
        bool IsVernalizable = true;//false: the vaiety is not vernalizable

        //-- For Sowing date correction of the phyllochron
        int SowingDay = 80;
        double Latitude = 33.069;
        double Rp = 0.003;
        double SDsa_sh = 151.0;
        double SDws = 90.0;
        double SDsa_nh = 200.0;

        //-- For segmented linear phyllochron model
        double Ldecr = 3.0;
        double Lincr = 8.0;
        double Pdecr = 0.4;
        double Pincr = 1.25;

        //-- For developmental phase timing parametrization
        double Dcd = 100.0;
        double Der = 300.0;
        double slopeTSFLN = 0.9;
        double intTSFLN = 2.6;

        //-- For Final leaf number, vernalization and photoperiod sensitivity
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

        double TTWindowForPTQ = 70.0;//Thermal Time window for the sliding average of the PTQ calculations 

        //-- For Shoot density calculation
        double SowingDensity = 288.0;
        double TargetFertileShoot = 600.0;

        //Varietal
        double P = 120.0;
        double VAI = 5.5;
        double SLDL = 0.85;
        double Dse = 105.0;
        double Dgf = 450.0;
        double Degfm = 0.0;

        //--For PTQ parametrization od the phyllochron (preliminary values)
        double PTQhf =  0.46;
        double Kl = 0.45;
        double LARmin = 0.0138;
        double LARmax = 0.0264;
        double B = 1.2;
        double LNeff = 3.0;
        double AreaSL = 9.0;
        double AreaSS = 1.83;


        //Options
        bool IgnoreGrainMaturation = false; //true:Zadok stage 92 (or phase 6: Maturity or dry grains) is ignored 
        string choosePhyllUse = "Default"; //"Default" for segmented linear modeled phyllocron with Sowing date correction
        //string choosePhyllUse = "PTQ"; //for photoThermal Quotient parametrization of phyllochron
        //string choosePhyllUse = "Test"; //for segmented linear modeled phyllochron without Sowing date correction
        //With "Test" it is possible to test a linear modeled phyllochron by setting
        //parameters Pdecr an Pincr to 1.0


        #endregion

        #region Constructor

        public PhenologyWrapper()
        {
            phenologyComponent = new SiriusQualityPhenology.Strategies.Phenology();
            phenologyState = new SiriusQualityPhenology.PhenologyState();
            previousphenologyState = new SiriusQualityPhenology.PhenologyState();
            loadParameters();
        }

        #endregion

        #region Initialization function

        //Register the sowing stage
        public void Init(double cumulTTatSowing, DateTime sowingDate)
        {

            phenologyComponent.Init(cumulTTatSowing, sowingDate, phenologyState);
            loadParameters();
        }

        #endregion

        #region Estimate fuction
        //This function runs the component for a given day

        public void EstimatePhenology(double dayLength, double deltaTTShoot, double cumulTT, double grainCumulTT, double GAI, bool isLatestLeafInternodeLengthPotPositive, double PAR, DateTime CurrentDate)
        {
            //Values of the day become values of the previous day just before calling the component
            LoadPreviousStates();

            //Valorization of the inputs
            phenologyState.DayLength = dayLength;
            phenologyState.DeltaTT = deltaTTShoot;
            phenologyState.cumulTT = cumulTT;
            phenologyState.GrainCumulTT = grainCumulTT;
            phenologyState.GAI = GAI;
            phenologyState.PAR = PAR;
            phenologyState.IsLatestLeafInternodeLengthPotPositive = (isLatestLeafInternodeLengthPotPositive) ? 1 : 0;
            phenologyState.currentdate = CurrentDate;

            //Call of the commponent
            //null is for the BioMa agroManagement events, they are not use here but can be used in the futur
            phenologyComponent.Estimate(phenologyState, previousphenologyState, null);
            

        }

        #endregion


        #region Utilities

        #region Load Parameters

        private void loadParameters()
        {
            phenologyComponent.AMNFLNO = AMNLFNO;
            phenologyComponent.AMXLFNO = AMXLFNO;
            phenologyComponent.Dcd = Dcd;
            phenologyComponent.Degfm = Degfm;
            phenologyComponent.Der = Der;
            phenologyComponent.Dgf = Dgf;
            phenologyComponent.Dse = Dse;
            phenologyComponent.IgnoreGrainMaturation = (IgnoreGrainMaturation) ? 1 : 0;
            phenologyComponent.IntTvern = IntTvern;
            phenologyComponent.IsVernalizable = (IsVernalizable) ? 1 : 0;
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
            phenologyComponent.LNeff = LNeff;
            phenologyComponent.AreaSS = AreaSS;
            phenologyComponent.AreaSL = AreaSL;

        }
        #endregion

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

        #region Instantiation

        //Composite strategy instantiation
        private SiriusQualityPhenology.Strategies.Phenology phenologyComponent;

        //Domain Class instantiation

        //States of the day
        private SiriusQualityPhenology.PhenologyState phenologyState;
        //States of the previous day
        private SiriusQualityPhenology.PhenologyState previousphenologyState;

        #endregion
    }
}
