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

namespace AC.SeleniumDriver.Pages
{
    /// <summary>
    /// The Search Barcode page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.ISearchBarcodePage" />
    public class SearchBarcodePage : PageBase, ISearchBarcodePage
    {

        [FindsBy(How = How.Id, Using = "inputBarcode")]
        private IWebElement inputBarcode;

        [FindsBy(How = How.Id, Using = "btnRelease")]
        private IWebElement btnRelease;

        [FindsBy(How = How.Id, Using = "btnUnrelease")]
        private IWebElement btnUnrelease;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),': Release ok')]")]
        private IWebElement txtBarcodeReleased;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),': Unreleased Ok')]")]
        private IWebElement txtBarcodeUnreleased;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),': Already unreleased')]")]
        private IWebElement txtBarcodeAlreadyUnreleased;

        [FindsBy(How = How.Id, Using = "btnOkDialog")]
        private IWebElement btnOkPopUp;

        [FindsBy(How = How.Id, Using = "btnSearch")]
        private IWebElement btnSearch;



        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBarcodePage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public SearchBarcodePage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at search barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at search barcode page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtSearchBarcodePage()
        {
            return inputBarcode.Displayed && btnSearch.Displayed;
        }


        /// <summary>
        /// Input a "barcode" in the input field.
        /// </summary>
        public void ClickSearchButton()
        {
            ClickElement(btnSearch);
        }

        /// <summary>
        /// Input a "barcode" in the input field.
        /// </summary>
        public void InputBarcode(string barcode)
        {
            ClearElement(inputBarcode);
            SendKeysElement(inputBarcode, barcode);
        }

        /// <summary>
        /// Click Release button.
        /// </summary>
        public void ClickReleaseButton()
        {
            ClickElement(btnRelease);
        }

        /// <summary>
        /// Click Release button.
        /// </summary>
        public void ClickUnreleaseButton()
        {
            ClickElement(btnUnrelease);
        }


        /// <summary>
        /// Determines whether [is at released barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at released barcode page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtReleasedPopUpMessage()
        {
            this.WaitUntil(1);
            Console.WriteLine(txtBarcodeReleased.Text);
            return txtBarcodeReleased.Displayed;
        }

        /// <summary>
        /// Determines whether [is at unreleased barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at unreleased barcode page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtUnreleasedPopUpMessage()
        {
            this.WaitUntil(1);
            Console.WriteLine(txtBarcodeUnreleased.Text);
            return txtBarcodeUnreleased.Displayed;
        }


        /// <summary>
        /// Determines whether [is at already released barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at already released barcode page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtAlreadyReleasedPopUpMessage()
        {
           return IsAtReleasedPopUpMessage();
        }

        /// <summary>
        /// Determines whether [is at already unreleased barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at already unreleased barcode page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtAlreadyUnreleasedPopUpMessage()
        {
            this.WaitUntil(1);
            Console.WriteLine(txtBarcodeAlreadyUnreleased.Text);
            return txtBarcodeAlreadyUnreleased.Displayed;
        }


        /// <summary>
        /// Click OK button at pop-up message.
        /// </summary>
        public void AcceptPopUpMessage()
        {
            ClickElement(btnOkPopUp);
        }
    }
}
