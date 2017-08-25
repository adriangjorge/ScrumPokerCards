using ScrumPokerCards.Android;
using ScrumPokerCards.Helpers.ThemeManager;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThemePlatform_Android))]
namespace ScrumPokerCards.Android
{
    public class ThemePlatform_Android : IThemePlatform
    {
        public void setTheme(Theme theme)
        {
            
        }
    }
}