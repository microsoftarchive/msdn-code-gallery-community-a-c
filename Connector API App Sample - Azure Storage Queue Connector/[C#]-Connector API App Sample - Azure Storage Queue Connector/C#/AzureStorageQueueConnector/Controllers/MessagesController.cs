using Microsoft.Azure.AppService.ApiApps.Service;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AzureStorageQueueConnector.Controllers
{
    /// <summary>
    /// Controller to handle messages
    /// </summary>
    public class MessagesController : ApiController
    {
        private CloudQueueClient QueueClient;

        public MessagesController()
        {
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["StorageConnectionString"];
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            this.QueueClient = storageAccount.CreateCloudQueueClient();
        }

        #region Actions

        /// <summary>
        /// Get Message
        /// </summary>
        /// <description>
        /// Read messages from the Queue.  Messages read will be marked invisible but are not deleted.
        /// Once processed, they will need to be explicitly deleted.
        /// </description>
        /// <param name="queueName">The name of the Storage Queue</param>
        public CloudQueueMessage GetMessage(string queueName)
        {
            CloudQueue queue = this.QueueClient.GetQueueReference(queueName);
            CloudQueueMessage message = queue.GetMessage();
            return message;
        }
 
        /// <summary>
        /// Delete Message
        /// </summary>
        /// <param name="queueName">The name of the Storage Queue</param>
        /// <param name="messageId">ID of the Message to be deleted</param>
        /// <param name="popReceipt">The PopReceipt value received while reading the message</param>
        public void DeleteMessage(string queueName, string messageId, string popReceipt)
        {
            CloudQueue queue = this.QueueClient.GetQueueReference(queueName);
            queue.DeleteMessage(messageId, popReceipt);
        }

        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="queueName">The name of the Storage Queue</param>
        /// <param name="messageText">The message text to be sent</param>
        public void SendMessage(string queueName, string messageText)
        {
            CloudQueue queue = this.QueueClient.GetQueueReference(queueName);

            CloudQueueMessage message = new CloudQueueMessage(messageText);
            queue.AddMessage(message);
        }

        #endregion

        #region Triggers

        /// <summary>
        /// Message Available
        /// </summary>
        /// <param name="triggerState">Specifies the state of the last trigger invocation</param>
        /// <param name="queueName">The name of the Storage Queue</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Messages/poll")]
        [ResponseType(typeof(CloudQueueMessage))]
        public HttpResponseMessage NewMessageTrigger(string triggerState, string queueName)
        {   
            // if there is a triggerState, we will use that to complete/delete the previous message
            if ( !string.IsNullOrEmpty(triggerState))
            {
                var triggerVariables = triggerState.Split(new char[] {';'}, 2);
                var messageId = triggerVariables[0];
                var popReceipt = triggerVariables[1];
                this.DeleteMessage(queueName, messageId, popReceipt);
            }

            var message = this.GetMessage(queueName);
            if (message == null)
            {
                // no message -- tell to wait for the next polling interval
                return Request.EventWaitPoll();
            }

            // we have a message:
            // (1) construct the new triggerState
            // (2) send the new message back
            // (3) tell to poll immediately again since we may have more message
            string newTriggerState = message.Id + ';' + message.PopReceipt;
            return Request.EventTriggered(message, triggerState: newTriggerState, pollAgain: TimeSpan.Zero);
        }

        #endregion

    }
}
