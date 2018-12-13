namespace US.EndPointTests.AdditionalFunctionalities
{
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TokenServiceTests
    {
        [TestMethod]
        public async Task CanGetTokenForValidUser()
        {
            var service = new TokenService();
            var authToken = await service.GetAuthToken("doctor", "password").ConfigureAwait(false);

            Assert.IsNotNull(authToken);
        }

        [TestMethod]
        public async Task WhenUserIsInvalidThenTokenIsNull()
        {
            var service = new TokenService();
            var authToken = await service.GetAuthToken("blah", "blah").ConfigureAwait(false);

            Assert.IsNull(authToken);
        }
    }
}