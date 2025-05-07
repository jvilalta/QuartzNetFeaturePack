using Nancy;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class ScriptsModule : NancyModule
    {
        public ScriptsModule()
            : base("/scripts")
        {
            Get("/{folder}/{script}", parameters =>
            {
                return new Nancy.Responses.EmbeddedFileResponse(GetType().Assembly, "Quartz.FeaturePack.NancyWebApi.Web.scripts." + parameters.folder, parameters.script);
            });
        }
    }
}
