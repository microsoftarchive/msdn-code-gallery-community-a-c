using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ShanuSchoppingCart_WCF.Module;

namespace ShanuSchoppingCart_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        ShanuShoppingDBEntities OME;
        public Service1()
        {
            OME = new ShanuShoppingDBEntities();
        }
         // This method is get the Toys details from Db and bind to list  using the Linq query
        public List<shoppingCartDataContract.itemDetailsDataContract> GetItemDetails()
        {
            var query = (from a in OME.ItemDetails
                         select a).Distinct();

            List<shoppingCartDataContract.itemDetailsDataContract> ItemDetailsList = new List<shoppingCartDataContract.itemDetailsDataContract>();

            query.ToList().ForEach(rec =>
            {
                ItemDetailsList.Add(new shoppingCartDataContract.itemDetailsDataContract
                {
                    Item_ID =  Convert.ToString(rec.Item_ID),
                    Item_Name = rec.Item_Name,
                    Description=rec.Description,
                    Item_Price = Convert.ToString(rec.Item_Price),
                    Image_Name = rec.Image_Name,
                    AddedBy = rec.AddedBy

                });
            });
            return ItemDetailsList;
        }

        public bool addItemMaster(shoppingCartDataContract.itemDetailsDataContract ItmDetails)   
      {   
          try   
          {   
                 ItemDetails itm = OME.ItemDetails.Create();                  
                    itm.Item_Name = ItmDetails.Item_Name;
                    itm.Description=ItmDetails.Description;
                    itm.Item_Price = Convert.ToInt32(ItmDetails.Item_Price);
                    itm.Image_Name = ItmDetails.Image_Name;
                    itm.AddedBy = ItmDetails.AddedBy;
                    OME.ItemDetails.Add(itm);
                    OME.SaveChanges();   
         }   
         catch (Exception ex)   
          {   
               throw new FaultException<string>   
                    (ex.Message);   
         }   
         return true;   
       }   

       
    }
    }

