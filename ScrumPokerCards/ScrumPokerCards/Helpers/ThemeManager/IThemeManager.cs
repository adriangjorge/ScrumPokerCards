using ScrumPokerCards.Helpers.ThemeManager.BaseThemes;
using ScrumPokerCards.Helpers.ThemeManager.ColorThemes;
using System.Collections.Generic;

namespace ScrumPokerCards.Helpers.ThemeManager
{
    public interface IThemeManager
    {
        /* Properties */

        BaseTheme CurrentBaseTheme { get; set; }
        ColorTheme CurrentColorTheme { get; set; }

        IList<BaseTheme> BaseThemesList { get; }
        IList<ColorTheme> ColorThemesList { get; }

        /* Methods */

        void Init();
    }
}
