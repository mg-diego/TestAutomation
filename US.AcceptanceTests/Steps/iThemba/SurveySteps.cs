using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts;
using AC.Contracts.Pages;
using CL.Configuration;
using CL.Containers;
using DF.Entities;
using FluentAssertions;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace US.AcceptanceTests.Steps
{
    /// <summary>
    /// The Survey steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class SurveySteps : StepBase
    {
        private readonly ISurveyPage surveyPage;
        private readonly ISetUp setUp;
        private readonly IAnalytics analytics;

        /// <summary>
        /// Initializes a new instance of the <see cref="SurveySteps" /> class.
        /// </summary>
        /// <param name="setUp">The set up.</param>
        /// <param name="surveyPage">The survey page.</param>

        public SurveySteps(ISetUp setUp, ISurveyPage surveyPage, IAnalytics analytics)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.surveyPage = surveyPage;
            this.setUp = setUp;
            this.analytics = analytics;
        }

        #region .: Steps :.

        /// <summary>
        /// The user closes the Survey
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user closes the Survey")]
        public void TheUserCloseSurvey()
        {
            surveyPage.ClickCloseSurvey();
        }

        /// <summary>
        /// The user confirms the Survey
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user confirms the Survey")]
        public void TheUserConfirmSurvey()
        {
            surveyPage.ClickConfirmSurvey();
        }

        /// <summary>
        /// The 3rd login survey appears
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The 3rd login survey appears for the user '(.*)'")]
        public void TheLoginSurveyAppears(string user)
        {
            var loginUser = this.GetLoginUser(user);

            surveyPage.IsAtLoginSurvey();
            TheUserFulfillRandomSurveyValue();
            TheUserConfirmSurvey();

            var resultLogin = analytics.GetAnalyticUserLoggedInFromDatabase(loginUser);
            analytics.IsAnalyticUserLoggedInSaved(resultLogin, loginUser);

            var resultSurvey = analytics.GetAnalyticExperienceRatedFromDatabase(loginUser);
            analytics.IsAnalyticLoginSurveySaved(resultSurvey, loginUser);
        }

        /// <summary>
        /// The user fulfill a random survey value
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user fulfill a random survey value")]
        public void TheUserFulfillRandomSurveyValue()
        {
            setUp.SelectRandomSurveyValue(
                surveyPage.GetRatingBarInitialLocationX(),
                surveyPage.GetRatingBarFinalLocationX(),
                surveyPage.GetRatingBarWidthY());            
        }

        #endregion

    }
}
