Imports System.Data

Class MainWindow
    Public Sub New()
        InitializeComponent()
        showChart()
    End Sub
    Private Sub showChart()
        Dim MyValue As New List(Of KeyValuePair(Of String, Integer))()
        MyValue.Add(New KeyValuePair(Of String, Integer)("Administration", 20))
        MyValue.Add(New KeyValuePair(Of String, Integer)("Management", 36))
        MyValue.Add(New KeyValuePair(Of String, Integer)("Development", 89))
        MyValue.Add(New KeyValuePair(Of String, Integer)("Support", 270))
        MyValue.Add(New KeyValuePair(Of String, Integer)("Sales", 140))

        ColumnChart1.DataContext = MyValue
        AreaChart1.DataContext = MyValue
        LineChart1.DataContext = MyValue
        PieChart1.DataContext = MyValue
        BarChart1.DataContext = MyValue
        BubbleSeries1.DataContext = MyValue
        ScatterSeries1.DataContext = MyValue
    End Sub
End Class
