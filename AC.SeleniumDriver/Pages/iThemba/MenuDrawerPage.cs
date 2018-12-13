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
    /// The menu drawer page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IMenuDrawerPage" />
    public class MenuDrawerPage : PageBase, IMenuDrawerPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.Id, Using = "OK")]
        public IWebElement btnOpenMenuDrawer { get; set; }

        [FindsBy(How = How.Id, Using = "GoBack")]
        public IWebElement btnCloseMenuDrawer { get; set; }

        [FindsBy(How = How.Id, Using = "menuInfo")]
        public IWebElement btnMenuInfo { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Blood results') and (@index='0')]")]
        private IWebElement btnBloodResults;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Barcode Scanner') and (@index='0')]")]
        private IWebElement btnScanBarcode;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Community Chats') and (@index='0')]")]
        private IWebElement btnChatWithCommunities;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Quick Pick-up') and (@index='0')]")]
        private IWebElement btnVipClinicPass;

        //Used to check that "Quick Pick-up pass" is not visible using FindElements() method
        [FindsBy(How = How.XPath, Using = "//*[(@text='Quick Pick-up') and (@index='0')]")]
        private IList<IWebElement> btnVipClinicPassList;

        [FindsBy(How = How.Id, Using = "AboutIthemba")]
        public IWebElement btnAboutIthemba { get; set; }

        [FindsBy(How = How.Id, Using = "MyProfile")]
        public IWebElement btnMyProfile { get; set; }

        [FindsBy(How = How.Id, Using = "Logout")]
        public IWebElement btnLogout { get; set; }   

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuDrawerPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public MenuDrawerPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        #region .: Menu Methods :.

        /// <summary>
        /// Opens the Drawer Menu.
        /// </summary>
        public void OpenDrawerMenu()
        {
           ClickElement(btnOpenMenuDrawer);
        }

        /// <summary>
        /// Opens the Blood Results Menu.
        /// </summary>
        public void OpenBloodResults()
        {
            ClickElement(btnBloodResults);            
        }

        /// <summary>
        /// Opens Scan Bar Code Menu.
        /// </summary>
        public void OpenScanBarcode()
        {
            ClickElement(btnScanBarcode);
        }

        /// <summary>
        /// Opens Chat with communities Menu.
        /// </summary>
        public void OpenChatWithCommunities()
        {
            ClickElement(btnChatWithCommunities);
        }

        /// <summary>
        /// Opens Quick Pick-up Menu.
        /// </summary>
        public void OpenVipClinicPass()
        {
            ClickElement(btnVipClinicPass);
        }

        /// <summary>
        /// Opens My Profile Menu.
        /// </summary>
        public void OpenMyProfile()
        {
            ClickElement(btnMyProfile);
        }

        /// <summary>
        /// Open About iThemba Menu
        /// </summary>
        public void ClickAboutIthemba()
        {
            ClickElement(btnAboutIthemba);
        }

        /// <summary>
        /// Logout from the iThemba app
        /// </summary>
        public void ClickLogout()
        {
            ClickElement(btnLogout);
        }

        /// <summary>
        /// Determines whether [is at menu drawer page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at menu drawer page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtMenuDrawerPage()
        {
            this.WaitUntil(1);
            return btnBloodResults.Displayed;
        }


        /// <summary>
        /// Determines whether [is Quick Pick-up menu visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Quick Pick-up menu visible]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsVipClinicPassVisible()
        {
            this.WaitUntil(1);
            return  btnVipClinicPass.Displayed;
        }


        /// <summary>
        /// Determines whether [is Quick Pick-up menu not visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Quick Pick-up menu not visible]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsVipClinicPassNotVisible()
        {
            this.WaitUntil(1);
            if (btnVipClinicPassList.Count < 1)
            {
                return true;
            }
            else return false;
        }
        #endregion

    }
}
