using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonTrigger
    {
        public JsonTrigger(ITrigger trigger)
        {
            Description = trigger.Description;
        }

        public string Description { get; set; }
    }
}
