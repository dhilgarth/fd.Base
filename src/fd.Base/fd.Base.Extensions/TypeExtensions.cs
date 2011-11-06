using System;
using System.Linq;

namespace fd.Base.Extensions.Simple
{
    public static class TypeExtensions
    {
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
