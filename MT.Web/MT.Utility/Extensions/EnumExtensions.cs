using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Utility.Extensions
{
    public static class EnumExtensions
    {
        private static DisplayAttribute GetDisplayAttribute(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var displayAttribute =
                fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            return displayAttribute;
        }

        /// <summary>
        /// Returns the Display Name of the given value
        /// </summary>
        /// <remarks>If the value is not decorated with the DisplayAttribute then returns null</remarks>
        public static string GetDisplayName(this Enum value)
        {
            var displayAttribute = GetDisplayAttribute(value);
            return displayAttribute == null ? string.Empty : displayAttribute.Name;
        }

        /// <summary>
        /// Returns the Display Description of the given value
        /// </summary>
        /// <remarks>If the value is not decorated with the DisplayAttribute then returns null</remarks>
        public static string GetDisplayDescription(this Enum value)
        {
            var displayAttribute = GetDisplayAttribute(value);
            return displayAttribute == null ? string.Empty : displayAttribute.Description;
        }
    }
}
