using System.ComponentModel.DataAnnotations;

namespace MT.ModelEntities.Entities
{
    /// <summary>
    /// сущность пользователя данные о котором мы получаем с сервисов
    /// </summary>
    public class ExternalUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProviderUserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Provider { get; set; }

    }
}
