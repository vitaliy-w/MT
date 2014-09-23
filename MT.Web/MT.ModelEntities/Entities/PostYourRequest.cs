using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ModelEntities.Entities
{
    public class PostYourRequest
    {
        /// <summary>
        /// Уникальный эдинтификатор моего запроса
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        /// <summary>
        /// Имя самого запроса
        /// </summary>
        [Display(Name = "Name")]
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Описание моего запроса
        /// </summary>
        [Display(Name = "Description"),]
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
        [Display(Name = "Post This Request For")]
        [Required]
        public int PostThisRequestFor { get; set; }

        /// <summary>
        /// Предпологаемая дата начала
        /// </summary>
        [Display(Name = "Proposed Start Date")]
        [Required]
        public bool ProposedStartDate { get; set; }
    }
}
