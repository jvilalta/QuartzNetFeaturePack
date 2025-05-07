using Nancy;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class CssModule : NancyModule
    {
        public CssModule()
            : base("/css")
        {
            Get("/{script}", parameters =>
            {
                return new Nancy.Responses.EmbeddedFileResponse(
                    GetType().Assembly,
                    "Quartz.FeaturePack.NancyWebApi.Web.css",
                    (string)parameters.script
                );
            });
        }
    }
}
