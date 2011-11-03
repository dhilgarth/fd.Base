using System;

namespace fd.Base.AutofacMvc
{
    public abstract class SingleModelFactoryBase<TModel> : ModelFactoryBase
    {
        protected SingleModelFactoryBase() : base(typeof (TModel)) {}

        public override object Create(Type modelType)
        {
            if (modelType == typeof (TModel))
                return Create();
            throw new InvalidOperationException("The model type '" + modelType + "' is not supported by this model factory.");
        }

        public abstract TModel Create();
    }
}
