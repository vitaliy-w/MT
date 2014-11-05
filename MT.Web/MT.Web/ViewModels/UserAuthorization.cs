using System.ComponentModel.DataAnnotations;
using MT.ModelEntities;
using MT.Utility.Localization.Attributes;

namespace MT.Web.ViewModels
{
    public class UserAuthorization
    {
        [Key]
        public int Id { get; set; }

        [LocalizedRequired(Constants.Entities.UserEmailRequiredValidationMsg)]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [LocalizedRequired(Constants.Entities.UserPasswordRequiredValidationMsg)]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}