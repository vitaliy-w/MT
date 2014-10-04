using System.Collections.Generic;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.Localization.AttributeAdapters
{
    public class LocalizedEmailAttributeAdapter : DataAnnotationsModelValidator<LocalizedEmailAttribute>
    {
        public LocalizedEmailAttributeAdapter(ModelMetadata metadata, ControllerContext context, LocalizedEmailAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRegexRule(ErrorMessage, Attribute.Pattern) };
        }
    }
}
