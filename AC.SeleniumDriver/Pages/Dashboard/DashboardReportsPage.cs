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
    /// The Dashboard Reports page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IDashboardReportsPage" />
    public class DashboardReportsPage : PageBase, IDashboardReportsPage
    {

        #region .: Selenium Elements:.
        [FindsBy(How = How.XPath, Using = "//*[@id'mat-radio-3']/label/div[2]")]
        private IWebElement btnDeviceCAPCTM;

        [FindsBy(How = How.Id, Using = "mat-radio-23")]
        private IWebElement btnDeviceCobas6800_8800;

        [FindsBy(How = How.Id, Using = "mat-radio-24")]
        private IWebElement btnDeviceCobas4800;

        [FindsBy(How = How.ClassName, Using = "mat-button-wrapper")]
        private IWebElement btnNextDevices;
        #endregion



        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardReportsPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public DashboardReportsPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at reports page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at reports page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtReportsPage()
        {
            return IsElementEnabled(btnNextDevices);
        }

        /// <summary>
        /// Click in device CAPCTM.
        /// </summary>
        public void ClickDeviceCAPCTM()
        {
            ClickElement(btnDeviceCAPCTM);
        }

        /// <summary>
        /// Click in device Cobas6800_8800.
        /// </summary>
        public void ClickDeviceCobas6800_8800()
        {
            ClickElement(btnDeviceCobas6800_8800);
        }

        /// <summary>
        /// Click in device Cobas4800.
        /// </summary>
        public void ClickDeviceCobas4800()
        {
            ClickElement(btnDeviceCobas4800);
        }
    }
}
