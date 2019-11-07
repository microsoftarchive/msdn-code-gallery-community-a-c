<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="pdf-converter-security.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.pdf_converter_security" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Pdf Security Settings with Html To Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Pdf Security with Html To Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="pdf security, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Pdf Security Settings with Html To Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to convert from html to pdf using SelectPdf, how to set a password to be able to view or 
                    modify the document and also specify user permissions for the pdf document (if the user can print, copy content, fill forms, modify, etc).
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                </p>
                <div class="col2">
                    User Password:<br />
                    <asp:TextBox ID="TxtUserPassword" runat="server"></asp:TextBox><br />
                    <br />
                    Owner Password:<br />
                    <asp:TextBox ID="TxtOwnerPassword" runat="server"></asp:TextBox><br />
                    <br />
                </div>
                <div class="col2">
                    <asp:CheckBox ID="ChkCanAssembleDocument" runat="server" Text="Allow Assemble Document" Checked="true" /> <br />
                    <asp:CheckBox ID="ChkCanCopyContent" runat="server" Text="Allow Copy Content" Checked="true" /> <br />
                    <asp:CheckBox ID="ChkCanEditAnnotations" runat="server" Text="Allow Edit Annotations" Checked="true" /> <br />
                    <asp:CheckBox ID="ChkCanEditContent" runat="server" Text="Allow Edit Content" Checked="true" /> <br />
                    <asp:CheckBox ID="ChkCanFillFormFields" runat="server" Text="Allow Fill Form Fields" Checked="true" /> <br />
                    <asp:CheckBox ID="ChkCanPrint" runat="server" Text="Allow Print" Checked="true" /> <br />
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
