using System.ComponentModel.DataAnnotations;

namespace MT.Web.ViewModels
{
    public class UserAuthorization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}