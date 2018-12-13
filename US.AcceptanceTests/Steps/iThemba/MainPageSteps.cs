using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Configuration;
using CL.Containers;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace US.AcceptanceTests.Steps.Main
{
    /// <summary>
    /// The main page steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class MainPageSteps : StepBase
    {
        private readonly IMainPage mainPage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageSteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>

        public MainPageSteps(ISetUp setUp)
        {
            TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;
            this.mainPage = AppContainer.Container.Resolve<IMainPage>();
            this.setUp = setUp;
        }

        #region .: Steps :.

        /// <summary>
        /// The user opens the iThemba app for the first time.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the iThemba app for the first time")]
        [When(@"The user opens the iThemba app for the first time")]
        public void TheUSerOpenIthembaFirstTime()
        {
            mainPage.IsAtOnboardPage1();            
        }


        /// <summary>
        /// The user opens the iThemba app for the second time.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user opens the iThemba app for the second time")]
        public void TheUSerOpenIthembaSecondTime()
        {
            TheUSerOpenIthembaFirstTime();
            TheUserCanSeeInfoAboutApp();
            TheUserClickSignUp();
            TheUserIsAtSignUpScreen();
            setUp.ReopenApp();
        }

        /// <summary>
        /// The user opens the iThemba app.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the iThemba app")]
        [When(@"The user opens the iThemba app")]
        public void TheUSerOpenIthemba()
        {
            TheUSerOpenIthembaFirstTime();
            TheUserCanSeeInfoAboutApp();
            TheUserClickSignUp();
            TheUserIsAtSignUpScreen();
        }

        /// <summary>
        /// The user click in Sign-up.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user click in Sign-up")]
        public void TheUserClickSignUp()
        {
            mainPage.IsAtOnboardPage3();
            mainPage.ClickSignUpButton();
        }

        /// <summary>
        /// The user can see the info about how to use the app.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can see the info about how to use the app")]
        public void TheUserCanSeeInfoAboutApp()
        {
            mainPage.ClickNextButton();
            mainPage.IsAtOnboardPage2();

            mainPage.ClickNextButton();
            mainPage.IsAtOnboardPage3();
        }

        /// <summary>
        /// The user can see the Sign-up screen.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can see the Sign-up screen")]
        public void TheUserIsAtSignUpScreen()
        {
            AppContainer.Container.Resolve<ILoginPage>().IsAtEnterPhoneNumberPage();
        }

        #endregion

        #region .: After Scenario :.
        /// <summary>
        /// The after scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (!setUp.IsDriverNull())
                {
                    if (ScenarioContext.Current.TestError != null)
                    {
                        this.setUp.SetSauceLabsTestResult("failed");
                        // Take a screenshot.
                        var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                        CurrentTestContext.AddResultFile(screenshotPathFile);
                    }
                    else
                    {
                        this.setUp.SetSauceLabsTestResult("passed");
                    }
                }
            }
            catch
            {
                setUp.CloseDriver();
            }
        }


        /// <summary>
        /// The after scenario.
        /// </summary>
        [AfterScenario("AfterScenarioWithGoToBloodResults")]
        public void AfterScenarioGoToMenu()
        {
            setUp.OpenMenuBySwipe();
            AppContainer.Container.Resolve<IMenuDrawerPage>().OpenBloodResults();
            //AppContainer.Container.Resolve<IBloodResultsPage>().IsAtBloodResultsPage().Should().BeTrue();

            try
            {
                if (!setUp.IsDriverNull())
                {
                    if (ScenarioContext.Current.TestError != null)
                    {
                        this.setUp.SetSauceLabsTestResult("failed");

                        // Take a screenshot.
                        var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                        CurrentTestContext.AddResultFile(screenshotPathFile);
                    }
                    else
                    {
                        this.setUp.SetSauceLabsTestResult("passed");
                    }
                }
            }
            catch
            {
                setUp.CloseDriver();
            }
        }

        /// <summary>
        /// The after scenario.
        /// </summary>
        [AfterScenario("@AfterScenarioWithEnablingNetwork")]
        public void AfterScenarioEnableNetwork()
        {
            setUp.SetAllNetworkMode();

            try
            {
                if (!setUp.IsDriverNull())
                {
                    if (ScenarioContext.Current.TestError != null)
                    {
                        this.setUp.SetSauceLabsTestResult("failed");

                        // Take a screenshot.
                        var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                        CurrentTestContext.AddResultFile(screenshotPathFile);
                    }
                    else
                    {
                        this.setUp.SetSauceLabsTestResult("passed");
                    }
                }
            }
            catch
            {
                setUp.CloseDriver();
            }
        }
        
        #endregion

        #region .: Before Scenario :.
        /*
        /// <summary>
        /// Before the scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            if (!setUp.IsDriverNull())
            {
                AppContainer.Container.Resolve<ISetUp>().ReopenApp();
            }
        }
        */

        /// <summary>
        /// Before the scenario for BeforeScenarioWithResetApp tag.
        /// </summary>
        [BeforeScenario("BeforeScenarioWithResetApp")]
        public void BeforeScenarioResetApp()
        {
            if (!setUp.IsDriverNull())
            {
                setUp.ResetApp();
            }
        }
        #endregion

        /// <summary>
        /// The clean test run.
        /// </summary>
        [AfterTestRun]
        public static void CleanTestRun()
        {
            AppContainer.Container.Resolve<ISetUp>().CloseDriver();
        }
    }
}
