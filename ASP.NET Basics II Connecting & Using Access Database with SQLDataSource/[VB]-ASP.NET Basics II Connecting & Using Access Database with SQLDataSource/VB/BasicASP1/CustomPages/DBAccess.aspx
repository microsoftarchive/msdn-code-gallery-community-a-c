<%@ Page Language="VB" AutoEventWireup="false" UnobtrusiveValidationMode="none" Title="ASP.NET with Access Database" MasterPageFile="~/MasterPage.master" CodeFile="DBAccess.aspx.vb" Inherits="CustomPages_DBSQL" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Label ID="Label1" runat="server" Text="AccessEmp Table on Access Database View" CssClass="font-x"></asp:Label><br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="50%" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" InsertVisible="False" />
            <asp:BoundField DataField="Emp_Name" HeaderText="Emp_Name" SortExpression="Emp_Name" />
            <asp:BoundField DataField="Emp_Dept" HeaderText="Emp_Dept" SortExpression="Emp_Dept" />
            <asp:BoundField DataField="Emp_Contact" HeaderText="Emp_Contact" SortExpression="Emp_Contact" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:Label ID="Label2" runat="server" Text="Tasks" CssClass="font-x"></asp:Label><hr />
    <asp:Panel ID="pIns" runat="server" Visible="false">
        <asp:Table runat="server" ID="Tab1" CellPadding="10">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TxtName" runat="server" Width="200px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label4" runat="server" Text="Dept."></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownDeptIns" runat="server">
                        <asp:ListItem Text="Dept1"></asp:ListItem>
                        <asp:ListItem Text="Dept2"></asp:ListItem>
                        <asp:ListItem Text="Dept3"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label5" runat="server" Text="Contact"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TxtInsContact" runat="server" Width="200px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <hr />
        <asp:Button ID="BtInsIns" runat="server" Text="Insert" />
        <asp:Button ID="BtInsCancel" runat="server" Text="Cancel" />
    </asp:Panel>
    <asp:Panel ID="pDel" runat="server" Visible="false">
        <asp:Table runat="server" ID="Table1" CellPadding="10">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label6" runat="server" Text="ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownDelID" runat="server">
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <hr />
        <asp:Button ID="BtDelDel" runat="server" Text="Delete" />
        <asp:Button ID="BtDelCancel" runat="server" Text="Cancel" />
    </asp:Panel>
    <asp:Panel ID="pUp" runat="server" Visible="false">
        <asp:Table runat="server" ID="Table2" CellPadding="10">
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label10" runat="server" Text="Select ID"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownUpID" runat="server" AutoPostBack="True"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label7" runat="server" Text="Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TxtUpName" runat="server" Width="200px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label8" runat="server" Text="Dept."></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="DropDownDeptUp" runat="server" AutoPostBack="True">
                        <asp:ListItem Text="Dept1"></asp:ListItem>
                        <asp:ListItem Text="Dept2"></asp:ListItem>
                        <asp:ListItem Text="Dept3"></asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Width="200px">
                    <asp:Label ID="Label9" runat="server" Text="Contact"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TxtUpContact" runat="server" Width="200px"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <hr />
        <asp:Button ID="BtUpIns" runat="server" Text="Update" />
        <asp:Button ID="BtUpCancel" runat="server" Text="Cancel" />
    </asp:Panel>
    <asp:Panel ID="pTsk" runat="server">
        <asp:Button ID="BtIns" runat="server" Text="Insert" />
        <asp:Button ID="BtDel" runat="server" Text="Delete" />
        <asp:Button ID="BtUp" runat="server" Text="Update" />
    </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings: ConnectionString %>' ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>' SelectCommand="SELECT * FROM [AccessEmp]"></asp:SqlDataSource>
</asp:Content>

