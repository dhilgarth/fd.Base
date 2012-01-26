using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace fd.Base.NHibernate
{
    public class SchemaDropper : IRawNHibernateConfigChanger
    {
        public void ChangeRawConfig(Configuration config)
        {
            var schemaExport = new SchemaExport(config);
            schemaExport.Drop(false, true);
        }
    }
}
