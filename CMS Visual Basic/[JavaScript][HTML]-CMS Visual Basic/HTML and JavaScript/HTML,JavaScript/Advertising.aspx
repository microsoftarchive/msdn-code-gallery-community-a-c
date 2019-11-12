<%@ Page Title="" ValidateRequest="false" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Advertising.aspx.vb" Inherits="Advertising" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<h1>
		<asp:Label ID="Label1" runat="server" Text="#2010"></asp:Label></h1>
	<h2>
		<asp:Label ID="Label2" runat="server" Text="#2012"></asp:Label></h2>
	<table style="white-space:nowrap">
		<tr>
			<th colspan="2">
				<asp:Label ID="Label8" runat="server" Text="#3170"></asp:Label>
			</th>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label3" runat="server" Text="#24"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="FirstName" runat="server" MaxLength="30" Width="100%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FirstName"
					ErrorMessage="RequiredFieldValidator" Display="Dynamic">#26</asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label4" runat="server" Text="#25"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="LastName" runat="server" MaxLength="30" Width="100%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
					ControlToValidate="LastName" Display="Dynamic">#26</asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label5" runat="server" Text="#12"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="Email" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Email"
					ErrorMessage="RequiredFieldValidator" Display="Dynamic">#26</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Email"
					ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
					Display="Dynamic">#29</asp:RegularExpressionValidator>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label6" runat="server" Text="#3183"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="Text" runat="server" MaxLength="30" Width="100%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Text"
					ErrorMessage="RequiredFieldValidator" Display="Dynamic">#26</asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="Label7" runat="server" Text="#120"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="Link" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Link"
					ErrorMessage="RequiredFieldValidator" Display="Dynamic">#26</asp:RequiredFieldValidator>
				<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="Link"
					ErrorMessage="RegularExpressionValidator" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
					Display="Dynamic">#29</asp:RegularExpressionValidator>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Label ID="DaysLabel" runat="server" Text="#2014"></asp:Label>
			</td>
			<td>
				<asp:TextBox ID="Days" runat="server" MaxLength="3" Width="50%"></asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Days"
					ErrorMessage="RequiredFieldValidator" Display="Dynamic">#26</asp:RequiredFieldValidator>
				<asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="RangeValidator"
					MaximumValue="90" MinimumValue="1" Type="Integer" ControlToValidate="Days" Display="Dynamic">#29</asp:RangeValidator>
				&nbsp;<asp:Label ID="MaxDays" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
	<input id="TotalPrice" type="hidden" runat="server" />
	<br />
	<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
	<br />
	<asp:Button ID="Button1" runat="server" Text="#57" Font-Bold="True" />
</asp:Content>
