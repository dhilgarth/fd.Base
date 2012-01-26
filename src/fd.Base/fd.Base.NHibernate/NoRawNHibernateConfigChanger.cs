using NHibernate.Cfg;

namespace fd.Base.NHibernate
{
    public class NoRawNHibernateConfigChanger : IRawNHibernateConfigChanger
    {
        public void ChangeRawConfig(Configuration config)
        {
        }
    }
}
