Namespace Common
    Public Class Settings
        Public Shared Property DeviceName As String
            Get
                If Windows.Storage.ApplicationData.Current.LocalSettings.Values.ContainsKey("DeviceName") Then
                    If Windows.Storage.ApplicationData.Current.LocalSettings.Values("DeviceName").ToString.Length > 0 Then
                        Return Windows.Storage.ApplicationData.Current.LocalSettings.Values("DeviceName").ToString
                    Else
                        Return "SBDBT-001bdc05bf3f"
                    End If
                Else
                    Return "SBDBT-001bdc05bf3f"
                End If
            End Get
            Set(value As String)
                If value IsNot Nothing Then
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values("DeviceName") = value
                Else
                    Windows.Storage.ApplicationData.Current.LocalSettings.Values("DeviceName") = ""
                End If
            End Set
        End Property
    End Class
End Namespace
