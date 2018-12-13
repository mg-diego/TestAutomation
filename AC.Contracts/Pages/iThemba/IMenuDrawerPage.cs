using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The menu drawer page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    /// 
    public interface IMenuDrawerPage : IPageBase
    {
        /// <summary>
        /// Opens the Drawer Menu.
        /// </summary>
        void OpenDrawerMenu();

        /// <summary>
        /// Opens the Blood Results Menu.
        /// </summary>
        void OpenBloodResults();

        /// <summary>
        /// Opens Scan Bar Code Menu.
        /// </summary>
        void OpenScanBarcode();

        /// <summary>
        /// Opens Chat with communities Menu.
        /// </summary>
        void OpenChatWithCommunities();

        /// <summary>
        /// Opens Quick Pick-up Menu.
        /// </summary>
        void OpenVipClinicPass();

        /// <summary>
        /// Opens My Profile Menu.
        /// </summary>
        void OpenMyProfile();

        /// <summary>
        /// Open About iThemba Menu
        /// </summary>
        void ClickAboutIthemba();

        /// <summary>
        /// Logout from the iThemba app
        /// </summary>
        void ClickLogout();

        /// <summary>
        /// Determines whether [is at menu drawer page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at menu drawer page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtMenuDrawerPage();

        /// <summary>
        /// Determines whether [is Quick Pick-up menu visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Quick Pick-up menu visible]; otherwise, <c>false</c>.
        /// </returns>
        bool IsVipClinicPassVisible();

        /// <summary>
        /// Determines whether [is Quick Pick-up menu not visible].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Quick Pick-up menu not visible]; otherwise, <c>false</c>.
        /// </returns>
        bool IsVipClinicPassNotVisible();
    }
}
