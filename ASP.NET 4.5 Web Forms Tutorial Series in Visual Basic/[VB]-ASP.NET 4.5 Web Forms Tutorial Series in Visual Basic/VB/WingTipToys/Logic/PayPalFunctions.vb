Imports System.Net
Imports System.IO

Public Class NVPAPICaller

    'Flag that determines the PayPal environment (live or sandbox)
    Private Const B_SANDBOX As Boolean = True
    Private Const CVV2 As String = "CVV2"

    ' Live strings.
    Private _pEndPointUrl As String = "https://api-3t.paypal.com/nvp"
    Private _host As String = "www.paypal.com"

    ' Sandbox strings.
    Private Const P_END_POINT_URL_SB As String = "https://api-3t.sandbox.paypal.com/nvp"
    Private Const HOST_SB As String = "www.sandbox.paypal.com"

    Private Const SIGNATURE As String = "SIGNATURE"
    Private Const PWD As String = "PWD"
    Private Const ACCT As String = "ACCT"

    'Replace <Your API Username> with your API Username
    'Replace <Your API Password> with your API Password
    'Replace <Your Signature> with your Signature
    Public ApiUserName As String = "WTS_1344290105_biz_api1.live.com"
    Private _apiPassword As String = "1344290129"
    Private _apiSignature As String = "AUrz5spHXetQp8oNaQrO9EIr8t1WA01cu3D6SSADhMtqQe7.CrNedIUH"
    Private _subject As String = ""
    Private Const BN_CODE As String = "PP-ECWizard"

    'HttpWebRequest Timeout specified in milliseconds 
    Private Const TIMEOUT As Integer = 15000
    Private Shared ReadOnly SecuredNvps As String() = New String() {ACCT, CVV2, SIGNATURE, PWD}

    Public Sub SetCredentials(ByVal userID As String, ByVal userPwd As String, ByVal userSignature As String)
        ApiUserName = userID
        _apiPassword = userPwd
        _apiSignature = userSignature
    End Sub

    Public Function ShortcutExpressCheckout(ByVal amt As String, ByRef token As String, ByRef retMsg As String) As Boolean

        If B_SANDBOX Then
            _pEndPointUrl = P_END_POINT_URL_SB
            _host = HOST_SB
        End If

        Const RETURN_URL As String = "http://localhost:53417/Checkout/CheckoutReview.aspx"
        Const CANCEL_URL As String = "http://localhost:53417/Checkout/CheckoutCancel.aspx"

        Dim encoder As New nvpCodec()
        encoder("METHOD") = "SetExpressCheckout"
        encoder("RETURNURL") = RETURN_URL
        encoder("CANCELURL") = CANCEL_URL
        encoder("BRANDNAME") = "Wingtip Toys Sample Application"
        encoder("PAYMENTREQUEST_0_AMT") = amt
        encoder("PAYMENTREQUEST_0_ITEMAMT") = amt
        encoder("PAYMENTREQUEST_0_PAYMENTACTION") = "Sale"
        encoder("PAYMENTREQUEST_0_CURRENCYCODE") = "USD"

        ' Get the Shopping Cart Products
        Dim myCartOrders As New ShoppingCartActions()
        Dim myOrderList As List(Of CartItem) = myCartOrders.GetCartItems()

        For i As Integer = 0 To myOrderList.Count - 1
            encoder("L_PAYMENTREQUEST_0_NAME" & i) = myOrderList(i).Product.ProductName
            encoder("L_PAYMENTREQUEST_0_AMT" & i) = myOrderList(i).Product.UnitPrice.ToString()
            encoder("L_PAYMENTREQUEST_0_QTY" & i) = myOrderList(i).Quantity.ToString()
        Next

        Dim pStrrequestforNvp As String = encoder.Encode()
        Dim pStresponsenvp As String = HttpCall(pStrrequestforNvp)

        Dim decoder As New nvpCodec()
        decoder.Decode(pStresponsenvp)

        Dim strAck As String = decoder("ACK").ToLower()
        If strAck IsNot Nothing AndAlso (strAck = "success" OrElse strAck = "successwithwarning") Then
            token = decoder("TOKEN")
            Dim ecurl As String = "https://" + _host + "/cgi-bin/webscr?cmd=_express-checkout" + "&token=" + token
            retMsg = ecurl
            Return True
        Else
            retMsg = "ErrorCode=" + decoder("L_ERRORCODE0") + "&" + "Desc=" + decoder("L_SHORTMESSAGE0") + "&" + "Desc2=" + decoder("L_LONGMESSAGE0")
            Return False
        End If
    End Function

    Public Function GetCheckoutDetails(ByVal token As String, ByRef payerID As String, ByRef decoder As nvpCodec, ByRef retMsg As String) As Boolean
        If B_SANDBOX Then
            _pEndPointUrl = P_END_POINT_URL_SB
        End If

        Dim encoder As New nvpCodec()
        encoder("METHOD") = "GetExpressCheckoutDetails"
        encoder("TOKEN") = token

        Dim pStrrequestforNvp As String = encoder.Encode()
        Dim pStresponsenvp As String = HttpCall(pStrrequestforNvp)

        decoder = New nvpCodec()
        decoder.Decode(pStresponsenvp)

        Dim strAck As String = decoder("ACK").ToLower()
        If strAck IsNot Nothing AndAlso (strAck = "success" OrElse strAck = "successwithwarning") Then
            payerID = decoder("PAYERID")
            Return True
        Else
            retMsg = "ErrorCode=" + decoder("L_ERRORCODE0") + "&" + "Desc=" + decoder("L_SHORTMESSAGE0") + "&" + "Desc2=" + decoder("L_LONGMESSAGE0")

            Return False
        End If
    End Function

    Public Function DoCheckoutPayment(ByVal finalPaymentAmount As String, ByVal token As String, ByVal payerID As String, ByRef decoder As nvpCodec, ByRef retMsg As String) As Boolean
        If B_SANDBOX Then
            _pEndPointUrl = P_END_POINT_URL_SB
        End If

        Dim encoder As New nvpCodec()
        encoder("METHOD") = "DoExpressCheckoutPayment"
        encoder("TOKEN") = token
        encoder("PAYERID") = payerID
        encoder("PAYMENTREQUEST_0_AMT") = finalPaymentAmount
        encoder("PAYMENTREQUEST_0_CURRENCYCODE") = "USD"
        encoder("PAYMENTREQUEST_0_PAYMENTACTION") = "Sale"

        Dim pStrrequestforNvp As String = encoder.Encode()
        Dim pStresponsenvp As String = HttpCall(pStrrequestforNvp)

        decoder = New nvpCodec()
        decoder.Decode(pStresponsenvp)

        Dim strAck As String = decoder("ACK").ToLower()
        If strAck IsNot Nothing AndAlso (strAck = "success" OrElse strAck = "successwithwarning") Then
            Return True
        Else
            retMsg = "ErrorCode=" + decoder("L_ERRORCODE0") + "&" + "Desc=" + decoder("L_SHORTMESSAGE0") + "&" + "Desc2=" + decoder("L_LONGMESSAGE0")

            Return False
        End If
    End Function

    Public Function HttpCall(ByVal nvpRequest As String) As String
        Dim url As String = _pEndPointUrl

        Dim strPost As String = NvpRequest + "&" + buildCredentialsNVPString()
        strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(BN_CODE)

        Dim objRequest As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        objRequest.Timeout = TIMEOUT
        objRequest.Method = "POST"
        objRequest.ContentLength = strPost.Length

        Try
            Using myWriter As New StreamWriter(objRequest.GetRequestStream())
                myWriter.Write(strPost)
            End Using
        Catch e As Exception
            ' Log the exception.
            ExceptionUtility.LogException(e, "HttpCall in PayPalFunction.cs")
        End Try

        'Retrieve the Response returned from the NVP API call to PayPal.
        Dim objResponse As HttpWebResponse = DirectCast(objRequest.GetResponse(), HttpWebResponse)
        Dim result As String
        Using sr As New StreamReader(objResponse.GetResponseStream())
            result = sr.ReadToEnd()
        End Using

        Return result
    End Function

    Private Function BuildCredentialsNvpString() As String
        Dim codec As New nvpCodec()

        If Not IsEmpty(ApiUserName) Then
            codec("USER") = ApiUserName
        End If

        If Not IsEmpty(_apiPassword) Then
            codec(PWD) = _apiPassword
        End If

        If Not IsEmpty(_apiSignature) Then
            codec(SIGNATURE) = _apiSignature
        End If

        If Not IsEmpty(_subject) Then
            codec("SUBJECT") = _subject
        End If

        codec("VERSION") = "88.0"

        Return codec.Encode()
    End Function

    Public Shared Function IsEmpty(s As String) As Boolean
        Return s Is Nothing OrElse s.Trim() = String.Empty
    End Function

End Class


Public NotInheritable Class nvpCodec
    Inherits NameValueCollection

    Private Const AMPERSAND_SIGN As String = "&"
    Private Const EQUALS_SIGN As String = "="

    Private Shared ReadOnly AmpersandCharArray As Char() = AMPERSAND_SIGN.ToCharArray()
    Private Shared ReadOnly EqualsCharArray As Char() = EQUALS_SIGN.ToCharArray()

    Public Function Encode() As String
        Dim sb As New StringBuilder()
        Dim firstPair As Boolean = True
        For Each kv As String In AllKeys
            Dim name As String = HttpUtility.UrlEncode(kv)
            Dim value As String = HttpUtility.UrlEncode(Me(kv))
            If Not firstPair Then
                sb.Append(AMPERSAND_SIGN)
            End If
            sb.Append(name).Append(EQUALS_SIGN).Append(value)
            firstPair = False
        Next
        Return sb.ToString()
    End Function

    Public Sub Decode(nvpstring As String)
        Clear()
        For Each nvp As String In nvpstring.Split(AmpersandCharArray)
            Dim tokens As String() = nvp.Split(EqualsCharArray)
            If tokens.Length >= 2 Then
                Dim name As String = HttpUtility.UrlDecode(tokens(0))
                Dim value As String = HttpUtility.UrlDecode(tokens(1))
                Add(name, value)
            End If
        Next
    End Sub

    Public Overloads Sub Add(name As String, value As String, index As Integer)
        Add(GetArrayName(index, name), value)
    End Sub

    Public Overloads Sub Remove(arrayName As String, index As Integer)
        Remove(GetArrayName(index, arrayName))
    End Sub

    Default Public Overloads Property Item(name As String, index As Integer) As String
        Get
            Return GetArrayName(index, name)
        End Get
        Set(value As String)
            GetArrayName(index, name)
        End Set
    End Property

    Private Shared Function GetArrayName(index As Integer, name As String) As String
        If index < 0 Then
            Throw New ArgumentOutOfRangeException("index", "index cannot be negative : " & index)
        End If
        Return name & index
    End Function
End Class