# Agregar y eliminar elementos a un Gridview sin usar BD
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
## Topics
- GridView
- DataSet
- Mantenimiento de un grid sin usar BD
## Updated
- 01/19/2012
## Description

<h1>Intro</h1>
<p><em>Estuve buscando algun ejemplo del uso de un GridView sin usar Base de Datos y no lo encontre, encontre unos muy buenos que me ayudaron para presentarles el siguiente ejemplo.</em></p>
<h1><span>Consistencia</span></h1>
<p><em>Es un ejemplo sencillo, uso 3 textbox que es donde se ingresaran 3 datos, luego al presionar el boton agregar los datos de los textbox se agregaran a un DataSet para que luego el GridView tome como datasource el DataSet, luego existe un boton que sirve
 para eliminar los elementos seleccionados en un TemplateField del GridView que es CheckBox.</em></p>
<p><em>Saludos, es mi primera aportaci&oacute;n ojala que le pueda servir a alguien. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Editar script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim dt As New datos.clienteDataTable()
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Session(&quot;accion&quot;) = 0 Then
            Dim dt As New datos.clienteDataTable()
            Dim fila As datos.clienteRow = dt.NewclienteRow
            fila.id = TxtId.Text
            fila.nombre = TxtNombre.Text
            fila.telefono = TxtTelefono.Text
            dt.Rows.Add(fila)
            Session(&quot;guardado&quot;) = dt
            LblEstado.Text = &quot;Datos Guardados&quot;
            Dim filaread As datos.clienteRow = dt.NewclienteRow
            For Each filaread In dt.Rows
                MsgBox(filaread.Item(&quot;nombre&quot;).ToString)
            Next
            Session(&quot;accion&quot;) = 1
            GridDetalle.DataSource = dt
        Else
            dt = Session(&quot;guardado&quot;)

            Dim fila As datos.clienteRow = dt.NewclienteRow
            fila.id = TxtId.Text
            fila.nombre = TxtNombre.Text
            fila.telefono = TxtTelefono.Text
            dt.Rows.Add(fila)
            Session(&quot;guardado&quot;) = dt
            LblEstado.Text = &quot;Datos Guardados&quot;
            Dim filaread As datos.clienteRow = dt.NewclienteRow
            For Each filaread In dt.Rows
                MsgBox(filaread.Item(&quot;nombre&quot;).ToString)
            Next
            GridDetalle.DataSource = dt
        End If
        GridDetalle.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session(&quot;accion&quot;) = 0
        End If
    End Sub

    Protected Sub BtnRecorrer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecorrer.Click
        Dim filaread As datos.clienteRow = dt.NewclienteRow
        For Each filaread In dt.Rows
            MsgBox(filaread.Item(&quot;nombre&quot;).ToString)
        Next

    End Sub

    Protected Sub BtnQuitar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnQuitar.Click
        Dim dtDatos As datos.clienteDataTable = TryCast(Session(&quot;guardado&quot;), datos.clienteDataTable)
 
        For Each row As GridViewRow In GridDetalle.Rows

            Dim check As CheckBox = TryCast(row.FindControl(&quot;chkSeleccion&quot;), CheckBox)

            If check.Checked Then
                '
                ' Se arma la fila para el DataSet de seleccion
                '
                Dim cliente As datos.clienteRow = dtDatos.NewclienteRow()
                cliente.id = GridDetalle.DataKeys(row.RowIndex).Value
                cliente.nombre = row.Cells(3).Text
                MsgBox(cliente.nombre.ToString)

                Dim rowdelete As DataRow() = dtDatos.[Select](String.Format(&quot;Id={0}&quot;, cliente.id))
                dtDatos.Rows.Remove(rowdelete(0))

            End If
        Next

        GridDetalle.DataSource = dtDatos
        GridDetalle.DataBind()
        Session(&quot;guardado&quot;) = dtDatos
    End Sub
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Data&nbsp;
<span class="visualBasic__keyword">Partial</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;_Default&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;System.Web.UI.Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;datos.clienteDataTable()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Session(<span class="visualBasic__string">&quot;accion&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dt&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;datos.clienteDataTable()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;fila&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteRow&nbsp;=&nbsp;dt.NewclienteRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fila.id&nbsp;=&nbsp;TxtId.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fila.nombre&nbsp;=&nbsp;TxtNombre.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fila.telefono&nbsp;=&nbsp;TxtTelefono.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(fila)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session(<span class="visualBasic__string">&quot;guardado&quot;</span>)&nbsp;=&nbsp;dt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LblEstado.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Datos&nbsp;Guardados&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;filaread&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteRow&nbsp;=&nbsp;dt.NewclienteRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;filaread&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;dt.Rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(filaread.Item(<span class="visualBasic__string">&quot;nombre&quot;</span>).ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session(<span class="visualBasic__string">&quot;accion&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridDetalle.DataSource&nbsp;=&nbsp;dt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt&nbsp;=&nbsp;Session(<span class="visualBasic__string">&quot;guardado&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;fila&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteRow&nbsp;=&nbsp;dt.NewclienteRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fila.id&nbsp;=&nbsp;TxtId.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fila.nombre&nbsp;=&nbsp;TxtNombre.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fila.telefono&nbsp;=&nbsp;TxtTelefono.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(fila)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session(<span class="visualBasic__string">&quot;guardado&quot;</span>)&nbsp;=&nbsp;dt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LblEstado.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Datos&nbsp;Guardados&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;filaread&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteRow&nbsp;=&nbsp;dt.NewclienteRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;filaread&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;dt.Rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(filaread.Item(<span class="visualBasic__string">&quot;nombre&quot;</span>).ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridDetalle.DataSource&nbsp;=&nbsp;dt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridDetalle.DataBind()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Page_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;IsPostBack&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session(<span class="visualBasic__string">&quot;accion&quot;</span>)&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnRecorrer_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;BtnRecorrer.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;filaread&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteRow&nbsp;=&nbsp;dt.NewclienteRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;filaread&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;dt.Rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(filaread.Item(<span class="visualBasic__string">&quot;nombre&quot;</span>).ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;BtnQuitar_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;BtnQuitar.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dtDatos&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteDataTable&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(Session(<span class="visualBasic__string">&quot;guardado&quot;</span>),&nbsp;datos.clienteDataTable)&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;row&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GridViewRow&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;GridDetalle.Rows&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;check&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;CheckBox&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(row.FindControl(<span class="visualBasic__string">&quot;chkSeleccion&quot;</span>),&nbsp;CheckBox)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;check.Checked&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Se&nbsp;arma&nbsp;la&nbsp;fila&nbsp;para&nbsp;el&nbsp;DataSet&nbsp;de&nbsp;seleccion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cliente&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;datos.clienteRow&nbsp;=&nbsp;dtDatos.NewclienteRow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cliente.id&nbsp;=&nbsp;GridDetalle.DataKeys(row.RowIndex).Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cliente.nombre&nbsp;=&nbsp;row.Cells(<span class="visualBasic__number">3</span>).Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(cliente.nombre.ToString)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rowdelete&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow()&nbsp;=&nbsp;dtDatos.[<span class="visualBasic__keyword">Select</span>](<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;Id={0}&quot;</span>,&nbsp;cliente.id))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dtDatos.Rows.Remove(rowdelete(<span class="visualBasic__number">0</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridDetalle.DataSource&nbsp;=&nbsp;dtDatos&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GridDetalle.DataBind()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Session(<span class="visualBasic__string">&quot;guardado&quot;</span>)&nbsp;=&nbsp;dtDatos&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<ul>
</ul>
<h1>Para m&aacute;s informaci&oacute;n escribanme a moytho@gmail.com salu2 desde Guatebella</h1>
<div id="progressText">Su descripci&oacute;n es demasiado breve.</div>
<div id="goodDescriptionText">
<p>Se requieren 1000 caracteres (sin incluir espacios).</p>
<p>Una buena descripci&oacute;n del ejemplo explica lo que se ense&ntilde;a sin necesidad de que los usuarios descarguen el c&oacute;digo del ejemplo.</p>
<p>Intente responder las siguientes preguntas en su descripci&oacute;n:</p>
<ul>
<li>&iquest;Qu&eacute; problema soluciona el ejemplo? </li><li>&iquest;De qu&eacute; manera este ejemplo soluciona el problema? </li><li>&iquest;Cu&aacute;les son los fragmentos de c&oacute;digo que resaltan las secciones m&aacute;s importantes del ejemplo?
</li><li>&iquest;D&oacute;nde se puede obtener m&aacute;s informaci&oacute;n sobre este tema o tecnolog&iacute;a?
</li></ul>
</div>
