using System;

namespace fd.Base.Common
{
    /// <summary>Represents an <see langword="abstract"/> factory.</summary>
    /// <typeparam name="T">The type this <see langword="abstract"/> factory creates.</typeparam>
    public interface IAbstractFactory<out T> : IAbstractFactory
    {
        /// <summary>Creates a new instance.</summary>
        /// <returns>The newly created instance.</returns>
        new T CreateInstance();
    }

    /// <summary>Represents an <see langword="abstract"/> factory.</summary>
    public interface IAbstractFactory
    {
        /// <summary>Gets the type supported by this factory.</summary>
        Type SupportedType { get; }

        /// <summary>Creates a new instance.</summary>
        /// <returns>The newly created instance.</returns>
        object CreateInstance();
    }
}
