namespace US.EndPointTests.AdditionalFunctionalities
{
    using System.Threading.Tasks;
    using SimpleIdentityServer.Client.Selectors;
    using SimpleIdentityServer.Core.Common.DTOs.Responses;

    public class TokenService
    {
        private const string WellKnownOpenidConfiguration = "https://identitystaging.projectschweitzer.net/.well-known/openid-configuration";
        private readonly ITokenGrantTypeSelector _authSelector;

        public TokenService()
        {
            var clientFactory = new SimpleIdentityServer.Client.IdentityServerClientFactory();
            _authSelector = clientFactory.CreateAuthSelector().UseClientSecretPostAuth("ReportingDashboard", "{E9mmLnrZmrM!]~$");
        }

        public async Task<GrantedTokenResponse> GetAuthToken(string username, string password)
        {
            var tokenClient = _authSelector
                     .UsePassword(username, password, "openid scim role");
            var result = await tokenClient.ResolveAsync(
                WellKnownOpenidConfiguration).ConfigureAwait(false);
            return result.Content;
        }

        public async Task<GrantedTokenResponse> RefreshAuthToken(string refreshToken)
        {
            var tokenClient = _authSelector.UseRefreshToken(refreshToken);
            var result = await tokenClient.ResolveAsync(WellKnownOpenidConfiguration).ConfigureAwait(false);
            return result.Content;
        }
    }
}