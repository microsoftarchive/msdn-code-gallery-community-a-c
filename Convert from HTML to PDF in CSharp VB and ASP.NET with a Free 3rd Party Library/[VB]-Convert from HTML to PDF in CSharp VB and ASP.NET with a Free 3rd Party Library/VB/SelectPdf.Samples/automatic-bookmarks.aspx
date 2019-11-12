<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="automatic-bookmarks.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.automatic_bookmarks" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Automatic Bookmarks with Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Getting Automatic Bookmarks with Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="bookmarks, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Automatic Bookmarks with Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how the html to pdf converter can automatically generate pdf bookmarks based on some elements selection using SelectPdf Pdf Library for .NET.
                    <br />
                    <br />
                    The elements that will be bookmarked are defined using CSS selectors. 
                    For example, the selector for all the H1 elements is "H1", the selector for all the elements with the CSS class name 'myclass' is "*.myclass" and 
                    the selector for the elements with the id 'myid' is "*#myid". Read more about CSS selectors <a href="http://www.w3schools.com/cssref/css_selectors.asp" target="_blank">here</a>.
                    <br />
                    <br />
                    <asp:HyperLink ID="LnkTest" runat="server" Text="Test document" Target="_blank"></asp:HyperLink>
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                    <br />
                    <br />
                    Bookmark the following elements:<br />
                    <asp:TextBox ID="TxtElements" runat="server" Width="90%" Text="H1, H2"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>
