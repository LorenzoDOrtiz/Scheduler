using System.Globalization;
using System.Resources;

namespace Scheduler.Localization
{
    public static class LocalizationManager
    {
        private static ResourceManager resManager = new ResourceManager("Scheduler.Localization.Localization", typeof(LocalizationManager).Assembly);

        public static string GetUserTwoLetterISOLanguageName()
        {
            return CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        }

        public static string GetString(string key, params object[] args)
        {
            string value = resManager.GetString(key, CultureInfo.CurrentUICulture);
            return string.Format(value, args);
        }

        public static void SetCulture(string cultureName)
        {
            CultureInfo culture = new CultureInfo(cultureName);
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.CurrentCulture = culture;
        }
    }
}
