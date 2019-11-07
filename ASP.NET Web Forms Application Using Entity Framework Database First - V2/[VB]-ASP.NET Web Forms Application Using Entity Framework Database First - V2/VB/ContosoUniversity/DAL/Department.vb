Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

<MetadataType(GetType(DepartmentMetaData))>
Partial Public Class Department
End Class

Public Class DepartmentMetaData
    <DataType(DataType.Currency), Range(0, 1000000, ErrorMessage:="Budget must be less than $1,000,000.00")>
    Public Property Budget() As Decimal

    <DisplayFormat(DataFormatString:="{0:d}", ApplyFormatInEditMode:=True)>
    Public Property StartDate() As Date

End Class