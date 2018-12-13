using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Containers;
using DF.Entities;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps.Communities
{
    /// <summary>
    /// The chat with communities steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class CommunitiesSteps : StepBase
    {
        private readonly ICommunitiesPage communitiesPage;
        private readonly IAnalytics analytics;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunitiesSteps" /> class.
        /// </summary>
        /// <param name="communitiesPage">The chat with communities page.</param>
        public CommunitiesSteps(ICommunitiesPage communitiesPage, IAnalytics analytics)
        {
            this.communitiesPage = communitiesPage;
            this.analytics = analytics;
        }


        /// <summary>
        /// The Chat with Communities is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Chat with Communities is opened")]
        public void TheChatWithCommunitiesIsOpened()
        {
            var isChatWithCommunitiesEnabled = this.communitiesPage.IsAtCommunitiesPage();
            isChatWithCommunitiesEnabled.Should().BeTrue();
        }


        /// <summary>
        /// The user joins a community.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in join a Community")]
        public void TheUserClicksInJoinACommunity()
        {
            communitiesPage.JoinRandomCommunity();            
        }


        /// <summary>
        /// The user joins a community.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user joins a Community")]
        public void TheUserJoinACommunity()
        {
            communitiesPage.CheckWhatsappIsLaunched();
            var result = analytics.GetAnalyticWhatsappJoinedFromDatabase();
            AppContainer.Container.Resolve<ISetUp>().ClickAndroidBack();
            AppContainer.Container.Resolve<ISetUp>().ClickAndroidBack();           
            analytics.IsAnalyticWhatsappJoinedSaved(result);
        }
    }
}
