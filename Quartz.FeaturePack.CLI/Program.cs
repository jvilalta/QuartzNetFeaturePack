using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topshelf;
using Quartz.FeaturePack.Server;
namespace Quartz.FeaturePack.CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			var exiteCode = HostFactory.Run(x =>
			{
				x.Service<IQuartzServer>(s =>
				{
					s.ConstructUsing(name =>
					{
						QuartzServer server = new QuartzServer();
						server.Initialize();
						return server;
					});
                    s.WhenStarted(server => server.Start());
                    s.WhenPaused(server => server.Pause());
                    s.WhenContinued(server => server.Resume());
                    s.WhenStopped(server => server.Stop());
				});

				x.RunAsLocalSystem();

				x.SetDescription("Quartz.Net Server");
				x.SetDisplayName("Quartz.Net Server");
				x.SetServiceName("Quartz.NetServer");
			});

		}
	}
}
