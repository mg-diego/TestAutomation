using System;
using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Quick Pick-up page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IQuickPickUpPage" />
    public class QuickPickUpPage : PageBase, IQuickPickUpPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Quick Pick-up') and (@index='1')]")]
        private IWebElement txtQuickPickUpTittle;

        [FindsBy(How = How.Id, Using = "userName")]
        private IWebElement txtUserName;

        [FindsBy(How = How.Id, Using = "lastResultValue")]
        private IWebElement txtLastResultValue;

        [FindsBy(How = How.Id, Using = "validUntil")]
        private IWebElement txtValidUntil;

        [FindsBy(How = How.Id, Using = "lastResultDate")]
        private IWebElement txtLastResultDate;

        [FindsBy(How = How.Id, Using = "lastResultDate")]
        private IList<IWebElement> txtLastResultDateList;

        [FindsBy(How = How.Id, Using = "ShowAllPastResults")]
        private IWebElement btnShowAllPastResults;


        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickPickUpPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public QuickPickUpPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at Quick Pick-up page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Quick Pick-up page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtQuickPickUpPage(UserLogin user)
        {
            this.WaitUntil(2);
            
            return txtQuickPickUpTittle.Displayed
                && Equals(txtLastResultDate.Text, user.latestTestDateQuickPickUp)
                && Equals(txtLastResultValue.Text, user.latestTestValueQuickPickUp);
        }

        /// <summary>
        /// Open the Show All Past Results
        /// </summary>
        public void ShowAllPastResults()
        {
            ClickElement(btnShowAllPastResults);
        }

        /// <summary>
        /// Determines whether [is Show All Past Results page is opened].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Show All Past Results page is opened]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsShowAllPastResultsOpened(UserLogin user)
        {
            this.WaitUntil(1);
            if (this.txtLastResultDateList.Count < 2)
            {
                Console.WriteLine(txtLastResultDateList[1].Text);
                Console.WriteLine(user.latestTestDateQuickPickUp);
                return false;
            }
            else
            {
                Console.WriteLine(txtLastResultDateList[1].Text);
                Console.WriteLine(user.latestTestDateQuickPickUp);

                return Equals(txtLastResultDateList[1].Text, user.latestTestDateQuickPickUp);
            }
            
        }
    }
}
