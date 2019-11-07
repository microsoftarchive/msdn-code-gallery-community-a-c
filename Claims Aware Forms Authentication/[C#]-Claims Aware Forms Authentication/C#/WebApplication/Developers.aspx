<%@ Page Title="Developers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Developers.aspx.cs" Inherits="WebApplication.Developers" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Only developers can see this page</h2>
    </hgroup>

    <p>If you can see this page you belong to developers role.</p>

</asp:Content>