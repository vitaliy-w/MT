using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    public class LocalizedRegularExpressionAttribute : RegularExpressionAttribute
    {
        public LocalizedRegularExpressionAttribute(string patternResourceKey, string errorMessageResourceKey, bool localizePattern = true)
            : base(localizePattern ? LocalizationResourceServiceSingleton.Current.GetValue(patternResourceKey) : patternResourceKey)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }
    }
}
