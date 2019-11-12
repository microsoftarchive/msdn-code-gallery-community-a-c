Imports System.ComponentModel.DataAnnotations

Public Class PersonaBBDD
    Implements IPersona

    <Required(ErrorMessageResourceName:="NombreObligatorio" _
        , ErrorMessageResourceType:=GetType(TextosLoader))> _
    <Display(Name:="Nombre", ResourceType:=GetType(TextosLoader))> _
    Public Property Nombre As String Implements IPersona.Nombre

    <Display(Name:="Apellido", ResourceType:=GetType(TextosLoader))> _
    Public Property Apellido As String Implements IPersona.Apellido

    <Display(Name:="Ciudad", ResourceType:=GetType(TextosLoader))> _
    <StringLength(20, MinimumLength:=4, ErrorMessageResourceName:="CiudadErrorLongitud" _
        , ErrorMessageResourceType:=GetType(TextosLoader))> _
    Public Property Ciudad As String Implements IPersona.Ciudad

    <Display(Name:="Email", ResourceType:=GetType(TextosLoader))> _
    Public Property Email As String Implements IPersona.Email

End Class
