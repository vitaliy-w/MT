using System.Globalization;

namespace MT.Utility
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the string to camel case (the first char should be in lower case).
        /// </summary>
        public static string ToCamelCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (text.Length == 1)
                return text.ToLowerInvariant();

            return text[0].ToString(CultureInfo.InvariantCulture).ToLowerInvariant() + text.Substring(1);
        }

    }
}
