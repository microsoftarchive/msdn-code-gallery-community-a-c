<%@ Page ValidateRequest="false" EnableViewState="false" EnableEventValidation="false"
    Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="forum.aspx.vb" Inherits="PageForum" Title="Untitled Page" EnableViewStateMac="false"%>
	<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:Panel ID="Panel" runat="server">
		<asp:Panel ID="FindPanel" runat="server" EnableViewState="False" Visible="False">
			<asp:Label ID="Label3" runat="server" EnableViewState="False">#3041</asp:Label>
			<asp:TextBox ID="Find" runat="server" MaxLength="256" Width="50%" spellcheck="true"></asp:TextBox>
			<asp:DropDownList ID="FindCriterion" runat="server" EnableViewState="False">
			</asp:DropDownList>
			<asp:Button ID="FindButton" runat="server" EnableViewState="False" Text="#3041">
			</asp:Button>
		</asp:Panel>
		<asp:PlaceHolder ID="SearchEngine" runat="server" Visible="False"></asp:PlaceHolder>
		<br />
		<asp:PlaceHolder ID="Display" runat="server"></asp:PlaceHolder>
		<br style="clear: left" />
	</asp:Panel>
	<table id="Edit" ClientIDMode="Static" runat="server" style="width: 100%">
		<tr id="TitleRow" visible="true" runat="server">
			<td>
				<asp:Label ID="Label1" runat="server">#101</asp:Label>
				<asp:TextBox ID="TopicTitle" runat="server" Width="100%" MaxLength="50" spellcheck="true"></asp:TextBox>
				<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
					EnableClientScript="False" ControlToValidate="TopicTitle" ErrorMessage="#26"></asp:RequiredFieldValidator>
			</td>
		</tr>
		<tr id="KeywordsRow" visible="false" runat="server">
			<td>
				<asp:Label ID="Label11" runat="server">#3000</asp:Label>
				<asp:TextBox ID="Keywords" runat="server" MaxLength="50" Width="100%" spellcheck="true"></asp:TextBox>
			</td>
		</tr>
		<tr id="QuoteRow" visible="true" runat="server">
			<td>
				<asp:Label ID="Label4" runat="server">#3072</asp:Label>
				<asp:PlaceHolder ID="QuoteAuthor" runat="server"></asp:PlaceHolder>
				<asp:TextBox ID="Quote" runat="server" Rows="11" TextMode="MultiLine" Width="100%"></asp:TextBox>
			</td>
		</tr>
		<tr id="EditTextRow" visible="true" runat="server">
			<td>
				<asp:Label ID="Label2" runat="server">#60</asp:Label>
				<asp:TextBox ID="TopicText" runat="server" Rows="11" TextMode="MultiLine" Width="100%" spellcheck="true"></asp:TextBox><br />
				<asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" Display="Dynamic"
					EnableClientScript="False" ControlToValidate="TopicText" ErrorMessage="#26"></asp:RequiredFieldValidator>
				<asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" EnableClientScript="False"
					ControlToValidate="TopicText" ErrorMessage="#426"></asp:CustomValidator>
				<asp:CustomValidator ID="CustomValidator2" runat="server" Display="Dynamic" EnableClientScript="False"
					ControlToValidate="TopicText" ErrorMessage="#3095"></asp:CustomValidator>
			</td>
		</tr>
		<tr>
			<td>
				<asp:PlaceHolder ID="Emotions" runat="server"></asp:PlaceHolder>
			</td>
		</tr>
		<tr id="SelectPhoto" runat="server">
			<td style="height: 70px">
				<asp:Panel ID="PanelPhotos" runat="server">
					<input id="Radio1" type="radio" value="Radio1" name="PhotoSource" runat="server" />
					<asp:Label ID="Label7" runat="server" EnableViewState="False">#3100</asp:Label>&nbsp;<input
						id="Radio2" type="radio" value="Radio2" name="PhotoSource" runat="server" />
					<asp:Label ID="Label8" runat="server" EnableViewState="False">#3101</asp:Label></asp:Panel>
				<asp:Label ID="Label6" runat="server">#56#104</asp:Label>:
				<br />
				<asp:DropDownList ID="PhotoList" runat="server" Style="width: inherit">
				</asp:DropDownList>
				<img id="imgpreview" alt="" class="Border" src="" runat="server" />
			</td>
		</tr>
		<tr id="UploadPhoto" runat="server">
			<td style="height: 165px">
			
<table runat="server" id="Table1">
<tr>
<th colspan="2">
    <asp:Label ID="Label12" runat="server" Text="#100"></asp:Label>
    </th>
</tr>
<tr>
<td>
    <asp:Label ID="Label13" runat="server" Font-Bold="False">#101</asp:Label>
</td>
<td>
<input id="ImgTitle" ClientIDMode="Static" type="text" maxlength="40" size="50" runat="server" />
</td>
</tr>
<tr>
<td>
	<asp:Label ID="Label14" runat="server" Font-Bold="False">#102</asp:Label>
</td>
<td>
<textarea id="ImgDescription" ClientIDMode="Static" rows="4" cols="40" runat="server" name="S1"></textarea>
</td>
</tr>
<tr>
<td colspan="2">
<input id="ImgInputFile" ClientIDMode="Static" type="file" name="InputFile" runat="server" />
</td>
</tr>
</table>

            </td>
		</tr>
		<tr id="SetVideo" runat="server">
			<td>
				<table id="Table4">
					<tr>
						<td>
							<h3>
								<asp:Label ID="Label9" runat="server">#3258</asp:Label>&nbsp;</h3>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Label ID="Label10" runat="server" Font-Bold="False">#3260</asp:Label>
							<asp:TextBox ID="VideoID" runat="server" Width="20em"></asp:TextBox>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="Button1" runat="server" Text="#405" Font-Bold="True"></asp:Button>
			</td>
		</tr>
	</table>
	<asp:PlaceHolder ID="LinksCorrelated" runat="server"></asp:PlaceHolder>
	<br />
	<asp:PlaceHolder ID="ChatPreview" runat="server"></asp:PlaceHolder>
	<asp:Panel ID="Preferences" runat="server" EnableViewState="False" Visible="False">
		<table id="Table2">
			<tr>
				<th>
						<asp:Label ID="Label5" runat="server">#3067</asp:Label>
				</th>
			</tr>
			<tr>
				<td>
					<asp:CheckBox ID="HideSettingPanel" runat="server" Text="#3068"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:CheckBox ID="ChatMode" runat="server" Text="#3069"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:CheckBox ID="AutoSubsctiption" runat="server" Text="#3073"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:CheckBox ID="ShowCensored" runat="server" Text="#3074"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:CheckBox ID="UseInternalSearchEngine" runat="server" Text="#3216"></asp:CheckBox>
				</td>
			</tr>
			<tr>
				<td>
					<asp:CheckBox ID="ShowAvatars" runat="server" Text="#3442" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Button ID="Button2" runat="server" Text="#405"></asp:Button>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
