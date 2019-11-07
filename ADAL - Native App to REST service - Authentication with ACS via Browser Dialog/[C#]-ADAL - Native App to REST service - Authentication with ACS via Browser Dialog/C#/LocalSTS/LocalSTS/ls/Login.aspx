<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LocalSTS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AAL Test STS Login</title>
    <style type="text/css">
<!--
.pagecontents {
    font-family: "Segoe UI Light", "Segoe UI", "Ubuntu Beta";
}
-->
</style>
</head>
<body>
    <div class="pagecontents">
    <p>
        <h1 align="center">AAL Test STS</h1>
    </p>
    <p>
    This page is part of a sample project demonstrating how to perform interactive 
    authentication from a rich client using ACS. <br>
    You can login with one of the following accounts:<br>
    </p>
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;adam@treyresearch.com<br>
    &nbsp;&nbsp;&nbsp;&nbsp;mary@treyresearch.com
    </p>    
    The password for both users is <b>Passw0rd!</b><br>
    Note: Adam belongs to the Sales group. In the sample scenario, this affords him special privileges.
    </p>

    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" DisplayRememberMe="False" TitleText="" 
            onauthenticate="Login1_Authenticate">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" MaxLength="64" Width="200px" 
                                            Font-Names="Segoe UI Light"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                            ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                            ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" MaxLength="64" TextMode="Password" 
                                            Width="200px" Font-Names="Segoe UI Light"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                            ControlToValidate="Password" ErrorMessage="Password is required." 
                                            ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                            ValidationGroup="Login1" Font-Names="Segoe UI Light" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </form>
    </div>
</body>
</html>