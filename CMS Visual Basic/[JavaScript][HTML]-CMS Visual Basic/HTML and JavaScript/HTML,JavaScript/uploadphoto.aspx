<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"	CodeFile="uploadphoto.aspx.vb" Inherits="uploadphoto" EnableViewStateMac="false" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="thumbnails.aspx">View PhotoAlbum</asp:HyperLink>
<table runat="server" id="Table1">
<tr>
<th colspan="2">
    <asp:Label ID="Label2" runat="server" Text="#100"></asp:Label>
    </th>
</tr>
<tr>
<td>
<div id="div1" style="display: inline; width: 70px" runat="server">
Label</div>
</td>
<td>
<input id="Title" type="text" maxlength="40" size="50" runat="server" />
</td>
</tr>
<tr>
<td>
<div id="div2" style="display: inline; width: 70px" runat="server">
Label</div>
</td>
<td>
<textarea id="Description" rows="4" cols="40" runat="server"></textarea>
</td>
</tr>
<tr>
<td colspan="2">
<input id="InputFile" type="file" name="InputFile" runat="server" />
</td>
</tr>
<tr>
<td colspan="2">
<div id="Div3" style="display: inline; width: 70px" runat="server">
Label</div>
<br />
<asp:TextBox ID="SourceUrl" runat="server" Width="100%"></asp:TextBox>
</td>
</tr>
<tr>
<td colspan="2"><input type="reset" value="Reset" /><input id="Submit1" type="submit" value="Submit" name="Submit1" runat="server" /></td>
</tr>
</table>

<asp:Panel ID="Panel1" runat="server" Visible="False">
<table runat="server" id="Table2">
<tr>
<th>
<asp:Label ID="Label1" runat="server">#59</asp:Label>
</th>
</tr>
<tr>
<td>
<p>
<asp:CheckBox ID="CheckBox1" runat="server" Text="#110"></asp:CheckBox></p>
</td>
</tr>
</table>
</asp:Panel>
</asp:Content>
