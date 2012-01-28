using System;
using System.Reflection;
using NHibernate.Properties;

namespace fd.Base.NHibernate
{
    /// <summary>A <see cref="ISetter" /> implementation that does nothing.</summary>
    [Serializable]
    internal class NoOpSetter : ISetter
    {
        /// <summary>Gets the <see cref="T:System.Reflection.MethodInfo" /> for the <c>set</c> accessor of the property.</summary>
        /// <value>
        /// Always returns <see langword="null" /> .
        /// </value>
        MethodInfo ISetter.Method
        {
            get { return null; }
        }

        /// <summary>Gets the name of the Property.</summary>
        /// <value>
        /// Always returns <see langword="null" /> .
        /// </value>
        string ISetter.PropertyName
        {
            get { return null; }
        }

        /// <summary>Does nothing.</summary>
        /// <param name="target">The object to set the Property <paramref name="value" /> in.</param>
        /// <param name="value">The value to set the Property to.</param>
        void ISetter.Set(object target, object value)
        {
        }
    }
}
