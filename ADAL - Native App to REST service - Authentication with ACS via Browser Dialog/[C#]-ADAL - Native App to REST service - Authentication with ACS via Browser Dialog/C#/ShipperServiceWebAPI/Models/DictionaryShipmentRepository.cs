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

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web.Script.Serialization;

namespace ShipperService.Models
{
    public class DictionaryShipmentRepository
    {
        private static int _nextId = 2; // set start value to 2 because there are already 2 processed shipments loaded in ctor
        private readonly Dictionary<string, Shipment> _shipments;

        public DictionaryShipmentRepository()
        {
            // load processed shipments from config to populate the internal repository
            _shipments = ConfigurationManager.AppSettings["ProcessedShipments"].ToShipments();
        }

        // get a list of all shipments from current owner
        public IEnumerable<Shipment> GetByCurrentOwner(string owner)
        {
            return _shipments.Values.Where(s => s.Owner == owner).ToList();
        }

        // get the shipment by id
        public bool TryGet(int id, string owner, out Shipment shipment) 
        {
            var ret = _shipments.TryGetValue(Convert.ToString(id), out shipment);
            if (ret)
            {
                // check if the current owner is the same as the one in the shipment
                if (shipment.Owner == owner)
                {
                    return true;
                }
            }

            shipment = null;
            return false;
        }

        public Shipment Add(Shipment shipment, string owner) 
        {
            // ignore the ID (if any) coming from the input shipment
            // and set with value of the internal counter
            shipment.ID = Interlocked.Increment(ref _nextId);

            // set the owner using the identity with the current principal
            shipment.Owner = owner;
            _shipments[Convert.ToString(shipment.ID)] = shipment;
            return shipment; 
        } 
 
        public bool TryUpdate(Shipment shipment, string owner, out Shipment updatedShipment)
        {
            var key = Convert.ToString(shipment.ID);
            Shipment oldShipment;
            if (_shipments.TryGetValue(key, out oldShipment))
            {
                if (owner == oldShipment.Owner)
                {
                    shipment.Owner = oldShipment.Owner;
                    shipment.ItemName = shipment.ItemName ?? oldShipment.ItemName;
                    shipment.Quantity = shipment.Quantity ?? oldShipment.Quantity;
                    _shipments[key] = shipment;
                    updatedShipment = shipment;
                    return true;
                }
            }

            updatedShipment = null;
            return false;
        }
    }

    internal static class ShipmentExtension
    {
        // extension method on string to deserialize the processed shipments to a dictionary
        public static Dictionary<string, Shipment> ToShipments(this string serializedShipments)
        {
            return (new JavaScriptSerializer()).Deserialize<Dictionary<string, Shipment>>(serializedShipments);
        }
    }
}