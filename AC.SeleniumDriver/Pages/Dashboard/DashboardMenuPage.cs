using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Dashboard Menu page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IDashboardMenuPage" />
    public class DashboardMenuPage : PageBase, IDashboardMenuPage
    {

        [FindsBy(How = How.ClassName, Using = "header__title")]
        private IWebElement txtMenuTittle;

        [FindsBy(How = How.XPath, Using = "//*[(@class='header__logout mat-button mat-primary')]")]
        private IWebElement btnLogout;

        [FindsBy(How = How.XPath, Using = "//*[(@href='/reports')]")]
        private IWebElement btnReports;

        [FindsBy(How = How.XPath, Using = "//*[(@href='/playground')]")]
        private IWebElement btnPlayground;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardMenuPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public DashboardMenuPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        /// <summary>
        /// Click in Login button.
        /// </summary>
        public void ClickLogoutButton()
        {
            ClickElement(btnLogout);
        }

        /// <summary>
        /// Click in Reports button.
        /// </summary>
        public void ClickReportsButton()
        {
            ClickElement(btnReports);
        }

        /// <summary>
        /// Click in Playground button.
        /// </summary>
        public void ClickPlaygroundButton()
        {
            ClickElement(btnPlayground);
        }
    }
}
