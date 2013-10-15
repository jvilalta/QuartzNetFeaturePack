using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class WebModule : NancyModule
    {
        public WebModule()
            : base("/")
        {
            Get[""] = parameters =>
                {
                    return View["index.html"];
                };
        }

    }
}
