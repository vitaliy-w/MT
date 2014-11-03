using System;
using System.ComponentModel.DataAnnotations;
using MT.Utility.Localization.Attributes;


namespace MT.ModelEntities.Entities
{
    public class UserInfo
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents users Name. 
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoNameDispalyName)]
        [LocalizedRequired(Constants.Entities.UserInfoRequiredValidationMsg)]
        [LocalizedStringLength(30, Constants.Entities.CommonMaxStringLength30)]
        public string Name { get; set; }

        
        /// <summary>
        /// Represents users Second name.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoSecondNameDisplayName)]
        [LocalizedStringLength(30, Constants.Entities.CommonMaxStringLength30)]
        public string SecondName { get; set; }

        /// <summary>
        /// Represents users Date of birht.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoDateOfBirthDisplayName)]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Represents users Country.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoCountryOfOriginDispalyName)]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Represents users City.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoCityDispalyName)]
        [LocalizedStringLength(30, Constants.Entities.CommonMaxStringLength30)]
        public string City { get; set; }

        /// <summary>
        /// Represents users Sex.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoIsManDisplayName)]
        public bool IsMan { get; set; }

        /// <summary>
        /// Represents current User's UTCZone.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserInfoUTCZoneDisplayName)]
        public int? UTCZone { get; set; }


    }
}
