<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Culture="Auto" UICulture="Auto" meta:resourcekey="PageResource1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:Label ID="Label1" meta:resourcekey="WelcomeString" Text="Welcome to ASP.NET!"
            runat="server"></asp:Label>
    </h2>
</asp:Content>
