using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MT.ModelEntities.Entities
{
   public class LocalisationTable
    {
     
       [Key, Column(Order = 0)]
       [Required]
       [StringLength(100, ErrorMessage = "More than 100 in ResourceKey symbols are not allowed")]
       public string ResourceKey { get; set; }

       [Key, Column(Order = 1)]
       [Required]
       [StringLength(5, ErrorMessage = "More than 5 symbols in ResourceCulture Code are not allowed")]
       public string ResourceCultureCode { get; set; }

       [Required]
       public string LocalizedResource { get; set; }

       
    }

  
}
