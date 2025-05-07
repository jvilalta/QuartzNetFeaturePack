using Quartz.FeaturePack.Services;
using Quartz.Spi;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.FeaturePack.Plugins
{
    /// <summary>
    /// This plugin is responsible for hosting the WCF service that provides RSS feeds for scheduler information.
    /// </summary>
    public class FeedServicePlugin : ISchedulerPlugin
    {
        public void Initialize(string pluginName, IScheduler scheduler)
        {
            _Host = new WebServiceHost(new FeedService(scheduler));
        }

        public void Shutdown()
        {
            _Host.Close();
        }

        public void Start()
        {
            _Host.Open();
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

        private ServiceHost _Host = null;
    }
}
