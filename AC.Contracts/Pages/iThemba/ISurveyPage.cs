using DF.Entities;
using System.Collections.Generic;

namespace AC.Contracts.Pages
{
    /// <summary>
    /// The Likert Survey page interface.
    /// </summary>
    /// <seealso cref="AC.Contracts.IPageBase" />
    /// 
    public interface ISurveyPage : IPageBase
    {
        /// <summary>
        /// Determines whether [is at Login survey].
        /// </summary>
        void IsAtLoginSurvey();

        /// <summary>
        /// Clicks Confirm Survey
        /// </summary>
        void ClickConfirmSurvey();

        /// <summary>
        /// Clicks Close Survey
        /// </summary>
        void ClickCloseSurvey();

        /// <summary>
        /// Get rating bar total width.
        /// </summary>
        int GetRatingBarFinalLocationX();

        /// <summary>
        /// Get rating bar X width.
        /// </summary>
        int GetRatingBarInitialLocationX();

        /// <summary>
        /// Get rating bar Y width.
        /// </summary>
        int GetRatingBarWidthY();
    }
}
