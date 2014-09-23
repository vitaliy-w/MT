using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace MT.ModelEntities.Entities
{
    public class LocalisationResource
    {
        /// <remarks>
        ///  Первая часть составного ключа
        /// Максимальная длинна ключа 100 символов
        /// </remarks>>
        [Key, Column(Order = 0)] 
        [Required]
        [StringLength(100, ErrorMessage = "More than 100 in ResourceKey symbols are not allowed" )] 
        public string ResourceKey { get; set; }

        /// <remarks>
        /// Вторая часть составного ключа. Ключ культуры языка в формате en-US, ru-RU, en-GB
        /// Максимальная длинна 5 символов
        /// </remarks>
        [Key, Column(Order = 1)] 
        [Required]
        [StringLength(5, ErrorMessage = "More than 5 symbols in ResourceCulture Code are not allowed")] 
        public string ResourceCultureCode { get; set; }


        /// <remarks>
        /// Cам ресурс для локализации
        /// </remarks>
        [Required]
        public string LocalizedResource { get; set; } 
        
    }






}