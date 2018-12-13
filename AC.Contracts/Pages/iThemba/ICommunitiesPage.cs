using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Chat with Communities interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    /// 
    public interface ICommunitiesPage : IPageBase
    {
        /// <summary>
        /// Determines whether [is at chat with communities page].
        /// </summary>
        void IsAtCommunitiesPage();

        /// <summary>
        /// Join a random Whatsapp Chat Community.
        /// </summary>
        void JoinRandomCommunity();

        /// <summary>
        /// Determines whether WhatsApp is launched.
        /// </summary>
        /// <returns>
        /// <c>true</c> if [iWhatsApp app is launched]; otherwise, <c>false</c>.
        /// </returns>
        bool CheckWhatsappIsLaunched();

        /// <summary>
        /// Determines whether WhatsApp groups are correct.
        /// </summary>
        /// <returns>
        void AreWhatsappGroupsCorrect(UserLogin userLogin, string gender, string location);
    }
}
