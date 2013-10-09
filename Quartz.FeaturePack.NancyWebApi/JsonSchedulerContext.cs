using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonSchedulerContext
    {
        public JsonSchedulerContext(SchedulerContext schedulerContext)
        {
            entrySet = new Dictionary<string, object>();
            foreach (var item in schedulerContext)
            {
                entrySet.Add(item.Key, item.Value);
            }
        }
        public Dictionary<string, object> entrySet { get; set; }
    }
}
