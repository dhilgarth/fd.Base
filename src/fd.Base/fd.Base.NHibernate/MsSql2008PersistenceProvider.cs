using FluentNHibernate.Cfg.Db;

namespace fd.Base.NHibernate
{
    public class MsSql2008PersistenceProvider : IPersistenceConfigurerProvider
    {
        //private const string DbFile = @"Data Source=C:\Temp\Download\MyDB.sdf";
        //private const string DbFile = @"Data Source=DHILGARTH-01\SQLEXPRESS;Initial Catalog=VoxBox;Persist Security Info=True;User ID=sa;Password=sa1234";
        private readonly string _connectionString;

        public MsSql2008PersistenceProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region IPersistenceConfigurerProvider Members

        public IPersistenceConfigurer Get()
        {
            return MsSqlConfiguration.MsSql2008.ConnectionString(_connectionString);
        }

        #endregion
    }
}
