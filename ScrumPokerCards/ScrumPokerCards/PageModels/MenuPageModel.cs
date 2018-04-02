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
        private ICommand _goToSettingsCommand;
        private ICommand _goToChronometerCommand;

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
        
        public ICommand GoToSettingsCommand
        {
            get { return _goToSettingsCommand; }
        }

        public ICommand GoToChronometerCommand
        {
            get { return _goToChronometerCommand; }
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
            _goToSettingsCommand = new Command(async () => await GoToSettingsExecute());
            _goToChronometerCommand = new Command(async () => await GoToChronometerExecute());
        }

        private async Task GoToAboutExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<AboutPageModel>(null, true);
        }

        private async Task GoToSettingsExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<SettingsPageModel>(null);
        }

        private async Task GoToChronometerExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<ChronometerPageModel>(null);
        }

        private void HiddenMenu()
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }
}
