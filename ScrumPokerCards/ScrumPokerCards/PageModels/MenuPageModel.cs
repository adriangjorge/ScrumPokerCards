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

        private ICommand _gotoAboutCommand;
        private ICommand _gotoSettingsCommand;

        /* Constructors */

        public MenuPageModel()
        {
            InitializeCommands();
        }

        /* Properties */
        
        public ICommand GotoAboutCommand
        {
            get { return _gotoAboutCommand; }
        }
        
        public ICommand GotoSettingsCommand
        {
            get { return _gotoSettingsCommand; }
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
            _gotoAboutCommand = new Command(async () => await GotoAboutExecute());
            _gotoSettingsCommand = new Command(async () => await GotoSettingsExecute());
        }

        private async Task GotoAboutExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<AboutPageModel>(null, true);
        }

        private async Task GotoSettingsExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<SettingsPageModel>(null);
        }

        private void HiddenMenu()
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }
}
