using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AC.SeleniumDriver.Pages.Login
{
    /// <summary>
    /// The iThemba Login page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ILoginPage" />
    public class LoginPage : PageBase, ILoginPage
    {
        #region .: Android Elements :.

        #region .: 1st page :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Enter your phone number') and (@class='android.widget.TextView')]")]
        private IWebElement txtPhoneNumberTittle;

        [FindsBy(How = How.XPath, Using = "//*[(@text='Your name and data are safe and secure.') and (@class='android.widget.TextView')]")]
        private IWebElement txtPhoneNumberIsSecure;

        [FindsBy(How = How.Id, Using = "inputPrefix")]
        private IWebElement inputPrefix;

        [FindsBy(How = How.Id, Using = "inputPhoneNumber")]
        private IWebElement inputPhoneNumber;

        [FindsBy(How = How.Id, Using = "Send")]
        private IWebElement btnSendPhone { get; set; }

        [FindsBy(How = How.Id, Using = "Exit")]
        private IWebElement btnExit { get; set; }

        #endregion

        #region .: 2nd page :.

        [FindsBy(How = How.Id, Using = "inputConfirmationCode")]
        [CacheLookup]
        private IWebElement inputConfirmationCode;


        [FindsBy(How = How.Id, Using = "Confirm")]
        [CacheLookup]
        private IWebElement btnSendConfirmationCode { get; set; }

        [FindsBy(How = How.Id, Using = "sendCodeAgain")]
        [CacheLookup]
        private IWebElement btnSendCodeAgain;

        [FindsBy(How = How.Id, Using = "Back")]
        private IWebElement btnGoBack { get; set; }

        #endregion

        #region .: 3rd page :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Tell us your gender and age for better advice')]")]
        private IWebElement txtDemographicTittle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@instance='0') and (@class='android.widget.ImageView')]")]
        private IWebElement btnSelectMaleGender { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@instance='1') and (@class='android.widget.ImageView')]")]
        private IWebElement btnSelectFemaleGender { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@class='android.widget.SeekBar')]")]
        private IWebElement ageSelectorBar { get; set; }

        [FindsBy(How = How.Id, Using = "btnSkipProfile")]
        private IWebElement btnSkipGenderAge { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmProfile")]
        private IWebElement btnConfirmGenderAge { get; set; }

        #endregion

        #region .: 4th page :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Which clinic do you visit?')]")]
        private IWebElement txtMyProfileClinicLocationTittle { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/button2")]
        private IWebElement btnCancelPopup { get; set; }

        [FindsBy(How = How.Id, Using = "inputCity")]
        private IWebElement inputCity { get; set; }

        [FindsBy(How = How.Id, Using = "inputNeighbourhood")]
        private IWebElement inputNeighbourhood { get; set; }

        [FindsBy(How = How.Id, Using = "inputClinic")]
        private IWebElement inputClinic { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/text1")]
        private IList<IWebElement> txtPopupOptionsList { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmClinicLocation")]
        private IWebElement btnConfirmClinicLocation { get; set; }

        [FindsBy(How = How.Id, Using = "btnSkipClinicLocation")]
        private IWebElement btnSkipClinicLocation { get; set; }

        #endregion

        #region .: 5th page :.
        [FindsBy(How = How.Id, Using = "Start")]
        [CacheLookup]
        private IWebElement btnStartAfterLogin { get; set; }

        #endregion


        [FindsBy(How = How.Id, Using = "Apps")]
        private IWebElement btnAndroidApps { get; set; }

        #endregion .: Android Elements :.


        private static IWebDriver SeleniumDriver;
        private static IWebElement confirmationCode;
        private static IList<IWebElement> codeArrivedList;
        private Random random = new Random();
        public static int randomTimes = -1;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public LoginPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        #region .: 1 - Enter Phone Number :.

        /// <summary>
        /// Determines whether [is at enter phone number page].
        /// </summary>
        public void IsAtEnterPhoneNumberPage()
        {
            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(txtPhoneNumberTittle), Is.EqualTo(true), "txtPhoneNumberTittle is not displayed");
                Assert.That(IsElementEnabled(txtPhoneNumberIsSecure), Is.EqualTo(true), "txtPhoneNumberIsSecure is not displayed");
            });
        }

        /// <summary>
        /// Determines if the main android page is displayed by lookging for the Apps button
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Apps button is displayed]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtMainAndroidPage()
        {
            return IsElementEnabled(btnAndroidApps);
        }

        /// <summary>
        /// Enter the user phone number.
        /// </summary>
        public void EnterPhoneNumber(UserLogin user)
        {
            SendKeysElement(this.inputPhoneNumber, user.phoneNumber);
        }

        /// <summary>
        /// Check the default phone prefix.
        /// </summary>
        public bool CheckDefaultPhonePrefix()
        {
            return Equals(this.inputPrefix.Text, "+27");
        }

        /// <summary>
        /// Enter the user phone prefix.
        /// </summary>
        public void EnterPhonePrefix(UserLogin user)
        {
            SendKeysElement(this.inputPrefix, user.phonePrefix);
        }

        /// <summary>
        /// Clear existing phone prefix.
        /// </summary>
        public void ClearPhonePrefix()
        {
            ClearElement(this.inputPrefix);
        }

        /// <summary>
        /// Click in send phone number button.
        /// </summary>
        public void ClickSendPhoneNumber()
        {
            ClickElement(btnSendPhone);
        }

        /// <summary>
        /// Click in exit button.
        /// </summary>
        public void ClickOnExitButton()
        {
            ClickElement(btnExit);
        }

        #endregion

        #region .: 2 - Get SMS code :.

        /// <summary>
        /// Click in send code again button.
        /// </summary>
        public void ClickSendCodeAgain()
        {
            ClickElement(btnSendCodeAgain);
        }

        /// <summary>
        /// Click in go to back button.
        /// </summary>
        public void ClickOnBackButton()
        {
            ClickElement(btnGoBack);
        }

        /// <summary>
        /// Click in send confirmation code button.
        /// </summary>
        public void ClickSendConfirmationCode()
        {
            ClickElement(btnSendConfirmationCode);
        }

        /// <summary>
        /// Get the confirmation code.
        /// </summary>
        public void GetConfirmationCode(UserLogin user)
        {
            const string DriverPath = @"\binaries\";
            SeleniumDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + DriverPath);
            SeleniumDriver.Manage().Cookies.DeleteAllCookies();

            SeleniumDriver.Navigate().GoToUrl(user.emulationPhone);

            //Maximize browser window
            //SeleniumDriver.Manage().Window.Maximize();

            int secondsAgo = 999;

            //Wait until SMS arrives
            do
            {
                do
                {
                    SeleniumDriver.Navigate().Refresh();
                    codeArrivedList = SeleniumDriver.FindElements(By.XPath("//*[contains(text(), 'seconds ago')]"));
                }
                while (codeArrivedList.Count < 1);

                //Gets the two first characters from the last SMS received
                secondsAgo = Int32.Parse(codeArrivedList[0].Text.Substring(0, 2));
            }
            while (secondsAgo > 15);
            
            //Gets the SMS value
            confirmationCode = SeleniumDriver.FindElement(By.XPath("//*[contains(text(), 'The activation code is')]"));

            String index = "The activation code is ";
            Int32 codeLength = 6;
            String code = confirmationCode.Text;
            code = code.Substring(index.Length, codeLength);

            //Sends the Confirmation Code
            inputConfirmationCode.Clear();
            SendKeysElement(inputConfirmationCode, code);
            SeleniumDriver.Close();            
        }

        /// <summary>
        /// Input wrong SMS code at inputConfirmationCode
        /// </summary>
        public void InputWrongSMSCodeRandomTimes()
        {
            this.WaitUntil(2);
            SendKeysElement(inputConfirmationCode, "123");

            randomTimes = random.Next(0, 5);
            for (int i = 0; i < randomTimes; i++)
            {
                ClickSendConfirmationCode();
            }            
        }

        #endregion

        #region .: 3 - Set Gender / Age info :.

        /// <summary>
        /// Determines whether [is at set gender / age info].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at set gender / age info]; otherwise, <c>false</c>.
        /// </returns>
        public void IsAtSetGenderAgeInfo()
        {
            WaitUntilElementIsVisible(txtDemographicTittle);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(txtDemographicTittle), Is.EqualTo(true), "txtDemographicTittle is not displayed");
                Assert.That(IsElementEnabled(ageSelectorBar), Is.EqualTo(true), "ageSelectorBar is not displayed");
                Assert.That(IsElementEnabled(btnSkipGenderAge), Is.EqualTo(true), "btnSkipGenderAge is not enabled");
                //Assert.That(IsElementEnabled(btnConfirmGenderAge), Is.EqualTo(true), "btnConfirmGenderAge is not displayed");
            });
            return;
        }

        /// <summary>
        /// Click SKIP at Profile info.
        /// </summary>
        public void ClickSkipProfileInfo()
        {
            ClickElement(btnSkipGenderAge);
        }

        /// <summary>
        /// Click CONFIRM at Profile info.
        /// </summary>
        public void ClickConfirmProfileInfo()
        {
            ClickElement(btnConfirmGenderAge);
        }

        /// <summary>
        /// Select a random gender.
        /// </summary>
        public void SelectRandomGender()
        {
            int randomNumber = random.Next(0, 100);

            if (randomNumber <= 50)
            {
                btnSelectMaleGender.Click();
            }
            else
            {
                btnSelectFemaleGender.Click();
            }
        }


        /// <summary>
        /// Get Age selector total width.
        /// </summary>
        public int GetAgeSelectorTotalWidth()
        {
            this.WaitUntilElementIsVisible(ageSelectorBar);
            return ageSelectorBar.Size.Width;
        }

        /// <summary>
        /// Get Age selector X width.
        /// </summary>
        public int GetAgeSelectorWidthX()
        {
            this.WaitUntilElementIsVisible(ageSelectorBar);
            return ageSelectorBar.Location.X;
        }

        /// <summary>
        /// Get Age selector Y width.
        /// </summary>
        public int GetAgeSelectorWidthY()
        {
            this.WaitUntilElementIsVisible(ageSelectorBar);
            return ageSelectorBar.Location.Y;
        }

        #endregion

        #region .: 4 - Set Location info :.

        /// <summary>
        /// Determines whether [is at set location info].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at set location info]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtSetLocationInfo()
        {
            WaitUntilElementIsVisible(txtMyProfileClinicLocationTittle);
            return IsElementEnabled(txtMyProfileClinicLocationTittle);
        }

        /// <summary>
        /// Click SKIP at Location info.
        /// </summary>
        public void ClickSkipLocationInfo()
        {
            ClickElement(btnSkipClinicLocation);
        }

        /// <summary>
        /// Click CONFIRM at Location info.
        /// </summary>
        public void ClickConfirmLocationInfo()
        {
            ClickElement(btnConfirmClinicLocation);
        }

        /// <summary>
        /// Click inputCity at Location info.
        /// </summary>
        public void ClickInputCityInfo()
        {
            ClickElement(inputCity);
        }

        /// <summary>
        /// Click inputNeighbourhood at Location info.
        /// </summary>
        public void ClickInputNeighbourhoodInfo()
        {
            ClickElement(inputNeighbourhood);
        }

        /// <summary>
        /// Click inputClinic at Location info.
        /// </summary>
        public void ClickInputClinicInfo()
        {
            ClickElement(inputClinic);
        }

        /// <summary>
        /// Click CANCEL Location info pop-up.
        /// </summary>
        public void ClickCancelLocationPopup()
        {
            ClickElement(btnCancelPopup);
        }

        /// <summary>
        /// Click pop-up option 1.
        /// </summary>
        public void SelectRandomPopupOption()
        {
            int randomNumber = random.Next(0, 100);

            if (txtPopupOptionsList.Count == 1) { ClickElement(txtPopupOptionsList[0]); }

            if (txtPopupOptionsList.Count == 2)
            {
                if (randomNumber <= 50)
                {
                    ClickElement(txtPopupOptionsList[0]);
                }
                else
                {
                    ClickElement(txtPopupOptionsList[1]);
                }
            }

            if (txtPopupOptionsList.Count == 3)
            {
                if (randomNumber <= 33)
                {
                    ClickElement(txtPopupOptionsList[0]);
                }
                if (randomNumber <= 66)
                {
                    ClickElement(txtPopupOptionsList[1]);
                }
                else
                {
                    ClickElement(txtPopupOptionsList[2]);
                }
            }
        }

        /// <summary>
        /// Determines whether [is at set location info pop-up].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at set location info pop-up]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtSetLocationInfoPopup()
        {
            WaitUntilElementIsVisible(btnCancelPopup);
            return IsElementEnabled(btnCancelPopup);
        }


        #endregion

        #region .: 5 - Complete Login :.

        /// <summary>
        /// Click in go to homepage button.
        /// </summary>
        public void ClickGoToHomepage()
        {
            {
                ClickElement(btnStartAfterLogin);
            } 
        }
        #endregion
    }
}