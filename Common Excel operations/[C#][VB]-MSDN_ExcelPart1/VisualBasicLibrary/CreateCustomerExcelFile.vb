Imports <xmlns="urn:schemas-microsoft-com:office:spreadsheet">
Imports <xmlns:o="urn:schemas-microsoft-com:office:office">
Imports <xmlns:x="urn:schemas-microsoft-com:office:excel">
Imports <xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
Imports <xmlns:html="http://www.w3.org/TR/REC-html40">
Public Class CreateCustomerExcelFile
    ''' <summary>
    ''' Create an xml file suitable for Excel to read in 2003 format.
    ''' Open the file, do a save as for .xlsx and done.
    ''' </summary>
    ''' <param name="pDataTable">DataTable to use for creating the WorkSheet</param>
    ''' <param name="pFileName">Path and file name to save results too</param>
    ''' <remarks>
    ''' Note the use of embedded expressions within this code to create
    ''' elements, setup column headers.
    ''' 
    ''' A decent effort is required to put this together but is extremely fast.
    ''' </remarks>
    Public Sub Demo(pDataTable As DataTable, pFileName As String)
        '
        ' Create row elements from the passed in data table
        ' EnumerableRowCollection(Of XElement)
        '
        Dim customers As EnumerableRowCollection(Of XElement) =
            From row In pDataTable.AsEnumerable
            Select
            <Row>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("CompanyName") %></Data></Cell>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("ContactName") %></Data></Cell>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("ContactTitle") %></Data></Cell>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("Address") %></Data></Cell>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("City") %></Data></Cell>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("PostalCode") %></Data></Cell>
                <Cell><Data ss:Type="String"><%= row.Field(Of String)("Country") %></Data></Cell>
            </Row>

        Dim columnCount As Integer = pDataTable.Columns.Count

        Dim document As XDocument =
        <?xml version="1.0"?>
        <?mso-application progid="Excel.Sheet"?>
        <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
            xmlns:o="urn:schemas-microsoft-com:office:office"
            xmlns:x="urn:schemas-microsoft-com:office:excel"
            xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
            xmlns:html="http://www.w3.org/TR/REC-html40">
            <DocumentProperties xmlns="urn:schemas-microsoft-com:office:office">
                <Author>Karen Payne</Author>
                <LastAuthor>Karen Payne</LastAuthor>
                <Title>Cool</Title>
                <Created>2018-02-25T01:16:35Z</Created>
                <Version>12.00</Version>
            </DocumentProperties>
            <ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
                <WindowHeight>12300</WindowHeight>
                <WindowWidth>21075</WindowWidth>
                <WindowTopX>240</WindowTopX>
                <WindowTopY>75</WindowTopY>
                <ProtectStructure>False</ProtectStructure>
                <ProtectWindows>False</ProtectWindows>
            </ExcelWorkbook>
            <Styles>
                <Style ss:ID="Default" ss:Name="Normal">
                    <Alignment ss:Vertical="Bottom"/>
                    <Borders/>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
                    <Interior/>
                    <NumberFormat/>
                    <Protection/>
                </Style>
                <Style ss:ID="s62">
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                        ss:Bold="1"/>
                </Style>
            </Styles>
            <Worksheet ss:Name="People">
                <Table ss:ExpandedColumnCount=<%= columnCount %> ss:ExpandedRowCount=<%= customers.Count + 1 %> x:FullColumns="1"
                    x:FullRows="1" ss:DefaultRowHeight="15">
                    <Row>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">Company</Data></Cell>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">Contact Name</Data></Cell>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">Contact Title</Data></Cell>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">Address</Data></Cell>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">City</Data></Cell>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">Postal Code</Data></Cell>
                        <Cell ss:StyleID="s62"><Data ss:Type="String">Country</Data></Cell>
                    </Row>
                    <%= customers %>
                </Table>
                <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                    <PageSetup>
                        <Header x:Margin="0.3"/>
                        <Footer x:Margin="0.3"/>
                        <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                    </PageSetup>
                    <Print>
                        <ValidPrinterInfo/>
                        <HorizontalResolution>600</HorizontalResolution>
                        <VerticalResolution>600</VerticalResolution>
                    </Print>
                    <Selected/>
                    <Panes>
                        <Pane>
                            <Number>3</Number>
                            <ActiveRow>4</ActiveRow>
                            <ActiveCol>1</ActiveCol>
                        </Pane>
                    </Panes>
                    <ProtectObjects>False</ProtectObjects>
                    <ProtectScenarios>False</ProtectScenarios>
                </WorksheetOptions>
            </Worksheet>
            <Worksheet ss:Name="Sheet2">
                <Table ss:ExpandedColumnCount="1" ss:ExpandedRowCount="1" x:FullColumns="1"
                    x:FullRows="1" ss:DefaultRowHeight="15">
                </Table>
                <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                    <PageSetup>
                        <Header x:Margin="0.3"/>
                        <Footer x:Margin="0.3"/>
                        <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                    </PageSetup>
                    <ProtectObjects>False</ProtectObjects>
                    <ProtectScenarios>False</ProtectScenarios>
                </WorksheetOptions>
            </Worksheet>
            <Worksheet ss:Name="Sheet3">
                <Table ss:ExpandedColumnCount="1" ss:ExpandedRowCount="1" x:FullColumns="1"
                    x:FullRows="1" ss:DefaultRowHeight="15">
                </Table>
                <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                    <PageSetup>
                        <Header x:Margin="0.3"/>
                        <Footer x:Margin="0.3"/>
                        <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                    </PageSetup>
                    <ProtectObjects>False</ProtectObjects>
                    <ProtectScenarios>False</ProtectScenarios>
                </WorksheetOptions>
            </Worksheet>
        </Workbook>

        document.Save(pFileName)

    End Sub

End Class
