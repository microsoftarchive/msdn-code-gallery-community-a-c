<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
EnableViewState="false"	CodeFile="profilemanager.aspx.vb" Inherits="ProfileManager" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel ID="Panel1" runat="server">
		<table>
			<caption>
				<asp:Label ID="Label1" runat="server" Text="#2007"></asp:Label></caption>
			<tr>
				<td>
					<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
					<asp:TextBox ID="Medal1" runat="server" MaxLength="1" Width="3em">0</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
					<asp:TextBox ID="Medal2" runat="server" MaxLength="1" Width="3em">0</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
					<asp:TextBox ID="Medal3" runat="server" MaxLength="1" Width="3em">0</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
					<asp:TextBox ID="Medal4" runat="server" MaxLength="1" Width="3em">0</asp:TextBox>
				</td>
			</tr>
		</table>
	</asp:Panel>
	<asp:Button ID="Button1" runat="server" Font-Bold="True" Text="#405" />
</asp:Content>
