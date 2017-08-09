using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public class Theme
    {

        public Theme(string key, string name)
        {
            ThemeKey = key;
            ThemeName = name;
        }

        public string ThemeKey { get; private set; }
        public string ThemeName { get; private set; }

        // Colours

        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public Color TextColor { get; set; }

        public Color PrimaryColor { get; set; }
        public Color PrimaryTextColor { get; set; }

        public Color SecondaryColor { get; set; }
        public Color SecondaryTextColor { get; set; }
    }
}
