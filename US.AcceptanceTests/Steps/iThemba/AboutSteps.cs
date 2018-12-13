using System.Diagnostics.CodeAnalysis;
using System.Threading;
using AC.Contracts;
using AC.Contracts.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using CL.Configuration;

namespace US.AcceptanceTests.Steps.About
{
    /// <summary>
    /// The About iThemba steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class AboutSteps : StepBase
    {
        private readonly IAboutPage aboutPage;
        private readonly ISetUp setUp;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutSteps" /> class.
        /// </summary>
        /// <param name="aboutPage">The About iThemba page.</param>
        /// <param name="setUp">The set up.</param>
        public AboutSteps(IAboutPage aboutPage, ISetUp setUp)
        {
			TestConfiguration.CurrentScenario = ScenarioContext.Current.ScenarioInfo.Title;

			this.aboutPage = aboutPage;
            this.setUp = setUp;
        }


        /// <summary>
        /// The About iThemba menu is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The About iThemba menu is opened")]
        public void TheAboutIthembaMenuIsOpened()
        {
            aboutPage.IsAtAboutIThembaPage().Should().BeTrue();
        }


        /// <summary>
        /// The About iThemba contact info is correct.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The '(.*)' About iThemba contact info is correct")]
        public void IsContactInfoCorrect(string clinic)
        {
			TheAboutIthembaMenuIsOpened();

			switch (clinic)
			{
				case "Yeoville":
					aboutPage.IsPhoneNumberCorrectYeoville();
					break;
				case "Hillbrow":
					aboutPage.IsPhoneNumberCorrectHillbrow();
					break;
			}
        }


		/// <summary>
		/// The user clicks in Whatsapp Link.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[When(@"The user clicks in Whatsapp Link")]
		public void TheUserClikcsInWhatsappLink()
		{
			aboutPage.ClickWhatsappLinkButton();
		}


		/// <summary>
		/// The user clicks in Whatsapp Link.
		/// </summary>
		[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
		[Then(@"The user is redirect to whatsapp contact phone")]
		public void TheUserIsRedirectToWhatsapp()
		{
			setUp.IsAtPackage("whatsapp");
			setUp.ClickAndroidBack();
			setUp.ClickAndroidBack();
		}
	}
}
