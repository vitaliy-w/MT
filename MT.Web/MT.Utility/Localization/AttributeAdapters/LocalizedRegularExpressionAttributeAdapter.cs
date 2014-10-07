using System.Collections.Generic;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.Localization.AttributeAdapters
{
    public class LocalizedRegularExpressionAttributeAdapter : DataAnnotationsModelValidator<LocalizedRegularExpressionAttribute>
    {
        public LocalizedRegularExpressionAttributeAdapter(ModelMetadata metadata, ControllerContext context, LocalizedRegularExpressionAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRegexRule(ErrorMessage, Attribute.Pattern) };
        }
    }
}
