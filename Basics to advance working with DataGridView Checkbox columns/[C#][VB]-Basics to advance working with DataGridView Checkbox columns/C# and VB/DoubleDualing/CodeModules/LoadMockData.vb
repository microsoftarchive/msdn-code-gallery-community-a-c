Module LoadMockData
    Public Function GetMockedData() As DataTable
        Dim dt As New DataTable

        dt.Columns.AddRange(New DataColumn() _
            {
                New DataColumn With
                {
                    .ColumnName = "Identifier",
                    .AutoIncrement = True,
                    .AutoIncrementSeed = 1
                },
                New DataColumn("YesResponse", GetType(Boolean)),
                New DataColumn("NoResponse", GetType(Boolean)),
                New DataColumn("Question", GetType(String))
                }
            )

        dt.Rows.Add(New Object() {Nothing, False, True, "Do you have VS2012 installed?"})
        dt.Rows.Add(New Object() {Nothing, False, True, "Have you coded with LINQ?"})
        dt.Rows.Add(New Object() {Nothing, False, True, "Do you write WCF services?"})
        dt.Rows.Add(New Object() {Nothing, False, True, "Have you worked with C#"})
        dt.Rows.Add(New Object() {Nothing, False, True, "Do you use Entity Framework"})

        dt.AcceptChanges()

        Return dt

    End Function
End Module
