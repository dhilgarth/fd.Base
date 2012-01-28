using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Properties;

namespace fd.Base.NHibernate
{
    /// <summary>A property accessor that returns a constant value.</summary>
    internal class ConstantValueAccessor : IPropertyAccessor
    {
        private static readonly ConcurrentDictionary<Type, SynchronizedCollection<IGetter>> _getters =
            new ConcurrentDictionary<Type, SynchronizedCollection<IGetter>>();

        /// <summary>Gets a value indicating whether the ReflectionOptimizer can be used.</summary>
        public bool CanAccessThroughReflectionOptimizer
        {
            get { return false; }
        }

        /// <summary>Registers the getter.</summary>
        /// <param name="type">The type the <paramref name="getter" /> is to be used on.</param>
        /// <param name="getter">The getter.</param>
        public static void RegisterGetter(Type type, IGetter getter)
        {
            var getters = _getters.GetOrAdd(type, t => new SynchronizedCollection<IGetter>());
            getters.Add(getter);
        }

        /// <summary>When implemented by a class, create a "getter" for the mapped property.</summary>
        /// <param name="theClass">The <see cref="T:System.Type" /> to find the Property in.</param>
        /// <param name="propertyName">The name of the mapped Property to get.</param>
        /// <exception cref="T:NHibernate.PropertyNotFoundException">
        /// Thrown when a Property specified by the <c>propertyName</c> could not be found in the <see cref="T:System.Type" /> .
        /// </exception>
        /// <returns>
        /// The <see cref="T:NHibernate.Properties.IGetter" /> to use to get the value of the Property from an instance of the <see cref="T:System.Type" /> .
        /// </returns>
        public IGetter GetGetter(Type theClass, string propertyName)
        {
            SynchronizedCollection<IGetter> getters;
            if (!_getters.TryGetValue(theClass, out getters))
                return null;
            return getters.SingleOrDefault(x => x.PropertyName == propertyName);
        }

        /// <summary>When implemented by a class, create a "setter" for the mapped property.</summary>
        /// <param name="theClass">The <see cref="T:System.Type" /> to find the Property in.</param>
        /// <param name="propertyName">The name of the mapped Property to set.</param>
        /// <exception cref="T:NHibernate.PropertyNotFoundException">
        /// Thrown when a Property specified by the <c>propertyName</c> could not be found in the <see cref="T:System.Type" /> .
        /// </exception>
        /// <returns>
        /// The <see cref="T:NHibernate.Properties.ISetter" /> to use to set the value of the Property on an instance of the <see cref="T:System.Type" /> .
        /// </returns>
        public ISetter GetSetter(Type theClass, string propertyName)
        {
            return new NoOpSetter();
        }
    }
}
