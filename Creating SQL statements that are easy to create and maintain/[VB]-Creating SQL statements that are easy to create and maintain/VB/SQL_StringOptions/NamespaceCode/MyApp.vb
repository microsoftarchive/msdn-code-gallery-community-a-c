Namespace My
    Partial Friend Class MyApplication
        ''' <summary>
        ''' Extracts strings from known project resources
        ''' </summary>
        ''' <param name="ResourceName">Embedded resource name</param>
        ''' <returns></returns>
        ''' <remarks>Resource must be marked as an embedded resource</remarks>
        Public Function ResourceText(ByVal ResourceName As String) As String
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
    End Class
End Namespace
