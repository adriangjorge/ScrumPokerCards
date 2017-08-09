using FreshMvvm;
using ScrumPokerCards.Helpers.ThemeManager;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScrumPokerCards.PageModels
{
    public class ThemePageModel : FreshBasePageModel
    {
        /* Services. */

        private readonly IThemeManager _themeManager;

        /* Constructor */

        public ThemePageModel()
        {
            _themeManager = FreshIOC.Container.Resolve<IThemeManager>();

            _themeList = _themeManager.ThemeList;
        }

        /* Properties */

        private IList<Theme> _themeList;
        public IList<Theme> ThemeList
        {
            get { return _themeList; }
        }

        public Theme SelectedTheme
        {
            get { return _themeManager.CurrentTheme; }
            set
            {
                if(value != null)
                {
                    CoreMethods.PopPageModel(false, true);
                    _themeManager.CurrentTheme = value;
                }
            }
        }
    }
}
