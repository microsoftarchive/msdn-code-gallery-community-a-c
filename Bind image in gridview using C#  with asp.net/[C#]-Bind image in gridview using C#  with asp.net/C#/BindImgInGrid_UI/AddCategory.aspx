<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddCategory.aspx.cs" Inherits="BindImgInGrid_UI.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Add Category
    </h2>
    <p>
        Put content here.
    </p>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblImgCatgryName" runat="server" Text="Category Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtImgCatgryName" runat="server" Width="191px"></asp:TextBox>
            </td>
             <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtImgCatgryName" ErrorMessage="*" Display="Dynamic" Font-Bold="True"
                    Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnAddCatgry" runat="server" OnClick="btnAddCatgry_Click" Text="Add Category "
                    Width="94px" />
            </td>
           
        </tr>
    </table>
    <asp:Label ID="lblmsg" runat="server" ForeColor="#0066CC"></asp:Label>
</asp:Content>
