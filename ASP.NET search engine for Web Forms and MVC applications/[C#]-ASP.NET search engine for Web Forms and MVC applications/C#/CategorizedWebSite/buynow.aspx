<%@ Page language="c#" AutoEventWireup="false"  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Buy <%= Page.Request.Params["title"] %> Now</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style> body{ font-family: book antiqua, batang; }
	            h3{ font-style: italic;}
		</style>
		<script type="text/javascript" src="/Keyoti_SearchEngine_Web_Common/SearchUnit_Highlighter.js"></script>
	</HEAD>
	<body bgcolor="#edc9ab">
		<div align="center">
			<table border="1" width='90%' bordercolor="#dc7d30">
				<tr>
					<td>
						<h1>Purchase From Our Site</h1>
					</td>
				</tr>
				<tr>
					<td align="right" bgcolor="#dc7d30">
						<h3>
							<%= Page.Request.Params["title"] %>
						</h3>
					</td>
				</tr>
				<tr>
					<td>
						<% if (Page.Request.Params["checkedStock"]==null) {%>
							<script>
							setTimeout("location.href='buynow.aspx?title=<%=Page.Request.Params["title"].ToString().Replace(" ", "%20")%>&checkedStock=true'", 1000);
							</script>
							Checking stock... please wait...
						<%  } else { %>
							<h3>So Sorry!</h3>
							We appreciate your interest in purchasing
							<%= Page.Request.Params["title"] %>
							, however at present we do not have this product in stock, please try again 
							later!
						<% } %>
						<br>
						<br>
						<br>
						<br>
						<br>
						<br>
						<a href="default.htm">Home</a>
					</td>
				</tr>
			</table>
		</div>
	</body>
</HTML>
