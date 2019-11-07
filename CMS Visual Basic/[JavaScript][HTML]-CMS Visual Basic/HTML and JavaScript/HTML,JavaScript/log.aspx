<%@ Page MaintainScrollPositionOnPostback="true" Language="VB" MasterPageFile="~/MasterPage.master"	AutoEventWireup="false" EnableViewState="false" CodeFile="log.aspx.vb" Inherits="log" EnableViewStateMac="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<h1>Login:</h1>
<h2><asp:Label ID="Label1" runat="server"></asp:Label></h2>
<asp:Panel ID="Panel1" runat="server">
<div>
<asp:Label ID="Label3" runat="server" EnableViewState="False" Visible="False">#30</asp:Label>
</div>
<div>
<table id="table2" runat="server">
<tr>
<td class="leftcoll">
*
<asp:Label ID="Label2" runat="server">#9</asp:Label>
</td>
<td class="rightcoll">
<input id="username" required="required" type="text" maxlength="30" size="30" name="Text1" runat="server" />
<asp:CustomValidator ID="CustomValidator1" runat="server" EnableClientScript="False"
	ControlToValidate="username" ErrorMessage="CustomValidator" Display="Dynamic">#425</asp:CustomValidator>
<asp:CustomValidator ID="Customvalidator4" runat="server" Display="Dynamic" ErrorMessage="CustomValidator"
	ControlToValidate="username" EnableClientScript="False">#28</asp:CustomValidator><asp:RequiredFieldValidator
		ID="RequiredFieldValidator2" runat="server" EnableClientScript="False" ControlToValidate="username"
		Display="Dynamic">#26</asp:RequiredFieldValidator><asp:CustomValidator ID="CustomValidator2"
			runat="server" EnableClientScript="False" Display="Dynamic">#31</asp:CustomValidator><asp:CustomValidator
				ID="CustomValidator3" runat="server" EnableClientScript="False" Display="Dynamic">#32</asp:CustomValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
*
<asp:Label ID="Label4" runat="server">#10</asp:Label>
</td>
<td class="rightcoll">
<input id="Password" required="required" type="password" maxlength="20" size="30" name="Password1" runat="server" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="False"
	ControlToValidate="Password" Display="Dynamic">#26</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
*
<asp:Label ID="Label5" runat="server">#11</asp:Label>
</td>
<td class="rightcoll">
<input id="Password2" required="required" type="password" maxlength="20" size="30" name="Password2" runat="server" />
<asp:CompareValidator ID="CompareValidator1" runat="server" EnableClientScript="False"
	ControlToValidate="Password2" ErrorMessage="CompareValidator" Display="Dynamic"
	ControlToCompare="Password">#29</asp:CompareValidator><asp:RequiredFieldValidator
		ID="RequiredFieldValidator4" runat="server" EnableClientScript="False" ControlToValidate="Password2"
		Display="Dynamic">#26</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
*
<asp:Label ID="Label12" runat="server">#24</asp:Label>
</td>
<td class="rightcoll">
<input id="FirstName" required="required" type="text" size="30" name="Text1" runat="server" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="False"
	ControlToValidate="FirstName" Display="Dynamic">#26</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
*
<asp:Label ID="Label13" runat="server">#25</asp:Label>
</td>
<td class="rightcoll">
<input id="LastName" required="required" type="text" size="30" name="Text1" runat="server" />
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" EnableClientScript="False"
	ControlToValidate="LastName" ErrorMessage="RequiredFieldValidator" Display="Dynamic">#26</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label6" runat="server">#15</asp:Label>
</td>
<td class="rightcoll">
<input id="phone" type="text" size="30" name="Text2" runat="server" />
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label7" runat="server">#16</asp:Label>
</td>
<td class="rightcoll">
<input id="country" type="text" size="30" name="Text3" runat="server" />
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label8" runat="server">#17</asp:Label>
</td>
<td class="rightcoll">
<input id="city" type="text" size="30" name="Text4" runat="server" />
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label9" runat="server">#18</asp:Label>
</td>
<td class="rightcoll">
<input id="Url" type="text" size="30" name="Text5" runat="server" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" EnableClientScript="False"
	ControlToValidate="Url" Display="Dynamic" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?">#29</asp:RegularExpressionValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label10" runat="server">#19</asp:Label>
</td>
<td class="rightcoll">
<asp:RadioButton ID="M" runat="server" GroupName="gender" Text="M"></asp:RadioButton><asp:RadioButton
	ID="F" runat="server" GroupName="gender" Text="F"></asp:RadioButton>
</td>
</tr>
<tr>
<td class="leftcoll">
*
<asp:Label ID="Label11" runat="server">#12</asp:Label>
</td>
<td class="rightcoll">
<input id="Email" required="required" type="text" size="30" name="Text7" runat="server" />
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" EnableClientScript="False"
	ControlToValidate="Email" Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">#29</asp:RegularExpressionValidator><asp:RequiredFieldValidator
		ID="RequiredFieldValidator8" runat="server" EnableClientScript="False" ControlToValidate="Email"
		Display="Dynamic">#26</asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label15" runat="server">Skype</asp:Label>
</td>
<td class="rightcoll">
<input id="Skype" type="text" size="30" name="Text4" runat="server" maxlength="32" />
<asp:HyperLink ID="SkypeInfo" runat="server" Target="_blank">#423</asp:HyperLink>
<asp:CustomValidator ID="CustomValidator5" runat="server" ControlToValidate="Skype"
	Display="Dynamic" EnableClientScript="False" ErrorMessage="CustomValidator">#29</asp:CustomValidator>
</td>
</tr>
<tr>
<td class="leftcoll">
<asp:Label ID="Label14" runat="server">#3224</asp:Label>
</td>
<td class="rightcoll">
<asp:CheckBox ID="PersonalPhotoAlbum" runat="server" Text="#3225"></asp:CheckBox>&nbsp;
<asp:PlaceHolder ID="PhotoAlbum" runat="server"></asp:PlaceHolder>
</td>
</tr>
</table>
</div>
<div id="Buttons" style="text-align:center" runat="server">
<input id="Unique_ID" type="hidden" name="Unique_ID" /><input id="Browser_Datas"
type="hidden" name="Browser_Datas" />
<script type="text/javascript">
if (navigator.appName == "Microsoft Internet Explorer")
{
    document.writeln('<OBJECT classid="clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95" ID=WMP style="visibility:hidden;height:1px;width:1px"></OBJECT>');
}
else
{
    document.writeln('<EMBED TYPE="application/x-mplayer2" NAME=WMP style="visibility:hidden;height:1px;width:1px"></EMBED>');
}
function NSShow()
{

if (typeof (document.WMP) == "object")
{
document.all.Unique_ID.value = document.WMP.GetClientID();
document.all.Browser_Datas.value = window.screen.availHeight + " " + window.screen.availWidth + " " + window.screen.height + " " + window.screen.width + " " + window.screen.bufferDepth + " " + window.screen.colorDepth + " " + window.screen.fontSmoothingEnabled + " " + window.navigator.platform + " " + window.navigator.cpuClass + " " + document.defaultCharset;
}
else
{
document.all.Browser_Datas.value = window.screen.availHeight + " " + window.screen.availWidth + " " + window.screen.height + " " + window.screen.width + " " + window.screen.bufferDepth + " " + window.screen.colorDepth + " " + window.screen.fontSmoothingEnabled + " " + window.navigator.platform + " " + window.navigator.cpuClass + " " + document.defaultCharset;
}
return;
}
if (navigator.appName == "Microsoft Internet Explorer")
{
if (typeof (document.WMP) == "object" &&
typeof (document.WMP.ClientID) == "string")
{
document.all.Unique_ID.value = document.WMP.ClientID;
document.all.Browser_Datas.value = window.screen.availHeight + " " + window.screen.availWidth + " " + window.screen.height + " " + window.screen.width + " " + window.screen.bufferDepth + " " + window.screen.colorDepth + " " + window.screen.fontSmoothingEnabled + " " + window.navigator.platform + " " + window.navigator.cpuClass + " " + document.defaultCharset;
}
else
{
document.all.Browser_Datas.value = window.screen.availHeight + " " + window.screen.availWidth + " " + window.screen.height + " " + window.screen.width + " " + window.screen.bufferDepth + " " + window.screen.colorDepth + " " + window.screen.fontSmoothingEnabled + " " + window.navigator.platform + " " + window.navigator.cpuClass + " " + document.defaultCharset;
}
}
else
{
setTimeout("NSShow()", 100);
}
</script>
<asp:Button ID="Submit1" runat="server" Font-Bold="True" Text="#405" />
</div>
<h1>
<asp:HyperLink ID="HyperLink1" runat="server" EnableViewState="False" Visible="False">#22</asp:HyperLink><asp:HyperLink
ID="HyperLink3" runat="server" EnableViewState="False" Visible="False">#21</asp:HyperLink><asp:HyperLink
ID="HyperLink2" runat="server" EnableViewState="False" Visible="False">#20</asp:HyperLink>
<br />
<asp:HyperLink ID="HyperLink4" runat="server" EnableViewState="False" Visible="False">#320</asp:HyperLink>
</h1>
</asp:Panel>
</asp:Content>
