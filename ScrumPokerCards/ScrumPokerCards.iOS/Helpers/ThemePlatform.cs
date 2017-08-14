using ScrumPokerCards.Helpers.ThemeManager;
using ScrumPokerCards.iOS.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThemePlatform))]
namespace ScrumPokerCards.iOS.Helpers
{
    public class ThemePlatform : IThemePlatform
    {
        public void setTheme(Theme theme)
        {
            
        }
    }
}
