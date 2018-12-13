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
namespace US.AcceptanceTests.Features.ResultRelease._02_SearchBarcode
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SearchBarcodeFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "SearchBarcode.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SearchBarcode", null, ProgrammingLanguage.CSharp, new string[] {
                        "ResultRelease"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "SearchBarcode")))
            {
                global::US.AcceptanceTests.Features.ResultRelease._02_SearchBarcode.SearchBarcodeFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can open Search Barcode tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResultRelease")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterscenarioWithResetBrowser")]
        public virtual void AsAUserICanOpenSearchBarcodeTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can open Search Barcode tab", new string[] {
                        "AfterscenarioWithResetBrowser"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("The user \'doctor\' login in the Result Release", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("The user opens Search Barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("The Search Barcode tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can release an existing Barcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResultRelease")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithUnreleaseBarcode")]
        public virtual void AsAUserICanReleaseAnExistingBarcode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can release an existing Barcode", new string[] {
                        "AfterScenarioWithUnreleaseBarcode"});
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("The user \'doctor\' login in the Result Release", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("The user opens Search Barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("The user releases the \'BBEV0503K\' barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("The barcode \'BBEV0503K\' is released", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can unrelease an existing Barcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResultRelease")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithReleaseBarcode")]
        public virtual void AsAUserICanUnreleaseAnExistingBarcode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can unrelease an existing Barcode", new string[] {
                        "AfterScenarioWithReleaseBarcode"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("The user \'doctor\' login in the Result Release", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("The user opens Search Barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.When("The user unreleases the \'$KUCS0928U\' barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
 testRunner.Then("The barcode \'$KUCS0928U\' is unreleased", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can\'t release an already released Barcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResultRelease")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterscenarioWithResetBrowser")]
        public virtual void AsAUserICantReleaseAnAlreadyReleasedBarcode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can\'t release an already released Barcode", new string[] {
                        "AfterscenarioWithResetBrowser"});
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("The user \'doctor\' login in the Result Release", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("The user opens Search Barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.When("The user releases the \'$BDZT8867J\' barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("The barcode \'$BDZT8867J\' is not released", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can\'t unrelease an already unreleased Barcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SearchBarcode")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ResultRelease")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterscenarioWithResetBrowser")]
        public virtual void AsAUserICantUnreleaseAnAlreadyUnreleasedBarcode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can\'t unrelease an already unreleased Barcode", new string[] {
                        "AfterscenarioWithResetBrowser"});
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("The user \'doctor\' login in the Result Release", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And("The user opens Search Barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("The user unreleases the \'ATHU7356A\' barcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("The barcode \'ATHU7356A\' is not unreleased", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
