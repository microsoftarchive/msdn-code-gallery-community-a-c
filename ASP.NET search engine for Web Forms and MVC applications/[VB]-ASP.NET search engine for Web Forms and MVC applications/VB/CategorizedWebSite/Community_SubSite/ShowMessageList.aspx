<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShowMessageList.aspx.vb" Inherits="SearchUnit_Basics_VB.ShowMessageList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Message List</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style> 
		BODY { FONT-FAMILY: book antiqua, batang } 
		H3 { FONT-STYLE: italic } 
		</style>
	</HEAD>
	<body>
		<div align="center">
			<table border="1" width='90%' bordercolor="#a9b7f5" ID="Table1">
				<tr>
					<td>
						<h1>Community</h1>
					</td>
				</tr>
				<tr>
					<td align="right" bgcolor="#a9b7f5">
						<h3>
							Messages
						</h3>
					</td>
				</tr>
				<tr>
					<td>
						<form id="Form1" method="post" runat="server">
							<asp:Label id="Label1" runat="server">Here's a list of feedback from our community members</asp:Label>
							<asp:Panel id="Panel1" runat="server"></asp:Panel>
						</form>
						<p>
							<a href="../default.htm">Home</a>
						</p>
					</td>
				</tr>
			</table>
		</div>
	</body>
</HTML>
