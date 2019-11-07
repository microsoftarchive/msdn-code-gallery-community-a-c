<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="domainevaluation.aspx.vb" Inherits="domainevaluation" title="Untitled Page" EnableViewState="false" EnableViewStateMac="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="#125"></asp:Label>
    <asp:TextBox ID="Domain" runat="server" AutoCompleteType="Search" CssClass="BigInput"
        ToolTip="#3041" Width="30%"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="#405" />
    <br />
    <asp:Image ID="Certificate" runat="server" Visible="False" />
    <asp:Panel ID="Panel1" runat="server" Visible="False">
    </asp:Panel>
    <asp:PlaceHolder ID="Content" runat="server"></asp:PlaceHolder>
</asp:Content>



