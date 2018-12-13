using System;
using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Settings page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IUserProfilePage" />
    public class UserProfilePage : PageBase, IUserProfilePage
    {

        #region .: Android Elements :.

        #region .: Gender / Age :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Tell us your gender and age for better advice')]")]
        private IWebElement txtMyProfileGenderAgeTittle { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@instance='0') and (@class='android.widget.ImageView')]")]
        private IWebElement btnSelectMaleGender { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@instance='1') and (@class='android.widget.ImageView')]")]
        private IWebElement btnSelectFemaleGender { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@class='android.widget.SeekBar')]")]
        private IWebElement ageSelectorBar { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmProfile")]
        private IWebElement btnConfirmGenderAge { get; set; }

        [FindsBy(How = How.Id, Using = "btnSkipProfile")]
        private IWebElement btnNextGenderAge { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.widget.TextView")]
        private IList<IWebElement> userId { get; set; }
        //userId[2] = userId
        //userId[8] = contact your nurse

        #endregion

        #region .: Clinic Location :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Which clinic do you visit?')]")]
        private IWebElement txtMyProfileClinicLocationTittle { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/button2")]
        private IWebElement btnCancelPopup { get; set; }

        [FindsBy(How = How.Id, Using = "btnBackClinicLocation")]
        private IWebElement btnBackClinicLocation { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmClinicLocation")]
        private IWebElement btnConfirmClinicLocation { get; set; }

        [FindsBy(How = How.Id, Using = "btnSkipClinicLocation")]
        private IWebElement btnDoneClinicLocation { get; set; }

        #region .: City :.
        [FindsBy(How = How.Id, Using = "inputCity")]
        private IWebElement inputCity { get; set; }

        [FindsBy(How = How.Id, Using = "txtCity1']")]
        private IWebElement txtCity1 { get; set; }

        [FindsBy(How = How.Id, Using = "txtCity2")]
        private IWebElement txtCity2 { get; set; }
        #endregion

        #region .: Neighbourhood :.
        [FindsBy(How = How.Id, Using = "inputNeighbourhood")]
        private IWebElement inputNeighbourhood { get; set; }

        [FindsBy(How = How.Id, Using = "txtNeighbourhood1")]
        private IWebElement txtNeighbourhood1 { get; set; }

        [FindsBy(How = How.Id, Using = "txtNeighbourhood2")]
        private IWebElement txtNeighbourhood2 { get; set; }

        [FindsBy(How = How.Id, Using = "txtNeighbourhood3")]
        private IWebElement txtNeighbourhood3 { get; set; }
        #endregion

        #region .: Clinic :.
        [FindsBy(How = How.Id, Using = "inputClinic")]
        private IWebElement inputClinic { get; set; }

        [FindsBy(How = How.Id, Using = "txtClinic1")]
        private IWebElement txtClinic1 { get; set; }

        [FindsBy(How = How.Id, Using = "txtClinic2")]
        private IWebElement txtClinic2 { get; set; }
        #endregion








        #endregion

        private Random random = new Random();

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilePage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public UserProfilePage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        #region .: Methods :.

        #region .: Gender / Age :.

        /// <summary>
        /// Save Gender/Age at My Profile
        /// </summary>
        public void SaveGenderAgeInfo()
        {
            ClickElement(btnConfirmGenderAge);
        }

        /// <summary>
        /// Click Next at demographic info page, My Profile
        /// </summary>
        public void ClickNextAtDemographInfoPage()
        {
            ClickElement(btnNextGenderAge);
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
            return ageSelectorBar.Size.Width;
        }

        /// <summary>
        /// Get Age selector X width.
        /// </summary>
        public int GetAgeSelectorWidthX()
        {
            return ageSelectorBar.Location.X;
        }

        /// <summary>
        /// Get Age selector Y width.
        /// </summary>
        public int GetAgeSelectorWidthY()
        {
            return ageSelectorBar.Location.Y;
        }


        /// <summary>
        /// Determines whether [is at My profile Gender/Age info page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at My profile Gender/Age info page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtGenderAgeProfilePage()
        {
            WaitUntilElementIsVisible(ageSelectorBar);
            return ageSelectorBar.Displayed;
        }


        /// <summary>
        /// Determines whether [is Gender/Age button is enabled].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Gender/Age button is enabled]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConfirmGenderAgeEnabled()
        {
            WaitUntilElementIsVisible(btnConfirmGenderAge);
            return btnConfirmGenderAge.Enabled;
        }


        /// <summary>
        /// Determines whether [demographic info at My Profile is correct].
        /// </summary>
        public void IsDemographicInfoCorrect(UserLogin user)
        {
            Assert.Multiple(() =>
            {
                Assert.That(userId[2].Text, Is.EqualTo(user.Uuid), "userId is wrong");

                /*At the moment both images have the same size, can't be checked
                Assert.That(IsCorrectGenderSelected(user.Gender), Is.True,"user gender is incorrect");*/
            });
        }


        /// <summary>
        /// Determines whether [correct gender at My Profile is selected].
        /// </summary>
        private bool IsCorrectGenderSelected(string gender)
        {
            bool result = false;
            switch(gender)
            {
                case "Male":
                    if (btnSelectMaleGender.Size.Height > btnSelectFemaleGender.Size.Height) { result = true; }
                    break;

                case "Female":
                    if (btnSelectFemaleGender.Size.Height > btnSelectMaleGender.Size.Height) { result = true; }
                    break;
            }

            return result;
        }

        #endregion


        #region .: Clinic Location :.

        /// <summary>
        /// Save Clinic Location at My Profile
        /// </summary>
        public void SaveClinicLocationInfo()
        {
            ClickElement(btnConfirmClinicLocation);
        }

        /// <summary>
        /// Determines whether [is at My profile Clinic Location info page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at My profile Clinic Location info page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtClinicLocationProfilePage()
        {
            return inputCity.Displayed;
        }

        /// <summary>
        /// Determines whether [is Clinic Location button is enabled].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Clinic Location button is enabled]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConfirmClinicLocationEnabled()
        {
            WaitUntilElementIsVisible(btnConfirmGenderAge);
            return btnConfirmGenderAge.Enabled;
        }

        /// <summary>
        /// Click EXIT at Location info.
        /// </summary>
        public void ClickExitLocationInfo()
        {            
            ClickElement(btnDoneClinicLocation);
        }

        /// <summary>
        /// Click PREVIOUS at Location info.
        /// </summary>
        public void ClickPreviousAtLocationInfo()
        {
            ClickElement(btnBackClinicLocation);
        }


        /// <summary>
        /// Determines whether [demographic info at My Profile is correct].
        /// </summary>
        public void IsClinicLocationPageInfoCorrect(UserLogin user)
        {
            Assert.Multiple(() =>
            {
                //Assert.That(userId[2].Text, Is.EqualTo(user.Uuid), "userId is wrong");
                Assert.That(inputCity.Text, Is.EqualTo(user.City), "City is wrong");
                Assert.That(inputNeighbourhood.Text, Is.EqualTo(user.Neighbourhood), "Neighbourhood is wrong");
                Assert.That(inputClinic.Text, Is.EqualTo(user.Clinic), "Clinic is wrong");
            });
        }
        #endregion

        #endregion
    }
}
