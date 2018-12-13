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

namespace US.AcceptanceTests.Steps.Reports
{
    /// <summary>
    /// The dashboard reports steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class DashboardReportsSteps : StepBase
    {
        private readonly IDashboardReportsPage dashboardReportsPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardReportsSteps" /> class.
        /// </summary>
        /// <param name="dashboardReportsPage">The reports up.</param>
        public DashboardReportsSteps(IDashboardReportsPage dashboardReportsPage)
        {
            this.dashboardReportsPage = dashboardReportsPage;
        }


        /// <summary>
        /// The user is at Reports tab.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Reports tab is opened")]
        [Then(@"The Dashboard page is opened")]
        public void TheUSerIsAtReports()
        {
            dashboardReportsPage.IsAtReportsPage().Should().BeTrue();
        }


        /// <summary>
        /// The user selects a device.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user selects '(.*)' as device")]
        public void TheUSerSelectDevice(string device)
        {
            switch (device)
            {
                case "CAPCTM":
                    dashboardReportsPage.ClickDeviceCAPCTM();
                    break;
                case "cobas 6800/8800":
                    dashboardReportsPage.ClickDeviceCobas6800_8800();
                    break;
                case "cobas 4800":
                    dashboardReportsPage.ClickDeviceCobas4800();
                    break;
                default:
                    break;
            }
        }



    }
}
