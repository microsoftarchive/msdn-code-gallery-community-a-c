using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Automation;
using System.Diagnostics;
using System.Configuration;

namespace AzureAPILibrary
{
    public class AzureAutomation
    {
        
        public static void CreateAutomationRunbook()
        {
            try
            {
                Microsoft.Azure.SubscriptionCloudCredentials creds;
                creds = CertificateAuthenticationHelper.GetCredentials(ConfigurationManager.AppSettings["SubscriptionID"], ConfigurationManager.AppSettings["Certificate"]);
                AutomationManagementClient automationClient = new AutomationManagementClient(creds);
                //Create Runbook
                FileStream fs = new FileStream(AzureAutomationSchema.ScriptFileLocation, FileMode.Open, FileAccess.Read);
                // Get Runbook Response
                var runbookversion = automationClient.RunbookVersions.Create(AzureAutomationSchema.automationAccount, fs);
                Trace.TraceInformation("Status of RunbookVersion Create request:" + runbookversion.StatusCode.ToString() + ".RunbookVersionId " + runbookversion.RunbookVersion.Id + "  Created.");

                var runbook = automationClient.Runbooks.ListByName(AzureAutomationSchema.automationAccount, AzureAutomationSchema.runbookname);

                // Get Runbook Publish Response
                Microsoft.Azure.Management.Automation.Models.RunbookPublishResponse pubresponse = automationClient.Runbooks.Publish(AzureAutomationSchema.automationAccount, new Microsoft.Azure.Management.Automation.Models.RunbookPublishParameters(runbook.Runbooks[0].Id, "Joe"));
                Trace.TraceInformation("Status of RunbookPublish request:" + pubresponse.StatusCode.ToString() + ". PublishedRunbookVersionId " + pubresponse.PublishedRunbookVersionId + "  Created.");

                Microsoft.Azure.Management.Automation.Models.Schedule RuleEngineSchedule = new Microsoft.Azure.Management.Automation.Models.Schedule();
                //Define Automation Schedule
                Microsoft.Azure.Management.Automation.Models.ScheduleCreateParameters scheduleParam = new Microsoft.Azure.Management.Automation.Models.ScheduleCreateParameters();
                scheduleParam.Schedule = RuleEngineSchedule;
                scheduleParam.Schedule.Description = AzureAutomationSchema.ScheduleDescription;
                scheduleParam.Schedule.StartTime = AzureAutomationSchema.ScheduleStartTime;
                scheduleParam.Schedule.IsEnabled = AzureAutomationSchema.ScheduleIsEnabled;
                scheduleParam.Schedule.DayInterval = AzureAutomationSchema.ScheduleDayInterval;
                scheduleParam.Schedule.Name = AzureAutomationSchema.ScheduleName;
                if (AzureAutomationSchema.ScheduleScheduleType == "DailySchedule")
                {
                    scheduleParam.Schedule.ScheduleType = Microsoft.Azure.Management.Automation.Models.ScheduleType.DailySchedule;
                }
                if (AzureAutomationSchema.ScheduleScheduleType == "HourlySchedule")
                {
                    scheduleParam.Schedule.ScheduleType = Microsoft.Azure.Management.Automation.Models.ScheduleType.HourlySchedule;
                }
                scheduleParam.Schedule.ExpiryTime = AzureAutomationSchema.ScheduleExpiryTime;
                // Get RunbookSchedule  response
                var response = automationClient.Schedules.Create(AzureAutomationSchema.automationAccount, scheduleParam);
                Trace.TraceInformation("Status of Schedule request:" + response.StatusCode.ToString() + ". " + response.Schedule.Name + "  Created.");

                Microsoft.Azure.Management.Automation.Models.RunbookCreateScheduleLinkParameters RuleEngineScheduleLink = new Microsoft.Azure.Management.Automation.Models.RunbookCreateScheduleLinkParameters();
                RuleEngineScheduleLink.RunbookId = runbook.Runbooks[0].Id;
                RuleEngineScheduleLink.ScheduleId = response.Schedule.Id;

                //Adding Parameters to Automation Schedule
                foreach (var param in ConfigurationManager.AppSettings.AllKeys.Where(key => key.StartsWith("Param")))
                {
                    RuleEngineScheduleLink.Parameters.Add(AddParametersToScheduleLink(param.Replace("Param", ""), ConfigurationManager.AppSettings[param]));
                }

                // Get RunbookSchedule link response
                Microsoft.Azure.Management.Automation.Models.RunbookCreateScheduleLinkResponse RuleEngineScheduleLinkResponse = automationClient.Runbooks.CreateScheduleLink(AzureAutomationSchema.automationAccount, RuleEngineScheduleLink);
                Trace.TraceInformation("Status of ScheduleLink request:" + RuleEngineScheduleLinkResponse.StatusCode.ToString() + ". JobContextID " + RuleEngineScheduleLinkResponse.JobContextId + "  Created.");
            }
            catch(Exception ex)
            {
                Trace.TraceError(ex.Message);
                throw ex;
            }
        }

        // Adding Azure Schedule Link Parameters
        public static Microsoft.Azure.Management.Automation.Models.NameValuePair AddParametersToScheduleLink(string Key, string Value)
        {
            Microsoft.Azure.Management.Automation.Models.NameValuePair param1 = new Microsoft.Azure.Management.Automation.Models.NameValuePair();
            param1.Name = Key;
            param1.Value = Value;
            return param1;


        }
    }
}
