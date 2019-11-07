Namespace My
    <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
    Partial Friend Class _SQL
        ''' <summary>
        ''' Extracts strings from known project resources
        ''' </summary>
        ''' <param name="ResourceName">Embedded resource name</param>
        ''' <returns></returns>
        ''' <remarks>Resource must be marked as an embedded resource</remarks>
        Public Function ResourceContents(ByVal ResourceName As String) As String
            Dim TS As IO.Stream
            Dim ThePath As String = String.Concat(Application.Info.AssemblyName, ".", ResourceName)
            TS = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(ThePath)
            If Not (TS Is Nothing) Then
                Dim TextStream As New IO.StreamReader(TS)
                Dim Result As String

                Result = TextStream.ReadToEnd

                TS.Flush()
                TS = Nothing

                Return Result
            Else
                Return Nothing
            End If
        End Function
        Public Function Query1() As String
            Return ResourceContents("MainSelect1.sql")
        End Function
        Public Function GetSQL(ByVal Name As String) As String
            Return ResourceContents(Name)
        End Function
        ''' <summary>
        ''' Base name of database to backup or restore
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Name As String = ""
        Private mFullName As String = ""
        ''' <summary>
        ''' Path and name of database to backup too.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FullName As String
            Get
                If String.IsNullOrEmpty(mFullName) Then
                    mFullName = "" 'IO.Path.Combine(My.Computer.MyDocuments, Name)
                End If
                Return mFullName
            End Get
        End Property
    End Class
    <Global.Microsoft.VisualBasic.HideModuleName()> _
    Friend Module KSG_Database
        Private instance As New ThreadSafeObjectProvider(Of _SQL)
        ReadOnly Property SQL() As _SQL
            Get
                Return instance.GetInstance()
            End Get
        End Property
    End Module
End Namespace
