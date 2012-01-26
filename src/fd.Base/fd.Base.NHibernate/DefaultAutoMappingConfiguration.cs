using System;
using fd.Base.Types;
using FluentNHibernate.Automapping;

namespace fd.Base.NHibernate
{
    /// <summary>The automapping configuration.</summary>
    public class DefaultAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        /// <summary>Determines whether the specified <paramref name="type" /> should be mapped.</summary>
        /// <param name="type">The type that should be checked.</param>
        /// <returns><c>true</c> if the specified <paramref name="type" /> should be mapped; otherwise, <c>false</c> .</returns>
        public override bool ShouldMap(Type type)
        {
            // specify the criteria that types must meet in order to be mapped
            // any type for which this method returns false will not be mapped.
            return typeof(Entity).IsAssignableFrom(type);
        }
    }
}
