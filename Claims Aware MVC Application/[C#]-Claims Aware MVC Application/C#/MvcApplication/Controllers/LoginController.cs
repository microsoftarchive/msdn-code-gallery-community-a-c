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

//This namespace has the classes for handling passive redirect protocols like WS-Federation
using System.IdentityModel.Services;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Message = "The page prepares the authentication request";
            return View();
        }

        [HttpPost]
        public ActionResult SignIn()
        {
            // Redirect user to identity provider STS for obtaining a token using WS-Federation Passive Protocol.
            FederatedAuthentication.WSFederationAuthenticationModule.SignIn("LoginPageSignInSubmit");
            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult SignIn(string returnUrl)
        {
            // WSFAM will only parse the WSFed message and redirect back to the page there, 
            // which is Login/?ReturnUrl=<OriginallyRequestedPage>
            // So let's handle that redirect
            return Redirect(returnUrl);
        }
    }
}