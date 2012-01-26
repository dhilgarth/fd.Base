using System.Collections.Generic;
using System.Reflection;
using NHibernate;

namespace fd.Base.NHibernate
{
    /// <summary>Represents a session factory builder.</summary>
    public interface ISessionFactoryBuilder
    {
        /// <summary>Builds the session factory using auto mapping only.</summary>
        /// <param name="entityAssemblies">The assemblies containing the entities to map.</param>
        /// <param name="conventionAssemblies">The assemblies containing additional conventions to use.</param>
        /// <param name="overridesAssemblies">The assemblies containing mapping overrides.</param>
        /// <returns>The newly built session factory.</returns>
        ISessionFactory Build(IEnumerable<Assembly> entityAssemblies, IEnumerable<Assembly> conventionAssemblies, IEnumerable<Assembly> overridesAssemblies);

        /// <summary>Builds the session factory using both fluent and auto mapping.</summary>
        /// <param name="mappingsAssemblies">The assemblies containing the class maps.</param>
        /// <param name="entityAssemblies">The assemblies containing the entities to map.</param>
        /// <param name="conventionAssemblies">The assemblies containing additional conventions to use.</param>
        /// <param name="overridesAssemblies">The assemblies containing mapping overrides.</param>
        /// <returns>The newly built session factory.</returns>
        ISessionFactory Build(
            IEnumerable<Assembly> mappingsAssemblies, 
            IEnumerable<Assembly> entityAssemblies, 
            IEnumerable<Assembly> conventionAssemblies, 
            IEnumerable<Assembly> overridesAssemblies);

        /// <summary>Builds the session factory using fluent mapping only.</summary>
        /// <param name="mappingsAssemblies">The assemblies containing the class maps.</param>
        /// <returns>The newly built session factory.</returns>
        ISessionFactory Build(IEnumerable<Assembly> mappingsAssemblies);
    }
}
