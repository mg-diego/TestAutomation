using System.Diagnostics.CodeAnalysis;
using AC.Contracts.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using AC.Contracts;
using CL.Configuration;

namespace US.AcceptanceTests.Steps.ScanBarcode
{
    /// <summary>
    /// The scan a barcode steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class ScanBarcodeSteps : StepBase
    {
        private readonly IScanBarcodePage scanBarcodePage;
        private readonly IAnalytics analytics;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScanBarcodeSteps" /> class.
        /// </summary>
        /// <param name="scanBarcodePage">The scan a barcode page.</param>
        public ScanBarcodeSteps(IScanBarcodePage scanBarcodePage, IAnalytics analytics)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.scanBarcodePage = scanBarcodePage;
            this.analytics = analytics;
        }


        /// <summary>
        /// The mobile camera is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The mobile camera is opened")]
        public void TheMobileCameraIsOpened()
        {
            this.scanBarcodePage.IsCameraOpened().Should().BeTrue();
        }


        /// <summary>
        /// The mobile camera is closed.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The mobile camera is closed")]
        public void TheMobileCameraIsClosed()
        {
            this.scanBarcodePage.IsCameraClosed().Should().BeTrue();
        }

        /// <summary>
        /// Wait until camera timeouts (3m)
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The camera timeout expires after (.*) minutes")]
        public void WaitUntilCameraTimeout(int minutes)
        {
            scanBarcodePage.WaitForCameraTimeout(minutes);
        }

        /// <summary>
        /// The try scanning again page is displayed
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"Then Barcode Scan timeout message appears")]
        public void BarcodeScanTimeoutMessageAppears()
        {
            scanBarcodePage.IsAtScanningTimeout();
            var result = analytics.GetAnalyticBarcodeScanFailedFromDatabase();
            scanBarcodePage.ClickGotItButtonBarcodeScanFailed();
            scanBarcodePage.IsCameraOpened();            
            analytics.IsAnalyticBarcodeScanFailedSaved(result);
        }
    }
}
