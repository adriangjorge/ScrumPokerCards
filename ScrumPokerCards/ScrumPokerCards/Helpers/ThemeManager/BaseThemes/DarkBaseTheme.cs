using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.BaseThemes
{
    public class DarkBaseTheme : BaseTheme
    {
        public DarkBaseTheme() : base("dark", "Dark Theme")
        {
            BackgroundColor = Color.FromHex("263238");
            ForegroundColor = Color.FromHex("37474F");
            TextColor = Color.FromHex("ECEFF1");
        }
    }
}
