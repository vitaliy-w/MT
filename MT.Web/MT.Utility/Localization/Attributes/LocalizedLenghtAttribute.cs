using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    public class LocalizedStringLengthAttribute : MaxLengthAttribute 
    {
        public LocalizedStringLengthAttribute(int maximumLength, string errorMessageResourceKey)
            : base(maximumLength)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }
    }
}
