<%@ Page Language="vb" AutoEventWireup="false" Inherits="utility" CodeFile="utility.aspx.vb" %>
<html>
	<head>
		<title>utility</title>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" runat="server" BorderWidth="1px">
				<h3>Merge language database</h3>
				<p>Language source file name
					<asp:TextBox id="MergeDataBase" runat="server">localization_new.mdb</asp:TextBox><br />
					Merge language
					<asp:DropDownList id="Languages" runat="server"></asp:DropDownList><br />
					<asp:CheckBox id="ReplaceOld" runat="server" Text="Replace old text"></asp:CheckBox><br />
					<asp:Button ID="Merge" runat="server" Text="Merge" />
				</p>
				<p>
					<asp:Button ID="Translate" runat="server" Text="Translate language database" />
				</p>
			</asp:panel>
            <asp:Panel ID="Panel2" runat="server">
							<h3>
								BackUp</h3>
							<p>
								<asp:Button ID="BackUp" runat="server" 
									Text="Make compress Backup file of App Data" />
								<asp:Button ID="Restore" runat="server" 
									Text="Restore the compress file App_Data.GzBackUp to App_data/" />
							</p>
							<p>
								<asp:Label ID="Label1" runat="server" Text="Host "></asp:Label>
								<asp:TextBox ID="Host" runat="server"></asp:TextBox>
								<asp:Label ID="Label2" runat="server" Text=" User Name "></asp:Label>
								<asp:TextBox ID="UserName" runat="server"></asp:TextBox>
								<asp:Label ID="Label3" runat="server" Text=" Password "></asp:Label>
								<asp:TextBox ID="Password" runat="server"></asp:TextBox>
								<asp:Button ID="FtpUploadBackUp" runat="server" Text="Ftp Upload BackUp " />
							</p>
							<p>
								&nbsp;</p>
			</asp:Panel>
            <br />
      <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Repair Users" /></form>
	</body>
</html>
