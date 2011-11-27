using System;
using System.Linq;
using fd.Base.Common;
using NHibernate;
using NHibernate.Linq;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// A generic NHibernate repository.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly ISession _session;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        public Repository(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            _session = session;
        }

        /// <summary>
        /// Deletes the specified object.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the object to be deleted.
        /// </typeparam>
        /// <param name="obj">
        /// The object to be deleted.
        /// </param>
        public void Delete<T>(T obj)
        {
            _session.Delete(obj);
        }

        /// <summary>
        /// Gets all objects of the specified type.
        /// </summary>
        /// <typeparam name="T">
        /// The type to return all objects for.
        /// </typeparam>
        /// <returns>
        /// The objects of the specified type.
        /// </returns>
        public IQueryable<T> Get<T>()
        {
            return _session.Query<T>();
        }

        /// <summary>
        /// Saves the specified object.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the object to save.
        /// </typeparam>
        /// <param name="obj">
        /// The object to save.
        /// </param>
        public void Save<T>(T obj)
        {
            _session.SaveOrUpdate(obj);
        }

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
        public T Single<T>(int id)
        {
            return _session.Load<T>(id);
        }

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
        public T SingleOrDefault<T>(int id)
        {
            return _session.Get<T>(id);
        }

    }
}
