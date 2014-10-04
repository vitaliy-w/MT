using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MT.Utility.Localization.Attributes;
using MT.Utility.Localization.Services;

namespace MT.ModelEntities.Entities
{
    /// <summary>
    /// Describes the text of different languages and cultures.
    /// </summary>
    public class LocalizationResource : IKeyValueEntity
    {
        /// <summary>
        ///  Строка, которая являеться уникальным индефикатором для конкретного текста.
        /// Максимальная длинна 100 символов.
        /// </summary>>
        [Key, Column(Order = 0)]
        [LocalizedRequired(Constants.Entities.LibraryResourceNameRequiredValidationMsg)]
        [StringLength(100, ErrorMessage = "More than 100 in ResourceKey symbols are not allowed")]
        public string ResourceKey { get; set; }

        /// <summary>
        /// Культура языка в формате en-US, ru-RU, en-GB.
        /// Максимальная длинна 5 символов.
        /// </summary>
        [Key, Column(Order = 1)]
        [LocalizedRequired(Constants.Entities.LibraryResourceNameRequiredValidationMsg)]
        [StringLength(5, ErrorMessage = "More than 5 symbols in ResourceCulture Code are not allowed")]
        public string ResourceCultureCode { get; set; }


        /// <summary>
        /// Переведенный текст на соответствующий язык.
        /// </summary>
        [LocalizedRequired(Constants.Entities.LibraryResourceNameRequiredValidationMsg)]
        public string LocalizedResource { get; set; }
    }
}