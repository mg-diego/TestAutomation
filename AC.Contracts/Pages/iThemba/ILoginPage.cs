using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The login page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface ILoginPage : IPageBase
    {

        #region .: 1 - Enter Phone Number :.

        /// <summary>
        /// Determines whether [is at enter phone number page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at enter phone number page]; otherwise, <c>false</c>.
        /// </returns>
        void IsAtEnterPhoneNumberPage();

        /// <summary>
        /// Determines if the main android page is displayed by lookging for the Apps button
        /// </summary>
        /// <returns>
        /// <c>true</c> if [Apps button is displayed]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtMainAndroidPage();

        /// <summary>
        /// Enter the user phone number.
        /// </summary>
        void EnterPhoneNumber(UserLogin user);

        /// <summary>
        /// Check the default phone prefix.
        /// </summary>
        bool CheckDefaultPhonePrefix();

        /// <summary>
        /// Enter the user phone prefix.
        /// </summary>
        void EnterPhonePrefix(UserLogin user);

        /// <summary>
        /// Clear existing phone prefix.
        /// </summary>
        void ClearPhonePrefix();

        /// <summary>
        /// Click in send phone number button.
        /// </summary>
        void ClickSendPhoneNumber();


        /// <summary>
        /// Click in exit button.
        /// </summary>
        void ClickOnExitButton();

        #endregion

        #region .: 2 - Get SMS code :.

        /// <summary>
        /// Click in send code again button.
        /// </summary>
        void ClickSendCodeAgain();

        /// <summary>
        /// Click in go to back button.
        /// </summary>
        void ClickOnBackButton();

        /// <summary>
        /// Click in send confirmation code button.
        /// </summary>
        void ClickSendConfirmationCode();

        /// <summary>
        /// Get the confirmation code.
        /// </summary>
        void GetConfirmationCode(UserLogin user);

        /// <summary>
        /// Input wrong SMS code at inputConfirmationCode
        /// </summary>
        void InputWrongSMSCodeRandomTimes();

        #endregion

        #region .: 3 - Set Gender / Age info :.

        /// <summary>
        /// Determines whether [is at set gender / age info].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at set gender / age info]; otherwise, <c>false</c>.
        /// </returns>
        void IsAtSetGenderAgeInfo();

        /// <summary>
        /// Click SKIP at Profile info.
        /// </summary>
        void ClickSkipProfileInfo();

        /// <summary>
        /// Click CONFIRM at Profile info.
        /// </summary>
        void ClickConfirmProfileInfo();

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

        #endregion

        #region .: 4 - Set Location info :.

        /// <summary>
        /// Determines whether [is at set location info].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at set location info]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtSetLocationInfo();

        /// <summary>
        /// Click SKIP at Location info.
        /// </summary>
        void ClickSkipLocationInfo();

        /// <summary>
        /// Click CONFIRM at Location info.
        /// </summary>
        void ClickConfirmLocationInfo();

        /// <summary>
        /// Click inputCity at Location info.
        /// </summary>
        void ClickInputCityInfo();

        /// <summary>
        /// Click inputNeighbourhood at Location info.
        /// </summary>
        void ClickInputNeighbourhoodInfo();

        /// <summary>
        /// Click inputClinic at Location info.
        /// </summary>
        void ClickInputClinicInfo();

        /// <summary>
        /// Click CANCEL Location info pop-up.
        /// </summary>
        void ClickCancelLocationPopup();

        /// <summary>
        /// Click pop-up option 1.
        /// </summary>
        void SelectRandomPopupOption();

        /// <summary>
        /// Determines whether [is at set location info pop-up].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at set location info pop-up]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtSetLocationInfoPopup();

        #endregion

        #region .: 5 - Complete Login :.

        /// <summary>
        /// Click in go to homepage button.
        /// </summary>
        void ClickGoToHomepage();
        #endregion

    }
}