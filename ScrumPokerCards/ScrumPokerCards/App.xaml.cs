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
            
            FreshIOC.Container.Resolve<IThemeManager>().Init();
        }

        /* Private Methods */

        private void SetMainPage()
        {
            var cardsListPage = FreshPageModelResolver.ResolvePageModel<CardsListPageModel>();
            var cardsListPageNav = new FreshNavigationContainer(cardsListPage);

            var master = FreshPageModelResolver.ResolvePageModel<MenuPageModel>(cardsListPage.GetModel().CoreMethods);

            MainPage = new MasterDetailPage()
            {
                Detail = cardsListPageNav,
                Master = master,
                MasterBehavior = MasterBehavior.Popover
            };
        }

        private void SetupIOC()
        {
            FreshIOC.Container.Register<ICardsService, CardsService>();
            FreshIOC.Container.Register<IThemeManager, ThemeManager>();
        }
    }
}
