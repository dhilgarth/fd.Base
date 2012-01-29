using FluentNHibernate.Automapping;

namespace fd.Base.NHibernate
{
    /// <summary>
    /// Used to adjust the auto-mappings.
    /// </summary>
    public interface IAutoMappingAdjuster
    {
        /// <summary>
        /// Adjusts the auto-mappings.
        /// </summary>
        /// <param name="mapping">The mapping.</param>
        void AdjustAutoMappings(AutoPersistenceModel mapping);
    }
}