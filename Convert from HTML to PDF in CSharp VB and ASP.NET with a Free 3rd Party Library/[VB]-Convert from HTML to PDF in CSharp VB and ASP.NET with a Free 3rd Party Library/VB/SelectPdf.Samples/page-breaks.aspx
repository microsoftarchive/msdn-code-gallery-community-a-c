<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="page-breaks.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.page_breaks" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Control Page Breaks with Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Control Page Breaks with Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="page breaks, custom page break, keep together, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Control Page Breaks with Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to use SelectPdf html to pdf converter to convert a raw html code to pdf and also how to control the page breaks from the html code.
                    <br />
                    <br />
                    To insert a page break in pdf, the html code must have an element with the style <i>page-break-before: always</i> or <i>page-break-after: always</i>. 
                    Before or after that specific element, a page break will be inserted into the generated pdf document. The element can be anything (image, table, table row, div, text, etc).
                    <br />
                    <br />
                    To instruct a certain section from the content to remain on the same page in the generated pdf document, an element with the style <i>page-break-inside: avoid</i> must be used.
                </p>
                <p>
                    Html Code:<br />
                    <asp:TextBox ID="TxtHtmlCode" runat="server" Width="90%" Text="" TextMode="MultiLine" Height="150px"></asp:TextBox><br />
                    <br />
                    Base Url:<br />
                    <asp:TextBox ID="TxtBaseUrl" runat="server" Width="90%" Text=""></asp:TextBox>
                </p>
                <div class="col-clear"></div>
                <p>
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>
