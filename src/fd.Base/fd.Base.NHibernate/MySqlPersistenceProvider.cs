using FluentNHibernate.Cfg.Db;

namespace fd.Base.NHibernate
{
    /// <summary>Provides a simple My SQL Server configuration.</summary>
    public class MySqlPersistenceProvider : IPersistenceConfigurerProvider
    {
        private readonly string _connectionString;
        private readonly bool _showSql;

        /// <summary>Initializes a new instance of the <see cref="MySqlPersistenceProvider" /> class.</summary>
        /// <param name="connectionString">The connection string.</param>
        public MySqlPersistenceProvider(string connectionString)
            : this(connectionString, false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="MySqlPersistenceProvider" /> class.</summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="showSql">if set to <c>true</c> enables the "Show SQL" option.</param>
        public MySqlPersistenceProvider(string connectionString, bool showSql)
        {
            _connectionString = connectionString;
            _showSql = showSql;
        }

        /// <summary>Gets this specific persistence configurer.</summary>
        /// <returns>The configured persistence configurer.</returns>
        public IPersistenceConfigurer Get()
        {
            var result = MySQLConfiguration.Standard.ConnectionString(_connectionString);
            if (_showSql)
                result.ShowSql();
            return result;
        }
    }
}
