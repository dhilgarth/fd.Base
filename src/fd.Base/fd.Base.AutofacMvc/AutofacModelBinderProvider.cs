using System;
using System.Web.Mvc;

namespace fd.Base.AutofacMvc
{
    public class AutofacModelBinderProvider : DefaultModelBinder, IModelBinderProvider
    {
        private readonly IModelFactory _modelFactory;

        public AutofacModelBinderProvider(IModelFactory modelFactory)
        {
            if (modelFactory == null)
                throw new ArgumentNullException("modelFactory");
            _modelFactory = modelFactory;
        }

        public IModelBinder GetBinder(Type modelType)
        {
            if (_modelFactory.Supports(modelType))
                return this;
            return null;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (_modelFactory.Supports(modelType))
                return _modelFactory.Create(modelType);
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}
