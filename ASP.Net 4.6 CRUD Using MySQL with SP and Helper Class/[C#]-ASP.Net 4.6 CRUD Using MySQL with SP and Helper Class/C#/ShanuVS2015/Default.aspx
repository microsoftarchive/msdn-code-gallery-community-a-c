<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShanuVS2015._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <img src="../Images/blank.gif" alt="" width="1" height="10" />
  <table width="99%" class="search">
        <tr>
                <td class="search_es" width="100" align=left>
                    Item Code :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtSitemCDE" runat="server"  MaxLength="30"  />
                </td>
                          
                <td class="search_es"  width="100" align=left>
                 Item NAME :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtSItemNme" runat="server"  MaxLength="30" />
                </td>
                         
                <td class="searchbtn"  align="center">
                        <asp:ImageButton ID="btnSearch" runat="server"  
                            ImageUrl="~/Images/btnSearch.jpg" onclick="btnSearch_Click"  />
                </td>
                           
        </tr>
        </table>

         <img src="../Images/blank.gif" alt="" width="1" height="10" />

         <table   style='width: 99%;table-layout:fixed;' >
     <tr>
        <td align="center" valign="middle" >
          <table   style='width: 99%;table-layout:fixed;'>
             <tr>
                 <td >
                    <table  width="100%" >
                     <tr>
                        <td class="style1" align=left>
                         <table  width="100%" class="title">
                         <tr>
                         <td  width="100%">
                         <img src="Images/Item.gif" />
                         <asp:ImageButton ID="btnAdd" runat="server" 
                            ImageUrl="~/Images/btnNew.jpg" onclick="btnAdd_Click"  />

                         </td>
                         </tr>
                         </table>
                        </td>
                    </tr>    
                    <tr >
                         <td id="tdADD" runat="server" visible="false">
                          <table width="100%" class="search">
        <tr>
                <td class="search_es" width="100" align=left>
                    Item Code :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtitemCode" runat="server"  MaxLength="30" Enabled="False"  />
                </td>
                          
                <td class="search_es"  width="100" align=left>
                 Item NAME :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtitemName" runat="server"  MaxLength="30" />
                       
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtitemName" ErrorMessage="Item Name"></asp:RequiredFieldValidator>
                       
                </td>
                <td class="search_es"  width="100" align=left>
                 Price :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtPrice" runat="server"  MaxLength="30" >0</asp:TextBox>
                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPrice" runat="server" 
                    ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>

                </td>
                <td class="searchbtn" rowspan = "2">
                        <asp:ImageButton ID="btnSave" runat="server"   OnClientClick="return ValidCheck();"
                            ImageUrl="~/Images/btnSave.jpg" onclick="btnSave_Click"/>
                             <asp:ImageButton ID="btnCancel" runat="server"  
                            ImageUrl="~/Images/btnCancel.jpg" onclick="btnCancel_Click" />
                </td>
           </tr>
          <tr>
          <td class="search_es" width="100" align=left>
                   Tax1 :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtTax" runat="server"  MaxLength="30"  >0</asp:TextBox>
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtTax" runat="server" 
                    ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                </td>
                          
                <td class="search_es"  width="100" align=left>
                    User :
                </td>
                <td align=left>
                    <asp:TextBox ID="txtuser" runat="server"  MaxLength="30"   >0</asp:TextBox>
                </td>
                <td class="search_es"  width="110" align=left>
                 Description :
                </td>
                <td align=left >
                    <asp:TextBox ID="txtdescription" runat="server"  MaxLength="30"  TextMode="MultiLine" 
                        Width="220px" />
                </td>
                         
                
                           
        </tr>
        </table>
                         </td>
                    </tr>
        </table>
         </td>
          </tr>
        </table>
         </td>
          </tr>
        </table>

          <img src="../Images/blank.gif" alt="" width="1" height="10" />

            <table   style='width: 99%;table-layout:fixed;' >
     <tr>
        <td align="center" valign="middle" >
          <table   style='width: 99%;table-layout:fixed;'>
             <tr>
                 <td >
                    <table  width="100%" >
                     <tr>
                        <td class="style1" align=left>
                         <table  width="100%" class="title">
                         <tr>
                         <td  width="100%">
                          <h3>Details:</h3>
                         </td>
                         </tr>
                         </table>
                        </td>
                    </tr>    
                    <tr>
                         <td>
                          <table width="100%" class="search">
                          <tr>
                                  <td>
                                      <asp:GridView ID="GridView1" runat="server" Width="100%" 
                                          AutoGenerateColumns="False" BackColor="#ECF3F4" BorderColor="#336699" 
                                          BorderStyle="Solid" BorderWidth="1px" onrowcommand="GridView1_RowCommand">
                                          <AlternatingRowStyle BackColor="#C5DAE4" />
                                          <EditRowStyle BorderColor="#336699" BorderStyle="Solid" BorderWidth="1px" />
                                          <HeaderStyle BackColor="#336699" BorderColor="AliceBlue" BorderStyle="Solid" 
                                              BorderWidth="1px" ForeColor="White" />
                                          <SelectedRowStyle BackColor="#8CB3D9" />
                                          <Columns>
                                            <asp:TemplateField HeaderText="&#160;Edit&#160;">
										        <HeaderStyle HorizontalAlign="Center" Width="5%" CssClass="title"></HeaderStyle>
										        <ItemStyle HorizontalAlign="Center" CssClass="normal"></ItemStyle>
										        <ItemTemplate>
                                                       <asp:ImageButton ID="btnEdit" runat="server"  
                                                        ImageUrl="Images/edit.gif" ToolTip="Edit row" CommandName="edits" CommandArgument='<%#Eval("Item_Code")%>'/>

										        </ItemTemplate>
									        </asp:TemplateField>

                                            <asp:TemplateField HeaderText="&#160;Delete&#160;">
										        <HeaderStyle HorizontalAlign="Center" Width="5%" CssClass="title"></HeaderStyle>
										        <ItemStyle HorizontalAlign="Center" CssClass="normal"></ItemStyle>
										        <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server"  OnClientClick="return DeleteConfirm();"
                                                        ImageUrl="Images/delete.gif" ToolTip="Delete row" CommandName="deletes" CommandArgument='<%#Eval("Item_Code")%>'/>

										        </ItemTemplate>
									        </asp:TemplateField>
                                            <asp:BoundField DataField="Item_Code" HeaderText="ItemCode"   >
                                              <HeaderStyle HorizontalAlign="Center" />
                                              </asp:BoundField>
                                            <asp:BoundField DataField="Item_Name" HeaderText="ItemName"  >
                                              <HeaderStyle HorizontalAlign="Center" />
                                              </asp:BoundField>
                                            <asp:BoundField DataField="Price" HeaderText="Price"   >
                                              <HeaderStyle HorizontalAlign="Center" />
                                              <ItemStyle HorizontalAlign="Right" />
                                              </asp:BoundField>
                                            <asp:BoundField DataField="TAX1" HeaderText="TAX"  >                                         
                                              <HeaderStyle HorizontalAlign="Center" />
                                              <ItemStyle HorizontalAlign="Right" />
                                              </asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="Description"  >
                                              <HeaderStyle HorizontalAlign="Center" />
                                              </asp:BoundField>
                                            <asp:BoundField DataField="IN_USR_ID" HeaderText="User"  >

                                              <HeaderStyle HorizontalAlign="Center" />
                                              </asp:BoundField>

                                          </Columns>
                                      </asp:GridView>
                                  </td>
                          </tr>
                            </table>
                      </td>
                    </tr>
        </table>
         </td>
          </tr>
        </table>
         </td>
          </tr>
        </table>
         <asp:HiddenField ID="hidsaveType" Value="Add" runat="server" />
         <asp:HiddenField ID="hiduser_ID" Value="Add" runat="server" />
</asp:Content>
