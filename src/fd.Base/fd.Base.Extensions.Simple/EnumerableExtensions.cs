using System.Collections.Generic;
using System.Linq;

namespace fd.Base.Extensions.Simple
{
    /// <summary>Contains extension methods for enumerables.</summary>
    public static class EnumerableExtensions
    {
        /// <summary>Makes the specified object enumerable.</summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="obj">The object to make enumerable.</param>
        /// <returns>An <see cref="System.Collections.Generic.IEnumerable`1" /> containing the specified object.</returns>
        public static IEnumerable<T> MakeEnumerable<T>(this T obj)
        {
            yield return obj;
        }

        /// <summary>
        /// Converts an <see cref="System.Collections.Generic.IEnumerable`1" /> to an <see cref="System.Collections.Generic.IList`1" /> . If the
        /// <paramref name="enumerable"/> already is in fact a <see cref="System.Collections.Generic.IList`1" /> , no new
        /// <see cref="System.Collections.Generic.IList`1" /> will be created. Otherwise,
        /// <see cref="Enumerable.ToList``1(System.Collections.Generic.IEnumerable{``0})" /> will be used.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the <see cref="System.Collections.Generic.IEnumerable`1" /> .</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>An <see cref="System.Collections.Generic.IList`1" /> containing the items of the specified enumerable.</returns>
        public static IList<T> ToListCheap<T>(this IEnumerable<T> enumerable)
        {
            var result = enumerable as IList<T>;
            return result ?? enumerable.ToList();
        }
    }
}
