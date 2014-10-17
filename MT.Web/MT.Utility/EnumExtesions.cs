using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MT.Utility.Localization.Attributes;

namespace MT.Utility
{
    public static class EnumExtesions
    {
        
        /// <summary>
        /// Returns string value of the Enum's attribute.
        /// </summary>
        public static string GetEnumStringValue(this object value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the string value attributes
            var listOfAllEnumStringValueAttributes = fieldInfo.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false) as EnumDisplayNameAttribute[];

            return listOfAllEnumStringValueAttributes != null && listOfAllEnumStringValueAttributes.Length > 0 ? listOfAllEnumStringValueAttributes[0].StringValue : String.Empty;
        }
    }
}
