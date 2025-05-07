﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Quartz.FeaturePack.Listeners
{
    public class JobFeedListener : IJobListener
    {
        public string Name
        {
            get { return "JobFeedListener"; }
        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {
            JobExecutionData data = new JobExecutionData();
            data.JobName = context.JobDetail.Key.Name;
            data.JobGroup = context.JobDetail.Key.Group;
            data.JobStartTime = DateTime.Now;
            data.FireInstanceId = context.FireInstanceId;
            context.Put("JobExecutionData", data);
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            JobExecutionData data = context.Get("JobExecutionData") as JobExecutionData;
            if (data != null)
            {
                data.JobEndTime = DateTime.Now;
                lock (_Data)
                {
                    if (_Data.Count > _Capacity)
                    {
                        _Data.RemoveAt(0);
                    }
                    _Data.Add(data);

                }
            }
        }

        public List<JobExecutionData> GetHistory()
        {
            return _Data;
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        private int _Capacity = 5;

        private List<JobExecutionData> _Data = new List<JobExecutionData>();
    }
}
