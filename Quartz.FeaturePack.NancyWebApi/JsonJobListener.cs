using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonJobListener
    {
        public JsonJobListener(IJobListener listener)
        {
            name = listener.Name;
        }

        public string name { get; set; }
    }
}
