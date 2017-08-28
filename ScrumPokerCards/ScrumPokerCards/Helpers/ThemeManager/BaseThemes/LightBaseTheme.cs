using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.BaseThemes
{
    public class LightBaseTheme : BaseTheme
    {
        public LightBaseTheme() : base("light", "Light Theme")
        {
            BackgroundColor = ColorPalette.Gray_50;
            ForegroundColor = ColorPalette.White;
            TextColor = ColorPalette.Gray_900;
        }
    }
}
