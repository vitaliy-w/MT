using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MT.ModelEntities.Entities;
using MT.ModelEntities.Enums;
using MT.Utility;
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

        [LocalizedRequired("Key is required")]
        [StringLength(100, ErrorMessage = "Too much characters")]

        public string ResourceKey { get; set; }


        [LocalizedRequired("Culture code is required.")]
        public ResourceCultureCodeTypesEnum[] ResourceCultureCodes { get; set; }

        /// <summary>
        /// Array of the localized resources.
        /// </summary>
        [LocalizedRequired("LocalizedResource is required.")]
        public string[] LocalizedResources { get; set; }


        /// <summary>
        /// Converts LocalizationResourceViewModel into list of LocalizationResource(s)
        /// </summary>
        /// <returns></returns>
        public List<LocalizationResource> GetLocalizationResources()
        {
            int counter = (ResourceCultureCodes.Length <= LocalizedResources.Length) ? ResourceCultureCodes.Length : LocalizedResources.Length;

            var listOfLocalizationResources = new List<LocalizationResource>(ResourceCultureCodes.Length);
            for (int i = 0; i < counter; i++)
            {
                var localizedResource = LocalizedResources[i];
                var resourceKey = ResourceKey;
                var resourceCultureCode = ResourceCultureCodes[i].GetEnumStringValue();

                listOfLocalizationResources.Add(new LocalizationResource() { ResourceKey = resourceKey, LocalizedResource = localizedResource, ResourceCultureCode = resourceCultureCode });
            }
            return listOfLocalizationResources;

        }

      

    }
}
