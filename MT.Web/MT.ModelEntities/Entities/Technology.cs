using System;
using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Attributes;

namespace MT.ModelEntities.Entities
{
    /// <summary>
    /// Describes a technology such as asp.net, C# and ect.
    /// </summary>
    [Serializable]
    public class Technology
    {
        /// <summary>
        /// A unique identificator of a technology.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A new of a technology.
        /// </summary>
        [LocalizedRequired(Constants.Entities.TechnologyNameRangeValidationMsg)]
        [LocalizedRange(2, 200, Constants.Entities.TechnologyNameRangeValidationMsg)]
        public string Name { get; set; }
    }
}
