using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MT.ModelEntities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Максимальное количество символов в имени пользователя - 50")]
        [Required(ErrorMessage = "Поле логин обязательно для заполнения")]
        [Remote("CheckUserName", "Account", ErrorMessage = "Логин занят")]
        public string UserName { get; set; }

        [MaxLength(50, ErrorMessage = "Максимальное количество символов в поле Email пользователя - 50")]
        [Required(ErrorMessage = "Поле Email обязательно для заполнения")]
        [Remote("CheckEmail", "Account", ErrorMessage = "Пользователь с такой почтой уже зарегистрирован")]
        [RegularExpression(@"/^([a-z0-9_\.-]+)@([a-z0-9_\.-]+)\.([a-z\.]{2,6})$/", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароль обязательно для заполнения")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль должен быть минимум 6 символов")]
        public string Password { get; set; }

        /// <summary>
        /// Подтверждение пароля (поле не сохраняется в БД)
        /// </summary>
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Время создания пользователя
        /// </summary>
        public DateTime? Created { get; set; }

    }
}
