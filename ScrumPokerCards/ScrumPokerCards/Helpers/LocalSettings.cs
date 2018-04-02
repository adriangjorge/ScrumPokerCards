using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

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
        private const string OffsetChronometerKey = "offset_chronometer";
        private const string StartTimeChronometerKey = "starttime_chronometer";

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

        public static class Chronometer
        {
            public static Nullable<TimeSpan> OffSet
            {
                get {
                    var valueStored = AppSettings.GetValueOrDefault(OffsetChronometerKey, null);
                    if (string.IsNullOrEmpty(valueStored))
                        return null;
                    return TimeSpan.Parse(valueStored);
                }
                set { AppSettings.AddOrUpdateValue(OffsetChronometerKey, value.ToString()); }
            }

            public static Nullable<DateTime> StartTime
            {
                get
                {
                    var valueStored = AppSettings.GetValueOrDefault(StartTimeChronometerKey, null);
                    if (string.IsNullOrEmpty(valueStored))
                        return null;
                    return DateTime.Parse(valueStored);
                }
                set { AppSettings.AddOrUpdateValue(StartTimeChronometerKey, value.ToString()); }
            }
        }

    }
}