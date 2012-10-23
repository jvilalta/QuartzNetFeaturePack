using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Quartz.Impl.Calendar;

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
		[Test]
		public void CronCalendarTest()
		{
			XmlLoaderPlugin plugin = new XmlLoaderPlugin();
			plugin.FileName = "quartz_loader_required_fields.xml";
			IScheduler scheduler = new Mock<IScheduler>().Object;
			plugin.Initialize("MyPlugin", scheduler);
			CronCalendar cal = plugin.Calendars["name1"] as CronCalendar;
			Assert.AreEqual("* * 0-20 * * ?", cal.CronExpression.CronExpressionString);
			Assert.IsTrue(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 17, 0, 0, new TimeSpan(0,0,0))));

		}
		[Test]
		public void DailyCalendarTest()
		{
			XmlLoaderPlugin plugin = new XmlLoaderPlugin();
			plugin.FileName = "quartz_loader_required_fields_daily_calendar.xml";
			IScheduler scheduler = new Mock<IScheduler>().Object;
			plugin.Initialize("MyPlugin", scheduler);
			DailyCalendar cal = plugin.Calendars["DailyCalendar1"] as DailyCalendar;
			Assert.IsTrue(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 17, 0, 0, new TimeSpan(-6, 0, 0))));
			Assert.IsTrue(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 18, 0, 0, new TimeSpan(-6, 0, 0))));
			Assert.IsFalse(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 19, 20, 0, new TimeSpan(-6, 0, 0))));

		}
	}
}
