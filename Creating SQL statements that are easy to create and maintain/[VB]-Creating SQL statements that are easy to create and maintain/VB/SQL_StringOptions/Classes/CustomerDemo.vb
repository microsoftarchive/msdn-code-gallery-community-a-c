Public Class CustomerDemo
    Private mException As Exception
    Public ReadOnly Property LastException As Exception
        Get
            Return mException
        End Get
    End Property
    Public ReadOnly Property FileName As String
        Get
            Return IO.Path.Combine(Application.StartupPath, "Customers.txt")
        End Get
    End Property
    Public Sub New()
    End Sub
    Public Sub New(ByVal Purge As Boolean)
        If Purge Then
            RemoveFile()
        End If
    End Sub
    Public Sub RemoveFile()
        If IO.File.Exists(FileName) Then
            IO.File.Delete(FileName)
        End If
    End Sub
    ''' <summary>
    ''' Demo creating xml structure from DataTable rows and columns
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    ''' Sample how to use embedded expression against a DataTable
    ''' to create an xml structure. Normally you would output a .xml
    ''' file but in this case we want to quickly display the output
    ''' and by using .txt we can show the structure in notepad.
    ''' <remarks></remarks>
    Public Function CreateXmlDocument(ByVal dt As DataTable) As Boolean
        Dim Success As Boolean = True

        Try
            Dim Customers =
                <Customers>
                    <%=
                        From P In dt.AsEnumerable Select _
                        <Customer>
                            <CompanyName><%= P.Field(Of String)("Company") %></CompanyName>
                            <Contact><%= P.Field(Of String)("Contact") %></Contact>
                            <Country><%= P.Field(Of String)("Country") %></Country>
                        </Customer>
                    %>
                </Customers>

            Customers.Save(FileName)

        Catch ex As Exception
            mException = ex
            Success = False
        End Try

        Return Success

    End Function
End Class
