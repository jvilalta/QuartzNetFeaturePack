using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class CssModule : NancyModule
    {
        public CssModule()
            : base("/css")
        {
            Get["/{script}"] = parameters =>
            {
                return new Nancy.Responses.EmbeddedFileResponse(GetType().Assembly, "Quartz.FeaturePack.NancyWebApi.Web.css", parameters.script);
            };
        }
    }
}
