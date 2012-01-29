using System;
using System.Activities.Tracking;
using Microsoft.Activities.UnitTesting.Tracking;

namespace fd.Base.Workflow
{
    /// <summary>A simple tracker that</summary>
    public class Tracker : TrackingParticipant
    {
        /// <summary>When implemented in a derived class, used to synchronously process the tracking record.</summary>
        /// <param name="record">The generated tracking record.</param>
        /// <param name="timeout">The time period after which the provider aborts the attempt.</param>
        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            // Using extension method to get a human readable trace
            record.Trace();
        }
    }
}
