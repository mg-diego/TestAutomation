
namespace AC.Contracts.Pages
{
    /// <summary>
    /// The No Connectivity page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface INoConnectivityPage : IPageBase 
    {

        /// <summary>
        /// Determines whether [is at no connectivity page].
        /// </summary>
        void IsAtNoConnectivityPage();

        /// <summary>
        /// Click Try Again button
        /// </summary>
        void ClickTryConnectionAgain();
    }
}
