using System.Diagnostics.CodeAnalysis;
using AC.Contracts.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;


namespace US.AcceptanceTests.Steps.MenuDrawer
{
    /// <summary>
    /// The menu drawer steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class MenuDrawerSteps : StepBase
    {
        private readonly IMenuDrawerPage menuDrawerPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuDrawerSteps" /> class.
        /// </summary>
        /// <param name="menuDrawerPage">The menu drawer.</param>
        public MenuDrawerSteps(IMenuDrawerPage menuDrawerPage)
        {
            this.menuDrawerPage = menuDrawerPage;
        }

        /// <summary>
        /// The user opens the iThemba app menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the iThemba app menu")]
        [When(@"The user opens the iThemba app menu")]
        public void TheUserOpensTheMenu()
        {
            menuDrawerPage.OpenDrawerMenu();
        }

        /// <summary>
        /// The user opens the Blood Results menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the Blood Results menu option")]
        [When(@"The user opens the Blood Results menu option")]
        public void TheUserOpensTheBloodResultsMenuOption()
        {
            menuDrawerPage.OpenBloodResults();
        }

        /// <summary>
        /// The user opens Barcode Scan menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens Barcode Scan menu option")]
        [When(@"The user opens Barcode Scan menu option")]
        public void TheUserOpensTheScanBarcodeMenuOption()
        {
            menuDrawerPage.OpenScanBarcode();
        }

        /// <summary>
        /// The user opens the Community Chats menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the Community Chats menu option")]
        [When(@"The user opens the Community Chats menu option")]
        public void TheUserOpensTheChatWithCommunitiesMenuOption()
        {
            menuDrawerPage.OpenChatWithCommunities();
        }

        /// <summary>
        /// The user opens the Quick Pick-up menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the Quick Pick-up menu option")]
        [When(@"The user opens the Quick Pick-up menu option")]
        public void TheUserOpensTheVipClinicPassMenuOption()
        {
            menuDrawerPage.OpenVipClinicPass();
        }

        /// <summary>
        /// The user opens the My Profile menu option.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the My Profile menu option")]
        [When(@"The user opens the My Profile menu option")]
        public void TheUserOpensTheMyProfileMenuOption()
        {
            menuDrawerPage.OpenMyProfile();
        }

        /// <summary>
        /// The user clicks in About iThemba menu option
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens the About iThemba menu option")]
        [When(@"The user opens the About iThemba menu option")]
        public void TheUserClicksAboutIthembaButton()
        {
            menuDrawerPage.ClickAboutIthemba();
        }

        /// <summary>
        /// The user clicks in Logout button.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks the Logout menu option")]
        public void TheUserClicksLogoutButton()
        {
            menuDrawerPage.ClickLogout();
        }


        /// <summary>
        /// The Vip Clinic Pass is visible.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Quick Pick-up menu is visible")]
        public void TheVipClinicPassIsVisible()
        {
            this.menuDrawerPage.IsVipClinicPassVisible().Should().BeTrue();
        }

        
        /// <summary>
        /// The Vip Clinic Pass is not visible.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Quick Pick-up menu is not visible")]
        public void TheVipClinicPassIsNotVisible()
        {
            this.menuDrawerPage.IsVipClinicPassNotVisible().Should().BeTrue();
        }
    }
}
