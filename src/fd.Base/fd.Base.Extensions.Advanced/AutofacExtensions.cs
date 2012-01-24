using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using AutoMapper;
using fd.Base.AutoMapper;
using fd.Base.Common;
using fd.Base.Extensions.Simple;

namespace fd.Base.Extensions.Advanced
{
    /// <summary>
    /// Contains extension methods related to Autofac.
    /// </summary>
    public static class AutofacExtensions
    {
        /// <summary>
        /// Configures the auto mapper using all registered <see cref="IAutoMapperSetup"/>.
        /// </summary>
        /// <param name="container">
        /// The Autofac container used to resolve the registered instances.
        /// </param>
        public static void ConfigureAutoMapper(this IComponentContext container)
        {
            foreach (var autoMapperSetup in container.Resolve<IEnumerable<IAutoMapperSetup>>())
                autoMapperSetup.Configure(Mapper.Configuration);
        }

        /// <summary>
        /// Creates a registration builder for all assemblies in the path of the executing assembly that conform to the specified search patterns.
        /// </summary>
        /// <param name="builder">
        /// The container builder to create the registration builder for.
        /// </param>
        /// <param name="searchPatterns">
        /// The search patterns the assemblies must satisfy at least one from.
        /// </param>
        /// <returns>
        /// A registration builder containing the matching assemblies.
        /// </returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssemblyTypesOf(
            this ContainerBuilder builder, params string[] searchPatterns)
        {
            return RegisterAssemblyTypesOfPath(builder, Assembly.GetExecutingAssembly().GetLocalPath(), searchPatterns);
        }

        /// <summary>
        /// Creates a registration builder for all assemblies in the specified path that conform to the specified search patterns.
        /// </summary>
        /// <param name="builder">
        /// The container builder to create the registration builder for.
        /// </param>
        /// <param name="path">
        /// The path the assemblies are located in.
        /// </param>
        /// <param name="searchPatterns">
        /// The search patterns the assemblies must satisfy at least one from.
        /// </param>
        /// <returns>
        /// A registration builder containing the matching assemblies.
        /// </returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssemblyTypesOfPath(
            this ContainerBuilder builder, string path, params string[] searchPatterns)
        {
            var assemblies = new List<Assembly>();
            foreach (var searchPattern in searchPatterns)
                assemblies.AddRange(Directory.GetFiles(path, searchPattern).Select(Assembly.LoadFrom));
            return builder.RegisterAssemblyTypes(assemblies.ToArray());
        }

        /// <summary>
        /// Registers the default types provided by this library.
        /// </summary>
        /// <param name="builder">
        /// The container builder to register the types with.
        /// </param>
        public static void RegisterDefault(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypesOf("fd.Base.*.dll").RegisterDefaultTypes();
            builder.Register(c => c.Resolve<ILocalDataFactory>().Create()).SingleInstance();
        }

        /// <summary>
        /// Registers the types conforming to the default naming conventions in the provided assemblies.
        /// </summary>
        /// <param name="builder">The registration builder that contains the assemblies.</param>
        /// <param name="values">The strings the type names must end with.</param>
        public static void RegisterTypesEndingWith(this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder, params string[] values)
        {
            builder.Where(x => x.Name.EndsWithAny(values)).AsImplementedInterfaces().SingleInstance();
        }

        /// <summary>
        /// Registers the types conforming to the default naming conventions in the provided assemblies.
        /// </summary>
        /// <param name="builder">
        /// The registration builder that contains the assemblies.
        /// </param>
        public static void RegisterDefaultTypes(this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> builder)
        {
            builder.RegisterTypesEndingWith("Service", "Factory", "Provider", "Builder", "Setup", "Generator", "Configuration");
        }
    }
}
