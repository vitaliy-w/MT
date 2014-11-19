using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MT.ModelEntities;
using MT.ModelEntities.Entities;
using MT.Utility.Localization.Attributes;

namespace MT.Web.Models
{
    /// <summary>
    /// Represents information about UserEducation for View.
    /// </summary>
    public class UserEducationViewModel
    {

        /// <summary>
        /// Represents number of education block.
        /// </summary>
        [HiddenInput]
        [ScaffoldColumn(false)]
        public int EducationId { get; set; }

        /// <summary>
        /// Represents level of User's education.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserEducationEducationLevelDisplayName)]
        [LocalizedStringLength(30, Constants.Entities.CommonMaxStringLength30)]
        public string EducationLevel { get; set; }

        /// <summary>
        /// Represents User's name of school.
        /// </summary>
        [LocalizedRequired(Constants.Entities.UserEducationNameOfSchoolRequried)]
        [LocalizedDisplayName(Constants.Entities.UserEducationNameOfSchoolDisplayName)]
        [LocalizedStringLength(50, Constants.Entities.CommonMaxStringLength50)]
        public string NameOfSchool { get; set; }

        /// <summary>
        /// Represents User's specialization.
        /// </summary>
        [LocalizedRequired(Constants.Entities.UserEducationSpecializationRequried)]
        [LocalizedDisplayName(Constants.Entities.UserEducationSpecializationDisplayName)]
        [LocalizedStringLength(50, Constants.Entities.CommonMaxStringLength50)]
        public string Specialization { get; set; }

        /// <summary>
        /// Displays month when Users starts his education.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserEducationMonthStartsFromDisplayName)]
        public string MonthStartsFrom { get; set; }

        /// <summary>
        /// Displays yaer when Users starts his education.
        /// </summary>
        public short YearStartsFrom { get; set; }

        /// <summary>
        /// Displays month when Users ends his education.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserEducationMonthEndsFromDisplayName)]
        public string MonthEndsFrom { get; set; }

        /// <summary>
        /// Displays month when Users starts his education.
        /// </summary>
        public short YearEndsFrom { get; set; }

        /// <summary>
        /// Represents any additional inforamtion from User.
        /// </summary>
        [LocalizedDisplayName(Constants.Entities.UserEducationAdditionalInformationDisplayName)]
        [LocalizedStringLength(140, Constants.Entities.CommonMaxStringLength140)]
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Creates list of userEducationViewModels from list of userEducation.
        /// </summary>
        public static List<UserEducationViewModel> CreateList(IEnumerable<UserEducation> userEducationList)
        {
            var collection = new List<UserEducationViewModel>(3);
            foreach (var userEducation in userEducationList)
            {
                var item = new UserEducationViewModel()
                {
                    AdditionalInformation = userEducation.AdditionalInformation,
                    EducationLevel = userEducation.EducationLevel,
                    EducationId = userEducation.EducationId,
                    NameOfSchool = userEducation.NameOfSchool,
                    MonthEndsFrom = userEducation.MonthEndsFrom,
                    Specialization = userEducation.Specialization,
                    MonthStartsFrom = userEducation.MonthEndsFrom,
                    YearEndsFrom = userEducation.YearEndsFrom,
                    YearStartsFrom = userEducation.YearStartsFrom
                };
                collection.Add(item);
            }

            return collection;
        }

        /// <summary>
        /// Converts current UserEducationViewModel to UserEducation adding userEmail.
        /// </summary>
        public UserEducation ConvertToUserEducationItem(string userEmail)
        {

            return new UserEducation()
            {
                AdditionalInformation = AdditionalInformation,
                EducationLevel = EducationLevel,
                EducationId = EducationId,
                NameOfSchool = NameOfSchool,
                MonthEndsFrom = MonthEndsFrom,
                Specialization = Specialization,
                MonthStartsFrom = MonthEndsFrom,
                YearEndsFrom = YearEndsFrom,
                YearStartsFrom = YearStartsFrom,
                UserEmail = userEmail
                
            };
        }

    }
}

