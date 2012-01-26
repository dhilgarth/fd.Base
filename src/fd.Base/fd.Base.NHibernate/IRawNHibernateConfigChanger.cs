using NHibernate.Cfg;

namespace fd.Base.NHibernate
{
    /// <summary>Represents a piece of encapsulated logic that changes the raw NHibernate configuration.</summary>
    public interface IRawNHibernateConfigChanger
    {
        /// <summary>Changes the raw NHibernate config.</summary>
        /// <param name="config">The configuration to change.</param>
        void ChangeRawConfig(Configuration config);
    }
}
