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
namespace US.AcceptanceTests.Features.IThemba._11_NoConnectivity
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class NoConnectivityFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "NoConnectivity.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NoConnectivity", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "NoConnectivity")))
            {
                global::US.AcceptanceTests.Features.IThemba._11_NoConnectivity.NoConnectivityFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after input the phone number")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserThatLosesConnectionAfterInputThePhoneNumber()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after input the phone number", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 4
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
 testRunner.Given("The user opens the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 6
 testRunner.And("The user \'User49\' enters his phone number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 7
 testRunner.And("The user click in send phone number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("The user is at Onboarding page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after input the SMS code")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        public virtual void AsAUserThatLosesConnectionAfterInputTheSMSCode()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after input the SMS code", null, new string[] {
                        "BeforeScenarioWithResetApp"});
#line 16
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 17
 testRunner.Given("The user opens the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.And("The user \'User49\' enters his phone number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("The user click in send phone number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("The user is at Enter SMS confirmation code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("The user is at Onboarding page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after input gender/age")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithCleanUser")]
        public virtual void AsAUserThatLosesConnectionAfterInputGenderAge()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after input gender/age", null, new string[] {
                        "BeforeScenarioWithCleanUser"});
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 29
 testRunner.Given("The user opens the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("The new user \'NewUser\' completes the SMS authentication process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("The user is at Onboarding page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after input clinic location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithCleanUser")]
        public virtual void AsAUserThatLosesConnectionAfterInputClinicLocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after input clinic location", null, new string[] {
                        "BeforeScenarioWithCleanUser"});
#line 38
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 39
 testRunner.Given("The user opens the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.And("The new user \'NewUser\' completes the SMS authentication process", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.And("The user sets it\'s profile info", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("The user is at Onboarding page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open Past Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenPastResults()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open Past Results", null, new string[] {
                        "BeforeScenarioWithResetApp",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 50
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 51
 testRunner.Given("The user \'User1001\' login in the iThemba app", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.And("The user opens the Past Results menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("The \'User1001\' Blood Results page is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open Blood Results")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenBloodResults()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open Blood Results", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 62
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 63
    testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open Barcode Scanner")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenBarcodeScanner()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open Barcode Scanner", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 72
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 73
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("The user opens Barcode Scan menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open Community Chats")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenCommunityChats()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open Community Chats", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 84
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 85
    testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
 testRunner.And("The user opens the Community Chats menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open About iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenAboutIThemba()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open About iThemba", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 96
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 97
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 98
 testRunner.And("The user opens the About iThemba menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open My Profile Demographic")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenMyProfileDemographic()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open My Profile Demographic", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 108
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 109
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 110
 testRunner.And("The user opens the My Profile menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user that loses connection after open My Profile Clinic Location")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NoConnectivity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResultsWithNetwork")]
        public virtual void AsAUserThatLosesConnectionAfterOpenMyProfileClinicLocation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user that loses connection after open My Profile Clinic Location", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResultsWithNetwork"});
#line 120
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 121
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
 testRunner.And("The user opens the My Profile menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("The user clicks Next button at demograph info page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.When("The user loses Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
 testRunner.Then("The user can see the No connection to network message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
 testRunner.And("The user recovers Connectivity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("The user click in Try Again", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
