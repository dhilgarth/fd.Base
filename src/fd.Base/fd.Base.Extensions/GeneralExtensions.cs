using System;
using System.IO;
using System.Reflection;

namespace fd.Base.Extensions
{
    public static class GeneralExtensions
    {
        public static T ThrowIfNull<T>(this T obj, string paramName) where T : class
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);
            return obj;
        }

        public static TTarget As<TTarget>(this object @this)
        {
            return (TTarget) @this;
        }

        public static string GetLocalPath(this Assembly assembly)
        {
            return Path.GetDirectoryName(new Uri(assembly.CodeBase).LocalPath);
        }
    }
}
