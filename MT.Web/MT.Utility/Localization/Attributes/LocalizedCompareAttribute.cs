using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    public class LocalizedCompareAttribute : CompareAttribute
    {
        public LocalizedCompareAttribute(string otherProperty, string errorMessageResourceKey)
            : base(otherProperty)
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }
    }
}
