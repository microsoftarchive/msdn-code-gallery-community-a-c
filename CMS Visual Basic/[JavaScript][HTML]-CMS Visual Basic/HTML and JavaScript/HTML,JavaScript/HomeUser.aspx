<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" EnableViewState="false" AutoEventWireup="false" CodeFile="HomeUser.aspx.vb" Inherits="HomeUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:Panel ID="UserPanel" runat="server">
		<h1><asp:PlaceHolder ID="UserName" runat="server"></asp:PlaceHolder>			
			<asp:PlaceHolder ID="Lock" runat="server"></asp:PlaceHolder>
			<asp:DropDownList ID="RoleList" runat="server" Visible="False"></asp:DropDownList>
		</h1>		
		<section itemscope="itemscope" itemtype="http://schema.org/Person" style="display:table" id="InfoPanel" Visible="false" runat="server"></section>
		<asp:Panel style="display:table" ID="Operations" runat="server">
		</asp:Panel>
	
		<asp:PlaceHolder ID="PhotosPlaceHolder" Visible="false" runat="server">		
		<hr />
		<asp:Panel style="display:table" ID="PhotosPanel" runat="server">
		<h2><asp:Label ID="Label1" runat="server" Text="#3224"></asp:Label></h2>			
		</asp:Panel>
		</asp:PlaceHolder>	

		<asp:PlaceHolder ID="FriendsPlaceHolder" Visible="false" runat="server">
		<hr />
		<asp:Panel style="display:table;line-height:2em" ID="Friends" runat="server">
		<h2><asp:Label ID="Label2" runat="server" Text="#2022"></asp:Label></h2>
		</asp:Panel>
		</asp:PlaceHolder>	
	</asp:Panel>
</asp:Content>
