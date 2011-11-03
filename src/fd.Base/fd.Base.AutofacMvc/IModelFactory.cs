using System;
using System.Collections.Generic;

namespace fd.Base.AutofacMvc
{
    public interface IModelFactory
    {
        bool Supports(Type modelType);
        IEnumerable<Type> GetSupportedTypes();
        object Create(Type modelType);
    }
}
