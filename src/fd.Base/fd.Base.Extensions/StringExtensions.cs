using System.Linq;

namespace fd.Base.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        public static bool EndsWithAny(this string @this, params string[] values)
        {
            return values.Any(@this.EndsWith);
        }
    }
}
