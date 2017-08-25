using FreshMvvm;
using ScrumPokerCards.Helpers.ThemeManager;
using ScrumPokerCards.PageModels;
using ScrumPokerCards.Services;
using Xamarin.Forms;

namespace ScrumPokerCards
{
    public partial class App : Application
    {
        /* Constructors */

        public App()
        {
            InitializeComponent();

            SetupIOC();
            SetMainPage();
        }

        /* Private Methods */

        private void SetMainPage()
        {
            var detailPage = FreshPageModelResolver.ResolvePageModel<CardsListPageModel>();
            var detailPageNav = new FreshNavigationContainer(detailPage);

            var masterPage = FreshPageModelResolver.ResolvePageModel<MenuPageModel>(detailPage.GetModel().CoreMethods);

            MainPage = new MasterDetailPage()
            {
                Detail = detailPageNav,
                Master = masterPage,
                MasterBehavior = MasterBehavior.Popover
            };
        }

        private void SetupIOC()
        {
            // Def
            FreshIOC.Container.Register<ICardsService, CardsService>();
            FreshIOC.Container.Register<IThemeManager, ThemeManager>();

            // Conf
            FreshIOC.Container.Resolve<IThemeManager>().Init();
        }
    }
}
