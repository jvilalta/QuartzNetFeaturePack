using Nancy.Hosting.Self;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.Plugins
{
    public class NancyWebApiPlugin : ISchedulerPlugin
    {
        public void Initialize(string pluginName, IScheduler sched)
        {
            _NancyHost = new Nancy.Hosting.Self.NancyHost(new Uri("http://localhost:8888"));
            Scheduler = sched;
        }

        public void Shutdown()
        {
            _NancyHost.Stop();
            Scheduler = null;
        }

        public void Start()
        {
            _NancyHost.Start();
        }
        private static NancyHost _NancyHost;
        public static IScheduler Scheduler;
    }
}
