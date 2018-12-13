using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Result Release menu page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface IMenuPage : IPageBase
    {

        /// <summary>
        /// Opens Unreleased Results.
        /// </summary>
        void OpenUnreleasedResults();

        /// <summary>
        /// Opens Unreleased Results.
        /// </summary>
        void OpenSearchBarcode();

        /// <summary>
        /// Click Logout.
        /// </summary>
        void ClickLogout();
    }
}
