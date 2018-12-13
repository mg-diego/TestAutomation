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

namespace US.AcceptanceTests.Steps.UserProfile
    {
    /// <summary>
    /// The My Profile steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class UserProfileSteps : StepBase
    {
        private readonly IUserProfilePage userProfilePage;


        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileSteps" /> class.
        /// </summary>
        /// <param name="userProfilePage">The My Profile page.</param>

        public UserProfileSteps(IUserProfilePage userProfilePage)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.userProfilePage = userProfilePage;
        }

        /// <summary>
        /// The Anonymous Information data is saved.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user saves his information at My Profile")]
        public void TheAnonymousInformationIsSaved()
        {
            TheMyProfileMenuIsOpened();

            //Gender - Age
            //userProfilePage.SelectRandomGender();
            AppContainer.Container.Resolve<ISetUp>().MoveSeekBar(userProfilePage.GetAgeSelectorWidthX(), userProfilePage.GetAgeSelectorTotalWidth(), userProfilePage.GetAgeSelectorWidthY());
            userProfilePage.SaveGenderAgeInfo();

            //Location
            userProfilePage.ClickExitLocationInfo();
        }

        
        /// <summary>
        /// The My Profile menu is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The My Profile menu is opened")]
        [Then(@"The user is at Demographic info page at My Profile")]
        public void TheMyProfileMenuIsOpened()
        {
            userProfilePage.IsAtGenderAgeProfilePage().Should().BeTrue();
        }

        /// <summary>
        /// The My Profile menu is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The user is at Clinic Location page at My Profile")]
        public void TheUserIsAtClinicLocationPageAtMyProfile()
        {
            userProfilePage.IsAtClinicLocationProfilePage().Should().BeTrue();
        }

        /// <summary>
        /// The user clicks Next button at demograph info page.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Given(@"The user clicks Next button at demograph info page")]
        [When(@"The user clicks Next button at demograph info page")]
        public void TheUserClickNextButtonAtDemographInfoPage()
        {
            userProfilePage.ClickNextAtDemographInfoPage();
        }

        /// <summary>
        /// The user clicks Done button at clinic info page.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks Done button at clinic info page")]
        public void TheUserClickDoneButtonAtClinicInfoPage()
        {
            userProfilePage.ClickExitLocationInfo();
        }

        /// <summary>
        /// The user clicks Previous button at clinic info page.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user clicks Previous button at clinic info page")]
        public void TheUserClickPreviousButtonAtClinicInfoPage()
        {
            userProfilePage.ClickPreviousAtLocationInfo();
        }

        /// <summary>
        /// The (.*) see his correct information at My Profile.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The (.*) see his correct information at My Profile")]
        public void TheUserSeeCorrectInformationAtMyProfile(string user)
        {
            var userLogin = this.GetLoginUser(user);
            userProfilePage.IsDemographicInfoCorrect(userLogin);
            userProfilePage.ClickNextAtDemographInfoPage();
            userProfilePage.IsClinicLocationPageInfoCorrect(userLogin);
        }
        



    }
}
