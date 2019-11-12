<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="WebApplication1.Admin.ManageUsers" %>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="width_3_quarter" style="float: right">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:Panel ID="Panel1" runat="server" CssClass="width_3_quarter" 
        HorizontalAlign="right" Width="80%">
      <p align="center">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
        DataKeyNames="ApplicationId,LoweredUserName" DataSourceID="SqlDataSource1" 
        ForeColor="#333333" GridLines="None"  Width="90%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" 
                ReadOnly="True" SortExpression="ApplicationId" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" 
                SortExpression="UserId" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="LoweredUserName" HeaderText="LoweredUserName" 
                ReadOnly="True" SortExpression="LoweredUserName" />
            <asp:BoundField DataField="MobileAlias" HeaderText="MobileAlias" 
                SortExpression="MobileAlias" />
            <asp:CheckBoxField DataField="IsAnonymous" HeaderText="IsAnonymous" 
                SortExpression="IsAnonymous" />
            <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" 
                SortExpression="LastActivityDate" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    </p>
    
    <ajaxToolkit:RoundedCornersExtender ID="GridView1_RoundedCornersExtender" 
        runat="server" Enabled="True" TargetControlID="GridView1">
    </ajaxToolkit:RoundedCornersExtender>
    
    <ajaxToolkit:DropShadowExtender ID="GridView1_DropShadowExtender" 
        runat="server" Enabled="True" TargetControlID="GridView1">
    </ajaxToolkit:DropShadowExtender>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
        OldValuesParameterFormatString="original_{0}" 
        
        SelectCommand="SELECT * FROM [vw_aspnet_Users] WHERE ([ApplicationId] = @ApplicationId)">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="ApplicationId" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
        <br />
        <br />
   
    
     <asp:Label ID="Label1" runat="server" Text="Member's Name:"></asp:Label>
    &nbsp;
    <asp:TextBox
        ID="tbMembersName" runat="server" ontextchanged="textChanged"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
    &nbsp;
        <asp:TextBox ID="tbPassword" runat="server" ontextchanged="textChanged"></asp:TextBox>
        <br />
    &nbsp;
        <asp:LinkButton ID="lbAdd" runat="server" onclick="lbAdd_Click">Add</asp:LinkButton>
    &nbsp;
        <asp:LinkButton ID="lbUpdate" runat="server">Update</asp:LinkButton>
&nbsp;
    <asp:LinkButton ID="lbDelete" runat="server">Delete</asp:LinkButton>
    <br /><br />
        <asp:Panel ID="panelMessages" runat="server" Visible="false">
            <asp:Label ID="lblMessages" runat="server" Text="Label" CssClass="alert_info"></asp:Label>
        </asp:Panel>
    </asp:Panel>
    </form>

   
</asp:Content>
