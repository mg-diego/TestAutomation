namespace AC.Contracts.Pages
{
    /// <summary>
    /// The IMainPage interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface IMainPage : IPageBase
    {

        /// <summary>
        /// Determines whether [is at onboard page1].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at onboard page1]; otherwise, <c>false</c>.
        /// </returns>
        void IsAtOnboardPage1();

        /// <summary>
        /// Determines whether [is at onboard page2].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at onboard page2]; otherwise, <c>false</c>.
        /// </returns>
        void IsAtOnboardPage2();

        /// <summary>
        /// Determines whether [is at onboard page3].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at onboard page3]; otherwise, <c>false</c>.
        /// </returns>
        void IsAtOnboardPage3();


        /// <summary>
        /// Click in next button.
        /// </summary>
        void ClickNextButton();

        /// <summary>
        /// Click in sign up button.
        /// </summary>
        void ClickSignUpButton();
    }
}
