namespace AlertWebhookDemo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.Serialization.Formatters;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using Microsoft.Azure.Management.Insights;
    using Microsoft.Azure.Management.Insights.Models;
    using Microsoft.Azure.Insights;
    using Microsoft.Azure.Insights.Models;
    using System.Xml;
    using System.Net.Http.Headers;
    using Microsoft.Azure;
    using Microsoft.Azure.Common.OData;

    class Program
    {
        private const string tenantId = "your_azure_tenant_id";
        private const string clientId = "enter_your_client_id";
        private const string subscriptionId = "enter_your_azure_subscription_id";        
        private const string URI = "create_a_uri";
        private const string ServiceUrl = "https://management.azure.com";
       
        [STAThread]
        static void Main(string[] args)
        {
            
            string authorizationToken = "";

            CreateAlertRule(authorizationToken);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static string GetAuthorizationHeader()
        {
            try
            {
                //Establish context & Acquire token 
                var context = new AuthenticationContext("https://login.windows.net/" + tenantId);

                Uri uri = new Uri(URI);
                AuthenticationResult result = context.AcquireToken("https://management.core.windows.net/", clientId, uri);

                if (result == null)
                {
                    throw new InvalidOperationException("Failed to obtain the token.");
                }

                return result.AccessToken;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.InnerException);
                throw;
            }
        }
        private static void CreateAlertRule(string authorizationToken)
        {
            
            string token = GetAuthorizationHeader();
            TokenCloudCredentials credentials = new TokenCloudCredentials(subscriptionId, token);

            InsightsManagementClient client = new InsightsManagementClient(credentials, new Uri(ServiceUrl));

            RuleCreateOrUpdateParameters parameters = new RuleCreateOrUpdateParameters();

            List<RuleAction> actions = new List<RuleAction>();

            //The new RuleWebhookAction has two properties - the uri and a property bag, which can be key value pairs
            //Lets create some key-value pairs to be added as properties for this webhook

            Dictionary<string, string> properties = new Dictionary<string, string>();
            properties.Add("Hello1", "World1!");
            properties.Add("json_stuff", "{\"type\":\"critical\", \"color\":\"red\"}'");
            properties.Add("customId", "wd39ue9832ue9iuhd9iuewhd9edh");
            properties.Add("send_emails_to", "someone@somewhere.com");


            // NOTE: you can add up to 5 webhooks for an alert programmatically 
            // if you configure multiple webhooks programmtically, you can only view/edit the 1st one via the Azure Portal UI 
            // We will add the ability to configure multiple webhooks via the portal soon
             
            
            // my runscope uri
            actions.Add(new RuleWebhookAction() { ServiceUri = "your_runscope_uri", Properties = properties});

            //pager_duty uri
            actions.Add(new RuleWebhookAction() { ServiceUri = "your_pagerduty_uri", Properties = properties });

            
            parameters.Properties = new Rule()
            {
                Name = "Alert_webhook_demo1",
                Action = new RuleEmailAction()
                {
                    CustomEmails = new List<string>() { "email@example.com" }
                },

                IsEnabled = true,
                Actions = actions,
                Condition = new ThresholdRuleCondition()
                {
                    DataSource = new RuleMetricDataSource()
                    {
                        MetricName = "\\Memory\\Available Bytes",
                        ResourceUri = "your_resource_id"
                    },
                    Operator = ConditionOperator.GreaterThan,
                    Threshold = 1.0,
                    TimeAggregation = TimeAggregationOperator.Average,
                    WindowSize = TimeSpan.FromMinutes(5),

                }
            };
            parameters.Location = "location_for_your_alert_rule";  // e.g "eastus"
            var response = client.AlertOperations.CreateOrUpdateRule("your_resoureGroupeName", parameters);
            Console.WriteLine("Alert created with a webhook!");           
        }

    }
}