using FreshMvvm;
using ScrumPokerCards.Services.ChronometerService;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class ChronometerPageModel : FreshBasePageModel
    {
        /* Private Attributes */

        private readonly IChronometerService _chronometerService;

        private bool _isFocused;

        private Command _startCommand;
        private Command _pauseCommand;
        private Command _resetCommand;

        /* Constructors */

        public ChronometerPageModel()
        {
            _chronometerService = FreshIOC.Container.Resolve<IChronometerService>();

            InitializeCommands();
        }

        /* Properties */

        public string CurrentTime
        {
            get
            {
                var time = _chronometerService.CurrentTime();
                return string.Format("{0:hh\\:mm\\:ss}", time);
            }
        }

        public bool EnabledStart
        {
            get { return !_chronometerService.IsRunning(); }
        }

        public bool EnabledPause
        {
            get { return _chronometerService.IsRunning(); }
        }

        public bool EnabledReset
        {
            get { return !_chronometerService.IsResetted(); }
        }

        public Command StartCommand
        {
            get { return _startCommand; }
        }

        public Command PauseCommand
        {
            get { return _pauseCommand; }
        }

        public Command ResetCommand
        {
            get { return _resetCommand; }
        }

        /* Override Methods */

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            _isFocused = true;
            RaisePropertyChanged(nameof(CurrentTime));
            NotifyControllerChanged();
            StartTimer();
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);
            _isFocused = false;
        }

        /* Private Methods */

        private void InitializeCommands()
        {
            _startCommand = new Command(() => StartExecute());
            _pauseCommand = new Command(() => PauseExecute());
            _resetCommand = new Command(async () => await ResetExecuteAsync());
        }

        private void StartExecute()
        {
            _chronometerService.Start();
            StartTimer();
            NotifyControllerChanged();
        }

        private void PauseExecute()
        {
            _chronometerService.Pause();
            NotifyControllerChanged();
        }

        private async Task ResetExecuteAsync()
        {
            if (await CoreMethods.DisplayAlert("Reset", "Do you wan't to reset the Chronometer?", "Yes", "Cancel"))
            {
                _chronometerService.Reset();
                RaisePropertyChanged(nameof(CurrentTime));
                NotifyControllerChanged();
            }
        }

        private void StartTimer()
        {
            if (_chronometerService.IsRunning())
            {
                Device.StartTimer(new TimeSpan(0, 0, 1), TimerExpired);
            }
        }

        private bool TimerExpired()
        {
            RaisePropertyChanged(nameof(CurrentTime));
            return _isFocused && _chronometerService.IsRunning();
        }

        private void NotifyControllerChanged()
        {
            RaisePropertyChanged(nameof(EnabledStart));
            RaisePropertyChanged(nameof(EnabledPause));
            RaisePropertyChanged(nameof(EnabledReset));
        }

    }
}
