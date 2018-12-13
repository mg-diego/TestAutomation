using AC.Contracts;
using AC.Contracts.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The No Connectivity page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.INoConnectivityPage" />
    public class NoConnectivityPage : PageBase, INoConnectivityPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.Id, Using = "noConnectionTittle")]
        private IWebElement txtNoConnectionTittle { get; set; }

        [FindsBy(How = How.Id, Using = "noConnectionDescription")]
        private IWebElement txtNoConnectionDescription { get; set; }

        [FindsBy(How = How.Id, Using = "noWifiIcon")]
        private IWebElement iconNoWifi { get; set; }

        [FindsBy(How = How.Id, Using = "RetryConection")]
        private IWebElement btnRetryConnection { get; set; }

        #endregion


        #region .: Expected Content :.

        private string expectedNoConnectionTittle = "No connection to network";
        private string expectedNoConnectionDescription = "This feature requires connection to network. Check your Wi-Fi connection on your phone and try again.";

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NoConnectivityPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public NoConnectivityPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Click Try Again button
        /// </summary>
        public void ClickTryConnectionAgain()
        {
            ClickElement(btnRetryConnection);
        }

        /// <summary>
        /// Determines whether [is at no connectivity page].
        /// </summary>
        public void IsAtNoConnectivityPage()
        {
            Assert.Multiple(() =>
            {
                Assert.That(txtNoConnectionTittle.Text, Is.EqualTo(expectedNoConnectionTittle), "txtNoConnectionTittle is not correct");
                Assert.That(txtNoConnectionDescription.Text, Is.EqualTo(expectedNoConnectionDescription), "txtNoConnectionDescription is not correct");
                Assert.That(iconNoWifi.Displayed, Is.EqualTo(true), "iconNoWifi is not displayed");
                Assert.That(IsElementEnabled(btnRetryConnection), Is.EqualTo(true), "btnRetryConnection is not enabled");
            });
        }
    }
}
