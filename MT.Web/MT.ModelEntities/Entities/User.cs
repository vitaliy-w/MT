using System.ComponentModel.DataAnnotations;

namespace MT.ModelEntities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Login { get; set; }
        public string PaswordHash { get; set; }
    }
}
