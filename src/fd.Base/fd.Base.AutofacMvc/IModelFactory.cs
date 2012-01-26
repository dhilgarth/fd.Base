using System;
using System.Collections.Generic;

namespace fd.Base.AutofacMvc
{
    public interface IModelFactory
    {
        object Create(Type modelType);
        IEnumerable<Type> GetSupportedTypes();
        bool Supports(Type modelType);
    }
}
