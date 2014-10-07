using System.Collections.Generic;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.Localization.AttributeAdapters
{
    public class LocalizedCompareAttributeAdapter : DataAnnotationsModelValidator<LocalizedCompareAttribute>
    {
        public LocalizedCompareAttributeAdapter(ModelMetadata metadata, ControllerContext context, LocalizedCompareAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationEqualToRule(ErrorMessage, Attribute.OtherProperty)  };
        }
    }
}
