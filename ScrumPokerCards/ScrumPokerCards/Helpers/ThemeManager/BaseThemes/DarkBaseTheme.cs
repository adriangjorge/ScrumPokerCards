using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.BaseThemes
{
    public class DarkBaseTheme : BaseTheme
    {
        public const string Key = "dark";

        public DarkBaseTheme() : base(Key, "Dark Theme")
        {
            BackgroundColor = ColorPalette.BlueGray_900;
            ForegroundColor = ColorPalette.BlueGray_800;
            TextColor = ColorPalette.BlueGray_50;
        }
    }
}
