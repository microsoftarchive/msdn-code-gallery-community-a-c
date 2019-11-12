<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display_Session_Variables.aspx.cs"
    Inherits="EvoHtmlToPdfDemo.HTML_to_PDF.Display_Session_Variables" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Session Variables</title>
    <link href="../styles/styles.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b style="font-size: 16px">The session variables</b><br />
        <br />
        <b>First Name:</b>&nbsp;<asp:Label ID="firstNameLabel" runat="server" Text=""></asp:Label><br />
        <b>Last Name:</b>&nbsp;<asp:Label ID="lastNameLabel" runat="server" Text=""></asp:Label><br />
        <b>Gender:</b>&nbsp;<asp:Label ID="genderLabel" runat="server" Text=""></asp:Label><br />
        <b>I have a car:</b>&nbsp;<asp:Label ID="haveCarLabel" runat="server" Text=""></asp:Label><br />
        <asp:Panel ID="carTypePanel" runat="server">
            <b>Car Type:</b>&nbsp;<asp:Label ID="carTypeLabel" runat="server" Text=""></asp:Label><br />
        </asp:Panel>
        <b>Comments:</b>&nbsp;<asp:Label ID="commentsLabel" runat="server" Text=""></asp:Label><br />
    </div>
    </form>
</body>
</html>
