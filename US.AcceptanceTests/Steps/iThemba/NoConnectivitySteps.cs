using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Configuration;
using CL.Containers;
using DF.Entities;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.NoConnectivity
{
    /// <summary>
    /// The no connectivity steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class NoConnectivitySteps : StepBase
    {
        private readonly INoConnectivityPage noConnectivityPage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoConnectivitySteps" /> class.
        /// </summary>
        /// <param name="noConnectivityPage">The chat with communities page.</param>
        public NoConnectivitySteps(INoConnectivityPage noConnectivityPage, ISetUp setUp)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.noConnectivityPage = noConnectivityPage;
            this.setUp = setUp;
        }

        /// <summary>
        /// The user recovers Network and click in Try Again.
        /// </summary>
        [Given(@"The user loses Connectivity")]
        [When(@"The user loses Connectivity")]
        [Then(@"The user loses Connectivity")]
        public void TheUserLosesConnectivity()
        {
            setUp.SetAirplaneMode();
        }

        /// <summary>
        /// The user recovers Network and click in Try Again.
        /// </summary>
        [Given(@"The user recovers Connectivity")]
        [When(@"The user recovers Connectivity")]
        [Then(@"The user recovers Connectivity")]
        public void TheUserRecoverConnectivity()
        {
            setUp.SetAllNetworkMode();
        }

        /// <summary>
        /// The user can see the No connection to network message.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can see the No connection to network message")]
        public void TheUserCanSeeNoNetworkScreen()
        {
            noConnectivityPage.IsAtNoConnectivityPage();
        }

        /// <summary>
        /// The user recovers Network and click in Try Again.
        /// </summary>
        [When(@"The user click in Try Again")]
        [Then(@"The user click in Try Again")]
        public void TheUserTriesToLoginWithTheFollowingUser()
        {
            noConnectivityPage.ClickTryConnectionAgain();
        }
    }
}
