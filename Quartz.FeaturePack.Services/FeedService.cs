using Quartz.FeaturePack.Listeners;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Text;

namespace Quartz.FeaturePack.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FeedService : IFeedService
    {
        public FeedService(IScheduler scheduler)
        {
            _Scheduler = scheduler;
            _Listener = new JobFeedListener();
            scheduler.ListenerManager.AddJobListener(_Listener, EverythingMatcher<JobKey>.AllJobs());
        }
        public SyndicationFeedFormatter GetRunningJobs(string format)
        {
            var jobs = _Scheduler.GetCurrentlyExecutingJobs().Result;
            SyndicationFeed feed = new SyndicationFeed();
            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (var job in jobs)
            {
                SyndicationItem item = new SyndicationItem();
                item.Id = job.FireInstanceId;
                item.LastUpdatedTime = DateTime.UtcNow;
                item.Title = new TextSyndicationContent(string.Format("{0} - {1}", job.JobDetail.Key.Group, job.JobDetail.Key.Name), TextSyndicationContentKind.Plaintext);
                item.Summary = new TextSyndicationContent(string.Format("Job {0} for group {1} has been running for {2} minutes.", job.JobDetail.Key.Name, job.JobDetail.Key.Group, job.JobRunTime.TotalMinutes), TextSyndicationContentKind.Plaintext);
                item.Content = new TextSyndicationContent(getJobDetails(job), TextSyndicationContentKind.Plaintext);
                items.Add(item);
            }
            feed.Items = items;
            SyndicationFeedFormatter formatter = new Rss20FeedFormatter(feed);

            return formatter;
        }

        private string getJobDetails(IJobExecutionContext job)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Group: {0}", job.JobDetail.Key.Group));
            builder.AppendLine(string.Format("Name: {0}", job.JobDetail.Key.Name));
            builder.AppendLine(string.Format("Description: {0}", job.JobDetail.Description));
            builder.AppendLine(string.Format("Job Type: {0}", job.JobDetail.JobType));

            return builder.ToString();
        }

        private IScheduler _Scheduler = null;
        private JobFeedListener _Listener = null;

        public SyndicationFeedFormatter GetJobs(string format)
        {
            var groups = _Scheduler.GetJobGroupNames().Result;
            SyndicationFeed feed = new SyndicationFeed();
            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (var group in groups)
            {
                var jobKeys = _Scheduler.GetJobKeys(GroupMatcher<JobKey>.GroupEquals(group)).Result;

                foreach (var jobKey in jobKeys)
                {
                    var job = _Scheduler.GetJobDetail(jobKey).Result;
                    SyndicationItem item = new SyndicationItem();
                    item.Id = job.Key.ToString();
                    item.LastUpdatedTime = DateTime.UtcNow;
                    item.Title = new TextSyndicationContent(string.Format("{0} - {1}", job.Key.Group, job.Key.Name), TextSyndicationContentKind.Plaintext);
                    item.Summary = new TextSyndicationContent(string.Format("Job {0} for group {1}.", job.Key.Name, job.Key.Group), TextSyndicationContentKind.Plaintext);
                    items.Add(item);
                }

            }
            feed.Items = items;
            SyndicationFeedFormatter formatter = new Rss20FeedFormatter(feed);

            return formatter;
        }

        public SyndicationFeedFormatter GetJobHistory(string format)
        {
            var jobDataList = _Listener.GetHistory();
            SyndicationFeed feed = new SyndicationFeed();
            List<SyndicationItem> items = new List<SyndicationItem>();
            foreach (var jobData in jobDataList)
            {
                SyndicationItem item = new SyndicationItem();
                item.Id = jobData.FireInstanceId;
                item.LastUpdatedTime = jobData.JobEndTime;
                item.Title = new TextSyndicationContent(string.Format("{0} - {1}", jobData.JobGroup, jobData.JobName), TextSyndicationContentKind.Plaintext);
                item.Summary = new TextSyndicationContent(string.Format("Job {0} for group {1} finished at {2}.", jobData.JobName, jobData.JobGroup, jobData.JobEndTime.ToString()), TextSyndicationContentKind.Plaintext);
                item.Content = new TextSyndicationContent(string.Format("The job ran for {0} seconds.", (jobData.JobEndTime - jobData.JobStartTime).TotalSeconds), TextSyndicationContentKind.Plaintext);
                items.Add(item);

            }
            feed.Items = items;
            SyndicationFeedFormatter formatter = new Rss20FeedFormatter(feed);

            return formatter;
        }
    }
}
