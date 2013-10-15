using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            var assembly = GetType().Assembly;
            ResourceViewLocationProvider.RootNamespaces.Add(assembly, "Quartz.FeaturePack.NancyWebApi.Web");
        }
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder);
            }
        }

        private void OnConfigurationBuilder(NancyInternalConfiguration internalConfiguration)
        {
            internalConfiguration.ViewLocationProvider = typeof(ResourceViewLocationProvider);
        }
    }
}
