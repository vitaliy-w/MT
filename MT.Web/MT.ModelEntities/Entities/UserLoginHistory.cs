using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MT.ModelEntities.Entities
{
    public class UserLoginHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime LoginDate { get; set; }

        public bool LoginResult { get; set; }
    }
}
