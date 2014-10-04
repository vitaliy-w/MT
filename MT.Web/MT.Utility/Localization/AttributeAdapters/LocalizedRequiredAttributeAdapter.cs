using System.Collections.Generic;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.Localization.AttributeAdapters
{
    public class LocalizedRequiredAttributeAdapter : DataAnnotationsModelValidator<LocalizedRequiredAttribute>
    {
        public LocalizedRequiredAttributeAdapter(ModelMetadata metadata, ControllerContext context, LocalizedRequiredAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRequiredRule(ErrorMessage) };
        }
    }
}
