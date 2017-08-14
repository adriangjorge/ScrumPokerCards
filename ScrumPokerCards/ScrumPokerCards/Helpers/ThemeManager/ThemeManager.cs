using ScrumPokerCards.Helpers.ThemeManager.Themes;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public class ThemeManager : IThemeManager
    {
        /* Private Attributes */

        private Theme _currentTheme;
        private Theme _defaultTheme;

        private readonly IThemePlatform _themePlatform;

        /* Constuctors */

        public ThemeManager()
        {
            _themePlatform = DependencyService.Get<IThemePlatform>();
            _defaultTheme = new DefaultTheme("default");
            CreateThemeList();
        }

        /* Properties */
        
        public Theme CurrentTheme
        {
            get { return _currentTheme; }
            set { SetCurrentTheme(value); }
        }

        public IList<Theme> ThemeList
        {
            get; private set;
        }

        /* Public Methods */

        public void Init()
        {
            var key = LocalSettings.Theme;
            var theme = (ThemeList as List<Theme>).Find(x => x.ThemeKey == key);
            if(theme == null)
                theme = _defaultTheme;
            _currentTheme = theme;
            ApplyTheme(theme);
        }

        /* Private Methods */

        private void ApplyTheme(Theme theme)
        {
            var resources = App.Current.Resources;

            resources["BackgroundColor"] = theme.BackgroundColor;
            resources["ForegroundColor"] = theme.ForegroundColor;
            resources["TextColor"] = theme.TextColor;

            resources["PrimaryColor"] = theme.PrimaryColor;
            resources["PrimaryTextColor"] = theme.PrimaryTextColor;

            resources["SecondaryColor"] = theme.SecondaryColor;
            resources["SecondaryTextColor"] = theme.SecondaryTextColor;

            _themePlatform.setTheme(theme);
        }

        private void SetCurrentTheme(Theme theme)
        {
            _currentTheme = theme;
            ApplyTheme(theme);
            LocalSettings.Theme = theme.ThemeKey;
        }

        private void CreateThemeList()
        {
            ThemeList = new List<Theme> ()
            {
                _defaultTheme,
                new DarkTheme("dark"),
                new TestTheme("test"),
                new DefaultTheme("orage", "Orange Theme")
                {
                    PrimaryColor = Color.FromHex("FF5722"),
                    SecondaryColor = Color.FromHex("2196F3")
                }
            };
        }

    }
}
