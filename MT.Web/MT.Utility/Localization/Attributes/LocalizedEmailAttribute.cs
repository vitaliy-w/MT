using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
    /// <summary>
    /// Validates if the input is an email
    /// </summary>
    public class LocalizedEmailAttribute : RegularExpressionAttribute
    {
        public LocalizedEmailAttribute(string errorMessageResourceKey) :
            base(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")
        {
            ErrorMessage = LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
        }
    }
}
