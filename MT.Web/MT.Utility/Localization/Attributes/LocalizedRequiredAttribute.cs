using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public LocalizedRequiredAttribute(string errorMessageResourceKey)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }
    }
}
