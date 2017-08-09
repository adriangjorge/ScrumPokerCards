using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.Themes
{
    public class DarkTheme : Theme
    {
        public DarkTheme(string key, string name = "Dark Theme") : base(key, name)
        {
            BackgroundColor = Color.FromHex("263238");
            ForegroundColor = Color.FromHex("37474F");
            TextColor = Color.FromHex("ECEFF1");

            PrimaryColor = Color.FromHex("00AA8D");
            PrimaryTextColor = Color.FromHex("FFFFFF");

            SecondaryColor = Color.FromHex("FF5722");
            SecondaryTextColor = Color.FromHex("FFFFFF");
        }

    }
}
