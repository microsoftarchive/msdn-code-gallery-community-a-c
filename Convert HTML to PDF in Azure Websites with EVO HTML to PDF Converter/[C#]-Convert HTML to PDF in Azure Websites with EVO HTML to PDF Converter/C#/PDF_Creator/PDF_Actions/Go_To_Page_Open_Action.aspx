<%@ Page Title="PDF Creator - Go To a Location in a PDF Page When the Document is Opened"
    Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Go_To_Page_Open_Action.aspx.cs"
    Inherits="EvoHtmlToPdfDemo.PDF_Creator.PDF_Actions.Go_To_Page_Open_Action" %>

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
            <td style="border: solid 1px Black; padding-top: 10px; padding-left: 10px; padding-right: 10px; padding-bottom: 0px">
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="font-size: 14px; font-weight: bold; height: 20px; padding-bottom: 15px; padding-top: 5px">Go To a Location in a PDF Page When the Document is Opened
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
                                                        <td>EVO HTML to PDF Converter can set the location in a PDF page where to go when the
                                                            generated PDF is opened in a PDF viewer. Additionally you can set the initial zoom
                                                            level. The Full Description and a Code Sample can be accessed from the top tabs.
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
                                                                    <td style="padding-bottom: 5px; font-weight: bold">HTML Page URL or Local File to Convert
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="urlTextBox" runat="server" Text="http://news.google.com" Width="500px"></asp:TextBox>
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
                                                                    <td style="font-weight: bold" colspan="2">Go To Page Action
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 10px" colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 30px">
                                                                    <td style="width: 20px"></td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>Page Number:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="pageNumberTextBox" runat="server" Width="40px">1</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                                                                                <td>Location:
                                                                                </td>
                                                                                <td style="width: 10px"></td>
                                                                                <td>X:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="xLocationTextBox" runat="server" Width="35px">50</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>pt
                                                                                </td>
                                                                                <td style="width: 22px"></td>
                                                                                <td>Y:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="yLocationTextBox" runat="server" Width="35px">50</asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 10px" colspan="2"></td>
                                                                </tr>
                                                                <tr style="height: 30px">
                                                                    <td style="width: 20px"></td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td>View Mode:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td style="width: 110px; margin-left: 40px;">
                                                                                    <asp:DropDownList ID="viewModeComboBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="viewModeComboBox_SelectedIndexChanged">
                                                                                        <asp:ListItem>X, Y and Zoom</asp:ListItem>
                                                                                        <asp:ListItem>Fit Window</asp:ListItem>
                                                                                        <asp:ListItem>Fit Horizontally</asp:ListItem>
                                                                                        <asp:ListItem>Fit Vertically</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 20px"></td>
                                                                                <td>
                                                                                    <asp:Panel ID="zoomLevelPanel" runat="server" Visible="true">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="zoomLevelTextBox" runat="server" Width="35px">150</asp:TextBox>
                                                                                                </td>
                                                                                                <td style="width: 5px"></td>
                                                                                                <td>%
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:Panel>
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
                                                            <asp:Button ID="convertToPdfButton" runat="server" Text="Convert HTML to PDF" OnClick="convertToPdfButton_Click" />
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
