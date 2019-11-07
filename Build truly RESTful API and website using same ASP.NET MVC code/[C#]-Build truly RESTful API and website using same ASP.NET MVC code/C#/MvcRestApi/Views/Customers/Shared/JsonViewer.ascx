<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl"  %>

<script type="text/javascript">
    function prepareForJsonCall() {
        $("#jsonViewer").val("Posting...");
        var url = $("#jsonUrl").val();
        if (url.indexOf("?") < 0)
            url += "?";
        else
            url += "&";
        url += $("#jsonAdditionalQueryString").val();
        return url;
    }
    function renderJson(data) {
        var json = JSON.stringify(data);
        //alert("Received: \n" + json);
        $("#jsonViewer").val(json);
    }
    $(document).ready(function () {
        $("#jsonUrl").val(document.location.href);
        $("#jsonPostUrl").text(document.location.href);
        $.getJSON(document.location.href, function (data) {
            renderJson(data);
        });

        $("#saveJson").click(function () {
            var json = $("#jsonViewer").val();
            url = prepareForJsonCall();
            
        
            $.ajax({
                url: url,
                type: 'POST',
                dataType: 'json',
                data: json,
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    renderJson(data);
                }
            });
        });

        $("#deleteJson").click(function () {
            prepareForJsonCall();
            $.ajax({
                url: document.location.href,
                type: 'DELETE',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    renderJson(data);
                }
            });
        });
    });
</script>

<hr />
<p>JSON received from: <input id="jsonUrl" type="text" value="" size="50" /></p>
<textarea id="jsonViewer" name="code" class="javascript" cols="80" rows="10">

</textarea>
<br />
Post to:
<span id="jsonPostUrl"></span>?<input type="text" id="jsonAdditionalQueryString" value="" size="10" />
<input id="saveJson" type="button" value="Post" />
<br />
<input id="deleteJson" type="button" value="Delete" />