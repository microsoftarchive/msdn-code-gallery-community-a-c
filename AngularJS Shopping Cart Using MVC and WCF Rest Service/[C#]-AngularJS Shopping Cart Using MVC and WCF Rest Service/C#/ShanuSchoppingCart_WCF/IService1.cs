using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ShanuSchoppingCart_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
   

        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebInvoke(Method = "GET",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/GetItemDetails/")]
            List<shoppingCartDataContract.itemDetailsDataContract> GetItemDetails();
            // TODO: Add your service operations here

       

            // to Insert the Item Master
            [OperationContract]
            [WebInvoke(Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/addItemMaster")]
            bool addItemMaster(shoppingCartDataContract.itemDetailsDataContract itemDetails);


        }

        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        public class shoppingCartDataContract
        {


            [DataContract]
            public class itemDetailsDataContract
            {
                [DataMember]
                public string Item_ID { get; set; }

                [DataMember]
                public string Item_Name { get; set; }

                [DataMember]
                public string Description { get; set; }

                [DataMember]
                public string Item_Price { get; set; }

                [DataMember]
                public string Image_Name { get; set; }


                [DataMember]
                public string AddedBy { get; set; }
            }

        }
    }

