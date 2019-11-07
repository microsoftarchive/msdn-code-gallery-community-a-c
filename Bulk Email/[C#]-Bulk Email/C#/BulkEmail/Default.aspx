<%@ Page Title="Home Page" Theme="BulkSMS" Language="C#" MasterPageFile="~/Site.master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BulkEmail._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <h2>
        Bulk Email
    </h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="middle">
                        To:
                    </td>
                    <td valign="middle">
                        <asp:TextBox ID="txtTo" TextMode="MultiLine" Columns="60" Rows="2" runat="server" />
                        <ajaxToolkit:AutoCompleteExtender runat="server" BehaviorID="AutoCompleteEx" ID="autoComplete1"
                            TargetControlID="txtTo" ServicePath="AutoComplete.asmx" ServiceMethod="GetCompletionList"
                            MinimumPrefixLength="1" CompletionInterval="1000" EnableCaching="true" CompletionSetCount="20"
                            CompletionListCssClass="autocomplete_completionListElement" CompletionListItemCssClass="autocomplete_listItem"
                            CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" DelimiterCharacters=";"
                            ShowOnlyCurrentWordInCompletionListItem="true">
                            <Animations>
                                <OnShow>
                                    <Sequence>
                                        <OpacityAction Opacity="0" />
                                        <HideAction Visible="true" />
                                        <ScriptAction Script="
                                            // Cache the size and setup the initial size
                                            var behavior = $find('AutoCompleteEx');
                                            if (!behavior._height) {
                                                var target = behavior.get_completionList();
                                                behavior._height = target.offsetHeight - 2;
                                                target.style.height = '0px';
                                            }" />
                                        <Parallel Duration=".4">
                                            <FadeIn />
                                            <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                                        </Parallel>
                                    </Sequence>
                                </OnShow>
                                <OnHide>
                                    <Parallel Duration=".4">
                                        <FadeOut />
                                        <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                                    </Parallel>
                                </OnHide>
                            </Animations>
                        </ajaxToolkit:AutoCompleteExtender>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        Subject:
                    </td>
                    <td valign="middle">
                        <asp:TextBox ID="txtSubject" runat="server" Columns="60"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="middle">
                        Message:
                    </td>
                    <td valign="middle">
                        <asp:TextBox ID="txtMessage" TextMode="MultiLine" Columns="60" Rows="10" runat="server" />
                        <ajaxToolkit:HtmlEditorExtender ID="HEE1" TargetControlID="txtMessage" DisplaySourceTab="true"
                            runat="server" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" valign="middle" align="center">
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" />
                    </td>
                </tr>
            </table>
            <asp:LinkButton ID="OpenButton" runat="server" />
            <asp:Panel ID="MessagePanel" runat="server" BorderStyle="Solid" Height="20" Style="display: none"
                Width="100" CssClass="modalPopup">
                <table width="100%">
                    <tr>
                        <td style="text-align: left; vertical-align: top">
                            <asp:Label ID="lblSent" runat="server"></asp:Label>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; vertical-align: bottom">
                            <asp:Button ID="CloseButton" runat="server" Text="Close" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <ajaxToolkit:ModalPopupExtender ID="MessagePopUp" runat="server" CancelControlID="CloseButton"
                Enabled="True" PopupControlID="MessagePanel" TargetControlID="OpenButton">
            </ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            Sending...
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
