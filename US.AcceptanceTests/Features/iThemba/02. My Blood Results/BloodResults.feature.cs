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
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class BloodResultsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "BloodResults.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BloodResults", "\tAs a user I want to have my Blood Results", ProgrammingLanguage.CSharp, new string[] {
                        "iThemba",
                        "AfterScenarioWithGoToBloodResults"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "BloodResults")))
            {
                global::US.AcceptanceTests.Features.IThemba._02_MyBloodResults.BloodResultsFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User can open the Blood Results menu option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user without any barcode I can see the Scan the first Barcode page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user without any barcode I can go to Barcode Scan")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user with a barcode without result I can see the Your results are on the way" +
            " page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResultsOnTheWay")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user with a barcode without result I can go to Community Chats")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user with a 50-1000 cp/ml I can see my results at Blood Results: User50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "User50")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "User50")]
        public virtual void AsAUserWithA50_1000CpMlICanSeeMyResultsAtBloodResults_User50()
        {
#line 45
this.AsAUserWithA50_1000CpMlICanSeeMyResultsAtBloodResults("User50", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user with a 50-1000 cp/ml I can see my results at Blood Results: User1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "User1000")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "User1000")]
        public virtual void AsAUserWithA50_1000CpMlICanSeeMyResultsAtBloodResults_User1000()
        {
#line 45
this.AsAUserWithA50_1000CpMlICanSeeMyResultsAtBloodResults("User1000", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user with less than 50 cp/ml I can see my results at Blood Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user with more than 1000 cp/ml I can see my results at Blood Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can remain in the application after using Android native BACK button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can see a banner with my results on the way")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResultsOnTheWay")]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can close the banner with my results on the way")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResultsOnTheWay")]
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
