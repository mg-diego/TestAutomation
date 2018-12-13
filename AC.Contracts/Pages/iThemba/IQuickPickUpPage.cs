using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Quick Pick-up interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    /// 
    public interface IQuickPickUpPage
    {
        /// <summary>
        /// Determines whether [is at Quick Pick-up page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at Quick Pick-up page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtQuickPickUpPage(UserLogin user);

        /// <summary>
        /// Open the Show All Past Results
        /// </summary>
        void ShowAllPastResults();

        /// <summary>
        /// Determines whether [is Show All Past Results page is opened].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Show All Past Results page is opened]; otherwise, <c>false</c>.
        /// </returns>
        bool IsShowAllPastResultsOpened(UserLogin user);
    }
}
