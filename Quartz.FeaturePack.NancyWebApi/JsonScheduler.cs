using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonScheduler
    {
        public JsonScheduler(IScheduler scheduler)
        {
            SchedulerName = scheduler.SchedulerName;
        }
        public string SchedulerName { get; set; }
    }
}
