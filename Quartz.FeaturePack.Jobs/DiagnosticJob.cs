using Common.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.FeaturePack.Jobs
{
    /// <summary>
    /// This job dumps to the log all of the scheduler information as it is running. It gives us a look at what is going on at a given time.
    /// </summary>
    public class DiagnosticJob : IJob
    {
        #region IJob Members

        public void Execute(IJobExecutionContext context)
        {
            _Log.InfoFormat("Calendar Names: {0}", string.Join(",", context.Scheduler.GetCalendarNames()));
            outputMetadata(context.Scheduler.GetMetaData().Result);
            Thread.Sleep(5000);
            //TODO: dump more data here
        }

        private void outputMetadata(SchedulerMetaData metaData)
        {
            _Log.InfoFormat("Scheduler Metadata:\nRunning Since: {0}", metaData.RunningSince);
        }

        Task IJob.Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }

        #endregion
        private static readonly ILog _Log = LogManager.GetLogger(typeof(DiagnosticJob));
    }
}
