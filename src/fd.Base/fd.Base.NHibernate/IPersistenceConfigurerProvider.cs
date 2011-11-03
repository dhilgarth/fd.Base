using FluentNHibernate.Cfg.Db;

namespace fd.Base.NHibernate
{
    public interface IPersistenceConfigurerProvider
    {
        IPersistenceConfigurer Get();
    }
}
