using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The login page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface ILoginBasePage : IPageBase
    {
        /// <summary>
        /// Click in send phone number button.
        /// </summary>
        void ClickLoginButton();

        /// <summary>
        /// Click in Login button.
        /// </summary>
        void ClickExternalLoginButton();

        /// <summary>
        /// Enter the username.
        /// </summary>
        void EnterUsername(UserLogin user);

        /// <summary>
        /// Enter the username.
        /// </summary>
        void EnterPassword(UserLogin user);

        /// <summary>
        /// Determines whether [is at invalid login page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at invalid login page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtLoginBasePage();

        /// <summary>
        /// Determines whether [is at invalid login page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at invalid login page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtInvalidLogin();
    }
}
