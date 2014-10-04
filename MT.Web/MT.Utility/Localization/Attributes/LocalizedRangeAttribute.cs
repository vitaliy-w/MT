using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    public class LocalizedRangeAttribute : RangeAttribute
    {
        public LocalizedRangeAttribute(int minValue, int maxValue, string errorMessageResourceKey)
            : base(minValue, maxValue)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }

        public LocalizedRangeAttribute(double minValue, double maxValue, string errorMessageResourceKey)
            : base(minValue, maxValue)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }

        public LocalizedRangeAttribute(System.Type type, string minValue, string maxValue, string errorMessageResourceKey)
            : base(type, minValue, maxValue)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }
    }
}
