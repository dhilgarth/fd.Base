using AutoMapper;

namespace fd.Base.AutoMapper
{
    /// <summary>
    /// Represents an encapsulated setup of AutoMapper.
    /// </summary>
    public interface IAutoMapperSetup
    {
        /// <summary>
        /// Configures the specified AutoMapper configuration.
        /// </summary>
        /// <param name="configuration">The AutoMapper configuration.</param>
        void Configure(IConfiguration configuration);
    }
}
