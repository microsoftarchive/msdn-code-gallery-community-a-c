using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using MvcWebRole.Models;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace AzureEmailServiceControllers
{
    public class MessageController : Controller
    {
        private static CloudBlobContainer blobContainer;
        private CloudTable mailingListTable;
        private CloudTable messageTable;
        private TableRequestOptions webUIRetryPolicy;

        public MessageController()
        {
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            // If this is running in a Windows Azure Web Site (not a Cloud Service) use the Web.config file:
            //    var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            // Get context object for working with tables and a reference to the blob container.
            var tableClient = storageAccount.CreateCloudTableClient();
            mailingListTable = tableClient.GetTableReference("mailinglist");
            messageTable = tableClient.GetTableReference("message");
            var blobClient = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClient.GetContainerReference("azuremailblobcontainer");

            webUIRetryPolicy = new TableRequestOptions()
            {
                MaximumExecutionTime = TimeSpan.FromSeconds(1.5),
                RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3)
            };
        }

        private Message FindRow(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<Message>(partitionKey, rowKey);
            var retrievedResult = messageTable.Execute(retrieveOperation);
            var message = retrievedResult.Result as Message;
            if (message == null)
            {
                throw new Exception("No message found for: " + partitionKey + ' ' + rowKey);
            }
            return message;
        }

        private async Task<Message> FindRowAsync(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<Message>(partitionKey, rowKey);
            var retrievedResult = await messageTable.ExecuteAsync(retrieveOperation);
            var message = retrievedResult.Result as Message;
            if (message == null)
            {
                throw new Exception("No message found for: " + partitionKey + ' ' + rowKey);
            }
            return message;
        }


        private async Task<List<MailingList>> GetListNamesAsync()
        {
            List<MailingList> lists = new List<MailingList>();
            var query = (new TableQuery<MailingList>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "mailinglist")));
            TableContinuationToken token = null;
            OperationContext ctx = new OperationContext();
            TableQuerySegment<MailingList> currentSegment = null;
            while (currentSegment == null || currentSegment.ContinuationToken != null)
            {
                currentSegment = await mailingListTable.ExecuteQuerySegmentedAsync(query, token, webUIRetryPolicy, ctx);
                lists.AddRange(currentSegment.Results);
                token = currentSegment.ContinuationToken;
            }
            return lists;
        }

        //
        // GET: /Message/

        public async Task<ActionResult> Index()
        {
            List<Message> messages = new List<Message>();
            TableRequestOptions reqOptions = new TableRequestOptions()
            {
                MaximumExecutionTime = TimeSpan.FromSeconds(1.5),
                RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3)
            };
            var query = (new TableQuery<Message>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThan, "message")));
            TableContinuationToken token = null;
            OperationContext ctx = new OperationContext() { ClientRequestID = "" };
            TableQuerySegment<Message> currentSegment = null;
            while (currentSegment == null || currentSegment.ContinuationToken != null)
            {
                currentSegment = await messageTable.ExecuteQuerySegmentedAsync(query, token, reqOptions, ctx);
                messages.AddRange(currentSegment.Results);
                token = currentSegment.ContinuationToken;
            }
            return View(messages);
        }

        //
        // GET: /Message/Details/5

        public async Task<ActionResult> Details(string partitionKey, string rowKey)
        {
            var message = await FindRowAsync(partitionKey, rowKey);
            return View(message);
        }

        //
        // GET: /Message/Create

        public async Task<ActionResult> Create()
        {
            var lists = await GetListNamesAsync();
            ViewBag.ListName = new SelectList(lists, "ListName", "Description");

            var message = new Message()
            {
                ScheduledDate = DateTime.Today.AddDays(7)
            };
            return View(message);
        }

        private async Task SaveBlobAsync(string blobName, HttpPostedFileBase httpPostedFile)
        {
            // Retrieve reference to a blob.
            var blob = blobContainer.GetBlockBlobReference(blobName);
            // Create the blob or overwrite the existing blob by uploading a local file.
            using (var fileStream = httpPostedFile.InputStream)
            {
                await blob.UploadFromStreamAsync(fileStream);
            }
        }

        //
        // POST: /Message/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Message message, HttpPostedFileBase file, HttpPostedFileBase txtFile)
        {
            if (file == null)
            {
                ModelState.AddModelError(string.Empty, "Please provide an HTML file path");
            }

            if (txtFile == null)
            {
                ModelState.AddModelError(string.Empty, "Please provide a Text file path");
            }

            if (ModelState.IsValid)
            {
                await SaveBlobAsync(message.MessageRef + ".htm", file);
                await SaveBlobAsync(message.MessageRef + ".txt", txtFile);

                var insertOperation = TableOperation.Insert(message);
                await messageTable.ExecuteAsync(insertOperation);

                return RedirectToAction("Index");
            }

            var lists = await GetListNamesAsync();
            ViewBag.ListName = new SelectList(lists, "ListName", "Description");
            return View(message);
        }

        //
        // GET: /Message/Edit/5

        public async Task<ActionResult> Edit(string partitionKey, string rowKey)
        {
            var message = await FindRowAsync(partitionKey, rowKey);
            if (message.Status != "Pending")
            {
                throw new Exception("Message can't be edited because it isn't in Pending status.");
            }

            var lists = await GetListNamesAsync();
            ViewBag.ListName = new SelectList(lists, "ListName", "Description", message.ListName);
            return View(message);
        }

        //
        // POST: /Message/Edit/5

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> Edit(string partitionKey, string rowKey, Message editedMsg,
    DateTime scheduledDate, HttpPostedFileBase httpFile, HttpPostedFileBase txtFile)
{
    if (ModelState.IsValid)
    {
        var excludePropLst = new List<string>();
        excludePropLst.Add("PartitionKey");
        excludePropLst.Add("RowKey");

        if (httpFile == null)
        {
            // They didn't enter a path or navigate to a file, so don't update the file.
            excludePropLst.Add("HtmlPath");
        }
        else
        {
            // They DID enter a path or navigate to a file, assume it's changed.
            await SaveBlobAsync(editedMsg.MessageRef + ".htm", httpFile);
        }

        if (txtFile == null)
        {
            excludePropLst.Add("TextPath");
        }
        else
        {
            await SaveBlobAsync(editedMsg.MessageRef + ".txt", txtFile);
        }

        string[] excludeProperties = excludePropLst.ToArray();

        try
        {
            UpdateModel(editedMsg, string.Empty, null, excludeProperties);
            if (editedMsg.PartitionKey == partitionKey)
            {
                // Keys didn't change -- update the row.
                var replaceOperation = TableOperation.Replace(editedMsg);
                await messageTable.ExecuteAsync(replaceOperation);
            }
            else
            {
                // Partition key changed -- delete and insert the row.
                // (Partition key has scheduled date which may be changed;
                // row key has MessageRef which does not change.)
                var deleteOperation = TableOperation.Delete(new Message { PartitionKey = partitionKey, RowKey = rowKey, ETag = editedMsg.ETag });
                await messageTable.ExecuteAsync(deleteOperation);
                var insertOperation = TableOperation.Insert(editedMsg);
                await messageTable.ExecuteAsync(insertOperation);
            }
            return RedirectToAction("Index");
        }
        catch (StorageException ex)
        {
            if (ex.RequestInformation.HttpStatusCode == 412)
            {
                // Concurrency error
                var currentMsg = FindRow(partitionKey, rowKey);
                if (currentMsg.Status != "Pending")
                {
                    throw new Exception("Message can't be edited because it isn't in Pending status.");
                }
                if (currentMsg.ListName != editedMsg.ListName)
                {
                    ModelState.AddModelError("ListName", "Current value: " + currentMsg.ListName);
                }
                if (currentMsg.SubjectLine != editedMsg.SubjectLine)
                {
                    ModelState.AddModelError("SubjectLine", "Current value: " + currentMsg.SubjectLine);
                }
                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                    + "was modified by another user after you got the original value. The "
                    + "edit operation was canceled and the current values in the database "
                    + "have been displayed. If you still want to edit this record, click "
                    + "the Save button again. Otherwise click the Back to List hyperlink.");
                ModelState.SetModelValue("ETag", new ValueProviderResult(currentMsg.ETag, currentMsg.ETag, null));
            }
            else
            {
                throw;
            }
        }
    }

    var lists = await GetListNamesAsync();
    ViewBag.ListName = new SelectList(lists, "ListName", "Description", editedMsg.ListName);

    return View(editedMsg);
}

        //
        // GET: /Message/Delete/5

        public async Task<ActionResult> Delete(string partitionKey, string rowKey)
        {
            var message = await FindRowAsync(partitionKey, rowKey);
            if (message.Status != "Pending")
            {
                throw new Exception("Message can't be deleted because it isn't in Pending status.");
            }

            return View(message);
        }

        //
        // POST: /Message/Delete/5

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(String partitionKey, string rowKey)
        {
            // Get the row again to make sure it's still in Pending status.
            var message = await FindRowAsync(partitionKey, rowKey);
            if (message.Status != "Pending")
            {
                throw new Exception("Message can't be deleted because it isn't in Pending status.");
            }

            await DeleteBlobAsync(message.MessageRef + ".htm");
            await DeleteBlobAsync(message.MessageRef + ".txt");
            var deleteOperation = TableOperation.Delete(message);
            messageTable.Execute(deleteOperation);
            return RedirectToAction("Index");
        }

        private async Task DeleteBlobAsync(string blobName)
        {
            var blob = blobContainer.GetBlockBlobReference(blobName);
            await blob.DeleteAsync();
        }
    }
}