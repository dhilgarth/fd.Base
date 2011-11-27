using System;

namespace fd.Base.Extensions.Simple
{
    /// <summary>
    /// Provides literal extension methods.
    /// </summary>
    public static class LiteralExtensions
    {
        /// <summary>
        /// Returns a TimeSpan representing the specified number of days.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Days(this int value)
        {
            return TimeSpan.FromDays(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of days.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Days(this double value)
        {
            return TimeSpan.FromDays(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of hours.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Hours(this int value)
        {
            return TimeSpan.FromHours(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of hours.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Hours(this double value)
        {
            return TimeSpan.FromHours(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of milliseconds.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Milliseconds(this int value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of milliseconds.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Milliseconds(this double value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of minutes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Minutes(this int value)
        {
            return TimeSpan.FromMinutes(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of minutes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Minutes(this double value)
        {
            return TimeSpan.FromMinutes(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of seconds.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Seconds(this int value)
        {
            return TimeSpan.FromSeconds(value);
        }

        /// <summary>
        /// Returns a TimeSpan representing the specified number of seconds.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The TimeSpan.</returns>
        public static TimeSpan Seconds(this double value)
        {
            return TimeSpan.FromSeconds(value);
        }
    }
}
