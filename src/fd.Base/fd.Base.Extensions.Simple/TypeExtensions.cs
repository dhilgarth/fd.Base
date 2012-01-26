using System;
using System.Linq;

namespace fd.Base.Extensions.Simple
{
    /// <summary>Extension methods for <see cref="Type" /> .</summary>
    public static class TypeExtensions
    {
        /// <summary>Creates a string representation of the supplied type using C# syntax.</summary>
        /// <remarks>
        /// If the specified type is not a generic type it simply returns the <see cref="System.Reflection.MemberInfo.Name" /> or
        /// <see cref="System.Type.FullName" /> . If the the specified type is a generic type it creates a representation including all type parameters in C#
        /// syntax, e.g. <c>List&lt;string&gt;</c> instead of <c>List`1</c> .
        /// </remarks>
        /// <param name="t">The type to return the string representation for.</param>
        /// <param name="fullName">if set to <c>true</c> returns the full name of the type including <see langword="namespace" /> .</param>
        /// <returns>The string representation of the specified type.</returns>
        public static string ToGenericTypeString(this Type t, bool fullName)
        {
            if (!t.IsGenericType)
                return fullName ? t.FullName : t.Name;
            var genericTypeDefinition = t.GetGenericTypeDefinition();
            var genericTypeName = fullName ? genericTypeDefinition.FullName : genericTypeDefinition.Name;
            genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
            var genericArgs = string.Join(",", t.GetGenericArguments().Select(x => x.ToGenericTypeString(fullName)).ToArray());
            return genericTypeName + "<" + genericArgs + ">";
        }
    }
}
