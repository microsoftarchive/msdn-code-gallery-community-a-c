<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="html-to-pdf-headers-and-footers.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.html_to_pdf_headers_and_footers" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Pdf Headers and Footers with Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Pdf Headers and Footers with Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="header, footer, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Pdf Headers and Footers with Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to convert an url to pdf using SelectPdf Pdf Library for .NET and how to set html headers and footers for the generated pdf document. 
                    <br />
                    <br />
                    This sample will also show how to add page numbers in the footer of the generated pdf document.
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                </p>
                <div class="col2">
                    Header:<br />
                    <asp:CheckBox ID="ChkHeaderFirstPage" runat="server" Text="Show on First Page" Checked="true" /><br />
                    <asp:CheckBox ID="ChkHeaderOddPages" runat="server" Text="Show on Odd Numbered Pages" Checked="true" /><br />
                    <asp:CheckBox ID="ChkHeaderEvenPages" runat="server" Text="Show on Even Numbered Pages" Checked="true" /><br />
                    Height:&nbsp;<asp:TextBox ID="TxtHeaderHeight" runat="server" Text="50" Width="50px"></asp:TextBox> px<br />
                    <a href="files/header.html" target="_blank">Sample header</a><br />
                    <br />
                </div>
                <div class="col2">
                    Footer:<br />
                    <asp:CheckBox ID="ChkFooterFirstPage" runat="server" Text="Show on First Page" Checked="true" /><br />
                    <asp:CheckBox ID="ChkFooterOddPages" runat="server" Text="Show on Odd Numbered Pages" Checked="true" /><br />
                    <asp:CheckBox ID="ChkFooterEvenPages" runat="server" Text="Show on Even Numbered Pages" Checked="true" /><br />
                    Height:&nbsp;<asp:TextBox ID="TxtFooterHeight" runat="server" Text="30" Width="50px"></asp:TextBox> px<br />
                    <asp:CheckBox ID="ChkPageNumbering" runat="server" Text="Add page numbers" Checked="true" /><br />
                    <a href="files/footer.html" target="_blank">Sample footer</a><br />
                    <br />
                </div>
                <div class="col-clear"></div>
                <p>
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>
