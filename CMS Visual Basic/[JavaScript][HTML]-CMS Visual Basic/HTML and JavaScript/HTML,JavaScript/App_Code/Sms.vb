'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Namespace WebApplication

	Public Module SmsManager
		Private FreeAvailable As Integer
		Private PaidAvailable As Integer
		Function SmsAvailable() As Integer
			Select Case WebServicesEnabledSendSMS
				Case Config.WebServicesSendSms.WwwWebservicexCom
					Return 1
			End Select
      Return 0
    End Function
		Function Send(ByVal User As User, ByVal PhoneNumber As String, ByVal Text As String) As SmsError
			Dim ReturnError As SmsError
			If SmsAvailable() Then
				Select Case WebServicesEnabledSendSMS
					Case Config.WebServicesSendSms.WwwWebservicexCom
						If PhoneNumber.Chars(0) = "+" Then
							PhoneNumber = Mid(PhoneNumber, 2)
						End If
						Dim Services As New com.webservicex.www.SendSMSWorld
						Dim CountryCode As String = Left(PhoneNumber, PhoneNumber.Length - 10)
						PhoneNumber = Right(PhoneNumber, 10)
						Select Case Services.sendSMS(User.Email, CountryCode, PhoneNumber, Text)
							Case "Message has been sent successfuly"
							Case Else
								ReturnError = SmsError.GenericError
						End Select
				End Select
			Else
				ReturnError = SmsError.ServiceNotAvailable
			End If
      Extension.Log("sms", 1000, User.Username, PhoneNumber, ReplaceBin(ReplaceBin(Text, vbCr, ""), vbLf, ""))
      Return ReturnError
    End Function
		Enum SmsError As Integer
			None = 0
			ServiceNotAvailable = 1
			PhoneNumberError = 2
			MessageError = 3
			NotCredit = 4
			OffLineWebServices = 5
			GenericError = 6
		End Enum

#If DEBUG Then
    Public EnabledSendSms As Boolean = False
#Else
		Public EnabledSendSms As Boolean = True
#End If

	End Module
End Namespace