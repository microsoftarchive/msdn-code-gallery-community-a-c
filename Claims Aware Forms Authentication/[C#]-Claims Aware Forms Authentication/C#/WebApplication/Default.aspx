<%@ Page Title="Claims Aware Forms Authentication" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>
                    <%: Page.Title %>.</h1>
                <h2>Demonstrates that with Windows Identity Foundation in .NET 4.5 claims are present
                    even in forms authentication out of the box.</h2>
            </hgroup>
            <p>
                This sample shows basic use of claims within an ASP.Net Web Application when using
                forms authentication. For a more complete explanation of how the sample works, please 
                refer to the readme.html file in the VS solution or to the sample’s <a href="http://code.msdn.microsoft.com/Claims-Aware-Forms-8c6a8b4d">online description</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Create an account and login</h3>
    <p>
        To see that claims are present even with basic normal forms authentication register
        an account in this application and go to the <a href="Claims.aspx">Claims page</a>
        to see what is available.
    </p>
</asp:Content>
