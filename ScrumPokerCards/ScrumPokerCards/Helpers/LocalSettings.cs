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

		private const string ThemeKey = "theme_key";
		public static string Theme
		{
			get { return AppSettings.GetValueOrDefault(ThemeKey, null); }
			set { AppSettings.AddOrUpdateValue(ThemeKey, value); }
		}

	}
}