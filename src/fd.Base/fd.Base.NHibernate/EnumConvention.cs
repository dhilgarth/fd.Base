using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// A convention that saves enums as ints instead of strings.
    /// </summary>
    public class EnumConvention : IUserTypeConvention
    {
        /// <summary>
        /// Accepts the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        /// <summary>
        /// Applies the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        public void Apply(IPropertyInstance target)
        {
            target.CustomType(target.Property.PropertyType);
        }
    }
}
