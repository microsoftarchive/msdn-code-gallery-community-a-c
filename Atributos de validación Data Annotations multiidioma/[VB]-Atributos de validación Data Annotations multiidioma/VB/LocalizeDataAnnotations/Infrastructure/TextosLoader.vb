
Public NotInheritable Class TextosLoader

	Public Shared ReadOnly Property Apellido() As String
		Get
			Return TextosBBDD.Recuperar("Apellido")
		End Get
	End Property
	Public Shared ReadOnly Property Ciudad() As String
		Get
			Return TextosBBDD.Recuperar("Ciudad")
		End Get
	End Property
	Public Shared ReadOnly Property CiudadErrorLongitud() As String
		Get
			Return TextosBBDD.Recuperar("CiudadErrorLongitud")
		End Get
	End Property
	Public Shared ReadOnly Property Email() As String
		Get
			Return TextosBBDD.Recuperar("Email")
		End Get
	End Property
	Public Shared ReadOnly Property Nombre() As String
		Get
			Return TextosBBDD.Recuperar("Nombre")
		End Get
	End Property
	Public Shared ReadOnly Property NombreObligatorio() As String
		Get
			Return TextosBBDD.Recuperar("NombreObligatorio")
		End Get
	End Property

End Class