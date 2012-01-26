using System;

namespace fd.Base.Common
{
    /// <summary>The base class for the <see langword="abstract"/> factories.</summary>
    /// <typeparam name="T">The type the <see langword="abstract"/> factory supports.</typeparam>
    public abstract class AbstractFactoryBase<T> : IAbstractFactory<T>
    {
        /// <summary>Gets the type supported by this factory.</summary>
        public Type SupportedType
        {
            get { return typeof(T); }
        }

        /// <summary>Creates a new instance.</summary>
        /// <returns>The newly created instance.</returns>
        public abstract T CreateInstance();

        /// <summary>Creates a new instance.</summary>
        /// <returns>The newly created instance.</returns>
        object IAbstractFactory.CreateInstance()
        {
            return CreateInstance();
        }
    }
}
