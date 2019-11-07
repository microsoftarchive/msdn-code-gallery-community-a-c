<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecipeViewer.aspx.cs" Inherits="SearchUnit_Basics_CSharp.RecipeViewer" %>


<!DOCTYPE html>

<html>
<head>
	<meta charset="UTF-8">
	<script type="text/javascript" src="/Keyoti_SearchEngine_Web_Common/SearchUnit_Highlighter.js"></script>
    
    <asp:Repeater ID="RepeaterTitle" runat="server" DataSourceID="XmlDataSource1">
     <ItemTemplate>
            <title><%# XPath("Title") %></title>   
            <meta name="Keyoti_Search_Custom_Data" content="<%# XPath("CustomData") %>" />
     </ItemTemplate></asp:Repeater>
	
    <meta name='Keyoti_Search_Location_Category' content='Recipes'  />
    

    <script src="Keyoti_SearchEngine_Web_Common/SearchUnit_Highlighter.js" type="text/javascript"></script>


</head>
<body>
	

    <form id="form1" runat="server">
    <div>
    

    
    <asp:Repeater ID="Repeater" runat="server" DataSourceID="XmlDataSource1">
     <ItemTemplate>
      <!--keyoti_search_ignore_begin-->
        <h1><%# XPath("Title") %></h1>
        <!--keyoti_search_ignore_end-->
	    <p>
		    <%# XPath("Description") %>
	    </p>


       
       <h4>INGREDIENTS</h4>
        <ol class="ingredients">
            <asp:Repeater ID="Repeater2" runat="server" DataSource='<%# XPathSelect("Ingredients/Ingredient") %>'>
             <ItemTemplate>
               <li><%# XPath(".") %></li>
             </ItemTemplate>
            </asp:Repeater>       
        </ol>
        
        <h4>DIRECTIONS</h4>
        <ol class="directions">
            <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# XPathSelect("Directions/Direction") %>'>
             <ItemTemplate>
               <li><%# XPath(".") %></li>
             </ItemTemplate>
            </asp:Repeater>       
        </ol>
     </ItemTemplate>
    </asp:Repeater>

    </div>
    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/RecipeWebSite/Recipes.xml" >
    </asp:XmlDataSource>
    </form>

				
</body> 
</html>
