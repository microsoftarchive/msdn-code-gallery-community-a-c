Public Class Form1

    ''' <summary>
    ''' datalayer class
    ''' </summary>
    ''' <remarks>handles all data access</remarks>
    Dim dl As New datalayer

    ''' <summary>
    ''' datatables
    ''' </summary>
    ''' <remarks>first + last name combobox datasources</remarks>
    Dim firstNames As DataTable
    Dim lastNames As DataTable

    ''' <summary>
    ''' datalayer.address structure variable
    ''' </summary>
    ''' <remarks>keeps track of address saved state</remarks>
    Dim currentAddress As New datalayer.address

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'check if current address has changed
        If btnAdd.Enabled Then
            Dim response As DialogResult = MessageBox.Show("Address has changed. Save it now?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If response = Windows.Forms.DialogResult.Yes Then
                btnAdd.PerformClick()
            End If
        End If
        dl.disconnect()
    End Sub

    ''' <summary>
    ''' Paint event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>draws control borders</remarks>
    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.DrawLine(New Pen(Color.LightGray, 2), cboFN.Left, cboFN.Top + cboFN.Height + 1, cboFN.Left + cboFN.Width, cboFN.Top + cboFN.Height + 1)
        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), cboFN.Left - 1, cboFN.Top - 1, cboFN.Width + 2, cboFN.Height + cboLN.Height + 5)
        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), txtAddr1.Left - 1, txtAddr1.Top - 1, txtAddr1.Width + 2, 101)
        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), txtPostcode.Left - 1, txtPostcode.Top - 1, txtPostcode.Width + 2, 21)
        e.Graphics.DrawLine(New Pen(Color.LightGray, 2), txtAddr1.Left, txtAddr1.Top + txtAddr1.Height + 1, txtAddr1.Left + txtAddr1.Width, txtAddr1.Top + txtAddr1.Height + 1)
        e.Graphics.DrawLine(New Pen(Color.LightGray, 2), txtAddr2.Left, txtAddr2.Top + txtAddr2.Height + 1, txtAddr2.Left + txtAddr2.Width, txtAddr2.Top + txtAddr2.Height + 1)
        e.Graphics.DrawLine(New Pen(Color.LightGray, 2), txtCity.Left, txtCity.Top + txtCity.Height + 1, txtCity.Left + txtCity.Width, txtCity.Top + txtCity.Height + 1)
        e.Graphics.DrawLine(New Pen(Color.LightGray, 2), txtCounty.Left, txtCounty.Top + txtCounty.Height + 1, txtCounty.Left + txtCounty.Width, txtCounty.Top + txtCounty.Height + 1)
        e.Graphics.DrawRectangle(New Pen(Color.LightGray, 2), cboTitle.Left - 1, cboTitle.Top - 1, cboTitle.Width + 2, cboTitle.Height + 2)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'initialize currentAddress variable
        currentAddress.firstName = "[New]"
        currentAddress.lastName = "[New]"

        'comboboxes AutoComplete properties
        cboFN.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboFN.AutoCompleteSource = AutoCompleteSource.ListItems
        cboLN.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboLN.AutoCompleteSource = AutoCompleteSource.ListItems

        'connect to database + load datatables
        dl.connect()
        firstNames = dl.getNames
        lastNames = firstNames.Copy

        'bind first + last name comboboxes 
        cboFN.DisplayMember = "firstName"
        cboFN.DataSource = firstNames.DefaultView.ToTable(True, "firstName")
        cboLN.DisplayMember = "lastName"
        cboLN.DataSource = lastNames.DefaultView.ToTable(True, "lastName")

    End Sub

    'keeps track of address state
    Public ReadOnly Property canAdd() As Boolean
        Get
            Return currentAddress = New datalayer.address With {.firstName = "[New]", .lastName = "[New]"} AndAlso _
                    cboFN.Text <> currentAddress.firstName AndAlso _
                    cboLN.Text <> currentAddress.lastName AndAlso _
                    Not dl.addressExists(cboFN.Text, cboLN.Text)
        End Get
    End Property

    'keeps track of address state
    Public ReadOnly Property canUpdate() As Boolean
        Get
            Return cboFN.Text <> "[New]" AndAlso _
                    cboLN.Text <> "[New]" AndAlso _
                    New datalayer.address With { _
                    .firstName = cboFN.Text, _
                    .lastName = cboLN.Text, _
                    .title = cboTitle.Text, _
                    .address1 = txtAddr1.Text, _
                    .address2 = txtAddr2.Text, _
                    .city = txtCity.Text, _
                    .county = txtCounty.Text, _
                    .country = txtCountry.Text, _
                    .postcode = txtPostcode.Text} <> _
                    currentAddress
        End Get
    End Property

    'form level variable to help in combobox selections
    Dim ignore As Boolean = False

    ''' <summary>
    ''' editControls_TextChanged
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>this multi eventHandler dynamically changes first + last name combobox datasources, based on user selection.
    ''' also enables disables command buttons, depending on state of current address</remarks>
    Private Sub editControls_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostcode.TextChanged, txtCounty.TextChanged, txtCountry.TextChanged, txtCity.TextChanged, txtAddr2.TextChanged, txtAddr1.TextChanged, cboTitle.TextChanged, cboLN.TextChanged, cboFN.TextChanged

        If sender Is cboFN Then
            If ignore Then Return
            Dim oldLastName As String = cboLN.Text

            ignore = True

            cboLN.DisplayMember = "lastName"
            If dl.findLastName(cboFN.Text) Then
                lastNames.DefaultView.RowFilter = "firstName = '" & cboFN.Text & "' OR firstName = '[New]'"
            Else
                lastNames.DefaultView.RowFilter = "firstName LIKE '*'"
            End If
            cboLN.DataSource = lastNames.DefaultView.ToTable(True, "lastName")
            Dim lnIndex As Integer = cboLN.FindStringExact(oldLastName)

            If lnIndex > -1 Then
                cboLN.SelectedIndex = lnIndex
            Else
                cboLN.SelectedIndex = 0
                cboLN.Text = oldLastName
            End If
            ignore = False

            If dl.addressExists(cboFN.Text, cboLN.Text) Then
                getAddress()
            End If
        ElseIf sender Is cboLN Then
            If ignore Then Return
            Dim oldFirstName As String = cboFN.Text

            ignore = True

            cboFN.DisplayMember = "firstName"
            If dl.findFirstName(cboLN.Text) Then
                firstNames.DefaultView.RowFilter = "lastName = '" & cboLN.Text & "' OR lastName = '[New]'"
            Else
                firstNames.DefaultView.RowFilter = "lastName LIKE '*'"
            End If
            cboFN.DataSource = firstNames.DefaultView.ToTable(True, "firstName")
            Dim fnIndex As Integer = cboFN.FindStringExact(oldFirstName)

            If fnIndex > -1 Then
                cboFN.SelectedIndex = fnIndex
            Else
                cboFN.SelectedIndex = 0
                cboFN.Text = oldFirstName
            End If
            ignore = False

            If dl.addressExists(cboFN.Text, cboLN.Text) Then
                getAddress()
            End If

        End If

        btnDelete.Enabled = currentAddress <> New datalayer.address With {.firstName = "[New]", .lastName = "[New]"}
        btnAdd.Text = If(canAdd, "add", If(canUpdate, "update", btnAdd.Text))
        btnAdd.Enabled = canAdd OrElse canUpdate

    End Sub

    ''' <summary>
    ''' getAddress method
    ''' </summary>
    ''' <remarks>runs when an address has been chosen (by first + last name) + populates the edit controls</remarks>
    Private Sub getAddress()
        currentAddress = dl.getFullAddress(cboFN.Text, cboLN.Text)

        cboTitle.SelectedIndex = cboTitle.FindStringExact(currentAddress.title)
        txtAddr1.Text = currentAddress.address1
        txtAddr2.Text = currentAddress.address2
        txtCity.Text = currentAddress.city
        txtCounty.Text = currentAddress.county
        txtCountry.Text = currentAddress.country
        txtPostcode.Text = currentAddress.postcode

    End Sub

    ''' <summary>
    ''' btnDelete_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>runs when user chooses to delete an address.    ''' </remarks>
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        dl.deleteAddress(cboFN.Text, cboLN.Text)

        firstNames = dl.getNames
        lastNames = firstNames.Copy

        cboFN.DisplayMember = "firstName"
        cboFN.DataSource = firstNames.DefaultView.ToTable(True, "firstName")
        cboLN.DisplayMember = "lastName"
        cboLN.DataSource = lastNames.DefaultView.ToTable(True, "lastName")

        btnNew.PerformClick()
    End Sub

    ''' <summary>
    ''' btnNew_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>runs when user chooses a new address</remarks>
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        'check if current address has changed
        If btnAdd.Enabled Then
            Dim response As DialogResult = MessageBox.Show("Address has changed. Save it now?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If response = Windows.Forms.DialogResult.Yes Then
                btnAdd.PerformClick()
            End If
        End If

        currentAddress = New datalayer.address With {.firstName = "[New]", .lastName = "[New]"}

        cboFN.SelectedIndex = 0
        cboLN.SelectedIndex = 0
        cboTitle.SelectedIndex = -1
        txtAddr1.Text = ""
        txtAddr2.Text = ""
        txtCity.Text = ""
        txtCounty.Text = ""
        txtCountry.Text = ""
        txtPostcode.Text = ""
    End Sub

    ''' <summary>
    ''' btnAdd_Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>adds or updates an address</remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If btnAdd.Text = "add" Then
            dl.addAddress(cboFN.Text, cboLN.Text, cboTitle.Text, txtAddr1.Text, txtAddr2.Text, txtCity.Text, txtCounty.Text, txtCountry.Text, txtPostcode.Text)
        Else
            dl.upDateAddress(cboFN.Text, cboLN.Text, cboTitle.Text, txtAddr1.Text, txtAddr2.Text, txtCity.Text, txtCounty.Text, txtCountry.Text, txtPostcode.Text, currentAddress.firstName, currentAddress.lastName)
        End If
        currentAddress = dl.getFullAddress(cboFN.Text, cboLN.Text)

        firstNames = dl.getNames
        lastNames = firstNames.Copy

        cboFN.DisplayMember = "firstName"
        cboFN.DataSource = firstNames.DefaultView.ToTable(True, "firstName")
        cboLN.DisplayMember = "lastName"
        cboLN.DataSource = lastNames.DefaultView.ToTable(True, "lastName")

        cboFN.SelectedIndex = cboFN.FindStringExact(currentAddress.firstName)
        cboLN.SelectedIndex = cboLN.FindStringExact(currentAddress.lastName)

    End Sub

End Class
