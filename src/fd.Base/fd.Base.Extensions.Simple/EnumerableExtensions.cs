using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Converts an <see cref="IEnumerable{T}"/> to an <see cref="IList{T}"/>. If the enumerable already is in fact a <see cref="IList{T}"/>,
        ///   no new <see cref="IList{T}"/> will be created. Otherwise, <see cref="Enumerable.ToList{TSource}"/> will be used.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the objects in the <see cref="IEnumerable{T}"/>.
        /// </typeparam>
        /// <param name="enumerable">
        /// The enumerable.
        /// </param>
        /// <returns>
        /// An <see cref="IList{T}"/> containing the items of the specified enumerable.
        /// </returns>
        public static IList<T> ToListCheap<T>(this IEnumerable<T> enumerable)
        {
            var result = enumerable as IList<T>;
            return result ?? enumerable.ToList();
        }
    }
}
