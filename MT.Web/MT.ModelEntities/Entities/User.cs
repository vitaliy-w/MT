using System;
using System.ComponentModel.DataAnnotations;

namespace MT.ModelEntities.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? Created { get; set; }

    }
}
