using System;
using System.Diagnostics.CodeAnalysis;
using AC.Contracts.Pages;
using DF.Entities;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace US.AcceptanceTests.Steps.QuickPickUp
{
    /// <summary>
    /// The QuickPickUp steps.
    /// </summary>
    /// <seealso cref="US.AcceptanceTests.Steps.StepBase" />
    [Binding]
    public class QuickPickUpSteps : StepBase
    {
        private readonly IQuickPickUpPage quickPickUpPage;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuickPickUpSteps" /> class.
        /// </summary>
        /// <param name="quickPickUpPage">The QuickPickUp pass page.</param>
        public QuickPickUpSteps(IQuickPickUpPage quickPickUpPage)
        {
            this.quickPickUpPage = quickPickUpPage;
        }


        /// <summary>
        /// The user clicks in Show All Past Results.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [When(@"The user click in Show All Past Results")]
        public void TheUserClicksShowAllPastResult()
        {
            quickPickUpPage.ShowAllPastResults();
        }


        /// <summary>
        /// The Quick Pick-up is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Quick Pick-up page of the '(.*)' is opened")]
        public void TheQuickPickUpIsOpened(string user)
        {
            var userLogin = this.GetLoginUser(user);
            try
            {
                this.quickPickUpPage.IsAtQuickPickUpPage(userLogin).Should().BeTrue();
            }
            catch (Exception e)
            {
                throw new Exception($"The Quick Pick-up page of {user} is not opened.", e);
            }

        }


        /// <summary>
        /// The All Past Results is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The All Past Results of the '(.*)' is opened")]
        public void TheAllPastResultsOptionIsOpened(string user)
        {
            var userLogin = this.GetLoginUser(user);
            this.quickPickUpPage.IsShowAllPastResultsOpened(userLogin).Should().BeTrue();
        }

        /*
        /// <summary>
        /// The Quick Pick-up is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The Quick Pick-up menu is opened")]
        public void TheQuickPickUpIsOpened()
        {
            var isQuickPickUpEnabled = this.quickPickUpPage.IsAtQuickPickUpPage();
            isQuickPickUpEnabled.Should().BeTrue();
        }
        

        /// <summary>
        /// The All Past Results is opened.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        [Then(@"The All Past Results option is opened")]
        public void TheAllPastResultsOptionIsOpened()
        {
            var isShowAllPastResultsOpened = this.quickPickUpPage.IsShowAllPastResultsOpened();
            isShowAllPastResultsOpened.Should().BeTrue();
        }
        */
    }
}
