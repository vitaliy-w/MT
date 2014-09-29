using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MT.ModelEntities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль должен быть минимум 6 символов")]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля (поле не сохраняется в БД)
        /// </summary>
        [NotMapped]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Время создания пользователя
        /// </summary>
        public DateTime? Created { get; set; }

    }
}
