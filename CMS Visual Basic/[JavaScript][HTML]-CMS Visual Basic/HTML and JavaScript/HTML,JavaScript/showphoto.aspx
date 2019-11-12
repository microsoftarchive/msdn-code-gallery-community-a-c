<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
	CodeFile="showphoto.aspx.vb" Inherits="showphoto" Title="Untitled Page" EnableViewStateMac="false"
	EnableViewState="false" %>
<%@ Register Src="PhotoOperations.ascx" TagName="PhotoOperations" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<section>
<table id="TableImg">
	<tr>
		<td style="border-style:none">
			<asp:PlaceHolder ID="PreviousPreView" runat="server"></asp:PlaceHolder>
		</td>
		<td style="border-style:none">
			<asp:HyperLink ID="GoToPrevious" runat="server"></asp:HyperLink>
		</td>
		<td style="border-style:none">
			<asp:PlaceHolder ID="ImgPlaceHolder" runat="server"></asp:PlaceHolder>
		</td>
		<td style="border-style:none">
			<asp:HyperLink ID="GoToNext" runat="server"></asp:HyperLink>
		</td>
		<td style="border-style:none">
			<asp:PlaceHolder ID="NextPreView" runat="server"></asp:PlaceHolder>
		</td>
	</tr>
</table>
</section>
	<asp:PlaceHolder ID="GoogleOff1" runat="server"></asp:PlaceHolder>
	<table id="Gradient" runat="server">
		<tr>
			<td>
				<script type="text/javascript">
<!--
					function SetBG(color)
					{
						for (var Cell in document.getElementById("TableImg").rows[0].cells)
						{
							document.getElementById("TableImg").rows[0].cells[Cell].bgColor = color
						}				
					}
//-->
				</script>
				<table id="Table1">
					<tr style="height: 20px">
						<td style="width: 20px; background-color: #000000; color:White" onmouseover="SetBG('#000000')">0%
						</td>
						<td style="width: 20px; background-color: #191919; color:White" onmouseover="SetBG('#191919')">10%
						</td>
						<td style="width: 20px; background-color: #333333; color:White" onmouseover="SetBG('#333333')">20%
						</td>
						<td style="width: 20px; background-color: #4c4c4c; color:White" onmouseover="SetBG('#4c4c4c')">30%
						</td>
						<td style="width: 20px; background-color: #666666; color:White" onmouseover="SetBG('#666666')">40%
						</td>
						<td style="width: 20px; background-color: #7f7f7f; color:White" onmouseover="SetBG('#7f7f7f')">50%
						</td>
						<td style="width: 20px; background-color: #999999; color:Black" onmouseover="SetBG('#999999')">60%
						</td>
						<td style="width: 20px; background-color: #b2b2b2; color:Black" onmouseover="SetBG('#b2b2b2')">70%
						</td>
						<td style="width: 20px; background-color: #cccccc; color:Black" onmouseover="SetBG('#cccccc')">80%
						</td>
						<td style="width: 20px; background-color: #e5e5e5; color:Black" onmouseover="SetBG('#e5e5e5')">90%
						</td>
						<td style="width: 20px; background-color: #ffffff; color:Black" onmouseover="SetBG('#ffffff')">100%
						</td>
					</tr>
				</table>
			</td>
			<td>
				<asp:HyperLink ID="FullScreen" runat="server"></asp:HyperLink><br />
				<asp:HyperLink ID="Max" runat="server"></asp:HyperLink>
			</td>
		</tr>
	</table>
	<asp:PlaceHolder ID="GoogleOn1" runat="server"></asp:PlaceHolder>
	<asp:PlaceHolder ID="GoogleOff2" runat="server"></asp:PlaceHolder>
    	<uc:PhotoOperations ID="PhotoOperations1" runat="server" />
	<br />
	<asp:PlaceHolder ID="PhotoAlbum" runat="server"></asp:PlaceHolder>
	<br />
	<asp:PlaceHolder ID="Comments" runat="server"></asp:PlaceHolder>
	<br />
	<asp:PlaceHolder ID="PlaceHolderControlOperations" runat="server"></asp:PlaceHolder>
	<br />
	<asp:Panel ID="Ecard" runat="server">
		<table runat="server" id="SendECard">
			<tr>
				<th colspan="2" style="height: 23px">
					<asp:Label ID="Label4" runat="server" Font-Bold="True">#3253#3254</asp:Label>
				</th>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right">
					<asp:Label ID="Label5" runat="server" Text="#3180#417"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="FromName" required="required" runat="server" MaxLength="50" Width="22em"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FromName"
						ErrorMessage="#26"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right">
					<asp:Label ID="Label6" runat="server" Text="#3180#12"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="FromEmail" required="required" type="email" runat="server" MaxLength="50" Width="22em"></asp:TextBox>
					<asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="FromEmail"
						ErrorMessage="#29" ValidateEmptyText="True"></asp:CustomValidator>
				</td>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right">
					<asp:Label ID="Label7" runat="server" Text="#3181#417"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="ToName" required="required" runat="server" MaxLength="50" Width="22em"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ToName"
						ErrorMessage="#26"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right">
					<asp:Label ID="Label8" runat="server" Text="#3181#12"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="ToEmail" required="required" type="toemail" runat="server" MaxLength="50" Width="22em"></asp:TextBox>
					<asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="ToEmail"
						ErrorMessage="#29" ValidateEmptyText="True"></asp:CustomValidator>
				</td>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right">
					<asp:Label ID="Label9" runat="server" Text="#3182"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="SubjectEcard" required="required" runat="server" MaxLength="50" Width="22em"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SubjectEcard"
						ErrorMessage="#26"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right">
					<asp:Label ID="Label10" runat="server" Text="#3183"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="TextEcard" required="required" runat="server" Height="59px" TextMode="MultiLine" MaxLength="500"
						Width="22em"></asp:TextBox>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextEcard"
						ErrorMessage="#26"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td style="white-space: nowrap; text-align: right" colspan="2">
					<asp:Button ID="Button1" runat="server" Text="#57" />
				</td>
			</tr>
		</table>
	</asp:Panel>
	<asp:PlaceHolder ID="GoogleOn2" runat="server"></asp:PlaceHolder>
</asp:Content>
