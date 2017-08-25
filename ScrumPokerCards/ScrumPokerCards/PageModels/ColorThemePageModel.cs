using FreshMvvm;
using ScrumPokerCards.Helpers.ThemeManager;
using ScrumPokerCards.Helpers.ThemeManager.ColorThemes;
using System.Collections.Generic;

namespace ScrumPokerCards.PageModels
{
    public class ColorThemePageModel : FreshBasePageModel
    {
        /* Private Attributes */

        private readonly IThemeManager _themeManager;

        private IList<ColorTheme> _colorThemeList;

        /* Constructors */

        public ColorThemePageModel()
        {
            _themeManager = FreshIOC.Container.Resolve<IThemeManager>();

            _colorThemeList = _themeManager.ColorThemesList;
        }

        /* Properties */

        public IList<ColorTheme> ColorThemeList
        {
            get { return _colorThemeList; }
        }

        public ColorTheme SelectedTheme
        {
            get { return _themeManager.CurrentColorTheme; }
            set { SetSelectedTheme(value); }
        }

        /* Private Methods */

        private void SetSelectedTheme(ColorTheme colorTheme)
        {
            if (colorTheme != null)
            {
                CoreMethods.PopPageModel();
                _themeManager.CurrentColorTheme = colorTheme;
            }
        }
        
    }
}
