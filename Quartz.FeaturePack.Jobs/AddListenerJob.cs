using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Listener;

namespace Quartz.FeaturePack.Jobs
{
    public class AddListenerJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            string type = context.MergedJobDataMap.GetString("type");
            IJobListener listener = (IJobListener)Type.GetType(type).GetConstructor(new Type[] { }).Invoke(null);
            IMatcher<JobKey> matcher = Quartz.Impl.Matchers.EverythingMatcher<JobKey>.AllJobs();
            context.Scheduler.ListenerManager.AddJobListener(listener, matcher);
        }
    }
}
