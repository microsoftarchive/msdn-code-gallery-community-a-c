<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="pdf-converter-viewer-preferences.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.pdf_converter_viewer_preferences" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Setting Pdf Viewer Preferences for the Html to Pdf Converter</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Setting Pdf Viewer Preferences for the Html to Pdf Converter Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="html to pdf converter, pdf viewer preferences, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Setting Pdf Viewer Preferences with the Html to Pdf Converter - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to convert from html to pdf using SelectPdf and set the pdf viewer preferences. 
                    With the viewer preferences, users can specify how the pdf document will appear in a pdf viewer when it is opened.
                </p>
                <p>
                    Url:<br />
                    <asp:TextBox ID="TxtUrl" runat="server" Width="90%" Text="http://selectpdf.com"></asp:TextBox>
                </p>
                <div class="col2">
                    Page Layout:<br />
                    <asp:DropDownList ID="DdlPageLayout" runat="server">
                        <asp:ListItem Text="SinglePage" Value="SinglePage"></asp:ListItem>
                        <asp:ListItem Text="OneColumn" Value="OneColumn" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="TwoColumnLeft" Value="TwoColumnLeft"></asp:ListItem>
                        <asp:ListItem Text="TwoColumnRight" Value="TwoColumnRight"></asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                    Page Mode:<br />
                    <asp:DropDownList ID="DdlPageMode" runat="server">
                        <asp:ListItem Text="UseNone" Value="UseNone" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="UseOutlines" Value="UseOutlines"></asp:ListItem>
                        <asp:ListItem Text="UseThumbs" Value="UseThumbs"></asp:ListItem>
                        <asp:ListItem Text="FullScreen" Value="FullScreen"></asp:ListItem>
                        <asp:ListItem Text="UseOC" Value="UseOC"></asp:ListItem>
                        <asp:ListItem Text="UseAttachments" Value="UseAttachments"></asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                </div>
                <div class="col2">
                    <asp:CheckBox ID="ChkCenterWindow" runat="server" Text="Center Window" /> <br />
                    <asp:CheckBox ID="ChkDisplayDocTitle" runat="server" Text="Display Doc Title" /> <br />
                    <asp:CheckBox ID="ChkFitWindow" runat="server" Text="Fit Window" /> <br />
                    <asp:CheckBox ID="ChkHideMenuBar" runat="server" Text="Hide Menu Bar" /> <br />
                    <asp:CheckBox ID="ChkHideToolbar" runat="server" Text="Hide Toolbar" /> <br />
                    <asp:CheckBox ID="ChkHideWindowUI" runat="server" Text="Hide Window UI" /> <br />
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
