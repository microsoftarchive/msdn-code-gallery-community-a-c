using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using System.IO;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Queue;
using System.Text;

namespace WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("WorkerRole is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("WorkerRole has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            try
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=[name];AccountKey=[key]");
                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
                CloudQueue queue = queueClient.GetQueueReference("myqueue");
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference("mytable");

                // Create the queue if it doesn't already exist
                queue.CreateIfNotExists();

                // Create the table if it doesn't exist.
                table.CreateIfNotExists();

                // TODO: Replace the following with your own logic.
                while (!cancellationToken.IsCancellationRequested)
                {
                    // Get the next message
                    CloudQueueMessage retrievedMessage = queue.GetMessage();

                    if (retrievedMessage != null)
                    {
                        var messages = new StringBuilder("Worker received: " + retrievedMessage.AsString);
                        messages.AppendLine();

                        // read the latest messages from the table            
                        TableOperation retrieveOperation = TableOperation.Retrieve<MyMessages>("Partition0", "Row0");

                        // Execute the retrieve operation.
                        TableResult retrievedResult = table.Execute(retrieveOperation);

                        MyMessages myMessages = retrievedResult.Result == null
                                              ? new MyMessages { PartitionKey = "Partition0", RowKey = "Row0", LastUpdated = DateTime.Now }
                                              : (MyMessages)retrievedResult.Result;


                        messages.AppendLine(myMessages.Messages);

                        var filename = RoleEnvironment.IsEmulated
                                     ? @"c:\windows\system32\cmd.exe"
                                     : @"d:\windows\system32\cmd.exe";

                        var processStartInfo = new ProcessStartInfo()
                        {
                            Arguments = "/c echo \"test message from a process on the worker vm\"",
                            FileName = filename,
                            RedirectStandardOutput = true,
                            UseShellExecute = false
                        };

                        var process = Process.Start(processStartInfo);

                        using (var streamReader = new StreamReader(process.StandardOutput.BaseStream))
                        {
                            messages.AppendLine(streamReader.ReadToEnd() + " at " + DateTime.Now.ToString() + " on " + RoleEnvironment.CurrentRoleInstance);
                        }

                        // replace the messages
                        myMessages.Messages = messages.ToString();
                        myMessages.LastUpdated = DateTime.Now;

                        // Create the Replace TableOperation.
                        TableOperation replaceOperation = TableOperation.InsertOrReplace(myMessages);

                        // Execute the operation.
                        var result = table.Execute(replaceOperation);

                        //Process the message in less than 30 seconds, and then delete the message
                        queue.DeleteMessage(retrievedMessage);


                        Trace.TraceInformation("Updated myMessage");
                    }

                    Trace.TraceInformation("Working");
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Worker failed with " + ex.Message);
            }
        }
        public class MyMessages : TableEntity
        {
            public DateTime LastUpdated { get; set; }
            public string Messages { get; set; }
        }
    }
}

