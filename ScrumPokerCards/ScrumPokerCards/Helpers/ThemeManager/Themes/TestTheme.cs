using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.Themes
{
    public class TestTheme : Theme
    {
        public TestTheme(string key, string name = "Test Theme") : base(key, name)
        {
            BackgroundColor = Color.FromHex("FF0000");
            ForegroundColor = Color.FromHex("0000FF");
            TextColor = Color.FromHex("00FF00");

            PrimaryColor = Color.FromHex("FFFF00");
            PrimaryTextColor = Color.FromHex("FF00FF");

            SecondaryColor = Color.FromHex("00FFFF");
            SecondaryTextColor = Color.FromHex("FFFFFF");
        }
        
    }
}
