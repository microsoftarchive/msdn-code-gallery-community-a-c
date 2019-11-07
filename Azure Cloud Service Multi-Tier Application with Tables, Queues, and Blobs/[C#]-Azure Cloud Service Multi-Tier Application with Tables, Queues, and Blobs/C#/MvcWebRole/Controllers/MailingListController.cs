using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Microsoft.WindowsAzure.Storage.Table;
using MvcWebRole.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AzureEmailServiceControllers
{
    public class MailingListController : Controller
    {
        private CloudTable mailingListTable;
        private TableRequestOptions webUIRetryPolicy;

        public MailingListController()
        {
            var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(RoleEnvironment.GetConfigurationSettingValue("StorageConnectionString"));
            // If this is running in an Azure Web Site (not a Cloud Service) use the Web.config file:
            //    var storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            var tableClient = storageAccount.CreateCloudTableClient();
            mailingListTable = tableClient.GetTableReference("mailinglist");

            webUIRetryPolicy = new TableRequestOptions()
            {
                MaximumExecutionTime = TimeSpan.FromSeconds(1.5),
                RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(3), 3)
            };
        }

        private async Task<MailingList> FindRowAsync(string partitionKey, string rowKey)
        {
            var retrieveOperation = TableOperation.Retrieve<MailingList>(partitionKey, rowKey);
            var retrievedResult = await mailingListTable.ExecuteAsync(retrieveOperation);
            var mailingList = retrievedResult.Result as MailingList;
            if (mailingList == null)
            {
                throw new Exception("No mailing list found for: " + partitionKey);
            }

            return mailingList;
        }

        //
        // GET: /MailingList/
        public async Task<ActionResult> Index()
        {
            List<MailingList> lists = new List<MailingList>();
            try
            {
                // This code gets all rows; for a production app implement paging
                // to avoid executing an unbounded query that might return too many rows.
                var query = new TableQuery<MailingList>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "mailinglist"));
                TableContinuationToken token = null;
                OperationContext ctx = new OperationContext();
                TableQuerySegment<MailingList> currentSegment = null;
                while (currentSegment == null || currentSegment.ContinuationToken != null)
                {
                    currentSegment = await mailingListTable.ExecuteQuerySegmentedAsync(query, token, webUIRetryPolicy, ctx);
                    lists.AddRange(currentSegment.Results);
                    token = currentSegment.ContinuationToken;
                }
            }
            catch (StorageException se)
            {
                ViewBag.errorMessage = "Timeout error, try again. ";
                Trace.TraceError(se.Message);
                return View("Error");
            }

            return View(lists);
        }

        //
        // GET: /MailingList/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MailingList/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MailingList mailingList)
        {
            if (ModelState.IsValid)
            {
                var insertOperation = TableOperation.Insert(mailingList);
                await mailingListTable.ExecuteAsync(insertOperation);
                return RedirectToAction("Index");
            }

            return View(mailingList);
        }

        //
        // GET: /MailingList/Edit/5

        public async Task<ActionResult> Edit(string partitionKey, string rowKey)
        {

            var mailingList = await FindRowAsync(partitionKey, rowKey);
            return View(mailingList);
        }

        //
        // POST: /MailingList/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string partitionKey, string rowKey, MailingList editedMailingList)
        {
            if (ModelState.IsValid)
            {
                var mailingList = new MailingList();
                UpdateModel(mailingList);
                try
                {
                    var replaceOperation = TableOperation.Replace(mailingList);
                    await mailingListTable.ExecuteAsync(replaceOperation);
                    return RedirectToAction("Index");
                }
                catch (StorageException ex)
                {
                    if (ex.RequestInformation.HttpStatusCode == 412)
                    {
                        // Concurrency error
                        var retrieveOperation = TableOperation.Retrieve<MailingList>(partitionKey, rowKey);
                        var retrievedResult = mailingListTable.Execute(retrieveOperation);
                        var currentMailingList = retrievedResult.Result as MailingList;
                        if (currentMailingList == null)
                        {
                            ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was deleted by another user after you got the original value. The "
                                + "edit operation was canceled. Click the Back to List hyperlink.");
                        }
                        if (currentMailingList.FromEmailAddress != editedMailingList.FromEmailAddress)
                        {
                            ModelState.AddModelError("FromEmailAddress", "Current value: " + currentMailingList.FromEmailAddress);
                        }
                        if (currentMailingList.Description != editedMailingList.Description)
                        {
                            ModelState.AddModelError("Description", "Current value: " + currentMailingList.Description);
                        }
                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                            + "was modified by another user after you got the original value. The "
                            + "edit operation was canceled and the current values in the database "
                            + "have been displayed. If you still want to edit this record, click "
                            + "the Save button again. Otherwise click the Back to List hyperlink.");
                        ModelState.SetModelValue("ETag", new ValueProviderResult(currentMailingList.ETag, currentMailingList.ETag, null));
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(editedMailingList);
        }

        //
        // GET: /MailingList/Delete/5

        public async Task<ActionResult> Delete(string partitionKey, string rowKey)
        {
            var mailingList = await FindRowAsync(partitionKey, rowKey);
            return View(mailingList);
        }

        //
        // POST: /MailingList/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string partitionKey)
        {
            // Delete all rows for this mailing list, that is, 
            // Subscriber rows as well as MailingList rows.
            // Therefore, no need to specify row key.

            // Get all rows for this mailing list. For a production app where this 
            // could return too many split the work up into segments.
            var query = new TableQuery<MailingList>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            TableContinuationToken token = null;
            OperationContext ctx = new OperationContext();
            TableQuerySegment<MailingList> currentSegment = null;
            List<MailingList> listRows = new List<MailingList>();
            while (currentSegment == null || currentSegment.ContinuationToken != null)
            {
                currentSegment = await mailingListTable.ExecuteQuerySegmentedAsync(query, token, webUIRetryPolicy, ctx);
                listRows.AddRange(currentSegment.Results);
                token = currentSegment.ContinuationToken;
            }

            // Delete the rows in batches of 100.
            var batchOperation = new TableBatchOperation();
            int itemsInBatch = 0;
            foreach (MailingList listRow in listRows)
            {
                batchOperation.Delete(listRow);
                itemsInBatch++;
                if (itemsInBatch == 100)
                {
                    await mailingListTable.ExecuteBatchAsync(batchOperation);
                    itemsInBatch = 0;
                    batchOperation = new TableBatchOperation();
                }
            }
            if (itemsInBatch > 0)
            {
                await mailingListTable.ExecuteBatchAsync(batchOperation);
            }
            return RedirectToAction("Index");
        }
    }
}