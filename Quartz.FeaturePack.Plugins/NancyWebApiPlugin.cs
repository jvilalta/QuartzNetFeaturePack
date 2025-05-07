using Nancy.Hosting.Self;
using Quartz.Spi;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        public Task Initialize(string pluginName, IScheduler scheduler, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Start(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Shutdown(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private static NancyHost _NancyHost;
        public static IScheduler Scheduler;
    }
}
