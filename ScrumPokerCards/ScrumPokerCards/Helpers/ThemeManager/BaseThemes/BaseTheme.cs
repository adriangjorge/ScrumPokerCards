using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.BaseThemes
{
    public class BaseTheme : Theme
    {
        public BaseTheme(string key, string name) : base(key, name)
        {
        }

        public Color BackgroundColor { get; set; }
        public Color ForegroundColor { get; set; }
        public Color TextColor { get; set; }
    }
}
