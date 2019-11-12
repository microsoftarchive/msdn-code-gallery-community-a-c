<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartPage.aspx.cs" Inherits="WebChart.ChartPage" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" 
    namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="ColumnChart" runat="server" BackColor="WhiteSmoke" BackGradientStyle="TopBottom"
            BackSecondaryColor="White" BorderColor="26, 59, 105" BorderlineDashStyle="Solid"
            BorderWidth="2" Height="350px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            Palette="BrightPastel" Width="900px">
            <Legends>
                <asp:Legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1"
                    Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent"
                    Alignment="Center">
                </asp:Legend>
            </Legends>
            <BorderSkin SkinStyle="Emboss" />
            <Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series1">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series2">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series3">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series4">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series5">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series6">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series7">
                </asp:Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series8">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="Gainsboro" BackGradientStyle="TopBottom" BackSecondaryColor="White"
                    BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="Transparent">
                    <AxisY2 Interval="25" IsLabelAutoFit="False">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid Enabled="False" />
                    </AxisY2>
                    <AxisX2 Interval="25" IsLabelAutoFit="False">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid Enabled="False" />
                    </AxisX2>
                    <Area3DStyle Inclination="15" IsClustered="False" IsRightAngleAxes="False" LightStyle="Realistic"
                        Rotation="10" WallWidth="0" />
                    <AxisY LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>   
        <asp:Chart ID="PieChart" runat="server" BackColor="WhiteSmoke" BackGradientStyle="TopBottom"
            BackSecondaryColor="White" BorderColor="26, 59, 105" BorderlineDashStyle="Solid"
            BorderWidth="2" Height="350px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            Palette="BrightPastel" Width="900px">
            <Legends>
                <asp:Legend LegendStyle="Row" IsTextAutoFit="False" DockedToChartArea="ChartArea1"
                    Docking="Bottom" IsDockedInsideChartArea="False" Name="Default" BackColor="Transparent"
                    Alignment="Center">
                </asp:Legend>
            </Legends>
            <BorderSkin SkinStyle="Emboss" />
            <Series>
                <asp:Series BorderColor="180, 26, 59, 105" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea BackColor="Gainsboro" BackGradientStyle="TopBottom" BackSecondaryColor="White"
                    BorderColor="64, 64, 64, 64" Name="ChartArea1" ShadowColor="Transparent">
                    <AxisY2 Interval="25" IsLabelAutoFit="False">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid Enabled="False" />
                    </AxisY2>
                    <AxisX2 Interval="25" IsLabelAutoFit="False">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid Enabled="False" />
                    </AxisX2>
                    <Area3DStyle Inclination="15" IsClustered="False" IsRightAngleAxes="False" LightStyle="Realistic"
                        Rotation="10" WallWidth="0" />
                    <AxisY LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64">
                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                        <MajorGrid LineColor="64, 64, 64, 64" />
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>           
     
    </div>
    </form>
</body>
</html>
