Imports System.IO.Ports
Imports Microsoft.SPOT.Hardware
Imports SecretLabs.NETMF.Hardware
Imports SecretLabs.NETMF.Hardware.Netduino

Module Module1
    Private MotorPower As UInteger = 0
    Sub Main()
        Dim power = New PWM(Pins.GPIO_PIN_D9)
        Dim serial = New SerialPort("COM1", 9800, Parity.None, 8, StopBits.One)
        Dim motorIn8 = New OutputPort(Pins.GPIO_PIN_D8, False)

        AddHandler Serial.DataReceived, AddressOf serial_DataReceived
        motorIn8.Write(True)
        Do While (True)
            Try
                Dim value = MotorPower
                If (Not Serial.IsOpen) Then
                    Serial.Open()
                End If
                Power.SetPulse(20000, value)
                Thread.Sleep(1000)
            Catch ex As Exception
                Dim mes = ex.Message
            End Try
        Loop
    End Sub

    Private Sub serial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim serial = CType(sender, SerialPort)
            Dim data(10) As Byte
            Dim cmd = serial.Read(data, 0, data.Length)

            MotorPower = CType(CType(data(0), UInteger) * 100, UInteger)
            If (MotorPower > 20000) Then
                MotorPower = 20000
            End If
        Catch ex As Exception
            Dim mes = ex.Message
        End Try
    End Sub
End Module

Namespace Global.System
    <AttributeUsageAttribute(AttributeTargets.Method)>
    Public NotInheritable Class STAThreadAttribute
        Inherits Attribute

    End Class
End Namespace
