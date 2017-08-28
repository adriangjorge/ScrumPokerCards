using ScrumPokerCards.Helpers.ThemeManager.BaseThemes;
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
                new ColorTheme("teal-deeporange", "Default", ColorPalette.Teal, ColorPalette.DeepOrange),
                new ColorTheme("black-cyan", "Black and Cyan", Color.FromHex("101010"), ColorPalette.Cyan),
                new ColorTheme("blue", "Blue", ColorPalette.Blue_A700, ColorPalette.Blue_A400),
                new ColorTheme("blue-deeporange", "Blue and Deep Orange", ColorPalette.Blue, ColorPalette.DeepOrange),
                new ColorTheme("blue-pink", "Blue and Pink", ColorPalette.Blue, ColorPalette.Pink),
                new ColorTheme("brown-yellow+1", "Brown and Yellow", ColorPalette.Brown, ColorPalette.Yellow_600)
                {
                    SecondaryTextColor = Color.FromHex("101010")
                },
                new ColorTheme("deeporange-blue", "Deep Orange and Blue", ColorPalette.DeepOrange, ColorPalette.Blue),
                new ColorTheme("deeporange-teal", "Deep Orange and Teal", ColorPalette.DeepOrange, ColorPalette.Teal),
                new ColorTheme("green-orange", "Green and Orange", ColorPalette.Green, ColorPalette.Orange),
                new ColorTheme("indigo", "Indigo", ColorPalette.Indigo_700, ColorPalette.Indigo),
                new ColorTheme("indigo-yellow+1", "Indigo and Yellow", ColorPalette.Indigo, ColorPalette.Yellow_600),
                new ColorTheme("pink-purple", "Pink and Purple", ColorPalette.Pink, ColorPalette.Purple),
                new ColorTheme("purple-pink", "Purple and Pink", ColorPalette.Purple, ColorPalette.Pink),
                new ColorTheme("red", "Red", ColorPalette.Red, ColorPalette.Red),
                new ColorTheme("teal-red", "Teal and Red", ColorPalette.Teal, ColorPalette.Red),
                new ColorTheme("yellow+1-brown", "Yellow and Brown", ColorPalette.Yellow_600, ColorPalette.Brown)
                {
                    PrimaryTextColor = Color.FromHex("101010")
                },
                new ColorTheme("yellow+1-cyan", "Yellow and Cyan", ColorPalette.Yellow_600, ColorPalette.Cyan)
                {
                    PrimaryTextColor = Color.FromHex("101010")
                }
            };
        }

    }
}
