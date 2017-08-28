using FreshMvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class AboutPageModel : FreshBasePageModel
    {
        /* Constants */

        private const string _githubUri = "https://github.com/adriangjorge";
        private const string _linkedinUri = "https://www.linkedin.com/in/adri%C3%A1n-g%C3%B3mez-jorge-19526a12b/";
        private const string _twitterUri = "https://twitter.com/AdrianGJorge";

        /* Private Attributes */

        private ICommand _closeCommand;

        private ICommand _goToGithubCommand;
        private ICommand _goToLinkedinCommand;
        private ICommand _goToTwitterCommand;

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

        public ICommand GoToGithubCommand
        {
            get { return _goToGithubCommand; }
        }

        public ICommand GoToLinkedinCommand
        {
            get { return _goToLinkedinCommand; }
        }

        public ICommand GoToTwitterCommand
        {
            get { return _goToTwitterCommand; }
        }

        /* Private methods */

        private void InitializeCommands()
        {
            _closeCommand = new Command(async () => await CloseExecute());
            _goToGithubCommand = new Command(() => GoToGithubExecute());
            _goToLinkedinCommand = new Command(() => GoToLinkedinExecute());
            _goToTwitterCommand = new Command(() => GoToTwitterExecute());
        }

        private async Task CloseExecute()
        {
            await CoreMethods.PopPageModel(true, true);
        }

        private void GoToGithubExecute()
        {
            Device.OpenUri(new Uri(_githubUri));
        }

        private void GoToLinkedinExecute()
        {
            Device.OpenUri(new Uri(_linkedinUri));
        }

        private void GoToTwitterExecute()
        {
            Device.OpenUri(new Uri(_twitterUri));
        }
    }
}
