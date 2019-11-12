<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UploadImg.aspx.cs" Inherits="BindImgInGrid_UI.UploadImg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Upload image
    </h2>
    <p>
        Put content here.
    </p>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Image Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtImgNme" runat="server"></asp:TextBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  
                     ControlToValidate="txtImgNme"
        ErrorMessage="*"  Display="Dynamic"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Image Description"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtImgDescr" runat="server"></asp:TextBox>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  
                     ControlToValidate="txtImgDescr"
        ErrorMessage="*"  Display="Dynamic"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Select Category"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpSelCategry" runat="server" Height="30px" Width="214px">
                </asp:DropDownList>
            </td>
            <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
                    InitialValue="0" ControlToValidate="drpSelCategry"
        ErrorMessage="*"  Display="Dynamic"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblImgCatgryName" runat="server" Text="Find Image"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
             <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  
                     ControlToValidate="FileUpload1"
        ErrorMessage="*"  Display="Dynamic"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnUploadImg" runat="server" OnClick="btnAddCatgry_Click" Text="Upload"
                    Width="94px" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblmsg" runat="server" ForeColor="#0066CC"></asp:Label>
</asp:Content>
