<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="thumbnails.aspx.vb" Inherits="thumbnails" Title="Untitled Page" %>

<%@ Register src="PhotoOperations.ascx" tagname="PhotoOperations" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<uc1:photooperations ID="PhotoOperations" runat="server" />
	<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>