using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;

namespace fd.Base.NHibernate
{
    public static class Extensions
    {
        public static T AddDefault<T>(this SetupConventionFinder<T> conventions)
        {
            conventions.Add(DefaultCascade.All(), /*Table.Is(x => x.EntityType.Name.Replace("Entity", "")),*/
                            ForeignKey.Format((me, t) => (me != null ? me.Name : t.Name) + "Id"));
            return conventions.AddFromAssemblyOf<EnumConvention>();
        }
    }
}
