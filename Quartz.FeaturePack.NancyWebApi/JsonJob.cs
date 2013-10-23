using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonJob
    {
        public JsonJob(IJobDetail jobDetail, IList<ITrigger> triggers)
        {
            JobType = jobDetail.JobType.FullName;
            Description = jobDetail.Description;
            Triggers = new List<JsonTrigger>(triggers.Count);
            foreach (var trigger in triggers)
            {
                Triggers.Add(new JsonTrigger(trigger));
            }
        }

        public string JobType { get; set; }

        public string Description { get; set; }

        public List<JsonTrigger> Triggers { get; set; }
    }
}
