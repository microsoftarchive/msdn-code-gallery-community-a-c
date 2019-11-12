Imports System.Security.Cryptography
Imports System.Management
Imports System.IO
''' <summary>
''' Demo. Copyprotect for Your Winform application
''' </summary>
''' <remarks>last update 2012-03-16</remarks>
Public Class MainForm1

    Private TripleDes As New TripleDESCryptoServiceProvider
    Private loginOK As Boolean = False
    Private myCode As Int64

  
#Region "formevents"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
                         Handles Me.Load

        'analyse data from system:
        Dim computername As String = My.Computer.Name
        Dim user As String = My.User.Name
        Dim driveSerial As String = GetDriveSerialNumber("C:")
        Dim coding As String = user & "\" & driveSerial & "\" & computername
        Dim cipherText As String = EncryptData(coding)
        Dim plainText As String = DecryptData(cipherText)

        'generate login code:
        Dim code As Int64 = generateCode(coding)
        Me.myCode = code ' für das assembly zur Verfügung stellen

        ' visualize data in Form
        TextBox1.Text = computername
        TextBox2.Text = user
        TextBox3.Text = driveSerial
        TextBox4.Text = coding              'full data string
        TextBox5.Text = cipherText          'encrypted data string 
        tbLogincode.Text = code.ToString    'login code (dez)
        TextBox7.Text = Hex(code)           'login code (hex)
        TextBox8.Text = plainText           'decrypt (test)
        PictureBox1.Image = My.Resources.Standby
        tbEnterLoginCode.Focus()

    End Sub

    ''' <summary>
    ''' login and start 
    ''' </summary>
    Private Sub btn_Check(ByVal sender As System.Object, _
                              ByVal e As System.EventArgs) Handles btnCeck.Click
        If Me.tbLogincode.Text = Me.tbEnterLoginCode.Text Then

            loginOK = True
            PictureBox1.Image = My.Resources.Ok
            MsgBox("Login successfull!")

            '************************************
            ' here condition to start any programm
            '************************************
        Else

            loginOK = False
            PictureBox1.Image = My.Resources.Standby
            MsgBox("Login failed!")

        End If
    End Sub

#End Region
#Region "ulitities"

    ''' <summary>
    ''' generate login code from computer data
    ''' </summary>
    ''' <param name="_coding">encryted string</param>
    ''' <returns>login code dez / string</returns>
    Private Function generateCode(ByVal _coding As String) As Int64
        Dim _code As Int64
        For I As Integer = 1 To Len(_coding)
            _code += (Asc(Mid(_coding, I, 1)) * 915734)
        Next
        Return _code
    End Function

    ''' <summary>
    ''' encrypt data
    ''' </summary>
    ''' <param name="plaintext">string to be encrypted</param>
    ''' <returns>encryted data</returns>
    Private Function EncryptData(ByVal plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms, _
            TripleDes.CreateEncryptor(), _
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    ''' <summary>
    ''' decrypt data
    ''' </summary>
    ''' <param name="encryptedtext">encrypted string</param>
    ''' <returns>plaint text</returns>
    Private Function DecryptData(ByVal encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms, _
            TripleDes.CreateDecryptor(), _
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

    ''' <summary>
    ''' get dirve serial number
    ''' </summary>
    ''' <param name="drive">C:</param>
    ''' <returns>drive serial</returns>
    Private Function GetDriveSerialNumber(ByVal drive As String) As String

        Dim driveSerial As String = String.Empty
        Dim driveFixed As String = System.IO.Path.GetPathRoot(drive)
        driveFixed = Replace(driveFixed, "\", String.Empty)

        Using querySearch As New ManagementObjectSearcher("SELECT VolumeSerialNumber FROM Win32_LogicalDisk Where Name = '" & driveFixed & "'")

            Using queryCollection As ManagementObjectCollection = querySearch.Get()

                Dim moItem As ManagementObject

                For Each moItem In queryCollection

                    driveSerial = CStr(moItem.Item("VolumeSerialNumber"))

                    Exit For
                Next
            End Using
        End Using
        Return driveSerial
    End Function
#End Region

End Class

