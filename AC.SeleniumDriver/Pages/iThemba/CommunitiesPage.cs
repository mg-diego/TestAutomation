using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using NUnit.Framework;
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
        private IWebElement txtCommunitiesTittle;

        [FindsBy(How = How.Id, Using = "whatsappIcon")]
        private IWebElement whatsappIcon;

        [FindsBy(How = How.Id, Using = "poweredByWhatsIcon")]
        private IWebElement poweredByWhatsIcon;

        [FindsBy(How = How.Id, Using = "whatsappBottomReminder")]
        private IWebElement whatsappBottomReminder;

        [FindsBy(How = How.Id, Using = "groupIcon")]
        private IList<IWebElement> groupIconList;

        [FindsBy(How = How.Id, Using = "groupName")]
        private IList<IWebElement> groupNameList;

        [FindsBy(How = How.Id, Using = "groupDescription")]
        private IList<IWebElement> groupDescriptionList;

        [FindsBy(How = How.Id, Using = "JoinWhatsappGroup")]
        private IList<IWebElement> btnJoinGroupList;       

        [FindsBy(How = How.Id, Using = "com.whatsapp:id/invite_accept")]
        private IWebElement whatsAppChatList;

		[FindsBy(How = How.Id, Using = "android:id/message")]
		private IWebElement disclaimerMessage;

		[FindsBy(How = How.Id, Using = "android:id/button1")]
		private IWebElement btnAcceptPopup;

		[FindsBy(How = How.Id, Using = "android:id/button2")]
		private IWebElement btnCancelPopup;
		#endregion

		#region .: Expected Content :.

		private string friendsOfIthembaDescriptionExpected = "Counselors and other iThemba users are here to ask and answer questions.";
        private string genderTalkLocationDescriptionExpected = "Discussion group for GENDER and counselors.";

        private string whatsappBottomReminderExpected = "When you join a WhatsApp group you are disclosing your HIV status to others in that WhatsApp group.  Please be aware that other personal information might also be exposed by using WhatsApp, including your photo and phone number.";
       
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
        public void IsAtCommunitiesPage()
        {
            int groupsPerPage = 2;

            Assert.Multiple(() =>
            { 
                Assert.That(whatsappIcon.Displayed, Is.EqualTo(true), "whatsappIcon is not displayed");
                Assert.That(poweredByWhatsIcon.Displayed, Is.EqualTo(true), "poweredByWhatsIcon is not displayed");
                Assert.That(groupIconList.Count, Is.EqualTo(groupsPerPage), "groupIcon count is not " + groupsPerPage.ToString());
                Assert.That(groupNameList.Count, Is.EqualTo(groupsPerPage), "groupName count is not " + groupsPerPage.ToString());
                Assert.That(groupDescriptionList.Count, Is.EqualTo(groupsPerPage), "groupDescription count is not " + groupsPerPage.ToString());
                Assert.That(btnJoinGroupList.Count, Is.EqualTo(groupsPerPage), "btnJoinGroup count is not " + groupsPerPage.ToString());
                //Assert.That(whatsappBottomReminder.Text, Is.EqualTo(whatsappBottomReminderExpected), "whatsappBottomReminder text is not correct");
            });
        }

        /// <summary>
        /// Join a random Whatsapp Chat Community.
        /// </summary>
        public void JoinRandomCommunity()
        {
            selectedGroup = rnd.Next(0, (btnJoinGroupList.Count) - 1);
            ClickElement(btnJoinGroupList[selectedGroup]);
			ClickElement(btnAcceptPopup);
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

        /// <summary>
        /// Determines whether WhatsApp groups are correct.
        /// </summary>
        /// <returns>
        public void AreWhatsappGroupsCorrect(UserLogin userLogin, string gender, string location)
        {
            //GroupNames and GroupDescriptions
            string expectedGroupName0 = "Friends of iThemba " + location;
            string expectedGroupName1 = " Talk " + location;
            string pattern = @"\bGENDER\b";

            switch (gender)
            {
                case ("Male"):
                    expectedGroupName1 = "Men" + expectedGroupName1;
                    genderTalkLocationDescriptionExpected = Regex.Replace(genderTalkLocationDescriptionExpected, pattern, "men");

                    break;

                case ("Female"):
                    expectedGroupName1 = "Women" + expectedGroupName1;
                    genderTalkLocationDescriptionExpected = Regex.Replace(genderTalkLocationDescriptionExpected, pattern, "women");
                    break;
            }

            Assert.Multiple(() =>
            {
                Assert.That(groupNameList[0].Text, Contains.Substring(expectedGroupName0), "groupName 0 is not correct");
                Assert.That(groupNameList[1].Text, Contains.Substring(expectedGroupName1), "groupName 1 is not correct");

                Assert.That(groupDescriptionList[0].Text, Is.EqualTo(friendsOfIthembaDescriptionExpected), "groupDescription 0 is not correct");
                Assert.That(groupDescriptionList[1].Text, Is.EqualTo(genderTalkLocationDescriptionExpected), "groupDescription 0 is not correct");
            });

        }
    }
}
