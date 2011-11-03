using AutoMapper;

namespace fd.Base.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void CreateTwoWayMap<T1, T2>(this IConfiguration configuration)
        {
            configuration.CreateMap<T1, T2>();
            configuration.CreateMap<T2, T1>();
        }
    }
}
