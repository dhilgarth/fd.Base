using System.Linq;

namespace fd.Base.Common
{
    public interface IRepository
    {
        T SingleOrDefault<T>(int id);
        T Single<T>(int id);
        IQueryable<T> Get<T>();
        void Delete<T>(T obj);
        void Save<T>(T obj);
    }
}
