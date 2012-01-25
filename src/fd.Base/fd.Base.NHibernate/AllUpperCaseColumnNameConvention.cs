using fd.Base.Extensions.Simple;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace fd.Base.NHibernate
{
    /// <summary>
    ///   A convention that creates all upper case column names with underscores between words.
    /// </summary>
    public class AllUpperCaseColumnNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(instance.Name.PascalCaseToAllUpperCase());
        }
    }
}
