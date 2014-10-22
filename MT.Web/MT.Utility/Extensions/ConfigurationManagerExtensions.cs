using System;
using System.Configuration;

namespace MT.Utility.Extensions
{
    /// <summary>
    /// This class helps to gets property from config file
    /// </summary>
    public class ConfigurationManagerExtensions
    {
        public static int? ReadIntSetting(string key)
        {
            string settingString = ConfigurationManager.AppSettings[key];

            if (settingString == null)
                return null;

            int settingValue;
            if (Int32.TryParse(settingString, out settingValue))
                return settingValue;

            return null;
        }

        public static string ReadStringSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
