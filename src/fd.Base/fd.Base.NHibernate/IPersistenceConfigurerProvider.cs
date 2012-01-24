using FluentNHibernate.Cfg.Db;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// Provides persistence configurer. 
    /// </summary>
    public interface IPersistenceConfigurerProvider
    {
        /// <summary>
        ///   Gets this specific persistence configurer.
        /// </summary>
        /// <returns> The configured persistence configurer. </returns>
        IPersistenceConfigurer Get();
    }
}
