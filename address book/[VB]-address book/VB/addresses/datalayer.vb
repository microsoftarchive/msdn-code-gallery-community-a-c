Imports System.Data.OleDb

Public Class datalayer

    ''' <summary>
    ''' address Structure
    ''' </summary>
    ''' <remarks>used to keep track of current address saved state</remarks>
    Public Structure address
        Public firstName As String
        Public lastName As String
        Public title As String
        Public address1 As String
        Public address2 As String
        Public city As String
        Public county As String
        Public country As String
        Public postcode As String
        Public Overloads Shared Operator =(ByVal a1 As address, ByVal a2 As address) As Boolean
            Return a1.firstName = a2.firstName AndAlso _
                    a1.lastName = a2.lastName AndAlso _
                    a1.title = a2.title AndAlso _
                    a1.address1 = a2.address1 AndAlso _
                    a1.address2 = a2.address2 AndAlso _
                    a1.city = a2.city AndAlso _
                    a1.county = a2.county AndAlso _
                    a1.country = a2.country AndAlso _
                    a1.postcode = a2.postcode
        End Operator
        Public Overloads Shared Operator <>(ByVal a1 As address, ByVal a2 As address) As Boolean
            Return a1.firstName <> a2.firstName OrElse _
                    a1.lastName <> a2.lastName OrElse _
                    a1.title <> a2.title OrElse _
                    a1.address1 <> a2.address1 OrElse _
                    a1.address2 <> a2.address2 OrElse _
                    a1.city <> a2.city OrElse _
                    a1.county <> a2.county OrElse _
                    a1.country <> a2.country OrElse _
                    a1.postcode <> a2.postcode
        End Operator
    End Structure

    Private con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=addresses1.accdb;Persist Security Info=False;")

    Public Sub connect()
        con.Open()
    End Sub

    Public Sub disconnect()
        con.Close()
    End Sub

    ''' <summary>
    ''' getNames Function
    ''' </summary>
    ''' <returns>returns a datatable, containing first names + last names</returns>
    ''' <remarks></remarks>
    Public Function getNames() As DataTable
        Dim da As New OleDbDataAdapter("SELECT firstName, lastName FROM addresses", con)
        Dim dt As New DataTable

        da.Fill(dt)

        Dim dr As DataRow = dt.NewRow
        dr.ItemArray = New Object() {"[New]", "[New]"}

        dt.Rows.InsertAt(dr, 0)

        Return dt

    End Function

    ''' <summary>
    ''' addressExists Function
    ''' </summary>
    ''' <param name="fn"></param>
    ''' <param name="ln"></param>
    ''' <returns></returns>
    ''' <remarks>queries the db to check if an address exists</remarks>
    Public Function addressExists(ByVal fn As String, ByVal ln As String) As Boolean
        Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM addresses WHERE firstName = @firstName AND lastName = @lastName", con)
        cmd.Parameters.AddWithValue("@firstName", fn)
        cmd.Parameters.AddWithValue("@lastName", ln)

        Return CInt(cmd.ExecuteScalar) > 0

    End Function

    ''' <summary>
    ''' findFirstName Function
    ''' </summary>
    ''' <param name="ln"></param>
    ''' <returns></returns>
    ''' <remarks>queries the db to check if lastName exists</remarks>
    Public Function findFirstName(ByVal ln As String) As Boolean

        Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM addresses WHERE lastName = @lastName", con)
        cmd.Parameters.AddWithValue("@lastName", ln)

        Return CInt(cmd.ExecuteScalar) > 0

    End Function

    ''' <summary>
    ''' findLastName Function
    ''' </summary>
    ''' <param name="fn"></param>
    ''' <returns></returns>
    ''' <remarks>queries the db to check if firstName exists</remarks>
    Public Function findLastName(ByVal fn As String) As Boolean

        Dim cmd As New OleDbCommand("SELECT COUNT(*) FROM addresses WHERE firstName = @firstName", con)
        cmd.Parameters.AddWithValue("@firstName", fn)

        Return CInt(cmd.ExecuteScalar) > 0

    End Function

    ''' <summary>
    ''' getFullAddress Function
    ''' </summary>
    ''' <param name="fn"></param>
    ''' <param name="ln"></param>
    ''' <returns>an instance of address structure</returns>
    ''' <remarks>queries the db + returns an address</remarks>
    Public Function getFullAddress(ByVal fn As String, ByVal ln As String) As address
        Dim a As New address

        a.firstName = "[New]"
        a.lastName = "[New]"

        Dim cmd As New OleDbCommand("SELECT * FROM addresses WHERE firstName = @firstName AND lastName = @lastName", con)
        cmd.Parameters.AddWithValue("@firstName", fn)
        cmd.Parameters.AddWithValue("@lastName", ln)

        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable

        da.Fill(dt)

        If dt.Rows.Count = 0 Then Return a

        a.firstName = fn
        a.lastName = ln
        a.title = dt.Rows(0).Field(Of String)("title")
        a.address1 = dt.Rows(0).Field(Of String)("addressLine1")
        a.address2 = dt.Rows(0).Field(Of String)("addressLine2")
        a.city = dt.Rows(0).Field(Of String)("city")
        a.county = dt.Rows(0).Field(Of String)("county")
        a.country = dt.Rows(0).Field(Of String)("country")
        a.postcode = dt.Rows(0).Field(Of String)("postcode")

        Return a

    End Function

    ''' <summary>
    ''' deleteAddress Method
    ''' </summary>
    ''' <param name="fn"></param>
    ''' <param name="ln"></param>
    ''' <remarks>deletes an address from db</remarks>
    Public Sub deleteAddress(ByVal fn As String, ByVal ln As String)
        Dim cmd As New OleDbCommand("DELETE * FROM addresses WHERE firstName = @firstName AND lastName = @lastName", con)
        cmd.Parameters.AddWithValue("@firstName", fn)
        cmd.Parameters.AddWithValue("@lastName", ln)

        cmd.ExecuteNonQuery()

    End Sub

    ''' <summary>
    ''' addAddress Method
    ''' </summary>
    ''' <param name="fn"></param>
    ''' <param name="ln"></param>
    ''' <param name="title"></param>
    ''' <param name="address1"></param>
    ''' <param name="address2"></param>
    ''' <param name="city"></param>
    ''' <param name="county"></param>
    ''' <param name="country"></param>
    ''' <param name="postcode"></param>
    ''' <remarks>adds an address to db</remarks>
    Public Sub addAddress(ByVal fn As String, ByVal ln As String, ByVal title As String, ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal county As String, ByVal country As String, ByVal postcode As String)
        Dim cmd As New OleDbCommand("INSERT INTO addresses (firstName, lastName, title, addressLine1, addressLine2, city, county, country, postcode) VALUES(@firstName, @lastName, @title, @address1, @address2, @city, @county, @country, @postcode)", con)
        cmd.Parameters.AddWithValue("@firstName", fn)
        cmd.Parameters.AddWithValue("@lastName", ln)
        cmd.Parameters.AddWithValue("@title", title)
        cmd.Parameters.AddWithValue("@address1", address1)
        cmd.Parameters.AddWithValue("@address2", address2)
        cmd.Parameters.AddWithValue("@city", city)
        cmd.Parameters.AddWithValue("@county", county)
        cmd.Parameters.AddWithValue("@country", country)
        cmd.Parameters.AddWithValue("@postcode", postcode)

        MsgBox(cmd.ExecuteNonQuery())
    End Sub

    ''' <summary>
    ''' upDateAddress Method
    ''' </summary>
    ''' <param name="fn"></param>
    ''' <param name="ln"></param>
    ''' <param name="title"></param>
    ''' <param name="address1"></param>
    ''' <param name="address2"></param>
    ''' <param name="city"></param>
    ''' <param name="county"></param>
    ''' <param name="country"></param>
    ''' <param name="postcode"></param>
    ''' <param name="oldFirstName"></param>
    ''' <param name="oldLastName"></param>
    ''' <remarks>updates an existing address in db</remarks>
    Public Sub upDateAddress(ByVal fn As String, ByVal ln As String, ByVal title As String, ByVal address1 As String, ByVal address2 As String, ByVal city As String, ByVal county As String, ByVal country As String, ByVal postcode As String, ByVal oldFirstName As String, ByVal oldLastName As String)
        Dim cmd As New OleDbCommand("UPDATE addresses SET firstName = @firstName, lastName = @lastName, title = @title, addressLine1 = @address1, addressLine2 = @address2, city = @city, county = @county, country = @country, postcode = @postcode WHERE firstName = @oldFirstName AND lastName = @oldLastName", con)
        cmd.Parameters.AddWithValue("@firstName", fn)
        cmd.Parameters.AddWithValue("@lastName", ln)
        cmd.Parameters.AddWithValue("@title", title)
        cmd.Parameters.AddWithValue("@address1", address1)
        cmd.Parameters.AddWithValue("@address2", address2)
        cmd.Parameters.AddWithValue("@city", city)
        cmd.Parameters.AddWithValue("@county", county)
        cmd.Parameters.AddWithValue("@country", country)
        cmd.Parameters.AddWithValue("@postcode", postcode)
        cmd.Parameters.AddWithValue("@oldFirstName", oldFirstName)
        cmd.Parameters.AddWithValue("@oldLastName", oldLastName)

        cmd.ExecuteNonQuery()
    End Sub

End Class
