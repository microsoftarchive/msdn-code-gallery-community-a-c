Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(StudentMetadata))>
    Partial Public Class Student
End Class

Public Class StudentMetadata
    <DisplayFormat(DataFormatString:="{0:d}", ApplyFormatInEditMode:=True)>
    Public Property EnrollmentDate As Date

    <StringLength(25, ErrorMessage:="First name must be 25 characters or less in length."), Required(ErrorMessage:="First name is required.")>
    Public Property FirstMidName As String

    <StringLength(25, ErrorMessage:="Last name must be 25 characters or less in length."), Required(ErrorMessage:="Last name is required.")>
    Public Property LastName As String
End Class
