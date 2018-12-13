using DF.Entities;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The reports page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    public interface IDashboardReportsPage : IPageBase
    {
        /// <summary>
        /// Determines whether [is at reports page].
        /// </summary>
        /// <returns>
        /// <c>true</c> if [is at reports page]; otherwise, <c>false</c>.
        /// </returns>
        bool IsAtReportsPage();

        /// <summary>
        /// Click in device CAPCTM.
        /// </summary>
        void ClickDeviceCAPCTM();

        /// <summary>
        /// Click in device Cobas6800_8800.
        /// </summary>
        void ClickDeviceCobas6800_8800();

        /// <summary>
        /// Click in device Cobas4800.
        /// </summary>
        void ClickDeviceCobas4800();
    }
}
