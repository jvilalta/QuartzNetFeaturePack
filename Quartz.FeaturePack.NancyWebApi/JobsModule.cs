using Nancy;
using Quartz.FeaturePack.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Impl.Matchers;
using Newtonsoft.Json;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JobsModule : NancyModule
    {
        public JobsModule()
            : base("api/jobs")
        {
            Get[""] = parameters =>
            {
                var scheduler = NancyWebApiPlugin.Scheduler;
                var jobs = new List<JsonJob>();
                var jobGroupNames = scheduler.GetJobGroupNames();
                if (jobGroupNames != null)
                {
                    foreach (var name in jobGroupNames)
                    {
                        foreach (var key in scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(name)))
                        {
                            var job = scheduler.GetJobDetail(key);
                            var triggers = scheduler.GetTriggersOfJob(job.Key);
                            jobs.Add(new JsonJob(job, triggers));
                        }
                    }
                }

                return JsonConvert.SerializeObject(jobs);
            };

            Put[""] = parameters =>
            {
                IJob job = null;
                return JsonConvert.SerializeObject(job);
            };

        }
    }
}
