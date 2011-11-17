using System.IO;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// Drops and re-creates the schema.
    /// </summary>
    public class SchemaRecreator : IRawNHibernateConfigChanger
    {
        private readonly bool _outputSql;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaRecreator"/> class.
        /// </summary>
        /// <param name="outputSql">
        /// If set to <c>true</c> outputs the generated SQL to files in the directory <c>NHibernate SQL</c> in the users temp directory.
        /// </param>
        public SchemaRecreator(bool outputSql)
        {
            _outputSql = outputSql;
        }

        /// <summary>
        /// Changes the raw NHibernate config.
        /// </summary>
        /// <param name="config">
        /// The configuration to change.
        /// </param>
        public void ChangeRawConfig(Configuration config)
        {
            var schemaExport = new SchemaExport(config);
            var path = string.Empty;
            if (_outputSql)
            {
                path = Path.Combine(Path.GetTempPath(), "NHibernate SQL");
                Directory.CreateDirectory(path);
                schemaExport.SetOutputFile(Path.Combine(path, "drop.sql"));
            }

            schemaExport.Drop(false, true);
            if (_outputSql)
                schemaExport.SetOutputFile(Path.Combine(path, "create.sql"));
            schemaExport.Create(false, true);
        }
    }
}
