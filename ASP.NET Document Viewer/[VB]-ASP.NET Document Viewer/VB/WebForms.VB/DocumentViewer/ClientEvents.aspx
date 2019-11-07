<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ClientEvents.aspx.vb" Inherits="GleamTech.DocumentUltimateExamples.WebForms.VB.DocumentViewer.ClientEventsPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.Examples" Assembly="GleamTech.Core" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.DocumentUltimate.AspNet.WebForms" Assembly="GleamTech.DocumentUltimate" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Client-side events</title>
    
    <script type="text/javascript">
        function documentViewerLoaded(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerFailed(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerDocumentLoaded(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPageChanged(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPageRendered(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerRotationChanged(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerDownloading(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPrinting(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPrintProgress(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerPrinted(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerTextSelected(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function documentViewerTextCopied(sender, e) {
            var documentViewer = sender;

            logEvent(e);
        }

        function logEvent(e) {
            var logTextBox = document.getElementById("LogTextBox");

            var now = new Date().toLocaleTimeString();
            var json = JSON.stringify(e, null, 2);
            logTextBox.value += "[" + now + "]" + "\nEvent arguments: " + json + "\n\n";
            logTextBox.scrollTop = logTextBox.scrollHeight;
        }

        function clearLog() {
            var logTextBox = document.getElementById("LogTextBox");

            logTextBox.value = "";
        }
    </script>
</head>
<body style="margin: 20px;">
    <GleamTech:ExampleFileSelectorControl ID="exampleFileSelector" runat="server"
        InitialFile="Default.pdf" />

    <p>
        Events:<br/>
        <textarea id="LogTextBox" style="width: 800px; height: 200px; background-color: white; border: 1px solid black"></textarea>
        <br /><input type="button" value="Clear" onclick="clearLog();" />
    </p>

    <GleamTech:DocumentViewerControl ID="documentViewer" runat="server" 
        Width="800" 
        Height="600"
        Resizable="True">
        
        <ClientEvents Loaded="documentViewerLoaded"
                      Failed="documentViewerFailed"
                      DocumentLoaded="documentViewerDocumentLoaded"
                      PageChanged="documentViewerPageChanged"
                      PageRendered="documentViewerPageRendered"
                      RotationChanged="documentViewerRotationChanged"
                      Downloading="documentViewerDownloading"
                      Printing="documentViewerPrinting"
                      PrintProgress="documentViewerPrintProgress"
                      Printed="documentViewerPrinted"
                      TextSelected="documentViewerTextSelected" 
                      TextCopied="documentViewerTextCopied" />

    </GleamTech:DocumentViewerControl>
    
</body>
</html>
