<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="contact" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<br />
	<asp:PlaceHolder ID="PhoneContact" runat="server"></asp:PlaceHolder>
	<br />
	<br />
	<div>
		<table id="Table1" runat="server">
			<tr>
				<th colspan="2">
					<asp:Label ID="Label1" runat="server">#3179</asp:Label>
				</th>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label4" runat="server" Font-Bold="True">#3180</asp:Label>
				</td>
				<td>
					<p>
						<asp:Label ID="Label6" runat="server">#417</asp:Label>
						<asp:TextBox ID="FromName" runat="server" Width="20em"></asp:TextBox>
						<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" ErrorMessage="#26"
							ControlToValidate="FromName" EnableClientScript="False" Display="Dynamic"></asp:RequiredFieldValidator></p>
					<p>
						<asp:Label ID="Label7" runat="server">#12</asp:Label>
						<asp:TextBox ID="FromEmail" runat="server" Width="20em"></asp:TextBox>
						<asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ErrorMessage="#26"
							ControlToValidate="FromEmail" EnableClientScript="False" Display="Dynamic"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator"
							ControlToValidate="FromEmail" EnableClientScript="False" Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">#29</asp:RegularExpressionValidator></p>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server" Font-Bold="True">#3181</asp:Label>
				</td>
				<td>
					<p>
						<asp:RadioButton ID="To_Staff" runat="server" GroupName="To_mail" Text="#3184" Checked="True">
						</asp:RadioButton>
						<asp:PlaceHolder ID="L1" runat="server"></asp:PlaceHolder>
						<br />
						<asp:RadioButton ID="To_Technical" runat="server" GroupName="To_mail" Text="#3185">
						</asp:RadioButton>
						<asp:PlaceHolder ID="L2" runat="server"></asp:PlaceHolder>
					</p>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Font-Bold="True">#3182</asp:Label>
				</td>
				<td>
					<asp:TextBox ID="MailSubject" runat="server" Width="50em"></asp:TextBox>
					<asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ErrorMessage="#26"
						ControlToValidate="MailSubject" EnableClientScript="False" Display="Dynamic"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label5" runat="server" Font-Bold="True">#3183</asp:Label>
				</td>
				<td>
					<asp:TextBox ID="MailText" runat="server" Width="599px" Height="280px" TextMode="MultiLine"></asp:TextBox><br />
					<asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ErrorMessage="#26"
						ControlToValidate="MailText" EnableClientScript="False" Display="Dynamic"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td colspan="2">
					<p align="right">
						<asp:Button ID="Button1" runat="server" Font-Bold="True" Text="#405" />
					</p>
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
