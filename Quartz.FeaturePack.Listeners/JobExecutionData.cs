using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.Listeners
{
    public class JobExecutionData
    {
        public string JobName { get; set; }
        public string JobGroup { get; set; }
        public DateTime JobStartTime { get; set; }
        public DateTime JobEndTime { get; set; }
        public string FireInstanceId { get; set; }
    }
}
