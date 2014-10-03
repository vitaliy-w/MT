using System.ComponentModel.DataAnnotations;
using MT.DomainLogic.Localization;

namespace MT.DomainLogic.Attributes
{
    public class LocalizedRequiredAttribute : RequiredAttribute
    {
        public ILocalizationResourceService LocalizationResourceService;

        public LocalizedRequiredAttribute(string errorMessageResourceKey)
        {
            ErrorMessage = LocalizationResourceService.GetValue(errorMessageResourceKey);
        }
    }
}
