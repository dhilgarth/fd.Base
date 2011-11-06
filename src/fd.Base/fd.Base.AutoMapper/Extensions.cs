using AutoMapper;

namespace fd.Base.AutoMapper
{
    /// <summary>
    /// Contains extension methods in the context of the AutoMapper.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates a simple two way map, i.e. it creates a map from <typeparamref name="T1"/> to <typeparamref name="T2"/> and vice versa.
        /// </summary>
        /// <typeparam name="T1">The first type to create a mapping for.</typeparam>
        /// <typeparam name="T2">The second type to create a mapping for.</typeparam>
        /// <param name="configuration">The configuration to create the mappings on.</param>
        public static void CreateTwoWayMap<T1, T2>(this IConfiguration configuration)
        {
            configuration.CreateMap<T1, T2>();
            configuration.CreateMap<T2, T1>();
        }
    }
}
