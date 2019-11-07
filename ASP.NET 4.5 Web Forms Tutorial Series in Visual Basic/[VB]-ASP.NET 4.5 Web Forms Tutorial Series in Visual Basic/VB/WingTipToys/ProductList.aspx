<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ProductList.aspx.vb" Inherits="WingTipToys.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Page.Title %></h1>
            </hgroup>

                 <section class="featured">
                    <ul> 
                        <asp:ListView ID="productList" runat="server" DataKeyNames="ProductID" GroupItemCount="3" ItemType="WingTipToys.Product" SelectMethod="GetProducts">
                            <EmptyDataTemplate>      
                                <table id="Table1" runat="server">        
                                    <tr>          
                                        <td>No data was returned.</td>        
                                    </tr>     
                                </table>  
                            </EmptyDataTemplate>  
                            <EmptyItemTemplate>     
                                <td id="Td1" runat="server" />  
                            </EmptyItemTemplate>  
                            <GroupTemplate>    
                                <tr ID="itemPlaceholderContainer" runat="server">      
                                    <td ID="itemPlaceholder" runat="server"></td>    
                                </tr>  
                            </GroupTemplate>  
                            <ItemTemplate>    
                                <td id="Td2" runat="server">      
                                    <table>        
                                        <tr>          
                                            <td>&nbsp;</td>          
                                            <td>
                                                <a href="<%#: GetRouteUrl("ProductByNameRoute", New With {.productName = Item.ProductName})%>">
                                                    <img src='/Catalog/Images/Thumbs/<%#:Item.ImagePath%>' width="100" height="75" border="1" alt=""/>
                                                </a>
                                            </td>
                                            <td>
                                                <a href="<%#: GetRouteUrl("ProductByNameRoute", New With {.productName = Item.ProductName})%>">
                                                    <%#:Item.ProductName%>
                                                </a>       
                                                <br />
                                                <span class="ProductPrice">           
                                                    <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                                </span>
                                                <br />
                                                <a href="/AddToCart.aspx?productID=<%#:Item.ProductID %>">               
                                                    <span class="ProductListItem">
                                                        <b>Add To Cart<b>
                                                    </span>           
                                                </a>
                                            </td>        
                                        </tr>      
                                    </table>    
                                </td>  
                            </ItemTemplate>  
                            <LayoutTemplate>    
                                <table id="Table2" runat="server">      
                                    <tr id="Tr1" runat="server">        
                                        <td id="Td3" runat="server">          
                                            <table ID="groupPlaceholderContainer" runat="server">            
                                                <tr ID="groupPlaceholder" runat="server"></tr>          
                                            </table>        
                                        </td>      
                                    </tr>      
                                    <tr id="Tr2" runat="server"><td id="Td4" runat="server"></td></tr>    
                                </table>  
                            </LayoutTemplate>
                        </asp:ListView>
                    </ul>
               </section>
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>