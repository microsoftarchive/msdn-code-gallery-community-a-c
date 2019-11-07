using System;

namespace SampleToSupportFunction
{
    public class Utility
    {
        public static string GetDateBytimeZone(TimeZoneInfo timeZone)
        {
            DateTime d = TimeZoneInfo.ConvertTime(DateTime.UtcNow, timeZone);
            return d.ToString("G");
        }
    }
}
