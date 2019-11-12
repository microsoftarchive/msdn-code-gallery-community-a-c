using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MvcMobile.Models
{
    // Could be loaded from a DB, but an in-memory collection is fine for this example
    public static class Sessions
    {
        public static IList<Session> All { get; private set; }

        static Sessions()
        {
            // Parse the XML
            var xmlFilename = HttpContext.Current.Server.MapPath("~/App_Data/Sessions/RawSessionsData.xml");
            var xml = XDocument.Load(xmlFilename);
            var sessions = from s in xml.Root.Elements("Session")
                           select new Session {
                               Title = s.Element("Title").Value,
                               Description = s.Element("Description").Value,
                               Room = s.Element("Room").Value,
                               Code = s.Element("Code").Value,
                               DateText = s.Element("Date").Value,
                               StartDate = ParseStartDate(s.Element("Date").Value),
                               Speakers = s.Elements("Speaker").Select(x => x.Value),
                               Tags = s.Elements("Tag").Select(x => x.Value)
                           };
            All = sessions.ToList();
        }

        private static DateTime ParseStartDate(string dateString)
        {
            // Parse text strictly of the form "Thu, Apr 14 12:00 PM - 1:00 PM"
            var date = dateString.Substring(5, 6);
            var time = dateString.Substring(11, 9);
            var combined = date + " 2011, " + time;
            return DateTime.Parse(combined);
        }
    }
}