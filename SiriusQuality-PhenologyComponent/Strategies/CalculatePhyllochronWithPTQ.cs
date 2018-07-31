

 //Author:Loic Manceau loic.manceau@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:6/4/2018
 //Date of revision:

using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;


using SiriusQualityPhenology;
using CRA.AgroManagement;


//To make this project compile please add the reference to assembly: SiriusQuality-PhenologyComponent, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer, Version=1.0.5212.29139, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.AgroManagement2014, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace SiriusQualityPhenology.Strategies
{

	/// <summary>
	///Class CalculatePhyllochronWithPTQ
    /// Calculate the phyllochron  with Photothermal Quotien
    /// </summary>
	public class CalculatePhyllochronWithPTQ : IStrategySiriusQualityPhenology
	{

	#region Constructor

			public CalculatePhyllochronWithPTQ()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 1.26;
				 v1.Description = "Scaling coefficient of GAI to carbon demand";
				 v1.Id = 0;
				 v1.MaxValue = 50;
				 v1.MinValue = 0;
				 v1.Name = "B";
				 v1.Size = 1;
				 v1.Units = "-";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				VarInfo v2 = new VarInfo();
				 v2.DefaultValue = 0.97;
				 v2.Description = "Photothermal quotient when leaf appearence rate is half LARdif+LARmin";
				 v2.Id = 0;
				 v2.MaxValue = 1000;
				 v2.MinValue = 0;
				 v2.Name = "PTQhf";
				 v2.Size = 1;
				 v2.Units = "MJ(PAR)/m² °Cd";
				 v2.URL = "";
				 v2.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v2);
				VarInfo v3 = new VarInfo();
				 v3.DefaultValue = 0.00138;
				 v3.Description = "Minimum leaf appearence rate when photothermal quotient equals zero";
				 v3.Id = 0;
				 v3.MaxValue = 1000;
				 v3.MinValue = 0;
				 v3.Name = "LARmin";
				 v3.Size = 1;
				 v3.Units = "leaf/°Cd";
				 v3.URL = "";
				 v3.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v3.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v3);
				VarInfo v4 = new VarInfo();
				 v4.DefaultValue = 0.0126;
				 v4.Description = "Value to add LARmin to reach maximum leaf appearence rate when photothermal quotient tends to infinity";
				 v4.Id = 0;
				 v4.MaxValue = 1000;
				 v4.MinValue = 0;
				 v4.Name = "LARdif";
				 v4.Size = 1;
				 v4.Units = "leaf/°Cd";
				 v4.URL = "";
				 v4.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v4.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v4);
				VarInfo v5 = new VarInfo();
				 v5.DefaultValue = 600;
				 v5.Description = "number of plant /m²";
				 v5.Id = 0;
				 v5.MaxValue = 1000;
				 v5.MinValue = 280;
				 v5.Name = "SowingDensity";
				 v5.Size = 1;
				 v5.Units = "shoot/m²";
				 v5.URL = "";
				 v5.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v5.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v5);
				VarInfo v6 = new VarInfo();
				 v6.DefaultValue = 9;
				 v6.Description = "Potential surface area of the leaves produced before floral initiation";
				 v6.Id = 0;
				 v6.MaxValue = 100;
				 v6.MinValue = 0;
				 v6.Name = "AreaSL";
				 v6.Size = 1;
				 v6.Units = "cm²/lamina";
				 v6.URL = "";
				 v6.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v6.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v6);
				VarInfo v7 = new VarInfo();
				 v7.DefaultValue = 1.83;
				 v7.Description = "Potential surface area of the sheath of the leaves produced before floral initiation";
				 v7.Id = 0;
				 v7.MaxValue = 100;
				 v7.MinValue = 0;
				 v7.Name = "AreaSS";
				 v7.Size = 1;
				 v7.Units = "cm²/sheath";
				 v7.URL = "";
				 v7.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v7.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v7);
				VarInfo v8 = new VarInfo();
				 v8.DefaultValue = 3;
				 v8.Description = "Number of leaves emerged before phyllochron depends on PTQ (below this value Phyllochron is constant)";
				 v8.Id = 0;
				 v8.MaxValue = 50;
				 v8.MinValue = 0;
				 v8.Name = "LNeff";
				 v8.Size = 1;
				 v8.Units = "leaf";
				 v8.URL = "";
				 v8.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v8.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v8);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(SiriusQualityPhenology.PhenologyState);
				pd1.PropertyName = "PTQ";
				pd1.PropertyType = (( SiriusQualityPhenology.PhenologyStateVarInfo.PTQ)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( SiriusQualityPhenology.PhenologyStateVarInfo.PTQ);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(SiriusQualityPhenology.PhenologyState);
				pd2.PropertyName = "GAImean";
				pd2.PropertyType = (( SiriusQualityPhenology.PhenologyStateVarInfo.GAImean)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( SiriusQualityPhenology.PhenologyStateVarInfo.GAImean);
				_inputs0_0.Add(pd2);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(SiriusQualityPhenology.PhenologyState);
				pd3.PropertyName = "Phyllochron";
				pd3.PropertyType =  (( SiriusQualityPhenology.PhenologyStateVarInfo.Phyllochron)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =(  SiriusQualityPhenology.PhenologyStateVarInfo.Phyllochron);
				_outputs0_0.Add(pd3);
				mo0_0.Outputs=_outputs0_0;
				//Associated strategies
				List<string> lAssStrat0_0 = new List<string>();
				mo0_0.AssociatedStrategies = lAssStrat0_0;
				//Adding the modeling options to the modeling options manager
				_modellingOptionsManager = new ModellingOptionsManager(mo0_0);
			
				SetStaticParametersVarInfoDefinitions();
				SetPublisherData();
					
			}

	#endregion

	#region Implementation of IAnnotatable

			/// <summary>
			/// Description of the model
			/// </summary>
			public string Description
			{
				get { return "Calculate the phyllochron  with Photothermal Quotien"; }
			}
			
			/// <summary>
			/// URL to access the description of the model
			/// </summary>
			public string URL
			{
				get { return "http://biomamodelling.org"; }
			}
		

	#endregion
	
	#region Implementation of IStrategy

			/// <summary>
			/// Domain of the model.
			/// </summary>
			public string Domain
			{
				get {  return "Crop"; }
			}

			/// <summary>
			/// Type of the model.
			/// </summary>
			public string ModelType
			{
				get { return "Development"; }
			}

			/// <summary>
			/// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
			/// </summary>
			public bool IsContext
			{
					get { return  false; }
			}

			/// <summary>
			/// Timestep to be used with this strategy
			/// </summary>
			public IList<int> TimeStep
			{
				get
				{
					IList<int> ts = new List<int>();
					
					return ts;
				}
			}
	
	
	#region Publisher Data

			private PublisherData _pd;
			private  void SetPublisherData()
			{
					// Set publishers' data
					
				_pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
				_pd.Add("Creator", "loic.manceau@inra.fr");
				_pd.Add("Date", "6/4/2018");
				_pd.Add("Publisher", "INRA");
			}

			public PublisherData PublisherData
			{
				get { return _pd; }
			}

	#endregion

	#region ModellingOptionsManager

			private ModellingOptionsManager _modellingOptionsManager;
			
			public ModellingOptionsManager ModellingOptionsManager
			{
				get { return _modellingOptionsManager; }            
			}

	#endregion

			/// <summary>
			/// Return the types of the domain classes used by the strategy
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Type> GetStrategyDomainClassesTypes()
			{
				return new List<Type>() {  typeof(SiriusQualityPhenology.PhenologyState),typeof(SiriusQualityPhenology.PhenologyState),typeof(CRA.AgroManagement.ActEvents) };
			}

	#endregion

    #region Instances of the parameters
			
			// Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

			
			public Double B
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("B");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'B' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("B");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'B' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double PTQhf
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("PTQhf");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'PTQhf' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("PTQhf");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'PTQhf' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double LARmin
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("LARmin");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'LARmin' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("LARmin");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'LARmin' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double LARdif
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("LARdif");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'LARdif' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("LARdif");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'LARdif' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double SowingDensity
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("SowingDensity");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'SowingDensity' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("SowingDensity");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'SowingDensity' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double AreaSL
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("AreaSL");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'AreaSL' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("AreaSL");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'AreaSL' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double AreaSS
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("AreaSS");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'AreaSS' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("AreaSS");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'AreaSS' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}
			public Double LNeff
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("LNeff");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'LNeff' not found (or found null) in strategy 'CalculatePhyllochronWithPTQ'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("LNeff");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'LNeff' not found in strategy 'CalculatePhyllochronWithPTQ'");
				}
			}

			// Getter and setters for the value of the parameters of a composite strategy
			

	#endregion		

	
	#region Parameters initialization method
			
            /// <summary>
            /// Set parameter(s) current values to the default value
            /// </summary>
            public void SetParametersDefaultValue()
            {
				_modellingOptionsManager.SetParametersDefaultValue();
				 

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
					//Code written below will not be overwritten by a future code generation

					//Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5 
            }

	#endregion		

	#region Static parameters VarInfo definition

			// Define the properties of the static VarInfo of the parameters
			private static void SetStaticParametersVarInfoDefinitions()
			{                                
                BVarInfo.Name = "B";
				BVarInfo.Description =" Scaling coefficient of GAI to carbon demand";
				BVarInfo.MaxValue = 50;
				BVarInfo.MinValue = 0;
				BVarInfo.DefaultValue = 1.26;
				BVarInfo.Units = "-";
				BVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				PTQhfVarInfo.Name = "PTQhf";
				PTQhfVarInfo.Description =" Photothermal quotient when leaf appearence rate is half LARdif+LARmin";
				PTQhfVarInfo.MaxValue = 1000;
				PTQhfVarInfo.MinValue = 0;
				PTQhfVarInfo.DefaultValue = 0.97;
				PTQhfVarInfo.Units = "MJ(PAR)/m² °Cd";
				PTQhfVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				LARminVarInfo.Name = "LARmin";
				LARminVarInfo.Description =" Minimum leaf appearence rate when photothermal quotient equals zero";
				LARminVarInfo.MaxValue = 1000;
				LARminVarInfo.MinValue = 0;
				LARminVarInfo.DefaultValue = 0.00138;
				LARminVarInfo.Units = "leaf/°Cd";
				LARminVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				LARdifVarInfo.Name = "LARdif";
				LARdifVarInfo.Description =" Value to add LARmin to reach maximum leaf appearence rate when photothermal quotient tends to infinity";
				LARdifVarInfo.MaxValue = 1000;
				LARdifVarInfo.MinValue = 0;
				LARdifVarInfo.DefaultValue = 0.0126;
				LARdifVarInfo.Units = "leaf/°Cd";
				LARdifVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				SowingDensityVarInfo.Name = "SowingDensity";
				SowingDensityVarInfo.Description =" number of plant /m²";
				SowingDensityVarInfo.MaxValue = 1000;
				SowingDensityVarInfo.MinValue = 280;
				SowingDensityVarInfo.DefaultValue = 600;
				SowingDensityVarInfo.Units = "shoot/m²";
				SowingDensityVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				AreaSLVarInfo.Name = "AreaSL";
				AreaSLVarInfo.Description =" Potential surface area of the leaves produced before floral initiation";
				AreaSLVarInfo.MaxValue = 100;
				AreaSLVarInfo.MinValue = 0;
				AreaSLVarInfo.DefaultValue = 9;
				AreaSLVarInfo.Units = "cm²/lamina";
				AreaSLVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				AreaSSVarInfo.Name = "AreaSS";
				AreaSSVarInfo.Description =" Potential surface area of the sheath of the leaves produced before floral initiation";
				AreaSSVarInfo.MaxValue = 100;
				AreaSSVarInfo.MinValue = 0;
				AreaSSVarInfo.DefaultValue = 1.83;
				AreaSSVarInfo.Units = "cm²/sheath";
				AreaSSVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				LNeffVarInfo.Name = "LNeff";
				LNeffVarInfo.Description =" Number of leaves emerged before phyllochron depends on PTQ (below this value Phyllochron is constant)";
				LNeffVarInfo.MaxValue = 50;
				LNeffVarInfo.MinValue = 0;
				LNeffVarInfo.DefaultValue = 3;
				LNeffVarInfo.Units = "leaf";
				LNeffVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _BVarInfo= new VarInfo();
				/// <summary> 
				///B VarInfo definition
				/// </summary>
				public static VarInfo BVarInfo
				{
					get { return _BVarInfo; }
				}
				private static VarInfo _PTQhfVarInfo= new VarInfo();
				/// <summary> 
				///PTQhf VarInfo definition
				/// </summary>
				public static VarInfo PTQhfVarInfo
				{
					get { return _PTQhfVarInfo; }
				}
				private static VarInfo _LARminVarInfo= new VarInfo();
				/// <summary> 
				///LARmin VarInfo definition
				/// </summary>
				public static VarInfo LARminVarInfo
				{
					get { return _LARminVarInfo; }
				}
				private static VarInfo _LARdifVarInfo= new VarInfo();
				/// <summary> 
				///LARdif VarInfo definition
				/// </summary>
				public static VarInfo LARdifVarInfo
				{
					get { return _LARdifVarInfo; }
				}
				private static VarInfo _SowingDensityVarInfo= new VarInfo();
				/// <summary> 
				///SowingDensity VarInfo definition
				/// </summary>
				public static VarInfo SowingDensityVarInfo
				{
					get { return _SowingDensityVarInfo; }
				}
				private static VarInfo _AreaSLVarInfo= new VarInfo();
				/// <summary> 
				///AreaSL VarInfo definition
				/// </summary>
				public static VarInfo AreaSLVarInfo
				{
					get { return _AreaSLVarInfo; }
				}
				private static VarInfo _AreaSSVarInfo= new VarInfo();
				/// <summary> 
				///AreaSS VarInfo definition
				/// </summary>
				public static VarInfo AreaSSVarInfo
				{
					get { return _AreaSSVarInfo; }
				}
				private static VarInfo _LNeffVarInfo= new VarInfo();
				/// <summary> 
				///LNeff VarInfo definition
				/// </summary>
				public static VarInfo LNeffVarInfo
				{
					get { return _LNeffVarInfo; }
				}					
			
			//Parameters static VarInfo list of the composite class
						

	#endregion
	
	#region pre/post conditions management		

		    /// <summary>
			/// Test to verify the postconditions
			/// </summary>
			public string TestPostConditions(SiriusQualityPhenology.PhenologyState phenologystate,SiriusQualityPhenology.PhenologyState phenologystate1, string callID)
			{
				try
				{
					//Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				
					
					SiriusQualityPhenology.PhenologyStateVarInfo.Phyllochron.CurrentValue=phenologystate.Phyllochron;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityPhenology.PhenologyStateVarInfo.Phyllochron);
					if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityPhenology.PhenologyStateVarInfo.Phyllochron.ValueType)){prc.AddCondition(r3);}

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

					//Get the evaluation of postconditions
					string postConditionsResult =pre.VerifyPostconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component SiriusQualityPhenology.Strategies, strategy " + this.GetType().Name ); }
					return postConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,	"Strategy: " + this.GetType().Name + " - Unhandled exception running post-conditions");

					string msg = "Component SiriusQualityPhenology.Strategies, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
					throw new Exception(msg, exception);
				}
			}

			/// <summary>
			/// Test to verify the preconditions
			/// </summary>
			public string TestPreConditions(SiriusQualityPhenology.PhenologyState phenologystate,SiriusQualityPhenology.PhenologyState phenologystate1, string callID)
			{
				try
				{
					//Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				
					
					SiriusQualityPhenology.PhenologyStateVarInfo.PTQ.CurrentValue=phenologystate.PTQ;
					SiriusQualityPhenology.PhenologyStateVarInfo.GAImean.CurrentValue=phenologystate.GAImean;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityPhenology.PhenologyStateVarInfo.PTQ);
					if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityPhenology.PhenologyStateVarInfo.PTQ.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityPhenology.PhenologyStateVarInfo.GAImean);
					if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityPhenology.PhenologyStateVarInfo.GAImean.ValueType)){prc.AddCondition(r2);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("B")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("PTQhf")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LARmin")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LARdif")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SowingDensity")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("AreaSL")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("AreaSS")));
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("LNeff")));

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 
								
					//Get the evaluation of preconditions;					
					string preConditionsResult =pre.VerifyPreconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component SiriusQualityPhenology.Strategies, strategy " + this.GetType().Name ); }
					return preConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//	TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,"Strategy: " + this.GetType().Name + " - Unhandled exception running pre-conditions");

					string msg = "Component SiriusQualityPhenology.Strategies, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
					throw new Exception(msg, exception);
				}
			}

		
	#endregion
		


	#region Model

		 	/// <summary>
			/// Run the strategy to calculate the outputs. In case of error during the execution, the preconditions tests are executed.
			/// </summary>
			public void Estimate(SiriusQualityPhenology.PhenologyState phenologystate,SiriusQualityPhenology.PhenologyState phenologystate1,CRA.AgroManagement.ActEvents actevents)
			{
				try
				{
					CalculateModel(phenologystate,phenologystate1,actevents);

					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,"Strategy: " + this.GetType().Name + " - Model executed");
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,		"Strategy: " + this.GetType().Name + " - Unhandled exception running model");

					string msg = "Error in component SiriusQualityPhenology.Strategies, strategy: " + this.GetType().Name + ": Unhandled exception running model. "+exception.GetType().FullName+" - "+exception.Message;				
					throw new Exception(msg, exception);
				}
			}

		

			private void CalculateModel(SiriusQualityPhenology.PhenologyState phenologystate,SiriusQualityPhenology.PhenologyState phenologystate1,CRA.AgroManagement.ActEvents actevents)
			{				
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
				//Code written below will not be overwritten by a future code generation


                //Mean irradiance intercepted over GAI mean (on TTWindowForPTQ window)
                double PTQ = phenologystate.PTQ;

                //GAI mean on TTWindowForPTQ window (maximum over the cultivation period)
                double GAImean = phenologystate.GAImean; 

                //GAI until the nubmer LNeff of leaves is reached
                double potentialGAISL = ((AreaSL + AreaSS) / 10000); //convert cm²->m²
                double GAILim = LNeff * potentialGAISL * SowingDensity;

                double LAR = 0.0;           

                if (GAImean > GAILim) LAR = (LARmin + ((LARdif * PTQ) / (PTQhf + PTQ))) /(B * GAImean);
                else LAR = (LARmin + ((LARdif * PTQ) / (PTQhf + PTQ))) / (B * GAILim);


                phenologystate.Phyllochron = 1.0 / LAR;




				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
