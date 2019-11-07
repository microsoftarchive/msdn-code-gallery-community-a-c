using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Mvc5Mobile.Models
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
                           select new Session
                           {
                               Title = s.Element("Title").Value,
                               Abstract = s.Element("Abstract").Value,
                               Room = s.Element("Room").Value,
                               Code = s.Element("Code").Value,
                               DateText = s.Element("Date").Value,
                               StartDate = ParseStartDate(s.Element("Date").Value),
                               Speakers = s.Elements("Speaker").Select(x => x.Value),
                               Tags = s.Elements("Tag").Select(x => x.Value),
                               Url = s.Element("Url").Value
                           };
            All = sessions.ToList();
        }

        private static DateTime ParseStartDate(string dateString)
        {
            // Parse text strictly of the form "04/02/2014 8:30am - 11:30am"
            //var date = dateString.Substring(0, 10);
            //var time = dateString.Substring(11, 7);
            //var combined = date + " 2011, " + time;
            return DateTime.Parse(dateString.Substring(0, 18));
        }
    }
}