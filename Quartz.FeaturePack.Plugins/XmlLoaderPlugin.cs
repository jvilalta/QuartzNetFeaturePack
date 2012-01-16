using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Spi;

namespace Quartz.FeaturePack.Plugins
{
    /// <summary>
    /// This plugin loads jobs, triggers, listeners and calendars that are defined in an xml file
    /// </summary>
    public class XmlLoaderPlugin : ISchedulerPlugin
    {
        public void Initialize(string pluginName, IScheduler sched)
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
