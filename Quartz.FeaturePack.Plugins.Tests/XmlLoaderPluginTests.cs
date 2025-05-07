using Moq;
using NUnit.Framework;
using Quartz.Impl.Calendar;
using System;

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
            Assert.That(plugin.Calendars.Count, Is.EqualTo(1));
            Assert.That(plugin.Calendars.ContainsKey("name1"), Is.True);
            Assert.That(plugin.Calendars["name1"].Description, Is.EqualTo("description1"));
        }

        [Test]
        public void InitializeTestsRequiredFields()
        {
            XmlLoaderPlugin plugin = new XmlLoaderPlugin();
            plugin.FileName = "quartz_loader_required_fields.xml";
            IScheduler scheduler = new Mock<IScheduler>().Object;
            plugin.Initialize("MyPlugin", scheduler);
            Assert.That(plugin.Calendars.Count, Is.EqualTo(1));
            Assert.That(plugin.Calendars.ContainsKey("name1"), Is.True);
            Assert.That(plugin.Calendars["name1"].Description, Is.Null);
        }
        [Test]
        public void CronCalendarTest()
        {
            XmlLoaderPlugin plugin = new XmlLoaderPlugin();
            plugin.FileName = "quartz_loader_required_fields.xml";
            IScheduler scheduler = new Mock<IScheduler>().Object;
            plugin.Initialize("MyPlugin", scheduler);
            CronCalendar cal = plugin.Calendars["name1"] as CronCalendar;
            Assert.That(cal.CronExpression.CronExpressionString, Is.EqualTo("* * 0-20 * * ?"));
            Assert.That(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 17, 0, 0, new TimeSpan(0, 0, 0))), Is.True);
        }
        [Test]
        public void DailyCalendarTest()
        {
            XmlLoaderPlugin plugin = new XmlLoaderPlugin();
            plugin.FileName = "quartz_loader_required_fields_daily_calendar.xml";
            IScheduler scheduler = new Mock<IScheduler>().Object;
            plugin.Initialize("MyPlugin", scheduler);
            DailyCalendar cal = plugin.Calendars["DailyCalendar1"] as DailyCalendar;
            Assert.That(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 17, 0, 0, new TimeSpan(-6, 0, 0))), Is.True);
            Assert.That(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 18, 0, 0, new TimeSpan(-6, 0, 0))), Is.True);
            Assert.That(cal.IsTimeIncluded(new DateTimeOffset(2012, 08, 30, 19, 20, 0, new TimeSpan(-6, 0, 0))), Is.False);
        }
    }
}
