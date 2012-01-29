using System.Activities;

namespace fd.Base.Workflow
{
    /// <summary>Contains extension methods for the Windows Workflow foundation 4.</summary>
    public static class WorkflowExtensions
    {
        /// <summary>Adds a tracker.</summary>
        /// <param name="value">The value.</param>
        public static void AddTracker(this WorkflowApplication value)
        {
            value.Extensions.Add(new Tracker());
        }

        /// <summary>Gets the value of the specified <paramref name="argument" /> or the default value.</summary>
        /// <remarks>From http://code.msdn.microsoft.com/windowsdesktop/Windows-Workflow-7245a820</remarks>
        /// <typeparam name="T">The type of the <paramref name="argument" /></typeparam>
        /// <param name="argument">The argument.</param>
        /// <param name="context">The context.</param>
        /// <param name="defaultValue">The default value to return of no value was set for the argument.</param>
        /// <returns>The value of the <paramref name="argument" /> if one was set; otherwise, the specified default value.</returns>
        public static T Get<T>(this InArgument<T> argument, ActivityContext context, T defaultValue)
        {
            var obj = argument.Get(context);
            if (Equals(obj, default(T)) && argument.Expression == null)
                obj = defaultValue;
            return obj;
        }
    }
}
