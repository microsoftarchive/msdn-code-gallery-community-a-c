<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableViewState="false"
	CodeFile="pagesmanager.aspx.vb" Inherits="pagesmanager" EnableViewStateMac="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div ID="BlockPanel" runat="server">
		<table id="Table1">
			<tr>
				<td>
					<h3>
						1°)
						<asp:Label ID="Label2" runat="server">#3001</asp:Label></h3>
				</td>
				<td>
					<h3>
						2°)
						<asp:Label ID="Label1" runat="server">#3002</asp:Label></h3>
				</td>
			</tr>
			<tr>
				<td>
					<asp:ListBox ID="ListItems" runat="server" Height="320px"
						Width="350px"></asp:ListBox>
					<br />
					<input id="AddItem" type="button" value="#3010" runat="server" /><input id="RemoveItem"
						type="button" value="#3011" runat="server" />
					<asp:Button ID="EditPage" runat="server" Text="#3012"></asp:Button>
				</td>
				<td>
					<table id="Table2">
						<tr>
							<td>
								<asp:Label ID="Label3" runat="server">#3003</asp:Label>
							</td>
							<td>
								<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
							</td>
							<td>
								<asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label ID="Label4" runat="server">#3004</asp:Label>
							</td>
							<td>
								<asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
							</td>
							<td>
								<asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<address>
									<asp:Label ID="MessageAlert" runat="server">Label</asp:Label></address>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:CheckBox ID="HidePage" runat="server" Text="#3009">
								</asp:CheckBox>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:CheckBox ID="JoinPrevious" runat="server" Text="#3238" />
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Label ID="Label5" runat="server">#101</asp:Label>
								<asp:TextBox ID="Label" runat="server" Width="264px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Label ID="Label6" runat="server">#102</asp:Label>
								<asp:TextBox ID="Title" runat="server" Width="264px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:Label ID="Label7" runat="server">#120</asp:Label>
								<asp:TextBox ID="Link" runat="server" Width="264px"></asp:TextBox>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<br />
		<asp:Button ID="Reload" runat="server" Text="#3022"></asp:Button>
		<asp:Button ID="Enter" runat="server" Text="#405"></asp:Button>
		<asp:Button ID="AddPage" runat="server" Text="#3013"></asp:Button>
		<input id="CodeMenu" type="hidden" runat="server" name="CodeMenu" />
		<input id="PageSelect" type="hidden" runat="server" name="PageSelect" />
	</div>
</asp:Content>
