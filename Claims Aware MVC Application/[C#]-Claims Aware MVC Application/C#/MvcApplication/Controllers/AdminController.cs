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

using MvcApplication.Models;
// This is the namespace to add when using claims in your code
using System.Security.Claims;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        // Requires users to log in before they are granted access to this restricted content. 
        [Authorize]
        public ActionResult Index(UserModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Create a ClaimsPrincipal object from the current user to work with claims
                ClaimsPrincipal claimsPrincipal = User as ClaimsPrincipal;

                // We can use the FindFirst method to get the first occurrence of a specific claim.
                // This is very useful when you only expect a single instance of a particular claim type.
                // Note the ClaimTypes class contains many common claims defined as properties for your use.

                // Elsewhere we use the Name property from the User.Identity, here we show
                // that it is also a claim just as the others below that are not mapped to
                // properties within IPrincipal based identities.
                Claim claimName = claimsPrincipal.FindFirst(ClaimTypes.Name);
                if (claimName != null)
                {
                    model.UserName = claimName.Value;
                }
                else
                {

                    model.UserName = "Name claim not found";
                }

                Claim claimLastName = claimsPrincipal.FindFirst(ClaimTypes.Surname);
                if (claimLastName != null)
                {
                    model.LastName = claimLastName.Value;
                }
                else
                {

                    model.LastName = "Surname claim not found";
                }

                Claim claimEmail = claimsPrincipal.FindFirst(ClaimTypes.Email);
                if (claimEmail != null)
                {
                    model.Email = claimEmail.Value;
                }
                else
                {

                    model.Email = "Email claim not found";
                }
                
                // You could map federated users to the local membership provider to retain
                // additional user profile information for your application, that is beyond the
                // scope of this sample.
            }

            ViewBag.Message = "You have to be authenticated to see this page.";
            return View(model);
        }
    }
}
