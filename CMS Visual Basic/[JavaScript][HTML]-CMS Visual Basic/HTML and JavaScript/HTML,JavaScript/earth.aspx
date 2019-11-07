<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="earth.aspx.vb" Inherits="earth" title="Untitled Page" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<fieldset style="border:0px"><legend id="Legend" runat="server"></legend>
	<table style="width:100%">
		<tr>
			<td style="height: 27px">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="#17"></asp:Label>&nbsp;<asp:TextBox
					ID="City" runat="server" MaxLength="10"></asp:TextBox>
			</td>
			<td style="height: 27px">
				<asp:Label ID="Label2" runat="server" Font-Bold="True" Text="#114"></asp:Label>&nbsp;<asp:TextBox
					ID="Country" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="FindCity" runat="server"
						Text="#405" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label3" runat="server" Font-Bold="True" Text="#115"></asp:Label>&nbsp;<asp:TextBox
					ID="Latitude" runat="server"></asp:TextBox>
			</td>
			<td>
				<asp:Label ID="Label4" runat="server" Font-Bold="True" Text="#116"></asp:Label>&nbsp;<asp:TextBox
					ID="Longitude" runat="server"></asp:TextBox>&nbsp;<asp:Button ID="ShowPosition" runat="server"
						Text="#117" />
			</td>
		</tr>
	</table>
	<asp:Panel ID="PanelCityList" runat="server" Height="50px" Visible="False" Width="100%">
	</asp:Panel>
	<asp:PlaceHolder ID="PlaceHolderMap" runat="server"></asp:PlaceHolder>
</fieldset>
</asp:Content>