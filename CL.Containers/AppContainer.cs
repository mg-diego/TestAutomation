using AC.Contracts;
using AC.Contracts.Pages;
using AC.SeleniumDriver;
using AC.SeleniumDriver.Pages.Login;
using AC.SeleniumDriver.Pages;
using Microsoft.Practices.Unity;

namespace CL.Containers
{
    /// <summary>
    /// The App Container dependency injector.
    /// </summary>
    public static class AppContainer
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IUnityContainer Container { get; private set; }

        /// <summary>
        /// Builds the web container.
        /// </summary>
        public static void BuildWebContainer()
        {
            if (Container == null)
            {
                var buildContainer = new UnityContainer();


                buildContainer.RegisterType<IAnalytics, Analytics>();

                buildContainer.RegisterType<ISetUp, SetUpDriver>();                

                buildContainer.RegisterType<ILoginPage, LoginPage>();
                buildContainer.RegisterType<IMainPage, MainPage>();
                buildContainer.RegisterType<IMenuDrawerPage, MenuDrawerPage>();
                buildContainer.RegisterType<IBloodResultsPage, BloodResultsPage>();
                buildContainer.RegisterType<ICommunitiesPage, CommunitiesPage>();
                buildContainer.RegisterType<IScanBarcodePage, ScanBarcodePage>();
                buildContainer.RegisterType<IQuickPickUpPage, QuickPickUpPage>();
                buildContainer.RegisterType<IUserProfilePage, UserProfilePage>();
                buildContainer.RegisterType<IAboutPage, AboutPage>();
                buildContainer.RegisterType<ISurveyPage, SurveyPage>();

                buildContainer.RegisterType<ILoginBasePage, LoginBasePage>();

                buildContainer.RegisterType<IDashboardMenuPage, DashboardMenuPage>();
                buildContainer.RegisterType<IDashboardReportsPage, DashboardReportsPage>();

                buildContainer.RegisterType<IMenuPage, MenuPage>();
                buildContainer.RegisterType<IUnreleasedResultPage, UnreleasedResultPage>();
                buildContainer.RegisterType<ISearchBarcodePage, SearchBarcodePage>();

                Container = buildContainer;
            }
        }
    }
}