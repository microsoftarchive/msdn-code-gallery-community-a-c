<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="http-cookies.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.http_cookies" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Sending HTTP Cookies with Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Sending HTTP Cookies with Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="http cookies, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Sending HTTP Cookies with Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to send HTTP cookies to the page that will be converted using the html to pdf converter from SelectPdf Pdf Library for .NET.
                    <br />
                    <br />
                    Below, there is a link to a test page that will display the HTTP cookies sent to it. Converting this page will display the cookies sent by the html to pdf converter.
                    <br />
                    <br />
                    <asp:HyperLink ID="LnkTest" runat="server" Text="Test page" Target="_blank"></asp:HyperLink>
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text=""></asp:TextBox>
                    <br />
                    <br />
                    HTTP Cookies:<br />
                    <br />
                    Name: <asp:TextBox ID="TxtName1" runat="server" Width="40%" Text="Name1"></asp:TextBox>
                    Value: <asp:TextBox ID="TxtValue1" runat="server" Width="40%" Text="Value1"></asp:TextBox>
                    <br />
                    Name: <asp:TextBox ID="TxtName2" runat="server" Width="40%" Text="Name2"></asp:TextBox>
                    Value: <asp:TextBox ID="TxtValue2" runat="server" Width="40%" Text="Value2"></asp:TextBox>
                    <br />
                    Name: <asp:TextBox ID="TxtName3" runat="server" Width="40%" Text="Name3"></asp:TextBox>
                    Value: <asp:TextBox ID="TxtValue3" runat="server" Width="40%" Text="Value3"></asp:TextBox>
                    <br />
                    Name: <asp:TextBox ID="TxtName4" runat="server" Width="40%" Text="Name4"></asp:TextBox>
                    Value: <asp:TextBox ID="TxtValue4" runat="server" Width="40%" Text="Value4"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>
