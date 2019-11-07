<%@ Page Language="C#"  EnableViewStateMac="false" ViewStateEncryptionMode="Never"%>
<%@ Import Namespace="System.Net.Mail" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="NReco.PivotData" %>
<%@ Import Namespace="NReco.PivotData.Output" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    <head>
        <meta charset="utf-8" />
        <title>PivotData WebForms Demo</title>
        
		<meta http-equiv="X-UA-Compatible" content="IE=edge"/>

		<link href="//netdna.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />
		<script type="text/javascript" src="//code.jquery.com/jquery-2.1.4.min.js"></script>
		<script type="text/javascript" src="//netdna.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
		
		<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

		<style>
			table.pvtTable {
				font-size:11px;
			}
			th.pvtColumn {
				text-align:center;
			}
			td.totalValue {
				font-weight:bold;
			}
		</style>
    </head>
    <body>	

		<div class="container-fluid">
			<form runat="server">
				<asp:ScriptManager ID="scriptMgr" runat="server"/>

				<script type="text/javascript">
					Sys.WebForms.PageRequestManager.getInstance()._updatePanelBase = Sys.WebForms.PageRequestManager.getInstance()._updatePanel;
					Sys.WebForms.PageRequestManager.getInstance()._updatePanel = function (updatePanelElement, rendering) {
						this._updatePanelBase(updatePanelElement, rendering);
						/* Eval JS patch */
						var scriptElements = updatePanelElement.getElementsByTagName('script');
						for (var veryUniqueIndex = 0; veryUniqueIndex < scriptElements.length; veryUniqueIndex++) {
							var scriptType = $(scriptElements[veryUniqueIndex]).attr('type');
							if (scriptElements[veryUniqueIndex].innerHTML.length > 0 && (scriptType == null || typeof (scriptType) != 'string' || scriptType.toLowerCase() == "text/javascript" || scriptType.toLowerCase() == ''))
								eval(scriptElements[veryUniqueIndex].innerHTML);
						}
					};
				</script>

				<asp:UpdatePanel ID="updPanel" runat="server">
					<ContentTemplate>
						<%@ Register TagPrefix="CTRL" TagName="PivotTableControl" Src="~/Templates/PivotTableControl.ascx" %>
						<CTRL:PivotTableControl ID="pvtCtrl" runat="server"/>
					</ContentTemplate>
				</asp:UpdatePanel>
			</form>	
			<hr/>
		</div>

    </body>
</html>
