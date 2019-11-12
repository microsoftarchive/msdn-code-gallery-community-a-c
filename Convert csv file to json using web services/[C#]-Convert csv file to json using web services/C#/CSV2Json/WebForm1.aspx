<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CSV2Json.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="Scripts/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "CSV2JSON.asmx/csvtojson",
                dataType: "text",
                success: function (msg) {
                    $("#output").text(msg.d);
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="data">
    
    </div>
    </form>
</body>
</html>
