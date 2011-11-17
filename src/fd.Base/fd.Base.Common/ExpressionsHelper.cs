using System;
using System.Linq.Expressions;
using System.Reflection;

namespace fd.Base.Common
{
    public class ExpressionsHelper
    {
        public static PropertyInfo GetPropertyInfo<T>(Expression<T> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'propertyExpression' should be a member expression, but it is a " + propertyExpression.Body.GetType());

            var propertyInfo = body.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("The member used in the expression should be a property, but it is a " + body.Member.GetType());
            return propertyInfo;
        }

        public static string GetPropertyName<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            return GetPropertyInfo(propertyExpression).Name;
        }

        public static string GetPropertyName<TClass, TProperty>(Expression<Func<TClass, TProperty>> propertyExpression)
        {
            return GetPropertyInfo(propertyExpression).Name;
        }
    }
}
