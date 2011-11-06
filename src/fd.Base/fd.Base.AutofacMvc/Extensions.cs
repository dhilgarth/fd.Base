using System.Collections.Generic;
using System.Web.Mvc;
using Autofac;

namespace fd.Base.AutofacMvc
{
    /// <summary>
    /// Contains extension methods related to ASP.NET MVC.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Registers the default ASP.NET MVC types with the specified container builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public static void RegisterMvc(this ContainerBuilder builder)
        {
            builder.Register(x => new AutofacModelBinderProvider(new CompositeModelFactory(x.Resolve<IEnumerable<IModelFactory>>()))).As<IModelBinderProvider>()
                .SingleInstance();
        }
    }
}