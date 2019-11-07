//----------------------------------------------------------------------------------------------
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using ShipperService.Models;

namespace ShipperService.Controllers
{    
    public class ShipmentController : ApiController
    {
        private static readonly object CacheLock = new object();

        private static readonly DictionaryShipmentRepository Repository;

        static ShipmentController()
        {
            Repository = new DictionaryShipmentRepository();
        }

        // GET api/shipment
        // get a list of all shipments from the current owner
        public IEnumerable<Shipment> Get()
        {
            return Repository.GetByCurrentOwner(GetCurrentOwner());
        }

        // GET api/shipment/5
        // get shipments by id
        public Shipment Get(int id)
        {
            Shipment shipment;
            if (Repository.TryGet(id, GetCurrentOwner(), out shipment))
            {
                return shipment;
            }

            return null;
        }

        // POST api/shipment
        // Create a new shipment
        public IEnumerable<Shipment> Post(Shipment shipment)
        {
            // validate if the caller is part of the sales group
            if (!ClaimsPrincipal.Current.IsInRole("Sales"))
            {
                var response = ControllerContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                response.Content = new StringContent("The caller must be a member of the 'Sales' group to create new shipments.");              
                throw new HttpResponseException(response);
            }

            lock (CacheLock)
            {
                return new List<Shipment>() { Repository.Add(shipment, GetCurrentOwner()) };
            }
        }

        // PUT api/shipment/5
        // Update an existing shipment
        public Shipment Put(int id, Shipment shipment)
        {

            string owner = GetCurrentOwner();
            shipment.ID = id;
            shipment.Owner = owner;

            lock (CacheLock)
            {
                Shipment updatedShipment;
                if (Repository.TryUpdate(shipment, owner, out updatedShipment))
                {
                    return updatedShipment;
                }

                return null;
            }
        }

        // Get owner from current thread principal
        private static string GetCurrentOwner()
        {
            return ClaimsPrincipal.Current.Identity.Name;
        }
    }
}
