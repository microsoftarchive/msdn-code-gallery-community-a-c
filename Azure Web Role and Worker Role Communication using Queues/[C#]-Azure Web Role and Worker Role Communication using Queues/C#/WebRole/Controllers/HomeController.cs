using System;
using System.Web.Mvc;

using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Queue; // Namespace for Queue storage types
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public string GetMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("mytable");

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            // read the latest messages from the table            
            TableOperation retrieveOperation = TableOperation.Retrieve<MyMessages>("Partition0", "Row0");

            // Execute the retrieve operation.
            TableResult retrievedResult = table.Execute(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                return ((MyMessages)retrievedResult.Result).Messages;
            }
            else
                return "Failed to retrieve the messages";
        }

        public void ClearMessages()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]");
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("mytable");

            // Create the table if it doesn't exist.
            table.CreateIfNotExists();

            // read the latest messages from the table            
            TableOperation retrieveOperation = TableOperation.Retrieve<MyMessages>("Partition0", "Row0");

            // Execute the retrieve operation.
            TableResult retrievedResult = table.Execute(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                TableOperation deleteOperation = TableOperation.Delete((MyMessages)retrievedResult.Result);

                table.Execute(deleteOperation);
            }
        }

        public void SendMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]");
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("myqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            // send a message to the queue
            CloudQueueMessage message = new CloudQueueMessage(string.Format("Sending at {0} from {1}", DateTime.Now, RoleEnvironment.CurrentRoleInstance));
            queue.AddMessage(message);
        }
    }

    public class MyMessages : TableEntity
    {
        public DateTime LastUpdated { get; set; }
        public string Messages { get; set; }
    }
}