using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The unreleased result page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface IUnreleasedResultPage : IPageBase
    {

        /// <summary>
        /// Determines whether [is at unreleased result page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at unreleased result page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtUnreleasedResultPage();

        /// <summary>
        /// Send 'barcode' to the filter input
        /// </summary>
        void FilterByBarcode(string barcode);

        /// <summary>
        /// Click in Clear Filter button
        /// </summary>
        void ClearFilter();

        /// <summary>
        /// Click in previous page button
        /// </summary>
        void ClickPreviousPageButton();

        /// <summary>
        /// Click in previous page button
        /// </summary>
        void ClickNextPageButton();

        /// <summary>
        /// Click in Select all Barcodes
        /// </summary>
        void ClickSelectAllBarcodes();

        /// <summary>
        /// Return a random existing Barcode
        /// </summary>
        string GetExistingBarcode();

        /// <summary>
        /// Determines whether [barcodes list are visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at reports page]; otherwise, <c>false</c>.
        /// </returns>
        bool AreAllBarcodesVisible();

        /// <summary>
        /// Determines whether [if all barcodes are selected].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [if all barcodes are selected]; otherwise, <c>false</c>.
        /// </returns>
        bool AreAllBarcodesSelected();

        /// <summary>
        /// Determines whether [barcodes are filtered].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [barcodes are filtered]; otherwise, <c>false</c>.
        /// </returns>
        bool AreBarcodesFiltered(string barcode);

        /// <summary>
        /// Determines whether [is at Next page (2)].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Next page (2)]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtNextPage();

        /// <summary>
        /// Determines whether [is at Previous page (1)].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Previous page (1)]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtPreviousPage();

    }
}
