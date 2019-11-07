<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
	CodeFile="translator.aspx.vb" Inherits="translator" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<table id="Table1">
		<tr>
			<td>
				<h3>
					<asp:Label ID="Label1" runat="server">#3220</asp:Label></h3>
				<p>
					<asp:Label ID="Label3" runat="server">#3087</asp:Label>&nbsp;
					<asp:DropDownList ID="SourceLanguage" runat="server" EnableViewState="False">
					</asp:DropDownList>
					<br />
					<asp:TextBox ID="SourceText" runat="server" Width="100%" Height="168px" TextMode="MultiLine"
						EnableViewState="False"></asp:TextBox></p>
			</td>
		</tr>
		<tr>
			<td>
				<h3>
					<asp:Label ID="Label2" runat="server">#3221</asp:Label></h3>
				<p>
					<asp:Label ID="Label4" runat="server">#3088</asp:Label>&nbsp;
					<asp:DropDownList ID="TargetLanguage" runat="server" EnableViewState="False">
					</asp:DropDownList>
					<br />
					<asp:TextBox ID="TargetText" runat="server" Width="100%" Height="168px" TextMode="MultiLine"
						EnableViewState="False" Visible="False"></asp:TextBox></p>
			</td>
		</tr>
		<tr>
			<td>
				<p style="text-align: right">
					<asp:Button ID="Button1" runat="server" Text="#57" EnableViewState="False"></asp:Button></p>
			</td>
		</tr>
	</table>
</asp:Content>
