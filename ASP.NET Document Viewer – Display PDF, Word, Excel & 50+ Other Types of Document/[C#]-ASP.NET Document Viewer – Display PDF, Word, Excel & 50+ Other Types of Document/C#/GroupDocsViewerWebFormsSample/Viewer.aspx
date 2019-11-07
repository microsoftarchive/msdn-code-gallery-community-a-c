<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viewer.aspx.cs" Inherits="GroupDocsViewerWebFormsSample.Viewer" %>
<%@ Import Namespace="Groupdocs.Web.UI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Displaying a <%= this.Filename %> document in the <%= this.Mode ? "HTML" : "image" %>-based mode</title>
    <%=Viewer.CreateScriptLoadBlock().LoadJquery(true).LoadJqueryUi(true).UseHttpHandlers()%>
    <style>
            /*body, html {
                height: 100%;
            }*/
            body {
                overflow:  hidden;
            }
    </style>
</head>
<body>
        <div id="viewer" style="width: 100%; height: 100%; /*position: relative;margin-bottom: 20px;*/"></div>
        <%= Viewer.ClientCode()
            .TargetElementSelector("#viewer")
            .FilePath(this.Filename)
            .UseHtmlBasedEngine(this.Mode)
            .UseInnerThumbnails(false).OpenThumbnails(false)
            .SupportPageRotation()
        %>
        <script type="text/javascript">
            function Check() {
                var new_width = $(window).width();
                $("#viewer").groupdocsViewer("setWidth", new_width - 10);
                var threshold = 860;
                if (new_width < threshold) {
                    var new_zoom = new_width * 100 / threshold;
                    $("#viewer").groupdocsViewer("setZoom", new_zoom);
                } else {
                    $("#viewer").groupdocsViewer("setZoom", 100);
                }
            }
            $(document).ready(function () {
                $(document).bind('touchstart,touchmove', function (e) {
                    e.preventDefault();
                });
                var containerElement = $("#viewer");
                containerElement.groupdocsViewer("on", "documentLoadCompleted.groupdocs",
                function (e) {
                    Check();
                });
            });

            $(window).resize(function () {
                Check();
            });
        </script>
</body>
</html>
