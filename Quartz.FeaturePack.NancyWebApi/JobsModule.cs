using Nancy;
using Quartz.FeaturePack.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Impl.Matchers;

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
                var jobs = new List<IJobDetail>();
                var jobGroupNames = scheduler.GetJobGroupNames();
                if (jobGroupNames != null)
                {
                    foreach (var name in jobGroupNames)
                    {
                        foreach (var key in scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(name)))
                        {
                            jobs.Add(scheduler.GetJobDetail(key));
                        }
                    }
                }

                return Newtonsoft.Json.JsonConvert.SerializeObject(jobs);
            };

        }
    }
}
