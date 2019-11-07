using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Threading.Tasks;
using OrdersAPI.Models;
using OrdersAPI.Dal;


namespace OrdersAPI.Dal
{


    public class OrderManager
    {
        private static DocumentClient client;

        //Assign a name for your database & collection 
        private static readonly string databaseId = ConfigurationManager.AppSettings["DatabaseId"];
        private static readonly string collectionId = ConfigurationManager.AppSettings["CollectionId"];

        //Read the DocumentDB endpointUrl and authorisationKeys from config
        //These values are available from the Azure Management Portal on the DocumentDB Account Blade under "Keys"
        //NB > Keep these values in a safe & secure location. Together they provide Administrative access to your DocDB account
        private static readonly string endpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private static readonly string authorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];


        #region GetOrderById
        public ServerOrder GetOrderById(string id)
        {
            ServerOrder order = null;

            //Get a Document client
            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                string pathLink = string.Format("dbs/{0}/colls/{1}", databaseId, collectionId);

                dynamic doc = client.CreateDocumentQuery<Document>(pathLink).Where(d => d.Id == id).AsEnumerable().FirstOrDefault();

                if (doc != null)
                {
                    order = doc;
                }
            }

            return order;
        }
        #endregion

        #region CreateOrder
        public async Task<string> CreateOrder(ClientOrder order)
        {
            string id = null;

            //Create a server order with extra properties
            ServerOrder s = new ServerOrder();

            s.customer = order.customer;
            s.item = order.item;

            //Add meta data to the order
            s.OrderStatus = "in progress";
            s.CreationDate = DateTime.UtcNow;

            //Get a Document client
            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                string pathLink = string.Format("dbs/{0}/colls/{1}", databaseId, collectionId);
                
                ResourceResponse<Document> doc = await client.CreateDocumentAsync(pathLink, s);

                //Return the created id
                id = doc.Resource.Id;
            }

            return id;
        }
        #endregion

        #region DeleteOrderById
        public async Task<string> DeleteOrderById(string id)
        {

            string result = null;

            //Get a Document client
            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                var docLink = string.Format("dbs/{0}/colls/{1}/docs/{2}", databaseId, collectionId, id);

                // Delete document using an Uri.  
                var x = await client.DeleteDocumentAsync(docLink);

                if (x != null)
                {
                                                        
                    result = x.StatusCode.ToString();
                }                
            }            

            return result;
        }
        #endregion

        #region UpdateOrderById
        public async Task<string> UpdateOrderById(string id, ClientOrder order)
        {

            string result = null;

            //Get a Document client
            using (client = new DocumentClient(new Uri(endpointUrl), authorizationKey))
            {

                string pathLink = string.Format("dbs/{0}/colls/{1}", databaseId, collectionId);

                dynamic doc = client.CreateDocumentQuery<Document>(pathLink).Where(d => d.Id == id).AsEnumerable().FirstOrDefault();

                if (doc != null)
                {
                    ServerOrder s = doc;
                    s.customer = order.customer;
                    s.item = order.item;
                    s.ModifiedDate = DateTime.UtcNow;

                    //Update document using self link.  
                    ResourceResponse<Document> x = await client.ReplaceDocumentAsync(doc.SelfLink, s);

                    result = x.StatusCode.ToString();
                }                
            }

            return result;
        }
        #endregion
    }
}