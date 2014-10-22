using System;
using System.Linq;

namespace MT.Utility.Extensions
{
    public static class DateTimePeriodTypeHelper
    {
        /// <summary>
        /// Returns a DateTimePeriodType by the name that is specified in the DisplayAttribute
        /// </summary>
        public static DateTimePeriodType GetByName(string name)
        {
            var result = Enum.GetValues(typeof(DateTimePeriodType))
                .Cast<DateTimePeriodType>()
                .FirstOrDefault(t => t.GetDisplayName().Equals(name));
            return result;
        }
    }
}