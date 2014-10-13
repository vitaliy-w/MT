using System;
using System.Reflection;
using MT.Utility.Localization.Attributes;

namespace MT.Utility.OtherTools
{
    public static class OtherTools
    {
        /// <summary>
        /// Returns string value of the enum
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
    