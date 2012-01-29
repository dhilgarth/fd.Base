using System;
using System.Collections;
using System.Reflection;
using NHibernate.Engine;
using NHibernate.Properties;

namespace fd.Base.NHibernate
{
    internal class ConstantValueGetter<T> : IGetter
    {
        private readonly string _propertyName;

        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public ConstantValueGetter(string propertyName, T value)
        {
            _propertyName = propertyName;
            Value = value;
        }

        /// <summary>Gets the <see cref="MethodInfo" /> for the <c>get</c> accessor of the property.</summary>
        public MethodInfo Method
        {
            get
            {
                var method = typeof(BasicPropertyAccessor).GetMethod("GetGetterOrNull", BindingFlags.Static | BindingFlags.NonPublic);

                var result = (BasicPropertyAccessor.BasicGetter)method.Invoke(null, new object[] { GetType(), "Value" });

                return result.Method;
            }
        }

        /// <summary>Gets the name of the Property.</summary>
        public string PropertyName
        {
            get { return _propertyName; }
        }

        /// <summary>Gets the <see cref="T:System.Type" /> that the Property returns.</summary>
        public Type ReturnType
        {
            get { return typeof(T); }
        }

        /// <summary>Gets or sets the value.</summary>
        private T Value { get; set; }

        /// <summary>When implemented by a class, gets the value of the Property/Field from the object.</summary>
        /// <param name="target">The object to get the Property/Field value from.</param>
        /// <returns>The value of the Property for the target.</returns>
        public object Get(object target)
        {
            return Value;
        }

        /// <summary>Gets the property value from the given <paramref name="owner" /> instance.</summary>
        /// <param name="owner">The instance containing the value to be retrieved.</param>
        /// <param name="mergeMap">a map of merged persistent instances to detached instances</param>
        /// <param name="session">The session from which this request originated.</param>
        /// <returns>The extracted value.</returns>
        public object GetForInsert(object owner, IDictionary mergeMap, ISessionImplementor session)
        {
            return Get(owner);
        }
    }
}
