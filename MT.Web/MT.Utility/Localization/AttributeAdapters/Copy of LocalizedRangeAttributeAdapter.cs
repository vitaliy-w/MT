using System.Collections.Generic;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.Localization.AttributeAdapters
{
    public class LocalizedStringLengthAttributeAdapter : DataAnnotationsModelValidator<LocalizedStringLengthAttribute>
    {
        public LocalizedStringLengthAttributeAdapter(ModelMetadata metadata, ControllerContext context, LocalizedStringLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationMaxLengthRule(ErrorMessage, Attribute.Length)   };
        }
    }
}
