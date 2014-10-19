using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Attributes;

namespace MT.ModelEntities.Entities
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        [LocalizedRange(0,50,"Max first name length is 50 characters")]
        [LocalizedRequired("Required")]
        public string Name { get; set; }

        [LocalizedRange(0,50,"Max second name length is 50 characters")]
        public string SecondName { get; set; }

        [LocalizedDisplayName("TEST")]
        [LocalizedRequired("This field is required")]
        public bool IsMan { get; set; }


    }
}
