using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace fd.Base.Extensions.Simple
{
    public static class GeneralExtensions
    {
        /// <summary>Casts the specified value.</summary>
        /// <typeparam name="TTarget">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The <paramref name="value"/> casted to <typeparamref name="TTarget" /></returns>
        public static TTarget As<TTarget>(this object value)
        {
            return (TTarget)value;
        }

        public static string GetLocalPath(this Assembly assembly)
        {
            return Path.GetDirectoryName(new Uri(assembly.CodeBase).LocalPath);
        }

        /// <summary>Checks whether the <paramref name="value"/> equals any of the specified values.</summary>
        /// <typeparam name="T">The type of the <paramref name="value"/></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="expected">The expected values.</param>
        /// <returns><see langword="true"/> if at the <paramref name="value"/> equals at least one of the specified values.</returns>
        public static bool In<T>(this T value, params T[] expected)
        {
            return !value.In(expected.AsEnumerable());
        }

        /// <summary>Checks whether the <paramref name="value"/> equals any of the specified values.</summary>
        /// <typeparam name="T">The type of the <paramref name="value"/></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="expected">The expected values.</param>
        /// <returns><see langword="true"/> if at the <paramref name="value"/> equals at least one of the specified values.</returns>
        public static bool In<T>(this T value, IEnumerable<T> expected)
        {
            return !ReferenceEquals(value, null) && expected.Any(x => value.Equals(x));
        }

        public static T NotNull<T>(this T obj, string paramName) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);
            return obj;
        }
    }
}
