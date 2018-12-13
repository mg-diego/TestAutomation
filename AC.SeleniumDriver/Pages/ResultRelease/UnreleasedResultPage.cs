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
    /// The ResultRelease unreleased results page.
    /// </summary>
    /// <seealso cref="AC.SeleniumDriver.PageBase" />
    /// <seealso cref="AC.Contracts.Pages.IUnreleasedResultPage" />
    public class UnreleasedResultPage : PageBase, IUnreleasedResultPage
    {


        #region .: Selenium Elements :.

        [FindsBy(How = How.Id, Using = "inputFilter")]
        private IWebElement inputFilter;
        
        [FindsBy(How = How.Id, Using = "checkboxSelectAll")]
        private IWebElement checkboxSelectAll;

        [FindsBy(How = How.Id, Using = "btnReleaseSelectedBarcodes")]
        private IWebElement btnReleaseSelectedBarcodesTop;

        [FindsBy(How = How.Id, Using = "btnReleaseSelection")]
        private IWebElement btnReleaseSelectedBarcodesBottom;        

        [FindsBy(How = How.ClassName, Using = "list__item__checkbox mat-checkbox mat-accent mat-checkbox-anim-unchecked-checked mat-checkbox-checked")]
        private IList<IWebElement> checkboxSelectedList;

        [FindsBy(How = How.Id, Using = "btnPrevious")]
        private IWebElement btnPrevious;

        [FindsBy(How = How.Id, Using = "btnNext")]
        private IWebElement btnNext;

        [FindsBy(How = How.Id, Using = "btnClearFilter")]
        private IWebElement btnClearFilter;

        [FindsBy(How = How.Id, Using = "btnReleaseSelection")]
        private IWebElement btnReleaseSelection;

        [FindsBy(How = How.Id, Using = "btnRelease")]
        private IWebElement btnReleaseSingleBarcode;

        [FindsBy(How = How.XPath, Using = "//*[starts-with(@id, 'mat-input-')]")]
        private IList<IWebElement> barcodesList;

        [FindsBy(How = How.Id, Using = "txtPageNumber")]
        private IWebElement txtPageNumber;

        #endregion


        /// <summary>
        /// Initializes a new instance of the <see cref="UnreleasedResultPage"/> class.
        /// </summary>
        /// <param name="setUpWebDriver">The set up web driver.</param>
        public UnreleasedResultPage(ISetUp setUpWebDriver)
            : base(setUpWebDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }


        /// <summary>
        /// Determines whether [is at reports page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at reports page]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtUnreleasedResultPage()
        {
            this.WaitUntil(2);
            AreAllBarcodesVisible();
            return IsElementEnabled(inputFilter);
        }

        /// <summary>
        /// Send 'barcode' to the filter input
        /// </summary>
        public void FilterByBarcode(string barcode)
        {
            ClearElement(inputFilter);
            SendKeysElement(inputFilter,barcode);
        }

        /// <summary>
        /// Click in Clear Filter button
        /// </summary>
        public void ClearFilter()
        {
            ClickElement(btnClearFilter);
        }

        /// <summary>
        /// Click in previous page button
        /// </summary>
        public void ClickPreviousPageButton()
        {
            ClickElement(btnPrevious);
        }

        /// <summary>
        /// Click in previous page button
        /// </summary>
        public void ClickNextPageButton()
        {
            ClickElement(btnNext);
        }

        /// <summary>
        /// Click in Select all Barcodes
        /// </summary>
        public void ClickSelectAllBarcodes()
        {
            this.WaitUntil(1);
            ClickElement(checkboxSelectAll);
        }

        /// <summary>
        /// Return a random existing Barcode
        /// </summary>
        public string GetExistingBarcode()
        {
            Random rand = new Random();
            int randomExistingBarcodePosition = rand.Next(0, (barcodesList.Count) - 1);

            return barcodesList[randomExistingBarcodePosition].GetAttribute("placeholder");
        }


        /// <summary>
        /// Determines whether [barcodes list are visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at reports page]; otherwise, <c>false</c>.
        /// </returns>
        public bool AreAllBarcodesVisible()
        {
            if (barcodesList.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Determines whether [if all barcodes are selected].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [if all barcodes are selected]; otherwise, <c>false</c>.
        /// </returns>
        public bool AreAllBarcodesSelected()
        {
            if (barcodesList.Count >= 30)
                return true;
            else
                return false;
        }


        /// <summary>
        /// Determines whether [barcodes are filtered].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [barcodes are filtered]; otherwise, <c>false</c>.
        /// </returns>
        public bool AreBarcodesFiltered(string barcode)
        {
            int counter = 0;
            
            for (int i = 0; i < barcodesList.Count; i++)
            {
                if (Equals(barcodesList[i].GetAttribute("placeholder").TrimStart('$'), barcode))
                {
                    if (Equals(barcodesList[i].Enabled, true))
                    {
                        counter = counter + 1;
                    }                    
                }
            }

            if (counter == 1) { return true; }

            else
            {
                Console.WriteLine(" -Barcode " + barcode + " appears " + counter + " times.");
                return false;
            }  
        }

        /// <summary>
        /// Determines whether [is at Next page (2)].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Next page (2)]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtNextPage()
        {
            this.WaitUntil(1);            
            return Equals(txtPageNumber.Text, "Page 2");
        }

        /// <summary>
        /// Determines whether [is at Previous page (1)].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Previous page (1)]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtPreviousPage()
        {
            this.WaitUntil(1);
            return Equals(txtPageNumber.Text, "Page 1");
        }

    }
}
