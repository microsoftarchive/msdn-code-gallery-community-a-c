<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl"  %>

<script type="text/javascript">
    function prepareForXmlCall() {        
        $("#xmlViewer").val("Posting...");
        var url = $("#xmlUrl").val();
        if (url.indexOf("?") < 0)
            url += "?";
        else
            url += "&";
        url += $("#xmlAdditionalQueryString").val();
        return url;
    }
    function renderXml(data) {
        var xml = window.ActiveXObject ? data.xml : (new XMLSerializer().serializeToString(data));
        $("#xmlViewer").val(xml);
    }

    $(document).ready(function () {
        $("#xmlUrl").val(document.location.href);
        $("#xmlPostUrl").text(document.location.href);
        
        $.ajax({
            url: document.location.href,
            type: "GET",
            data: null,
            dataType: "xml",
            success: function (data) {
                renderXml(data);
            }
        });

        $("#saveXml").click(function () {
            var xml = $("#xmlViewer").val();
            var url = prepareForXmlCall();
            
            $.ajax({
                url: url,
                type: "POST",
                dataType: "xml",
                data: xml,
                contentType: "text/xml",
                processData: false,
                success: function (data) {
                    renderXml(data);
                }
            });
        });

        $("#deleteXml").click(function () {
            prepareForXmlCall();

            $.ajax({
                url: document.location.href,
                type: "DELETE",
                dataType: "xml",
                contentType: "text/xml",
                processData: false,
                success: function (data) {
                    renderXml(data);
                }
            });
        });
    });
</script>

<hr />
<p>XML received from: <input id="xmlUrl" type="text" value="" size="50" /></p>
<textarea id="xmlViewer" name="code" class="javascript" cols="80" rows="10">

</textarea>
<br />
Post to:
<span id="xmlPostUrl"></span>?<input type="text" id="xmlAdditionalQueryString" value="" size="10" />
<input id="saveXml" type="button" value="Post" />
<br />
<input id="deleteXml" type="button" value="Delete" />

