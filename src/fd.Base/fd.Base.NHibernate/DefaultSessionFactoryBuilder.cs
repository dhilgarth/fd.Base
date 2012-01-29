using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using NHibernate;

namespace fd.Base.NHibernate
{
    /// <summary>The default session factory builder.</summary>
    public class DefaultSessionFactoryBuilder : ISessionFactoryBuilder
    {
        private readonly IAutoMappingAdjuster _autoMappingAdjuster;
        private readonly IPersistenceConfigurerProvider _persistenceConfigurerProvider;
        private readonly IRawNHibernateConfigChanger _rawNHibernateConfigChanger;

        /// <summary>Initializes a new instance of the <see cref="DefaultSessionFactoryBuilder" /> class.</summary>
        /// <param name="autoMappingAdjuster">The auto-mapping configuration to use.</param>
        /// <param name="persistenceConfigurerProvider">The persistence configurer provider.</param>
        /// <param name="rawNHibernateConfigChanger">The raw N hibernate config changer.</param>
        public DefaultSessionFactoryBuilder(
            IAutoMappingAdjuster autoMappingAdjuster, 
            IPersistenceConfigurerProvider persistenceConfigurerProvider, 
            IRawNHibernateConfigChanger rawNHibernateConfigChanger)
        {
            _autoMappingAdjuster = autoMappingAdjuster;
            _persistenceConfigurerProvider = persistenceConfigurerProvider;
            _rawNHibernateConfigChanger = rawNHibernateConfigChanger;
        }

        /// <summary>Builds the session factory using auto mapping only.</summary>
        /// <param name="entityAssemblies">The assemblies containing the entities to map.</param>
        /// <param name="conventionAssemblies">The assemblies containing additional conventions to use.</param>
        /// <param name="overridesAssemblies">The assemblies containing mapping overrides.</param>
        /// <returns>The newly built session factory.</returns>
        public virtual ISessionFactory Build(
            IEnumerable<Assembly> entityAssemblies, IEnumerable<Assembly> conventionAssemblies, IEnumerable<Assembly> overridesAssemblies)
        {
            return Build(Enumerable.Empty<Assembly>(), entityAssemblies, conventionAssemblies, overridesAssemblies);
        }

        /// <summary>Builds the session factory using fluent mapping only.</summary>
        /// <param name="mappingsAssemblies">The assemblies containing the class maps.</param>
        /// <returns>The newly built session factory.</returns>
        public ISessionFactory Build(IEnumerable<Assembly> mappingsAssemblies)
        {
            return Build(mappingsAssemblies, Enumerable.Empty<Assembly>(), Enumerable.Empty<Assembly>(), Enumerable.Empty<Assembly>());
        }

        /// <summary>Builds the session factory using both fluent and auto mapping.</summary>
        /// <param name="mappingsAssemblies">The assemblies containing the class maps.</param>
        /// <param name="entityAssemblies">The assemblies containing the entities to map.</param>
        /// <param name="conventionAssemblies">The assemblies containing additional conventions to use.</param>
        /// <param name="overridesAssemblies">The assemblies containing mapping overrides.</param>
        /// <returns>The newly built session factory.</returns>
        public virtual ISessionFactory Build(
            IEnumerable<Assembly> mappingsAssemblies, 
            IEnumerable<Assembly> entityAssemblies, 
            IEnumerable<Assembly> conventionAssemblies, 
            IEnumerable<Assembly> overridesAssemblies)
        {
            if (mappingsAssemblies == null)
                throw new ArgumentNullException("mappingsAssemblies");
            if (entityAssemblies == null)
                throw new ArgumentNullException("entityAssemblies");
            if (conventionAssemblies == null)
                throw new ArgumentNullException("conventionAssemblies");
            if (overridesAssemblies == null)
                throw new ArgumentNullException("overridesAssemblies");

            var autoMappings = CreateAutoMappings(entityAssemblies, conventionAssemblies, overridesAssemblies);

            return Fluently.Configure().Database(_persistenceConfigurerProvider.Get()).Mappings(
                m =>
                {
                    foreach (var mappingsAssembly in mappingsAssemblies)
                        m.FluentMappings.AddFromAssembly(mappingsAssembly);
                    m.AutoMappings.Add(() => autoMappings);
                }).ExposeConfiguration(_rawNHibernateConfigChanger.ChangeRawConfig).BuildSessionFactory();
        }

        /// <summary>Creates the auto mappings.</summary>
        /// <param name="entityAssemblies">The assemblies containing the entities to map.</param>
        /// <param name="conventionAssemblies">The assemblies containing additional conventions to use.</param>
        /// <param name="overridesAssemblies">The assemblies containing mapping overrides.</param>
        /// <returns>The auto mappings configuration.</returns>
        protected virtual AutoPersistenceModel CreateAutoMappings(
            IEnumerable<Assembly> entityAssemblies, IEnumerable<Assembly> conventionAssemblies, IEnumerable<Assembly> overridesAssemblies)
        {
            var mapping = AutoMap.Assemblies(_autoMappingAdjuster, entityAssemblies);
            foreach (var conventionAssembly in conventionAssemblies)
                mapping = mapping.Conventions.AddAssembly(conventionAssembly);
            foreach (var overridesAssembly in overridesAssemblies)
                mapping = mapping.UseOverridesFromAssembly(overridesAssembly);

            _autoMappingAdjuster.AdjustAutoMappings(mapping);

            return mapping;
        }
    }
}
