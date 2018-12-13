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

namespace US.AcceptanceTests.Steps
{
    /// <summary>
    /// The Result Release menu steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class MenuSteps : StepBase
    {
        private readonly IMenuPage menuPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuSteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        /// <param name="UnreleasedResultPage">The unreleased results page.</param>
        public MenuSteps(IMenuPage menuPage)
        {
            this.menuPage = menuPage;
        }


        /// <summary>
        /// The user opens Unreleased Result
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens Unreleased Result")]
        [When(@"The user opens Unreleased Result")]
        public void TheUserOpenUnreleasedResult()
        {
            menuPage.OpenSearchBarcode();
            menuPage.OpenUnreleasedResults();
        }


        /// <summary>
        /// The user opens Search Barcode
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user opens Search Barcode")]
        [When(@"The user opens Search Barcode")]
        public void TheUserOpenSearchBarcode()
        {
            menuPage.OpenSearchBarcode();
        }


        /// <summary>
        /// The user clicks Logout
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in Logout")]
        public void TheUserClicksLogout()
        {
            menuPage.ClickLogout();
        }

    }
}
