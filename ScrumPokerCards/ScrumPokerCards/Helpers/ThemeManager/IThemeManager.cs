using System.Collections.Generic;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public interface IThemeManager
    {
        /* Properties */

        Theme CurrentTheme { get; set; }

        IList<Theme> ThemeList { get; }

        /* Methods */

        void Init();
    }
}
