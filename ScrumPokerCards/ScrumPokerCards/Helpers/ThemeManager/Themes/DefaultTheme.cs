using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.Themes
{
    public class DefaultTheme : Theme
    {
        public DefaultTheme(string key, string name = "Default Theme") : base(key, name)
        {
            BackgroundColor = Color.FromHex("FAFAFA");
            ForegroundColor = Color.FromHex("FFFFFF");
            TextColor = Color.FromHex("212121");

            PrimaryColor = Color.FromHex("00AA8D");
            PrimaryTextColor = Color.FromHex("FFFFFF");

            SecondaryColor = Color.FromHex("FF5722");
            SecondaryTextColor = Color.FromHex("FFFFFF");
        }
        
    }
}
