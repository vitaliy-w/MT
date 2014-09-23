using MT.ModelEntities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MT.ModelEntities.Entities
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        public string Name { get; set; }

        public LevelAccess Access { get; set; }

        public string Link { get; set; }

        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }
    }
}
