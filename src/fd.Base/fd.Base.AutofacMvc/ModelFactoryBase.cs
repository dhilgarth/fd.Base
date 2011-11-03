using System;
using System.Collections.Generic;

namespace fd.Base.AutofacMvc
{
    public abstract class ModelFactoryBase : IModelFactory
    {
        private readonly HashSet<Type> _supportedTypes;
        protected ModelFactoryBase(Type supportedType) : this(supportedType, new Type[] {}) {}

        protected ModelFactoryBase(Type supportedType, params Type[] supportedTypes)
        {
            _supportedTypes = new HashSet<Type>(supportedTypes);
            _supportedTypes.Add(supportedType);
        }

        #region IModelFactory Members

        public bool Supports(Type modelType)
        {
            return _supportedTypes.Contains(modelType);
        }

        public IEnumerable<Type> GetSupportedTypes()
        {
            return _supportedTypes;
        }

        public abstract object Create(Type modelType);

        #endregion
    }
}
