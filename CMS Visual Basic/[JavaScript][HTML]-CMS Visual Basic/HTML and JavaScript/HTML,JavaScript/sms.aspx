<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
	CodeFile="sms.aspx.vb" Inherits="sms" Title="Untitled Page" EnableViewStateMac="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<table id="Table1" runat="server">
		<tr>
			<td colspan="2">
				<script type="text/javascript">
<!--
					var running = false
					var endTime = null
					var timerID = null
					var MaxLen = 160
					var msie = (navigator.userAgent.indexOf("MSIE") > 0)
					var msg
					function ChangeMAX(inputStr)
					{
						if (inputStr == "s") { MaxLen = 160 };
						if (inputStr == "u") { MaxLen = 140 };
						if (inputStr == "c") { MaxLen = 70 };
						upperMe(document.aspnetForm)
					}
					function upperMe(form)
					{
						inputStr = aspnetForm.ctl00$ContentPlaceHolder1$SM.value;
						strlength = inputStr.length;
						if (strlength > MaxLen) aspnetForm.ctl00$ContentPlaceHolder1$SM.value = inputStr.substring(0, MaxLen);
						aspnetForm.num.value = (MaxLen - aspnetForm.ctl00$ContentPlaceHolder1$SM.value.length);
						aspnetForm.ctl00$ContentPlaceHolder1$SM.focus();
					}
//-->
				</script>
				<h3>
					<asp:Label ID="Label5" runat="server">#3064</asp:Label></h3>
			</td>
		</tr>
		<tr>
			<td style="white-space: nowrap">
				<asp:Label ID="Label1" runat="server">#15</asp:Label>
			</td>
			<td>
				<asp:TextBox ID="PhoneNumber" runat="server" MaxLength="13">+</asp:TextBox>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PhoneNumber"
					Display="Dynamic" EnableClientScript="False" ErrorMessage="#26"></asp:RequiredFieldValidator>
				<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="PhoneNumber"
					Display="Dynamic" EnableClientScript="False" ErrorMessage="CustomValidator">#400</asp:CustomValidator>
			</td>
		</tr>
		<tr>
			<td style="white-space: nowrap">
				<asp:Label ID="Label2" runat="server">#60</asp:Label>
			</td>
			<td>
				<textarea id="SM" runat="server" cols="40" name="SM" onchange="upperMe(document.aspnetForm)"
					onkeydown="upperMe(document.aspnetForm)" rows="5"></textarea>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SM"
					Display="Dynamic" EnableClientScript="False" ErrorMessage="#26"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr>
			<td colspan="2" style="white-space: nowrap">
				<input checked="checked" disabled="disabled" name="CS" onclick="ChangeMAX(this.value)"
					type="radio" value="s" />
				<asp:Label ID="Label3" runat="server">#3066</asp:Label>&nbsp;
				<input disabled="disabled" name="CS" onclick="ChangeMAX(this.value)" type="radio"
					value="u" />
				<asp:Label ID="Label4" runat="server">#3065</asp:Label>&nbsp;
				<input disabled="disabled" name="CS" onclick="ChangeMAX(this.value)" type="radio"
					value="c" />UCS2&nbsp;
			</td>
		</tr>
		<tr>
			<td colspan="2" style="white-space: nowrap">
				<input id="num" name="num" onchange="upperMe(document.aspnetForm)" onkeydown="upperMe(document.aspnetForm)"
					size="3" value="160" />
			</td>
		</tr>
		<tr>
			<td colspan="2" style="white-space: nowrap; text-align: right">
				<p style="text-align: right">
					<asp:Button ID="Button1" runat="server" Text="#405" /></p>
			</td>
		</tr>
	</table>
	<asp:Panel ID="Info" runat="server" Enabled="False">
		<table>
			<tr>
				<td style="width: 50%">
					<b>This SMS covers following countries and&nbsp; networks.</b>
				</td>
			</tr>
			<tr>
				<td>
					<b>Austria -</b> Mobilkom<b><br />
						Bulgaria - </b>Mobiltel <b>
							<br />
							Croatia -</b> Cronet <b>
								<br />
								Germany -</b> E-Plus,Mannesman D2 <b>
									<br />
									Israel - </b>Pelephone <b>
										<br />
										Lithuania -</b> Omnitel <b>
											<br />
											Maldives - </b>Dhiraagu <b>
												<br />
												Norway - </b>NetCom,TeleNor <b>
													<br />
													Switzerland - </b>Bluewin <b>
														<br />
														USA - </b>Ameritech Cellular services ,Cellular One, Cingular
					<b>
						<br />
						Brazil - </b>ATL express,Telemig Cellular <b>
							<br />
							Canada -</b> Bell Mobility, Clearnet, Rogers AT&amp;T Wireless ,Telus <b>
								<br />
								France - </b>Itineris <b>
									<br />
									India - </b>Essar Cell Phone,RPG Cellular <b>
										<br />
										Japan - </b>NTT Docomo <b>
											<br />
											Malaysia - </b>Celcom <b>
												<br />
												New Zealand - </b>Messagetrack <b>
													<br />
													Spain -</b> MoviStar <b>
														<br />
														Ukraine - </b>Golden Telecom, UMC <b>
															<br />
															USA - </b>Comcast Cellular Communications,Voicestream Wireless
					Corp.
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
