using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// Contains extension methods related to NHibernate or Fluent NHibernate.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds the default conventions.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="conventions">The conventions finder to add the conventions to.</param>
        /// <returns>Returns the result of the add operation.</returns>
        public static T AddDefault<T>(this SetupConventionFinder<T> conventions)
        {
            conventions.Add(
                DefaultCascade.All()/*, Table.Is(x => x.EntityType.Name.Replace("Entity", "")),
                ForeignKey.Format((me, t) => (me != null ? me.Name : t.Name) + "Id")*/);
            return conventions.AddFromAssemblyOf<EnumConvention>();
        }

        /// <summary>
        /// Registers the default NHibernate types with this container builder.
        /// </summary>
        /// <param name="builder">The container builder to register the types in.</param>
        public static void RegisterNHibernate(this ContainerBuilder builder)
        {
            builder.RegisterType<NoRawNHibernateConfigChanger>().AsImplementedInterfaces().SingleInstance();
            builder.Register(c => c.Resolve<ISessionFactoryBuilder>().Build()).SingleInstance();
        }
    }
}
