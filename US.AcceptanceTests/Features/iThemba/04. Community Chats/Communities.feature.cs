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
namespace US.AcceptanceTests.Features.IThemba._04_CommunityChats
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CommunitiesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Communities.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Communities", "\tAs a user i want to be able to connect easily with the community once I open the" +
                    " application.\r\n\tI want to see a list of different communities and be able to joi" +
                    "n them with a click of a button", ProgrammingLanguage.CSharp, new string[] {
                        "iThemba",
                        "AfterScenarioWithGoToBloodResults",
                        "Story:Communities"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Communities")))
            {
                global::US.AcceptanceTests.Features.IThemba._04_CommunityChats.CommunitiesFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User can open the Chat with Communities menu option")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        public virtual void UserCanOpenTheChatWithCommunitiesMenuOption()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User can open the Chat with Communities menu option", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResults"});
#line 14
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 15
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.When("The user opens the Community Chats menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("The Chat with Communities is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can navigate back using the Android native BACK button")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        public virtual void AsAUserICanNavigateBackUsingTheAndroidNativeBACKButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can navigate back using the Android native BACK button", null, new string[] {
                        "BeforeScenarioWithUniqueLogin"});
#line 21
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 22
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
 testRunner.And("The user opens the Community Chats menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("The user clicks on Android back button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("The Blood Results is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation(string user, string gender, string location, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "BeforeScenarioWithResetApp"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a user I can see my correct WhatsApp groups by gender / location", null, @__tags);
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 29
 testRunner.Given(string.Format("The user \'{0}\' login in the iThemba app", user), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.When("The user opens the Community Chats menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then(string.Format("The user \'{0}\' can see the groups for gender \'{1}\' and location \'{2}\'", user, gender, location), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can see my correct WhatsApp groups by gender / location: ResultsOnThe" +
            "Way")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "ResultsOnTheWay")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "ResultsOnTheWay")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:location", "Hillbrow")]
        public virtual void AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation_ResultsOnTheWay()
        {
#line 28
this.AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation("ResultsOnTheWay", "Male", "Hillbrow", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can see my correct WhatsApp groups by gender / location: User49")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "User49")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "User49")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gender", "Female")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:location", "Hillbrow")]
        public virtual void AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation_User49()
        {
#line 28
this.AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation("User49", "Female", "Hillbrow", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can see my correct WhatsApp groups by gender / location: User1001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "User1001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "User1001")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gender", "Male")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:location", "Yeoville")]
        public virtual void AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation_User1001()
        {
#line 28
this.AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation("User1001", "Male", "Yeoville", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("As a user I can see my correct WhatsApp groups by gender / location: NoResult")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithResetApp")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "NoResult")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:user", "NoResult")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:gender", "Female")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:location", "Yeoville")]
        public virtual void AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation_NoResult()
        {
#line 28
this.AsAUserICanSeeMyCorrectWhatsAppGroupsByGenderLocation("NoResult", "Female", "Yeoville", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User can join a Community Chat")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("iThemba")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Story:Communities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("BeforeScenarioWithUniqueLogin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AfterScenarioWithGoToBloodResults")]
        public virtual void UserCanJoinACommunityChat()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User can join a Community Chat", null, new string[] {
                        "BeforeScenarioWithUniqueLogin",
                        "AfterScenarioWithGoToBloodResults"});
#line 44
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 45
 testRunner.Given("The user opens the iThemba app menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.And("The user opens the Community Chats menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("The user clicks in join a Community", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("The user is redirect to whatsapp Community Chat", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
