using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace fd.Base.AutofacMvc
{
    public class CompositeModelFactory : IModelFactory
    {
        private readonly ConcurrentDictionary<Type, IModelFactory> _modelFactories;

        public CompositeModelFactory(IEnumerable<IModelFactory> modelFactories)
        {
            _modelFactories = new ConcurrentDictionary<Type, IModelFactory>();
            foreach (var modelFactory in modelFactories)
            {
                foreach (var supportedType in modelFactory.GetSupportedTypes())
                {
                    IModelFactory existingModelFactory;
                    if (_modelFactories.TryGetValue(supportedType, out existingModelFactory))
                        throw new InvalidOperationException("The model type '" + supportedType + "' is already supported by " + existingModelFactory.GetType());
                    _modelFactories[supportedType] = modelFactory;
                }
            }
        }

        public object Create(Type modelType)
        {
            IModelFactory modelFactory;
            if (_modelFactories.TryGetValue(modelType, out modelFactory))
                return modelFactory.Create(modelType);
            throw new InvalidOperationException("The model type '" + modelType + "' is not supported by any model factory.");
        }

        public IEnumerable<Type> GetSupportedTypes()
        {
            return _modelFactories.Keys;
        }

        public bool Supports(Type modelType)
        {
            return _modelFactories.ContainsKey(modelType);
        }
    }
}
