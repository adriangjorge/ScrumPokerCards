using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager.ColorThemes
{
    public class TealColorTheme : ColorTheme
    {
        public TealColorTheme() : base("teal", "Default")
        {
            PrimaryColor = Color.FromHex("00AA8D");
            PrimaryTextColor = Color.FromHex("FFFFFF");

            SecondaryColor = Color.FromHex("FF5722");
            SecondaryTextColor = Color.FromHex("FFFFFF");
        }
    }
}
