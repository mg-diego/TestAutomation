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
using NUnit.Framework;

namespace AC.SeleniumDriver.Pages.Login
{
    /// <summary>
    /// The Likert Survey page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ISurveyPage" />
    public class SurveyPage : PageBase, ISurveyPage
    {

        #region .: Android Elements :.  

        [FindsBy(How = How.Id, Using = "txtSurveyQuestion")]
        private IWebElement txtSurveyQuestion { get; set; }

        [FindsBy(How = How.Id, Using = "btnConfirmSurvey")]
        private IWebElement btnConfirmSurvey { get; set; }

        [FindsBy(How = How.Id, Using = "btnCloseSurvey")]
        private IWebElement btnCloseSurvey { get; set; }

        [FindsBy(How = How.Id, Using = "ratingBar")]
        private IWebElement ratingBar { get; set; }

        [FindsBy(How = How.Id, Using = "SurveyOptionLabel_1")]
        private IWebElement SurveyOptionLabel_1 { get; set; }

        [FindsBy(How = How.Id, Using = "SurveyOptionLabel_2")]
        private IWebElement SurveyOptionLabel_2 { get; set; }

        [FindsBy(How = How.Id, Using = "SurveyOptionLabel_3")]
        private IWebElement SurveyOptionLabel_3 { get; set; }

        [FindsBy(How = How.Id, Using = "SurveyOptionLabel_4")]
        private IWebElement SurveyOptionLabel_4 { get; set; }

        [FindsBy(How = How.Id, Using = "SurveyOptionLabel_5")]
        private IWebElement SurveyOptionLabel_5 { get; set; }

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="SurveyPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public SurveyPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at Login survey].
        /// </summary>
        public void IsAtLoginSurvey()
        {
            WaitUntilElementIsVisible(txtSurveyQuestion);

            Assert.Multiple(() =>
            {
                Assert.That(txtSurveyQuestion.Text, Is.EqualTo("How easy was it to log in?"), "txtSurveyQuestion is not correct");
                Assert.That(SurveyOptionLabel_1.Text, Is.EqualTo("not at all"), "SurveyOptionLabel_1 is not correct");
                Assert.That(SurveyOptionLabel_2.Text, Is.EqualTo("not really"), "SurveyOptionLabel_2 is not correct");
                Assert.That(SurveyOptionLabel_3.Text, Is.EqualTo("was ok"), "SurveyOptionLabel_3 is not correct");
                Assert.That(SurveyOptionLabel_4.Text, Is.EqualTo("liked it"), "SurveyOptionLabel_4 is not correct");
                Assert.That(SurveyOptionLabel_5.Text, Is.EqualTo("loved it"), "SurveyOptionLabel_5 is not correct");
            });
        }


        /// <summary>
        /// Clicks Confirm Survey
        /// </summary>
        public void ClickConfirmSurvey()
        {
            ClickElement(btnConfirmSurvey);
        }

        /// <summary>
        /// Clicks Close Survey
        /// </summary>
        public void ClickCloseSurvey()
        {
            ClickElement(btnCloseSurvey);
        }

        /// <summary>
        /// Get rating bar total width.
        /// </summary>
        public int GetRatingBarFinalLocationX()
        {
            this.WaitUntilElementIsVisible(ratingBar);
            //Console.WriteLine("Width: " + ratingBar.Size.Width);
            //Console.WriteLine("FinalX: "+ (ratingBar.Location.X + ratingBar.Size.Width));
            return (ratingBar.Location.X + ratingBar.Size.Width);
        }

        /// <summary>
        /// Get rating bar X width.
        /// </summary>
        public int GetRatingBarInitialLocationX()
        {
            this.WaitUntilElementIsVisible(ratingBar);
            //Console.WriteLine("InitialX: "+ratingBar.Location.X);
            return ratingBar.Location.X;
        }

        /// <summary>
        /// Get rating bar Y width.
        /// </summary>
        public int GetRatingBarWidthY()
        {
            this.WaitUntilElementIsVisible(ratingBar);
            //Console.WriteLine("Y_initial:"+ratingBar.Location.Y);
            //Console.WriteLine("Y_final:" + (ratingBar.Location.Y + ratingBar.Size.Height));
            return (ratingBar.Location.Y + (ratingBar.Size.Height/2));
        }




    }
}
