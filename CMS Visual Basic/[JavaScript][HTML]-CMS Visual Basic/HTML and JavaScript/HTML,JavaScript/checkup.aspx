<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="checkup.aspx.vb" Inherits="CheckUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false" BorderWidth="1px">
	<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="DDos Attacks Blocked:"></asp:Label>
	<br />
	<asp:PlaceHolder ID="DDoSIp" runat="server"></asp:PlaceHolder>
	</asp:Panel>
	<br />
	<asp:PlaceHolder ID="UserStats" runat="server"></asp:PlaceHolder>
	<table>
		<tr>
            <th colspan="2">
                Current server
            </th>
		</tr>
        <tr>
			<td style="text-align: right">
				Path
			</td>
			<td style="text-align: left">
				<asp:Label ID="Path" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Computer name
			</td>
			<td style="text-align: left">
				<asp:Label ID="ComputerName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Multi Server
			</td>
			<td style="text-align: left">
				<asp:Label ID="MultiServer" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Disk frees pace
			</td>
			<td style="text-align: left">
				<asp:Label ID="DiskFreeSpace" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Available Physical Memory
			</td>
			<td style="text-align: left">
				<asp:Label ID="AvailablePhysicalMemory" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Available Virtual Memory
			</td>
			<td style="text-align: left">
				<asp:Label ID="AvailableVirtualMemory" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Total Physical Memory
			</td>
			<td style="text-align: left">
				<asp:Label ID="TotalPhysicalMemory" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Total Virtual Memory
			</td>
			<td style="text-align: left">
				<asp:Label ID="TotalVirtualMemory" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				OS Full Name
			</td>
			<td style="text-align: left">
				<asp:Label ID="OSFullName" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				OS Platform
			</td>
			<td style="text-align: left">
				<asp:Label ID="OSPlatform" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				OS Version
			</td>
			<td style="text-align: left">
				<asp:Label ID="OSVersion" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Time on server
			</td>
			<td style="text-align: left">
				<asp:Label ID="TimeServer" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Time on server UTC
			</td>
			<td style="text-align: left">
				<asp:Label ID="TimeUTC" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Skypecast Failed Acquire
			</td>
			<td style="text-align: left">
				<asp:Label ID="SkypecastFailAcquire" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Server Time Out
			</td>
			<td style="text-align: left">
				<asp:Label ID="ServerTimeOut" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				IP Address
			</td>
			<td style="text-align: left">
				<asp:Label ID="IP" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
    <br />
	<table id="Performance" runat="server">
		<tr>
            <th colspan="2">
                Performance of server
            </th>
		</tr>
		<tr>
			<td style="text-align: right">
				Benchmark 7zip
			</td>
			<td style="text-align: left">
				<asp:Label ID="Benchmark" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				CPU Average last 60 sec.
			</td>
			<td style="text-align: left">
                <div id='ChartCpuAverage'></div>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				CPU Usage last 60 sec.
			</td>
			<td style="text-align: left; width: 100%;">
                <div id='ChartCpuUsage60Sec'></div>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				CPU Usage last 24 h.
			</td>
			<td style="text-align: left; width: 100%;">
                <div id='ChartCpuUsage24H'></div>
			</td>
		</tr>
	</table>
    <br />
	<table>
		<tr>
            <th colspan="2">
                Diagnostic
            </th>
		</tr>
		<tr>
			<td style="text-align: right">
				Error Disk Space Preserved
			</td>
			<td style="text-align: left">
				<asp:Label ID="ErrorDiskSpacePreserved" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Domains fail connected
			</td>
			<td style="text-align: left">
				<asp:PlaceHolder ID="DomainsNotConnected" runat="server"></asp:PlaceHolder>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Domains fail response
			</td>
			<td style="text-align: left">
				<asp:PlaceHolder ID="DomainsNotResponse" runat="server"></asp:PlaceHolder>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Currency Exchange
			</td>
			<td style="text-align: left">
				<asp:Label ID="ErrorExchangeRate" runat="server"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="text-align: right">
				Last SMTP Error
			</td>
			<td style="text-align: left">
				<asp:Label ID="ErrorSendEmail" runat="server"></asp:Label>
			</td>
		</tr>
	</table>
</asp:Content>
