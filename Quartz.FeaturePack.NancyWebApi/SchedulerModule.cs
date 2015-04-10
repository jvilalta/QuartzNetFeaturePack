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
            Get[""] = parameters =>
            {
                var response = Response.AsJson(new JsonScheduler(NancyWebApiPlugin.Scheduler));
                response.Headers.Add("Access-Control-Allow-Origin","*");
                return response ;
            };
        }
    }
}
