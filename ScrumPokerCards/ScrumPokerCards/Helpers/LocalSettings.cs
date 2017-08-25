using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ScrumPokerCards.Helpers
{
	public static class LocalSettings
	{
		private static ISettings AppSettings
		{
			get { return CrossSettings.Current; }
		}

		private const string BaseThemeKey = "base_theme";
        private const string ColorThemeKey = "color_theme";
        
        public static class Theme
        {
            public static string Base
            {
                get { return AppSettings.GetValueOrDefault(BaseThemeKey, null); }
                set { AppSettings.AddOrUpdateValue(BaseThemeKey, value); }
            }
            
            public static string Color
            {
                get { return AppSettings.GetValueOrDefault(ColorThemeKey, null); }
                set { AppSettings.AddOrUpdateValue(ColorThemeKey, value); }
            }
        }

    }
}