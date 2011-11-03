using NHibernate.Cfg;

namespace fd.Base.NHibernate
{
    public interface IRawNHibernateConfigChanger
    {
        void ChangeRawConfig(Configuration config);
    }
}
