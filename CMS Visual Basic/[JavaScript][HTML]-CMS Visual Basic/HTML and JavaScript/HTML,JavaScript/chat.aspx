<%@ Page Language="VB" AutoEventWireup="false" ValidateRequest="false" MasterPageFile="~/MasterPage.master" CodeFile="chat.aspx.vb" Inherits="Chat" MaintainScrollPositionOnPostback="true" EnableViewStateMac="false" EnableViewState="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:Panel ID="Discussion" runat="server">
</asp:Panel>
<br />
<asp:Panel ID="Compose" runat="server">
<table id="Table1">
<tr>
<td style="width: 100%">
<asp:TextBox ID="TextMessage" runat="server" EnableViewState="False" MaxLength="600"
Style="width: 100%"></asp:TextBox>
</td>
<td>
<asp:Button ID="Button1" runat="server" Text="#57"></asp:Button>
</td>
</tr>
</table>
<asp:PlaceHolder ID="Emoticons" runat="server"></asp:PlaceHolder>
</asp:Panel>
</asp:Content>
