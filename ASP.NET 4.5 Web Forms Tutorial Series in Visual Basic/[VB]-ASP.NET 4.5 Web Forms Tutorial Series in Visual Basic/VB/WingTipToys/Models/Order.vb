Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

Public Class Order

    Public Property OrderId() As Integer

    Public Property OrderDate() As DateTime

    Public Property Username() As String

    <Required(ErrorMessage:="First Name is required")> _
    <DisplayName("First Name")> _
    <StringLength(160)> _
    Public Property FirstName() As String

    <Required(ErrorMessage:="Last Name is required")> _
    <DisplayName("Last Name")> _
    <StringLength(160)> _
    Public Property LastName() As String

    <Required(ErrorMessage:="Address is required")> _
    <StringLength(70)> _
    Public Property Address() As String

    <Required(ErrorMessage:="City is required")> _
    <StringLength(40)> _
    Public Property City() As String

    <Required(ErrorMessage:="State is required")> _
    <StringLength(40)> _
    Public Property State() As String

    <Required(ErrorMessage:="Postal Code is required")> _
    <DisplayName("Postal Code")> _
    <StringLength(10)> _
    Public Property PostalCode() As String

    <Required(ErrorMessage:="Country is required")> _
    <StringLength(40)> _
    Public Property Country() As String

    <StringLength(24)> _
    Public Property Phone() As String

    <Required(ErrorMessage:="Email Address is required")> _
    <DisplayName("Email Address")> _
    <RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage:="Email is is not valid.")> _
    <DataType(DataType.EmailAddress)> _
    Public Property Email() As String

    <ScaffoldColumn(False)> _
    Public Property Total() As Decimal

    <ScaffoldColumn(False)> _
    Public Property PaymentTransactionId() As String

    <ScaffoldColumn(False)> _
    Public Property HasBeenShipped() As Boolean

    Public Property OrderDetails() As List(Of OrderDetail)

End Class