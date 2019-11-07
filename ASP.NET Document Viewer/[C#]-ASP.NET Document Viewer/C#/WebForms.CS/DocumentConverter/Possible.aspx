<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Possible.aspx.cs" Inherits="GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentConverter.PossiblePage" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Possible conversions</title>
    <script type="text/javascript">
        function canConvert(sender) {
            var inputFormats = document.getElementById("InputFormats");
            if (inputFormats.selectedIndex === -1)
                inputFormats.selectedIndex = 0;
            var inputFormat = inputFormats.options[inputFormats.selectedIndex].value;
            var outputFormats = document.getElementById("OutputFormats");
            if (outputFormats.selectedIndex === -1)
                outputFormats.selectedIndex = 0;
            var outputFormat = outputFormats.options[outputFormats.selectedIndex].value;

            var iframe = document.getElementById("resultIframe");
            (iframe.contentDocument || iframe.contentWindow.document).documentElement.innerHTML = "";
            iframe.className = "loading";
            iframe.contentWindow.location.replace(
                document.getElementById("resultHandlerUrl").value +
                "&inputFormat=" + inputFormat +
                "&outputFormat=" + outputFormat);
        }

        function load(sender) {
            sender.className = "";
        }
    </script>
    <style>
        .loading {
            background: url('data:image/gif;base64,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') center center no-repeat;
        }
    </style>
</head>
<body style="margin: 20px;">
   
    <div style="text-align: center; display:inline-block; width: 800px">
        <div style="float: left;">
            <p>Input formats (<%=InputFormatCount%>):</p>
            <asp:Repeater ID="InputFormats" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <select id="<%=InputFormats.ClientID %>" size="20">
                </HeaderTemplate>
                <ItemTemplate>
                        <optgroup label="<%# Eval("Key") %>">
                            <asp:Repeater runat="server" DataSource='<%# Eval("Value") %>'>
                                <ItemTemplate>
                                    <option value="<%# Eval("Value") %>"><%# Eval("Text") %></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </optgroup>
                </ItemTemplate>
                <FooterTemplate>
                    </select>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="float: right; margin-left:20px">
            <p>Output formats (<%=OutputFormatCount%>):</p>
            <asp:Repeater ID="OutputFormats" runat="server" EnableViewState="False">
                <HeaderTemplate>
                    <select id="<%=OutputFormats.ClientID %>" size="20">
                </HeaderTemplate>
                <ItemTemplate>
                        <optgroup label="<%# Eval("Key") %>">
                            <asp:Repeater runat="server" DataSource='<%# Eval("Value") %>'>
                                <ItemTemplate>
                                    <option value="<%# Eval("Value") %>"><%# Eval("Text") %></option>
                                </ItemTemplate>
                            </asp:Repeater>
                        </optgroup>
                </ItemTemplate>
                <FooterTemplate>
                    </select>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div style="clear: both;"></div>
        <p>
            <input type="hidden" value="<%=ResultHandlerUrl %>" id="resultHandlerUrl"/>
            <input type="button" value="Can convert?" id="canConvertButton" onclick="canConvert(this)"/>
        </p>
        <iframe id="resultIframe" src="javascript:''" style="width: 400px; height: 100px; background-color: white" onload="load(this)"></iframe>
   </div>

</body>
</html>
