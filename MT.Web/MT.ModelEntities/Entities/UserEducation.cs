using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MT.ModelEntities.Enums;
using MT.Utility.Localization.Attributes;

namespace MT.ModelEntities.Entities
{
    /// <summary>
    /// Represents information about user education with UserId.
    /// </summary>
    public class UserEducation
    {
        /// <summary>
        /// Represents UserEmail. Part of primary key.
        /// </summary>
        [ScaffoldColumn(false)]
        [Key, Column(Order = 0)]
        public string UserEmail { get; set; }

        /// <summary>
        /// Represents number of education block. Part of primary key.
        /// </summary>
        [Key, Column(Order = 1)]
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

    }
}
