using AC.Contracts;
using AC.Contracts.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages.Login
{
    /// <summary>
    /// The MainPage class.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IMainPage" />
    public class MainPage : PageBase, IMainPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Introduction to iThemba')]")]
        private IWebElement txtOnboardingHeader;

        [FindsBy(How = How.XPath, Using = "//*[(@text='With iThemba you can receive your results directly on your phone without picking it up in the clinic')]")]
        private IWebElement txtOnboardingTittle1;

        [FindsBy(How = How.XPath, Using = "//*[(@text='With iThemba you can scan the blood sample barcode to receive your results later')]")]
        private IWebElement txtOnboardingTittle2;

        [FindsBy(How = How.XPath, Using = "//*[(@text='With iThemba you can join community chats to share ideas and ask questions')]")]
        private IWebElement txtOnboardingTittle3;

        [FindsBy(How = How.XPath, Using = "//*[(@text='NEXT') and (@class='android.widget.Button')]")]
        private IWebElement btnNext { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='START iTHEMBA') and (@class='android.widget.Button')]")]
        private IWebElement btnSignUp { get; set; }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public MainPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at onboard page 1].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at onboard page 1]; otherwise, <c>false</c>.
        /// </returns>
        public void IsAtOnboardPage1()
        {
            WaitUntilElementIsVisible(btnNext);

            Assert.Multiple(() =>
            {
                Assert.That(btnNext.Text, Is.EqualTo("NEXT"), "Button btnNext has wrong text");
                Assert.That(txtOnboardingTittle1.Text, Is.EqualTo("With iThemba you can receive your results directly on your phone without picking it up in the clinic"), "Txt txtOnboardingTittle1 has wrong text");
                Assert.That(txtOnboardingHeader.Text, Is.EqualTo("Introduction to iThemba"), "Txt txtOnboardingHeader has wrong text");
            });

            return;
        }
        
        /// <summary>
        /// Determines whether [is at onboard page 2].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at onboard page 2]; otherwise, <c>false</c>.
        /// </returns>
        public void IsAtOnboardPage2()
        {
            WaitUntilElementIsVisible(btnNext);

            Assert.Multiple(() =>
            {
                Assert.That(btnNext.Text, Is.EqualTo("NEXT"), "Button btnNext has wrong text");
                Assert.That(txtOnboardingTittle2.Text, Is.EqualTo("With iThemba you can scan the blood sample barcode to receive your results later"), "Txt txtOnboardingTittle2 has wrong text");
                Assert.That(txtOnboardingHeader.Text, Is.EqualTo("Introduction to iThemba"), "Txt txtOnboardingHeader has wrong text");
            });
            return;
        }

        /// <summary>
        /// Determines whether [is at onboard page 3].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at onboard page 3]; otherwise, <c>false</c>.
        /// </returns>
        public void IsAtOnboardPage3()
        {
            WaitUntilElementIsVisible(btnSignUp);

            Assert.Multiple(() =>
            {
                Assert.That(btnSignUp.Text, Is.EqualTo("START iTHEMBA"), "Button btnSignUp has wrong text");
                Assert.That(txtOnboardingTittle3.Text, Is.EqualTo("With iThemba you can join community chats to share ideas and ask questions"), "Txt txtOnboardingTittle3 has wrong text");
                Assert.That(txtOnboardingHeader.Text, Is.EqualTo("Introduction to iThemba"), "Txt txtOnboardingHeader has wrong text");
            });
            return;
        }

        /// <summary>
        /// Click in next button.
        /// </summary>
        public void ClickNextButton()
        {
            ClickElement(btnNext);
        }

        /// <summary>
        /// Click in sign up button.
        /// </summary>
        public void ClickSignUpButton()
        {
            ClickElement(btnSignUp);
        }

    }
}
