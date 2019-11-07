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
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web.UI;

namespace RelyingParty
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                // Create a ClaimsPrincipal object from the current user to work with claims
                ClaimsPrincipal claimsPrincipal = Page.User as ClaimsPrincipal;

                // ClaimsPrincipal.Claims returns a collection of claims that we can query, iterate over
                // or in this case set as a datasource of a GridView control. Lots of flexibility. 
                this.ClaimsGridView.DataSource = claimsPrincipal.Claims;
                this.ClaimsGridView.DataBind();

        
                if (claimsPrincipal != null)
                {
                    DisplayReceivedToken(claimsPrincipal);
                }
            }
        }

        private void DisplayReceivedToken(ClaimsPrincipal claimsPrincipal)
        {
            ClaimsIdentity identity = claimsPrincipal.Identity as ClaimsIdentity;
            BootstrapContext bootstrapContext = identity.BootstrapContext as BootstrapContext;
            this.tokenStringLabel.Text += bootstrapContext.Token;
            this.tokenStringLabel.Visible = true;
        }
    }
}