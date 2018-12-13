using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The search barcode page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface ISearchBarcodePage : IPageBase
    {
        /// <summary>
        /// Determines whether [is at search barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at search barcode page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtSearchBarcodePage();

        /// <summary>
        /// Input a "barcode" in the input field.
        /// </summary>
        void ClickSearchButton();

        /// <summary>
        /// Input a "barcode" in the input field.
        /// </summary>
        void InputBarcode(string barcode);

        /// <summary>
        /// Click Release button.
        /// </summary>
        void ClickReleaseButton();

        /// <summary>
        /// Click Unrelease button.
        /// </summary>
        void ClickUnreleaseButton();

        /// <summary>
        /// Determines whether [is at released barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at released barcode page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtReleasedPopUpMessage();

        /// <summary>
        /// Determines whether [is at unreleased barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at unreleased barcode page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtUnreleasedPopUpMessage();

        /// <summary>
        /// Determines whether [is at already released barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at already released barcode page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtAlreadyReleasedPopUpMessage();

        /// <summary>
        /// Determines whether [is at already unreleased barcode page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at already unreleased barcode page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtAlreadyUnreleasedPopUpMessage();

        /// <summary>
        /// Click OK button at pop-up message.
        /// </summary>
        void AcceptPopUpMessage();
    }
}
