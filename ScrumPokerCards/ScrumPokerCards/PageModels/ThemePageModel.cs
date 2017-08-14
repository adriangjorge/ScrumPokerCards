using FreshMvvm;
using ScrumPokerCards.Helpers.ThemeManager;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class ThemePageModel : FreshBasePageModel
    {
        /* Private Attributes */

        private readonly IThemeManager _themeManager;

        private IList<Theme> _themeList;

        /* Constructors */

        public ThemePageModel()
        {
            _themeManager = FreshIOC.Container.Resolve<IThemeManager>();

            _themeList = _themeManager.ThemeList;
        }

        /* Properties */

        public IList<Theme> ThemeList
        {
            get { return _themeList; }
        }

        public Theme SelectedTheme
        {
            get { return _themeManager.CurrentTheme; }
            set { SetSelectedTheme(value); }
        }

        /* Private Methods */

        private void SetSelectedTheme(Theme theme)
        {
            if (theme != null)
            {
                CoreMethods.PopPageModel(false, true);
                _themeManager.CurrentTheme = theme;
            }
        }
    }
}
