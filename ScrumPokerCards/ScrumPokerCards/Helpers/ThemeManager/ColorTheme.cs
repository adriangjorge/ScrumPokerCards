using Xamarin.Forms;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public class ColorTheme : Theme
    {
        /* Contructors */

        public ColorTheme(string key, string name) : base(key, name)
        {
        }

        public ColorTheme(string key, string name, Color primaryColor, Color secondaryColor) : base(key, name)
        {
            PrimaryColor = primaryColor;
            PrimaryTextColor = Color.FromHex("FFFFFF");
            SecondaryColor = secondaryColor;
            SecondaryTextColor = Color.FromHex("FFFFFF");
        }

        /* Properties */

        public Color PrimaryColor { get; set; }
        public Color PrimaryTextColor { get; set; }

        public Color SecondaryColor { get; set; }
        public Color SecondaryTextColor { get; set; }
    }
}
