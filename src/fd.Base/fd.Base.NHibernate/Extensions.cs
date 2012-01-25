using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Autofac;
using fd.Base.Common;
using fd.Base.Extensions.Simple;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace fd.Base.NHibernate
{
    /// <summary>
    ///   Contains extension methods related to NHibernate or Fluent NHibernate.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        ///   Adds the default conventions.
        /// </summary>
        /// <typeparam name="T"> The return type. </typeparam>
        /// <param name="conventions"> The conventions finder to add the conventions to. </param>
        /// <returns> Returns the result of the add operation. </returns>
        public static T AddDefault<T>(this SetupConventionFinder<T> conventions)
        {
            return conventions.Add(DefaultCascade.All(), new EnumConvention(), new AllUpperCaseColumnNameConvention(), new AllUpperCaseTableNameConvention());
        }

        public static void KeyColumnFromReference<TChild>(
            this OneToManyPart<TChild> collectionmap, ClassMap<TChild> map, Expression<Func<TChild, object>> referenceprop)
        {
            var propertyname = ExpressionsHelper.GetPropertyName(referenceprop);
            var column = ((IMappingProvider)map).GetClassMapping().References.First(m => m.Name == propertyname).Columns.First().Name;

            collectionmap.KeyColumn(column);
        }

        public static void KeyColumnFromReference<T, TChild>(this OneToManyPart<TChild> collectionmap, ClassMap<TChild> map)
        {
            var column = ((IMappingProvider)map).GetClassMapping().References.First(m => m.ContainingEntityType == typeof(TChild)).Columns.First().Name;

            collectionmap.KeyColumn(column);
        }

        /// <summary>
        ///   Registers the default NHibernate types with this container builder. Uses auto mapping only.
        /// </summary>
        /// <param name="builder"> The container builder to register the types in. </param>
        /// <param name="entityAssemblies"> The assemblies containing the entities to map. </param>
        /// <param name="conventionAssemblies"> The assemblies containing additional conventions to use. </param>
        /// <param name="overridesAssemblies"> The assemblies containing mapping overrides. </param>
        public static void RegisterNHibernate(
            this ContainerBuilder builder, 
            IEnumerable<Assembly> entityAssemblies, 
            IEnumerable<Assembly> conventionAssemblies, 
            IEnumerable<Assembly> overridesAssemblies)
        {
            builder.RegisterNHibernate(Enumerable.Empty<Assembly>(), entityAssemblies, conventionAssemblies, overridesAssemblies);
        }

        /// <summary>
        ///   Registers the default NHibernate types with this container builder. Uses fluent and auto mapping.
        /// </summary>
        /// <param name="builder"> The container builder to register the types in. </param>
        /// <param name="mappingsAssemblies"> The assemblies containing the class maps. </param>
        /// <param name="entityAssemblies"> The assemblies containing the entities to map. </param>
        /// <param name="conventionAssemblies"> The assemblies containing additional conventions to use. </param>
        /// <param name="overridesAssemblies"> The assemblies containing mapping overrides. </param>
        public static void RegisterNHibernate(
            this ContainerBuilder builder, 
            IEnumerable<Assembly> mappingsAssemblies, 
            IEnumerable<Assembly> entityAssemblies, 
            IEnumerable<Assembly> conventionAssemblies, 
            IEnumerable<Assembly> overridesAssemblies)
        {
            builder.RegisterType<NoRawNHibernateConfigChanger>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<DefaultAutoMappingConfiguration>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<DefaultSessionFactoryBuilder>().AsImplementedInterfaces().SingleInstance();

            builder.Register(c => c.Resolve<ISessionFactoryBuilder>().Build(mappingsAssemblies, entityAssemblies, conventionAssemblies, overridesAssemblies)).
                SingleInstance();
        }

        /// <summary>
        ///   Registers the default NHibernate types with this container builder. Uses fluent and auto mapping.
        /// </summary>
        /// <param name="builder"> The container builder to register the types in. </param>
        /// <param name="entityAssembly"> The assembly containing the entities to map. </param>
        /// <param name="configurationAssembly"> The assembly containing the class maps, additional conventions and overrides to use. </param>
        public static void RegisterNHibernate(this ContainerBuilder builder, Assembly entityAssembly, Assembly configurationAssembly)
        {
            var configurationAssemblies = configurationAssembly.MakeEnumerable().ToList();
            builder.RegisterNHibernate(configurationAssemblies, entityAssembly.MakeEnumerable(), configurationAssemblies, configurationAssemblies);
        }
    }
}
