Imports System.ComponentModel.DataAnnotations

Public Class Persona
    Property Nombre As String
    Property Apellido As String
    Property Ciudad As String
    <Display(Name:="Fecha de Nacimiento")> _
    <DataType(DataType.Date)> _
    Property FechaNacimiento As DateTime
    <Display(Name:="Último Acceso")> _
    Property UltimoAcceso As DateTime
    <Display(Name:="Fecha de Registro")> _
    <DataType(DataType.Date)> _
    Property FechaRegistro As DateTime
    <Display(Name:="Última Operación")> _
    Property UltimaOperacion As DateTime
End Class
