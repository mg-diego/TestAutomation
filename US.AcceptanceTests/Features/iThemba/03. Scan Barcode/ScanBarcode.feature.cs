﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace US.AcceptanceTests.Features.IThemba._03_ScanBarcode
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ScanBarcodeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ScanBarcode.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ScanBarcode", "\tAs a user i want a clear indication when i scan a barcode that i am doing it cor" +
                    "rectly", ProgrammingLanguage.CSharp, new string[] {
                        "iThemba",
                        "Story:ScanBarcode"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ScanBarcode")))
            {
                global::US.AcceptanceTests.Features.IThemba._03_ScanBarcode.ScanBarcodeFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User can open the camera to scan a Barcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ScanBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:ScanBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        public virtual void UserCanOpenTheCameraToScanABarcode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User can open the camera to scan a Barcode", new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResults"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.When("The user opens Barcode Scan menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("The mobile camera is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User can exit the camera by pressing Android native Back button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ScanBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:ScanBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        public virtual void UserCanExitTheCameraByPressingAndroidNativeBackButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User can exit the camera by pressing Android native Back button", new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResults"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("The user opens Barcode Scan menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("The user clicks on Android back button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.Then("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
