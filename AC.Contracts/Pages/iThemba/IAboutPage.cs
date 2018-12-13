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
		/// Determines whether [is yeoville phone number correct]
		/// </summary>
		void IsPhoneNumberCorrectYeoville();

		/// <summary>
		/// Determines whether [is hillbrow phone number correct]
		/// </summary>
		void IsPhoneNumberCorrectHillbrow();

		/// <summary>
		/// Click in Whatsapp Link button
		/// </summary>
		void ClickWhatsappLinkButton();

		/// <summary>
		/// Click in Phone Contact button
		/// </summary>
		void ClickContactPhoneNumberButton();
	}
}
