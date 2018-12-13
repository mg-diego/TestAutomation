using DF.Entities;


namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Settings page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />

    public interface IUserProfilePage : IPageBase
    {

        #region .: Gender / Age :.

        /// <summary>
        /// Save Gender/Age at My Profile
        /// </summary>
        void SaveGenderAgeInfo();


        /// <summary>
        /// Select a random gender.
        /// </summary>
        void SelectRandomGender();

        /// <summary>
        /// Get Age selector total width.
        /// </summary>
        int GetAgeSelectorTotalWidth();

        /// <summary>
        /// Get Age selector X width.
        /// </summary>
        int GetAgeSelectorWidthX();

        /// <summary>
        /// Get Age selector Y width.
        /// </summary>
        int GetAgeSelectorWidthY();

        /// <summary>
        /// Determines whether [is at My profile Gender/Age info page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at My profile Gender/Age info page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtGenderAgeProfilePage();

        /// <summary>
        /// Determines whether [is Gender/Age button is enabled].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Gender/Age button is enabled]; otherwise, <c>false</c>.
        /// </returns>
        bool IsConfirmGenderAgeEnabled();

        #endregion


        #region .: Clinic Location :.

        /// <summary>
        /// Save Clinic Location at My Profile
        /// </summary>
        void SaveClinicLocationInfo();

        /// <summary>
        /// Determines whether [is at My profile Clinic Location info page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at My profile Clinic Location info page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtClinicLocationProfilePage();

        /// <summary>
        /// Determines whether [is Clinic Location button is enabled].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Clinic Location button is enabled]; otherwise, <c>false</c>.
        /// </returns>
        bool IsConfirmClinicLocationEnabled();

        /// <summary>
        /// Click EXIT at Location info.
        /// </summary>
        void ClickExitLocationInfo();

        /// <summary>
        /// Click Next at demographic info page, My Profile
        /// </summary>
        void ClickNextAtDemographInfoPage();

        /// <summary>
        /// Click PREVIOUS at Location info.
        /// </summary>
        void ClickPreviousAtLocationInfo();

        /// <summary>
        /// Determines whether [demographic info at My Profile is correct].
        /// </summary>
        void IsDemographicInfoCorrect(UserLogin user);

        /// <summary>
        /// Determines whether [clinic location info at My Profile is correct].
        /// </summary>
        void IsClinicLocationPageInfoCorrect(UserLogin user);

        #endregion
    }
}