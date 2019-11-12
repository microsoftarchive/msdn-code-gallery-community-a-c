<%@ Page EnableViewState="false" EnableViewStateMac="false" Language="VB" MasterPageFile="~/MasterPage.master"
	AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="search" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div id="Panel" runat="server">
		<asp:TextBox ID="Query" runat="server" Width="30%" AutoCompleteType="Search" ToolTip="#3041"
			CssClass="BigInput"></asp:TextBox>
		<asp:Button ID="StartSearch" runat="server" Text="#3041" CssClass="BigText" />
		<asp:DropDownList ID="FindCriterion" runat="server" CssClass="BigText">
		</asp:DropDownList>
		<asp:PlaceHolder ID="ScriptFocus" runat="server"></asp:PlaceHolder>
		<br />
		<asp:Panel ID="Setup" runat="server" HorizontalAlign="Left">
			<asp:Label ID="Label1" runat="server" Text="#4004"></asp:Label>:&nbsp;<asp:TextBox
				ID="NotTerms" runat="server" ToolTip="#4004"></asp:TextBox><br />
			<asp:CheckBox ID="TargetBlank" runat="server" Text="#4002" /><br />
			<asp:CheckBox ID="ShowPreview" runat="server" Text="#117#4000" /><br />
			<asp:CheckBox ID="WebSearch" runat="server" Text="#4005" /><br />
			<asp:CheckBox ID="VideoSearch" runat="server" Text="#3041#3258" /><br />
			<asp:CheckBox ID="SaleSearch" runat="server" Text="#4006" /><br />
			<asp:CheckBox ID="QuestionSearch" runat="server" Text="#4007" /><br />
		</asp:Panel>
		<div>
			<asp:PlaceHolder ID="Results" runat="server"></asp:PlaceHolder>
		</div>
		<asp:Panel ID="Search2" runat="server" Visible="False">
			<asp:TextBox ID="Query2" runat="server" Width="30%" AutoCompleteType="Search" ToolTip="#3041"
				CssClass="BigText"></asp:TextBox>
			<asp:Button ID="StartSearch2" runat="server" Text="#3041" CssClass="BigText" />
		</asp:Panel>
	</div>
</asp:Content>
