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

namespace US.AcceptanceTests.Steps.Menu
{
    /// <summary>
    /// The dashboard menu steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class DashboardMenuSteps : StepBase
    {
        private readonly IDashboardMenuPage dashboardMenuPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="IDashboardMenuPage" /> class.
        /// </summary>
        /// <param name="dashboardMenuPage">The menu up.</param>
        public DashboardMenuSteps(IDashboardMenuPage dashboardMenuPage)
        {
            this.dashboardMenuPage = dashboardMenuPage;
        }

        /// <summary>
        /// The user clicks in the Logout button.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in the Logout button")]
        public void TheUSerClicksLogoutButton()
        {
            dashboardMenuPage.ClickLogoutButton();
        }

        /// <summary>
        /// The user clicks in the Reports button.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in the Reports button")]
        public void TheUSerClicksReportsButton()
        {
            dashboardMenuPage.ClickReportsButton();
        }

        /// <summary>
        /// The user clicks in the Playground button.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in the Playground button")]
        public void TheUSerClicksPlaygroundButton()
        {
            dashboardMenuPage.ClickPlaygroundButton();
        }

    }
}
