namespace Roche.Rmdd.HivMonitor.Reporting.Stores
{
    using SimpleIdentityServer.Client;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using SimpleIdentityServer.Core.Common.DTOs.Responses;
    using SimpleIdentityServer.Core.Common.Models;

    internal sealed class TokenStore //: ITokenStore
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private readonly IIdentityServerClientFactory _identityServerClientFactory;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _authority;
        private readonly List<StoredToken> _tokens;

        public TokenStore(string clientId, string clientSecret, string authority)
        {
            _tokens = new List<StoredToken>();
            _identityServerClientFactory = new IdentityServerClientFactory();
            _clientId = clientId;
            _clientSecret = clientSecret;
            _authority = authority;
        }

        public async Task<GrantedToken> GetToken(params string[] scopes)
        {
            try
            {
                await _semaphore.WaitAsync();
                var allScopes = scopes.ToArray();

                var token = _tokens.FirstOrDefault(
                    t =>
                        allScopes.Length == t.Scopes.Count() && allScopes.All(s => t.Scopes.Contains(s)));
                if (token != null)
                {
                    if (DateTime.UtcNow < token.ExpirationDateTime)
                    {
                        return token.GrantedToken;
                    }

                    _tokens.Remove(token);
                }

                var grantedTokenResponse = await _identityServerClientFactory
                    .CreateAuthSelector()
                    .UseClientSecretPostAuth(_clientId, _clientSecret)
                    .UseClientCredentials(allScopes.ToArray())
                    .ResolveAsync($"{_authority}/.well-known/uma2-configuration");

                GrantedToken grantedToken = null;
                if (!string.IsNullOrWhiteSpace(grantedTokenResponse.Content.AccessToken))
                {
                    grantedToken = new GrantedToken
                    {
                        AccessToken = grantedTokenResponse.Content.AccessToken,
                        ExpiresIn = grantedTokenResponse.Content.ExpiresIn,
                        IdToken = grantedTokenResponse.Content.IdToken,
                        RefreshToken = grantedTokenResponse.Content.RefreshToken,
                        Scope = string.Join(",", grantedTokenResponse.Content.Scope),
                        TokenType = grantedTokenResponse.Content.TokenType
                    };
                    _tokens.Add(new StoredToken
                    {
                        GrantedToken = grantedToken,
                        ExpirationDateTime = DateTime.UtcNow.AddSeconds(grantedTokenResponse.Content.ExpiresIn),
                        Scopes = allScopes
                    });
                }

                return grantedToken;
            }
            catch (Exception e)
            {
                throw;
            }

            finally
            {
                _semaphore.Release();
            }
        }


        private class StoredToken
        {
            public StoredToken()
            {
                Scopes = new List<string>();
            }

            public DateTime ExpirationDateTime { get; set; }
            public GrantedToken GrantedToken { get; set; }
            public IEnumerable<string> Scopes { get; set; }
        }
    }
}