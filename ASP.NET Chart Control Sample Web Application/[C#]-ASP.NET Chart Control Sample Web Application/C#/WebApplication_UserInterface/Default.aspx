<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication_UserInterface._Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
 </h2>
 
        <table>
        <tr>
        <td>
            <asp:Chart ID="Chart1" runat="server" Width="345px" >
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                        <Area3DStyle Enable3D="True" />
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            </td>
        <td><asp:GridView ID="GridView1" runat="server" CellPadding="4" 
            ForeColor="#333333"  AutoGenerateColumns="False" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" onrowediting="GridView1_RowEditing" 
            onrowupdating="GridView1_RowUpdating" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField Visible="False">  
                                
                    <ItemTemplate>
                        <asp:Label ID="lblPk_id" runat="server"  Text='<%#Eval("pk_id")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Headertext="Student Name">
                    <EditItemTemplate> 
                        <asp:TextBox ID="txtSName" runat="server"  Text='<%#Eval("StudName")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtSName" runat="server"  Text='<%#Eval("StudName")%>'></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSName" runat="server"  Text='<%#Eval("StudName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Total">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSTotal" runat="server" Text='<%#Eval("StudTotal")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                    <asp:TextBox ID="txtSTotal" runat="server" Text='<%#Eval("StudTotal")%>'></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSTotal" runat="server"  Text='<%#Eval("StudTotal")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:TemplateField>
                <FooterTemplate>

                <asp:Button ID="btnInsert" runat="Server" Text="Insert" CommandName="Insert" UseSubmitBehavior="False" />

                </FooterTemplate>
                </asp:TemplateField>

            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <table>
 <tr>
    <td> 
 
  <asp:Label ID="Label1" runat="server" Text="Student Name" CssClass="bold" 
            ForeColor="#333333"></asp:Label>
  </td>
 <td>
 <asp:TextBox ID="txtStudName" runat="server" MaxLength="50"></asp:TextBox>
 </td>
 </tr>
     
   <tr>
   <td>  

  <asp:Label ID="Label2" runat="server" Text="Student Total" CssClass="bold" 
           ForeColor="#333333"></asp:Label>
   </td>
 <td>
 <asp:TextBox ID="txtStudTotal" runat="server" MaxLength="3"></asp:TextBox>
 </td>
 </tr>

  <tr>
 <td>
 </td> 
 <td>
 <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add Row" />
 </td>
 </tr>
 </table>
        <asp:Label ID="lblmsg" runat="server" CssClass="bold" ForeColor="#0033CC" 
            Text="Label"></asp:Label>

        </td>
        </tr>
        </table>
        
    </asp:Content>
