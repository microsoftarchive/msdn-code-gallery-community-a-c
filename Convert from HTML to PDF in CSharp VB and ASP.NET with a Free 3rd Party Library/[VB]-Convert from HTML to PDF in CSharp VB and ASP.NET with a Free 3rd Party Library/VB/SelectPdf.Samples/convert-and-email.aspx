<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Samples.Master" CodeBehind="convert-and-email.aspx.vb" Inherits="SelectPdf.Samples.convert_and_email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET - Html to Pdf Converter - Convert and Email as Attachment - VB.NET / ASP.NET</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter. Convert and Email as Attachment Sample for VB.NET ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="html to pdf converter, convert and email, email as attachment, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter for .NET - Convert and Email as Attachment - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows the simplest code that can be used to convert an url to pdf using SelectPdf Pdf Library for .NET and then email the generated PDF document as an attachment.
                    <br />
                    <br />
                    IMPORTANT: Remember to set the SMTP server details in web.config.
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                    <br />
                    <br />
                    Email:<br />
                    <asp:TextBox ID="TxtEmail" runat="server" Width="50%" Text="your_email@your.domain.com"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="BtnCreatePdf" runat="server" Text="Create PDF and Email" OnClick="BtnCreatePdf_Click" CssClass="mybutton" />
                    &nbsp;&nbsp;
                    <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label>
                </p>
            </div>
            <!-- .entry-content -->
        </article>
        <!-- #post -->
</asp:Content>
