<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
	CodeFile="pay.aspx.vb" Inherits="pay" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:PlaceHolder ID="DescriptionModalityOfPayment" runat="server"></asp:PlaceHolder>
	<asp:Panel ID="Confirm" runat="server" Visible="False">
		<table id="TableDate" runat="server">
			<tr>
				<td>
					<h2>
						<asp:Label ID="Label1" runat="server" EnableViewState="False">#3188</asp:Label></h2>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label13" runat="server" EnableViewState="False">#3187</asp:Label>
					<asp:TextBox ID="DateOfPayment" runat="server" EnableViewState="False" MaxLength="10"
						ToolTip="#3135" Width="10em">#3135</asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server" EnableViewState="False">#3205</asp:Label>
					<asp:TextBox ID="ModalityOfPayment" runat="server" EnableViewState="False" MaxLength="50"
						Width="10em"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td align="center">
					<asp:Button ID="ConfirmPayment" runat="server" EnableViewState="False" Text="#405" />
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>

