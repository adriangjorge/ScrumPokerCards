using FreshMvvm;
using ScrumPokerCards.PageModels;
using ScrumPokerCards.Services;
using Xamarin.Forms;

namespace ScrumPokerCards
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            SetupIOC();
            SetMainPage();
        }

        /* Private Methods */

        private void SetMainPage()
        {
            var detail = FreshPageModelResolver.ResolvePageModel<CardsListPageModel>();
            var master = FreshPageModelResolver.ResolvePageModel<MenuPageModel>(detail.GetModel().CoreMethods);

            MainPage = new MasterDetailPage()
            {
                Detail = new FreshNavigationContainer(detail),
                Master = master,
                MasterBehavior = MasterBehavior.Popover
            };
        }

        private void SetupIOC()
        {
            FreshIOC.Container.Register<ICardsService, CardsService>();
        }
    }
}
