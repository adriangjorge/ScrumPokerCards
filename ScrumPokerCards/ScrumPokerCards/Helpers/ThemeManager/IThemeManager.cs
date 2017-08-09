using System.Collections.Generic;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public interface IThemeManager
    {
        Theme CurrentTheme { get; set; }

        IList<Theme> ThemeList { get; }

        void Init();
    }
}
