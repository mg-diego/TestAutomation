using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The menu page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface IDashboardMenuPage : IPageBase
    {

        /// <summary>
        /// Click in Login button.
        /// </summary>
        void ClickLogoutButton();

        /// <summary>
        /// Click in Reports button.
        /// </summary>
        void ClickReportsButton();

        /// <summary>
        /// Click in Playground button.
        /// </summary>
        void ClickPlaygroundButton();
    }
}
