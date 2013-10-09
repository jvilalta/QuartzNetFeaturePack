using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonSchedulerListener
    {
        public JsonSchedulerListener(ISchedulerListener listener)
        {
            name = listener.GetType().FullName;
        }

        public string name { get; set; }
    }
}
