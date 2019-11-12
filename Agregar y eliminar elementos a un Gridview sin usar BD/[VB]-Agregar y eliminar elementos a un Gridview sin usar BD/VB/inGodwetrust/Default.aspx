<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        id<asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
        <br />
        nombre<asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <br />
        telefono<asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
        <asp:Label ID="LblEstado" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Guardar Datos" />
&nbsp;&nbsp;
        <asp:Button ID="BtnRecorrer" runat="server" Text="Recorrer DataSet" />
        <br />
        <asp:GridView ID="GridDetalle" runat="server" AutoGenerateColumns="False" DataKeyNames="id">
            <Columns>
                <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" />
                            </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="Nombre" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="telefono" HeaderText="Telefono" />
            </Columns>
        </asp:GridView>
    
        <asp:Button ID="BtnQuitar" runat="server" Text="Quitar" />
    
    </div>
    </form>
</body>
</html>
