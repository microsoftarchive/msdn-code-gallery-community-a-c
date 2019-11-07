<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="conversion-delay.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.conversion_delay" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Conversion Delay with Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Conversion Delay with Html to Pdf Converter Sample for VB.NET ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="conversion delay, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Conversion Delay with Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how the html to pdf converter can be used to convert a web page to pdf using SelectPdf Pdf Library for .NET.
                    <br />
                    <br />
                    For pages that use javascripts heavily, the conversion can be delayed a number of seconds using <i>converter.Options.MinPageLoadTime</i> property to allow the content to be fully rendered.
                    <br />
                    <br />
                    In a similar way, if a page takes too much time to load, the converter can specify the amount of time in seconds when the page load will timeout using the property <i>converter.Options.MaxPageLoadTime</i>.
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                </p>
                <div class="col2">
                    Delay conversion:<br />
                    <asp:TextBox ID="TxtDelay" runat="server" Width="50px" Text="2"></asp:TextBox> seconds<br />
                    <br />
                </div>
                <div class="col2">
                    Page timeout:<br />
                    <asp:TextBox ID="TxtTimeout" runat="server" Width="50px" Text="20"></asp:TextBox> seconds<br />
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
