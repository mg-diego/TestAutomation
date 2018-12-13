using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Scan Barcode page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    /// 
    public interface IScanBarcodePage : IPageBase
    {
        /// <summary>
        /// Determines whether [mobile camera is open].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [camera is open]; otherwise, <c>false</c>.
        /// </returns>
        bool IsCameraOpened();

        /// <summary>
        /// Determines whether [mobile camera is closed].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [camera is closed]; otherwise, <c>false</c>.
        /// </returns>
        bool IsCameraClosed();

        /// <summary>
        /// Clicks the Close button after error scanning.
        /// </summary>
        void ClickGotItButtonBarcodeScanFailed();

        /// <summary>
        /// Wait until camera timeout (3m).
        /// </summary>
        void WaitForCameraTimeout(int seconds);

        /// <summary>
        /// Determines whether [is at scanning timeout].
        /// </summary>
        void IsAtScanningTimeout();
    }
}
