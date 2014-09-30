using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ModelEntities.Entities
{
    /// <summary>
    /// Класс для создание запроса на новый проект
    /// </summary>
    public class PostRequest
    {
        /// <summary>
        /// Уникальный эдинтификатор запроса
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Имя самого запроса
        /// </summary>
        [Display(Name = "Name")]
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Описание запроса
        /// </summary>
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Видимость запроса (Public или Private)
        /// </summary>
        [Display(Name = "Request Posting Visibility")]
        [Required]
        public bool RequestPostingVisibility { get; set; }

        /// <summary>
        /// Предпочтения по расположению кандидатов
        /// </summary>
        [Display(Name = "Preferred Candidate Location")]
        [Required]
        public bool PreferredCandidateLocation { get; set; }

        /// <summary>
        /// Запостить этот запрос на определенное количество дней
        /// </summary>
        [Display(Name = "Post This Request For"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [Required]
        public DateTime PostPeriod { get; set; }

        /// <summary>
        /// Предпологаемая дата начала
        /// </summary>
        [Display(Name = "Proposed Start Date"), DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }
    }
}
