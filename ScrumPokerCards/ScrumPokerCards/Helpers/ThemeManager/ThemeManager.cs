using ScrumPokerCards.Helpers.ThemeManager.Themes;
using System.Collections.Generic;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public class ThemeManager : IThemeManager
    {
        private const string DEFAULT_KEY = "default";

        public ThemeManager()
        {
            CreateThemeList();
        }

        /* Properties */

        private Theme _currentTheme;
        public Theme CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                _currentTheme = value;
                ApplyTheme(value);
                LocalSettings.Theme = value.ThemeKey;
            }
        }

        public IList<Theme> ThemeList
        {
            get; private set;
        }

        public void Init()
        {
            var key = LocalSettings.Theme ?? DEFAULT_KEY;
            var theme = (ThemeList as List<Theme>).Find(x => x.ThemeKey == key);
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
        }

        private void CreateThemeList()
        {
            ThemeList = new List<Theme> ()
            {
                new DefaultTheme(DEFAULT_KEY),
                new DarkTheme("dark")
            };
        }

    }
}
