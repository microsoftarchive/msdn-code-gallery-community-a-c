<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Protection.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer.ProtectionPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Copy protection (DRM)</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.pdf"
        DeniedPermissions="Download, DownloadAsPdf, Print, SelectText" />

</body>
</html>
