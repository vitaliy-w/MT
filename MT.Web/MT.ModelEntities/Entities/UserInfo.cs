using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MT.Utility.Localization.Attributes;

namespace MT.ModelEntities.Entities
{
    public class UserInfo
    {
        [Key]
        [ScaffoldColumn(true)]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Максимальное количество символов в имени пользователя - 50")]
        [LocalizedRequired("Required")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Максимальное количество символов в фамилии пользователя - 50")]
        [LocalizedRange(0,50,"MaxLength")]
        public string SecondName { get; set; }

        [LocalizedDisplayName("")]
        [LocalizedRequired("Required")]
        public bool IsMan { get; set; }


    }
}
