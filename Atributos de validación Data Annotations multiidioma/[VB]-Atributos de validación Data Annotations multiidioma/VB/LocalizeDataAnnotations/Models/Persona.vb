Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Persona
    Implements IPersona

    <Required(ErrorMessage:="Debe introducir un nombre")> _
    <DisplayName("Nombre")> _
    Public Property Nombre As String Implements IPersona.Nombre

    <DisplayName("Apellido")> _
    Public Property Apellido As String Implements IPersona.Apellido

    <DisplayName("Ciudad")> _
    <StringLength(20, MinimumLength:=4, ErrorMessage:="El nombre de Ciudad debe tener una longitud entre 4 y 20 caracteres")> _
    Public Property Ciudad As String Implements IPersona.Ciudad

    <DisplayName("Correo electrónico")> _
    Public Property Email As String Implements IPersona.Email

End Class
