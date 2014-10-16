using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MT.ModelEntities.Entities
{
    public class UserBan
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public DateTime StartBanTime { get; set; }

        public bool UserIsBan { get; set; }

        public int AttemptCount { get; set; }
    }
}
