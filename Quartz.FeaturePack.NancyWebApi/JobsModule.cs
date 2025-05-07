using Nancy;
using Newtonsoft.Json;
using Quartz.FeaturePack.Plugins;
using Quartz.Impl.Matchers;
using System.Collections.Generic;
using System.Linq;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JobsModule : NancyModule
    {
        public JobsModule()
            : base("api/jobs")
        {
            Get("", parameters =>
            {
                var scheduler = NancyWebApiPlugin.Scheduler;
                var jobs = new List<JsonJob>();
                var jobGroupNames = scheduler.GetJobGroupNames().Result;
                if (jobGroupNames != null)
                {
                    foreach (var name in jobGroupNames)
                    {
                        foreach (var key in scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(name)).Result)
                        {
                            var job = scheduler.GetJobDetail(key).Result;
                            var triggers = scheduler.GetTriggersOfJob(job.Key).Result.ToList();
                            jobs.Add(new JsonJob(job, triggers));
                        }
                    }
                }
                var response = Response.AsJson(jobs);
                response.Headers.Add("Access-Control-Allow-Origin", "*");
                return response;
            });

            Put("", parameters =>
            {
                IJob job = null;
                return JsonConvert.SerializeObject(job);
            });

        }
    }
}
