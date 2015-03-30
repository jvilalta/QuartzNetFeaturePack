using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Listener;

namespace Quartz.FeaturePack.Jobs
{
    /// <summary>
    /// This job adds a listener to the scheduler. Set the "job-type" property of the job to the  <see cref="Type">Type</see> of the listener 
    /// that you want to add to the scheduler. This job is handy if you want to add a listener to the scheduler via 
    /// the quartz_jobs.xml file. The listener will be added with an EverythingMatcher, so it will match all jobs.
    /// </summary>
    public class AddListenerJob : IJob
    {
        /// <summary>
        /// Looks up the listener's <see cref="Type">Type</see> in the job's data map. You must set the value
        /// of the listener's type in a parameter called "type".
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            string type = context.MergedJobDataMap.GetString(JOB_TYPE);
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException(JOB_TYPE, "Could not find a parameter named type in the job's datamap.");
            }
            IJobListener listener = (IJobListener)Type.GetType(type).GetConstructor(new Type[] { }).Invoke(null);
            IMatcher<JobKey> matcher = Quartz.Impl.Matchers.EverythingMatcher<JobKey>.AllJobs();
            context.Scheduler.ListenerManager.AddJobListener(listener, matcher);
        }
        public static string JOB_TYPE = "job-type";
    }
}
