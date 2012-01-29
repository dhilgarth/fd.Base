using NHibernate.Cfg;

namespace fd.Base.NHibernate
{
    /// <summary>A raw NHibernate config changer that does nothing.</summary>
    public class NoOpRawNHibernateConfigChanger : IRawNHibernateConfigChanger
    {
        /// <summary>Changes the raw NHibernate config.</summary>
        /// <param name="config">The configuration to change.</param>
        public void ChangeRawConfig(Configuration config)
        {
        }
    }
}
