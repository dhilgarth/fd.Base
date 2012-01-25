using System.Linq;
using System.Text;

namespace fd.Base.Extensions.Simple
{
    /// <summary>
    ///   Contains extensions to the <see cref="string" /> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///   Determines whether the end of the specified string matches any of the specified values.
        /// </summary>
        /// <param name="this"> The string to check. </param>
        /// <param name="values"> The values to check the string against. </param>
        /// <returns> <c>true</c> if the string ends with any of the supplied values; otherwise, <c>false</c> . </returns>
        public static bool EndsWithAny(this string @this, params string[] values)
        {
            return values.Any(@this.EndsWith);
        }

        /// <summary>
        ///   Determines whether the specified string is <c>null</c> or <see cref="string.Empty" /> .
        /// </summary>
        /// <param name="this"> The string to check. </param>
        /// <returns> <c>true</c> if specified string is null or empty; otherwise, <c>false</c> . </returns>
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        /// <summary>
        ///   Changes a Pascal Case string to an All Upper Case string.
        /// </summary>
        /// <param name="value"> The string to change. </param>
        /// <returns> The input string in All Upper Case </returns>
        /// <example>
        ///   PascalCase will yield PASCAL_CASE
        /// </example>
        /// <example>
        ///   camelCase will yield CAMEL_CASE
        /// </example>
        /// <example>
        ///   Street2 will yield STREET_2
        /// </example>
        /// <example>
        ///   House2number will yield HOUSE_2NUMBER
        /// </example>
        /// <example>
        ///   Crc32 will yield CRC_32
        /// </example>
        /// <remarks>
        ///   Existing underscores are not interpreted, i.e. Pascal_Case will yield PASCAL__CASE.
        /// </remarks>
        public static string PascalCaseToAllUpperCase(this string value)
        {
            var sb = new StringBuilder();
            var lastLetterWasDigit = false;
            foreach (var letter in value)
            {
                if (sb.Length > 0)
                {
                    if (char.IsUpper(letter))
                    {
                        sb.Append("_");
                        lastLetterWasDigit = false;
                    }
                    else if (char.IsDigit(letter))
                    {
                        if (!lastLetterWasDigit)
                        {
                            lastLetterWasDigit = true;
                            sb.Append("_");
                        }
                    }
                    else
                        lastLetterWasDigit = false;
                }

                sb.Append(letter);
            }

            return sb.ToString().ToUpperInvariant();
        }
    }
}
