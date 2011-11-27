using System.Linq;

namespace fd.Base.Common
{
    /// <summary>
    /// Represents a generic repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the object to be deleted.
        /// </typeparam>
        /// <param name="obj">
        /// The object to be deleted.
        /// </param>
        void Delete<T>(T obj);

        /// <summary>
        /// Gets all objects of the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The type to return all objects for.
        /// </typeparam>
        /// <returns>
        /// The objects of the specified type.
        /// </returns>
        IQueryable<T> Get<T>();

        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the object to save.
        /// </typeparam>
        /// <param name="obj">
        /// The object to save.
        /// </param>
        void Save<T>(T obj);

        /// <summary>
        /// Returns the only element of the specified type with the specified ID; this method throws an exception
        ///   if there is no or more than one matching element.
        /// </summary>
        /// <typeparam name="T">
        /// The type to return.
        /// </typeparam>
        /// <param name="id">
        /// The ID of the element to return.
        /// </param>
        /// <returns>
        /// The element with the specified ID.
        /// </returns>
        T Single<T>(int id);

        /// <summary>
        /// Returns the only element of the specified type with the specified ID,
        ///   or a default value if no matching element exists; this method throws an exception if there is more than one matching element.
        /// </summary>
        /// <typeparam name="T">
        /// The type to return.
        /// </typeparam>
        /// <param name="id">
        /// The ID of the element to return.
        /// </param>
        /// <returns>
        /// The element with the specified ID or <c>default(T)</c>.
        /// </returns>
        T SingleOrDefault<T>(int id);
    }
}
