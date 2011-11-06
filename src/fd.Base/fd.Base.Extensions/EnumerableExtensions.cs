using System.Collections.Generic;

namespace fd.Base.Extensions.Simple
{
    /// <summary>
    /// Contains extension methods for enumerables.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Makes the specified object enumerable.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the object.
        /// </typeparam>
        /// <param name="obj">
        /// The object to make enumerable.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the specified object.
        /// </returns>
        public static IEnumerable<T> MakeEnumerable<T>(this T obj)
        {
            yield return obj;
        }
    }
}
