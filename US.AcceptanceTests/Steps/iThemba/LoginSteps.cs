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
        /// <param name="loginPage">The login page.</param>

        public LoginSteps(ISetUp setUp, ILoginPage loginPage, IAnalytics analytics)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.loginPage = loginPage;
            this.setUp = setUp;
            this.analytics = analytics;
        }

        #region .: Steps :.
        /// <summary>
        /// The user enters his phone number.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user '(.*)' enters his phone number")]
        [When(@"The user '(.*)' enters his phone number")]
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
            var result = analytics.GetAnalyticUserLoggedInFromDatabase(loginUser);
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
        /// The user receives the confirmation code (without Analytics)
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The new user '(.*)' receives the confirmation code")]
        public void TheNewUserReceivesTheConfirmationCode(string user)
        {
            var loginUser = this.GetLoginUser(user);
            loginPage.GetConfirmationCode(loginUser);
            loginPage.ClickSendConfirmationCode();
        }

        /// <summary>
        /// The user completes the SMS authentication process (without Analytics)
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The new user '(.*)' completes the SMS authentication process")]
        public void TheNewUserCompleteSMSAuthentication(string user)
        {
            TheUSerEnterHisPhoneNumber(user);
            TheUserClickInSendPhoneNumber();
            TheNewUserReceivesTheConfirmationCode(user);
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
        /// The user is at Enter SMS confirmation code
        /// </summary>
        /// <param name="user">The user.</param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user is at Enter SMS confirmation code")]
        public void TheUserIsAtEnterSMSCode()
        {
            loginPage.IsAtEnterSMSCodePage();
        }
        


        /// <summary>
        /// The user sets Profile info
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user sets it's profile info")]
        [When(@"The user sets it's profile info")]
        public void TheUserSetsProfileInfo()
        {
            loginPage.IsAtSetGenderAgeInfo();
            loginPage.SelectRandomGender();
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
			TheUserSetsCityLocation();

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
		/// The user sets Location info changing Neighbourhood
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[When(@"The user sets it's location info changing Neighbourhood")]
		public void TheUserSetsLocationInfoWithNeighbourhoodChange()
		{
			TheUserSetsCityLocation();
			TheUserSetsNeighbourhoodLocation("Yeoville");
			TheUserSetsNeighbourhoodLocation("Hillbrow");
			TheUserSetsClinicLocation();
			loginPage.ClickConfirmLocationInfo();
		}

		/// <summary>
		/// The user sets City info
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[When(@"The user selects a City")]
		public void TheUserSetsCityLocation()
		{
			//City
			loginPage.ClickInputCityInfo();
			loginPage.IsAtSetLocationInfoPopup().Should().BeTrue();
			loginPage.SelectRandomPopupOption();
		}

		/// <summary>
		/// The user sets Neighbourhood info
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[When(@"The user selects Neighbourhood '(.*)'")]
		public void TheUserSetsNeighbourhoodLocation(string location)
		{
			//Neighbourhood
			loginPage.ClickInputNeighbourhoodInfo();
			loginPage.IsAtSetLocationInfoPopup().Should().BeTrue();
			loginPage.SelectPopupOption(location);
		}

		/// <summary>
		/// The user sets Clinic info
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The user selects Clinic")]
		public void TheUserSetsClinicLocation()
		{
			//Clinic
			loginPage.ClickInputClinicInfo();
			loginPage.IsAtSetLocationInfoPopup().Should().BeTrue();
			loginPage.SelectRandomPopupOption();
		}

		/// <summary>
		/// The user sets Neighbourhood info
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The Neighbourhood '(.*)' is selected")]
		public void IsClinicSelected(string clinic)
		{
			loginPage.IsClinicInfoCorrect(clinic);
		}

		
		/// <summary>
		/// The user can complete the login
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The new user (.*) can complete the login")]
        public void TheUserCanCompleteLogin(string user)
        {
            var loginUser = this.GetLoginUser(user);
            loginPage.ClickGoToHomepage();

			var result = analytics.GetAnalyticUserBirthdayUpdatedFromDatabase();
            analytics.IsAnalyticUserBirthdayUpdatedSaved(result, loginUser);

			result = analytics.GetAnalyticUserGenderUpdatedFromDatabase();
			analytics.IsAnalyticUserGenderUpdatedSaved(result, loginUser);

			result = analytics.GetAnalyticUserLocationUpdatedFromDatabase();
			analytics.IsAnalyticUserLocationUpdatedSaved(result, loginUser);
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
            }
            catch (Exception e)
            {
                throw new Exception($"User {user} could not login.", e);
            }

            var result = analytics.GetAnalyticBarcodeDataRequestedFromDatabase(loginUser);
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
                AppContainer.Container.Resolve<INoConnectivityPage>().IsAtNoConnectivityPage();
            }
            catch (Exception e)
            {
                throw new Exception($"User {user} does not exist.", e);
            }
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
        /// The user can logout from the application.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can logout from the application")]
        [Then(@"The user is at enter Phone Number page")]
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