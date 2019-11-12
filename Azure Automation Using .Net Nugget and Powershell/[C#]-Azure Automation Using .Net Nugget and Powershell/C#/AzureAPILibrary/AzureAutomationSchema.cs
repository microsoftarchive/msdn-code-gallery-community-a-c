using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AzureAPILibrary
{
    public class AzureAutomationSchema
    {
        public static string ScriptFileLocation = ConfigurationSettings.AppSettings["ScriptFileLocation"];
        public static string automationAccount = ConfigurationSettings.AppSettings["automationAccount"];
        public static string runbookname = ConfigurationSettings.AppSettings["runbookname"];
        public static DateTime ScheduleStartTime = Convert.ToDateTime(ConfigurationSettings.AppSettings["ScheduleStartTime"]).ToUniversalTime();
        public static bool ScheduleIsEnabled = Convert.ToBoolean(ConfigurationSettings.AppSettings["ScheduleIsEnabled"]);
        public static int? ScheduleDayInterval = Convert.ToInt16(ConfigurationSettings.AppSettings["ScheduleDayInterval"]);
        public static string ScheduleName = runbookname + ConfigurationSettings.AppSettings["ScheduleName"];
        public static string ScheduleScheduleType = ConfigurationSettings.AppSettings["ScheduleScheduleType"];
        public static DateTime ScheduleExpiryTime = Convert.ToDateTime(ConfigurationSettings.AppSettings["ScheduleExpiryTime"]).ToUniversalTime();
        public static string ScheduleDescription = ConfigurationSettings.AppSettings["ScheduleDescription"];

    }
}
