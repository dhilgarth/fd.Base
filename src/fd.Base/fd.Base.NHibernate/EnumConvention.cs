using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace fd.Base.NHibernate
{
    public class EnumConvention : IUserTypeConvention
    {
        #region IUserTypeConvention Members

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum);
        }

        public void Apply(IPropertyInstance target)
        {
            target.CustomType(target.Property.PropertyType);
        }

        #endregion
    }
}
