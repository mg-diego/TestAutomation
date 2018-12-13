using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Configuration;
using FluentAssertions;
using TechTalk.SpecFlow;


namespace US.AcceptanceTests.Steps.BloodResults
{
    /// <summary>
    /// The My Blood Results steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class BloodResultsSteps : StepBase
    {
        private readonly IBloodResultsPage bloodResultsPage;
        private readonly ISetUp setUp;
        private readonly IAnalytics analytics;

        /// <summary>
        /// Initializes a new instance of the <see cref="BloodResultsSteps" /> class.
        /// </summary>
        /// <param name="bloodResultsPage">The blood results page.</param>
        public BloodResultsSteps(IBloodResultsPage bloodResultsPage, ISetUp setUp, IAnalytics analytics)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.bloodResultsPage = bloodResultsPage;
            this.setUp = setUp;
            this.analytics = analytics;
        }

        /// <summary>
        /// The user clicks in Go To Community.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user clicks in Go to Community")]
        [When(@"The user clicks in Go to Community")]
        public void TheUserClickGoToCommunity()
        {
            bloodResultsPage.ClickGoToCommunity();
        }


        /// <summary>
        /// The user clicks in Go To Scanner.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in Go to Scanner")]
        public void TheUserClickGoToScanner()
        {
            bloodResultsPage.ClickGoToScanner();
        }


        /// <summary>
        /// The user opens the Past Results menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the Past Results menu option")]
        [When(@"The user opens the Past Results menu option")]
        public void TheUserOpenPastResults()
        {
            bloodResultsPage.ClickGoToPastResults();
        }

        /// <summary>
        /// The user closes the Past Results menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user closes the Past Results menu option")]
        public void TheUserClosePastResults()
        {
            bloodResultsPage.ClickExitPastResults();
        }


        /// <summary>
        /// The Blood Results is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Blood Results is opened")]
        [Then(@"The user can login to the application")]
        [Then(@"The My Profile information is saved")]
        public void TheBloodResultsIsOpened()
        {
            this.bloodResultsPage.IsAtBloodResultsPage().Should().BeTrue();
        }

        /// <summary>
        /// The Scan the first Barcode page is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Scan the first Barcode page is opened")]
        public void TheScanFirstBarcodeIsOpened()
        {
           this.bloodResultsPage.IsAtScanFirstBarcodePage();
        }


        /// <summary>
        /// The Scan the first Barcode page is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The '(.*)' Blood Results page is opened")]
        [When(@"The '(.*)' Blood Results page is opened")]
        [Then(@"The '(.*)' Blood Results page is opened")]
        public void TheUserBloodResultsIsOpened(string user)
        {

            var userLogin = this.GetLoginUser(user);

            var result = analytics.GetAnalyticBarcodeDataRequestedFromDatabase(userLogin);
            analytics.IsAnalyticBarcodeDataRequestedSaved(result, userLogin);

            switch (user)
            {
                case "ResultsOnTheWay":
                    this.bloodResultsPage.IsAtResultsOnTheWayPage(userLogin);
                    break;
                case "User49":
                    this.bloodResultsPage.IsAtLessThan50ResultsPage(userLogin);
                    break;
                case "User50":
                    this.bloodResultsPage.IsAt50_1000ResultsPage(userLogin);
                    break;
                case "User1000":
                    this.bloodResultsPage.IsAt50_1000ResultsPage(userLogin);
                    break;
                case "User1001":
                    this.bloodResultsPage.IsAtMoreThan1000ResultsPage(userLogin);
                    break;
                case "UserWithMultipleImportResults":
                    this.bloodResultsPage.IsAtLessThan50ResultsPage(userLogin);
                    break;
                case "UserWithSingleInvalidResults":
                    this.bloodResultsPage.IsAtUniqueInvalidBloodResultsPage(userLogin);
                    break;
                case "UserWithMultipleInvalidResults":
                    this.bloodResultsPage.IsAtMultipleInvalidBloodResultsPage(userLogin);
                    break;
                default:
                    throw new InvalidOperationException("Unknown user '"+user+"'.");
            }
        }

        /// <summary>
        /// The user clicks on Android native BACK button
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user clicks on Android back button")]
        [When(@"The user clicks on Android back button")]
        public void TheUserClicksAndroidBackButton()
        {
            setUp.ClickAndroidBack();
        }

        /// <summary>
        /// The user clicks on NO button from pop up window
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in NO button from Exit pop up message")]
        public void TheUserClicksNoButtonFromExitWindow()
        {
            var isPopUpMessageDisplayed = this.bloodResultsPage.IsExitMessageDisplayed();
            isPopUpMessageDisplayed.Should().BeTrue();
            bloodResultsPage.ClickNoButtonFromExitMenu();
        }

        /// <summary>
        /// The user clicks on YES, EXIT button from pop up window
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in YES, EXIT button")]
        public void TheUserClicksYesExitButton()
        {
            var isPopUpMessageDisplayed = this.bloodResultsPage.IsExitMessageDisplayed();
            isPopUpMessageDisplayed.Should().BeTrue();
            bloodResultsPage.ClickYesExit();
        }


        /// <summary>
        /// The Results on the way banner appears.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Results on the way banner appears")]
        public void TheResultsOnTheWayBannerAppears()
        {
            bloodResultsPage.IsResultsOnTheWayBannerVisible().Should().BeTrue();
        }

        /// <summary>
        /// The user closes the Results on the Way banner.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user closes the Results on the Way banner")]
        public void TheUserCloseBannerResultsOnTheWay()
        {
            bloodResultsPage.ClickCloseBannerResultsOnTheWay();
        }

        /// <summary>
        /// The Results on the way banner doesn't appear.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Results on the way banner doesn't appear")]
        public void TheResultsOnTheWayBannerDoesNotAppear()
        {
            bloodResultsPage.IsResultsOnTheWayBannerVisible().Should().BeFalse();
        }


        /// <summary>
        /// The user '(.*)' Past Results page is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user '(.*)' Past Results page is opened")]
        public void TheUserPastResultsPageIsOpened(string user)
        {
            var userLogin = this.GetLoginUser(user);

            switch (user)
            {
                case "UserWithMultipleInvalidResults":
                    bloodResultsPage.IsAtPastResultsWithInvalidResults();
                    break;
                case "UserWithMultipleImportResults":
                    bloodResultsPage.IsAtPastResultsWithImportedResults();
                    break;
				case "ResultsOnTheWayMultiple":
					bloodResultsPage.IsAtPastResultsWithInvalidResults();
					break;

				default:
                    bloodResultsPage.IsAtPastResults();
                    break;
            }


            bloodResultsPage.IsAtPastResults();
            bloodResultsPage.AreHorizontalPastResultsDatesOk(userLogin);
            bloodResultsPage.AreVerticalPastResultsDatesOk(userLogin);
            bloodResultsPage.ArePastResultsValuesOk(userLogin);
        }

        /// <summary>
        /// The user clicks in Show Barcode.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in Show Barcode")]
        [Then(@"The user clicks in Show Barcode")]
        public void TheUserClickShowBarcode()
        {
            bloodResultsPage.ClickShowBarcode();
        }

        /// <summary>
        /// The user clicks in Close Barcode.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in Close Barcode")]
        [Then(@"The user clicks in Close Barcode")]
        public void TheUserCloseShowBarcode()
        {
            bloodResultsPage.ClickCloseBarcode();
        }
        

        /// <summary>
        /// The user '(.*)' barcode is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user '(.*)' barcode is opened")]
        public void TheUserBarcodeIsOpened(string user)
        {
            var userLogin = this.GetLoginUser(user);
            bloodResultsPage.IsAtBarcodeView(userLogin);
        }


    }
}
