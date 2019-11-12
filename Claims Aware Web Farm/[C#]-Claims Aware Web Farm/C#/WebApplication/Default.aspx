<%@ Page Title="Claims Aware Web Farm" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>Demonstrates web farm related features of Windows Identity Foundation in .NET 4.5.
                </h2>
            </hgroup>
            <p>
                This sample shows the use of machine key and token cache in web farms. For a more complete explanation of how the sample works, 
                please refer to the readme.html file in the VS solution or to the sample’s <a href="http://code.msdn.microsoft.com/Claims-Aware-Web-Farm-088a7a4f">online description</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h1>Running on machine <%: Environment.MachineName.ToLower() %></h1>
    <h3>Hi
        <%: Page.User.Identity.Name %>!</h3>
    <h4>Your email address is
        <asp:Label ID="emailLabel" runat="server"></asp:Label>.</h4>
    <p>
        Above the name is displayed using the Page.User.Identity.Name property. In the header
        the name is displayed using the LoginName control. The value itself is from a claim
        that the Windows Identity Foundation processed from a security token and integrated
        into the current user principal. Other claims can also be sent in a security token.
        These claims can be accessed directly, for example the email address displayed above
        is another claim in the security token. That is accessed in the code behind of default.aspx
        page by creating a ClaimsPrincipal from the current user.
    </p>
    <p>
        You can see all of the claims returned in the security token below in the GridView
        where we have used the ClaimsPrincipal as the data source in the code behind.
    </p>
    <h3>Your claims</h3>
    <p>
        <asp:GridView ID="ClaimsGridView" runat="server" CellPadding="3">
            <AlternatingRowStyle BackColor="White" />
            <HeaderStyle BackColor="#7AC0DA" ForeColor="White" />
        </asp:GridView>
    </p>
</asp:Content>
