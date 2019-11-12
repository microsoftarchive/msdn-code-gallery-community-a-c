<%@ Page Title="Create PDF Documents" Language="C#" MasterPageFile="~/MasterPage.Master"
    AutoEventWireup="true" CodeBehind="Create_PDF_Documents.aspx.cs" Inherits="EvoHtmlToPdfDemo.PDF_Creator.Create_PDF_Documents" %>

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
                        <td style="font-size: 14px; font-weight: bold; height: 20px; padding-bottom: 15px; padding-top: 5px">Create PDF Documents
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
                                                        <td>EVO HTML to PDF Converter allows you to create empty PDF documents to which you
                                                            can add various types elements: HTML, text, images, graphics. You can save the created
                                                            PDF document to a file, a stream or in a memory buffer. The Full Description and
                                                            a Code Sample can be accessed from the top tabs.
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
                                                                    <td style="font-weight: bold" colspan="2">PDF Standard
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
                                                                                <td>
                                                                                    <asp:RadioButton ID="fullPdfRadioButton" GroupName="PdfStandard" runat="server" Text="Full PDF"
                                                                                        Checked="True" Font-Bold="False" />
                                                                                </td>
                                                                                <td style="width: 20px"></td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="pdfARadioButton" GroupName="PdfStandard" runat="server" Text="PDF/A-1b"
                                                                                        Font-Bold="False" />
                                                                                </td>
                                                                                <td style="width: 20px"></td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="pdfXRadioButton" GroupName="PdfStandard" runat="server" Text="PDF/X-1a"
                                                                                        Font-Bold="False" />
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
                                                                    <td style="font-weight: bold" colspan="2">Color Space
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
                                                                                <td>
                                                                                    <asp:RadioButton ID="rgbRadioButton" GroupName="PdfColorSpace" runat="server" Text="RGB"
                                                                                        Checked="True" Font-Bold="False" />
                                                                                </td>
                                                                                <td style="width: 20px"></td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="grayScaleRadioButton" GroupName="PdfColorSpace" runat="server"
                                                                                        Text="Gray Scale" Font-Bold="False" />
                                                                                </td>
                                                                                <td style="width: 20px"></td>
                                                                                <td>
                                                                                    <asp:RadioButton ID="cmykRadioButton" GroupName="PdfColorSpace" runat="server" Text="CMYK"
                                                                                        Font-Bold="False" />
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
                                                                    <td style="font-weight: bold" colspan="2">PDF Page Options
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
                                                                                <td>Size:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td style="width: 110px">
                                                                                    <asp:DropDownList ID="pdfPageSizeDropDownList" runat="server">
                                                                                        <asp:ListItem>A0</asp:ListItem>
                                                                                        <asp:ListItem>A1</asp:ListItem>
                                                                                        <asp:ListItem>A2</asp:ListItem>
                                                                                        <asp:ListItem>A3</asp:ListItem>
                                                                                        <asp:ListItem>A4</asp:ListItem>
                                                                                        <asp:ListItem>A5</asp:ListItem>
                                                                                        <asp:ListItem>A6</asp:ListItem>
                                                                                        <asp:ListItem>A7</asp:ListItem>
                                                                                        <asp:ListItem>A8</asp:ListItem>
                                                                                        <asp:ListItem>A9</asp:ListItem>
                                                                                        <asp:ListItem>A10</asp:ListItem>
                                                                                        <asp:ListItem>B0</asp:ListItem>
                                                                                        <asp:ListItem>B1</asp:ListItem>
                                                                                        <asp:ListItem>B2</asp:ListItem>
                                                                                        <asp:ListItem>B3</asp:ListItem>
                                                                                        <asp:ListItem>B4</asp:ListItem>
                                                                                        <asp:ListItem>B5</asp:ListItem>
                                                                                        <asp:ListItem>ArchA</asp:ListItem>
                                                                                        <asp:ListItem>ArchB</asp:ListItem>
                                                                                        <asp:ListItem>ArchC</asp:ListItem>
                                                                                        <asp:ListItem>ArchD</asp:ListItem>
                                                                                        <asp:ListItem>ArchE</asp:ListItem>
                                                                                        <asp:ListItem>Flsa</asp:ListItem>
                                                                                        <asp:ListItem>HalfLetter</asp:ListItem>
                                                                                        <asp:ListItem>Ledger</asp:ListItem>
                                                                                        <asp:ListItem>Legal</asp:ListItem>
                                                                                        <asp:ListItem>Letter</asp:ListItem>
                                                                                        <asp:ListItem>Letter11x17</asp:ListItem>
                                                                                        <asp:ListItem>Note</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 20px"></td>
                                                                                <td>Orientation:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="pdfPageOrientationDropDownList" runat="server">
                                                                                        <asp:ListItem>Portrait</asp:ListItem>
                                                                                        <asp:ListItem>Landscape</asp:ListItem>
                                                                                    </asp:DropDownList>
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
                                                                                <td>Margins:
                                                                                </td>
                                                                                <td style="width: 10px"></td>
                                                                                <td>Left:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="leftMarginTextBox" runat="server" Width="35px">0</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>pt
                                                                                </td>
                                                                                <td style="width: 22px"></td>
                                                                                <td>Right:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="rightMarginTextBox" runat="server" Width="35px">0</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>pt
                                                                                </td>
                                                                                <td style="width: 25px"></td>
                                                                                <td>Top:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="topMarginTextBox" runat="server" Width="35px">0</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>pt
                                                                                </td>
                                                                                <td style="width: 15px"></td>
                                                                                <td>Bottom:
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="bottomMarginTextBox" runat="server" Width="35px">0</asp:TextBox>
                                                                                </td>
                                                                                <td style="width: 5px"></td>
                                                                                <td>pt
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
                                                            <asp:Button ID="createPdfButton" runat="server" Text="Create PDF Document"
                                                                OnClick="createPdfButton_Click" />
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
