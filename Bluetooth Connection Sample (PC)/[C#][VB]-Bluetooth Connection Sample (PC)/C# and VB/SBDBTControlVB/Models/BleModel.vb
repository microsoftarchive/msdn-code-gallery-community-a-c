Imports Windows.Devices.Bluetooth.Rfcomm
Imports Windows.Devices.Enumeration
Imports Windows.Networking.Sockets
Imports Windows.Storage.Streams

Namespace Models
    Public Class BleModel
        Implements INotifyPropertyChanged

        Private DeviceService As RfcommDeviceService
        Private BtSocket As StreamSocket
        Private Writer As DataWriter

        Public Sub New()

        End Sub

        Private _Power As Integer? = Nothing
        Public Property Power As Integer?
            Get
                Return _Power
            End Get
            Set(value As Integer?)
                If (_Power Is Nothing OrElse _Power <> value) Then
                    _Power = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Private _Message As String = Nothing
        Public Property Message As String
            Get
                Return _Message
            End Get
            Set(value As String)
                If (_Power Is Nothing OrElse _Message <> value) Then
                    _Message = value
                    OnPropertyChanged()
                End If
            End Set
        End Property

        Public Async Function Connect() As Task
            Dim name = Common.Settings.DeviceName
            If (name IsNot Nothing) Then
                ''保存されたBluetoothデバイス名と一致するデバイス情報を取得しデータを送信する
                Dim serviceInfos = Await DeviceInformation.FindAllAsync(RfcommDeviceService.GetDeviceSelector(RfcommServiceId.SerialPort))
                For Each serviceInfo In serviceInfos
                    If (serviceInfo.Name = name) Then
                        Await Connect(serviceInfo)
                        Exit For
                    End If
                Next
            End If
        End Function

        Public Async Function Connect(serviceInfo As DeviceInformation) As Task
            Try
                ''指定されたデバイス情報で接続を行う
                If (DeviceService Is Nothing) Then
                    DeviceService = Await RfcommDeviceService.FromIdAsync(serviceInfo.Id)
                    BtSocket = New StreamSocket()
                    Await BtSocket.ConnectAsync(
                        Me.DeviceService.ConnectionHostName,
                        Me.DeviceService.ConnectionServiceName,
                        SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication)
                    Writer = New DataWriter(BtSocket.OutputStream)
                    Me.Message = "Connected " + DeviceService.ConnectionHostName.DisplayName
                End If
                ''接続されたBluetoothデバイスにデータを送信する
                SetPower(Me.Power)
            Catch ex As Exception
                Me.Message = ex.Message
                DeviceService = Nothing
            End Try
        End Function

        Private Async Sub SetPower(power As Integer?)
            Try
                If (DeviceService IsNot Nothing) Then
                    ''0 - 200の値を送信する
                    Dim moterPower = If(power <= 200, power, 200)
                    Dim byteArray() As Byte = {CType(moterPower, Byte)}
                    Writer.WriteBytes(byteArray)
                    Dim sendResult = Await Writer.StoreAsync()
                End If
            Catch ex As Exception
                Me.Message = ex.Message
                DeviceService = Nothing
            End Try
        End Sub

        Public Event PropertyChanged(sender As Object,
                             e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
        Protected Sub OnPropertyChanged(<CallerMemberName> Optional propertyName As String = Nothing)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
