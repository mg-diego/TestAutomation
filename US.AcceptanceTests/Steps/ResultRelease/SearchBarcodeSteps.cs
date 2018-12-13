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
    public class SearchBarcodeSteps : StepBase
    {
        private readonly ISearchBarcodePage searchBarcodePage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBarcodeSteps" /> class.
        /// </summary>
        /// <param name="setUp">The setup page.</param>
        /// <param name="searchBarcodePage">The search barcode page.</param>
        public SearchBarcodeSteps(ISetUp setUp, ISearchBarcodePage searchBarcodePage)
        {
            this.searchBarcodePage = searchBarcodePage;
            this.setUp = setUp;
        }


        /// <summary>
        /// The user releases the 'BARCODE' barcode.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user releases the '(.*)' barcode")]
        [When(@"The user releases the '(.*)' barcode")]
        public void TheUserReleaseBarcode(string barcode)
        {
            searchBarcodePage.InputBarcode(barcode);
            searchBarcodePage.ClickSearchButton();
            searchBarcodePage.ClickReleaseButton();
        }

        /// <summary>
        /// The user unreleases the 'BARCODE' barcode.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user unreleases the '(.*)' barcode")]
        [When(@"The user unreleases the '(.*)' barcode")]
        public void TheUserUnreleaseBarcode(string barcode)
        {
            searchBarcodePage.InputBarcode(barcode);
            searchBarcodePage.ClickSearchButton();
            searchBarcodePage.ClickUnreleaseButton();
        }

        /// <summary>
        /// The Search Barcode tab is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Search Barcode tab is opened")]
        public void TheSearchBarcodeIsOpened()
        {
            searchBarcodePage.IsAtSearchBarcodePage().Should().BeTrue();
        }


        /// <summary>
        /// The barcode 'barcode' is released.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The barcode '(.*)' is released")]
        public void TheBarcodeIsReleased(string barcode)
        {
            searchBarcodePage.IsAtReleasedPopUpMessage().Should().BeTrue();
            searchBarcodePage.AcceptPopUpMessage();
        }

        /// <summary>
        /// The barcode 'barcode' is unreleased.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The barcode '(.*)' is unreleased")]
        public void TheBarcodeIsUnreleased(string barcode)
        {
            searchBarcodePage.IsAtUnreleasedPopUpMessage().Should().BeTrue();
            searchBarcodePage.AcceptPopUpMessage();
        }

        /// <summary>
        /// The barcode 'barcode' is not released.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The barcode '(.*)' is not released")]
        public void TheBarcodeIsNotReleased(string barcode)
        {
            searchBarcodePage.IsAtAlreadyReleasedPopUpMessage().Should().BeTrue();
            searchBarcodePage.AcceptPopUpMessage();
        }


        /// <summary>
        /// The barcode 'barcode' is not unreleased.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The barcode '(.*)' is not unreleased")]
        public void TheBarcodeIsNotUnreleased(string barcode)
        {
            searchBarcodePage.IsAtAlreadyUnreleasedPopUpMessage().Should().BeTrue();
            searchBarcodePage.AcceptPopUpMessage();
        }
        

        




        /// <summary>
        /// Leaves the barcode already unreleased in RELEASED status.
        /// </summary>
        [AfterScenario("@AfterScenarioWithReleaseBarcode")]
        public void AfterScenarioWithReleaseBarcode()
        {
            TheUserReleaseBarcode("$KUCS0928U");
            TheBarcodeIsReleased("$KUCS0928U");
            setUp.CloseDriver();
            setUp.ReopenBrowser();
        }


        /// <summary>
        /// Leaves the barcode already released in UNRELEASED status.
        /// </summary>
        [AfterScenario("@AfterScenarioWithUnreleaseBarcode")]
        public void AfterScenarioWithUnreleaseBarcode()
        {
            TheUserUnreleaseBarcode("BBEV0503K");
            TheBarcodeIsUnreleased("BBEV0503K");
            setUp.CloseDriver();
            setUp.ReopenBrowser();
        }


    }
}
