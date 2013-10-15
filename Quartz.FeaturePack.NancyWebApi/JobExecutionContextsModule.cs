using Nancy;
using Quartz.FeaturePack.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JobExecutionContextsModule : NancyModule
    {
        public JobExecutionContextsModule()
            : base("/api/jobexecutioncontexts")
        {
            Get[""] = parameters =>
            {
                var scheduler = NancyWebApiPlugin.Scheduler;
                var jobExecutionContexts = scheduler.GetCurrentlyExecutingJobs();
                var jsonContexts = new List<JsonJobExecutionContext>();
                foreach (var context in jobExecutionContexts)
                {
                    jsonContexts.Add(new JsonJobExecutionContext(context));
                }
                return Newtonsoft.Json.JsonConvert.SerializeObject(jsonContexts);
            };

        }
    }
}
