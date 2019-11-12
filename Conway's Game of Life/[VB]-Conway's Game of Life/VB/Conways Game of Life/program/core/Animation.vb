Imports System.Threading

Public Class Animation

    Private gridControl As exDGV
    Private cellValues(99)() As Integer
    Public cancelled As Boolean = False

    Public Sub New(dgv As exDGV)
        Me.gridControl = dgv
        For r As Integer = 0 To 99
            ReDim cellValues(r)(99)
        Next
    End Sub

    Private Sub clear()
        For r As Integer = 0 To 99
            For c As Integer = 0 To 99
                cellValues(r)(c) = 0
            Next
        Next
    End Sub

    Private Sub repaint()
        If cancelled Then Return
        For r As Integer = 0 To 99
            For c As Integer = 0 To 99
                If cellValues(r)(c) > 0 Then
                    gridControl.Rows(r).Cells(c).Style.BackColor = Color.Black
                Else
                    gridControl.Rows(r).Cells(c).Style.BackColor = Color.White
                End If
            Next
        Next
    End Sub

    Public Sub setSeed(ByVal x As Integer)
        cancelled = True
        clear()

        Select Case x
            Case 1 'diamond
                For r As Integer = 47 To 48
                    For c As Integer = 49 To 50
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 49 To 50
                    For c As Integer = 49 To 50
                        cellValues(r)(c) = -1
                    Next c
                Next r
                For r As Integer = 49 To 50
                    For c As Integer = 51 To 52
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 51 To 52
                    For c As Integer = 49 To 50
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 49 To 50
                    For c As Integer = 47 To 48
                        cellValues(r)(c) = 1
                    Next c
                Next r
            Case 2 'square
                For r As Integer = 48 To 51
                    For c As Integer = 48 To 51
                        cellValues(r)(c) = 1
                    Next c
                Next r
            Case 3 'cross
                For r As Integer = 47 To 48
                    For c As Integer = 47 To 48
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 47 To 48
                    For c As Integer = 51 To 52
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 49 To 50
                    For c As Integer = 49 To 50
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 51 To 52
                    For c As Integer = 47 To 48
                        cellValues(r)(c) = 1
                    Next c
                Next r
                For r As Integer = 51 To 52
                    For c As Integer = 51 To 52
                        cellValues(r)(c) = 1
                    Next c
                Next r
        End Select
        cancelled = False
        repaint()
        cancelled = True

    End Sub

    Public Sub animate(ByVal index As Integer)
        cancelled = False
        Dim l As Integer = 0
        Dim t As Integer = 0
        Dim r As Integer = 0
        Dim b As Integer = 0
        Select Case index
            Case 1, 3
                t = 47
                b = 52
                l = 47
                r = 52
            Case 2
                t = 48
                b = 51
                l = 48
                r = 51
        End Select
        Dim g As Integer = 2
        Do While Not cancelled
            For y As Integer = t To b
                For x As Integer = l To r
                    If cancelled Then
                        Return
                    End If
                    If cellValues(y)(x) > 0 AndAlso cellValues(y)(x) < g Then
                        grow(g, y, x)
                    End If
                Next x
            Next y
            'Pause for 50 milliseconds
            Thread.Sleep(50)
            For y As Integer = t To b
                For x As Integer = l To r
                    If cancelled Then
                        Return
                    End If
                    If cellValues(y)(x) > 0 AndAlso cellValues(y)(x) < g Then
                        Dim count As Integer = surrounding(y, x)
                        If count < 2 Then
                            cellValues(y)(x) = -1
                        ElseIf count > 3 Then
                            cellValues(y)(x) = -1
                        End If
                    End If
                Next x
            Next y
            'Pause for 50 milliseconds
            Thread.Sleep(50)
            For y As Integer = t To b
                For x As Integer = l To r
                    If cancelled Then
                        Return
                    End If
                    If cellValues(y)(x) = -1 Then
                        Dim count As Integer = surrounding(y, x)
                        If count = 3 Then
                            cellValues(y)(x) = 1
                        End If
                    End If
                Next x
            Next y
            'Pause for 50 milliseconds
            Thread.Sleep(50)
            t -= 1
            l -= 1
            b += 1
            r += 1
            g += 1
            If t < 0 OrElse l < 0 Then
                cancelled = True
            End If
            repaint()
        Loop
    End Sub

    Private Sub grow(ByVal g As Integer, ByVal r As Integer, ByVal c As Integer)
        If r > 0 Then
            If cellValues(r - 1)(c) = 0 Then
                cellValues(r - 1)(c) = g
            End If
            If c > 0 Then
                If cellValues(r - 1)(c - 1) = 0 Then
                    cellValues(r - 1)(c - 1) = g
                End If
            End If
            If c < 99 Then
                If cellValues(r - 1)(c + 1) = 0 Then
                    cellValues(r - 1)(c + 1) = g
                End If
            End If
        End If
        If c > 0 Then
            If cellValues(r)(c - 1) = 0 Then
                cellValues(r)(c - 1) = g
            End If
        End If
        If c < 99 Then
            If cellValues(r)(c + 1) = 0 Then
                cellValues(r)(c + 1) = g
            End If
        End If
        If r < 99 Then
            If cellValues(r + 1)(c) = 0 Then
                cellValues(r + 1)(c) = g
            End If
            If c > 0 Then
                If cellValues(r + 1)(c - 1) = 0 Then
                    cellValues(r + 1)(c - 1) = g
                End If
            End If
            If c < 99 Then
                If cellValues(r + 1)(c + 1) = 0 Then
                    cellValues(r + 1)(c + 1) = g
                End If
            End If
        End If
    End Sub

    Private Function surrounding(ByVal r As Integer, ByVal c As Integer) As Integer
        Dim count As Integer = 0
        If r > 0 Then
            If cellValues(r - 1)(c) > 0 Then
                count += 1
            End If
            If c > 0 Then
                If cellValues(r - 1)(c - 1) > 0 Then
                    count += 1
                End If
            End If
            If c < 99 Then
                If cellValues(r - 1)(c + 1) > 0 Then
                    count += 1
                End If
            End If
        End If
        If c > 0 Then
            If cellValues(r)(c - 1) > 0 Then
                count += 1
            End If
        End If
        If c < 99 Then
            If cellValues(r)(c + 1) > 0 Then
                count += 1
            End If
        End If
        If r < 99 Then
            If cellValues(r + 1)(c) > 0 Then
                count += 1
            End If
            If c > 0 Then
                If cellValues(r + 1)(c - 1) > 0 Then
                    count += 1
                End If
            End If
            If c < 99 Then
                If cellValues(r + 1)(c + 1) > 0 Then
                    count += 1
                End If
            End If
        End If

        Return count
    End Function

End Class
