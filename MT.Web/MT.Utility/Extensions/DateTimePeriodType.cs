using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace MT.Utility.Extensions
{
    public enum DateTimePeriodType
    {
        NoValue = 0,

        [Display(Name = "Last year")]
        LastYear = 1,

        [Display(Name = "ShowThisQuarter", Description = "Show This Quarter")]
        CurrentQuarter = 2,

        [Display(Name = "ShowPreviousQuarter", Description = "Show Previous Quarter")]
        PreviousQuarter = 3,

        /// <summary>
        /// Current week which starting on sunday
        /// </summary>
        [Display(Name = "ShowThisWeek", Description = "Show This Week")]
        CurrentWeekMonday = 4,

        /// <summary>
        /// Previous week which starting on sunday
        /// </summary>
        [Display(Name = "ShowPreviousWeek", Description = "Show Previous Week")]
        WeekPreviousMonday = 5,

        [Display(Name = "ShowThisMonth", Description = "Show This Month")]
        CurrentMonth = 6,

        [Display(Name = "ShowPreviousMonth", Description = "Show Previous Month ")]
        PreviousMonth = 7,

        [Display(Name = "ShowThisYear", Description = "Show This Year")]
        CurrentYear = 8,

        [Display(Name = "ShowPreviousYear", Description = "Show Previous Year")]
        PreviousYear = 9,

        [Display(Name = "ShowQ1", Description = "Show Q1")]
        Quarter1 = 10,

        [Display(Name = "ShowQ2", Description = "Show Q2")]
        Quarter2 = 11,

        [Display(Name = "ShowQ3", Description = "Show Q3")]
        Quarter3 = 12,

        [Display(Name = "ShowQ4", Description = "Show Q4")]
        Quarter4 = 13,

        [Display(Name = "ShowToday", Description = "Show Today")]
        Today = 14,

        [Display(Name = "ShowYesterday", Description = "Show Yesterday")]
        Yesterday = 15,

        /// <remarks> 
        /// Custom period cannot be calculated. It can be retrieved by the users input
        ///</remarks>
        [Display(Name = "ShowCustomPeriod", Description = "Show Custom Period")]
        CustomPeriod = 16,
    }
}
