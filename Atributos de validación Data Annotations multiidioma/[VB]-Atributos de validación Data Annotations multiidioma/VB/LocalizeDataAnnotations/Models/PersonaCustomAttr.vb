Imports System.ComponentModel.DataAnnotations

Public Class PersonaCustomAttr
    Implements IPersona

    <CustomRequired(ErrorMessageResourceName:="NombreObligatorio")> _
    <CustomDisplay("Nombre")> _
    Public Property Nombre As String Implements IPersona.Nombre

    <CustomDisplay("Apellido")> _
    Public Property Apellido As String Implements IPersona.Apellido

    <CustomDisplay("Ciudad")> _
    <CustomStringLength(20, MinimumLength:=4, ErrorMessageResourceName:="CiudadErrorLongitud")> _
    Public Property Ciudad As String Implements IPersona.Ciudad

    <CustomDisplay("Email")> _
    Public Property Email As String Implements IPersona.Email

End Class
