//----------------------------------------------------------------------------------------------
//    Copyright 2013 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------

namespace Microsoft.Samples.Adal.TelemetryServiceWebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Web.Http;
    using System.Web.Mvc;

    using Microsoft.Samples.Adal.TelemetryServiceWebApi.Models;

    public class DevicesController : ApiController
    {
        // GET method that returns all Devices that have their status maintained in the server
        // GET: /Devices/
        private static readonly IDeviceRepository repository = new DeviceRepository();
        
        public IEnumerable<Device> GetAllDevices()
        {
            Claim objectId = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");

            if (String.Compare(objectId.Value, ConfigurationManager.AppSettings["MonitorObjectId"], StringComparison.OrdinalIgnoreCase) == 0)
            {
                return repository.GetAll();  
            }

            var res = this.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            throw new HttpResponseException(res);
        }

        // POST: /
        [ValidateAntiForgeryToken]
        public HttpResponseMessage PostDevice(Device item)
        {
            Claim objectId = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");

            if (String.Compare(objectId.Value, ConfigurationManager.AppSettings["ClientObjectId1"], StringComparison.OrdinalIgnoreCase) == 0)
            {
                item = repository.Add(item);
                var response = Request.CreateResponse(HttpStatusCode.Created, item);
                string uri = Url.Link("DefaultApi", new { id = item.Id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            var res = this.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            return res;
        }
    }
}