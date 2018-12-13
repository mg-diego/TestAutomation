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
    /// The Result Release menu page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IMenuPage" />
    public class MenuPage : PageBase, IMenuPage
    {
        #region .: Selenium Elements :.

        [FindsBy(How = How.Id, Using = "btnLogout")]
        private IWebElement btnLogout;

        [FindsBy(How = How.Id, Using = "btnUnreleasedResult")]
        private IWebElement btnUnreleasedResult;

        [FindsBy(How = How.Id, Using = "SearchBarcode")]
        private IWebElement btnSearchBarcode;
        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public MenuPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        /// <summary>
        /// Opens Unreleased Results.
        /// </summary>
        public void OpenUnreleasedResults()
        {
            ClickElement(btnUnreleasedResult);
        }

        /// <summary>
        /// Opens Unreleased Results.
        /// </summary>
        public void OpenSearchBarcode()
        {
            ClickElement(btnSearchBarcode);
        }

        /// <summary>
        /// Opens Unreleased Results.
        /// </summary>
        public void ClickLogout()
        {
            ClickElement(btnLogout);
        }
    }
}
