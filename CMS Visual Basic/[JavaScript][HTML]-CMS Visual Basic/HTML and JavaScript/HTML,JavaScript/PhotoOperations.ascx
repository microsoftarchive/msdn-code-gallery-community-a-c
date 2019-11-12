<%@ Control Language="vb" AutoEventWireup="false" Inherits="PhotoOperations"	CodeFile="PhotoOperations.ascx.vb" %>
<table id="OperationTable" runat="server">
	<tr>
		<th>
				<asp:Label ID="_OperationName" runat="server">Operation</asp:Label>
		</th>
	</tr>
	<tr>
		<td>
			<div>
				<table id="_Table1" runat="server">
					<tr>
						<th>
							<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
						</th>
						<td>
							<input id="title" type="text" maxlength="40" size="50" name="title" runat="server" />
						</td>
					</tr>
					<tr>
						<th>
							<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
						</th>
						<td>
							<textarea id="description" name="description" rows="4" cols="40" runat="server"></textarea>
						</td>
					</tr>
				</table>
			</div>
			<h3>
				<asp:Label ID="_Alert" runat="server" EnableViewState="False" Visible="False">Label</asp:Label></h3>
			<p>
				<input id="_Reset1" type="reset" value="Reset" name="Reset1" runat="server" /><input
					id="Submit1" type="submit" value="Submit" name="Submit1" runat="server" /></p>
		</td>
	</tr>
</table>
