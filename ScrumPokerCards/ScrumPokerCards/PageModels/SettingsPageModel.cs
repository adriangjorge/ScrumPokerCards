using FreshMvvm;
using ScrumPokerCards.Helpers.ThemeManager;
using ScrumPokerCards.Helpers.ThemeManager.BaseThemes;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class SettingsPageModel : FreshBasePageModel
    {
        /* Private Attributes */

        private readonly IThemeManager _themeManager;

        private bool _isDarkBaseTheme;
        private string _currentColorTheme;

        private Command _gotoColorThemeCommand;

        /* Constructors */

        public SettingsPageModel()
        {
            _themeManager = FreshIOC.Container.Resolve<IThemeManager>();

            InitializeCommands();

            _isDarkBaseTheme = _themeManager.CurrentBaseTheme.ThemeKey.Equals(new DarkBaseTheme().ThemeKey);
        }

        /* Properties */

        public bool IsDarkBaseTheme
        {
            get { return _isDarkBaseTheme; }
            set { SetBaseTheme(value); }
        }

        public string CurrentColorTheme
        {
            get { return _currentColorTheme; }
            set { _currentColorTheme = value; RaisePropertyChanged(nameof(CurrentColorTheme)); }
        }

        public Command GotoColorThemeCommand
        {
            get { return _gotoColorThemeCommand; }
        }

        /* Override Methods */

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            CurrentColorTheme = _themeManager.CurrentColorTheme.ThemeName;
        }

        /* Private Methods */

        private void InitializeCommands()
        {
            _gotoColorThemeCommand = new Command(async () => await GotoColorThemeExecute());
        }

        private async Task GotoColorThemeExecute()
        {
            await CoreMethods.PushPageModel<ColorThemePageModel>(null);
        }

        private void SetBaseTheme(bool isDarkBaseTheme)
        {
            BaseTheme baseTheme;
            if (isDarkBaseTheme)
                baseTheme = new DarkBaseTheme();
            else
                baseTheme = new LightBaseTheme();
            _themeManager.CurrentBaseTheme = baseTheme;
            _isDarkBaseTheme = isDarkBaseTheme;
            RaisePropertyChanged(nameof(IsDarkBaseTheme));
        }
    }
}
