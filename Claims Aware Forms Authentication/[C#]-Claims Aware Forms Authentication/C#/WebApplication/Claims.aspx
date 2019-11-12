<%@ Page Title="Claims Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Claims.aspx.cs" Inherits="WebApplication.Claims" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>This page shows the claims associated from normal forms based authentication.
                </h2>
            </hgroup>
            <p>
                For a more complete explanation of how the sample works, please refer to the readme.html file in the VS solution or to the sample’s <a href="http://code.msdn.microsoft.com/Claims-Aware-Forms-8c6a8b4d">online description</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Hi
        <asp:Label ID="nameLabel" runat="server"></asp:Label>!</h3>
    <p>
        Claims associated with an authenticated user can be accessed directly, for example
        the name displayed above is accessed in the code behind of claims.aspx page
        by creating a ClaimsPrincipal from the current user rather than the Page.User.Identity.Name
        property. 
    </p>
    <p>
        Below you can see all of the claims associated with the authenticated user in the GridView
        where we have used the ClaimsPrincipal as the data source in the code behind.
        All of this is using just forms authentication, no identity providers or security tokens 
        demonstrating consistency of the model across authentication technologies.
    </p>
    <h3>Your claims</h3>
    <p>
        <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />
        </asp:GridView>
    </p>
</asp:Content>
