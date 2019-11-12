<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="html-to-pdf-converter-links.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.html_to_pdf_converter_links" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Pdf Internal and External Links - Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Pdf Internal and External Links - Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="internal link, external link, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Pdf Internal and External Links - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how the html to pdf converter can handle internal and external links from the web page when converted to pdf using SelectPdf Pdf Library for .NET.
                    <br />
                    <br />
                    SelectPdf Library can convert internal html links to internal pdf links and keep external html links (hyperlinks to other pages) the same in pdf (external links). 
                    These links can be disabled in pdf if needed.
                    <br />
                    <br />
                    <asp:HyperLink ID="LnkTest" runat="server" Text="Test document" Target="_blank"></asp:HyperLink>
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                    <br />
                    <br />
                    <asp:CheckBox ID="ChkInternalLinks" runat="server" Text="Convert with internal links" Checked="true" /><br />
                    <asp:CheckBox ID="ChkExternalLinks" runat="server" Text="Convert with external links" Checked="true" /><br />
                    <br />
                    <br />
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>

