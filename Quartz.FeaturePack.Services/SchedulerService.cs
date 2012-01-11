using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Quartz.FeaturePack.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SchedulerService : ISchedulerService
    {
    }
}
