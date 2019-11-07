<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Processing.aspx.vb" Inherits="GleamTech.ImageUltimateExamples.WebForms.VB.ProcessingPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.Examples" Assembly="GleamTech.Core" %>
<%@ Import Namespace="GleamTech.ImageUltimate.AspNet.WebForms" %>

<html>
<head runat="server">
    <title>Image Processing</title>
    <asp:PlaceHolder runat="server">
        <link href="<%=ExamplesConfiguration.GetVersionedUrl("~/resources/table.css")%>" rel="stylesheet" />
    </asp:PlaceHolder>
    <script type="text/javascript">
        function showImageSize(img, targetId) {
            if (!img.complete)
                return;
            if (typeof img.naturalWidth != "undefined" && img.naturalWidth === 0)
                return;

            var width = img.naturalWidth || img.width;
            var height = img.naturalHeight || img.height;

            document.getElementById(targetId).innerHTML = width + "x" + height;
        }
    </script>
</head>
<body style="margin: 20px;">
    
    <form id="form1" runat="server">
        <GleamTech:ExampleFileSelectorControl ID="exampleFileSelector" runat="server"
            InitialFile="JPG Image.jpg"
            FormWrapped="False" />

        <p>
            Choose task: <asp:DropDownList ID="TaskSelector" runat="server" AutoPostBack="true"></asp:DropDownList>
        </p>
    </form>

    <table class="info image">
        <caption>Resulting Image (<span id="outputSize"></span>)</caption>
        <tr>
            <td><%=Me.ImageTag(ImagePath, TaskAction, New With { .onload="showImageSize(this, 'outputSize')"})%></td>
        </tr>
    </table>

    <table class="info image">
        <caption>Original Image (Resized to <span id="inputSize"></span>)</caption>
        <tr>
            <td><%=Me.ImageTag(ImagePath, Function(task) task.ResizeWidth(400), New With { .onload="showImageSize(this, 'inputSize')"})%></td>
        </tr>
    </table>
    
    <div class="clear"></div>

    <table class="info">
        <caption>Code</caption>
        <tr>
            <td><pre><%=CodeString%></pre></td>
        </tr>
    </table>
    
    <div class="clear"></div>

    <table class="info">
        <caption>Resulting Image Url</caption>
        <tr>
            <td><pre><%=Me.ImageUrl(ImagePath, TaskAction)%></pre></td>
        </tr>
    </table>

</body>
</html>
