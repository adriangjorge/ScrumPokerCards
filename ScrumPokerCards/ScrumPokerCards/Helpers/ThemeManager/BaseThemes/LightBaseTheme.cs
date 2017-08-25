using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.BaseThemes
{
    public class LightBaseTheme : BaseTheme
    {
        public LightBaseTheme() : base("light", "Light Theme")
        {
            BackgroundColor = Color.FromHex("FAFAFA");
            ForegroundColor = Color.FromHex("FFFFFF");
            TextColor = Color.FromHex("212121");
        }
    }
}
