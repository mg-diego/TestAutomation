using System;
using System.Collections.Generic;
using AC.Contracts;
using AC.Contracts.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Chat with Communities page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IScanBarcodePage" />
    public class ScanBarcodePage : PageBase, IScanBarcodePage
    {
        #region .: Barcode scanner :.

        [FindsBy(How = How.Id, Using = "FlashIcon")]
        private IWebElement btnFlash;

        [FindsBy(How = How.Id, Using = "CloseScannerButton")]
        private IWebElement btnCloseCamera;        

        [FindsBy(How = How.ClassName, Using = "android.widget.FrameLayout")]
        private IWebElement camera;

        #endregion


        #region .: ScanFeedback timeout :.

        [FindsBy(How = How.Id, Using = "Tittle_ScanPage_TryAgain")]
        private IWebElement tittleTimeoutTryAgain;

        [FindsBy(How = How.Id, Using = "Tip1_ScanPage_TryAgain")]
        private IWebElement tip1_ScanPage_TryAgain;

        [FindsBy(How = How.Id, Using = "Tip2_ScanPage_TryAgain")]
        private IWebElement tip2_ScanPage_TryAgain;

        [FindsBy(How = How.Id, Using = "Tip3_ScanPage_TryAgain")]
        private IWebElement tip3_ScanPage_TryAgain;

        [FindsBy(How = How.Id, Using = "image_ScanPage_TryAgain")]
        private IList<IWebElement> image_ScanPage_TryAgain;

        [FindsBy(How = How.Id, Using = "BtnScanFeedbackConfirm")]
        private IWebElement BtnScanFeedbackConfirm;

        string expected_tip1 = "Turn on the flash";
        string expected_tip2 = "Hold your device steady";
        string expected_tip3 = "Place the barcode on a flat surface";
        string expected_tittle = "Please scan the barcode again";
        string expected_button_retry = "Got it!";

        #endregion



        /// <summary>
        /// Initializes a new instance of the <see cref="ScanBarcodePage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public ScanBarcodePage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [mobile camera is open].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [camera is open]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCameraOpened()
        {
            this.WaitUntil(1);
            return camera.Displayed;
        }

        /// <summary>
        /// Determines whether [mobile camera is closed].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [camera is closed]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCameraClosed()
        {
            Console.WriteLine("Pending to implement!");
            return false;
        }

       
        /// <summary>
        /// Clicks the Got It! button after error scanning.
        /// </summary>
        public void ClickGotItButtonBarcodeScanFailed()
        {
            ClickElement(BtnScanFeedbackConfirm);
        }


        /// <summary>
        /// Wait until camera timeout (3m).
        /// </summary>
        public void WaitForCameraTimeout(int minutes)
        {
            WaitUntil(minutes*60);
            WaitUntil(5);
        }

        /// <summary>
        /// Determines whether [is at scanning timeout].
        /// </summary>
        public void IsAtScanningTimeout()
        {
            Assert.Multiple(() =>
            {
                Assert.That(tip1_ScanPage_TryAgain.Text, Is.EqualTo(expected_tip1), "Tip1 text is wrong.");
                Assert.That(tip2_ScanPage_TryAgain.Text, Is.EqualTo(expected_tip2), "Tip2 text is wrong.");
                Assert.That(tip3_ScanPage_TryAgain.Text, Is.EqualTo(expected_tip3), "Tip3 text is wrong.");
                Assert.That(tittleTimeoutTryAgain.Text, Is.EqualTo(expected_tittle), "Tittle text is wrong.");
                Assert.That(BtnScanFeedbackConfirm.Text, Is.EqualTo(expected_button_retry), "Button text is wrong.");
                Assert.That(image_ScanPage_TryAgain[0].Displayed, Is.EqualTo(true), "Image retry is not displayed.");
            });
        }
    }
}
