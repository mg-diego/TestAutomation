using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Configuration;
using CL.Containers;
using DF.Entities;
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
		private readonly IAnalytics analytics;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageSteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        /// <param name="mainPage">The main page.</param>

        public MainPageSteps(ISetUp setUp, IMainPage mainPage, IAnalytics analytics)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.mainPage = mainPage;
            this.setUp = setUp;
			this.analytics = analytics;
        }

        #region .: Steps :.

        /// <summary>
        /// The user opens the iThemba app for the first time.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the iThemba app for the first time")]
        [When(@"The user opens the iThemba app for the first time")]
        [Then(@"The user is at Onboarding page")]
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

        /// <summary>
        /// The user can see the SMS code screen.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can see the Enter SMS code screen")]
        public void TheUserIsAtEnterSMSCodeScreen()
        {
            AppContainer.Container.Resolve<ILoginPage>().IsAtEnterSMSCodePage();
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
                        // Take a screenshot.
                        //var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                        //CurrentTestContext.AddResultFile(screenshotPathFile);
                    }
                }
            }
            catch
            {
                setUp.CloseDriver();
            }
        }


        /// <summary>
        /// The AfterScenarioWithGoToBloodResults--- scenario.
        /// </summary>
        [AfterScenario("AfterScenarioWithGoToBloodResults")]
        public void AfterScenarioGoToMenu()
        {
            setUp.OpenMenuBySwipe();
            AppContainer.Container.Resolve<IMenuDrawerPage>().OpenBloodResults();

            try
            {
                if (!setUp.IsDriverNull())
                {
                    if (ScenarioContext.Current.TestError != null)
                    {
						// Take a screenshot.
						//Console.WriteLine(ScenarioContext.Current.ScenarioInfo);
                        var screenshotPathFile = setUp.MakeScreenshot("stepName",ScenarioContext.Current.ScenarioInfo.Title);
                        CurrentTestContext.AddResultFile(screenshotPathFile);
                    }
                }
            }
            catch
            {
                setUp.CloseDriver();
            }
        }


        /// <summary>
        /// The AfterScenarioWithEnablingNetwork--- scenario.
        /// </summary>
        [AfterScenario("@AfterScenarioWithGoToBloodResultsWithNetwork")]
        public void AfterScenarioWithGoToBloodResultsWithNetwork()
        {
            setUp.SetAllNetworkMode();
            setUp.OpenMenuBySwipe();
            AppContainer.Container.Resolve<IMenuDrawerPage>().OpenBloodResults();

            try
            {
                if (!setUp.IsDriverNull())
                {
                    if (ScenarioContext.Current.TestError != null)
                    {
                        // Take a screenshot.
                        var screenshotPathFile = setUp.MakeScreenshot("stepName", ScenarioContext.Current.ScenarioInfo.Title);
                        CurrentTestContext.AddResultFile(screenshotPathFile);
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
        /// Before the scenario for BeforeScenarioWithResetApp--- tag.
        /// </summary>
        [BeforeScenario("BeforeScenarioWithResetApp")]
        public void BeforeScenarioResetApp()
        {
            if (!setUp.IsDriverNull())
            {
                setUp.ResetApp();
            }
        }

		/// <summary>
		/// Before the scenario for BeforeScenarioWithCleanUser--- tag.
		/// </summary>
		[BeforeScenario("BeforeScenarioWithCleanUser")]
		public void BeforeScenarioWithCleanUser()
		{
			if (!setUp.IsDriverNull())
			{
				var loginUser = this.GetLoginUser("NewUser");
				analytics.ClearUserData(loginUser);

				setUp.ResetApp();				
			}
		}

		/// <summary>
		/// Before the scenario for BeforeScenarioWithResultsOnTheWay--- tag.
		/// </summary>
		[BeforeScenario("BeforeScenarioWithResultsOnTheWay")]
		public void BeforeScenarioWithResultsOnTheWay()
		{
			analytics.SetResultsOnTheWayBarcodesValidDateFrame();
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

        /// <summary>
        /// The clean test run.
        /// </summary>
        [AfterStep]
        public void AfterStepMakeScreenShot()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.StepContext.StepInfo.StepDefinitionType.ToString(), ScenarioContext.Current.ScenarioInfo.Title);
        }

    }
}
