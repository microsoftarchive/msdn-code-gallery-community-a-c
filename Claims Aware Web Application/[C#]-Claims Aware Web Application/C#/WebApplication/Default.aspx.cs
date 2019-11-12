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
// This is the namespace to add when using claims in your code
using System.Security.Claims;
using System.Web.Security.AntiXss;
using System.Web.UI;

namespace WebApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a ClaimsPrincipal object from the current user to work with claims
            ClaimsPrincipal claimsPrincipal = Page.User as ClaimsPrincipal;

            /* 
             * We can use the FindFirst method to get the first occurance of a specific claim.
             * This is very useful when you only expect a single instance of a particular claim type.
             * Note the ClaimTypes class contains many common claims defined as properties for your use.
            */
            // Here we are setting our label to the email claim value. 
            Claim claimEmail = claimsPrincipal.FindFirst(ClaimTypes.Email);
            if (claimEmail != null)
            {
                this.emailLabel.Text = AntiXssEncoder.HtmlEncode( claimEmail.Value, false);
            }
            else
            {

                this.emailLabel.Text = "Email claim not found";
            }

            // ClaimsPrincipal.Claims returns a collection of claims that we can query, iterate over
            // or in this case set as a datasource of a GridView control. Lots of flexibility. 
            this.ClaimsGridView.DataSource = claimsPrincipal.Claims;
            this.ClaimsGridView.DataBind();
        }
    }
}