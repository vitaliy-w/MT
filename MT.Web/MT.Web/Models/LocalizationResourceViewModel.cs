using System;
using System.ComponentModel.DataAnnotations;
using MT.ModelEntities.Enums;
using MT.Utility.Localization.Attributes;

namespace MT.Web.Models
{
    /// <summary>
    /// Сущность-посредник принимающая данные от пользвателя и передающая их в сущности LocalizationResource.
    /// Позволяет принимать под один ResourceKey несколько пар ResourceCultureCode-LocalizedResource.
    /// </summary>

    public class LocalizationResourceViewModel
    {
        /// <summary>
        /// Unique identifier for the resource with max length  = 100 characters.
        /// </summary>
        [LocalizedRange(1, 100, "The ResourceKey cannot exceed 100 characters.")]
        public string ResourceKey { get; set; }


        [LocalizedRequired("Culture code is required.")]
        public ResourceCultureCodeTypesEnum[] ResourceCultureCodes { get; set; }

        /// <summary>
        /// Localized resource.
        /// </summary>
        [LocalizedRequired("LocalizedResource is required.")]
        public string[] LocalizedResources { get; set; }

    }
}
