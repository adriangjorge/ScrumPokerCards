using FreshMvvm;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class MenuPageModel : FreshBasePageModel
    {

        private IPageModelCoreMethods _coreMethods;

        public MenuPageModel()
        {
            InitializeCommands();
        }

        // Commands.

        private ICommand _goToAboutCommand;
        public ICommand GoToAboutCommand
        {
            get { return _goToAboutCommand; }
        }

        // Overriden methods.

        public override void Init(object initData)
        {
            base.Init(initData);
            _coreMethods = initData as IPageModelCoreMethods;
        }

        /* Private methods */

        private void InitializeCommands()
        {
            _goToAboutCommand = new Command(async () => await GoToAboutExecute());
        }

        private async Task GoToAboutExecute()
        {
            HiddenMenu();
            await _coreMethods.PushPageModel<AboutPageModel>(null, true, true);
        }

        private void HiddenMenu()
        {
            (App.Current.MainPage as MasterDetailPage).IsPresented = false;
        }
    }
}
