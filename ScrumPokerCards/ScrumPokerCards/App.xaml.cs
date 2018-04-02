using FreshMvvm;
using ScrumPokerCards.Helpers;
using ScrumPokerCards.Helpers.ThemeManager;
using ScrumPokerCards.PageModels;
using ScrumPokerCards.Services;
using ScrumPokerCards.Services.ChronometerService;
using System;
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
            var cardsListPage = FreshPageModelResolver.ResolvePageModel<CardsListPageModel>();
            var cardsListPageNav = new FreshNavigationContainer(cardsListPage);

            var masterPage = FreshPageModelResolver.ResolvePageModel<MenuPageModel>(cardsListPage.GetModel().CoreMethods);

            MainPage = new MasterDetailPage()
            {
                Detail = cardsListPageNav,
                Master = masterPage,
                MasterBehavior = MasterBehavior.Popover
            };
        }

        private void SetupIOC()
        {
            // Def
            FreshIOC.Container.Register<ICardsService, CardsService>();
            FreshIOC.Container.Register<IThemeManager, ThemeManager>();
            FreshIOC.Container.Register<IChronometerService, ChronometerService>();

            // Conf
            FreshIOC.Container.Resolve<IThemeManager>().Init();
        } 
    }
}
