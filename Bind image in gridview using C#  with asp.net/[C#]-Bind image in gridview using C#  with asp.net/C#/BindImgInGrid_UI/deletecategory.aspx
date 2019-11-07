<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="deletecategory.aspx.cs" Inherits="BindImgInGrid_UI.deletecategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Select Category"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpSelCategry" runat="server" Height="30px" Width="214px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnremove" runat="server" Text="Remove" 
                    onclick="btnremove_Click" />
            </td>
            <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
                    InitialValue="0" ControlToValidate="drpSelCategry"
        ErrorMessage="*"  Display="Dynamic"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
     <asp:Label ID="lblmsg" runat="server" ForeColor="#0066CC"></asp:Label>
</asp:Content>
