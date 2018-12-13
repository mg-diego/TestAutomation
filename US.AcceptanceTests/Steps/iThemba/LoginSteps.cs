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
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.Login
{
    /// <summary>
    /// The login steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class LoginSteps : StepBase
    {
        private readonly ILoginPage loginPage;
        private readonly ISetUp setUp;
        private readonly IAnalytics analytics;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        public LoginSteps(ISetUp setUp, IAnalytics analytics)
        {
            TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;
            this.loginPage = AppContainer.Container.Resolve<ILoginPage>();
            this.setUp = setUp;
            this.analytics = analytics;
        }

        #region .: Steps :.
        /// <summary>
        /// The user enters his phone number.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user '(.*)' enters his phone number")]
        [When(@"The user enters his phone number")]
        public void TheUSerEnterHisPhoneNumber(string user)
        {
            var loginUser = this.GetLoginUser(user);
            loginPage.CheckDefaultPhonePrefix().Should().BeTrue();
            loginPage.ClearPhonePrefix();
            loginPage.EnterPhonePrefix(loginUser);
            loginPage.EnterPhoneNumber(loginUser);
        }

        /// <summary>
        /// The user click in send phone number.
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user click in send phone number")]
        [When(@"The user click in send phone number")]
        public void TheUserClickInSendPhoneNumber()
        {
            loginPage.ClickSendPhoneNumber();
        }

        /// <summary>
        /// The user click on send code number again.
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user click in send code again")]
        public void TheUserClickOnSendCodeAgain()
        {
            loginPage.ClickSendCodeAgain();
        }

        /// <summary>
        /// The user receives the confirmation code
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user '(.*)' receives the confirmation code")]
        public void TheUserReceivesTheConfirmationCode(string user)
        {
            var loginUser = this.GetLoginUser(user);
            loginPage.GetConfirmationCode(loginUser);
            loginPage.ClickSendConfirmationCode();
            var result = analytics.GetAnalyticUserLoggedInFromDatabase();
            analytics.IsAnalyticUserLoggedInSaved(result, loginUser);
        }

        /// <summary>
        /// The user completes the SMS authentication process
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user '(.*)' completes the SMS authentication process")]
        public void TheUserCompleteSMSAuthentication(string user)
        {
            TheUSerEnterHisPhoneNumber(user);
            TheUserClickInSendPhoneNumber();
            TheUserReceivesTheConfirmationCode(user);
        }

        /// <summary>
        /// The user completes the SMS authentication process
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user '(.*)' completes the SMS authentication process with failed attempts")]
        public void TheUserCompleteSMSAuthenticationWithFailedAttempts(string user)
        {
            TheUSerEnterHisPhoneNumber(user);
            TheUserClickInSendPhoneNumber();
            loginPage.InputWrongSMSCodeRandomTimes();
            TheUserReceivesTheConfirmationCode(user);
        }

        /// <summary>
        /// The user receives the confirmation code and login without Network
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user '(.*)' receives the confirmation code and loses Network after login")]
        public void TheUserReceivesTheConfirmationCodeAndLosesNetworkAfterLogin(string user)
        {
            TheUserReceivesTheConfirmationCode(user);
            //TheUserSkipsProfileInfo();
            setUp.SetAirplaneMode();
            //TheUserCanCompleteLogin();
        }


        /// <summary>
        /// The user sets Profile info
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user sets it's profile info")]
        public void TheUserSetsProfileInfo()
        {
            loginPage.IsAtSetGenderAgeInfo();
            //loginPage.SelectRandomGender();
            setUp.MoveSeekBar(loginPage.GetAgeSelectorWidthX(), loginPage.GetAgeSelectorTotalWidth(), loginPage.GetAgeSelectorWidthY());
            loginPage.ClickConfirmProfileInfo();
        }

        /// <summary>
        /// The user sets Location info
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user sets it's location info")]
        public void TheUserSetsLocationInfo()
        {
            //City
            loginPage.ClickInputCityInfo();
            loginPage.IsAtSetLocationInfoPopup().Should().BeTrue();
            loginPage.SelectRandomPopupOption();

            //Neighbourhood
            loginPage.ClickInputNeighbourhoodInfo();
            loginPage.IsAtSetLocationInfoPopup().Should().BeTrue();
            loginPage.SelectRandomPopupOption();

            //Clinic
            loginPage.ClickInputClinicInfo();
            loginPage.IsAtSetLocationInfoPopup().Should().BeTrue();
            loginPage.SelectRandomPopupOption();

            loginPage.ClickConfirmLocationInfo();
        }

        /// <summary>
        /// The user skips Profile info
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user skips it's profile info")]
        public void TheUserSkipsProfileInfo()
        {
            loginPage.ClickSkipProfileInfo();
        }

        /// <summary>
        /// The user skips Location info
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user skips it's location info")]
        public void TheUserSkipsLocationInfo()
        {
            loginPage.ClickSkipLocationInfo();
        }

        /// <summary>
        /// The user can complete the login
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user (.*) can complete the login")]
        public void TheUserCanCompleteLogin(string user)
        {
            var loginUser = this.GetLoginUser(user);
            loginPage.ClickGoToHomepage();
            var result = analytics.GetAnalyticUserLoggedInFromDatabase();
            analytics.IsAnalyticUserLoggedInSaved(result, loginUser);
        }


        /// <summary>
        /// The user login in the iThemba app.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user '(.*)' login in the iThemba app")]
        public void TheUSerLoginInIthembaApp(string user)
        {
            var loginUser = this.GetLoginUser(user);

            try
            {  
                //MainPage
                AppContainer.Container.Resolve<IMainPage>().ClickNextButton();
                AppContainer.Container.Resolve<IMainPage>().ClickNextButton();
                AppContainer.Container.Resolve<IMainPage>().ClickSignUpButton();

                //Phone confirmation
                TheUserCompleteSMSAuthentication(user);

                //TheUserSkipsProfileInfo();
                //TheUserSkipsLocationInfo();
                //TheUserCanCompleteLogin();
            }
            catch (Exception e)
            {
                throw new Exception($"User {user} could not login.", e);
            }

            var result = analytics.GetAnalyticBarcodeDataRequestedFromDatabase();
            analytics.IsAnalyticBarcodeDataRequestedSaved(result, loginUser);
        }


        /// <summary>
        /// The user login in the iThemba app.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user '(.*)' login in the iThemba app and loses Network")]
        public void TheUSerLoginInIthembaAppAndLosesNetwork(string user)
        {
            try
            {
                var loginUser = this.GetLoginUser(user);

                //MainPage
                AppContainer.Container.Resolve<IMainPage>().ClickNextButton();
                AppContainer.Container.Resolve<IMainPage>().ClickNextButton();
                AppContainer.Container.Resolve<IMainPage>().ClickSignUpButton();

                //Phone confirmation
                TheUserCompleteSMSAuthentication(user);
                //TheUserSkipsProfileInfo();
                setUp.SetAirplaneMode();
                //TheUserCanCompleteLogin();
                TheUserCanSeeNoNetworkScreen();
            }
            catch (Exception e)
            {
                throw new Exception($"User {user} does not exist.", e);
            }
        }


        /// <summary>
        /// The user recovers Network and click in Try Again.
        /// </summary>
        [When(@"The user recovers Network and click in Try Again")]
        public void TheUserTriesToLoginWithTheFollowingUser()
        {
            setUp.SetDataOnlyMode();
            AppContainer.Container.Resolve<IBloodResultsPage>().ClickTryConnectionAgain();
        }



        /// <summary>
        /// The user tries to login with the following user.
        /// </summary>
        /// <param name="table">The table.</param>
        [When(@"The user tries to login with the following user")]
        public void TheUserTriesToLoginWithTheFollowingUser(Table table)
        {
            var user = table.CreateInstance<UserLogin>();
            //loginPage.LoginUser(user);
        }



        /// <summary>
        /// The user can see the No connection to network message.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can see the No connection to network message")]
        public void TheUserCanSeeNoNetworkScreen()
        {
            //TO DO
            AppContainer.Container.Resolve<IBloodResultsPage>().IsAtNoNetworkScreen().Should().BeTrue();
        }

        /// <summary>
        /// The user can logout from the application.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can logout from the application")]
        public void TheUserCanLogout()
        {
            loginPage.IsAtEnterPhoneNumberPage();
        }

        /// <summary>
        /// The user can click the back button
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user click in back button on code confirmation screen")]
        public void TheUserClickBackButton()
        {
            loginPage.ClickOnBackButton();
        }

        /// <summary>
        /// The user can click the exit button
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user click in the exit button")]
        public void TheUserClickExitButton()
        {
            Console.WriteLine(setUp.GetCurrentActivityStatus());
            setUp.GetCurrentActivityStatus().Contains(".MainActivity").Should().BeTrue();
            loginPage.ClickOnExitButton();
        }

        /// <summary>
        /// The application is closed
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The application is closed")]
        public void TheApplicationIsClosed()
        {
            Console.WriteLine(setUp.GetCurrentActivityStatus());
            setUp.GetCurrentActivityStatus().Contains(".MainActivity").Should().BeFalse();
        }


        /// <summary>
        /// The user login for the 3rd time
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user '(.*)' login for the 3rd time")]
        public void TheUserLogin3rdTime(string user)
        {
            //1st Login
            TheUserCompleteSMSAuthentication(user);
            //TheUserSkipsProfileInfo();
            //TheUserSkipsLocationInfo();
            //TheUserCanCompleteLogin();
            AppContainer.Container.Resolve<IMenuDrawerPage>().OpenDrawerMenu();
            AppContainer.Container.Resolve<IMenuDrawerPage>().ClickLogout();

            //2nd Login
            TheUserClickInSendPhoneNumber();
            TheUserReceivesTheConfirmationCode(user);
            AppContainer.Container.Resolve<IMenuDrawerPage>().OpenDrawerMenu();
            AppContainer.Container.Resolve<IMenuDrawerPage>().ClickLogout();

            //3rd Login
            TheUserClickInSendPhoneNumber();
            var loginUser = this.GetLoginUser(user);
            loginPage.GetConfirmationCode(loginUser);
            loginPage.ClickSendConfirmationCode();
        }


        /// <summary>
        /// FailedLoginAttempts analytic is saved at Database
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"FailedLoginAttempts analytic is saved at Database")]
        public void FailedLoginAttemptsAnalyticIsSaved()
        {
            var result = analytics.GetAnalyticFailedLoginAttemptsFromDatabase();
            analytics.IsAnalyticFailedLoginAttemptsSaved(result);
        }
        

        #endregion


        /// <summary>
        /// Before the scenario BeforeScenarioWithUniqueLogin--- .
        /// </summary>
        [BeforeScenario("BeforeScenarioWithUniqueLogin")]
        public void BeforeScenarioWithLogin()
        {
            if (AppContainer.Container.Resolve<IBloodResultsPage>().IsAtBloodResultsPage() == false)
            {
                setUp.ResetApp();
                TheUSerLoginInIthembaApp("User49");
            }

            else
            {
                //setUp.ReopenApp();
            }
        }
    }
}