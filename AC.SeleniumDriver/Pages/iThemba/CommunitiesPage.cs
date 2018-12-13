using System;
using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Chat with Communities page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ICommunitiesPage" />
    public class CommunitiesPage : PageBase, ICommunitiesPage
    {
        #region .: Android Elements :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Community Chats') and (@index='1')]")]
        [CacheLookup]
        private IWebElement txtCommunitiesTittle;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Heterosexual adult men)]")]
        private IWebElement txtWhatsappGroup1;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Young mothers)]")]
        private IWebElement txtWhatsappGroup2;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Family matters)]")]
        private IWebElement txtWhatsappGroup3;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Medication side effects)]")]
        private IWebElement txtWhatsappGroup4;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Pregnancy)]")]
        private IWebElement txtWhatsappGroup5;

        [FindsBy(How = How.XPath, Using = "//*[(@text='LGTB youth support)]")]
        private IWebElement txtWhatsappGroup6;

        [FindsBy(How = How.Id, Using = "JoinWhatsappGroup")]
        private IList<IWebElement> btnJoinGroup;       

        [FindsBy(How = How.Id, Using = "com.whatsapp:id/invite_accept")]
        private IWebElement whatsAppChatList;
        #endregion

        private Random rnd = new Random();
        public static int selectedGroup = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunitiesPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public CommunitiesPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at Chat with Communities page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Chat with Communities page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtCommunitiesPage()
        {
            WaitUntilElementIsVisible(txtCommunitiesTittle);
            return txtCommunitiesTittle.Displayed;
        }

        /// <summary>
        /// Join a random Whatsapp Chat Community.
        /// </summary>
        public void JoinRandomCommunity()
        {
            selectedGroup = rnd.Next(0, (btnJoinGroup.Count) - 1);
            ClickElement(btnJoinGroup[selectedGroup]);
        }


        /// <summary>
        /// Determines whether WhatsApp is launched.
        /// </summary>
        /// <returns>
        /// <c>true</c> if [iWhatsApp app is launched]; otherwise, <c>false</c>.
        /// </returns>
        public bool CheckWhatsappIsLaunched()
        {
            WaitUntilElementIsVisible(whatsAppChatList);
            return whatsAppChatList.Displayed;
        }
    }
}
