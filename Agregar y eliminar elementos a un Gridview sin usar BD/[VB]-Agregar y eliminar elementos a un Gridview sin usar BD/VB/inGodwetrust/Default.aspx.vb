Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim dt As New datos.clienteDataTable()
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Session("accion") = 0 Then
            Dim dt As New datos.clienteDataTable()
            Dim fila As datos.clienteRow = dt.NewclienteRow
            fila.id = TxtId.Text
            fila.nombre = TxtNombre.Text
            fila.telefono = TxtTelefono.Text
            dt.Rows.Add(fila)
            Session("guardado") = dt
            LblEstado.Text = "Datos Guardados"
            Dim filaread As datos.clienteRow = dt.NewclienteRow
            For Each filaread In dt.Rows
                MsgBox(filaread.Item("nombre").ToString)
            Next
            Session("accion") = 1
            GridDetalle.DataSource = dt
        Else
            dt = Session("guardado")

            Dim fila As datos.clienteRow = dt.NewclienteRow
            fila.id = TxtId.Text
            fila.nombre = TxtNombre.Text
            fila.telefono = TxtTelefono.Text
            dt.Rows.Add(fila)
            Session("guardado") = dt
            LblEstado.Text = "Datos Guardados"
            Dim filaread As datos.clienteRow = dt.NewclienteRow
            For Each filaread In dt.Rows
                MsgBox(filaread.Item("nombre").ToString)
            Next
            GridDetalle.DataSource = dt
        End If
        GridDetalle.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("accion") = 0
        End If
    End Sub

    Protected Sub BtnRecorrer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecorrer.Click
        Dim filaread As datos.clienteRow = dt.NewclienteRow
        For Each filaread In dt.Rows
            MsgBox(filaread.Item("nombre").ToString)
        Next

    End Sub

    Protected Sub BtnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnQuitar.Click
        Dim dtDatos As datos.clienteDataTable = TryCast(Session("guardado"), datos.clienteDataTable)
 
        For Each row As GridViewRow In GridDetalle.Rows

            Dim check As CheckBox = TryCast(row.FindControl("chkSeleccion"), CheckBox)

            If check.Checked Then
                '
                ' Se arma la fila para el DataSet de seleccion
                '
                Dim cliente As datos.clienteRow = dtDatos.NewclienteRow()
                cliente.id = GridDetalle.DataKeys(row.RowIndex).Value
                cliente.nombre = row.Cells(3).Text
                MsgBox(cliente.nombre.ToString)

                Dim rowdelete As DataRow() = dtDatos.[Select](String.Format("Id={0}", cliente.id))
                dtDatos.Rows.Remove(rowdelete(0))

            End If
        Next

        GridDetalle.DataSource = dtDatos
        GridDetalle.DataBind()
        Session("guardado") = dtDatos
    End Sub
End Class
