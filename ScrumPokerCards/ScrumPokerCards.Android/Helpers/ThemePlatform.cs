using ScrumPokerCards.Android.Helpers;
using ScrumPokerCards.Helpers.ThemeManager;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThemePlatform))]
namespace ScrumPokerCards.Android.Helpers
{
    public class ThemePlatform : IThemePlatform
    {
        public void setTheme(Theme theme)
        {
            
        }
    }
}