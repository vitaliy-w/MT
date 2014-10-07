using System.Collections.Generic;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.Localization.AttributeAdapters
{
    public class LocalizedRangeAttributeAdapter : DataAnnotationsModelValidator<LocalizedRangeAttribute>
    {
        public LocalizedRangeAttributeAdapter(ModelMetadata metadata, ControllerContext context, LocalizedRangeAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            return new[] { new ModelClientValidationRangeRule(ErrorMessage, Attribute.Minimum, Attribute.Maximum)  };
        }
    }
}
