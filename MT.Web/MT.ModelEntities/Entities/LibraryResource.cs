using MT.ModelEntities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MT.Utility.Localization.Attributes;

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
        [LocalizedDisplayName(Constants.Entities.LibraryResourceName)]
        [LocalizedRequired(Constants.Entities.LibraryResourceNameRequiredValidationMsg)]
        [LocalizedRange(2, 100, Constants.Entities.LibraryResourceNameRangeValidationMsg)]
        public string Name { get; set; }

        /// <summary>
        /// Рівень доступу до ресурсу.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.LibraryResourceAccess)]
        public AccessLevelsEnum Access { get; set; }

        /// <summary>
        /// Url посилання на ресурс
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.LibraryResourceUrl)]
        [LocalizedRequired(Constants.Entities.LibraryResourceUrlRequiredValidationMsg)]
        [Url]
        public string Url { get; set; }

        /// <summary>
        /// Детальний опис ресурсу. 
        /// Обов'язкове поле.
        /// Максимальна довжина 500 смволів.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.LibraryResourceDescription)]
        [LocalizedRequired(Constants.Entities.LibraryResourceDescriptionRequiredValidationMsg)]
        [LocalizedRange(2, 500, Constants.Entities.LibraryResourceDescriptionRangeValidationMsg)]
        public string Description { get; set; }

        /// <summary>
        /// Зовнішній ключ.
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
