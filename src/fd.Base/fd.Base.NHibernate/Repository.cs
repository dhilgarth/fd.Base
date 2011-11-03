using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using fd.Base.Common;

namespace fd.Base.NHibernate
{
    public class Repository : IRepository
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");
            _session = session;
        }

        #region IRepository Members

        public T SingleOrDefault<T>(int id)
        {
            return _session.Get<T>(id);
        }

        public T Single<T>(int id)
        {
            return _session.Load<T>(id);
        }

        public IQueryable<T> Get<T>()
        {
            return _session.Query<T>();
        }

        public void Delete<T>(T obj)
        {
            _session.Delete(obj);
        }

        public void Save<T>(T obj)
        {
            _session.SaveOrUpdate(obj);
        }

        #endregion
    }
}
