using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;

namespace Quartz.FeaturePack.Services
{
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        [WebGet(UriTemplate = "jobs/running?format={format}")]
        [ServiceKnownType(typeof(Atom10FeedFormatter))]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        SyndicationFeedFormatter GetRunningJobs(string format);
        
        [OperationContract]
        [WebGet(UriTemplate = "jobs?format={format}")]
        [ServiceKnownType(typeof(Atom10FeedFormatter))]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        SyndicationFeedFormatter GetJobs(string format);
        
        [OperationContract]
        [WebGet(UriTemplate = "jobs/history?format={format}")]
        [ServiceKnownType(typeof(Atom10FeedFormatter))]
        [ServiceKnownType(typeof(Rss20FeedFormatter))]
        SyndicationFeedFormatter GetJobHistory(string format);
    }
}
