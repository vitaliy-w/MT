using System.ComponentModel.DataAnnotations;

using MT.Utility.Localization.Services;

namespace MT.Utility.Localization.Attributes
{
   public class LocalizedStringLengthAttribute : StringLengthAttribute
    {

       public LocalizedStringLengthAttribute(int maxLenght, string errorMessageResourceKey)
            : base(maxLenght)
       {
           ErrorMessage = errorMessageResourceKey; //LocalizationResourceServiceSingleton.Current.GetValue(errorMessageResourceKey);
       }
    }
}
