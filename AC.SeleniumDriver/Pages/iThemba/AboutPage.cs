using System;
using AC.Contracts;
using AC.Contracts.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Settings page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IAboutPage" />

    public class AboutPage : PageBase, IAboutPage
    {
        #region .: Android Elements :. 

        [FindsBy(How = How.XPath, Using = "//*[(@text='About iThemba') and (@index='1')]")]
        private IWebElement txtAboutIThembaTittle { get; set; }

        [FindsBy(How = How.Id, Using = "contactEmail")]
        private IWebElement txtContactEmail { get; set; }

        [FindsBy(How = How.Id, Using = "contactPhone")]
        private IWebElement txtContactPhone { get; set; }

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="AboutPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public AboutPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at About info page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at About info page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtAboutIThembaPage()
        {
            WaitUntilElementIsVisible(txtAboutIThembaTittle);
            return txtAboutIThembaTittle.Displayed;
        }

        /// <summary>
        /// Determines whether [is Contact EMail correct]
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Contact EMail correct]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsContactMailCorrect()
        {
            return Equals(txtContactEmail.Text,"ithemba-info@ithemba.com");
        }

        /// <summary>
        /// Determines whether [is Contact Phone correct]
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Contact Phone correct]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsContactPhoneCorrect()
        {
            return Equals(txtContactPhone.Text, "+34645114076");
        }
    }
}
