Imports System.ComponentModel.DataAnnotations
Imports LocalizeDataAnnotations.My.Resources

Public Class PersonaResource
    Implements IPersona

    <Required(ErrorMessageResourceName:="NombreObligatorio", ErrorMessageResourceType:=GetType(Textos))> _
    <Display(Name:="Nombre", ResourceType:=GetType(Textos))> _
    Public Property Nombre As String Implements IPersona.Nombre

    <Display(Name:="Apellido", ResourceType:=GetType(Textos))> _
    Public Property Apellido As String Implements IPersona.Apellido

    <Display(Name:="Ciudad", ResourceType:=GetType(Textos))> _
    <StringLength(20, MinimumLength:=4, ErrorMessageResourceName:="CiudadErrorLongitud", ErrorMessageResourceType:=GetType(Textos))> _
    Public Property Ciudad As String Implements IPersona.Ciudad

    <Display(Name:="Email", ResourceType:=GetType(Textos))> _
    Public Property Email As String Implements IPersona.Email

End Class
