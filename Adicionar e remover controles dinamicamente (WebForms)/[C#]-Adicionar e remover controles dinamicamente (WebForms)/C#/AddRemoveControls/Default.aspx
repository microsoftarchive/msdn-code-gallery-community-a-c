<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AddRemoveControls.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
    body { width:100% }
    .legend { font-weight:bold; font-family:Verdana; vertical-align:middle; }
    #content {  position: relative;
                left: 50%;
                width: 740px;
                margin: 0 0 0 -370px; 
             }
    #tableDescription { width:647px}
    #message { vertical-align:middle; font-weight:bold; width:100%; text-align:center; padding-left:150px; }
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="content">
    <span id="message">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </span>

    <table id="tableDescription">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
    <ItemTemplate>
      <tr>
      <td class="legend">Description: </td>
      <td valign="middle">
            <table>
            <tr>
            <td>
                <asp:TextBox ID="txtDescription" Text='<%# Eval("DESCRIPTION").ToString() %>'  runat="server" Width="500px" ToolTip="Add new description"></asp:TextBox> 
            </td>
            <td>
                <asp:ImageButton ID="btnRemove" runat="server" ImageUrl="images/remove.png" ToolTip="Remove this description"  />                  
            </td>
            </tr>
            </table>
      </td>
      </tr>
    </ItemTemplate>
    </asp:Repeater>
    <tr>
    <td colspan="2" align="right">
            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="images/add.png" OnClick="btnAdd_Click" />
    </td>
    </tr>
    </table>
    

    </div>
    </form>
</body>
</html>
