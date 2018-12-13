using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Containers;
using DF.Entities;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.Login
{
    /// <summary>
    /// The dashboard login steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class LoginBaseSteps : StepBase
    {
        private readonly ILoginBasePage LoginBasePage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginBaseSteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        /// <param name="LoginBasePage">The login page.</param>
        public LoginBaseSteps(ISetUp setUp, ILoginBasePage LoginBasePage)
        {
            this.setUp = setUp;
            this.LoginBasePage = LoginBasePage;
        }


        /// <summary>
        /// The user clicks in the Login button.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user clicks in the Login button")]
        public void TheUSerClicksLoginButton()
        {
            LoginBasePage.ClickLoginButton();
        }


        /// <summary>
        /// The 'user' login in the Dashboard.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user '(.*)' login in the Dashboard")]
        [Given(@"The user '(.*)' login in the Result Release")]
        public void TheUserDoesExternalLogin(string user)
        {
            TheUSerClicksLoginButton();
            TheUSerEnterCredentials(user);
        }
        

        /// <summary>
        /// The user enters the credentials for user "User"
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user '(.*)' enter his credentials")]
        public void TheUSerEnterCredentials(string user)
        {
            var loginUser = this.GetLoginUser(user);
            LoginBasePage.EnterUsername(loginUser);
            LoginBasePage.EnterPassword(loginUser);
            LoginBasePage.ClickExternalLoginButton();
        }

        /// <summary>
        /// The invalid credentials message appears.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The invalid credentials message appears and user can't login")]
        public void TheInvalidCredentialsAppears()
        {
            LoginBasePage.IsAtInvalidLogin().Should().BeTrue();
        }

        /// <summary>
        /// The user clicks in the Login button.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user is at login page")]
        public void TheUSerIsAtLoginPage()
        {
            LoginBasePage.IsAtLoginBasePage();
        }



        /// <summary>
        /// The after scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                // Take a screenshot.
                //var screenshotPathFile = setUp.MakeScreenshot(ScenarioContext.Current.ScenarioInfo.Title);
                //CurrentTestContext.AddResultFile(screenshotPathFile);               
            }
            catch
            {
                setUp.CloseDriver();
            }
        }

        /// <summary>
        /// Before the scenario for AfterscenarioWithResetBrowser tag.
        /// </summary>
        [AfterScenario("@AfterscenarioWithResetBrowser")]
        public void AfterScenarioWithResetBrowser()
        {
            AfterScenario();
            setUp.CloseDriver();
            setUp.ReopenBrowser();
        }


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
