using ScrumPokerCards.Helpers.ThemeManager;
using ScrumPokerCards.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThemePlatform_iOS))]
namespace ScrumPokerCards.iOS
{
    public class ThemePlatform_iOS : IThemePlatform
    {
        public void setTheme(Theme theme)
        {
            
        }
    }
}
