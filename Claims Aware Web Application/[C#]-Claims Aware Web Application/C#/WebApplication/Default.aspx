<%@ Page Title="Claims Aware Web Application" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>Demonstrates basic use of claims.</h2>
            </hgroup>
            <p>
                This sample shows basic use of claims within an ASP.Net Web Application. For a more complete explanation of how the sample works, 
                please refer to the readme.html file in the VS solution or to the sample’s <a href="http://code.msdn.microsoft.com/Claims-Aware-Web-d94a89ca">online description</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Hi
        <%: Page.User.Identity.Name %>!</h3>
    <h4>Your email address is
        <asp:Label ID="emailLabel" runat="server"></asp:Label>.</h4>
    <p>
        Above you can see the name of an authenticated user and an associated email address.
    </p>
    <p>
        You can see all of the claims associated with the authenticated user below.
    </p>
    <h3>Your claims</h3>
    <p>
        <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />
        </asp:GridView>
    </p>
</asp:Content>
