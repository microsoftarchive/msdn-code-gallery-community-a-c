<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true"
    CodeBehind="roles.aspx.cs" Inherits="WebApplication1.Admin.profiles" EnableViewState="True" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <form id="contentForm" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
   </asp:ScriptManager>
            <header>
                <h3>
                    Roles Manager</h3>
                    
                    </header>
                    <asp:Panel ID="Panel1" runat="server" CssClass="width_3_quarter" 
                HorizontalAlign="Center">
                       
            <p align="center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" 
                    DataKeyNames="ApplicationId,LoweredRoleName" DataSourceID="SqlDataSource1" 
                    GridLines="Vertical" HorizontalAlign="Center" 
                    AllowPaging="True" AllowSorting="True" BackColor="White" 
                    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                    EnableSortingAndPagingCallbacks="True">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" 
                            ReadOnly="True" SortExpression="ApplicationId" />
                        <asp:BoundField DataField="RoleId" HeaderText="RoleId" 
                            SortExpression="RoleId" />
                        <asp:BoundField DataField="RoleName" HeaderText="RoleName" 
                            SortExpression="RoleName" />
                        <asp:BoundField DataField="LoweredRoleName" HeaderText="LoweredRoleName" 
                            ReadOnly="True" SortExpression="LoweredRoleName" />
                        <asp:BoundField DataField="Description" HeaderText="Description" 
                            SortExpression="Description" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                    SelectCommand="SELECT * FROM [vw_aspnet_Roles]"></asp:SqlDataSource>
                <ajaxToolkit:RoundedCornersExtender ID="GridView1_RoundedCornersExtender" 
                    runat="server" Enabled="True" TargetControlID="GridView1">
                </ajaxToolkit:RoundedCornersExtender>
                <ajaxToolkit:DropShadowExtender ID="GridView1_DropShadowExtender" 
                    runat="server" Enabled="True" TargetControlID="GridView1">
                </ajaxToolkit:DropShadowExtender>
                <br />


                
            </p>
                       
                
             <asp:Label ID="RoleName" runat="server" Text="Role: Name:"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="tbRoleName" runat="server" EnableViewState="true"></asp:TextBox>
                            &nbsp;
                            <asp:LinkButton ID="lbAdd" runat="server" onclick="lbAdd_Click">Add</asp:LinkButton>  
                            &nbsp;
                            <!-- If you have users then you need to remove them from the role and then re-add them to the new role-->
                            <asp:LinkButton ID="lbUpdate" runat="server" onclick="lbUpdate_Click" >Update</asp:LinkButton>             
                            &nbsp;
                            <!-- If you have users - you will need to delete this role from their profile -->
                            <asp:LinkButton ID="lbDelete" runat="server" >Delete</asp:LinkButton>    
                      <br /> Updating the Role requires the Role to be deleted and then recreated.
            </asp:Panel>
            
 </form>       
</asp:Content>

<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="head">
   
</asp:Content>
