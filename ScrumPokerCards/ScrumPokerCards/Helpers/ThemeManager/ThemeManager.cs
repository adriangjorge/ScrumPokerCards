using ScrumPokerCards.Helpers.ThemeManager.BaseThemes;
using ScrumPokerCards.Helpers.ThemeManager.ColorThemes;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public class ThemeManager : IThemeManager
    {
        /* Private Attributes */

        private readonly IThemePlatform _themePlatform;

        private BaseTheme _currentBaseTheme;
        private ColorTheme _currentColorTheme;

        private List<BaseTheme> _baseThemesList;
        private List<ColorTheme> _colorThemesList;

        /* Constuctors */

        public ThemeManager()
        {
            _themePlatform = DependencyService.Get<IThemePlatform>();

            CreateLists();
        }

        /* Properties */
        
        public BaseTheme CurrentBaseTheme
        {
            get { return _currentBaseTheme; }
            set { SetCurrentBaseTheme(value); }
        }

        public ColorTheme CurrentColorTheme
        {
            get { return _currentColorTheme; }
            set { SetCurrentColorTheme(value); }
        }

        public IList<BaseTheme> BaseThemesList
        {
            get { return _baseThemesList; }
        }

        public IList<ColorTheme> ColorThemesList
        {
            get { return _colorThemesList; }
        }

        /* Public Methods */

        public void Init()
        {
            InitBaseTheme();
            InitColorTheme();
            UpdateResources();
        }

        /* Private Methods */

        private void SetCurrentBaseTheme(BaseTheme baseTheme)
        {
            _currentBaseTheme = baseTheme;
            UpdateResources();

            LocalSettings.Theme.Base = baseTheme.ThemeKey;
        }

        private void SetCurrentColorTheme(ColorTheme colorTheme)
        {
            _currentColorTheme = colorTheme;
            UpdateResources();
            
            LocalSettings.Theme.Color = colorTheme.ThemeKey;
        }

        private void UpdateResources()
        {
            var resources = App.Current.Resources;

            resources["BackgroundColor"] = _currentBaseTheme.BackgroundColor;
            resources["ForegroundColor"] = _currentBaseTheme.ForegroundColor;
            resources["TextColor"] = _currentBaseTheme.TextColor;

            resources["PrimaryColor"] = _currentColorTheme.PrimaryColor;
            resources["PrimaryTextColor"] = _currentColorTheme.PrimaryTextColor;
            resources["SecondaryColor"] = _currentColorTheme.SecondaryColor;
            resources["SecondaryTextColor"] = _currentColorTheme.SecondaryTextColor;
        }

        private void InitBaseTheme()
        {
            var key = LocalSettings.Theme.Base;
            var baseTheme = _baseThemesList.Find(x => x.ThemeKey == key);
            if (baseTheme == null)
                baseTheme = _baseThemesList[0];
            _currentBaseTheme = baseTheme;
        }

        private void InitColorTheme()
        {
            var key = LocalSettings.Theme.Color;
            var colorTheme = _colorThemesList.Find(x => x.ThemeKey == key);
            if (colorTheme == null)
                colorTheme = _colorThemesList[0];
            _currentColorTheme = colorTheme;
        }

        private void CreateLists()
        {
            _baseThemesList = new List<BaseTheme>()
            {
                new LightBaseTheme(),
                new DarkBaseTheme()
            };

            _colorThemesList = new List<ColorTheme>()
            {
                new TealColorTheme(),
                new ColorTheme("blue-deeporange", "Blue and Deep Orange")
                {
                    PrimaryColor = Color.FromHex("2196F3"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("FF5722"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("blue-pink", "Blue and Pink")
                {
                    PrimaryColor = Color.FromHex("2196F3"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("E91E63"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("deeporange-blue", "Deep Orange and Blue")
                {
                    PrimaryColor = Color.FromHex("FF5722"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("2196F3"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("green-orange", "Green and Orange")
                {
                    PrimaryColor = Color.FromHex("4CAF50"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("FF9800"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("purple-pink", "Purple and Pink")
                {
                    PrimaryColor = Color.FromHex("9C27B0"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("E91E63"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("red", "Red")
                {
                    PrimaryColor = Color.FromHex("F44336"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("F44336"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("yellow+1-brown", "Yellow and Brown")
                {
                    PrimaryColor = Color.FromHex("FDD835"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("795548"), SecondaryTextColor = Color.FromHex("FFFFFF")
                },
                new ColorTheme("yellow+1-cyan", "Yellow and Cyan")
                {
                    PrimaryColor = Color.FromHex("FDD835"), PrimaryTextColor = Color.FromHex("FFFFFF"),
                    SecondaryColor = Color.FromHex("00BCD4"), SecondaryTextColor = Color.FromHex("FFFFFF")
                }
            };
        }

    }
}
