using NHibernate.Cfg;

namespace fd.Base.NHibernate
{
    public class NoRawNHibernateConfigChanger : IRawNHibernateConfigChanger
    {
        #region IRawNHibernateConfigChanger Members

        public void ChangeRawConfig(Configuration config) {}

        #endregion
    }
}
