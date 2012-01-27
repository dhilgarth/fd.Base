using System;
using System.Linq.Expressions;
using System.Reflection;

namespace fd.Base.Common
{
    /// <summary>
    /// A <see langword="static" /> class that simplifies <see langword="null" /> checks of parameters, especially in constructors when calling the base
    /// implementation or another constructor.
    /// </summary>
    public static class Guard
    {
        /// <summary>Throws an <see cref="ArgumentNullException" /> if the variable in the specified expression is <c>null</c> .</summary>
        /// <remarks>
        /// This is pretty slow, because it compiles the supplied expression to provide the return value. If performance is critical, use <see cref="Guard" />
        /// instead.
        /// </remarks>
        /// <typeparam name="T">The type of the variable that should be <see langword="checked" /> for <c>null</c> .</typeparam>
        /// <param name="parameterExpression">The parameter expression that defines the variable to check.</param>
        /// <returns>The value of the variable in the expression.</returns>
        public static T AgainstNull<T>(Expression<Func<T>> parameterExpression) where T : class
        {
            var @this = parameterExpression.Compile()();
            if (@this == null)
                throw new ArgumentNullException(GetParameterName(parameterExpression));
            return @this;
        }

        /// <summary>Throws an <see cref="ArgumentNullException" /> if the object on which this extension method is called is <c>null</c> .</summary>
        /// <remarks>Use this instead of <see cref="Guard" /> , if performance is an issue.</remarks>
        /// <typeparam name="T">The type of the variable that should be <see langword="checked" /> for <c>null</c> .</typeparam>
        /// <param name="this">The object that is not allowed to be null.</param>
        /// <param name="parameterExpression">The parameter expression that defines the variable to check.</param>
        /// <returns>The value of the variable in the expression.</returns>
        public static T NotNull<T>(this T @this, Expression<Func<T>> parameterExpression) where T : class
        {
            if (@this == null)
                throw new ArgumentNullException(GetParameterName(parameterExpression));
            return @this;
        }

        /// <summary>Gets the name of the parameter.</summary>
        /// <typeparam name="T">The type of the variable.</typeparam>
        /// <param name="parameterExpression">The parameter expression.</param>
        /// <returns>The name of the variable inside the expression.</returns>
        private static string GetParameterName<T>(Expression<Func<T>> parameterExpression)
        {
            var body = parameterExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'parameterExpression' should be a member expression, but it is a " + parameterExpression.Body.GetType());

            var propertyInfo = body.Member as PropertyInfo;
            if (propertyInfo != null)
                return propertyInfo.Name;

            var fieldInfo = body.Member as FieldInfo;
            if (fieldInfo != null)
                return fieldInfo.Name;

            throw new ArgumentException("The member used in the expression should be a property or a field, but it is a " + body.Member.GetType());
        }
    }
}
