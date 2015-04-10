using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using Nancy.Conventions;
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

        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/", @"Web\"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Styles", @"Web\styles"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/jspm_packages", @"Web\jspm_packages"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/dist", @"Web\dist"));
            base.ConfigureConventions(nancyConventions);
        }
        private void OnConfigurationBuilder(NancyInternalConfiguration internalConfiguration)
        {
            //internalConfiguration.ViewLocationProvider = typeof(ResourceViewLocationProvider);
        }
    }
}
