using System;
namespace MT.Utility.Localization.Attributes
{
    /// <summary>
    /// Represents a string value for an enum item
    /// </summary>
    public class EnumDisplayNameAttribute : Attribute
    {
        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }


        public EnumDisplayNameAttribute(string value)
        {
            this.StringValue = value;
        }


    }
}