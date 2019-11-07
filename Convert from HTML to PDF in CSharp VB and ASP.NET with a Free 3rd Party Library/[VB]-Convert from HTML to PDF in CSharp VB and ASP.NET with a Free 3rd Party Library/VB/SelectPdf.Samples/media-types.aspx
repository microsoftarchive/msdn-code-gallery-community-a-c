<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="media-types.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.media_types" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Use media types with Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Use media types with Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="media type, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Use media types with Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to convert an url to pdf using SelectPdf Pdf Library for .NET and also use a media type during the conversion.
                    <br />
                    <br />
                    The 2 available media types are <i>Screen</i> and <i>Print</i>. They are useful for pages that use a different set of styles when displayed in browser and when sent to printers.
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                    <br />
                    <br />
                    Media Type:<br />
                    <asp:DropDownList ID="DdlCssMediaType" runat="server">
                        <asp:ListItem Text="Screen" Value="Screen" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Print" Value="Print"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>

