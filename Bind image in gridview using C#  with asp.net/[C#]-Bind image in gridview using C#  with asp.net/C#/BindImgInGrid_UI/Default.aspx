<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="BindImgInGrid_UI._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://code.msdn.microsoft.com/Insert-Update-Delete-rows-b0a2d4e2" title="click here download..">
          More downloads From Sathiyamoorthy S code.msdn.microsoft.com Profile</a>.
    </p>
    
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
                <asp:Button ID="btnfetch" runat="server" Text="Bind Image" 
                    onclick="btnfetch_Click" />
            </td>
            <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  
                    InitialValue="0" ControlToValidate="drpSelCategry"
        ErrorMessage="*"  Display="Dynamic"  Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <br />
      
      <br />
      <table align="center">
      <tr >
      <td>
       <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333"  
              AutoGenerateColumns="false" >
           <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:TemplateField HeaderText="Image Name">
                   
                   <ItemTemplate>
                       <asp:Label ID="Label1" runat="server" Text='<%#Eval("ImgName")%>'></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Image Description" >
                   
                   <ItemTemplate>
                       <asp:Label ID="Label2" runat="server" Text='<%#Eval("ImgDesc")%>' Width="200"></asp:Label>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="Image">
                   
                   <ItemTemplate>
                       <asp:Image ID="Image1" runat="server" Width="150" Height="100" ImageUrl='<%#Eval("ImgPath")%>'/>
                       <asp:Label ID="Label3" runat="server"></asp:Label>
                   </ItemTemplate>
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
      </td>
      </tr>
      </table>
   
</asp:Content>
