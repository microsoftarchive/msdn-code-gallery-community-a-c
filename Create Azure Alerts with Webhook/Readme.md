# Create Azure Alerts with Webhook
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- Microsoft Azure
## Topics
- Microsoft Azure
## Updated
- 09/28/2015
## Description

<h1>Introduction</h1>
<p>This sample will help you get started with creating an Azure Alert with webhooks on metric data from an Azure Virtual Machine.</p>
<p>Webhooks allow you to route Azure Alerts to other services or notification channels. Learn more about configuring webhooks for Azure Alerts here: http://go.microsoft.com/fwlink/?LinkId=626008</p>
<p>Using webhooks for Azure Alerts you can route your alerts to additonal services such as -</p>
<p>- PagerDuty, OpsGenie, VictorOps etc</p>
<p>- Azure Automation Runbooks</p>
<p>- Logic apps</p>
<p>- Twilio APIs to send text messages</p>
<p>- APIs that notify you via Slack, HipChat, Campfire etc</p>
<h1><span>Building the Sample</span></h1>
<p>1. Use Visual Studio 2013</p>
<p>2. Please make sure you download the latest Nuget packages for the following in your project</p>
<ul>
<li>Microsoft Azure Insights Library (Microsoft.Azure.Insights) </li><li>Microsoft Active Directory Library (Microsoft.IdentityModel.Clients.ActiveDirectory)
</li></ul>
<p>3. Make sure you have diagnostics turned on for the Azure VM on which you plan to configure this alert</p>
<p>4. SubscriptionId:&nbsp; Go to <a href="https://manage.windowsazure.com">https://manage.windowsazure.com</a>&nbsp;-&gt; Settings&nbsp; -&gt; Subscription Id<br>
or <a href="https://portal.azure.com">https://portal.azure.com</a>&nbsp; -&gt; Browse -&gt; Subscriptions -&gt; Subscription Id</p>
<p>5. For TenantID/ClientID/URI follow the &quot;Set up Authentication using the Management Portal&quot; (<a href="https://msdn.microsoft.com/en-us/library/azure/dn790557.aspx">https://msdn.microsoft.com/en-us/library/azure/dn790557.aspx</a> )&nbsp;step in Authenticating
 Azure Resource Manager requests<br>
&nbsp;&nbsp;&nbsp; 1. TenantID&nbsp; - found in Step 3.3<br>
&nbsp;&nbsp;&nbsp; 2. ClientID (aka Application ID) - found in Step 3.3<br>
&nbsp;&nbsp;&nbsp; 3. URI (aka redirect URI)- found in Step 1.4</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">js</span>
<pre class="hidden">namespace AlertWebhookDemo
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
        private const string tenantId = &quot;your_azure_tenant_id&quot;;
        private const string clientId = &quot;enter_your_client_id&quot;;
        private const string subscriptionId = &quot;enter_your_azure_subscription_id&quot;;
        private const string URI = &quot;create_a_uri&quot;;
        private const string ServiceUrl = &quot;https://management.azure.com&quot;;
       
        [STAThread]
        static void Main(string[] args)
        {
            
            string authorizationToken = &quot;&quot;;

            CreateAlertRule(authorizationToken);

            Console.WriteLine(&quot;Press any key to continue...&quot;);
            Console.ReadKey();
        }

        private static string GetAuthorizationHeader()
        {
            try
            {
                //Establish context &amp; Acquire token 
                var context = new AuthenticationContext(&quot;https://login.windows.net/&quot; &#43; tenantId);

                Uri uri = new Uri(URI);
                AuthenticationResult result = context.AcquireToken(&quot;https://management.core.windows.net/&quot;, clientId, uri);
                if (result == null)
                {
                    throw new InvalidOperationException(&quot;Failed to obtain the token.&quot;);
                }

                return result.AccessToken;

            }
            catch (Exception e)
            {
                Console.WriteLine(&quot;Exception: &quot; &#43; e.InnerException);
                throw;
            }
        }
        private static void CreateAlertRule(string authorizationToken)
        {
            
            string token = GetAuthorizationHeader();
            TokenCloudCredentials credentials = new TokenCloudCredentials(subscriptionId, token);

            InsightsManagementClient client = new InsightsManagementClient(credentials, new Uri(ServiceUrl));

            RuleCreateOrUpdateParameters parameters = new RuleCreateOrUpdateParameters();

            List&lt;RuleAction&gt; actions = new List&lt;RuleAction&gt;();

            //The new RuleWebhookAction has two properties - the uri and a property bag, which can be key value pairs
            //Lets create some key-value pairs to be added as properties for this webhook

            Dictionary&lt;string, string&gt; properties = new Dictionary&lt;string, string&gt;();
            properties.Add(&quot;Hello1&quot;, &quot;World1!&quot;);
            properties.Add(&quot;json_stuff&quot;, &quot;{\&quot;type\&quot;:\&quot;critical\&quot;, \&quot;color\&quot;:\&quot;red\&quot;}'&quot;);
            properties.Add(&quot;customId&quot;, &quot;wd39ue9832ue9iuhd9iuewhd9edh&quot;);
            properties.Add(&quot;send_emails_to&quot;, &quot;someone@somewhere.com&quot;);


            // NOTE: you can add up to 5 webhooks for an alert programmatically 
            // if you configure multiple webhooks programmtically, you can only view/edit the 1st one via the Azure Portal UI 
            // We will add the ability to configure multiple webhooks via the portal soon
             
            
            // my runscope uri
            actions.Add(new RuleWebhookAction() { ServiceUri = &quot;your_runscope_uri&quot;, Properties = properties });

            //pager_duty uri
            actions.Add(new RuleWebhookAction() { ServiceUri = &quot;your_pagerduty_uri&quot;, Properties = properties });

            
            parameters.Properties = new Rule()
            {
                Name = &quot;Alert_webhook_demo1&quot;,
                Action = new RuleEmailAction()
                {
                    CustomEmails = new List&lt;string&gt;() { &quot;email@example.com&quot; }
                },

                IsEnabled = true,
                Actions = actions,
                Condition = new ThresholdRuleCondition()
                {
                    DataSource = new RuleMetricDataSource()
                    {
                        MetricName = &quot;\\Memory\\Available Bytes&quot;,
                        ResourceUri = &quot;your_resource_id&quot;
                    },
                    Operator = ConditionOperator.GreaterThan,
                    Threshold = 1.0,
                    TimeAggregation = TimeAggregationOperator.Average,
                    WindowSize = TimeSpan.FromMinutes(5),

                }
            };
            parameters.Location = &quot;location_for_your_alert_rule&quot;;  // e.g &quot;eastus&quot;
            var response = client.AlertOperations.CreateOrUpdateRule(&quot;your_resoureGroupeName&quot;, parameters);
            Console.WriteLine(&quot;Alert created with a webhook!&quot;);           
        }

    }
}</pre>
<pre class="hidden">//FOR REFERENCE: THIS IS THE ALERT's JSON PAYLOAD

{
&quot;status&quot;: &quot;Activated&quot;,
&quot;context&quot;: {
            &quot;timestamp&quot;: &quot;2015-08-14T22:26:41.9975398Z&quot;,
            &quot;id&quot;: &quot;/subscriptions/s1/resourceGroups/useast/providers/microsoft.insights/alertrules/ruleName1&quot;,
            &quot;name&quot;: &quot;ruleName1&quot;,
            &quot;description&quot;: &quot;some description&quot;,
            &quot;conditionType&quot;: &quot;Metric&quot;,
            &quot;condition&quot;: {
                        &quot;metricName&quot;: &quot;Requests&quot;,
                        &quot;metricUnit&quot;: &quot;Count&quot;,
                        &quot;metricValue&quot;: &quot;10&quot;,
                        &quot;threshold&quot;: &quot;10&quot;,
                        &quot;windowSize&quot;: &quot;15&quot;,
                        &quot;timeAggregation&quot;: &quot;Average&quot;,
                        &quot;operator&quot;: &quot;GreaterThanOrEqual&quot;
                },
            &quot;subscriptionId&quot;: &quot;s1&quot;,
            &quot;resourceGroupName&quot;: &quot;useast&quot;,                                
            &quot;resourceName&quot;: &quot;mysite1&quot;,
            &quot;resourceType&quot;: &quot;microsoft.foo/sites&quot;,
            &quot;resourceId&quot;: &quot;/subscriptions/s1/resourceGroups/useast/providers/microsoft.foo/sites/mysite1&quot;,
            &quot;resourceRegion&quot;: &quot;centralus&quot;,
            &quot;portalLink&quot;: &ldquo;https://portal.azure.com/#resource/subscriptions/s1/resourceGroups/useast/providers/microsoft.foo/sites/mysite1&rdquo;                                
},
&quot;properties&quot;: {
              &quot;Hello1&quot;: &quot;World1!&quot;,
              &quot;json_stuff&quot;: &quot;{\&quot;type\&quot;:\&quot;critical\&quot;, \&quot;color\&quot;:\&quot;red\&quot;}'&quot;,
              &quot;customId&quot;: &quot;wd39ue9832ue9iuhd9iuewhd9edh&quot;,
              &quot;send_emails_to&quot;: &quot;someone@somewhere.com&quot;
              }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;AlertWebhookDemo&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Globalization;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Net.Http;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Runtime.Serialization.Formatters;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Threading;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.IdentityModel.Clients.ActiveDirectory;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json.Converters;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json.Linq;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Newtonsoft.Json.Serialization;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Azure.Management.Insights;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Azure.Management.Insights.Models;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Azure.Insights;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Azure.Insights.Models;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Xml;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;System.Net.Http.Headers;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Azure;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;Microsoft.Azure.Common.OData;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;tenantId&nbsp;=&nbsp;<span class="cs__string">&quot;your_azure_tenant_id&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;clientId&nbsp;=&nbsp;<span class="cs__string">&quot;enter_your_client_id&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;subscriptionId&nbsp;=&nbsp;<span class="cs__string">&quot;enter_your_azure_subscription_id&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;URI&nbsp;=&nbsp;<span class="cs__string">&quot;create_a_uri&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ServiceUrl&nbsp;=&nbsp;<span class="cs__string">&quot;https://management.azure.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[STAThread]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;authorizationToken&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateAlertRule(authorizationToken);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Press&nbsp;any&nbsp;key&nbsp;to&nbsp;continue...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetAuthorizationHeader()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Establish&nbsp;context&nbsp;&amp;&nbsp;Acquire&nbsp;token&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;AuthenticationContext(<span class="cs__string">&quot;https://login.windows.net/&quot;</span>&nbsp;&#43;&nbsp;tenantId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;uri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(URI);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AuthenticationResult&nbsp;result&nbsp;=&nbsp;context.AcquireToken(<span class="cs__string">&quot;https://management.core.windows.net/&quot;</span>,&nbsp;clientId,&nbsp;uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;InvalidOperationException(<span class="cs__string">&quot;Failed&nbsp;to&nbsp;obtain&nbsp;the&nbsp;token.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result.AccessToken;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Exception:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;e.InnerException);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateAlertRule(<span class="cs__keyword">string</span>&nbsp;authorizationToken)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;token&nbsp;=&nbsp;GetAuthorizationHeader();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TokenCloudCredentials&nbsp;credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TokenCloudCredentials(subscriptionId,&nbsp;token);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InsightsManagementClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;InsightsManagementClient(credentials,&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(ServiceUrl));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RuleCreateOrUpdateParameters&nbsp;parameters&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RuleCreateOrUpdateParameters();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;RuleAction&gt;&nbsp;actions&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;RuleAction&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;new&nbsp;RuleWebhookAction&nbsp;has&nbsp;two&nbsp;properties&nbsp;-&nbsp;the&nbsp;uri&nbsp;and&nbsp;a&nbsp;property&nbsp;bag,&nbsp;which&nbsp;can&nbsp;be&nbsp;key&nbsp;value&nbsp;pairs</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Lets&nbsp;create&nbsp;some&nbsp;key-value&nbsp;pairs&nbsp;to&nbsp;be&nbsp;added&nbsp;as&nbsp;properties&nbsp;for&nbsp;this&nbsp;webhook</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;&nbsp;properties&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Dictionary&lt;<span class="cs__keyword">string</span>,&nbsp;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;properties.Add(<span class="cs__string">&quot;Hello1&quot;</span>,&nbsp;<span class="cs__string">&quot;World1!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;properties.Add(<span class="cs__string">&quot;json_stuff&quot;</span>,&nbsp;<span class="cs__string">&quot;{\&quot;type\&quot;:\&quot;critical\&quot;,&nbsp;\&quot;color\&quot;:\&quot;red\&quot;}'&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;properties.Add(<span class="cs__string">&quot;customId&quot;</span>,&nbsp;<span class="cs__string">&quot;wd39ue9832ue9iuhd9iuewhd9edh&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;properties.Add(<span class="cs__string">&quot;send_emails_to&quot;</span>,&nbsp;<span class="cs__string">&quot;someone@somewhere.com&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;NOTE:&nbsp;you&nbsp;can&nbsp;add&nbsp;up&nbsp;to&nbsp;5&nbsp;webhooks&nbsp;for&nbsp;an&nbsp;alert&nbsp;programmatically&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;if&nbsp;you&nbsp;configure&nbsp;multiple&nbsp;webhooks&nbsp;programmtically,&nbsp;you&nbsp;can&nbsp;only&nbsp;view/edit&nbsp;the&nbsp;1st&nbsp;one&nbsp;via&nbsp;the&nbsp;Azure&nbsp;Portal&nbsp;UI&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;We&nbsp;will&nbsp;add&nbsp;the&nbsp;ability&nbsp;to&nbsp;configure&nbsp;multiple&nbsp;webhooks&nbsp;via&nbsp;the&nbsp;portal&nbsp;soon</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;my&nbsp;runscope&nbsp;uri</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;actions.Add(<span class="cs__keyword">new</span>&nbsp;RuleWebhookAction()&nbsp;{&nbsp;ServiceUri&nbsp;=&nbsp;<span class="cs__string">&quot;your_runscope_uri&quot;</span>,&nbsp;Properties&nbsp;=&nbsp;properties&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//pager_duty&nbsp;uri</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;actions.Add(<span class="cs__keyword">new</span>&nbsp;RuleWebhookAction()&nbsp;{&nbsp;ServiceUri&nbsp;=&nbsp;<span class="cs__string">&quot;your_pagerduty_uri&quot;</span>,&nbsp;Properties&nbsp;=&nbsp;properties&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parameters.Properties&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Rule()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Alert_webhook_demo1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Action&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RuleEmailAction()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomEmails&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;()&nbsp;{&nbsp;<span class="cs__string">&quot;email@example.com&quot;</span>&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsEnabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Actions&nbsp;=&nbsp;actions,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Condition&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ThresholdRuleCondition()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSource&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RuleMetricDataSource()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MetricName&nbsp;=&nbsp;<span class="cs__string">&quot;\\Memory\\Available&nbsp;Bytes&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResourceUri&nbsp;=&nbsp;<span class="cs__string">&quot;your_resource_id&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Operator&nbsp;=&nbsp;ConditionOperator.GreaterThan,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Threshold&nbsp;=&nbsp;<span class="cs__number">1.0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TimeAggregation&nbsp;=&nbsp;TimeAggregationOperator.Average,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WindowSize&nbsp;=&nbsp;TimeSpan.FromMinutes(<span class="cs__number">5</span>),&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parameters.Location&nbsp;=&nbsp;<span class="cs__string">&quot;location_for_your_alert_rule&quot;</span>;&nbsp;&nbsp;<span class="cs__com">//&nbsp;e.g&nbsp;&quot;eastus&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;client.AlertOperations.CreateOrUpdateRule(<span class="cs__string">&quot;your_resoureGroupeName&quot;</span>,&nbsp;parameters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Alert&nbsp;created&nbsp;with&nbsp;a&nbsp;webhook!&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><em>&nbsp;</em></h1>
