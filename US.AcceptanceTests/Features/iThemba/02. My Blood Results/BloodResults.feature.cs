﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace US.AcceptanceTests.Features.IThemba._02_MyBloodResults
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("BloodResults")]
    [NUnit.Framework.CategoryAttribute("iThemba")]
    [NUnit.Framework.CategoryAttribute("AfterScenarioWithGoToBloodResults")]
    public partial class BloodResultsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BloodResults.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BloodResults", "\tAs a user I want to have my Blood Results", ProgrammingLanguage.CSharp, new string[] {
                        "iThemba",
                        "AfterScenarioWithGoToBloodResults"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("User can open the Blood Results menu option")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithUniqueLogin")]
        public virtual void UserCanOpenTheBloodResultsMenuOption()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User can open the Blood Results menu option", null, new string[] {
                        "BeforeScenarioWithUniqueLogin"});
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user without any barcode I can see the Scan the first Barcode page")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserWithoutAnyBarcodeICanSeeTheScanTheFirstBarcodePage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user without any barcode I can see the Scan the first Barcode page", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 14
 testRunner.Given("The user \'NoResult\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("The Scan the first Barcode page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user without any barcode I can go to Barcode Scan")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserWithoutAnyBarcodeICanGoToBarcodeScan()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user without any barcode I can go to Barcode Scan", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 20
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 21
 testRunner.Given("The user \'NoResult\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("The user clicks in Go to Scanner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("The mobile camera is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user with a barcode without result I can see the Your results are on the way" +
            " page")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResultsOnTheWay")]
        public virtual void AsAUserWithABarcodeWithoutResultICanSeeTheYourResultsAreOnTheWayPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user with a barcode without result I can see the Your results are on the way" +
                    " page", null, new string[] {
                        "BeforeScenarioWithResetApp",
                        "BeforeScenarioWithResultsOnTheWay"});
#line 29
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 30
 testRunner.Given("The user \'ResultsOnTheWay\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("The \'ResultsOnTheWay\' Blood Results page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user with a barcode without result I can go to Community Chats")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserWithABarcodeWithoutResultICanGoToCommunityChats()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user with a barcode without result I can go to Community Chats", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 36
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 37
 testRunner.Given("The user \'ResultsOnTheWay\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("The user clicks in Go to Community", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.Then("The Chat with Communities is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user with a 50-1000 cp/ml I can see my results at Blood Results")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        [NUnit.Framework.TestCaseAttribute("User50", null)]
        [NUnit.Framework.TestCaseAttribute("User1000", null)]
        public virtual void AsAUserWithA50_1000CpMlICanSeeMyResultsAtBloodResults(string user, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "BeforeScenarioWithResetApp"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user with a 50-1000 cp/ml I can see my results at Blood Results", null, @__tags);
#line 45
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 46
 testRunner.Given(string.Format("The user \'{0}\' login in the iThemba app", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then(string.Format("The \'{0}\' Blood Results page is opened", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user with less than 50 cp/ml I can see my results at Blood Results")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserWithLessThan50CpMlICanSeeMyResultsAtBloodResults()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user with less than 50 cp/ml I can see my results at Blood Results", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 58
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 59
 testRunner.Given("The user \'User49\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
 testRunner.Then("The \'User49\' Blood Results page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user with more than 1000 cp/ml I can see my results at Blood Results")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserWithMoreThan1000CpMlICanSeeMyResultsAtBloodResults()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user with more than 1000 cp/ml I can see my results at Blood Results", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 65
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 66
 testRunner.Given("The user \'User1001\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
 testRunner.Then("The \'User1001\' Blood Results page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user I can remain in the application after using Android native BACK button")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserICanRemainInTheApplicationAfterUsingAndroidNativeBACKButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can remain in the application after using Android native BACK button", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 72
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 73
 testRunner.Given("The user \'User49\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("The user clicks on Android back button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("The user clicks in NO button from Exit pop up message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user I can see a banner with my results on the way")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResultsOnTheWay")]
        public virtual void AsAUserICanSeeABannerWithMyResultsOnTheWay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can see a banner with my results on the way", null, new string[] {
                        "BeforeScenarioWithResetApp",
                        "BeforeScenarioWithResultsOnTheWay"});
#line 80
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 81
 testRunner.Given("The user \'ResultsOnTheWayMultiple\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 82
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.When("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.Then("The Results on the way banner appears", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("As a user I can close the banner with my results on the way")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResetApp")]
        [NUnit.Framework.CategoryAttribute("BeforeScenarioWithResultsOnTheWay")]
        public virtual void AsAUserICanCloseTheBannerWithMyResultsOnTheWay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can close the banner with my results on the way", null, new string[] {
                        "BeforeScenarioWithResetApp",
                        "BeforeScenarioWithResultsOnTheWay"});
#line 88
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 89
 testRunner.Given("The user \'ResultsOnTheWayMultiple\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.When("The user closes the Results on the Way banner", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("The user opens the Blood Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.Then("The Results on the way banner doesn\'t appear", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
