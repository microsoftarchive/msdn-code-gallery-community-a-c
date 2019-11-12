<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Highlight.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.WebForms.VB.DocumentViewer.HighlightPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Auto searching and highlighting keywords</title>
</head>
<body style="margin: 20px;">

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True"
        Document="~/App_Data/ExampleFiles/Default.doc"        
        SearchOptions-Term="ancient mariner"
        SearchOptions-MatchOptions="MatchAnyWord" />

</body>
</html>
