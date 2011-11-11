using System.Linq;

namespace fd.Base.Extensions.Simple
{
    /// <summary>
    /// Contains extensions to the <see cref="string"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the end of the specified string matches any of the specified values.
        /// </summary>
        /// <param name="this">
        /// The string to check.
        /// </param>
        /// <param name="values">
        /// The values to check the string against.
        /// </param>
        /// <returns>
        /// <c>true</c> if the string ends with any of the supplied values; otherwise, <c>false</c>.
        /// </returns>
        public static bool EndsWithAny(this string @this, params string[] values)
        {
            return values.Any(@this.EndsWith);
        }

        /// <summary>
        /// Determines whether the specified string is <c>null</c> or <see cref="string.Empty"/>.
        /// </summary>
        /// <param name="this">
        /// The string to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if specified string is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }
    }
}
