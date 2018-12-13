using AC.Contracts;
using AC.Contracts.Pages;
using NUnit.Framework;
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

        [FindsBy(How = How.XPath, Using = "//*[(@text='Help & About iThemba') and (@index='1')]")]
        private IWebElement txtAboutIThembaTittle { get; set; }

		//Help
		[FindsBy(How = How.Id, Using = "txtTitleHelp")]
		private IWebElement txtTitleHelp { get; set; }

		[FindsBy(How = How.Id, Using = "txtHelpDescription")]
		private IWebElement txtHelpDescription { get; set; }

		[FindsBy(How = How.Id, Using = "LabelPhoneNumberHelp")]
		private IWebElement txtPhoneNumberHelp { get; set; }

		[FindsBy(How = How.Id, Using = "btnWhatsappLink")]
		private IWebElement btnWhatsappLink { get; set; }


		//ChangeNumber
		[FindsBy(How = How.Id, Using = "txtTitleChangeNumber")]
		private IWebElement txtTitleChangeNumber { get; set; }

		[FindsBy(How = How.Id, Using = "txtChangeNumber1")]
		private IWebElement txtChangeNumber1 { get; set; }

		[FindsBy(How = How.Id, Using = "LabelChangeNumber")]
		private IWebElement txtPhoneNumberChange { get; set; }

		[FindsBy(How = How.Id, Using = "txtChangeNumber2")]
		private IWebElement txtChangeNumber2 { get; set; }


		//Privacy Policy
		[FindsBy(How = How.Id, Using = "txtTitlePrivacy")]
		private IWebElement txtTitlePrivacy { get; set; }

		[FindsBy(How = How.Id, Using = "txtPrivacy")]
		private IWebElement txtPrivacy { get; set; }


		//Question
		[FindsBy(How = How.Id, Using = "txtTitleQuestion")]
		private IWebElement txtTitleQuestion { get; set; }


		//User provided
		[FindsBy(How = How.Id, Using = "txtTitleUserProvided")]
		private IWebElement txtTitleUserProvided { get; set; }

		[FindsBy(How = How.Id, Using = "txtUserProvided")]
		private IWebElement txtUserProvided { get; set; }


		//My Rights
		[FindsBy(How = How.Id, Using = "txtTitleMyRights")]
		private IWebElement txtTitleMyRights { get; set; }

		[FindsBy(How = How.Id, Using = "txtMyRights")]
		private IWebElement txtMyRights { get; set; }


		//Data Retention
		[FindsBy(How = How.Id, Using = "txtTitleDataRetention")]
		private IWebElement txtTitleDataRetention { get; set; }

		[FindsBy(How = How.Id, Using = "txtDataRetention")]
		private IWebElement txtDataRetention { get; set; }


		//Your Consent
		[FindsBy(How = How.Id, Using = "txtTitleYourConsent")]
		private IWebElement txtTitleYourConsent { get; set; }

		[FindsBy(How = How.Id, Using = "txtYourConsent")]
		private IWebElement txtYourConsent { get; set; }


		//Contact us
		[FindsBy(How = How.Id, Using = "txtTitleContactUs")]
		private IWebElement txtTitleContactUs { get; set; }

		[FindsBy(How = How.Id, Using = "txtContactUs1")]
		private IWebElement txtContactUs1 { get; set; }

		[FindsBy(How = How.Id, Using = "LabelContactUs")]
		private IWebElement txtPhoneNumberContactUs { get; set; }

		[FindsBy(How = How.Id, Using = "txtContactUs2")]
		private IWebElement txtContactUs2 { get; set; }

		#endregion

		#region .: Expected Content :.

		private string txtPhoneNumberYeoville = "+27 65 569 9435";
		private string txtPhoneNumberHillbrow = "+27 78 762 1334";

		private string txtTitleHelpExpected = "Help";
		private string txtHelpDescriptionExpected = "For any questions regarding the study, the iThemba app, or your medical care, contact a study counselor through the WhatsApp link or phone number below:";

		private string txtTitleChangeNumberExpected = "If you change your number during the study:";
		private string txtChangeNumber1Expected = "send an SMS with the text “call-me” to:";
		private string txtChangeNumber2Expected = "We will then contact you to get your new phone number.";

		private string txtPrivacyExpected = "This privacy notice governs your use of the software application iThemba (“Application”) for " +
			"mobile devices that was created by Roche Molecular Systems, Inc. (“Roche”).  The iThemba" +
			"application is only being used as part of the Clinical Study.The Application is for research only, and it provides your HIV" +
			"viral load result to you directly on your mobile phone.You will also be given the opportunity to participate in specific WhatsApp" +
			"community groups which will enable you to communicate with others with HIV and an HIV counsellor." +
			"The use of Application is consistent with Roche privacy policy:" +
			"https://www.roche.com/privacy_policy.htm";

		private string txtContactUs1Expected = "Please first reach out to the Study Investigator and/or the Clinical Study team for any questions. " +
			"The​ 24-hour telephone number to discuss concerns about the Clinical Study is:";

		private string txtContactUs2Expected = "If you have any questions outside of this Clinical Study, such as questions regarding Roche’s " +
			"privacy practices, please reach out to diaprivacy.notice@roche.com.";

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
		/// Click in Whatsapp Link button
		/// </summary>
		public void ClickWhatsappLinkButton()
		{
			ClickElement(btnWhatsappLink);
		}

		/// <summary>
		/// Click in Phone Contact button
		/// </summary>
		public void ClickContactPhoneNumberButton()
		{
			ClickElement(txtPhoneNumberHelp);
		}

		/// <summary>
		/// Determines whether [is yeoville phone number correct]
		/// </summary>
		public void IsPhoneNumberCorrectYeoville()
        {
			Assert.That(txtPhoneNumberHelp.Text.Substring(txtPhoneNumberHelp.Text.Length - (txtPhoneNumberYeoville.Length), txtPhoneNumberYeoville.Length), Is.EqualTo(txtPhoneNumberYeoville));
		}

		/// <summary>
		/// Determines whether [is hillbrow phone number correct]
		/// </summary>
		public void IsPhoneNumberCorrectHillbrow()
		{
			Assert.That(txtPhoneNumberHelp.Text.Substring(txtPhoneNumberHelp.Text.Length - (txtPhoneNumberHillbrow.Length), txtPhoneNumberHillbrow.Length), Is.EqualTo(txtPhoneNumberHillbrow));
		}
	}
}
