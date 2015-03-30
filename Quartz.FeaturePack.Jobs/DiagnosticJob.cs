using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using System.Threading;

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
			outputMetadata(context.Scheduler.GetMetaData());
		}

		private void outputMetadata(SchedulerMetaData metaData)
		{
			_Log.DebugFormat("Scheduler Metadata:\nRunning Since: {0}", metaData.RunningSince);
            //TODO: dump more data here
        }

		#endregion
		private static readonly ILog _Log = LogManager.GetLogger(typeof(DiagnosticJob));
	}
}
