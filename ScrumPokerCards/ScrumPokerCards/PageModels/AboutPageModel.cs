using FreshMvvm;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class AboutPageModel : FreshBasePageModel
    {
        /* Private Attributes */

        private ICommand _closeCommand;

        /* Contructors */

        public AboutPageModel()
        {
            InitializeCommands();
        }

        /* Properties */

        public ICommand CloseCommand
        {
            get { return _closeCommand; }
        }

        /* Private methods */

        private void InitializeCommands()
        {
            _closeCommand = new Command(async () => await CloseExecute());
        }

        private async Task CloseExecute()
        {
            await CoreMethods.PopPageModel(true, true);
        }
    }
}
