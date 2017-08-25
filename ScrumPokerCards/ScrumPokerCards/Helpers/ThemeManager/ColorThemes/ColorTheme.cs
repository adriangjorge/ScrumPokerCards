using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.ColorThemes
{
    public class ColorTheme : Theme
    {
        public ColorTheme(string key, string name) : base(key, name)
        {
        }

        public Color PrimaryColor { get; set; }
        public Color PrimaryTextColor { get; set; }

        public Color SecondaryColor { get; set; }
        public Color SecondaryTextColor { get; set; }
    }
}
