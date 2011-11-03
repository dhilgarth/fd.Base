using NHibernate;

namespace fd.Base.NHibernate
{
    public interface ISessionFactoryBuilder
    {
        ISessionFactory Build();
    }
}
