' Copyright © Microsoft Corporation.  All Rights Reserved.
' This code released under the terms of the 
' Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
'
' Copyright (c) Microsoft Corporation. All rights reserved.
Public Class Status

    Public Overloads Sub Show(ByVal message As String)
        lblStatus.Text = message
        Me.Show()
        Application.DoEvents()
    End Sub

End Class