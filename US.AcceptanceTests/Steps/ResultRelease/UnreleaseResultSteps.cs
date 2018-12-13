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
    /// The Unreleased Result steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class UnreleasedResultSteps : StepBase
    {
        private readonly IUnreleasedResultPage UnreleasedResultPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnreleasedResultSteps" /> class.
        /// </summary>
        /// <param name="UnreleasedResultPage">The unreleased results page.</param>
        public UnreleasedResultSteps (IUnreleasedResultPage UnreleasedResultPage)
        {
            this.UnreleasedResultPage = UnreleasedResultPage;
        }


        /// <summary>
        /// The Result Release page is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Result Release page is opened")]
        [Then(@"The Unreleased Result tab is opened")]
        public void TheResultReleaseIsOpened()
        {
            UnreleasedResultPage.IsAtUnreleasedResultPage().Should().BeTrue();
        }


        /// <summary>
        /// The user filter by existing/non "BARCODE" existing barcode.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user filter by existing '(.*)' barcode")]
        [Given(@"The user filter by non existing '(.*)' barcode")]
        [When(@"The user filter by existing '(.*)' barcode")]
        [When(@"The user filter by non existing '(.*)' barcode")]
        public void TheUserFilterByExistingBarcode(string barcode)
        {
            UnreleasedResultPage.FilterByBarcode(barcode);
        }


        /// <summary>
        /// The user filter by existing/non existing barcode.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user filter by existing barcode")]
        [When(@"The user filter by existing barcode")]
        public void TheUserFilterByRandomExistingBarcode(string barcode)
        {
            UnreleasedResultPage.FilterByBarcode(UnreleasedResultPage.GetExistingBarcode());
        }


        /// <summary>
        /// The user clicks in select all barcodes checkbox.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in select all barcodes checkbox")]
        public void TheUserClicksSelectAllBarcodes()
        {
            UnreleasedResultPage.ClickSelectAllBarcodes();
        }


        /// <summary>
        /// All the barcodes of the page are selected.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"All the barcodes of the page are selected")]
        public void AllTheBarcodesAreSelected()
        {
            UnreleasedResultPage.AreAllBarcodesSelected().Should().BeTrue();
        }



        /// <summary>
        /// The user clicks in Clear Filter.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in Clear Filter")]
        public void TheUserClicksClearFilter()
        {
            UnreleasedResultPage.ClearFilter();
        }

        /// <summary>
        /// The user clicks in go to Next page.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user clicks in go to Next page")]
        [When(@"The user clicks in go to Next page")]
        public void TheUserClicksGoToNextPage()
        {
            UnreleasedResultPage.ClickNextPageButton();
        }

        /// <summary>
        /// The user clicks in go to Previous page.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks in go to Previous page")]
        public void TheUserClicksGoToPreviousPage()
        {
            UnreleasedResultPage.ClickPreviousPageButton();
        }


        /// <summary>
        /// The barcodes are filtered by "barcode".
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"Only the '(.*)' barcode appears")]
        public void TheBarcodesAreFiltered(string barcode)
        {
            UnreleasedResultPage.AreBarcodesFiltered(barcode).Should().BeTrue();
        }

        /// <summary>
        /// The user can see all the barcodes.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user can see all the barcodes")]
        public void TheUserCanSeeAllBarcodes()
        {
            UnreleasedResultPage.AreAllBarcodesVisible().Should().BeTrue();
        }

        /// <summary>
        /// The Next page is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Next page is opened")]
        public void TheNextPageIsOpened()
        {
            UnreleasedResultPage.IsAtNextPage().Should().BeTrue();
        }

        /// <summary>
        /// The Next page is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Previous page is opened")]
        public void ThePreviousPageIsOpened()
        {
            UnreleasedResultPage.IsAtPreviousPage().Should().BeTrue();
        }

    }
}
