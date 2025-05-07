using Castle.Core;
using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Quartz.Spi;
using System;
using System.IO;
using System.Reflection;

namespace Quartz.FeaturePack.JobFactories
{
    /// <summary>
    /// A job factory that uses Windsor Castle to resolve dependencies.
    /// </summary>
    public class CastleJobFactory : IJobFactory
    {
        public CastleJobFactory()
        {
            _Container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _Container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(path)).BasedOn<IJob>().Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _Container.Resolve(bundle.JobDetail.JobType) as IJob;
        }

        private static WindsorContainer _Container;

        public void ReturnJob(IJob job)
        {
            throw new NotImplementedException();
        }
    }
}
