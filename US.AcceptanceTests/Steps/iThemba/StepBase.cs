using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using DF.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace US.AcceptanceTests.Steps
{
    /// <summary>
    /// The step base.
    /// </summary>
    [TestClass]
    public class StepBase : TechTalk.SpecFlow.Steps
    {
        private const string UsersFile = @"TestData\Users.json";
        private const string AnonymousDataFile = @"TestData\AnonymousData.json";
        private static TestContext context;

        private IEnumerable<UserLogin> loginUsers;

        public TestContext CurrentTestContext => context;

		/// <summary>
		/// Gets the login users.
		/// </summary>
		public IEnumerable<UserLogin> LoginUsers
        {
            get
            {
                if (this.loginUsers == null)
                {
                    this.loginUsers = this.LoadUsers();
                }

                return this.loginUsers;
            }
        }

        /// <summary>
        /// The assembly init.
        /// </summary>
        /// <param name="testContext">
        /// The context.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext testContext)
        {
            if (context == null)
            {
                context = testContext;		
            }
        }


        /// <summary>
        /// Gets the login user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// The <see cref="UserLogin"/>
        /// </returns>
        public UserLogin GetLoginUser(string user)
        {
            if (this.loginUsers == null)
            {
                this.loginUsers = this.LoadUsers();
            }

            return this.loginUsers.FirstOrDefault(i => i.UserId == user);
        }

        private IEnumerable<UserLogin> LoadUsers()
        {
            using (var file = File.OpenText(UsersFile))
            {
                var serializer = new JsonSerializer();
                return (List<UserLogin>)serializer.Deserialize(file, typeof(List<UserLogin>));
            }
        }
    }
}
