using DF.Entities;
using System.Collections.Generic;

namespace AC.Contracts
{
    /// <summary>
    /// Analytics checks.
    /// </summary>
    public interface IAnalytics
    {
        #region .: Experience Rated :.

        /// <summary>
        /// GetAnalyticExperienceRatedFromDatabase
        /// </summary>
        Dictionary<string, string> GetAnalyticExperienceRatedFromDatabase();

        /// <summary>
        /// Check if Login Survey Analytic has been saved at DB
        /// </summary>
        void IsAnalyticLoginSurveySaved(Dictionary<string, string> results, UserLogin userLogin);

        #endregion

        #region .: BarcodeScanFailed :.

        /// <summary>
        /// GetAnalyticBarcodeScanFailedFromDatabase
        /// </summary>
        Dictionary<string, string> GetAnalyticBarcodeScanFailedFromDatabase();

        /// <summary>
        /// Check if Barcode Scan Failed Analytic has been saved at DB
        /// </summary>
        void IsAnalyticBarcodeScanFailedSaved(Dictionary<string, string> results);

        #endregion

        #region .: FailedLoginAttempts :.

        /// <summary>
        /// GetAnalyticFailedLoginAttemptsFromDatabase
        /// </summary>
        Dictionary<string, string> GetAnalyticFailedLoginAttemptsFromDatabase();

        /// <summary>
        /// Check if Failed Login Attempts Analytic has been saved at DB
        /// </summary>
        void IsAnalyticFailedLoginAttemptsSaved(Dictionary<string, string> results);

        #endregion

        #region .: WhatsappJoined :.

        /// <summary>
        /// GetAnalyticWhatsappJoinedFromDatabase
        /// </summary>
        Dictionary<string, string> GetAnalyticWhatsappJoinedFromDatabase();

        /// <summary>
        /// Check if Whatsapp Joined Analytic has been saved at DB
        /// </summary>
        void IsAnalyticWhatsappJoinedSaved(Dictionary<string, string> results);

        #endregion

        #region .: UserLoggedIn :.

        /// <summary>
        /// GetAnalyticUserLoggedInFromDatabase
        /// </summary>
        Dictionary<string, string> GetAnalyticUserLoggedInFromDatabase();

        /// <summary>
        /// Check if UserLoggedIn Analytic has been saved at DB
        /// </summary>
        void IsAnalyticUserLoggedInSaved(Dictionary<string, string> results, UserLogin user);

        #endregion

        #region .: BarcodeDataRequested :.

        /// <summary>
        /// GetAnalyticBarcodeDataRequestedFromDatabase
        /// </summary>
        Dictionary<string, string> GetAnalyticBarcodeDataRequestedFromDatabase();

        /// <summary>
        /// Check if BarcodeDataRequested Analytic has been saved at DB
        /// </summary>
        void IsAnalyticBarcodeDataRequestedSaved(Dictionary<string, string> results, UserLogin user);

        #endregion
    }
}
