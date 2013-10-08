using Nancy;
using Quartz.FeaturePack.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class SchedulerModule : NancyModule
    {
        public SchedulerModule()
            : base("/api/scheduler")
        {
            Get[""] = parameters => { return NancyWebApiPlugin.Scheduler.SchedulerName; };
        }
    }
}
