<%@ Page Title="" Language="vb" MasterPageFile="~/Samples.Master" AutoEventWireup="true" CodeBehind="convert-current-page-to-pdf.aspx.vb" Inherits="SelectPdf.Samples.SelectPdf.Samples.convert_current_page_to_pdf" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SelectPdf Free Html To Pdf Converter for .NET VB.NET / ASP.NET - Convert Current Asp.Net Page to Pdf</title>
    <meta name="description" content="SelectPdf Free Html To Pdf Converter - Convert Current Asp.Net Page to Pdf Sample for VB.NET / ASP.NET. Pdf Library for .NET with full sample code in C# and VB.NET." itemprop="description">
    <meta name="keywords" content="convert current asp.net page to pdf, pdf library, sample code, html to pdf, pdf converter" itemprop="keywords">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <article class="post type-post status-publish format-standard hentry">
            <header class="entry-header">
                <h1 class="entry-title">SelectPdf Free Html To Pdf Converter - Convert Current Asp.Net Page to Pdf - VB.NET / ASP.NET Sample</h1>
            </header>
            <!-- .entry-header -->

            <div class="entry-content">
                <p>
                    This sample shows how to use SelectPdf html to pdf converter to convert the current asp.net page to pdf preserving the values entered in the page controls before hitting the Convert button.
                </p>
                <p>
                    Sample text field:<br />
                    <asp:TextBox ID="TxtSample" runat="server" Width="90%" Text="sample text"></asp:TextBox>
                </p>
                <div class="col2">
                    Sample drop down:<br />
                    <asp:DropDownList ID="DdlSample1" runat="server">
                        <asp:ListItem Text="Value1" Value="Value1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Value2" Value="Value2"></asp:ListItem>
                        <asp:ListItem Text="Value3" Value="Value3"></asp:ListItem>
                        <asp:ListItem Text="Value4" Value="Value4"></asp:ListItem>
                        <asp:ListItem Text="Value5" Value="Value5"></asp:ListItem>
                        <asp:ListItem Text="Value6" Value="Value6"></asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                    Sample drop down:<br />
                    <asp:DropDownList ID="DdlSample2" runat="server">
                        <asp:ListItem Text="Demo 1" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Demo 2" Value="2"></asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                </div>
                <div class="col2">
                    Sample text field:<br />
                    <asp:TextBox ID="TxtSample1" runat="server" Width="50px" Text="1000"></asp:TextBox> px<br />
                    <br />
                    Sample text field:<br />
                    <asp:TextBox ID="TxtSample2" runat="server" Width="50px" Text="800"></asp:TextBox> px<br />
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
