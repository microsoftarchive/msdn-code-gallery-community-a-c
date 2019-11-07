<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConfigEditor.aspx.vb" Inherits="ConfigEditor" EnableViewState="false" ViewStateMode="Disabled" ValidateRequest="False" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	<asp:HiddenField ID="KeyObject" runat="server" />
	<br />
	<asp:Button ID="SaveButton" runat="server" Text="#405" />
</asp:Content>