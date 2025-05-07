using Nancy;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class WebModule : NancyModule
    {
        public WebModule()
            : base("/")
        {
            Get("", parameters =>
                {
                    return View["index.html"];
                });
        }

    }
}
