using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Spi;
using System.ServiceModel;
using Quartz.FeaturePack.Services;
using System.ServiceModel.Web;

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
        private ServiceHost _Host = null;
    }
}
