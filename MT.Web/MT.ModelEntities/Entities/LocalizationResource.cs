using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MT.ModelEntities.Entities
{
    /// <summary>
    /// Describes the text of different languages and cultures.
    /// </summary>
    public class LocalizationResource
    {
        /// <summary>
        ///  Строка, которая являеться уникальным индефикатором для конкретного текста.
        /// Максимальная длинна 100 символов.
        /// </summary>>
        [Key, Column(Order = 0)]
        [Required]
        [StringLength(100, ErrorMessage = "More than 100 in ResourceKey symbols are not allowed")]
        public string ResourceKey { get; set; }

        /// <summary>
        /// Культура языка в формате en-US, ru-RU, en-GB.
        /// Максимальная длинна 5 символов.
        /// </summary>
        [Key, Column(Order = 1)]
        [Required]
        [StringLength(5, ErrorMessage = "More than 5 symbols in ResourceCulture Code are not allowed")]
        public string ResourceCultureCode { get; set; }


        /// <summary>
        /// Переведенный текст на соответствующий язык.
        /// </summary>
        [Required]
        public string LocalizedResource { get; set; }

    }






}