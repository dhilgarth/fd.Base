using FluentNHibernate.Cfg.Db;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// Provides a simple MS SQL Server 2008 configuration.
    /// </summary>
    public class MsSql2008PersistenceProvider : IPersistenceConfigurerProvider
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsSql2008PersistenceProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public MsSql2008PersistenceProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region IPersistenceConfigurerProvider Members

        /// <summary>
        /// Gets this specific persistence configurer.
        /// </summary>
        /// <returns>
        /// The configured persistence configurer.
        /// </returns>
        public IPersistenceConfigurer Get()
        {
            return MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString);
        }

        #endregion
    }
}
