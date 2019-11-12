<%@ Page MaintainScrollPositionOnPostback="true" ValidateRequest="false" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" EnableViewState="false" EnableViewStateMac="false" Inherits="EditPage" CodeFile="edit.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel ID="Panel1" runat="server">
		<table id="Table1">
			<tr>
				<th>
						<asp:Label ID="Label1" runat="server">#101</asp:Label>
				</th>
				<td>
					<asp:TextBox ID="TitlePage" runat="server" Width="40em" spellcheck="true"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="Label2" runat="server">#102</asp:Label>
				</th>
				<td>
					<asp:TextBox ID="Description" runat="server" Width="40em" spellcheck="true"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="Label3" runat="server">#3000</asp:Label>
				</th>
				<td>
					<asp:TextBox ID="KeyWords" runat="server" Width="40em" spellcheck="true"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="Label44" runat="server">#3177</asp:Label>
				</th>
				<td style="text-align: left">
					<asp:TextBox ID="CorrelatedWords" runat="server" Width="40em" MaxLength="256" spellcheck="true"></asp:TextBox><br />
					<asp:RadioButton ID="CW_Enabled" runat="server" Text="#420" GroupName="CWStatus">
					</asp:RadioButton><br />
					<asp:RadioButton ID="CW_SameDomain" runat="server" Text="#3178" GroupName="CWStatus">
					</asp:RadioButton><br />
					<asp:RadioButton ID="CW_NotEnabled" runat="server" Text="#421" GroupName="CWStatus">
					</asp:RadioButton>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="Label8" runat="server">#59</asp:Label>
				</th>
				<td style="text-align: left">
					<asp:CheckBox ID="EnabledComments" runat="server" Checked="True" Text="#130" />
					&nbsp;&nbsp;
					<asp:Label ID="Label45" runat="server" Font-Bold="False">#156</asp:Label>
					<asp:DropDownList ID="ShowDate" runat="server">
					</asp:DropDownList>
				</td>
			</tr>
		</table>
		<br />
		<asp:Panel ID="Panel2" runat="server">
			<table id="Table2">
				<tr>
					<th>
							<asp:Label ID="Label4" runat="server">#56#104</asp:Label>
					</th>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="AddPhotoAlbum" runat="server" Text="#56#103"></asp:CheckBox>
						<asp:PlaceHolder ID="PhotosSourceSelect" runat="server"></asp:PlaceHolder>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label6" runat="server">#56#104</asp:Label>:
						<asp:DropDownList ID="PhotoList" runat="server">
						</asp:DropDownList>
						&nbsp;
					</td>
				</tr>
				<tr>
					<td style="height: 140px;text-align: center;">
						<img id="imgpreview" runat="server" class="Border" alt="" />
					</td>
				</tr>
			</table>
			<br />
		</asp:Panel>
		<asp:Panel ID="Panel3" runat="server">
			<table id="Table4">
				<tr>
					<th>
							<asp:Label ID="Label5" runat="server">#3258</asp:Label>
					</th>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label7" runat="server">#3260</asp:Label>
						<asp:TextBox ID="VideoID" runat="server" Width="20em"></asp:TextBox>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<br />
		<br />
		<asp:PlaceHolder ID="HtmlEditor" runat="server"></asp:PlaceHolder>
		<textarea rows="1" cols="1" id="Html" name="Html" runat="server" style="width: 100%; height: 500px;" spellcheck="true"></textarea>
		<p>
			<asp:Button ID="Submit" runat="server" Text="#405"></asp:Button>
			<asp:Button ID="Delete" runat="server" Text="#51" Visible="False">
			</asp:Button><input id="NewNPage" type="hidden" name="NewNPage" runat="server" />
			<asp:PlaceHolder ID="ScriptClient" runat="server"></asp:PlaceHolder>
		</p>
	</asp:Panel>
</asp:Content>
