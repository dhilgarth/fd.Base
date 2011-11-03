using Autofac;

namespace fd.Base.AutofacMvc
{
    public interface IContainerProvider
    {
        IComponentContext Get();
    }
}
