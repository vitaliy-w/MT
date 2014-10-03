using MT.ModelEntities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MT.ModelEntities.Entities
{
    public class LibraryResource
    {
        /// <summary>
        /// Унікальний цифровий ідентифікатор для даної сутності.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Ім'я ресурсу. 
        /// Обов'язкове поле.
        /// Максимальна довжина 100 смволів.
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Рівень доступу до ресурсу.
        /// Private = 1   - доступний лише для власника.
        /// Protected = 2 - доступний для власника та користувачів з якими у нього взаємний "follow".
        /// Public = 3    - доступний для всіх користувачів.
        /// </summary>
        public AccessLevelsEnum Access { get; set; }

        /// <summary>
        /// Url посилання на ресурс
        /// </summary>
        [Url]
        public string Url { get; set; }

        /// <summary>
        /// Детальний опис ресурсу. 
        /// Обов'язкове поле.
        /// Максимальна довжина 500 смволів.
        /// </summary>
        [Required, MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Зовнішній ключ.
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
