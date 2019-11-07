<%@ Page Title="Database Manager" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="database.aspx.cs" Inherits="WebApplication1.Admin.Database._default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <form id="form1" runat="server">
 <asp:Timer ID="timerUpdate" runat="server" ontick="timerUpdate_Tick" 
        Interval="600000"> <!-- Ten Minutes -->
    </asp:Timer>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="panelHead" runat="server" Direction="LeftToRight" Width="100%">
        <h1>
            Database Management<br />
        </h1>

    </asp:Panel>
   
        <asp:Label ID="Label1" runat="server" Text="ASPNETDB Database Size:  "></asp:Label>
    <asp:Label ID="lbASPNetDBSize" runat="server" Text="0 MB"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="CMS Database Size:  "></asp:Label>
    <asp:Label ID="lblCMSDBSize" runat="server" Text="0 MB"></asp:Label>
       
   
    <br />
    <asp:SqlDataSource ID="CMSDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CMSServices %>" 
        SelectCommand="SELECT * FROM [Applications]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="aspnetdbDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        SelectCommand="SELECT * FROM [Applications]"></asp:SqlDataSource>
    </form>
</asp:Content>
