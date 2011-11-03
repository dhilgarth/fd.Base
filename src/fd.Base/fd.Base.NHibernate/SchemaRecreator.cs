using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace fd.Base.NHibernate
{
    public class SchemaRecreator : IRawNHibernateConfigChanger
    {
        #region IRawNHibernateConfigChanger Members

        public void ChangeRawConfig(Configuration config)
        {
            var schemaExport = new SchemaExport(config);
            schemaExport.Drop(false, true);
            schemaExport. /*SetOutputFile(@"C:\Temp\Download\MyDDL.sql").*/Create(false, true);
        }

        #endregion
    }
}
