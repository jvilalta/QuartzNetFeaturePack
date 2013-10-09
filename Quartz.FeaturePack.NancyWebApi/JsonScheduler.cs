using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz.FeaturePack.NancyWebApi
{
    public class JsonScheduler
    {
        public JsonScheduler(IScheduler scheduler)
        {
            isShutdown = scheduler.IsShutdown;
            inStandbyMode = scheduler.InStandbyMode;
            isStarted = scheduler.IsStarted;
            schedulerInstanceId = scheduler.SchedulerInstanceId;
            schedulerName = scheduler.SchedulerName;
            jobListeners = new List<JsonJobListener>();
            foreach (var item in scheduler.ListenerManager.GetJobListeners())
            {
                jobListeners.Add(new JsonJobListener(item));
            }
            schedulerListeners = new List<JsonSchedulerListener>();
            foreach (var item in scheduler.ListenerManager.GetSchedulerListeners())
            {
                schedulerListeners.Add(new JsonSchedulerListener(item));
            }
            schedulerContext = new JsonSchedulerContext(scheduler.Context);
            jobStoreClustered = scheduler.GetMetaData().JobStoreClustered;
            jobStoreSupportsPersistence = scheduler.GetMetaData().JobStoreSupportsPersistence;
            jobStoreType = scheduler.GetMetaData().JobStoreType.FullName;
            numberOfJobsExecuted = scheduler.GetMetaData().NumberOfJobsExecuted;
            runningSince = scheduler.GetMetaData().RunningSince;
            schedulerRemote = scheduler.GetMetaData().SchedulerRemote;
            schedulerType = scheduler.GetMetaData().SchedulerType.FullName;
            threadPoolSize = scheduler.GetMetaData().ThreadPoolSize;
            threadPoolType = scheduler.GetMetaData().ThreadPoolType.FullName;
            version = scheduler.GetMetaData().Version;
        }
        public string schedulerName { get; set; }

        public bool isShutdown { get; set; }

        public bool inStandbyMode { get; set; }

        public bool isStarted { get; set; }

        public string schedulerInstanceId { get; set; }

        public IList<JsonJobListener> jobListeners { get; set; }

        public List<JsonSchedulerListener> schedulerListeners { get; set; }

        public JsonSchedulerContext schedulerContext { get; set; }

        public DateTimeOffset? runningSince { get; set; }

        public bool jobStoreClustered { get; set; }

        public bool jobStoreSupportsPersistence { get; set; }

        public string jobStoreType { get; set; }

        public int numberOfJobsExecuted { get; set; }

        public bool schedulerRemote { get; set; }

        public string schedulerType { get; set; }

        public int threadPoolSize { get; set; }

        public string threadPoolType { get; set; }

        public string version { get; set; }
    }
}
