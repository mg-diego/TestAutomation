using DF.Entities;
using System.Collections.Generic;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The blood results page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />

    public interface IBloodResultsPage : IPageBase
    {
        #region .: General Methods :.

        /// <summary>
        /// Determines whether [is at blood results page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at blood results page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtBloodResultsPage();
        
        #endregion

        #region .: User Less Than 50 :.

        /// <summary>
        /// Determines whether [is at less than 50 cp/ml blood results page].
        /// </summary>
        void IsAtLessThan50ResultsPage(UserLogin user);

        #endregion

        #region .: User Between 50-1000 :.

        /// <summary>
        /// Determines whether [is at 50-1000 cp/ml blood results page].
        /// </summary>
        void IsAt50_1000ResultsPage(UserLogin user);

        #endregion

        #region .: User More Than 1000 :.

        /// <summary>
        /// Determines whether [is at more than 1000 cp/ml blood results page].
        /// </summary>
        void IsAtMoreThan1000ResultsPage(UserLogin user);

        #endregion

        #region .: No Result :.

        /// <summary>
        /// Clicks the Show Barcode button
        /// </summary>
        void ClickShowBarcode();

        /// <summary>
        /// Clicks the Close Barcode button
        /// </summary>
        void ClickCloseBarcode();

        /// <summary>
        /// Determines whether [is at Barcode View screen].
        /// </summary>
        void IsAtBarcodeView(UserLogin user);

        /// <summary>
        /// Clicks the YES, EXIT button from pop up exit window
        /// </summary>
        void ClickGoToScanner();

        /// <summary>
        /// Determines whether [is at Scan first Barcode page].
        /// </summary>
        void IsAtScanFirstBarcodePage();

        #endregion

        #region .: ResultsOnTheWay :.

        /// <summary>
        /// Clicks the Go To Community button
        /// </summary>
        void ClickGoToCommunity();

        /// <summary>
        /// Clicks the Close banner Results on the Way
        /// </summary>
        void ClickCloseBannerResultsOnTheWay();

        /// <summary>
        /// Determines whether [is at results on the way page].
        /// </summary>
        void IsAtResultsOnTheWayPage(UserLogin user);

        /// <summary>
        /// Determines whether [results on the way banner is visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [results on the way banner is visible]; otherwise, <c>false</c>.
        /// </returns>
        bool IsResultsOnTheWayBannerVisible();

        #endregion

        #region .: Past Results :.

        /// <summary>
        /// Clicks the Go To Past Results
        /// </summary>
        void ClickGoToPastResults();

        /// <summary>
        /// Clicks the Exit Past Results
        /// </summary>
        void ClickExitPastResults();

        /// <summary>
        /// Determines whether [is at Past Results screen].
        /// </summary>
        void IsAtPastResults();

        /// <summary>
        /// Determines whether horizontal Past Results dates are OK
        /// </summary>
        /// <returns>
        /// <c>true</c> if [horizontal Past Results dates are OK]; otherwise, <c>false</c>.
        /// </returns>
        void AreHorizontalPastResultsDatesOk(UserLogin user);

        /// <summary>
        /// Determines whether vertical Past Results dates are OK
        /// </summary>
        /// <returns>
        /// <c>true</c> if [vertical Past Results dates are OK]; otherwise, <c>false</c>.
        /// </returns>
        void AreVerticalPastResultsDatesOk(UserLogin user);

        /// <summary>
        /// Determines whether vertical Past Results are OK
        /// </summary>
        /// <returns>
        /// <c>true</c> if [vertical Past Results are OK]; otherwise, <c>false</c>.
        /// </returns>
        void ArePastResultsValuesOk(UserLogin user);

        /// <summary>
        /// Determines whether is at Past Results with imported results
        /// </summary>
        /// <returns>
        void IsAtPastResultsWithImportedResults();

        /// <summary>
        /// Determines whether is at Past Results with invalid results
        /// </summary>
        /// <returns>
        void IsAtPastResultsWithInvalidResults();

        #endregion

        #region .: Exit iThemba :.

        /// <summary>
        /// Clicks the YES, EXIT button from the pop up exit window
        /// </summary>
        void ClickYesExit();

        /// <summary>
        /// Clicks the NO button from the pop up exit window
        /// </summary>
        void ClickNoButtonFromExitMenu();

        /// <summary>
        /// Determines whether Exit iThemba pop up message is displayed
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Exit iThemba pop up message is displayed]; otherwise, <c>false</c>.
        /// </returns>
        bool IsExitMessageDisplayed();

        #endregion

        #region .: Invalid Results :.

        /// <summary>
        /// Determines whether [is at Unique Invalid Blood Results page].
        /// </summary>
        void IsAtUniqueInvalidBloodResultsPage(UserLogin userLogin);

        /// <summary>
        /// Determines whether [is at Multiple Invalid Blood Results page].
        /// </summary>
        void IsAtMultipleInvalidBloodResultsPage(UserLogin userLogin);

        #endregion
    }
}
