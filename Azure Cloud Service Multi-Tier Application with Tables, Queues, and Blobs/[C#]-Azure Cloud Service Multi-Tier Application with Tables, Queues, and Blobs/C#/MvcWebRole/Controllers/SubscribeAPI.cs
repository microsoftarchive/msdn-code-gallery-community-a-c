using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using MvcWebRole.Models;
using System.Threading.Tasks;

namespace MvcWebRole.Controllers
{
    public class SubscribeAPIController : System.Web.Http.ApiController
    {
        private CloudQueue subscribeQueue;
        private CloudTable mailingListTable;

        public SubscribeAPIController()
        {
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            // If this is running in a Windows Azure Web Site (not a Cloud Service) use the Web.config file:
            //  var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            // Get table and queue objects for working with tables and queues.
            var tableClient = storageAccount.CreateCloudTableClient();
            mailingListTable = tableClient.GetTableReference("mailinglist");
            var queueClient = storageAccount.CreateCloudQueueClient();
            subscribeQueue = queueClient.GetQueueReference("azuremailsubscribequeue");
        }

        // Use this URL format to test
        // http://127.0.0.1:81/api/SubscribeAPI?emailAddress=student1@contoso.edu&listName=contoso1
        //

        public async Task<HttpResponseMessage> GetSubscribeToList(string emailAddress, string listName)
        {
            var newSubscriber = new Subscriber()
            {
                EmailAddress = emailAddress,
                ListName = listName,
                Verified = false,
                SubscriberGUID = Guid.NewGuid().ToString()
            };

            // If the list doesn't exist, send an error response.
            if (await IsListAsync(listName) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No such list " + listName);
            }

            // Handle the special case of user currently subscribed
            var subscriber = await GetSubscribedUserAsync(listName, emailAddress);
            if (subscriber != null)
            {
                return await HandleSubscribedUserAsync(subscriber);
            }

            var insertOperation = TableOperation.Insert(newSubscriber);
            mailingListTable.Execute(insertOperation);

            // Create a queue message which will send a subscribe confirmation email.
            await CreateQueueMessageAsync(newSubscriber);

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }

        private async Task CreateQueueMessageAsync(Subscriber newSubscriber)
        {
            await subscribeQueue.AddMessageAsync(new CloudQueueMessage(newSubscriber.SubscriberGUID + "," + newSubscriber.ListName));
        }

        private async Task<bool> IsListAsync(string listName)
        {
            var retrieveOperation = TableOperation.Retrieve<MailingList>(listName, "mailinglist");
            var retrievedResult = await mailingListTable.ExecuteAsync(retrieveOperation);
            var list = retrievedResult.Result as MailingList;
            if (list == null)
            {
                return false;
            }
            return true;
        }

        private async Task<Subscriber> GetSubscribedUserAsync(string listName, string emailAddress)
        {
            var retrieveOperation = TableOperation.Retrieve<Subscriber>(listName, emailAddress);
            var retrievedResult = await mailingListTable.ExecuteAsync(retrieveOperation);
            return retrievedResult.Result as Subscriber;
        }

        private async Task<HttpResponseMessage> HandleSubscribedUserAsync(Subscriber subscriber)
        {
            // If the user is Verified, send an error response.
            if (subscriber.Verified == true)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    subscriber.EmailAddress + " Currently subscribed to: " + subscriber.ListName);
            }
            else
            {
                // The user is currently subscribed to the list but not Verified
                // they might have lost the previous confirm subscribe email and be requesting
                // another confirmation email.

                // Send a queue message which will send a subscribe confirmation email.
                await CreateQueueMessageAsync(subscriber);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
        }
    }
}
