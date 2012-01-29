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
    }
}
