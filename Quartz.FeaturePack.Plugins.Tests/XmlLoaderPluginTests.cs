using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;

namespace Quartz.FeaturePack.Plugins.Tests
{
	[TestFixture]
	public class XmlLoaderPluginTests
	{
		[Test]
		public void InitializeTestsAllFields()
		{
			XmlLoaderPlugin plugin = new XmlLoaderPlugin();
			plugin.FileName = "quartz_loader_all_fields.xml";
			IScheduler scheduler = new Mock<IScheduler>().Object;
			plugin.Initialize("MyPlugin", scheduler);
			Assert.AreEqual(1, plugin.Calendars.Count);
			Assert.IsTrue(plugin.Calendars.ContainsKey("name1"));
			Assert.AreEqual("description1", plugin.Calendars["name1"].Description);
		}

		[Test]
		public void InitializeTestsRequiredFields()
		{
			XmlLoaderPlugin plugin = new XmlLoaderPlugin();
			plugin.FileName = "quartz_loader_required_fields.xml";
			IScheduler scheduler = new Mock<IScheduler>().Object;
			plugin.Initialize("MyPlugin", scheduler);
			Assert.AreEqual(1, plugin.Calendars.Count);
			Assert.IsTrue(plugin.Calendars.ContainsKey("name1"));
			Assert.IsNull(plugin.Calendars["name1"].Description);
		}
	}
}
