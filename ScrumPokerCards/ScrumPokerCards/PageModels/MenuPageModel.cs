using FreshMvvm;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class MenuPageModel : FreshBasePageModel
    {
        /* Private Attributes */

        private IPageModelCoreMethods _coreMethods;

        private ICommand _goToAboutCommand;
        private ICommand _goToThemeCommand;

        /* Constructors */

        public MenuPageModel()
        {
            InitializeCommands();
        }

        /* Properties */
        
        public ICommand GoToAboutCommand
        {
            get { return _goToAboutCommand; }
        }
        
        public ICommand GoToThemeCommand
        {
            get { return _goToThemeCommand; }
        }

        /* Overriden methods */

        public override void Init(object initData)
        {
            base.Init(initData);
            _coreMethods = initData as IPageModelCoreMethods;
        }

        /* Private methods */

        private void InitializeCommands()
        {
            _goToAboutCommand = new Command(async () => await GoToAboutExecute());
            _goToThemeCommand = new Command(async () => await GoToThemeExecute());
        }

        private async Task GoToAboutExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<AboutPageModel>(null, true, true);
        }

        private async Task GoToThemeExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<ThemePageModel>(null, false, true);
        }

        private void HiddenMenu()
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }
}
