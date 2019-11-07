Imports System.Threading
Imports SBDBTControlVB.Common
Imports SBDBTControlVB.Models

Namespace ViewModels
    Public Class MainViewModel
        Implements INotifyPropertyChanged

        Private Context As SynchronizationContext = SynchronizationContext.Current
        Private WithEvents Ble As New BleModel()

        Public Sub New()
        End Sub

        Public Property Message As String
            Get
                Return Me.Ble.Message
            End Get
            Set(value As String)
                Me.Ble.Message = value
            End Set
        End Property

        Public Property DeviceName As String
            Get
                Return Common.Settings.DeviceName
            End Get
            Set(value As String)
                Common.Settings.DeviceName = value
                OnPropertyChanged()
            End Set
        End Property

        Private _ConnectBleCommand As RelayCommand(Of String)
        Public Property ConnectBleCommand As RelayCommand(Of String)
            Get
                If (_ConnectBleCommand Is Nothing) Then
                    _ConnectBleCommand = New RelayCommand(Of String)(
                            Async Sub(a)
                                Dim power = Integer.Parse(a) * 2
                                Me.Ble.Power = power
                                Await Me.Ble.Connect()
                            End Sub)
                End If
                Return _ConnectBleCommand
            End Get
            Set(value As RelayCommand(Of String))
                _ConnectBleCommand = value
            End Set
        End Property

        Private Sub Ble_PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Handles Ble.PropertyChanged
            Me.Context.Post(Sub(o)
                                OnPropertyChanged(e.PropertyName)
                            End Sub, Nothing)
        End Sub

        Public Event PropertyChanged(sender As Object,
                             e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class

End Namespace
