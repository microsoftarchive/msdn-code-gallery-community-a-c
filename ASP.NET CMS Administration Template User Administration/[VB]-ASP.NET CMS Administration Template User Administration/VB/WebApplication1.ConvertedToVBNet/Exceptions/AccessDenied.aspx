<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessDenied.aspx.cs" Inherits="WebApplication1.Exceptions.AccessDenied" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            color: #FFFF66;
            background-color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="style1">
        ACCESS DENIED</h1>
    <p >
        </p>

    <asp:TextBox ID="TextBox1" runat="server" Height="100%" ReadOnly="True" 
                Rows="25" TextMode="MultiLine" Width="100%">
                You have tried to access a web page that you do not have authorisation to access. 
                The method that you access this page is suspicious and may be illegal.
                As a result we have logged this access and are backtracing you to your destination. 
                If you have come to this page by accident then do not worry. 
                Simply email us at security@ccs-labs.com and explain how you came to this page. 
                We will investigate the problem and if the error is on our side no further action will be taken.
                
                </asp:TextBox>

</asp:Content>
