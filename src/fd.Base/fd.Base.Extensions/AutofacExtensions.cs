using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using AutoMapper;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using fd.Base.AutofacMvc;
using fd.Base.Common;
using fd.Base.NHibernate;

namespace fd.Base.Extensions
{
    public static class AutofacExtensions
    {
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssemblyTypesOf(this ContainerBuilder builder,
                params string[] searchPatterns)
        {
            return RegisterAssemblyTypesOfPath(builder, Assembly.GetExecutingAssembly().GetLocalPath(), searchPatterns);
        }

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssemblyTypesOfPath(this ContainerBuilder builder,
                string path, params string[] searchPatterns)
        {
            var assemblies = new List<Assembly>();
            foreach (var searchPattern in searchPatterns)
                assemblies.AddRange(Directory.GetFiles(path, searchPattern).Select(Assembly.LoadFrom));
            return builder.RegisterAssemblyTypes(assemblies.ToArray());
        }

        public static void RegisterDefault(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypesOf("fd.Base.*.dll").Where(x => x.Name.EndsWithAny("Service", "Factory", "Provider", "Builder")).AsImplementedInterfaces
                    ().SingleInstance();

            builder.Register(c => c.Resolve<ILocalDataFactory>().Create()).SingleInstance();
        }

        public static void RegisterNHibernate(this ContainerBuilder builder)
        {
            builder.RegisterType<NoRawNHibernateConfigChanger>().AsImplementedInterfaces().SingleInstance();
            builder.Register(c => c.Resolve<ISessionFactoryBuilder>().Build()).SingleInstance();
        }

        public static void RegisterMvc(this ContainerBuilder builder)
        {
            builder.Register(x => new AutofacModelBinderProvider(new CompositeModelFactory(x.Resolve<IEnumerable<IModelFactory>>()))).As<IModelBinderProvider>()
                    .SingleInstance();
        }

        public static void ConfigureAutoMapper(this IComponentContext container)
        {
            foreach (var autoMapperSetup in container.Resolve<IEnumerable<IAutoMapperSetup>>())
                autoMapperSetup.Configure(Mapper.Configuration);
        }
    }
}
