using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Settings page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />

    public interface IAboutPage : IPageBase
    {
        /// <summary>
        /// Determines whether [is at About info page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at About info page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtAboutIThembaPage();

        /// <summary>
        /// Determines whether [is Contact EMail correct]
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Contact EMail correct]; otherwise, <c>false</c>.
        /// </returns>
        bool IsContactMailCorrect();

        /// <summary>
        /// Determines whether [is Contact Phone correct]
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is Contact Phone correct]; otherwise, <c>false</c>.
        /// </returns>
        bool IsContactPhoneCorrect();

    }
}
