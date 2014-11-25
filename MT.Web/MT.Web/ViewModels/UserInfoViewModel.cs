using System;
using System.ComponentModel.DataAnnotations;
using MT.ModelEntities;
using MT.ModelEntities.Entities;
using MT.Utility.Localization.Attributes;

namespace MT.Web.ViewModels
{
    public class UserInfoViewModel
    {
        
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

        public UserInfo ConvertToUserInfoItem(string userEmail)
        {
            return new UserInfo()
            {
                UserEmail = userEmail,
                Name = this.Name,
                SecondName = this.SecondName,
                IsMan = this.IsMan,
                DateOfBirth = this.DateOfBirth,
                CountryOfOrigin = this.CountryOfOrigin,
                City = this.City,
                UTCZone = this.UTCZone
            };
        }

        public static UserInfoViewModel CreateFromUserInfo(UserInfo userInfo)
        {
            if (userInfo == null) return null;

            return new UserInfoViewModel()
            {

                Name = userInfo.Name,
                SecondName = userInfo.SecondName,
                IsMan = userInfo.IsMan,
                DateOfBirth = userInfo.DateOfBirth,
                CountryOfOrigin = userInfo.CountryOfOrigin,
                City = userInfo.City,
                UTCZone = userInfo.UTCZone
            };
        }

        private int ConvertUTCtoInt(string utc)
        {
            int result = int.Parse(utc.Split(' ')[1]);
            return result;

        }

    }
}