﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz.Spi;
using System.Xml.Linq;
using Quartz.Impl.Calendar;

namespace Quartz.FeaturePack.Plugins
{
	/// <summary>
	/// This plugin loads jobs, triggers, listeners and calendars that are defined in an xml file
	/// </summary>
	public class XmlLoaderPlugin : ISchedulerPlugin
	{
		public string FileName { get; set; }
		private string Name { get; set; }
		public IScheduler Scheduler { get; set; }
		public Dictionary<string, ICalendar> Calendars { get; set; }
		public void Initialize(string pluginName, IScheduler sched)
		{
			Calendars = new Dictionary<string, ICalendar>();
			Name = pluginName;
			Scheduler = sched;
			parseCalendars();
		}

		private void parseCalendars()
		{
			XElement doc = XElement.Load(FileName);
			XNamespace ns = doc.GetDefaultNamespace();
			var calendars = doc.Descendants(ns + "calendars").Elements();
			foreach (var calendarXml in calendars)
			{
				string type = calendarXml.Name.LocalName;
				ICalendar calendar = null;
				switch (type)
				{
					case "cronCalendar":
						calendar = parseCronCalendar(calendarXml);
						break;
					default:
						throw new ArgumentOutOfRangeException(string.Format("Calendar type {0} is not supported", type));
				}
				string calendarName = parseCalendarName(calendarXml);
				Scheduler.AddCalendar(calendarName, calendar, parseReplaceCalendar(calendarXml), parseUpdateTriggers(calendarXml));
				Calendars.Add(parseCalendarName(calendarXml), calendar);
			}
		}

		private ICalendar parseCronCalendar(XElement calendarXml)
		{
			CronCalendar calendar = new CronCalendar(parseCronExpression(calendarXml));
			calendar.Description = parseDescription(calendarXml);
			return calendar;
		}

		private string parseDescription(XElement calendarXml)
		{
			XNamespace ns = calendarXml.GetDefaultNamespace();
			XElement element = calendarXml.Element(ns + "description");
			if (element == null)
			{
				return null;
			}
			return element.Value.Trim();
		}

		private bool parseUpdateTriggers(XElement calendarXml)
		{
			XNamespace ns = calendarXml.GetDefaultNamespace();
			XElement element = calendarXml.Element(ns + "updateTriggers");
			if (element == null)
			{
				return false;
			}
			return Convert.ToBoolean(element.Value);
		}

		private bool parseReplaceCalendar(XElement calendarXml)
		{
			XNamespace ns = calendarXml.GetDefaultNamespace();
			XElement element = calendarXml.Element(ns + "replaceCalendar");
			if (element == null)
			{
				return false;
			}
			return Convert.ToBoolean(element.Value);
		}

		private string parseCalendarName(XElement calendarXml)
		{
			XNamespace ns = calendarXml.GetDefaultNamespace();
			return calendarXml.Element(ns + "name").Value;
		}

		private string parseCronExpression(XElement calendarXml)
		{
			XNamespace ns = calendarXml.GetDefaultNamespace();
			return calendarXml.Element(ns + "cronExpression").Value;
		}

		public void Shutdown()
		{
			Scheduler = null;
		}

		public void Start()
		{
		}
	}
}
