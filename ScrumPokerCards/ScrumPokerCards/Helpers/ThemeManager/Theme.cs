namespace ScrumPokerCards.Helpers.ThemeManager
{
    public partial class Theme
    {
        public Theme(string key, string name)
        {
            ThemeKey = key;
            ThemeName = name;
        }

        public string ThemeKey { get; private set; }
        public string ThemeName { get; private set; }
    }
}
