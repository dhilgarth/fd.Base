using fd.Base.Extensions.Simple;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace fd.Base.NHibernate
{
    /// <summary>
    ///   A convention that changes all table names to all upper case.
    /// </summary>
    public class AllUpperCaseTableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table(instance.EntityType.Name.PascalCaseToAllUpperCase());
        }
    }
}
