using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MT.ModelEntities.Entities
{
   public class LocalisationResource
    {
     
       [Key, Column(Order = 0)] /// Первая часть составного ключа
       [Required]
       [StringLength(100, ErrorMessage = "More than 100 in ResourceKey symbols are not allowed")] /// Максимальная длинна 100 символов
       public string ResourceKey { get; set; }

       [Key, Column(Order = 1)] //вторая часть составного ключа
       [Required]
       [StringLength(5, ErrorMessage = "More than 5 symbols in ResourceCulture Code are not allowed")] /// Максимальная длинна 5 символов
       public string ResourceCultureCode { get; set; }

       [Required]
       public string LocalizedResource { get; set; } /// собственно сам ресурс для локализации

       
    }

  
}
