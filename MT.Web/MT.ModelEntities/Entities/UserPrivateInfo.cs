using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.ModelEntities.Entities
{
    public class UserPrivateInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You have to enter your Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You have to enter your LastName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You have to enter your Sex")]
        public string Sex { get; set; }

        [Required]
        public DateTimeOffset TimeZone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You have to enter where are you from, yuor Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You have to enter where are you from, your City")]
        public string City { get; set; }
    }
}
