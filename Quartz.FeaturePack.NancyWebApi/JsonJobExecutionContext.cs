using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonJobExecutionContext
    {
        public JsonJobExecutionContext(IJobExecutionContext jobExecutionContext)
        {
            calendar = jobExecutionContext.Calendar;
            fireInstanceId = jobExecutionContext.FireInstanceId;
            fireTimeUtc = jobExecutionContext.FireTimeUtc;
            jobDetail = jobExecutionContext.JobDetail;
            jobInstance = jobExecutionContext.JobInstance;
            jobRunTime = jobExecutionContext.JobRunTime;
            mergedJobDataMap = jobExecutionContext.MergedJobDataMap;
            nextFireTimeUtc = jobExecutionContext.NextFireTimeUtc;
            previousFireTimeUtc = jobExecutionContext.PreviousFireTimeUtc;
        }

        public IJob jobInstance { get; set; }

        public TimeSpan jobRunTime { get; set; }

        public DateTimeOffset? fireTimeUtc { get; set; }

        public string fireInstanceId { get; set; }

        public ICalendar calendar { get; set; }

        public IJobDetail jobDetail { get; set; }

        public JobDataMap mergedJobDataMap { get; set; }

        public DateTimeOffset? nextFireTimeUtc { get; set; }

        public DateTimeOffset? previousFireTimeUtc { get; set; }
    }
}
