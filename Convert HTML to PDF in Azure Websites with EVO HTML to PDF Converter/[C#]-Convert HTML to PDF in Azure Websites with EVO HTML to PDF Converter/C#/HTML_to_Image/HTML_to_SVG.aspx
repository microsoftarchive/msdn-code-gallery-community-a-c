<%@ Page Title="Convert HTML to SVG" Language="C#" MasterPageFile="~/MasterPage.Master"
    AutoEventWireup="true" CodeBehind="HTML_to_SVG.aspx.cs" Inherits="EvoHtmlToPdfDemo.HTML_to_Image.HTML_to_SVG" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="height: 20px; padding-bottom: 1px">
                <asp:Menu ID="demoMenu" runat="server" Orientation="Horizontal" Font-Bold="True"
                    OnMenuItemClick="demoMenu_MenuItemClick">
                    <Items>
                        <asp:MenuItem Text="Live Demo" ToolTip="Live Demo" Value="Live_Demo" Selected="True"></asp:MenuItem>
                        <asp:MenuItem Text="Description" ToolTip="Description" Value="Description"></asp:MenuItem>
                        <asp:MenuItem Text="Sample Code" ToolTip="Sample Code" Value="Sample_Code"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BackColor="White" Font-Underline="True" />
                    <StaticMenuItemStyle Font-Size="14px" ForeColor="Black" BackColor="WhiteSmoke" BorderStyle="Solid"
                        BorderWidth="1px" HorizontalPadding="20px" ItemSpacing="1px" VerticalPadding="5px"
                        Font-Bold="False" Font-Underline="False" />
                    <StaticSelectedStyle BackColor="White" Font-Underline="False" ForeColor="Navy" />
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td style="border: solid 1px Black; height: 776px; padding-top: 10px; padding-left: 10px; padding-right: 10px; padding-bottom: 0px">
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="font-size: 14px; font-weight: bold; height: 20px; padding-bottom: 15px; padding-top: 5px">Convert HTML to SVG
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <asp:MultiView ID="demoMultiView" runat="server" ActiveViewIndex="0">
                                <asp:View ID="liveDemoView" runat="server">
                                    <table style="width: 535px; height: 855px">
                                        <tr>
                                            <td style="vertical-align: top">
                                                <table>
                                                    <tr>
                                                        <td>Convert a HTML page from an URL or a HTML String to a SVG vector image using the
                                                            basic options of converter. The Full Description and a Code Sample can be accessed
                                                            from the top tabs.
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td>Server IP:
                                                                    </td>
                                                                    <td style="width: 5px"></td>
                                                                    <td>
                                                                        <asp:TextBox ID="textBoxServerIP" runat="server" Width="79px">127.0.0.1</asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 20px"></td>
                                                                    <td>Port:
                                                                    </td>
                                                                    <td style="width: 5px"></td>
                                                                    <td>
                                                                        <asp:TextBox ID="textBoxServerPort" runat="server" Width="48px">40001</asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 30px"></td>
                                                                    <td>Service Password:
                                                                    </td>
                                                                    <td style="width: 5px"></td>
                                                                    <td>
                                                                        <asp:TextBox ID="textBoxServicePassword" runat="server" Width="106px" Style="margin-left: 0px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton ID="convertUrlRadioButton" GroupName="HtmlPageSource" runat="server"
                                                                            Text="Convert URL or Local File" Checked="True" OnCheckedChanged="convertUrlRadioButton_CheckedChanged"
                                                                            AutoPostBack="True" Font-Bold="False" />
                                                                    </td>
                                                                    <td style="width: 50px"></td>
                                                                    <td>
                                                                        <asp:RadioButton ID="convertHtmlRadioButton" GroupName="HtmlPageSource" runat="server"
                                                                            Text="Convert HTML String" OnCheckedChanged="convertHtmlRadioButton_CheckedChanged"
                                                                            AutoPostBack="True" Font-Bold="False" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="urlPanel" runat="server">
                                                                <table>
                                                                    <tr>
                                                                        <td style="padding-bottom: 5px; font-weight: bold">HTML Page URL or Local File to Convert
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="urlTextBox" runat="server" Text="http://www.cnn.com"
                                                                                Width="500px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                            <asp:Panel ID="htmlStringPanel" runat="server" Visible="false">
                                                                <table>
                                                                    <tr>
                                                                        <td style="font-weight: bold">HTML String to Convert
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="htmlStringTextBox" runat="server" TextMode="MultiLine" Height="200px"
                                                                                Width="500px">Enter the HTML String to Convert and optionally set a Base URL if the HTML string references external resources by relative URLs</asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-weight: bold">Base URL
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="baseUrlTextBox" runat="server" Text="" Width="500px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="font-weight: bold" colspan="2">HTML Viewer Options
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 10px" colspan="2"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20px"></td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>Width:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="htmlViewerWidthTextBox" runat="server" Width="40px">1024</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>px
                                                                                </td>
                                                                                <td style="width: 50px"></td>
                                                                                <td>Height:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="htmlViewerHeightTextBox" runat="server" Width="40px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>px
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="font-weight: bold" colspan="2">Navigation Options
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 10px" colspan="2"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 20px"></td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>Timeout:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="navigationTimeoutTextBox" runat="server" Width="30px">60</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>sec
                                                                                </td>
                                                                                <td style="width: 50px"></td>
                                                                                <td>Delay Conversion :
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="conversionDelayTextBox" runat="server" Width="30px">2</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>sec
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="convertToSvgButton" runat="server" Text="Convert HTML to SVG"
                                                                OnClick="convertToSvgButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="descriptionView" runat="server">
                                    <div style="width: 535px; height: 855px; overflow: scroll; font-size: 11px">
                                        <asp:Literal ID="descriptionLiteral" runat="server"></asp:Literal>
                                    </div>
                                </asp:View>
                                <asp:View ID="sampleCodeView" runat="server">
                                    <div style="width: 535px; height: 855px; overflow: scroll; font-size: 11px">
                                        <asp:Literal ID="sampleCodeLiteral" runat="server"></asp:Literal>
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
