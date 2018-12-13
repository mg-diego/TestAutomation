using System;
using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using DF.Entities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AC.SeleniumDriver.Pages.Login
{
    /// <summary>
    /// The My Blood Results page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IBloodResultsPage" />
    public class BloodResultsPage : PageBase, IBloodResultsPage
    {

        #region .: Common Elements :.

        #region .: Tool bar Elements :.

        [FindsBy(How = How.Id, Using = "OK")]
        public IWebElement btnOpenMenuDrawer { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Blood results') and (@index='1')]")]
        private IList<IWebElement> txtBloodResults { get; set; }
        #endregion

        #region .: Latest result date Elements :.

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='ResultsOnTheWay']/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.widget.TextView")]
        private IWebElement txtLatestTestDateResultsOnTheWay { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.view.ViewGroup[@content-desc='ResultTitle']/android.view.ViewGroup/android.view.ViewGroup[1]/android.view.ViewGroup/android.widget.TextView")]
        private IWebElement txtLatestTestDateWithResultsReleased { get; set; }

        #endregion

        #region .: Bubble information Elements :.

        [FindsBy(How = How.Id, Using = "txtBubbleHeader")]
        private IList<IWebElement> txtBubbleHeader { get; set; }

        [FindsBy(How = How.Id, Using = "txtBubbleMeds")]
        private IWebElement txtBubbleMeds { get; set; }

        [FindsBy(How = How.Id, Using = "txtBubbleVirus")]
        private IWebElement txtBubbleVirus { get; set; }

        [FindsBy(How = How.Id, Using = "txtBubbleTalk")]
        private IWebElement txtBubbleTalkToNurse { get; set; }

        [FindsBy(How = How.Id, Using = "imgBubbleMeds")]
        private IWebElement iconMeds { get; set; }

        [FindsBy(How = How.Id, Using = "imgBubbleVirus")]
        private IWebElement iconVirus { get; set; }

        [FindsBy(How = How.Id, Using = "imgBubbleTalk")]
        private IWebElement iconTalkToNurse { get; set; }

        #endregion

        #region .: Tips information Elements :.

        [FindsBy(How = How.Id, Using = "txtTipFoodAndExcercise")]
        private IWebElement txtTipFood { get; set; }

        [FindsBy(How = How.Id, Using = "txtTipProtection")]
        private IWebElement txtTipProtection { get; set; }

        [FindsBy(How = How.Id, Using = "iconTipFoodAndExcercise")]
        private IWebElement iconTipFoodAndExcercise { get; set; }

        [FindsBy(How = How.Id, Using = "iconTipProtection")]
        private IWebElement iconTipProtection { get; set; }

        #endregion

        #endregion

        #region .: No results Elements :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Barcode Scanner') and (@index='1')]")]
        private IList<IWebElement> txtBloodResultsNoResults { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Welcome to iThemba') and (@class='android.widget.TextView')]")]
        private IWebElement txtWelcome { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Scan the first sample') and (@class='android.widget.TextView')]")]
        private IWebElement txtScanFirstSample { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='To receive your results scan your barcode in the blood room') and (@class='android.widget.TextView')]")]
        private IWebElement txtReceiveResultsInfo { get; set; }

        [FindsBy(How = How.Id, Using = "imgNoResults")]
        private IWebElement imgScanBarcode { get; set; }

        [FindsBy(How = How.Id, Using = "GoToScan")]
        [CacheLookup]
        private IWebElement btnGoToScanner { get; set; }

        #endregion

        #region .: Results on the way :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Everything worked well!') and (@class='android.widget.TextView')]")]
        private IWebElement txtAllWentWell { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Your Results are on the way') and (@class='android.widget.TextView')]")]
        private IWebElement txtBloodResultsOnTheWay { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Your results will arrive in 3-5 days, chat to other positive people while waiting') and (@class='android.widget.TextView')]")]
        private IWebElement txtResultsArriveTimeInfo { get; set; }

        [FindsBy(How = How.Id, Using = "GoToCommunity")]
        private IWebElement btnGoToCommunity { get; set; }

        [FindsBy(How = How.Id, Using = "BannerResultsOnTheWay")]
        private IList<IWebElement> BannerResultsOnTheWay { get; set; }

        [FindsBy(How = How.Id, Using = "closeResultsOnTheWay")]
        private IWebElement btnCloseBannerResultsOnTheWay { get; set; }

        #endregion

        #region .: Less then 50 Elements :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Everything looks fine!') and (@class='android.widget.TextView')]")]
        private IWebElement txtBloodResultsEverythingFine { get; set; }

        [FindsBy(How = How.Id, Using = "iconHappy")]
        private IWebElement emoticonHappy { get; set; }

        #endregion

        #region .: Between 50-1000 Elements :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Visit your clinic') and (@class='android.widget.TextView')]")]
        private IWebElement txtVisitYourClinic { get; set; }

        [FindsBy(How = How.Id, Using = "txtBubbleTalk")]
        private IWebElement txtBubbleDiscussToNurse { get; set; }

        [FindsBy(How = How.Id, Using = "iconSurprised")]
        private IWebElement emoticonSurprised { get; set; }

        [FindsBy(How = How.Id, Using = "imgBubbleTalk")]
        private IWebElement iconDiscussToNurse { get; set; }


        #endregion

        #region .: More then 1000 Elements :.

        [FindsBy(How = How.Id, Using = "iconNurse")]
        private IWebElement emoticonNurse { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Visit your clinic immediately') and (@class='android.widget.TextView')]")]
        private IWebElement txtBloodResultsVisitClinic { get; set; }

        [FindsBy(How = How.Id, Using = "iconScheduleAppointment")]
        private IWebElement iconScheduleAppointment { get; set; }

        [FindsBy(How = How.Id, Using = "txtBubbleScheduleAppointment")]
        private IWebElement txtBubbleScheduleAppointment { get; set; }

        #endregion

        #region .: Past Results :.

        [FindsBy(How = How.XPath, Using = "//*[(@text='Past Results')]")]
        private IWebElement btnGoToPastResults { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Past Results')]")]
        private IList<IWebElement> btnGoToPastResultsList { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.widget.ImageButton")]
        private IWebElement btnExitPastResults { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='All your results') and (@class='android.widget.TextView')]")]
        private IWebElement txtPastResultsHeader { get; set; }

        [FindsBy(How = How.Id, Using = "BarcodeClickStackLayout")]
        private IList<IWebElement> btnShowBarcode { get; set; }

        [FindsBy(How = How.Id, Using = "btnCloseBarcode")]
        private IWebElement btnCloseBarcode { get; set; }

        [FindsBy(How = How.Id, Using = "txtBarcodeId")]
        private IWebElement txtBarcodeId { get; set; }

        [FindsBy(How = How.Id, Using = "ReleaseDateHorizontal")]
        private IList<IWebElement> ReleaseDateHorizontalList { get; set; }

        [FindsBy(How = How.Id, Using = "ReleaseDateVertical")]
        private IList<IWebElement> ReleaseDateVerticalList { get; set; }

        [FindsBy(How = How.Id, Using = "ReleaseResultVertical")]
        private IList<IWebElement> ReleaseResultVertical { get; set; }

        #endregion

        #region .: Expected Content :.

        private string expectedEmoticonTxtGreen = "You are in top shape!";
        private string expectedEmoticonTxtOrange = "Please take care";
        private string expectedEmoticonTxtRed = "Please take extra care";

        private string expectedBubbleMedsRed = "Are you taking your pills correctly?";
        private string expectedBubbleMedsOrange = "Keep taking your pills every day at the same time";
        private string expectedBubbleMedsGreen = "Keep taking your pills every day at the same time";

        private string expectedBubbleVirusRed = "The virus is there and it is growing fast";
        private string expectedBubbleVirusOrange = "The virus is still there and it is not suppressed";
        private string expectedBubbleVirusGreen = "The virus is still there but it is suppressed";

        private string expectedBubbleFeedbackRed = "Talk to the nurse and show her these results";
        private string expectedBubbleFeedbackOrange = "Discuss your result with a nurse";
        private string expectedBubbleFeedbackGreen = "On your next visit, please show this to the nurse";

        private string expectedBubbleScheduleAppointmentRed = "Make sure to schedule your next blood test";

        private string expectedTipFood = "Continue to eat healthy and exercise";
        private string expectedTipProtection = "Always be safe and use protection";

        #endregion

        #region .: No network condition Elements :.

        [FindsBy(How = How.Id, Using = "RetryConection")]
        [CacheLookup]
        private IWebElement btnRetryConnection { get; set; }

        [FindsBy(How = How.Id, Using = "CancelConection")]
        [CacheLookup]
        private IWebElement btnCancelConnection { get; set; }

        #endregion

        #region .: Exit IThemba pop up window

        [FindsBy(How = How.XPath, Using = "//*[(@text='Yes, exit') and (@class='android.widget.Button')]")]
        private IWebElement btnYesExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='No') and (@class='android.widget.Button')]")]
        private IWebElement btnNoExit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[(@text='Are you sure you want to exit iThemba?') and (@class='android.widget.TextView')]")]
        private IWebElement txtExitApp { get; set; }

        #endregion



        /// <summary>
        /// Initializes a new instance of the <see cref="BloodResultsPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public BloodResultsPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        #region .: General Methods :.

        /// <summary>
        /// Determines whether [is at blood results page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at blood results page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtBloodResultsPage()
        {
            this.WaitUntil(2);
            if (txtBloodResults.Count >= 1)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Determines whether [Last result date is correct or not].
        /// </summary>
        private bool IsLastResultDateCorrect(string expectedDate)
        {
            Assert.Multiple(() => 
            {
                Assert.That(txtLatestTestDateWithResultsReleased.Text, Is.EqualTo(expectedDate),
                    "txtLatestTestDateWithResultsReleased is not correct");
            });

            return true;
        }

        /// <summary>
        /// Determines whether [user tips are correct].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [user tips are correct]; otherwise, <c>false</c>.
        /// </returns>
        private bool AreUserTipsCorrect(string userType)
        {
            switch (userType)
            {
                case "green":
                    Assert.Multiple(() =>
                    {
                        Assert.That(txtBubbleHeader[0].Text, Is.EqualTo(expectedEmoticonTxtGreen), "txtBubbleHeader is wrong");

                        Assert.That(IsElementEnabled(iconMeds), Is.EqualTo(true), "iconMeds is not displayed");
                        Assert.That(txtBubbleMeds.Text, Is.EqualTo(expectedBubbleMedsGreen), "txtBubbleMeds is wrong");

                        Assert.That(IsElementEnabled(iconVirus), Is.EqualTo(true), "iconVirus is not displayed");
                        Assert.That(txtBubbleVirus.Text, Is.EqualTo(expectedBubbleVirusGreen), "txtBubbleVirus is wrong");

                        Assert.That(IsElementEnabled(iconTalkToNurse), Is.EqualTo(true), "iconTalkToNurse is not displayed");
                        Assert.That(txtBubbleTalkToNurse.Text, Is.EqualTo(expectedBubbleFeedbackGreen), "txtBubbleTalkToNurse is wrong");

                        Assert.That(IsElementEnabled(iconTipFoodAndExcercise), Is.EqualTo(true), "iconTipFoodAndExcercise is not displayed");
                        Assert.That(txtTipFood.Text, Is.EqualTo(expectedTipFood), "txtTipFood is wrong");

                        //Assert.That(IsElementEnabled(iconTipProtection), Is.EqualTo(true), "iconTipProtection is not displayed");
                        //Assert.That(txtTipProtection.Text, Is.EqualTo(expectedTipProtection), "txtTipProtection is wrong");
                    });
                    break;


                case "orange":
                    Assert.Multiple(() =>
                    {
                        Assert.That(txtBubbleHeader[0].Text, Is.EqualTo(expectedEmoticonTxtOrange), "txtBubbleHeader is wrong");

                        Assert.That(IsElementEnabled(iconMeds), Is.EqualTo(true), "iconMeds is not displayed");
                        Assert.That(txtBubbleMeds.Text, Is.EqualTo(expectedBubbleMedsOrange), "txtBubbleMeds is wrong");

                        Assert.That(IsElementEnabled(iconVirus), Is.EqualTo(true), "iconVirus is not displayed");
                        Assert.That(txtBubbleVirus.Text, Is.EqualTo(expectedBubbleVirusOrange), "txtBubbleVirus is wrong");

                        Assert.That(IsElementEnabled(iconDiscussToNurse), Is.EqualTo(true), "iconDiscussToNurse is not displayed");
                        Assert.That(txtBubbleDiscussToNurse.Text, Is.EqualTo(expectedBubbleFeedbackOrange), "txtBubbleDiscussToNurse is wrong");

                        Assert.That(IsElementEnabled(iconTipFoodAndExcercise), Is.EqualTo(true), "iconTipFoodAndExcercise is not displayed");
                        Assert.That(txtTipFood.Text, Is.EqualTo(expectedTipFood), "txtTipFood is wrong");

                        //Assert.That(IsElementEnabled(iconTipProtection), Is.EqualTo(true), "iconTipProtection is not displayed");
                        //Assert.That(txtTipProtection.Text, Is.EqualTo(expectedTipProtection), "txtTipProtection is wrong");
                    });
                    break;

                case "red":
                    Assert.Multiple(() =>
                    {
                        Assert.That(txtBubbleHeader[0].Text + " " + txtBubbleHeader[1].Text + " " + txtBubbleHeader[2].Text, Is.EqualTo(expectedEmoticonTxtRed), "txtBubbleHeader is wrong");

                        Assert.That(IsElementEnabled(iconMeds), Is.EqualTo(true), "iconMeds is not displayed");
                        Assert.That(txtBubbleMeds.Text, Is.EqualTo(expectedBubbleMedsRed), "txtBubbleMeds is wrong");

                        Assert.That(IsElementEnabled(iconVirus), Is.EqualTo(true), "iconVirus is not displayed");
                        Assert.That(txtBubbleVirus.Text, Is.EqualTo(expectedBubbleVirusRed), "txtBubbleVirus is wrong");

                        Assert.That(IsElementEnabled(iconTalkToNurse), Is.EqualTo(true), "iconTalkToNurse is not displayed");
                        Assert.That(txtBubbleTalkToNurse.Text, Is.EqualTo(expectedBubbleFeedbackRed), "txtBubbleTalkToNurse is wrong");

                        Assert.That(IsElementEnabled(iconScheduleAppointment), Is.EqualTo(true), "iconScheduleAppointment is not displayed");
                        Assert.That(txtBubbleScheduleAppointment.Text, Is.EqualTo(expectedBubbleScheduleAppointmentRed), "txtBubbleScheduleAppointment is wrong");

                        Assert.That(IsElementEnabled(iconTipFoodAndExcercise), Is.EqualTo(true), "iconTipFoodAndExcercise is not displayed");
                        Assert.That(txtTipFood.Text, Is.EqualTo(expectedTipFood), "txtTipFood is wrong");

                        //Assert.That(IsElementEnabled(iconTipProtection), Is.EqualTo(true), "iconTipProtection is not displayed");
                        //Assert.That(txtTipProtection.Text, Is.EqualTo(expectedTipProtection), "txtTipProtection is wrong");
                    });
                    break;
            }
            return true;
        }

        #endregion

        #region .: User Less Than 50 :.

        /// <summary>
        /// Determines whether [is at less than 50 cp/ml blood results page].
        /// </summary>
        public void IsAtLessThan50ResultsPage(UserLogin user)
        {
            WaitUntilElementIsVisible(btnOpenMenuDrawer);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnOpenMenuDrawer), Is.EqualTo(true), "btnOpenMenuDrawer is not displayed");
                Assert.That(IsElementEnabled(txtBloodResults[0]), Is.EqualTo(true), "txtBloodResults[0] is not displayed");
                Assert.That(IsElementEnabled(btnGoToPastResults), Is.EqualTo(true), "btnGoToPastResults is not displayed");
                Assert.That(IsLastResultDateCorrect(user.latestTestDateBloodResults), Is.EqualTo(true), "latestTestDateBloodResults is not correct");
                Assert.That(IsElementEnabled(txtBloodResultsEverythingFine), Is.EqualTo(true), "txtBloodResultsEverythingFine is not displayed");
                Assert.That(IsHappyIconSelected(), Is.EqualTo(true), "HappyIcon is not selected");
                Assert.That(AreUserTipsCorrect("green"), Is.EqualTo(true), "UserTips green are not correct");
            });
        }

        /// <summary>
        /// Determines whether [happy icon is selected].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [happy icon is selected]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsHappyIconSelected()
        {
            Assert.Multiple(() =>
            {
                Assert.That(emoticonHappy.Size.Height > emoticonSurprised.Size.Height &&
                            emoticonHappy.Size.Height > emoticonNurse.Size.Height,
                            Is.EqualTo(true), "Happy icon is not selected");
            });
            return true;
        }

        #endregion

        #region .: User Between 50-1000 :.

        /// <summary>
        /// Determines whether [is at 50-1000 cp/ml blood results page].
        /// </summary>
        public void IsAt50_1000ResultsPage(UserLogin user)
        {
            WaitUntilElementIsVisible(btnOpenMenuDrawer);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnOpenMenuDrawer), Is.EqualTo(true), "btnOpenMenuDrawer is not displayed");
                Assert.That(IsElementEnabled(txtBloodResults[0]), Is.EqualTo(true), "txtBloodResults[0] is not displayed");
                Assert.That(IsElementEnabled(btnGoToPastResults), Is.EqualTo(true), "btnGoToPastResults is not displayed");
                Assert.That(IsLastResultDateCorrect(user.latestTestDateBloodResults), Is.EqualTo(true), "latestTestDateBloodResults is not correct");
                Assert.That(IsElementEnabled(txtVisitYourClinic), Is.EqualTo(true), "txtVisitYourClinic is not displayed");
                Assert.That(IsSurprisedIconSelected(), Is.EqualTo(true), "SurprisedIcon is not selected");
                Assert.That(AreUserTipsCorrect("orange"), Is.EqualTo(true), "UserTips orange are not correct");
            });
        }

        /// <summary>
        /// Determines whether [Surprised icon is selected].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Surprised icon is selected]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSurprisedIconSelected()
        {
            Assert.Multiple(() =>
            {
                Assert.That(emoticonSurprised.Size.Height > emoticonHappy.Size.Height &&
                            emoticonSurprised.Size.Height > emoticonNurse.Size.Height,
                            Is.EqualTo(true), "Surprised icon is not selected");
            });
            return true;
        }

        #endregion

        #region .: User More Than 1000 :.

        /// <summary>
        /// Determines whether [is at more than 1000 cp/ml blood results page].
        /// </summary>
        public void IsAtMoreThan1000ResultsPage(UserLogin user)
        {
            WaitUntilElementIsVisible(btnOpenMenuDrawer);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnOpenMenuDrawer), Is.EqualTo(true), "btnOpenMenuDrawer is not displayed");
                Assert.That(IsElementEnabled(txtBloodResults[0]), Is.EqualTo(true), "txtBloodResults[0] is not displayed");
                Assert.That(IsElementEnabled(btnGoToPastResults), Is.EqualTo(true), "btnGoToPastResults is not displayed");
                Assert.That(IsLastResultDateCorrect(user.latestTestDateBloodResults), Is.EqualTo(true), "latestTestDateBloodResults is not correct");
                Assert.That(IsElementEnabled(txtBloodResultsVisitClinic), Is.EqualTo(true), "txtBloodResultsVisitClinic is not correct");
                Assert.That(IsNurseIconSelected(), Is.EqualTo(true), "NurseIcon is not selected");
                Assert.That(AreUserTipsCorrect("red"), Is.EqualTo(true), "UserTips red are not correct");
            });
        }

        /// <summary>
        /// Determines whether [Nurse icon is selected].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Nurse icon is selected]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsNurseIconSelected()
        {
            Assert.Multiple(() =>
            {
                Assert.That(emoticonNurse.Size.Height > emoticonHappy.Size.Height &&
                            emoticonNurse.Size.Height > emoticonSurprised.Size.Height,
                            Is.EqualTo(true), "Nurse icon is not selected");
            });
            return true;
        }

        #endregion

        #region .: No Result :.

        /// <summary>
        /// Clicks the Go To Scanner button
        /// </summary>
        public void ClickGoToScanner()
        {
            ClickElement(btnGoToScanner);
        }

        /// <summary>
        /// Determines whether [is at Scan first Barcode page].
        /// </summary>
        public void IsAtScanFirstBarcodePage()
        {
            WaitUntilElementIsVisible(btnOpenMenuDrawer);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnOpenMenuDrawer), Is.EqualTo(true), "btnOpenMenuDrawer is not displayed");
                Assert.That(IsElementEnabled(txtBloodResultsNoResults[0]), Is.EqualTo(true), "txtBloodResultsNoResults[0] is not displayed");
                Assert.That(btnGoToPastResultsList.Count, Is.EqualTo(0), "btnGoToPastResults is displayed");
                Assert.That(IsElementEnabled(txtScanFirstSample), Is.EqualTo(true), "txtScanFirstSample is not displayed");
                Assert.That(IsElementEnabled(txtWelcome), Is.EqualTo(true), "txtWelcome is not displayed");
                Assert.That(IsElementEnabled(imgScanBarcode), Is.EqualTo(true), "imgScanBarcode is not displayed");
                Assert.That(IsElementEnabled(txtReceiveResultsInfo), Is.EqualTo(true), "txtReceiveResultsInfo is not displayed");
                Assert.That(IsElementEnabled(btnGoToScanner), Is.EqualTo(true), "btnGoToScanner is not displayed");
            });
        }
        #endregion

        #region .: ResultsOnTheWay :.

        /// <summary>
        /// Clicks the Go To Community button
        /// </summary>
        public void ClickGoToCommunity()
        {
            ClickElement(btnGoToCommunity);
        }

        /// <summary>
        /// Clicks the Close banner Results on the Way
        /// </summary>
        public void ClickCloseBannerResultsOnTheWay()
        {
            ClickElement(btnCloseBannerResultsOnTheWay);
        }

        /// <summary>
        /// Determines whether [is at results on the way page].
        /// </summary>
        public void IsAtResultsOnTheWayPage(UserLogin user)
        {
            WaitUntilElementIsVisible(btnOpenMenuDrawer);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnOpenMenuDrawer), Is.EqualTo(true), "btnOpenMenuDrawer is not displayed");
                Assert.That(IsElementEnabled(txtBloodResults[0]), Is.EqualTo(true), "txtBloodResults[0] is not displayed");
                Assert.That(btnGoToPastResultsList.Count, Is.EqualTo(0), "btnGoToPastResults is displayed");
                Assert.That(IsElementEnabled(txtAllWentWell), Is.EqualTo(true), "txtAllWentWell is not displayed");
                Assert.That(IsElementEnabled(txtBloodResultsOnTheWay), Is.EqualTo(true), "txtBloodResultsOnTheWay is not displayed");
                Assert.That(IsElementEnabled(txtResultsArriveTimeInfo), Is.EqualTo(true), "txtResultsArriveTimeInfo is not displayed");
                Assert.That(IsElementEnabled(btnGoToCommunity), Is.EqualTo(true), "btnGoToCommunity is not displayed");
            });
        }

        /// <summary>
        /// Determines whether [results on the way banner is visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [results on the way banner is visible]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsResultsOnTheWayBannerVisible()
        {
            this.WaitUntil(1);
            if (BannerResultsOnTheWay.Count >= 1)
            {
                return true;
            }
            else
                return false;
        }

        #endregion

        #region .: Past Results :.

        /// <summary>
        /// Clicks the Go To Past Results
        /// </summary>
        public void ClickGoToPastResults()
        {
            WaitUntilElementIsVisible(btnGoToPastResults);
            ClickElement(btnGoToPastResults);
        }

        /// <summary>
        /// Clicks the Exit Past Results
        /// </summary>
        public void ClickExitPastResults()
        {
            ClickElement(btnExitPastResults);
        }

        /// <summary>
        /// Clicks the Show Barcode button
        /// </summary>
        public void ClickShowBarcode()
        {
            ClickElement(btnShowBarcode[0]);
        }

        /// <summary>
        /// Clicks the Close Barcode button
        /// </summary>
        public void ClickCloseBarcode()
        {
            ClickElement(btnCloseBarcode);
        }
        

        /// <summary>
        /// Determines whether [is at Past Results screen].
        /// </summary>
        public void IsAtPastResults()
        {
            WaitUntilElementIsVisible(txtPastResultsHeader);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(txtPastResultsHeader), Is.EqualTo(true), "txtPastResultsHeader is not displayed");
                Assert.That(btnShowBarcode.Count, Is.GreaterThan(0), "btnShowBarcode is not displayed");
                Assert.That(ReleaseDateHorizontalList.Count, Is.GreaterThan(0), "ReleaseDateHorizontalList is not displayed");
                Assert.That(ReleaseDateVerticalList.Count, Is.GreaterThan(0), "ReleaseDateVerticalList is not displayed");
                Assert.That(ReleaseResultVertical.Count, Is.GreaterThan(0), "ReleaseResultVertical is not displayed");
            });
        }

        /// <summary>
        /// Determines whether is at Past Results with imported results
        /// </summary>
        /// <returns>
        public void IsAtPastResultsWithImportedResults()
        {
            WaitUntilElementIsVisible(txtPastResultsHeader);

            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(txtPastResultsHeader), Is.EqualTo(true), "txtPastResultsHeader is not displayed");
                Assert.That(btnShowBarcode.Count, Is.LessThan(2), "Imported result show barcode is displayed");
                Assert.That(ReleaseDateHorizontalList.Count, Is.GreaterThan(0), "ReleaseDateHorizontalList is not displayed");
                Assert.That(ReleaseDateVerticalList.Count, Is.GreaterThan(0), "ReleaseDateVerticalList is not displayed");
                Assert.That(ReleaseResultVertical.Count, Is.GreaterThan(0), "ReleaseResultVertical is not displayed");
            });
        }

        /// <summary>
        /// Determines whether [is at Barcode View screen].
        /// </summary>
        public void IsAtBarcodeView(UserLogin user)
        {
            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnCloseBarcode), Is.EqualTo(true), "btnCloseBarcode is not displayed");
                Assert.That(txtBarcodeId.Text, Is.EqualTo(user.BarcodeIdList[0]), "txtBarcodeId is not correct");
            });
        }

        /// <summary>
        /// Determines whether horizontal Past Results dates are OK
        /// </summary>
        /// <returns>
        /// <c>true</c> if [horizontal Past Results dates are OK]; otherwise, <c>false</c>.
        /// </returns>
        public void AreHorizontalPastResultsDatesOk(UserLogin user)
        {
            for (var i = 0; i < user.ReleaseDateHorizontal.Count; i++)
                Assert.Multiple(() =>
                {                    
                    Assert.That(ReleaseDateHorizontalList[i].Text, Is.EqualTo(user.ReleaseDateHorizontal[i]),
                        "ReleaseDateHorizontalList["+i+"] is not correct");
                });
        }

        /// <summary>
        /// Determines whether vertical Past Results dates are OK
        /// </summary>
        /// <returns>
        /// <c>true</c> if [vertical Past Results dates are OK]; otherwise, <c>false</c>.
        /// </returns>
        public void AreVerticalPastResultsDatesOk(UserLogin user)
        {
            for (var i = 0; i < user.ReleaseDateVertical.Count; i++)
                Assert.Multiple(() =>
                {                    
                    Assert.That(ReleaseDateVerticalList[i].Text, Is.EqualTo(user.ReleaseDateVertical[i]),
                        "ReleaseDateVerticalList[" + i + "] is not correct");
                });
        }

        /// <summary>
        /// Determines whether Past Results values are OK
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Past Results values are OK]; otherwise, <c>false</c>.
        /// </returns>
        public void ArePastResultsValuesOk(UserLogin user)
        {
            for (var i = 0; i < user.ReleaseResultVertical.Count; i++)
                Assert.Multiple(() =>
                {                    
                    Assert.That(ReleaseResultVertical[i].Text, Is.EqualTo(user.ReleaseResultVertical[i]),
                        "ReleaseResultVertical[" + i + "] is not correct");
                });
        }


        #endregion

        #region .: Exit iThemba :.

        /// <summary>
        /// Clicks the YES, EXIT button from the pop up exit window
        /// </summary>
        public void ClickYesExit()
        {
            ClickElement(btnYesExit);
        }

        /// <summary>
        /// Clicks the NO button from the pop up exit window
        /// </summary>
        public void ClickNoButtonFromExitMenu()
        {
            ClickElement(btnNoExit);
        }

        /// <summary>
        /// Determines whether Exit iThemba pop up message is displayed
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Exit iThemba pop up message is displayed]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsExitMessageDisplayed()
        {
            return IsElementEnabled(txtExitApp);
        }

        #endregion

        #region .: No Connectivity :.

        /// <summary>
        /// Clicks the Try Again button
        /// </summary>
        public void ClickTryConnectionAgain()
        {
            ClickElement(btnRetryConnection);
        }

        /// <summary>
        /// Determines whether [is at no Network Screen].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at no Network Screen]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtNoNetworkScreen()
        {
            Assert.Multiple(() =>
            {
                Assert.That(IsElementEnabled(btnRetryConnection), Is.EqualTo(true), "btnRetryConnection is not displayed");
                Assert.That(IsElementEnabled(btnCancelConnection), Is.EqualTo(true), "btnCancelConnection is not displayed");
            });

            return true;
        }

        #endregion

    }
}