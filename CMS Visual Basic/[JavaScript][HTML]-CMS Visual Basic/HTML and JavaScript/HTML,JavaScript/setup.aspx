<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="setup.aspx.vb" Inherits="SubSiteEditor" EnableViewStateMac="false" MaintainScrollPositionOnPostback="true" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel ID="HostSetting" runat="server">
		<table id="TableDomain" runat="server">
			<tr>
				<th colspan="2">
					<asp:Label ID="Label30" runat="server">#3025</asp:Label>
				</th>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label31" runat="server" Font-Bold="True">#3172</asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="ListSetups" runat="server">
					</asp:DropDownList>
					<asp:Button ID="SelectSetup" runat="server" Text="#56" EnableViewState="False"></asp:Button>
					&nbsp;<asp:Button ID="RemoveSetup" runat="server" Text="#157" />
					&nbsp;<asp:Button ID="DeleteSetup" runat="server" Text="#51" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label32" runat="server" Font-Bold="True">#3173</asp:Label>
				</td>
				<td>
					<asp:Label ID="Label33" runat="server">#3174</asp:Label>
					<asp:TextBox ID="NameNewSetup" runat="server" Width="10em" MaxLength="20"></asp:TextBox>
					<asp:Button ID="NewSetup" runat="server" Text="#3176"></asp:Button>
				</td>
			</tr>
		</table>
		<br />
	</asp:Panel>
	<asp:Panel ID="PanelSetup" runat="server">
		<table id="TableSetting" runat="server">
			<tr>
				<th colspan="2">
						<asp:Label ID="Label35" runat="server">#1016</asp:Label>
						:&nbsp;
						<asp:Label style="font-size:larger" ID="Name" runat="server"></asp:Label>
				</th>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label1" runat="server" Font-Bold="True">#101</asp:Label>
				</td>
				<td>
					<asp:TextBox ID="TitleField" runat="server" Width="40em" MaxLength="128" spellcheck="true"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label2" runat="server" Font-Bold="True">#102</asp:Label>
				</td>
				<td>
					<asp:TextBox ID="Description" runat="server" Width="40em" MaxLength="256" spellcheck="true"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label3" runat="server" Font-Bold="True">#3000</asp:Label>
				</td>
				<td>
					<asp:TextBox ID="KeyWords" runat="server" Width="40em" MaxLength="256" spellcheck="true"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="height: 25px">
					<asp:Label ID="Label44" runat="server" Font-Bold="True">#3177</asp:Label>
				</td>
				<td style="height: 25px">
					<asp:TextBox ID="CorrelatedWords" runat="server" Width="40em" MaxLength="256" spellcheck="true"></asp:TextBox>
					<br />
					<asp:RadioButton ID="CW_Enabled" runat="server" Text="#420" GroupName="CWStatus">
					</asp:RadioButton>
					<br />
					<asp:RadioButton ID="CW_SameDomain" runat="server" Text="#3178" GroupName="CWStatus">
					</asp:RadioButton>
					<br />
					<asp:RadioButton ID="CW_NotEnabled" runat="server" Text="#421" GroupName="CWStatus">
					</asp:RadioButton>
				</td>
			</tr>
			<tr>
				<td style="height: 25px">
					<asp:Label ID="Label4" runat="server" Font-Bold="True">#79</asp:Label>
				</td>
				<td style="height: 25px">
					<asp:DropDownList ID="Language" runat="server">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label27" runat="server" Font-Bold="True">#3166</asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="Skin" runat="server">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label28" runat="server" Font-Bold="True">#149</asp:Label>
				</td>
				<td>
					<table id="TablePlugins" runat="server">
						<tr>
							<td>
							</td>
							<td style="white-space: nowrap">
								<strong>
									<asp:Label ID="Label29" runat="server">#4</asp:Label>
								</strong>
							</td>
						</tr>
						<tr>
							<td>
								<strong>
									<asp:Label ID="PluginLabel" runat="server"></asp:Label>
								</strong>
							</td>
							<td style="white-space: nowrap">
								<asp:RadioButton ID="HP_Default" runat="server" Text="#3167" GroupName="HomePage">
								</asp:RadioButton>
							</td>
							<td style="white-space: nowrap">
								<asp:Label ID="Label11" runat="server" Font-Bold="True">#3067</asp:Label>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label8" runat="server" Font-Bold="True">#1007</asp:Label>
				</td>
				<td>
					<asp:TextBox ID="Currency" runat="server" Width="3em" MaxLength="3"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label19" runat="server" Font-Bold="True">#2</asp:Label>
				</td>
				<td>
					<p>
						<strong>
							<asp:Label ID="Label20" runat="server">#3091</asp:Label>
							:</strong><br />
						<asp:TextBox ID="NewsRSS" runat="server" Width="20em" MaxLength="10000"></asp:TextBox>
						<asp:Label ID="Label23" runat="server">#3094</asp:Label>
						<br />
						<strong>
							<asp:Label ID="Label21" runat="server">#3092</asp:Label>
							:</strong><br />
						<asp:TextBox ID="NewsWords" runat="server" Width="20em" MaxLength="1000"></asp:TextBox>
						<asp:Label ID="Label24" runat="server">#3094</asp:Label>
						<br />
						<strong>
							<asp:Label ID="Label22" runat="server">#3093</asp:Label>
							:</strong><br />
						<asp:TextBox ID="NewsNotWords" runat="server" Width="20em" MaxLength="100"></asp:TextBox>
						<asp:Label ID="Label25" runat="server">#3094</asp:Label>
					</p>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label10" runat="server" Font-Bold="True">#59</asp:Label>
				</td>
				<td>
					<div>
						<asp:CheckBox ID="AboutUs" runat="server" Text="#2006" />
					</div>
					<div>
						<asp:CheckBox ID="UsersOnline" runat="server" Text="#131" />
						<br />
						<asp:CheckBox ID="EnableContacts" runat="server" Text="#1224" />
						<br />
						<asp:CheckBox ID="EnableRelatedBlogAggregator" runat="server" Text="#147" />
					</div>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label5" runat="server" Font-Bold="True">#3014</asp:Label>
				</td>
				<td>
					<table id="AddMenu" runat="server">
						<tr>
							<th>
									<asp:Label ID="Label40" runat="server">#50</asp:Label>
							</th>
						</tr>
						<tr>
							<td>
								<asp:Button ID="NewMenu" runat="server" Text="#50"></asp:Button>
							</td>
						</tr>
					</table>
								<p>
								<asp:CheckBox ID="FirstDocumentInHomePage" runat="server" Text="#3223"></asp:CheckBox>
								</p>
       				<table id="table2">
						<tr>
							<td>
								<asp:Label ID="Label12" runat="server">#3028</asp:Label>
								<asp:DropDownList ID="NMenu" runat="server">
								</asp:DropDownList>
								<asp:Button ID="Button1" runat="server" Text="#57"></asp:Button>
							</td>
						</tr>
					</table>
					<asp:PlaceHolder ID="Menus" runat="server" EnableViewState="False"></asp:PlaceHolder>
				</td>
			</tr>
			<tr>
				<td style="height: 70px">
					<asp:Label ID="Label6" runat="server" Font-Bold="True">#61</asp:Label>
				</td>
				<td style="height: 70px">
					<table id="AddForum" runat="server">
						<tr>
							<th colspan="2">
								<asp:Label ID="Label39" runat="server">#50</asp:Label>
							</th>
						</tr>
						<tr>
							<td>
								<asp:Label ID="Label37" runat="server">#101</asp:Label>
							</td>
							<td>
								<asp:TextBox ID="NewForumName" runat="server" Width="20em" MaxLength="128"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label ID="Label38" runat="server">#102</asp:Label>
							</td>
							<td>
								<asp:TextBox ID="NewForumDescription" runat="server" Width="20em" MaxLength="128"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<p>
									<asp:Button ID="NewForum" runat="server" Text="#50"></asp:Button>
								</p>
							</td>
						</tr>
					</table>
					<br />
					<table id="table3">
						<tr>
							<td>
								<asp:Label ID="Label13" runat="server">#3029</asp:Label>
								<asp:DropDownList ID="NForum" runat="server">
								</asp:DropDownList>
								<asp:Button ID="Button2" runat="server" Text="#57"></asp:Button>
							</td>
						</tr>
					</table>
					<asp:PlaceHolder ID="Forums" runat="server" EnableViewState="False"></asp:PlaceHolder>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label15" runat="server" Font-Bold="True">#3037</asp:Label>
				</td>
				<td>
					<table id="table5">
						<tr>
							<td>
								<asp:Label ID="Label16" runat="server">#3038</asp:Label>
								<asp:DropDownList ID="NWeather" runat="server">
								</asp:DropDownList>
								<asp:Button ID="Button4" runat="server" Text="#57"></asp:Button>
							</td>
						</tr>
					</table>
					<asp:PlaceHolder ID="Weathers" runat="server" EnableViewState="False"></asp:PlaceHolder>
					<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://developer.yahoo.com/weather/#req"
						Target="_blank">#3039</asp:HyperLink>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="Label17" runat="server" Font-Bold="True">#103</asp:Label>
				</td>
				<td>
					<table id="AddAlbum" runat="server">
						<tr>
							<th colspan="2">
								<asp:Label ID="Label43" runat="server">#50</asp:Label>
							</th>
						</tr>
						<tr>
							<td>
								<asp:Label ID="Label42" runat="server">#101</asp:Label>
							</td>
							<td>
								<asp:TextBox ID="NewAlbumTitle" runat="server" Width="20em" MaxLength="128"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Label ID="Label41" runat="server">#102</asp:Label>
							</td>
							<td>
								<asp:TextBox ID="NewAlbumDescription" runat="server" Width="20em" MaxLength="128"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td colspan="2">
								<p>
									<asp:Button ID="NewAlbum" runat="server" Text="#50"></asp:Button>
								</p>
							</td>
						</tr>
					</table>
					<table id="table6">
						<tr>
							<td>
								<asp:Label ID="Label18" runat="server">#3089</asp:Label>
								<asp:DropDownList ID="NAlbum" runat="server">
								</asp:DropDownList>
								<asp:Button ID="Button5" runat="server" Text="#57"></asp:Button>
							</td>
							<td>
								<asp:HyperLink ID="AlbumSetup" runat="server" Target="_blank"></asp:HyperLink>
							</td>
						</tr>
					</table>
					<asp:PlaceHolder ID="Albums" runat="server" EnableViewState="False"></asp:PlaceHolder>
				</td>
			</tr>
			<tr>
				<td style="text-align: right" colspan="2">
					<asp:Button ID="ExtraSetting" runat="server" Text="#151" />
					<a id="save" />
					<asp:Button ID="Save" runat="server" Text="#57"></asp:Button>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
