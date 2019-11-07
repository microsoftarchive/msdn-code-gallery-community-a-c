Option Explicit On
Option Strict On
Imports ContaNet.Tools
Imports ContaNet.Tools.NSEnums.Align
Imports ContaNet.Tools.NSVars
Imports ContaNet.Tools.NSHTML
Imports ContaNet.Tools.NSStyles
Imports ContaNet.Tools.Util
Imports System.IO
Imports System.Threading.Tasks
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim Mobile As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Mobile = GetMobile()
        Dim core As New ContaNet.Tools.NSCore(Page, "", PageSetup, , , , True)
        Dim show As New ContaNet.Tools.NSShow(Page)
        If core.OnBeforeUnload Then
            ' do something on before page unload
        End If

        If core.OnUnload Then
            ' do something on page unload
        End If


        Select Case core.Funct

            Case "CHANGE1"
                'show.SetAttribute("body", "style.background", "url(images/background/gris.jpg)", 0)
                Dim AT As New NSAttributes
                '  AT.DeleteItem("mainTB")
                AT.SetAttribute("body", "style.background", "url(images/background/gris.jpg)", 0)
                AT.AddToolbar(ToolBar2(2))
                AT.AddText("This text is centered on the page", "Contact",, "20px", "bold", "Red", "50%", "50%",,, ,,, "Textx", "centertext")
                AT.Show(Page)
            Case "CHANGE2"
                Dim AT As New NSAttributes
                AT.SetAttribute("body", "style.background", "url(images/background/caboverde.jpg) no-repeat fixed;", 0)
                AT.SetAttribute("body", "style.backgroundSize", "cover", 0)

                AT.AddToolbar(ToolBar)
                AT.AddText("Centered Text", "Contact",, "20px", "bold", "Blue", "50%", "50%",,, , ,, "Textx", "centertext")
                AT.Show(Page)
            Case "SearchForName"
                Dim m As New NSMenu
                With m
                    .Caption = "Search for name"
                    .AddItem("Name", NSVars.Text, 30)
                    .Funct = "SearchForName2"
                    .Show(Page)

                End With
            Case "SearchForName2"
                LoadHTMImage(core.Menu.GetValue(0))
            Case "TEST4"
                show.WebPage("Amortizaciones", "amortizacion2.aspx",,, 700, 650, True)
              '  show.Message("Button clicked")
            Case "CUTTOOLBAR"
                show.DeleteItem("mainTB")
               ' show.SetAttribute("body", "style", "background:url(images/background/gris.jpg)")
            Case "Style" To "Stylez"
                Dim FileName As String = core.Funct.Substring(5).Replace("_", " ") & ".txt"
                Cookie(Page, "STYLE", DateTime.Now.AddDays(1)) = FileName
                'If Not My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\data\styles\" & FileName) Then show.ErrorMessage("File does not exist")
                'FileCopy(Server.MapPath(".") & "\data\styles\" & FileName, Server.MapPath(".") & "\data\style.txt")
                show.Reload()

            Case "ADDLABEL"
                show.PositionLocator("Test" & Now.Second.ToString, 50, 50, 200)
            Case "SAVELABELS"
                show.ReturnPositions("SAVELABELS2")
            Case "SAVELABELS2"
                If core.Values(0).Trim = "" Then
                    If My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\test\test.txt") Then My.Computer.FileSystem.DeleteFile(Server.MapPath(".") & "\test\test.txt")
                Else
                    If Not My.Computer.FileSystem.DirectoryExists(Server.MapPath(".") & "\test") Then
                        My.Computer.FileSystem.CreateDirectory(Server.MapPath(".") & "\test")
                    End If
                    My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\test\test.txt", core.Values(0) & "", False)

                End If
                show.DoNothing()
            Case "LOADLABEL0" To "LOADLABEL99"
                If Not My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\test\test.txt") Then show.DoNothing()

                Dim B() As String = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\test\test.txt").Split(CChar(vbTab))
                Dim X As Integer = CInt(core.Funct.Substring(9))
                Dim C() As String = B(X).Split(CChar("-"))
                If C.GetUpperBound(0) > 2 Then
                    show.PositionLocator(C(0), CInt(C(1)), CInt(C(2)), CInt(C(3)))
                Else
                    show.DoNothing()
                End If
            Case "DATAENTRY1", "DATAENTRY2"
                Dim m As New ContaNet.Tools.NSMenu
                If core.Funct = "DATAENTRY2" Then m.Modal = True
                m.Top = 100
                m.Left = 100
                m.Height = 400
                m.Funct = "RETURNDATAENTRY"
                m.AddCancelFunction("CANCEL1", "ENGLISH")
                m.Caption = "Data Entry"
                m.TextboxClass = "textbox"
                m.AddItem("Name", NSVars.Text, 35, "", "*required")
                m.AddItem("Address", NSVars.Text, 35, "")
                m.AddItem("Postal Code", ZeroFilledNumber, 5)
                m.AddItem("STATE", States, 0)
                m.AddItem("Country", Country, 30, "")
                m.AddItem("MaskedEdit Telephone", MaskedEdit, 14, "(111) 222-3333", "(###) ###-####")
                m.AddItem("MaskedEdit SSN", MaskedEdit, 14, "111-22-3333", "###-##-####")
                m.AddItem("email", Email, 40)

                m.AddItem("STATES (with abreviation)", States_Abrev, 0)
                m.AddItem("Text entry (30 characters)", NSVars.Text, 30, "Original text", "* notes for this field")

                m.AddItem("A Date", NSVars.DateSelect, 8, Now.ToString("MM/dd/yy", CultureInfo.InvariantCulture))
                m.AddItem("Date with century", NSVars.DateSelect, 10, Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture))
                m.AddItem("Date with just day and month", NSVars.DateSelect, 5, Now.ToString("MM/dd", CultureInfo.InvariantCulture))

                m.AddItem("No decimals", Number, 12)
                m.AddItem("one decimal", Number_1dec, 12)
                m.AddItem("two decimals", Number_2dec, 12, "")
                m.AddItem("three decimals", Number_3dec, 12)
                m.AddItem("four decimals", Number_4dec, 12)
                m.AddItem("five decimals", Number_5dec, 12)

                m.AddItem("File upload 1", FileUpload, 50, "")
                m.AddItem("Check box 1 (not checked by default)", Checkbox, 0, "")
                m.AddItem("Check box 2 (checked by default)", Checkbox, 0, "1")
                m.AddItem("Option 1", NSVars.SelectOption, 0, "")
                m.AddItem("Option 2", NSVars.SelectOption, 0, "1")
                m.AddItem("Mutiple selection", MultipleSelection, 2, "one,two,three,four,five")
                m.AddItem("Multiple selection (hit 0 or 1 and enter)", MultipleSelectionEditable, 20, "one,two,three,four,five", "300, 300, Choose one")
                m.AddItem("Field updated by timer", NonModifiableText, 20, Now.ToLongTimeString)
                m.AddLabel("<b><i>Red</b></i> label align left", LabelColor.Red, NSEnums.Align.Left)
                m.AddLabel("<b><i>Yellow</b></i> label align center", LabelColor.Yellow, NSEnums.Align.Center)
                m.AddLabel("<b><i>Green</b></i> label align right", LabelColor.Green, NSEnums.Align.Right)
                m.AddItem("Color", Colors, 0, "")
                m.AddItem("Fonts", FontNames, 0)
                m.AddItem("Month", Month, 0, "")
                m.AddItem("NIF (Spanish ID)", Nif, 10, "")
                m.AddItem("NOTES", Notes, 50, "", "", , , "I would Like To receive more information regarding...")
                m.AddItem("NUMERATOR", Numerator, 10, "")
                m.AddItem("PASSWORD", Password, 20, "")
                m.AddItem("Zero filled number", ZeroFilledNumber, 8, "000000000", "", "ZERO")
                m.AddItem("File upload", FileUpload, 50, "")

                For x As Integer = 5 To 7
                    m.AddButton("Test" & x, CType(x, ContaNet.Tools.DefaultIcons), , "BTEST" & CStr(x))
                Next

                m.CloseOnOK = NSMenu.CloseOnOKValues.DoNotClose

                ' m.AddTimer(1000, "Timer", , True)

                '  m.JavaScript = "function Testx() { alert('this adds javascript dynamically') }; Testx();"
                '  m.HelpFile = "helpfiles/VB/Code for data entry.htm"

                m.AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_data_entry")
                m.AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_data_entry")
                m.Show(Page)

            Case "HELPVB" To "HELPVB_z"
                Dim h As String = core.Funct.Substring(7).Replace("_", " ")
                show.HTMLFile(h & " (using VB)", "helpfiles/VB/" & h & ".htm")
            Case "HELPCS" To "HELPCS_z"
                Dim h As String = core.Funct.Substring(7).Replace("_", " ")
                show.HTMLFile(h & " (using C#)", "helpfiles/CS/" & h & ".htm")
            Case "Timer"
                show.SetTimerText(core.HiddenData & "_Textbox27", Now.ToLongTimeString)
            Case "RETURNDATAENTRY"
                Dim txt As String = ""
                For x As Integer = 0 To core.Menu.Count
                    txt += core.Menu.GetDescription(x) & vbTab & core.Menu.GetValue(x).Replace(Chr(10), "<BR>") & vbNewLine
                Next

                Dim htm As New ContaNet.Tools.NSHTML
                With htm
                    .BackgroundColor = "white"
                    .TextColor = "black"
                    .Caption = "DATA"
                    .AddCol("Description", Types.Text)
                    .AddCol("Value", Types.Text)
                    .Text = txt
                    .Show(Page)
                End With

            Case "BTEST5"
                Dim rm As New ContaNet.Tools.NSShow.MenuValues
                rm.SetTextValue(1, "189 Elm Ave.", "Changed server side")
                rm.ReturnValues(Page)
            Case "BTEST" To "BTEST9"
                show.Message("Do something with this: " & core.Funct)
            Case "TEST", "TEST1"
                Dim IMPORTE As String = "0,00"

                If core.Funct = "TEST1" Then IMPORTE = "10,00"
                Dim txt1 As String = "Fecha Alta" & vbTab & "28/11/16" & vbTab & "CODIGO" & vbTab & "0004" & vbTab & "NOMBRE" & vbTab & "Alllan Waarden" & vbTab & "CODIGO CONTABLE" & vbTab & vbTab & "SERIE" & vbTab & vbTab & "DIRECCION" & vbTab & "Calle cueva juarada n5" & vbTab & "POBLACION" & vbTab & "Tegueste" & vbTab & "CODIGO POSTAL" & vbTab & "38280" & vbTab & "D.N.I." & vbTab & "12345678Z" & vbTab & "TELÉFONO" & vbTab & "922543900" & vbTab & "FAX" & vbTab & "922543901" & vbTab & "EMAIL" & vbTab & "alan@contanet.es" & vbTab & "CCC" & vbTab & "                    " & vbTab & "Vendedor" & vbTab & vbTab & "Llamar a partir:" & vbTab & vbTab & "Sector:" & vbTab & vbTab & "Saldo Pte." & vbTab & "0" & vbTab & "Facturación Mensual" & vbTab & "0,00" & vbTab
                Dim datos2() As String = txt1.Split(CChar(vbTab))
                Dim html As New NSHTML
                With html
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\art.txt")
                    .Caption = "Contrato de Mantenimiento"
                    .AddTextBox("Fecha", DateTime.Now.ToShortDateString, NSVars.DateSelect, 10, "FechaContrato", "textbox", 0)
                    .AddTextBox("Cód.", datos2(3), NSVars.ZeroFilledNumber, 4, "CodigoClienteContrato", , 0)
                    .AddTextBox("Nombre/Razón Social", datos2(5), NSVars.Text, 35, "NombreContrato", , 0)
                    .AddTextBox("NIF/CIF", datos2(17), NSVars.Text, 10, "NIFContrato", , 0)
                    .AddTextBox("Teléfonos", datos2(19), NSVars.Text, 20, "TelefonoContrato", , 0)
                    .AddTextBox("Fax", datos2(21), NSVars.Text, 20, "FaxContrato", , 0)
                    .AddTextBox("Timer", "", NSVars.NonModifiableText, 20, "Timer", , 0)
                    .AddTextBox("Dirección", datos2(11), NSVars.Text, 35, "DireccionContrato", , 1)
                    .AddTextBox("Población", datos2(13), NSVars.Text, 35, "PoblacionContrato", , 1)
                    .AddTextBox("C.P.", datos2(15), NSVars.ZeroFilledNumber, 5, "CPContrato", , 1)
                    .AddTextBox("Email", datos2(23), NSVars.Text, 49, "EmailContrato", , 1)
                    .AddTextBox("Persona de Contacto", "", NSVars.Text, 35, "PersonaContactoContrato", , 2)
                    .AddTextBox("F.Pago", "Contado,Letra,Talón,Transferencia", NSVars.MultipleSelection, 10, "FormaPagoContrato", , 2)
                    .AddTextBox("Observaciones", "", NSVars.Text, 35, "ObservacionesContrato", , 2)
                    .AddTextBox("Cuenta Corriente", datos2(25), NSVars.MaskedEdit, 20, "CuentaCorrienteContrato", , 2, , "####-####-##-##########")
                    .AddTextBox("Notas", "These are some notes", Notes, 120, "MyNotes", , 4)
                    .AddCol("Programa", NSHTML.Types.Text, 35)
                    .AddCol(NSHTML.SpecialColumns.MultipleSelection, "Unidades", 1, "ImporteLineaContrato", "TEST1", 30, NSEnums.Align.Center, , "0,1,2,3,4,5")
                    .AddEditableCol("Importe Act.", 2, , 10, NSEnums.Align.Center, "")
                    .AddCol(NSHTML.SpecialColumns.Checkbox, "Actualizaciones", 1, "ImporteLineaContrato", "TEST1", 30, NSEnums.Align.Center)
                    .AddEditableCol("Importe Mant.", 2, , 10, NSEnums.Align.Center, "")
                    .AddCol(NSHTML.SpecialColumns.Checkbox, "Act. Asistencia", 1, "ImporteLineaContrato", "TEST1", 30, NSEnums.Align.Center)
                    .AddCol("Importe", NSHTML.Types.Text)
                    '.AddTimer(1000, "UPDATETIMER", , True)
                    ' .AddTimer(1000, "UPDATETIMER2", , False)
                    .CenterScreen = True
                    .Funct = "GuardarContratoMantenimiento"
                    .Height = "600px"
                    Cookie(Page, "TIMER") = Now.ToUniversalTime.ToString
                    .Show(Page)
                End With
            Case "UPDATETIMER2"
                show.SetTimerText("TIMERTEST", Now.ToLongTimeString)
            Case "UPDATETIMER"
                Dim Result2 As String = ""
                Dim checktime As DateTime
                If DateTime.TryParse(Cookie(Page, "TIMER"), checktime) Then
                    Dim currenttime As Date = Date.Now
                    Result2 = (currenttime - checktime).ToString
                    Result2 = Result2.Substring(0, Result2.LastIndexOf("."))
                End If
                show.SetTimerText("Timer", Result2)
            Case "ImporteLineaContrato"
                Dim u As New NSUtil(Page)
                Dim d(,) As String = u.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\art.txt"))
                Dim sb As New StringBuilder
                Dim imp As Double = 0
                For x As Integer = 0 To d.GetUpperBound(0)
                    imp = 0
                    If core.HTML.Value = d(x, 0) Then
                        d(x, 3) = "0"
                        d(x, 5) = "0"
                        If core.HTML.GetCheckbox(x + 1, 4).Value = "1" Then
                            d(x, 1) = core.HTML.GetMultipleSelection(x + 1, 2).Value
                            If d(x, 1) < "1" Then d(x, 1) = "1"
                            d(x, 2) = core.HTML.GetEditText(x + 1, 3).Value
                            d(x, 3) = "1"
                            imp = Val(d(x, 2)) * Val(d(x, 1))
                        Else
                            d(x, 3) = "0"
                        End If
                        If core.HTML.GetCheckbox(x + 1, 6).Value = "1" Then
                            d(x, 1) = core.HTML.GetMultipleSelection(x + 1, 2).Value
                            If d(x, 1) < "1" Then d(x, 1) = "1"
                            d(x, 3) = ""
                            d(x, 4) = core.HTML.GetEditText(x + 1, 5).Value
                            d(x, 5) = "1"
                            imp = Val(d(x, 4)) * Val(d(x, 1))
                        Else
                            d(x, 5) = "0"
                        End If
                        If imp = 0 Then d(x, 1) = "0"
                        For y As Integer = 0 To 5
                            sb.Append(d(x, y) & vbTab)
                        Next
                        sb.Append(Microsoft.VisualBasic.Format(imp, "##0.00") & "€")
                        sb.Append(vbNewLine)
                    Else
                        For y As Integer = 0 To 6
                            sb.Append(d(x, y) & vbTab)
                        Next
                        sb.Append(vbNewLine)

                    End If
                Next
                Try
                    My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\art.txt", sb.ToString, False)
                Catch ex As Exception
                    show.Message(ex.Message)
                End Try
                show.CloseCallingWindow()

                '  show.Message(core.HTML.GetCheckbox("ContaNet Bronce", 4).Value & " " & core.HTML.GetCheckbox("ContaNet Bronce", 6).Value)
            Case "GuardarContratoMantenimiento"
                Stop
                Dim a As String = core.Grid.Clip
                Stop
                show.Message(core.TextBox("MyNotes"))

            Case "INFO"
                show.HTMLFile("Info", "info.html", , , , , , , , , , "helpfiles/VB/Code to show info.html")
            Case "Funct2"
                Dim m As New NSMenu
                With m
                    .Funct = "Funct2Test"
                    .Caption = "Test"
                    .AddItem("NAME", NSVars.Text, 30)
                    .AddItem("Address", NSVars.Text, 30)
                    .Show(Page)
                End With
            Case "Funct2Test"
                show.CloseCallingWindow()

            Case "DATESS" ' this takes into account different culture settings 
                Dim m As New NSMenu With {
                    .Funct = "DATESS1",
                    .Caption = "Date management"
                }
                m.AddItem("Today's date", DateSelect, 8, Microsoft.VisualBasic.Format(Now, core.ServerShortDateFormat), "", "DATESS2")
                m.AddItem("One month from now", DateSelect, 8, Microsoft.VisualBasic.Format(Now.AddMonths(1), core.ServerShortDateFormat))
                m.AddItem("One year from now", DateSelect, 8, Microsoft.VisualBasic.Format(Now.AddYears(1), core.ServerShortDateFormat))
                m.Show(Page)
            Case "DATESS1"
                show.Message(core.Menu.GetValue(1))
            Case "DATESS2" ' this takes into account different culture settings 
                Dim d As String = core.Menu.GetValue(0)
                Dim err1 As Integer = 0
                Dim D1 As Date
                Dim D2 As Date
                Dim d0 As System.DateTime
                Dim dateformat As String = core.ServerShortDateFormat
                Try
                    d0 = New System.DateTime(CInt("20" + d.Substring(dateformat.IndexOf("yy"), 2)), CInt(d.Substring(dateformat.IndexOf("MM"), 2)), CInt(d.Substring(dateformat.IndexOf("dd"), 2)))
                    D1 = d0.AddMonths(1)
                    D2 = d0.AddYears(1)
                Catch ex As Exception
                    err1 = 1
                End Try

                Dim mr As New ContaNet.Tools.NSShow.MenuValues
                With mr
                    If err1 = 1 Then
                        .SetTextValue(0, "", "Invalid date")
                        .SetFocus(0)
                    Else
                        .SetTextValue(0, core.FormatDate(d0))
                        .SetTextValue(1, core.FormatDate(D1))
                        .SetTextValue(2, core.FormatDate(D2))
                    End If
                    .ReturnValues(Page)
                End With


            Case "MULTICOPY"
                Dim FileTypes() As String = "audio/*,video/*,image/*,media_type,.jpg,.xls,.xlsx,.doc,.docx,.pdf".Split(CChar(","))
                Dim m As New NSMenu With {
                    .Funct = "TEST2",
                    .Caption = "Multi File Upload"
                }
                For x As Integer = 0 To FileTypes.GetUpperBound(0) - 1
                    m.AddItem(FileTypes(x), FileUpload, 100, FileTypes(x))
                Next
                m.CloseOnOK = NSMenu.CloseOnOKValues.CloseOnReturn
                m.Show(Page)
            Case "TEST2"
                If core.Menu.ErrorMsg.Length > 0 Then
                    show.HTMLFile("Error", core.Menu.ErrorMsg, True)
                Else
                    Dim Tem As String = ""
                    For x As Integer = 0 To core.Menu.Count
                        Tem += core.Menu.GetValue(x) & "<BR>"
                    Next
                    show.Message("Multiple files copied<BR>" & Tem)

                End If

            Case "WPW"
                ' show.WebPage("Contanet", "http://www.contanet.es", 10, 10, 600, 500)
                show.WebPage("Contanet", "http://localhost:51453/", 10, 10, 600, 500)


            Case "TEST1"
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\LEO.txt", core.Grid.Clip, False)
            Case "HTMLFILE2"
                show.HTMLFile("'HTML'", "data/test.html?1111", , , , , , , True)
            Case "MULTIPDF"
                Cookie(Page, "Page") = "1"
                Dim C As New NSContainer
                With C
                    .AddCancelFunction("CANCELHTM", "MYVALUE")
                    .Height = 700
                    .Width = 820
                    .Caption = "Page 1"
                    .AddButton("test", DefaultIcons.ArrowLeft, , "PDFPREVIOUS")
                    .AddButton("test2", DefaultIcons.ArrowRight, , "PDFNEXT")
                    .Href = "data/forms/form1/pdf1.pdf"
                    .AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_container")
                    .AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_container")
                    .Show(Page)
                End With
            Case "PDFPREVIOUS"
                Dim f As String = CStr(CInt(Cookie(Page, "Page")) - 1)
                If My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\data\forms\form1\pdf" & f & ".pdf") Then
                    Cookie(Page, "Page") = f
                    show.ReloadContainer("Page " & f, "data/forms/form1/pdf" & f & ".pdf")
                Else
                    show.DoNothing()
                End If
            Case "PDFNEXT"
                Dim f As String = CStr(CInt(Cookie(Page, "Page")) + 1)
                If My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\data\forms\form1\pdf" & f & ".pdf") Then
                    Cookie(Page, "Page") = f
                    show.ReloadContainer("Page " & f, "data/forms/form1/pdf" & f & ".pdf")
                Else
                    show.DoNothing()
                End If
            Case "CANCELHTM"
                ' do something here
            Case "OK"
                show.Message("OK")
            Case "LOGIN"
                ' m.Height = 200
                Dim m As New NSMenu With {
                    .Funct = CStr(2),
                    .Top = 100,
                    .Left = 100,
                    .Caption = "Login"
                }
                m.AddItem("bt/intro.png", Image, 2, "Enter here")
                'For x As Integer = 1 To 7
                '    m.AddButton("Test" & x, CType(x, ContaNet.Tools.DefaultIcons), , CStr(x))
                'Next
                m.AddButton("Send an email", "images/newclient.png", , "MAILTO")
                m.AddLabel("Just click below to enter", LabelColor.Yellow, NSEnums.Align.Center)
                m.AddLabel("No password or name required", LabelColor.Red, NSEnums.Align.Center)
                m.AddItem("Name", NSVars.Text, 30, "", "", "", Server.MapPath(".") & "\mykeyboard.txt")
                m.AddItem("Password", NSVars.Password, 30, "")
                '  m.AddItem("<b>';debugger;</b> <>ª|\&$", NSVars.Text, 30, Chr(34) & ";debugger;<>\|&$")
                '  m.AddItem("This is <b>bold</b> and this is <i>italic</i>", NSVars.Text, 20, "")
                m.Show(Page)
            Case "MAILTO"
                show.MailTo("test@test.com", "This is the subject", "This is the body")
            Case "ABCD"
                Dim mr As New ContaNet.Tools.NSShow.MenuValues
                With mr
                    .SetTextValue(2, "hola", "in spanish")
                    .SetTextValue(3, "hello", "in english")
                    .SetFocus(3)
                    .ReturnValues(Page)
                End With

            Case "2"
                Dim util As New NSUtil(Page)
                util.Cookie("LOGIN") = ""
                show.Reload()
            Case "ZERO"
                ' Stop
            Case "11"
                Dim grd1 As New NSGrid
                With grd1
                    .Caption = "Estimates"
                    .Calculator = True
                    '.Calendar = True
                    ' .fullScreen = True
                    .RepeatPreviousLine = True
                    .HiddenData = "Hidden Grid Data"
                    .LineNumbers = True
                    .Funct = "GRIDSAVE"
                    .AddTextBox("Month " & Chr(34) & " one", "January,February,March,April,May,June,July,August,September,October,November,December", MultipleSelection, 4, "GetMonth", , , "11MONTH")
                    .AddTextBox("Month two", "January,February,March,April,May,June,July,August,September,October,November,December", MultipleSelectionReturnsNumber, 4, "GetMonth2", , , "11MONTH")
                    .AddTextBox("Date", "31/12/14", DateSelect, 10, "Date1", "")
                    .AddTextBox("Total", "", Number_2dec, 12, "TotalGrid", "", 1)
                    .AddTextBox("Date", "31/12/14", DateSelect, 10, "Date2", "", 1)


                    .AddCol("Chanel", NonModifiableText, 3)
                    .AddCol("Date", DateSelect, 8, "")
                    .AddCol("Description", NSVars.Text, 35, , , "1111")
                    .AddCol("KEY", ZeroFilledNumber, 6)

                    .AddCol("Amount", Number, 12, , , "ADD")
                    .AddCol("Amount 1", Number_1dec, 12, , , "ADD")
                    .AddCol("Amount 2", Number_2dec, 12, , , "ADD")
                    .AddCol("Amount 3", Number_3dec, 12, , , "ADD")
                    .AddCol("Amount 4", Number_4dec, 12, , , "ADD")
                    .AddCol("Amount 5", Number_5dec, 12, , , "ADD")

                    .AddCol("File", FileUpload, 50)
                    .AddCol("Check", Checkbox, 1)
                    .ASPXPage = "Webform1.aspx"
                    .Rows = 10
                    .Show(Page)
                End With
            Case "GRIDSAVE"
                show.Message("Grid data could be saved here<br>Files saved to uploads")
            Case "ADD"
                Dim Total As Double = 0
                For y As Integer = 0 To core.Grid.Rows
                    For x As Integer = 4 To 9
                        Total += Val(core.Grid.CellValue(y, x))
                    Next
                Next

                Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                grdreturn.SetTextValue("TotalGrid", CStr(Total))
                Select Case core.Grid.Col
                    Case 4 To 8
                        grdreturn.Setfocus(core.Grid.Row, core.Grid.Col + 1)
                    Case 9
                        grdreturn.Setfocus(core.Grid.Row + 1, 1)
                End Select
                grdreturn.ReturnValues(Page)
            Case "1111"

                Dim Articulos() As String = {"01 ContaNet ORO", "02 Plata", "03 CRM", "04 Platino"}
                Dim Importes() As String = {"798.25", "255", "489", "2500"}
                Dim found As Boolean = False
                If core.Values(0) > "0" Then
                    Dim row As Integer = core.Grid.Row
                    Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                    Dim des As String = core.Grid.CellValue(core.Grid.Row, core.Grid.Col)
                    For x As Integer = 0 To UBound(Articulos) - 1
                        If Articulos(x).StartsWith(des) Then
                            grdreturn.AddColValue(row, 0, "111")
                            grdreturn.AddColValue(row, 2, Articulos(x).Substring(3))
                            grdreturn.AddColValue(row, 3, Importes(x))
                            grdreturn.Setfocus(core.Grid.Row, 4)
                            found = True
                            Exit For
                        End If
                    Next
                    If found Then grdreturn.ReturnValues(Page)
                End If
                show.List("my items", Articulos)

            Case "111"
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\mytest.txt", core.Grid.Clip, False)
                show.CloseCallingWindow()
            Case "Test"
                show.RedirectPage("Webform1.aspx", "Test3")
            Case "Test3"
                Stop
            Case "INVOICE"
                Dim grd1 As New NSGrid
                With grd1
                    .LineNumbers = False
                    .CenterScreen = True
                    .Caption = "Invoice"
                    .Name = "grd1"
                    .FontSize = 20
                    .ReturnCol = 4
                    .AddButton("New client", DefaultIcons.UserNew, , "CREATECLIENT")
                    .AddButton("Close me down", DefaultIcons.Cancel, , "CANCELGRID")
                    .AddButton("Invoice help", DefaultIcons.Help, , "GRIDHELP")
                    .AddTextBox("Client (see help file)", "", NSVars.Text, 35, "ClientName", , , "113A")
                    .AddTextBox("Client ID", "", NSVars.NonModifiableText, 10, "ClientID")
                    .AddTextBox("Date", Now.ToString("MM/dd/yy"), DateSelect, 8, "InvoiceDate", , 0)
                    .AddTextBox("Total", "", NSVars.NonModifiableNumber, 12, "Total")

                    .AddCol("Item", NSVars.Text, 10, "", , "113D")
                    .AddCol("Description", NSVars.Text, 45, "", , "113E")
                    .AddCol("Units", NSVars.Number, 12, , , "113C")
                    .AddCol("Amount", NonModifiableNumber, 12, , , "113C")
                    .AddCol("%", Number, 2, , , "113C")
                    .AddCol("Total", NonModifiableNumber, 15)
                    '  .MaxRows = 10
                    .Top = "200px"
                    .Left = "200px"
                    .Funct = "SAVEINVOICE"
                    .AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_creating_invoice_grid")
                    .AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_creating_invoice_grid")
                    .Rows = 5
                    .Show(Page)
                End With
            Case "GRIDHELP"
                show.HTMLFile("Help for Invoice", "help/VB/invoicehelp.html")
            Case "CANCELGRID"
                ' DO STUFF
                show.CloseCallingWindow()

            Case "SAVEINVOICE"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim Client As String = "Client ID: " & core.Grid.TextBoxValue("ClientID") & "<br/>"
                Client += "Name: " & core.Grid.TextBoxValue("ClientName")
                Dim Text As String = core.Grid.Clip
                Dim row As Integer = 0
                Dim Total As Double = 0
                For row = 0 To core.Grid.Rows
                    Total += util.Val(core.Grid.CellValue(row, 5))
                Next
                Text += vbNewLine & "*" & vbTab & "Total" & vbTab & vbTab & vbTab & vbTab & CStr(Total)
                Dim htm As New ContaNet.Tools.NSHTML
                With htm
                    .BackgroundColor = "white"
                    .TextColor = "black"
                    .Caption = "Invoice"
                    .Header = Client
                    .Text = Text
                    .AddCol("Item", Types.Text)
                    .AddCol("Description", Types.Text)
                    .AddCol("Units", Types.Number)
                    .AddCol("Amount", Types.Number)
                    .AddCol("%", Types.Text)
                    .AddCol("Total", Types.Number)
                    .Show(Page)
                End With
            Case "113A"
                Dim Found As Integer = -1
                Dim position As Integer = 0
                Dim clientName As String = core.Grid.TextBoxValue("CLIENTNAME")
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim TA(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                Dim clients(UBound(TA, 1)) As String
                If clientName.Trim = "" Then
                    For x As Integer = 0 To UBound(TA, 1)
                        clients(x) = TA(x, 0) & " - " & TA(x, 1).Trim & " " & TA(x, 2)
                    Next
                    show.List("Select one", clients, "113B")
                Else

                    For x As Integer = 0 To UBound(TA, 1)
                        If TA(x, 1).Trim.ToUpper & " " & TA(x, 2).Trim.ToUpper Like clientName.ToUpper & "*" Then
                            Found += 1
                            position = x
                            ReDim Preserve clients(Found)
                            clients(Found) = TA(x, 0) & " - " & TA(x, 1).Trim & " " & TA(x, 2)
                        End If
                    Next
                    Select Case Found
                        Case -1
                            show.Message("Client not found")
                        Case 0
                            Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                            grdreturn.SetTextValue("ClientID", TA(position, 0))
                            grdreturn.SetTextValue("ClientName", TA(position, 1).Trim & " " & TA(position, 2))
                            grdreturn.Setfocus(0, 0)
                            grdreturn.ReturnValues(Page)
                        Case Else
                            show.List("Select one", clients, "113B")
                    End Select
                End If
            Case "113B"
                Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                grdreturn.SetTextValue("ClientID", core.Values(0).Substring(0, core.Values(0).IndexOf(" ")))
                grdreturn.SetTextValue("ClientName", core.Values(0).Substring(core.Values(0).IndexOf("-") + 2))
                grdreturn.Setfocus(0, 0)
                grdreturn.ReturnValues(Page)
            Case "113C"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim row As Integer = core.Grid.Row
                Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                Dim importe As Double = Val(core.Grid.CellValue(row, 2)) * Val(core.Grid.CellValue(row, 3))
                Dim descuento As Double = importe * Val(core.Grid.CellValue(row, 4)) * 0.01
                importe -= descuento
                grdreturn.AddColValue(row, 5, util.NSFormat(importe))
                grdreturn.ReturnValues(Page)
            Case "113D", "113E", "113G"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim Artic(0) As String
                Dim des As String = ""
                If core.Funct = "113G" Then
                    des = core.Grid.CellValue(core.Grid.Row, core.Grid.Col)
                    des = des.Substring(0, des.IndexOf(" "))
                    If des = "" Then Exit Sub
                Else
                    des = core.Grid.CellValue(core.Grid.Row, core.Grid.Col)
                End If
                If des = "" Or des = "0" Then
                    ReDim Artic(UBound(AR, 1))
                    For x As Integer = 0 To UBound(AR, 1)
                        Artic(x) = AR(x, 0) & " " & AR(x, 1)
                    Next
                    show.List("Choose one", Artic, "113G")
                    Exit Sub
                End If
                Dim row As Integer = core.Grid.Row
                Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                Dim FocusCol As Integer = 0
                If core.Funct = "113E" Then des = "*" & des.ToUpper & "*" : FocusCol = 1
                Dim Found As Integer = -1
                Dim Counter As Integer = -1
                If des = "" Then
                    grdreturn.Setfocus(row, 0)
                    grdreturn.ReturnValues(Page)
                Else
                    For x As Integer = 0 To UBound(AR, 1)
                        Select Case core.Funct
                            Case "113D", "113G"
                                If AR(x, 0).Trim = des.Trim Then Found = x : Exit For
                            Case "113E"
                                If AR(x, 1).ToUpper Like des Then
                                    Found = x
                                    Counter += 1
                                    ReDim Preserve Artic(Counter)
                                    Artic(Counter) = AR(x, 0) & " " & AR(x, 1)
                                End If
                        End Select
                    Next
                    If Found > -1 Then
                        If Counter > 0 Then
                            show.List("Choose one", Artic, "113G")
                            Exit Sub
                        End If
                        grdreturn.AddColValue(row, 0, AR(Found, 0))
                        grdreturn.AddColValue(row, 1, AR(Found, 1))
                        grdreturn.AddColValue(row, 2, "1")
                        grdreturn.AddColValue(row, 3, util.NSFormat(CDbl(AR(Found, 3))))
                        grdreturn.AddColValue(row, 4, "10")
                        Dim importe As Double = util.Val(AR(Found, 3))
                        Dim descuento As Double = importe * 10 * 0.01
                        importe -= descuento
                        grdreturn.AddColValue(row, 5, util.NSFormat(importe))
                        grdreturn.SetTextValue("Total", util.NSFormat(GetTotal(core.Grid) + importe))
                        grdreturn.Setfocus(row + 1, FocusCol)
                    Else
                        grdreturn.Setfocus(row, 0)
                    End If
                    grdreturn.ReturnValues(Page)
                End If
            Case "114"
                Dim htm As New NSHTML With {
                    .Funct = "114A",
                    .Caption = "Price list",
                    .TextColor = "Black"
                }
                htm.AddCol("Units", Types.MultipleSelection)
                htm.AddCol("Description", Types.Text)
                htm.AddCol("Price (in Euros)", Types.Number)
                Dim Seleccion As String = "0,1,2,3,4,5,6,7,8,9,10"
                Dim Txt As New System.Text.StringBuilder
                Txt.Append(Seleccion & vbTab & "User license (valid for two servers)" & vbTab & "395" & vbNewLine)
                Txt.Append(Seleccion & vbTab & "Aditional licenses" & vbTab & "175" & vbNewLine)
                Txt.Append(Seleccion & vbTab & "Pack of 10 licenses" & vbTab & "1500" & vbNewLine)
                Txt.Append(Seleccion & vbTab & "Pack of 100 licenses" & vbTab & "10000" & vbNewLine)
                Txt.Append("_Updates" & vbNewLine)
                Txt.Append(Seleccion & vbTab & "Includes all updates for one year (per license)" & vbTab & "90" & vbNewLine)
                Txt.Append(Seleccion & vbTab & "Silver assistance plan (one year)" & vbTab & "390" & vbNewLine)
                Txt.Append(Seleccion & vbTab & "Gold assistance plan (one year)" & vbTab & "780" & vbNewLine)
                htm.Text = Txt.ToString
                htm.Show(Page)
            Case "114A"

            Case "SHOWCLIENTGRID"
                Dim grd1 As New NSGrid
                With grd1
                    .Caption = "Clients"
                    .AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_to_show_client_data_in_grid")
                    .AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_to_show_client_data_in_grid")
                    .ActivateDeleteLines = True
                    .ActivateInsertLines = True
                    .AddCol("ID", NonModifiableText, 10, "111")
                    .AddCol("First Name", NSVars.Text, 35, "")
                    .AddCol("Last Name", NSVars.Text, 35)
                    .AddCol("Phone", NSVars.MaskedEdit, 13, "(###) ###-####")
                    .AddCol("Title", NSVars.Text, 40)
                    .AddCol("Company", NSVars.Text, 35)
                    .AddCol("Sales", NSVars.Number_2dec, 12)
                    .AddCol("Checked", Checkbox, 1)
                    .AddCol("Date", DateSelect, 8)
                    .ASPXPage = "Webform1.aspx"
                    .Funct = "111"
                    .FontSize = 15
                    .Clip = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                    .Show(Page)
                End With

            Case "CANCEL"
                ' Stop
            Case "CANCEL1"
                'Stop
            Case "CLEAR"
                Dim grdreturn As New ContaNet.Tools.NSShow.GridValues With {
                    .Clear = True
                }
                grdreturn.Setfocus(0, 1)

                grdreturn.ReturnValues(Page)
            Case "CLIP"
                Dim grdreturn As New ContaNet.Tools.NSShow.GridValues
                grdreturn.Clip(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                grdreturn.ReturnValues(Page)
            Case "nSTYLE"
                Dim config() As String = GetStyle()
                Dim Numbers As String = "0"
                For x As Integer = 10 To 300 Step 10 : Numbers += "," & x : Next
                Dim Numbers2 As String = "5"
                For x As Integer = 6 To 40 : Numbers2 += "," & x : Next
                If Val(config(11)) > 40 Then config(11) = "20"

                Dim m As New NSMenu
                With m

                    Try


                        .TextboxClass = "textbox"
                        .AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_style_menu")
                        .AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_style_menu")

                        .Funct = "nStyleReturn"
                        .Caption = "Page style"
                        .AddItem("Preset Styles", MultipleSelection, 0, "," & GetFiles(Server.MapPath(".") & "\data\styles"), "", "cStyle")

                        .AddItem("Background", MultipleSelection, 0, GetBackground(), config(0))
                        .AddItem("Center background", Checkbox, 0, config(1))
                        .AddItem("Menu background image", MultipleSelection, 0, GetBackground(), config(2))
                        .AddItem("Menu color", Colors, 0, config(3))
                        .AddItem("Menu border width", MultipleSelection, 0, "1,2,3,4,5,6,7,8,9", config(4))
                        .AddItem("Menu border style", BorderStyle, 0, config(5))
                        .AddItem("Menu font color", Colors, 0, config(6))
                        .AddItem("No scrollbars", Checkbox, 0, config(7))
                        .AddItem("Menu background color", Colors, 0, config(8))
                        .AddItem("Menu border radius", MultipleSelection, 0, Numbers, config(9))
                        .AddItem("Menu font family", FontNames, 0, config(10))
                        .AddItem("Menu font size", MultipleSelection, 0, Numbers2, config(11))
                        .AddItem("Menu border color", Colors, 0, config(12))
                        .AddItem("Background Color", Colors, 0, config(13))
                        .AddItem("Icon Style", MultipleSelection, 0, "1,2,3", config(14))
                        .AddItem("Icon Columns", MultipleSelection, 0, "1,2,3,4,5,6,7,8,9,10,11,12", config(15))
                        .AddItem("Menu gradient color", Colors, 0, config(16))
                        .AddItem("Menu font color 1", Colors, 0, config(17))
                        .AddItem("Menu font color 2", Colors, 0, config(18))
                        .AddItem("Menu font color 3", Colors, 0, config(19))
                        .AddItem("Shadow", Checkbox, 1, config(20))
                        .AddItem("Include page items", Checkbox, 0, config(21))
                        .AddItem("Localization", MultipleSelection, 0, GetLocalization(), config(22))
                    Catch ex As Exception
                        show.Message("Error " & ex.Message)
                    End Try

                    .Show(Page)
                End With
            Case "cStyle"

                Dim config() As String = GetStyle(core.Menu.GetValue(0))
                Dim rm As New ContaNet.Tools.NSShow.MenuValues
                For x As Integer = 0 To config.GetUpperBound(0)
                    rm.SetTextValue(x + 1, config(x))
                Next
                rm.ReturnValues(Page)

            Case "nStyleReturn"
                Dim sb As New System.Text.StringBuilder
                For x As Integer = 1 To core.Menu.Count
                    sb.Append(core.Menu.GetValue(x) & ",")
                Next
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\style.txt", sb.ToString, False)
                Dim UTIL As New ContaNet.Tools.NSUtil(Page)
                UTIL.Cookie("STYLE", DateTime.Now.AddDays(1)) = "STYLE.TXT"
                show.Reload()

            Case "STYLE1"

                Dim config() As String = GetStyle()

                Dim Numbers As String = "0"
                For x As Integer = 10 To 300 Step 10 : Numbers += "," & x : Next
                Dim Numbers2 As String = "5"
                For x As Integer = 6 To 40 : Numbers2 += "," & x : Next
                If Val(config(11)) > 40 Then config(11) = "20"
                Dim m As New NSMenu
                With m

                    .Funct = "13A"
                    .Caption = "Page style"

                    .AddItem("Background", MultipleSelection, 0, GetBackground(), config(0))
                    .AddItem("Center background", Checkbox, 0, config(1))
                    .AddItem("Menu background image", MultipleSelection, 0, GetBackground(), config(2))
                    .AddItem("Menu color", Colors, 0, config(3))

                    .AddItem("Menu border width", MultipleSelection, 0, "1,2,3,4,5,6,7,8,9", config(4))
                    .AddItem("Menu border style", BorderStyle, 0, config(5))
                    .AddItem("Menu font color", Colors, 0, config(6))
                    .AddItem("No scrollbars", Checkbox, 0, config(7))
                    .AddItem("Menu background color", Colors, 0, config(8))
                    .AddItem("Menu border radius", MultipleSelection, 0, Numbers, config(9))
                    .AddItem("Menu font family", FontNames, 0, config(10))
                    .AddItem("Menu font size", MultipleSelection, 0, Numbers2, config(11))
                    .AddItem("Menu border color", Colors, 0, config(12))
                    .AddItem("Background Color", Colors, 0, config(13))
                    .AddItem("Icon Style", MultipleSelection, 0, "1,2,3", config(14))
                    .AddItem("Icon Columns", MultipleSelection, 0, "1,2,3,4,5,6,7,8,9,10,11,12", config(15))
                    .AddItem("Menu gradient color", Colors, 0, config(16))
                    .AddItem("Menu font color 1", Colors, 0, config(17))
                    .AddItem("Menu font color 2", Colors, 0, config(18))
                    .AddItem("Menu font color 3", Colors, 0, config(19))
                    .AddItem("Shadow", Checkbox, 1, config(20))
                    .Show(Page)
                End With
            Case "STYLE2"
                Dim m As New NSMenu
                With m
                    .Funct = "STYLE2A"
                    .Caption = "Save current style"
                    .AddLabel("The style will be available to other users of the demo", LabelColor.Bold, NSEnums.Align.Center)
                    .AddItem("Name for the current style", NSVars.Text, 30)
                    .Show(Page)
                End With
            Case "STYLE2A"
                Try
                    Dim FileName As String = core.Menu.GetValue(1)
                    If FileName.Trim.Length < 2 Then show.ErrorMessage("Please include a proper file name")
                    FileCopy(Server.MapPath(".") & "\data\style.txt", Server.MapPath(".") & "\data\styles\" & FileName & ".txt")
                Catch ex As Exception
                    show.ErrorMessage(ex.Message)
                End Try
                show.CloseCallingWindow()

            Case "STYLE3"
                Dim m As New NSMenu
                With m
                    .Funct = "STYLE3A"
                    .Caption = "Try a style"
                    .AddItem("Select one", MultipleSelection, 0, GetFiles(Server.MapPath(".") & "\data\styles"))
                    .Show(Page)
                End With
            Case "STYLE3A"
                Dim FileName As String = core.Menu.GetValue(0)
                If Not My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\data\styles\" & FileName) Then show.ErrorMessage("File does not exist")
                FileCopy(Server.MapPath(".") & "\data\styles\" & FileName, Server.MapPath(".") & "\data\style.txt")
                show.Reload()

            Case "13A"
                Dim sb As New System.Text.StringBuilder
                For x As Integer = 0 To core.Menu.Count
                    sb.Append(core.Menu.GetValue(x) & ",")
                Next
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\style.txt", sb.ToString, False)
                Dim UTIL As New ContaNet.Tools.NSUtil(Page)
                UTIL.Cookie("STYLE", DateTime.Now.AddDays(1)) = "STYLE.TXT"
                show.Reload()
            Case "32C"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Top = "100px",
                    .Left = "100px",
                    .Height = "300px",
                    .BorderWidth = 1,
                    .Caption = "Clients",
                    .BackgroundColor = "white",
                    .TextColor = "black",
                    .NewPageIcon = True,
                    .HiddenData = "HOLA"
                }
                If core.Funct = "32A" Then
                    htm.FullScreen = True
                    htm.AddButton("New client", DefaultIcons.UserNew, , "CREATECLIENT", "32A")
                End If
                htm.Header = Now.ToLongDateString
                'For x As Integer = 1 To 9
                '    htm.AddButton("Test" & x, CType(x, ContaNet.Tools.DefaultIcons), , CStr(x))
                'Next
                ' htm.AddButton("Add new client", "images/newclient.png")
                htm.Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                '  htm.AddCol(SpecialColumns.CSSClass)
                htm.AddCol("ID", NSHTML.Types.Text, , , "odd")
                htm.AddCol("First Name", NSHTML.Types.Text, , , "even")
                htm.AddCol("Last Name", NSHTML.Types.Text, , , "odd")
                htm.AddCol("Phone", NSHTML.Types.Text, , , "even")
                htm.AddCol("Title", NSHTML.Types.Text, , , "odd")
                htm.AddCol("Company", NSHTML.Types.Text, , , "even")
                htm.AddCol("Sales", NSHTML.Types.Number, , , "odd")
                htm.AddCol("Checked", NSHTML.Types.Text, , , "even")
                htm.Show(Page)
            Case "32A"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Top = "0px",
                    .Left = "0px",
                    .Caption = "Clients",
                    .BackgroundColor = "white",
                    .TextColor = "black",
                    .NewPageIcon = True,
                    .HiddenData = "HOLA"
                }
                htm.FullScreen = True
                htm.AddButton("New client", DefaultIcons.UserNew, , "CREATECLIENT", "32A")
                htm.Header = Now.ToLongDateString
                'For x As Integer = 1 To 9
                '    htm.AddButton("Test" & x, CType(x, ContaNet.Tools.DefaultIcons), , CStr(x))
                'Next
                ' htm.AddButton("Add new client", "images/newclient.png")
                htm.Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                '  htm.AddCol(SpecialColumns.CSSClass)
                htm.AddCol("ID", NSHTML.Types.Text, , , "odd")
                htm.AddCol("First Name", NSHTML.Types.Text, , , "even")
                htm.AddCol("Last Name", NSHTML.Types.Text, , , "odd")
                htm.AddCol("Phone", NSHTML.Types.Text, , , "even")
                htm.AddCol("Title", NSHTML.Types.Text, , , "odd")
                htm.AddCol("Company", NSHTML.Types.Text, , , "even")
                htm.AddCol("Sales", NSHTML.Types.Number, , , "odd")
                htm.AddCol("Checked", NSHTML.Types.Text, , , "even")
                htm.Show(Page)

            Case "32B", "32C"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Top = "100px",
                    .Left = "100px",
                    .Height = "300px",
                    .BorderWidth = 0,
                    .Caption = "Clients",
                    .BackgroundColor = "white",
                    .TextColor = "black",
                    .NewPageIcon = True
                }
                If core.Funct = "32A" Then htm.FullScreen = True
                htm.Header = Now.ToLongDateString
                Dim txt As String = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                Dim tx() As String = txt.Split(CChar(vbNewLine))
                Dim sb As New System.Text.StringBuilder
                Dim count As Integer = 0
                For x As Integer = 0 To tx.GetUpperBound(0)
                    If x Mod 10 = 0 Then
                        count += 1 : sb.Append(htm.Subheading & "subheading" & vbTab & "Group " & CStr(count) & vbNewLine)
                        sb.Append(htm.TableHeader & "subheading2" & vbTab & "ID" & vbTab & "First Name" & vbTab & "Last Name" & vbTab & "Phone" & vbTab & "Title" & vbTab & "Company" & vbTab & "Sales" & vbTab & "Checked" & vbNewLine)
                    End If
                    If x Mod 2 = 0 Then
                        sb.Append("even" & vbTab & tx(x) & vbNewLine) ' modify class in Webform1.aspx
                    Else
                        sb.Append("odd" & vbTab & tx(x) & vbNewLine)
                    End If
                Next
                htm.Text = sb.ToString
                htm.AddRowClassCol()

                htm.AddCol("", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Number)
                htm.AddCol("", NSHTML.Types.Text)
                htm.Show(Page)

            Case "33", "33A"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Clients",
                    .HiddenData = "Data from HTML",
                    .NewPageIcon = True,
                    .BackgroundColor = "white",
                    .TextColor = "black",
                    .Header = Now.ToLongDateString,
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                }
                htm.AddHyperlinkCol("ID", 1, "333", "33A", , Center)
                htm.AddCol("First Name", NSHTML.Types.Text)
                htm.AddCol("Last Name", NSHTML.Types.Text)
                htm.AddCol("Phone", NSHTML.Types.Text)
                htm.AddCol("Title", NSHTML.Types.Text, , Center)
                htm.AddCol("Company", NSHTML.Types.Text)
                htm.AddCol("Sales", NSHTML.Types.Number)
                htm.AddCol("Checked", NSHTML.Types.Text)

                htm.Show(Page)

            Case "34", "34A"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Clients",
                    .Header = Now.ToLongDateString,
                    .BorderWidth = 1,
                    .BorderColor = "darkblue",
                    .PositiveNumberColor = "black",
                    .NegativeNumberColor = "black",
                    .BackgroundColor = "antiquewhite",
                    .TextColor = "black",
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                }
                htm.AddCol("ID", NSHTML.Types.Invisible)
                htm.AddHyperlinkCol("First Name", 1, "333", "34A")
                htm.AddCol("Last Name", NSHTML.Types.Text)
                htm.AddCol("Phone", NSHTML.Types.Text)
                htm.AddCol("Title", NSHTML.Types.Text)
                htm.AddCol("Company", NSHTML.Types.Text)
                htm.AddCol("Sales", NSHTML.Types.Number)
                htm.AddCol("Checked", NSHTML.Types.Text)
                htm.Show(Page)
            Case "35"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Clients",
                    .HiddenData = "Test",
                    .Header = Now.ToLongDateString,
                    .BorderWidth = 1,
                    .BorderColor = "chocolate",
                    .BackgroundColor = "beige",
                    .TextColor = "black",
                    .Funct = "335",
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                }
                htm.AddCol("ID", NSHTML.Types.Text)
                htm.AddEditableCol("First Name", 1, 300, 30)
                htm.AddCol("Last Name", NSHTML.Types.Text)
                htm.AddCol("Phone", NSHTML.Types.Text)
                htm.AddCol("Title", NSHTML.Types.Text)
                htm.AddCol("Company", NSHTML.Types.Text)
                htm.AddCol("Sales", NSHTML.Types.Number)
                htm.AddCol("Checked", NSHTML.Types.Text, , Center)
                htm.Show(Page)
            Case "36" ' checkbox
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .TextColor = "black",
                    .BackgroundColor = "lightgreen",
                    .Caption = "Clients",
                    .Funct = "360",
                    .Header = Now.ToLongDateString,
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                }
                htm.AddCol("ID", NSHTML.Types.Text)
                htm.AddCol("First Name", NSHTML.Types.Text)
                htm.AddCol("Last Name", NSHTML.Types.Text)
                htm.AddCol("", NSHTML.Types.Invisible)
                htm.AddCol("", NSHTML.Types.Invisible)
                htm.AddCol("", NSHTML.Types.Invisible)
                htm.AddCol("", NSHTML.Types.Invisible)
                htm.AddCol(NSHTML.SpecialColumns.Checkbox, "Check", 1, "")
                htm.Show(Page)
            Case "SEARCHCLIENT"
                LoadHTMImage(core.TextBox(0))
            Case "HTMIMAGE"
                LoadHTMImage()
            Case "DELETECLIENT"
                Dim sb As New System.Text.StringBuilder
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                Dim ClientNumber As String = core.Values(0)
                For x As Integer = 0 To UBound(AR, 1)
                    If AR(x, 0).Trim = "" Then
                    ElseIf AR(x, 0).Trim = ClientNumber Then
                    Else
                        sb.Append(AR(x, 0))
                        For y = 1 To AR.GetUpperBound(1)
                            sb.Append(vbTab & AR(x, y))
                        Next
                        sb.Append(vbNewLine)
                    End If
                Next
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\mytest.txt", sb.ToString, False)
                show.DoNothing()
            Case "ARTIMAGECLICK"
                Dim m As New NSMenu
                With m
                    .HiddenData = core.HiddenData
                    .Caption = "New Photo"
                    .Funct = "UPLOADARTPHOTO"
                    .AddItem("Photo", FileUpload, 0)
                    .Show(Page)
                End With
            Case "UPLOADARTPHOTO"
                Dim photo As String = core.Values(0)
                My.Computer.FileSystem.CopyFile(Server.MapPath(".") & "\uploads\" & core.Values(0), Server.MapPath(".") & "\IMAGES\articles\PHOTO" & core.HiddenData & ".JPG", True)
                Dim rm As New ContaNet.Tools.NSShow.MenuValues
                Dim rnd As Random = New Random
                Dim aa As Integer = rnd.Next(1000000)
                rm.SetTextValue(0, "images/articles/photo" & core.HiddenData & ".jpg?" & CStr(aa))
                rm.ReturnValues(Page)

            Case "IMAGECLICK"
                Dim m As New NSMenu
                With m
                    .HiddenData = core.HiddenData
                    .Caption = "New Photo"
                    .Funct = "UPLOADPHOTO"
                    .AddItem("Photo", FileUpload, 0)
                    .Show(Page)
                End With
            Case "UPLOADPHOTO"
                Dim photo As String = core.Values(0)
                My.Computer.FileSystem.CopyFile(Server.MapPath(".") & "\uploads\" & core.Values(0), Server.MapPath(".") & "\IMAGES\CLIENTS\PHOTO" & core.HiddenData & ".JPG", True)
                Dim rm As New ContaNet.Tools.NSShow.MenuValues
                Dim rnd As Random = New Random
                Dim aa As Integer = rnd.Next(1000000)
                rm.SetTextValue(0, "images/clients/photo" & core.HiddenData & ".jpg?" & CStr(aa))
                rm.ReturnValues(Page)
                'show.CloseCallingWindow()
            Case "333"
                Dim Photo As String = ""
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                Dim Titles() As String = Split("ID,First Name,Last Name,Phone,Title,Company,Sales,Checked", ",")
                Dim Types() As String = Split("0,0,0,202,0,0,3,30", ",")
                Dim Widths() As String = Split("5,35,35,13,35,35,13,1", ",")
                Dim Masks() As String = Split(",,,(###)###-####,,,,", ",")
                For x As Integer = 0 To UBound(AR, 1)
                    If AR(x, 0) = core.Values(0) Then
                        If My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\IMAGES\CLIENTS\PHOTO" & core.Values(0) & ".JPG") Then
                            Photo = "PHOTO" & core.Values(0) & ".JPG"
                            Dim rnd As Random = New Random
                            Dim aa As Integer = rnd.Next(1000000)

                            Photo += "?" & CStr(aa)
                        Else
                            Photo = "Photo.jpg"
                        End If
                        Photo = "images/clients/" & Photo
                        Dim m As New NSMenu
                        With m
                            .Funct = "CREATECLIENT4"
                            .HiddenData = core.Values(0)
                            .Caption = "Edit client data"
                            .AddImage(Photo, 150, 150, Align2.MiddleLeft, "IMAGECLICK")
                            ' .AddItem("photo.png", Image, 0, "", "right", "IMAGECLICK")

                            For y As Integer = 1 To UBound(Titles)
                                .AddItem(Titles(y), CType(Types(y), NSVars), CInt(Widths(y)), AR(x, y), Masks(y))
                            Next
                            .CloseOnOK = NSMenu.CloseOnOKValues.CloseOnOK
                            .Show(Page)
                        End With
                        Exit For
                    End If
                Next

            Case "CREATECLIENT", "CREATECLIENT2"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                Dim Titles() As String = Split("ID,First Name,Last Name,Phone,Title,Company,Sales,Checked", ",")
                Dim Types() As String = Split("0,0,0,0,0,0,3,30", ",")
                Dim Widths() As String = Split("5,35,35,13,35,35,13,1", ",")

                Dim ClientNumber As Integer = GetNextClient()
                Dim m As New NSMenu
                With m
                    .Funct = "CREATECLIENT3"
                    .HiddenData = CStr(ClientNumber)
                    .Caption = "Create a new client: ID=" & CStr(ClientNumber)
                    .AddImage("images/clients/photo.jpg", 150, 150, Align2.MiddleLeft, "IMAGECLICK")
                    For y As Integer = 1 To UBound(Titles)
                        If y = 3 Then
                            .AddItem("Telephone", MaskedEdit, 14, "", "(###) ###-####")
                        Else
                            .AddItem(Titles(y), CType(Types(y), NSVars), CInt(Widths(y)), "")
                        End If
                    Next
                    .AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_creating_a_client")
                    .AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_creating_a_client")

                    .Show(Page)
                End With


            Case "CREATECLIENT3", "CREATECLIENT4"
                If core.Menu.GetValue(1).Trim = "" Then
                    show.Message("A name must be assigned to the client")
                End If
                Dim NewClient As String = ""
                Dim found As Boolean = False
                Dim Found2 As Boolean = False
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                Dim ID As String = core.HiddenData
                Try
                    If CInt(ID) > GetNextClient() Then show.Message("Invalid client id") : Exit Sub
                Catch ex As Exception
                    show.Message("Invalid client id")
                End Try
                If core.Funct = "CREATECLIENT4" Then
                    For x As Integer = 0 To UBound(AR, 1)
                        If AR(x, 0) = ID Then
                            Found2 = True
                            For y = 1 To UBound(AR, 2)
                                If AR(x, y).Trim <> core.Menu.GetValue(y).Trim Then
                                    found = True
                                    AR(x, y) = core.Menu.GetValue(y).Trim
                                End If
                            Next
                        End If
                    Next
                Else
                    If Not Found2 Then
                        NewClient += vbNewLine
                        NewClient += core.HiddenData
                        For y = 1 To core.Menu.Count
                            NewClient += vbTab & core.Menu.GetValue(y).Trim
                        Next
                    End If
                End If
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\mytest.txt", util.Array2Tab(AR) & NewClient, False)

                show.CloseCallingWindow()
            Case "334"
                show.Message("Invisible column " & core.Values(0))
            Case "335"
                ' RV.Values contains modified values
                Dim found As Boolean = False
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                For x As Integer = 0 To UBound(AR, 1)
                    Dim Value As String = core.HTML.GetEditText(AR(x, 0)).Value
                    If AR(x, 1).Trim <> Value.Trim Then
                        found = True
                        AR(x, 1) = Value.Trim
                    End If
                Next
                If found Then My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\mytest.txt", util.Array2Tab(AR), False)
                show.CloseCallingWindow()
            Case "360"
                Dim found As Boolean = False
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                For x As Integer = 0 To UBound(AR, 1)
                    Dim NewValue As String = core.HTML.GetCheckbox(AR(x, 0)).Value
                    If AR(x, 7).Trim <> NewValue.Trim Then
                        found = True
                        AR(x, 7) = NewValue.Trim
                    End If
                Next
                If found Then My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\mytest.txt", util.Array2Tab(AR), False)
                show.CloseCallingWindow()
            Case "370" To "373"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Clients",
                    .TextColor = "black",
                    .BackgroundColor = "white",
                    .NewPageIcon = False,
                    .Header = Now.ToLongDateString,
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt")
                }
                htm.AddCol("ID", NSHTML.Types.Text)
                htm.AddCol("First Name", NSHTML.Types.Text)
                htm.AddCol("Last Name", NSHTML.Types.Text)
                htm.AddCol("Phone", NSHTML.Types.Text)
                htm.AddCol("Title", NSHTML.Types.Text)
                htm.AddCol("Company", NSHTML.Types.Text)
                htm.AddCol("Sales", NSHTML.Types.Number)
                htm.AddCol("Checked", NSHTML.Types.Invisible)
                Dim Pos As Integer = CInt(core.Funct) - 370
                Select Case Pos
                    Case 0, 2
                        htm.ToolBar = ToolBar2(1)
                    Case 1, 3
                        htm.ToolBar = ToolBar2(10)
                End Select
                htm.ToolBarPosition = CType(CInt(core.Funct) - 370, ToolbarAlign)
                htm.Show(Page)
            Case "200"
                show.Video("Trailer", "http://media.w3.org/2010/05/sintel/trailer.mp4", , , , , , , "CANCELHTM", "HiddenValue")
            Case "CNVideo"
                show.Video("ContaNet Tools", "http://contanettools.cloudapp.net/demo/info/video/contanet tools.mp4", "images/cntools.jpg", , , 500, 700, True, , , "helpFiles/VB/Code to show video.htm")
            Case "2030" To "20399"
                If My.Computer.FileSystem.DirectoryExists(Server.MapPath(".") & "\info\video") Then
                    My.Computer.FileSystem.GetFiles(Server.MapPath(".") & "\info\video")
                    Dim Files() As String = GetFiles(Server.MapPath(".") & "\info\video", "*.mp4").Split(CChar(","))
                    show.Video(Files(CInt(core.Funct.Substring(3))), Server.MapPath(".") & "\info\video\" & Files(CInt(core.Funct.Substring(3))))
                Else
                    show.ErrorMessage("Folder does not exist: " & Server.MapPath(".") & "\info\video")
                End If

            Case "211"
                If Not My.Computer.FileSystem.DirectoryExists(Server.MapPath(".") & "\info\music") Then My.Computer.FileSystem.CreateDirectory(Server.MapPath(".") & "\info\music")
                Dim tv As New ContaNet.Tools.NSTreeView With {
                    .Funct = "3022"
                }
                tv.ShowFiles.Path = Server.MapPath(".") & "\info\music"
                tv.ShowFiles.SearchPattern = "*.mp3"
                tv.ShowFiles.ShowEmptyFolders = False
                tv.ShowFiles.ReturnFullPath = True
                tv.Caption = "Music"
                tv.ASPXPage = ""
                tv.BackgroundColor = "white"
                tv.TextColor = "black"
                tv.Show(Page)
            Case "220"
                show.Image("Boavista, Cabo Verde", "images/test/cabo verde 204.jpg", 100, 100, 600, , True)
            Case "221"
                show.Image("Maui", "images/test/maui 109.jpg")
            Case "SLIDESHOW", "SLIDER"
                Dim tv As New ContaNet.Tools.NSTreeView
                With tv
                    If core.Funct = "SLIDESHOW" Then
                        .Caption = "Slide Show"
                        .Funct = "SLIDESHOW2"
                    Else
                        .Caption = "Slider"
                        .Funct = "SLIDER2"
                    End If
                    .HiddenData = "this is Hidden data"
                    .FontSize = 20
                    .ShowFolders.Path = Server.MapPath(".") & "\info\images"
                    .ShowFolders.SearchPattern = "*.jpg"
                    .ShowFolders.ShowEmptyFolders = False
                    .UseIcons = False
                    .ASPXPage = ""
                    .BackgroundColor = "white"
                    .TextColor = "black"
                    .Show(Page)
                End With

            Case "SLIDESHOW2"
                show.SlideShow("Slideshow", core.Values(0), , , , , , , , , 3000, SlideShowStyles.zoom)
            Case "SLIDER2"
                show.Slider("Slider", core.Values(0))
            Case "TESTBUTTON"
                Dim m As New ContaNet.Tools.NSMenu
                With m
                    .Funct = "TESTBUTTON2"
                    .Caption = "Upload file"
                    .AddItem("Upload a file", FileUpload, 80)
                    .AddItem("Destination folder", NSVars.Text, 40, "Maui")
                    .CloseOnOK = NSMenu.CloseOnOKValues.CloseOnReturn
                    .Show(Page)
                End With
            Case "TESTBUTTON2"
                Dim f As String = core.Menu.GetValue(0)
                If f <> "" Then
                    f = Server.MapPath(".") & "\uploads\" & f
                    If Not My.Computer.FileSystem.DirectoryExists(Server.MapPath(".") & "\info\images\" & core.Menu.GetValue(1)) Then
                        My.Computer.FileSystem.CreateDirectory(Server.MapPath(".") & "\info\images\" & core.Menu.GetValue(1))
                    End If
                    FileCopy(f, Server.MapPath(".") & "\info\images\" & core.Menu.GetValue(1) & "\" & core.Menu.GetValue(0))
                End If
                show.CloseCallingWindow()

            Case "302", "302LARGE", "302X", "TESTBUTTON3"
                Dim tv As New ContaNet.Tools.NSTreeView
                tv.AddButton("test", DefaultIcons.About, , "TESTBUTTON", "TESTBUTTON3")
                tv.Funct = "3021"
                tv.FontSize = 15
                tv.AddCancelFunction("CANCELTV", "MY VALUE")
                If core.Funct = "302LARGE" Then
                    tv.IncludePreviewOfPictureFiles(True, 420, 600)
                ElseIf core.Funct = "302X" Then
                    tv.IncludePreviewOfPictureFiles(False)
                Else
                    tv.Modal = True ' modal treeview
                    tv.IncludePreviewOfPictureFiles(True, 70, 100)
                End If
                tv.ShowFiles.Path = Server.MapPath(".") & "\info\images"
                tv.ShowFiles.SearchPattern = "*.jpg"
                tv.ShowFiles.ShowEmptyFolders = False
                tv.ShowFiles.ReturnFullPath = True
                tv.Caption = "Images"
                tv.HiddenData = "this is hidden data"
                tv.BackgroundColor = "white"
                tv.TextColor = "black"
                tv.AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_to_show_images")
                tv.AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_to_show_images")
                tv.Show(Page)
            Case "CANCELTV"

            Case "3022"
                Dim Name As String = My.Computer.FileSystem.GetName(core.Values(0))
                Name = Name.Substring(0, Name.LastIndexOf("."))
                show.Audio(Name, core.Values(0))
            Case "3021"
                If Mobile Then
                    show.RedirectPage(core.Values(0))
                Else
                    Dim Name As String = My.Computer.FileSystem.GetName(core.Values(0))
                    Name = Name.Substring(0, Name.LastIndexOf("."))
                    show.Image(Name, core.Values(0))
                End If
            Case "LOCATE"
                Dim m As New ContaNet.Tools.NSMenu
                With m
                    .Funct = "LOCATE2"
                    .Caption = "Locate files"
                    .AddItem("File extension", MultipleSelection, 0, "jpg,xls,xlsx,doc,pdf,mp3,mp4")
                    .AddItem("Root folder", MultipleSelection, 0, "Documents,Images,Video,Music")
                    .AddItem("File name like", NSVars.Text, 20, "*")
                    .AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_locating_files_(part_1)")
                    .AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_locating_files_(part_1)")

                    .Show(Page)
                End With
            Case "LOCATE2"
                Dim Folder As String = ""
                Dim TipoArch As String = ""
                Dim NameLike As String = ""
                Try
                    Folder = core.Menu.GetValue(1)
                    NameLike = core.Menu.GetValue(2)
                    TipoArch = core.Menu.GetValue(0)

                    If NameLike.Contains("*") Or NameLike.Contains("?") Then
                    ElseIf NameLike = "" Then
                        NameLike = "*"
                    Else
                        NameLike = "*" & NameLike & "*"
                    End If

                    Select Case Folder.ToUpper
                        Case "DOCUMENTS"
                            Folder = Server.MapPath(".") & "\info"
                        Case Else
                            Folder = Server.MapPath(".") & "\info\" & Folder
                    End Select

                Catch ex As Exception
                    show.ErrorMessage(ex.Message)
                End Try

                Dim tv As New ContaNet.Tools.NSTreeView With {
                    .Funct = "SHOWEXCELFILES2"
                }
                tv.ShowFiles.Path = Folder
                tv.ShowFiles.SearchPattern = NameLike & "." & TipoArch
                tv.ShowFiles.ShowEmptyFolders = False
                tv.ShowFiles.ReturnFullPath = True
                tv.Caption = NameLike & "." & TipoArch.ToUpper
                tv.BackgroundColor = "white"
                tv.AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_for_locating_files_(part_2)")
                tv.AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_for_locating_files_(part_2)")

                tv.Show(Page)

            Case "SHOWEXCELFILES2"
                ShowFile(core.Values(0))
            Case "1301"
                show.Message(core.Values(0))

            Case "304" ' file upload

                Dim m As New ContaNet.Tools.NSMenu
                With m
                    .Funct = "304A"
                    .Caption = "Upload file"
                    .AddItem("Upload a file", FileUpload, 80)
                    .AddItem("Present after upload", NSVars.SelectOption, 0, "1")
                    .AddItem("Copy to folder", NSVars.SelectOption, 0, "")
                    .AddItem("Destination folder in documents", NSVars.Text, 40, "ContaNetTools")
                    .CloseOnOK = NSMenu.CloseOnOKValues.CloseOnReturn
                    .Show(Page)
                End With
            Case "304A"
                If Not My.Computer.FileSystem.FileExists(Page.Server.MapPath(".") & "\uploads\" & core.Menu.GetValue(0)) Then
                    show.ErrorMessage("El archvio no existe")
                    Exit Sub
                End If
                If core.Menu.GetOption = 1 Then
                    ShowFile(Page.Server.MapPath(".") & "\uploads\" & core.Menu.GetValue(0))
                Else
                    Try
                        Dim Folder As String = Server.MapPath(".") & "\info\" & core.Menu.GetValue(3)
                        If Not My.Computer.FileSystem.DirectoryExists(Folder) Then My.Computer.FileSystem.CreateDirectory(Folder)
                        My.Computer.FileSystem.CopyFile(Page.Server.MapPath(".") & "\uploads\" & core.Menu.GetValue(0), Folder & "\" & core.Menu.GetValue(0), True)

                    Catch ex As Exception
                        show.ErrorMessage(ex.Message)
                    End Try
                    show.CloseCallingWindow()
                End If
            Case "52"
                Dim m As New ContaNet.Tools.NSMenu
                With m
                    .Caption = "New Event"
                    .Funct = "52A"
                    .AddItem("User", NSVars.Text, 20, "")
                    .AddItem("Date", NSVars.DateSelect, 8, Now.ToString("MM/dd/yy"))
                    .AddItem("Time", NSVars.MaskedEdit, 5, "00:00", "##:##")
                    .AddItem("With notification", Checkbox, 0, "0")
                    .AddItem("Subject", NSVars.Notes, 99, "")
                    .AddItem("Days", NSVars.MultipleSelection, 0, "1,2,3,4,5,6,7,8,9,10")
                    .AddItem("Spanish ID (NIF)", Nif, 15, "")
                    .HiddenData = core.HiddenData
                    .Show(Page)
                End With
            Case "52A"
                show.Message(core.HiddenData)

            Case "56"

                Dim grd1 As New NSGrid
                With grd1

                    .Caption = "Estimates"
                    .Calculator = True
                    '.Calendar = True
                    ' .fullScreen = True
                    .RepeatPreviousLine = True

                    .AddTextBox("Total", "", NSVars.Number_2dec, 12, "TotalGrid", "")
                    .AddTextBox("Date", "31/12/14", DateSelect, 10, "Date1", "")
                    .AddTextBox("Total", "", NSVars.Number_2dec, 12, "TotalGrid", "", 1)
                    .AddTextBox("Date", "31/12/14", DateSelect, 10, "Date2", "", 1)

                    .AddCol("Chanel", NonModifiableNumber, 3)
                    .AddCol("Date", DateSelect, 8, "")

                    .AddCol("Description", NSVars.Text, 35, , , "1111")
                    .AddCol("Amount", Number_2dec, 12)
                    .AddCol("Check", Checkbox, 1, "")
                    .ASPXPage = "Webform1.aspx"
                    '  .Funct = 111
                    .Rows = 10
                    .Show(Page)
                End With



            Case "58"
                show.HTMLFile("Help file", Page.Server.MapPath(".") & "\data\help.html")
            Case "SHOWEXCELFILES"

                Dim Folder As String = Server.MapPath(".") & "\info"
                Dim tv As New ContaNet.Tools.NSTreeView With {
                    .Funct = "SHOWEXCELFILES2"
                }
                tv.ShowFiles.Path = Folder
                tv.ShowFiles.SearchPattern = "*.xls"
                tv.ShowFiles.ShowEmptyFolders = False
                tv.ShowFiles.ReturnFullPath = True
                tv.Caption = "EXCEL"
                tv.BackgroundColor = "grey"
                tv.AddButton("How to? (VB)", "images/vb.png", , "HELPVB_Code_to_show_treeview_with_Excel_files")
                tv.AddButton("How to? (C#)", "images/cs.png", , "HELPCS_Code_to_show_treeview_with_Excel_files")

                tv.Show(Page)

            Case "999"
                Select Case core.Values(0)
                    Case "LST"
                        Dim sv As New NSShow(Page)
                        sv.List("Chose a value", "ONE,TWO,THREE,FOUR".Split(CChar(",")))
                End Select
            Case "SELARTIC"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim sb As New System.Text.StringBuilder
                Dim Txt(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim ImageName As String = ""
                Dim CurrentPath As String = Server.MapPath(".") & "\images\articles\"
                Dim Seleccion As String = "0,1,2,3,4,5,6,7,8,9,10"

                For x As Integer = 0 To Txt.GetUpperBound(0)
                    If sb.Length > 0 Then sb.Append(vbNewLine)
                    If Val(Txt(x, 0)) > 0 Then
                        For y As Integer = 0 To 4
                            Select Case y
                                Case 0
                                    sb.Append(Txt(x, y))
                                Case 1
                                    If My.Computer.FileSystem.FileExists(CurrentPath & "PHOTO" & Txt(x, 0) & ".JPG") Then
                                        Dim rnd As Random = New Random
                                        ImageName = "images/articles/photo" & Txt(x, 0) & ".jpg" & "?" & CStr(rnd.Next(1000000))
                                    Else
                                        ImageName = "images/articles/photo.jpg"
                                    End If
                                    sb.Append(vbTab & ImageName)
                                Case 3
                                    sb.Append(vbTab & Seleccion)
                                Case 4
                                    sb.Append(vbTab & Txt(x, y - 1))
                                Case Else
                                    sb.Append(vbTab & Txt(x, y - 1))
                            End Select
                        Next
                    End If
                Next

                ' htm.NewPageIcon = True
                ' htm.Header = Now.ToLongDateString
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Articles",
                    .HiddenData = "Test hidden data",
                    .BackgroundColor = "white",
                    .TextColor = "black",
                    .Text = sb.ToString
                }
                htm.AddCol("ID", Types.Text)
                htm.AddImageCol("Image", 50, 50, , 1, "LARGEPHOTO")
                htm.AddCol("Description", NSHTML.Types.Text)
                htm.AddCol(NSHTML.SpecialColumns.MultipleSelection, "Units", 1)
                htm.AddCol("Price", NSHTML.Types.Number)
                htm.Funct = "SAVEORDER"
                htm.Show(Page)
            Case "SAVEORDER"
                Dim sb As New System.Text.StringBuilder
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim Value As Double = 0
                Dim Total1 As Double = 0
                Dim Total2 As Double = 0
                Dim Txt(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                For x As Integer = 0 To Txt.GetUpperBound(0)
                    Value = Val(core.HTML.GetMultipleSelection(Txt(x, 0)).Value)
                    If Value <> 0 Then
                        Total1 = Value * util.Val(Txt(x, 3))
                        Total2 += Total1
                        sb.Append(Txt(x, 0) & vbTab & Txt(x, 1) & vbTab & CStr(Value) & vbTab & Txt(x, 3) & vbTab & Total1 & vbNewLine)
                    End If
                Next
                sb.Append("*" & vbTab & "TOTAL" & vbTab & vbTab & vbTab & CStr(Total2) & vbNewLine)
                Dim htm As New ContaNet.Tools.NSHTML
                With htm
                    .Caption = "Your order"
                    .AddCol("ID", Types.Text)
                    .AddCol("Description", Types.Text)
                    .AddCol("Units", Types.Number)
                    .AddCol("Price", Types.Number)
                    .AddCol("Total", Types.Number)
                    .Text = sb.ToString
                    .TextColor = "black"
                    .BackgroundColor = "white"
                    .Show(Page)
                End With
            Case "LARGEPHOTO"
                Dim IMG As String = core.Values(0)
                If Not My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\images\articles\photo" & IMG & ".JPG") Then IMG = ""
                show.Image(GetArticle(core.Values(0)), "images/articles/photo" & IMG & ".JPG", , , 500)
            Case "B3"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim sb As New System.Text.StringBuilder
                Dim Txt(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim ImageName As String = ""
                Dim CurrentPath As String = Server.MapPath(".") & "\images\articles\"
                For x As Integer = 0 To Txt.GetUpperBound(0)
                    If sb.Length > 0 Then sb.Append(vbNewLine)
                    For y As Integer = 0 To Txt.GetUpperBound(1)
                        If Val(Txt(x, 0)) > 0 Then
                            Select Case y
                                Case 0
                                    If My.Computer.FileSystem.FileExists(CurrentPath & "PHOTO" & Txt(x, y) & ".JPG") Then
                                        Dim rnd As Random = New Random
                                        ImageName = "images/articles/photo" & Txt(x, y) & ".jpg" & "?" & CStr(rnd.Next(1000000))
                                    Else
                                        ImageName = "images/articles/photo.jpg"
                                    End If
                                    sb.Append(Txt(x, y) & vbTab & ImageName)
                                Case Else
                                    sb.Append(vbTab & Txt(x, y))
                            End Select
                        End If
                    Next
                Next

                ' htm.Header = Now.ToLongDateString
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Articles",
                    .NewPageIcon = True,
                    .HiddenData = "Test hidden data",
                    .BackgroundColor = "white",
                    .TextColor = "black",
                    .Text = sb.ToString
                }
                htm.AddHyperlinkCol("ID", 1, "B3A", "B3")
                htm.AddImageCol("Image", 50, 50, , 1, "ChangeImage", "B3")
                htm.AddCol("Description", NSHTML.Types.Text)
                htm.AddCol("Units", NSHTML.Types.Number)
                htm.AddCol("Price", NSHTML.Types.Number)
                htm.LockHeaders = True
                htm.Show(Page)
            Case "ChangeImage"
                Dim m As New NSMenu
                With m
                    .HiddenData = core.Values(0)
                    .Caption = "New Photo"
                    .Funct = "SavePhoto2"
                    .AddItem("Photo", FileUpload, 0)
                    .Show(Page)
                End With
            Case "SavePhoto2"
                Dim photo As String = core.Values(0)
                My.Computer.FileSystem.CopyFile(Server.MapPath(".") & "\uploads\" & core.Values(0), Server.MapPath(".") & "\IMAGES\articles\PHOTO" & core.HiddenData & ".JPG", True)
                show.CloseCallingWindow()
            Case "B3A"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim Titles() As String = Split("ID,Description,Units,Price", ",")
                Dim Types() As String = Split("0,0,3,3", ",")
                Dim Widths() As String = Split("5,35,13,13", ",")
                For x As Integer = 0 To UBound(AR, 1)
                    If AR(x, 0) = core.Values(0) Then
                        Dim m As New NSMenu
                        With m
                            .Funct = "B3B"
                            .Caption = core.Values(0)
                            .HiddenData = core.Values(0)
                            Dim photo As String = ""
                            If My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\IMAGES\articles\PHOTO" & core.Values(0) & ".JPG") Then
                                photo = "PHOTO" & core.Values(0) & ".JPG"
                                Dim rnd As Random = New Random
                                Dim aa As Integer = rnd.Next(1000000)

                                photo += "?" & CStr(aa)
                            Else
                                photo = "Photo.jpg"
                            End If
                            photo = "images/articles/" & photo
                            .AddImage(photo, 150, 150, Align2.MiddleLeft, "ARTIMAGECLICK")
                            For y As Integer = 1 To UBound(Titles)
                                .AddItem(Titles(y), CType(Types(y), NSVars), CInt(Widths(y)), AR(x, y))
                            Next
                            .Show(Page)
                        End With
                        Exit For
                    End If
                Next
            Case "B3B"
                If core.Menu.GetValue(1).Trim = "" Then
                    show.Message("A description must be assigned to the article")
                End If
                Dim NewArtic As String = ""
                Dim found As Boolean = False
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim ID As String = core.Menu.Caption.Trim
                For x As Integer = 0 To UBound(AR, 1)
                    If AR(x, 0) = ID Then
                        For y = 1 To UBound(AR, 2)
                            If AR(x, y).Trim <> core.Menu.GetValue(y).Trim Then
                                found = True
                                AR(x, y) = core.Menu.GetValue(y).Trim
                            End If
                        Next
                    End If
                Next
                If Not found Then
                    NewArtic += vbNewLine
                    NewArtic += core.Menu.Caption.Trim
                    For y = 1 To core.Menu.Count
                        NewArtic += vbTab & core.Menu.GetValue(y).Trim
                    Next
                End If
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\artic.txt", util.Array2Tab(AR) & NewArtic, False)
                CleanUpFile("artic.txt")
                show.CloseCallingWindow()
            Case "B4"
                Dim grd1 As New NSGrid
                With grd1
                    '  .Top = 0
                    '  .Left = 0
                    '  .Height = 1000
                    .Caption = "ARTICLES"
                    .AddCol("ID", NonModifiableText, 10)
                    .AddCol("Description", NSVars.Text, 35, "")
                    .AddCol("Units", Number_2dec, 12)
                    .AddCol("Price", Number_2dec, 12)
                    .Funct = "B41"
                    .Clip = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt").Replace(",", ".")
                    .Show(Page)
                End With
            Case "B41"
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\artic.txt", core.Grid.Clip, False)
            Case "B5"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim NewID As Integer = 0
                For x As Integer = 0 To UBound(AR, 1)
                    Try
                        If CInt(AR(x, 0)) > NewID Then NewID = CInt(AR(x, 0))
                    Catch ex As Exception

                    End Try
                Next
                NewID += 1
                Dim m As New NSMenu
                With m
                    .Caption = "Create a new article"
                    '  .AddImage(Photo, 150, 150, Align2.MiddleLeft, "IMAGECLICK")
                    .AddItem("ID", NSVars.NonModifiableText, 5, CStr(NewID))
                    .AddItem("Description", NSVars.Text, 35, "")
                    .AddItem("Units", Number, 12, "")
                    .AddItem("Price", Number_2dec, 12, "")
                    .Funct = "B5A"
                    .Show(Page)
                End With
            Case "B5A"
                Dim NewArtic As String = vbNewLine
                For y = 1 To core.Menu.Count
                    NewArtic += core.Menu.GetValue(y - 1).Trim & vbTab
                Next
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\artic.txt", NewArtic, True)
                show.CloseCallingWindow()

            Case "B6"
                Dim htm As New ContaNet.Tools.NSHTML With {
                    .Caption = "Delete Articles",
                    .NewPageIcon = True,
                    .Header = Now.ToLongDateString,
                    .Text = My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt")
                }
                htm.AddHyperlinkCol("ID", 1, "B6A", "B6")
                htm.AddCol("Description", NSHTML.Types.Text)
                htm.AddCol("Units", NSHTML.Types.Number)
                htm.AddCol("Price", NSHTML.Types.Number)
                htm.BackgroundColor = "WHITE"
                htm.TextColor = "BLACK"
                htm.Show(Page)
            Case "B6A"
                Dim id = core.Values(0)
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim Ar2(UBound(AR, 1), UBound(AR, 2)) As String
                Dim Counter As Integer = -1
                For x As Integer = 0 To UBound(AR)
                    If AR(x, 0) <> id Then
                        Counter += 1
                        For y As Integer = 0 To UBound(AR, 2)
                            Ar2(Counter, y) = AR(x, y)
                        Next
                    End If
                Next
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\artic.txt", util.Array2Tab(Ar2), False)
                CleanUpFile("ARTIC.TXT")
                show.CloseCallingWindow()
            Case "1005", "1006"
                Dim m As New NSMenu
                Dim Des As String = "Country"
                With m
                    .Funct = "1005A"
                    If core.Funct = "1005" Then
                        .Caption = "Choose one"
                    Else
                        .Caption = "Elegir uno"
                        Des = "Pais"
                    End If

                    m.AddItem(Des, NSVars.Country, 30, "United States")
                    m.AddItem(Des & " (ISO3166-2)", NSVars.Countries_ISO3166_2, 30, "US")
                    m.AddItem(Des & " (ISO3166-3)", NSVars.Countries_ISO3166_3, 30, "USA")
                    m.AddItem(Des & " (ISO3166-N)", NSVars.Countries_ISO3166_N, 30, "840")


                    If core.Funct = "1005" Then
                        m.AddItem("ISO4127", NSVars.CurrencyCodes_ISO4127, 30, "USD")
                    Else
                        m.AddItem("ISO6391", NSVars.Countries_ISO6391_Spanish, 30)
                    End If
                    m.Show(Page)

                End With
            Case "1005A"
                Dim HTM As String = ""
                For X As Integer = 0 To core.Menu.Count
                    HTM += core.Menu.GetDescription(X) & vbTab & core.Menu.GetValue(X) & vbNewLine
                Next

                Dim HTML As New ContaNet.Tools.NSHTML With {
                    .Caption = "You chose"
                }
                HTML.AddCol("Selecction", Types.Text)
                HTML.AddCol("Selected option", Types.Text)
                HTML.BackgroundColor = "lightskyblue"
                HTML.Text = HTM
                HTML.Show(Page)

            Case "ChangeStyle"
                Dim m As New NSMenu With {
                    .Funct = "ChangeStyle1",
                    .Caption = "Styles"
                }
                Dim Styles As String = GetFiles(Server.MapPath(".") & "\data\styles")
                Dim S1() As String = Styles.Split(CChar(","))
                For x As Integer = 0 To S1.GetUpperBound(0) - 1
                    m.AddItem(S1(x).Substring(0, S1(x).Length - 4), SelectOption, 0)
                Next
                m.Show(Page)
            Case "ChangeStyle1"
                Dim FileName As String = core.Menu.GetDescription(core.Menu.GetOption - 1) & ".txt"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                util.Cookie("STYLE", DateTime.Now.AddDays(1)) = FileName
                'If Not My.Computer.FileSystem.FileExists(Server.MapPath(".") & "\data\styles\" & FileName) Then show.ErrorMessage("File does not exist")
                'FileCopy(Server.MapPath(".") & "\data\styles\" & FileName, Server.MapPath(".") & "\data\style.txt")
                show.Reload()
            Case "ShowHelp"
                Dim tv As New ContaNet.Tools.NSTreeView With {
                    .Funct = "ShowHelp1"
                }
                tv.ShowFiles.Path = Server.MapPath(".") & "\help"
                tv.ShowFiles.SearchPattern = "*.pdf"
                tv.ShowFiles.ShowEmptyFolders = False
                tv.ShowFiles.ReturnFullPath = True
                tv.Caption = "Help"

                tv.BackgroundColor = "pink"
                tv.Show(Page)
            Case "ShowHelp1"
                If Mobile Then
                    show.RedirectPage(core.Values(0))
                Else
                    show.PDF("Help", core.Values(0), , , , , 600, 700, True)
                End If
            Case "AboutDemos"
                show.Message("As we are VB programmers, the VB demo is complete, but the C# demo isn't. Sorry about any inconvenience.<br/>Also note that this is not intended to be a demostration of how to use a database. We have used text files for our database to keep it as simple as possible for demostration purposes.<br>The demo can be used for free for as long as you like both for development as well as production. A small ad for our products will appear at the bottom of the page in the demo version.")
            Case "VBDEMO", "CSDEMO", "DLL"
                Dim M As New NSMenu
                With M
                    .Funct = core.Funct & "1"
                    .Caption = "End users licence"
                    .AddLabel("Please read the following end users licence", LabelColor.Red, NSEnums.Align.Center)
                    .AddItem("English", SelectOption, 0, "1", "", "EULAEN")
                    .AddItem("Español", SelectOption, 0, "", "", "EULAES")
                    .AddItem("", NSVars.NonModifiableNotes, 60, My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\eula.txt", System.Text.Encoding.UTF7))
                    .AddLabel("Mark the checkbox if you approve and accept the conditions", LabelColor.Red, NSEnums.Align.Center)
                    .AddItem("I accept the conditions", Checkbox, 0, "")
                    .Show(Page)
                End With
            Case "EULAEN"
                Dim rm As New ContaNet.Tools.NSShow.MenuValues
                rm.SetCaption("End users licence")
                rm.SetTextValue(0, "Please read the following end users licence")
                rm.SetTextValue(3, My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\eula.txt", System.Text.Encoding.UTF7).Replace(vbTab, " "))
                rm.SetTextValue(4, "Mark the checkbox if you approve and accept the conditions")
                rm.SetTextValue(5, "0", , "I accept the conditions")

                rm.ReturnValues(Page)
            Case "EULAES"
                Dim rm As New ContaNet.Tools.NSShow.MenuValues
                rm.SetCaption("Licencia de usuario")
                rm.SetTextValue(0, "Por favor lea detenidamente la licencia de usuario")
                rm.SetTextValue(3, My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\cluf.txt", System.Text.Encoding.UTF7))
                rm.SetTextValue(4, "Marque la casilla si acepta las condiciones")

                rm.SetTextValue(5, "0", , "Acepto las condiciones")
                rm.ReturnValues(Page)
            Case "VBDEMO1"
                If core.Menu.GetValue(5) = "1" Then show.DownloadFile(Server.MapPath(".") & "\DOWNLOADS\VBDEMO.ZIP")
                show.Message("You must accept the terms and conditions to download the demo")
            Case "CSDEMO1"
                If core.Menu.GetValue(5) = "1" Then show.DownloadFile(Server.MapPath(".") & "\DOWNLOADS\CSDEMO.ZIP")
                show.Message("You must accept the terms and conditions to download the demo")
            Case "DLL1"
                If core.Menu.GetValue(5) = "1" Then show.DownloadFile(Server.MapPath(".") & "\DOWNLOADS\CONTANET.TOOLS.ZIP")
                show.Message("You must accept the terms and conditions to download the DLL")
            Case "1999"
                Dim util As New NSUtil(Page)
                util.Cookie("LOGIN") = "FALSE"
                show.RedirectPage("WebForm1.aspx")

            Case "RELOAD"
                show.RedirectPage("WebForm1.aspx", "RELOAD2", "CLIENTID")
            Case "RELOAD2"
                show.Message("This executed after page reload")
            Case "PROGRESS"
                Dim m As New NSMenu
                With m
                    .AddProgressBar("ENDPROGRESS")
                    .Funct = "PROGRESS2"
                    .Caption = "Progress bar demo"
                    .AddLabel("Progress bar for long operations", LabelColor.Grey, NSEnums.Align.Center)
                    .Show(Page)
                End With
            Case "PROGRESS2"
                Dim pc As New ProgressCtrl
                pc.Progress(Page, core)
                show.DoNothing()

            Case "ENDPROGRESS"
                show.Message("Progress finished")
            Case "ADDITION"
                Dim m As New NSMenu
                With m
                    .Caption = "ADDITION"
                    .Funct = "ADDTOTAL"
                    For x As Integer = 0 To 5
                        .AddItem("Amount " & x, Number_2dec, 12, "", "", "ADDIT" & CStr(x))
                    Next
                    .AddItem("TOTAL", NonModifiableNumber, 12)
                    .Show(Page)
                End With
            Case "ADDIT0" To "ADDIT5"
                Dim util As New ContaNet.Tools.NSUtil(Page)

                Dim Total As Double = 0
                For X As Integer = 0 To 5
                    Total += util.Val(core.Menu.GetValue(X))
                Next
                Dim mr As New ContaNet.Tools.NSShow.MenuValues
                With mr
                    .SetTextValue(6, util.NSFormat(Total), "Total")
                    .SetFocus(CInt(core.Funct.Substring(5, 1)) + 1)
                    .ReturnValues(Page)
                End With
            Case "ADDTOTAL"
                show.Message("Total is: " & core.Menu.GetValue(6))
            Case "MATH"
                Dim m As New NSMenu
                With m
                    .Caption = "MATH"
                    .Funct = "MATH2"
                    .AddItem("Start with", Number_2dec, 12, "", "", "MATH3")
                    .AddItem("Add this to it", Number_2dec, 12, "", "", "MATH3")
                    .AddItem("Subtract this", Number_2dec, 12, "", "", "MATH3")
                    .AddItem("Multiply by", Number_2dec, 12, "1", "", "MATH3")
                    .AddItem("Divide by", Number_2dec, 12, "1", "", "MATH3")
                    .AddItem("TOTAL", NonModifiableNumber, 12)
                    .Show(Page)
                End With
            Case "MATH2"
                show.Message("Amount is " & core.Menu.GetValue(5))
            Case "MATH3"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim Amount As Double
                Amount = util.Val(core.Menu.GetValue(0))
                Dim MENU As New NSShow.MenuValues
                With MENU
                    Amount += util.Val(core.Menu.GetValue(1))
                    .SetTextValue(1, core.Menu.GetValue(1), CStr(Amount))
                    Amount -= util.Val(core.Menu.GetValue(2))
                    .SetTextValue(2, core.Menu.GetValue(2), CStr(Amount))
                    Amount = Amount * util.Val(core.Menu.GetValue(3))
                    .SetTextValue(3, core.Menu.GetValue(3), CStr(Amount))
                    Dim imp As Double = util.Val(core.Menu.GetValue(4))
                    If imp <> 0 Then Amount = Amount / imp Else Amount = 0
                    .SetTextValue(4, core.Menu.GetValue(4), CStr(Amount))
                    .SetTextValue(5, CStr(Amount), "--- Total")
                    .ReturnValues(Page)
                    Exit Sub
                End With
            Case "DYSELECT"
                Dim m As New NSMenu
                With m
                    .Caption = "Dinamic select"
                    .Funct = "DYSELECTOK"
                    .AddItem("Article code (Try 0, 1, or TOM)", NSVars.Text, 10, "", "", "DYSELECT2")
                    .AddItem("Description", NSVars.Text, 30)
                    .AddItem("Price", Number_2dec, 12)
                    .Show(Page)
                End With
            Case "DYSELECTOK"
                show.Message("OK")
            Case "DYSELECT2"
                Dim y As Integer = 0
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim Artic(0) As String
                Dim des As String = core.Menu.GetValue(0).Trim
                If des = "" Or des = "0" Then
                    ReDim Artic(UBound(AR, 1))
                    For x As Integer = 0 To UBound(AR, 1)
                        Artic(x) = AR(x, 0) & " " & AR(x, 1)
                    Next
                    show.List("Choose one", Artic, "DYSELECT3")
                    Exit Sub
                Else
                    Dim Found As Boolean = False
                    For X As Integer = 0 To AR.GetUpperBound(0)
                        If des = AR(X, 0) Then
                            Dim MENU As New NSShow.MenuValues
                            With MENU
                                .SetTextValue(1, AR(X, 1))
                                .SetTextValue(2, AR(X, 3))
                                .SetFocus(4)
                                .ReturnValues(Page)
                                Found = True
                                Exit Sub
                            End With
                        End If
                    Next
                    If Not Found Then
                        des = UCase(des)
                        For X As Integer = 0 To AR.GetUpperBound(0)
                            If InStr(UCase(AR(X, 1)), des) > 0 Then
                                ReDim Preserve Artic(y)
                                Artic(y) = AR(X, 0) & " " & AR(X, 1)
                                y = y + 1
                                Found = True
                            End If
                        Next
                        If Found Then
                            show.List("Choose one", Artic, "DYSELECT3")
                        Else
                            Dim m As New NSMenu
                            With m
                                .Caption = "Create a new article"
                                .AddItem("ID", NSVars.NonModifiableText, 5, des)
                                .AddItem("Description", NSVars.Text, 35, "")
                                .AddItem("Units", Number, 12, "")
                                .AddItem("Price", Number_2dec, 12, "")
                                .Funct = "CR4"
                                .Show(Page)
                            End With
                        End If
                    End If
                End If
            Case "DYSELECT3"
                Dim Des As String = core.Values(0)
                Des = Des.Substring(0, Des.IndexOf(" "))
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                For X As Integer = 0 To AR.GetUpperBound(0)
                    If Des = AR(X, 0) Then
                        Dim MENU As New NSShow.MenuValues
                        With MENU
                            .SetTextValue(0, AR(X, 0))
                            .SetTextValue(1, AR(X, 1))
                            .SetTextValue(2, AR(X, 3))
                            .SetFocus(4)
                            .ReturnValues(Page)
                            Exit Sub
                        End With
                    End If
                Next
            Case "CR4"
                Dim NewArtic As String = vbNewLine
                For y = 1 To core.Menu.Count
                    NewArtic += core.Menu.GetValue(y - 1).Trim & vbTab
                Next
                My.Computer.FileSystem.WriteAllText(Server.MapPath(".") & "\data\artic.txt", NewArtic, True)
                CleanUpFile("artic.txt")

                Dim MENU As New NSShow.MenuValues
                With MENU
                    .SetTextValue(1, core.Menu.GetValue(1))
                    .SetTextValue(2, core.Menu.GetValue(3))
                    .SetFocus(4)
                    .ReturnValues(Page)
                End With
            Case "OPTION"
                Dim m As New NSMenu
                With m
                    .Funct = "OPTIONMULTI"
                    .Caption = "Option/Multiselect"
                    .AddItem("Clients", SelectOption, 0, "", "", "OPTION1")
                    .AddItem("Articles", SelectOption, 0, "", "", "OPTION2")
                    .AddItem("MultiSelect", MultipleSelection, 0)
                    .Show(Page)
                End With
            Case "OPTIONMULTI"
                show.Message(core.Menu.GetValue(2))
            Case "OPTION2"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
                Dim sb As New System.Text.StringBuilder
                For x As Integer = 0 To AR.GetUpperBound(0)
                    sb.Append(AR(x, 0) & " " & AR(x, 1) & ",")
                Next
                Dim m As New NSShow.MenuValues
                With m
                    .SetTextValue(2, sb.ToString, "Articles")
                    .ReturnValues(Page)
                End With
            Case "OPTION1"
                Dim util As New ContaNet.Tools.NSUtil(Page)
                Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
                Dim sb As New System.Text.StringBuilder
                For x As Integer = 0 To AR.GetUpperBound(0)
                    sb.Append(AR(x, 0) & " " & AR(x, 1) & ",")
                Next
                Dim m As New NSShow.MenuValues
                With m
                    .SetTextValue(2, sb.ToString, "Clients")
                    .ReturnValues(Page)
                End With
            Case "OPTM2A", "OPTM2B"
                Dim Tipo As NSVars = MultipleSelection
                Dim Caption As String = "SELECT"
                If core.Funct = "OPTM2A" Then Tipo = Combo : Caption = "DataList"

                Dim m As New NSMenu
                With m
                    .Funct = "OPTIONMULTI"
                    .Caption = Caption
                    .AddLabel("Try United States or Spain", LabelColor.Yellow, NSEnums.Align.Center)
                    .AddItem("Country", Country, 0, "", "", "COUNTRY1")
                    .AddItem("STATE/PROVINCE", Tipo, 0, "one,two,three,four")
                    .Show(Page)
                End With
            Case "COUNTRY1"
                Dim Util As New ContaNet.Tools.NSUtil(Page)
                Dim m As New NSShow.MenuValues
                Select Case core.Menu.GetValue(1).ToUpper
                    Case "UNITED STATES", "ESTADOS UNIDOS"
                        Dim states() As String = Util.States()
                        With m
                            .SetTextValue(2, Join(states, ","), "States")
                            .ReturnValues(Page)
                        End With

                    Case "SPAIN", "ESPAÑA"
                        Dim prov() As String = Util.ProvinciasDeEspaña()
                        With m
                            .SetTextValue(2, Join(prov, ","), "Spanish Provinces")
                            .ReturnValues(Page)
                        End With
                    Case Else
                        With m
                            .SetTextValue(2, "", " ")
                            .ReturnValues(Page)
                        End With

                End Select
            Case "TREEVIEWTEST1"
                ShowTreeview("one")
            Case "TREEVIEWTEST2"
                ShowTreeview("TWO")

            Case "FUNCT0" To "FUNCT999"
                show.Message("You choose: " & core.Funct)
            Case "TREEVIEWTEST2"
                Dim TV As New ContaNet.Tools.NSTreeView
                With TV
                    .Caption = "test"
                    .FontSize = 20
                    .UseIcons = True
                    .Icon = "images/tv-icons2.png"

                    For X As Integer = 1 To 5
                        .AddNode("Top" & X, "TOP" & X)
                        For Y As Integer = 1 To 5
                            .AddNode("SUB" & X & Y, "SUB" & X & Y, "TOP" & X)
                            For Z As Integer = 1 To 5
                                .AddNode("NODE adflkj asfklj sflkjsfl ksjdf lksjflk sjflksj lskfj " & X & Y & Z, , "SUB" & X & Y, "FUNCT" & X & Y & Z)
                            Next
                        Next
                    Next
                    .Show(Page)
                End With
            Case "ONBEFOREUNLOAD"
                ' DO SOMETHING
            Case "ONUNLOAD"
                ' DO SOMETHING ELSE
            Case "TESTCOOKIE"
                Dim U As New NSUtil(Page)
                U.Cookie("TEST1") = "Progamación "
            Case "TESTCOOKIE2"
                Dim U As New NSUtil(Page)
                show.Message(U.Cookie("TEST1"))
            Case Else
                '  show.Message("Option chosen was:  " & core.Funct)
        End Select
        '  show.Message("OK")
    End Sub


    Sub CleanUpFile(ByVal FileName As String)
        Dim FiName As String = Server.MapPath(".") & "\data\" & FileName
        Dim util As New ContaNet.Tools.NSUtil(Page)
        Dim data As String = My.Computer.FileSystem.ReadAllText(FiName).Replace(Chr(10) & Chr(10), Chr(10))
        Dim AR(,) As String = util.Tab2Array(data)
        Dim AR2() As String = data.Split(CChar(vbNewLine))
        Dim sb As New System.Text.StringBuilder
        Dim Max As Integer = 0
        For x As Integer = 0 To AR.GetUpperBound(0)
            If Max < CInt(Val(AR(x, 0))) Then Max = CInt(Val(AR(x, 0)))
        Next
        For x As Integer = 1 To Max
            For y As Integer = 0 To AR.GetUpperBound(0)

                If Val(AR(y, 0)) = x Then
                    sb.Append(AR2(y).Replace(Chr(10), "") & vbNewLine)
                    Exit For
                End If
            Next
        Next
        My.Computer.FileSystem.WriteAllText(FiName, sb.ToString, False)
    End Sub


    Sub ShowFile(ByVal FileName As String)

        Dim show As New ContaNet.Tools.NSShow(Page)

        Dim fName As String = My.Computer.FileSystem.GetName(FileName)

        If FileName.ToUpper.EndsWith(".JPG") Then
            show.Image(fName & " " & FileSystem.FileDateTime(FileName).ToString, FileName, 10, 10, 300)
        ElseIf FileName.ToUpper.EndsWith(".PDF") Then
            show.PDF(fName & " " & FileSystem.FileDateTime(FileName).ToString, FileName, , , , , , 800)
        ElseIf FileName.ToUpper.EndsWith(".MP3") Then
            show.Audio(fName & " " & FileSystem.FileDateTime(FileName).ToString, FileName)
        ElseIf FileName.ToUpper.EndsWith(".MP4") Then
            show.Video(fName & " " & FileSystem.FileDateTime(FileName).ToString, FileName)
        Else
            show.DownloadFile(FileName)
        End If

    End Sub


    Function GetTotal(ByVal Grid As ContaNet.Tools.NSCore.NSGrid) As Double
        Dim Total As Double = 0
        For x As Integer = 0 To Grid.Rows
            If Grid.cellValue(x, 5) > "" Then Total += Val(Grid.cellValue(x, 5))
        Next
        Return Total
    End Function


    Function DropDownMenu() As NSDropDownMenu
        Dim m As New NSDropDownMenu
        If Not IsLoading(Page) Then Return m
        If Mobile Then Return m

        If Cookie(Page, "LOGIN") = "FALSE" Then Return Nothing
        Dim menuColor As String = ""
        Dim menuFont As String = ""
        Dim menuFontSize As Integer = 30
        Dim config() As String = GetStyle()
        menuColor = config(3)
        menuFont = config(10)
        If Val(config(11)) > 0 Then
            menuFontSize = CInt(Val(config(11)))
            If menuFontSize > 40 Then menuFontSize = 20
        End If

        If config(14) = "2" Then
            m.Top = 200
            m.Left = 200
            m.Width = 1000
            '   m.OnTop = False
        Else
            m.Top = 0
            m.Left = 0
        End If
        'm.Width = 1000
        m.FontSize1 = CInt(menuFontSize)
        m.FontSize2 = CInt(menuFontSize * 0.8)
        m.MenuColor = menuColor

        m.MenuGradientColor = config(16)
        m.FontColor1 = config(17)
        m.FontColor2 = config(18)
        m.FontColor3 = config(19)


        m.FontFamily = menuFont
        ' Data Entry
        Dim Mobile1 As String = ""
        Mobile = False ' this can be used to create a different menu for a phone, etc. (remove this line to see how it works)
        If Mobile Then Mobile1 = "MOBILE"
        If Mobile Then m.AddNode("MENU", Mobile1)
        m.AddNode("Data Entry", "TOP1", Mobile1)
        m.AddNode("Sample data entry", , "TOP1", "DATAENTRY1")
        m.AddNode("Same as before (Modal)", , "TOP1", "DATAENTRY2")
        m.AddNode("This shows a grid", , "TOP1", "11")
        m.AddNode("Choose a country", "COUNTRY", "TOP1")
        m.AddNode("English", , "COUNTRY", "1005")
        m.AddNode("Spanish", , "COUNTRY", "1006")


        '    m.AddNode("Another grid", , "TOP1", "12")
        m.AddNode("ServerSide Validation", "SERVERSIDE", "TOP1")
        m.AddNode("Addition", , "SERVERSIDE", "ADDITION")
        m.AddNode("Do some math", , "SERVERSIDE", "MATH")
        m.AddNode("Dynamic selection", , "SERVERSIDE", "DYSELECT")
        m.AddNode("Option/Multiselect", , "SERVERSIDE", "OPTION")
        m.AddNode("Countries/States", "STATES", "SERVERSIDE")
        m.AddNode("DataList", , "STATES", "OPTM2A")
        m.AddNode("Select", , "STATES", "OPTM2B")
        m.AddNode("Multiple file upload", , "TOP1", "MULTICOPY")
        m.AddNode("Dates", , "SERVERSIDE", "DATESS")
        ' m.AddNode("Test", , "TOP1", "TEST")

        ' styles

        m.AddNode("Styles", "Styles")
        Dim s() As String = GetFiles(Server.MapPath(".") & "\data\styles",, True).Split(CChar(","))
        For x As Integer = 0 To s.GetUpperBound(0)
            m.AddNode(s(x),, "Styles", "Style" & s(x).Replace(" ", "_"))
        Next
        ' varios

        m.AddNode("Various", "VARIOUS", Mobile1)

        'Videos
        m.AddNode("Videos", "VIDEOS", "VARIOUS")
        m.AddNode("Animated Movie", , "VIDEOS", "200")

        If My.Computer.FileSystem.DirectoryExists(Server.MapPath(".") & "\info\video") Then
            My.Computer.FileSystem.GetFiles(Server.MapPath(".") & "\info\video")
            Dim Files() As String = GetFiles(Server.MapPath(".") & "\info\video", "*.mp4").Split(CChar(","))
            For x As Integer = 0 To Files.GetUpperBound(0) - 1
                m.AddNode(Files(x).Substring(0, Files(x).Length - 4), , "VIDEOS", "203" & CStr(x))
            Next
        End If
        'Audio

        m.AddNode("Audio", "AUDIO", "VARIOUS")
        m.AddNode("VARIOUS", , "AUDIO", "211")
        ' Images
        m.AddNode("Images", "Images", "VARIOUS")
        m.AddNode("Boavista", , "Images", "220")
        m.AddNode("Maui", , "Images", "221")


        m.AddNode("Menu example", "MoreM", "VARIOUS")
        m.AddNode("SUB 1", "sub2", "MoreM")
        m.AddNode("Sub sub 2 (contanet)", , "sub2", , , "http://www.contanet.es")
        m.AddNode("Sub sub 1", "SUB3", "sub2", "DATAENTRY1")
        m.AddNode("Sub sub 3", , "SUB3", "DATAENTRY1")


        ' Other

        m.AddNode("Images", "SHOWIMAGE", "VARIOUS")
        m.AddNode("Slideshow", , "VARIOUS", "SLIDESHOW")
        m.AddNode("Slider", , "VARIOUS", "SLIDER")
        m.AddNode("Small preview", , "SHOWIMAGE", "302")
        m.AddNode("Large preview", , "SHOWIMAGE", "302LARGE")
        m.AddNode("No preview", , "SHOWIMAGE", "302X")

        m.AddNode("Search", , "VARIOUS", "LOCATE")
        m.AddNode("File Upload", , "VARIOUS", "304")
        m.AddNode("Styles", "STYLES", "VARIOUS")
        m.AddNode("Change style", "", "STYLES", "STYLE1")

        m.AddNode("Save current style", "", "STYLES", "STYLE2")
        m.AddNode("Load a style", "", "STYLES", "STYLE3")

        m.AddNode("Open a web page (contanet.es)", , "VARIOUS", , , "http://www.contanet.es")
        m.AddNode("Open a web page (contanet.es) in a window", , "VARIOUS", "WPW")
        m.AddNode("javascript function called Test", , "VARIOUS", , "Test('ok')")
        m.AddNode("Reload Web Page", , "VARIOUS", "RELOAD")
        m.AddNode("Progress", , "VARIOUS", "PROGRESS")
        m.AddNode("Treeview test", "TREEVIEWTEST", "VARIOUS")
        m.AddNode("Treeview with standar icon", , "TREEVIEWTEST", "TREEVIEWTEST1")
        m.AddNode("Treeview with personalized icon", , "TREEVIEWTEST", "TREEVIEWTEST2")
        m.AddNode("Set Cookie", , "VARIOUS", "TESTCOOKIE")
        m.AddNode("Get Cookie", , "VARIOUS", "TESTCOOKIE2")



        ' Sample billing program
        m.AddNode("Billing", "BILLING", Mobile1)
        m.AddNode("Clients", "CLIENTS", "BILLING")
        m.AddNode("Clients (HTML)", , "CLIENTS", "HTMIMAGE")
        m.AddNode("Clients (GRID)", , "CLIENTS", "SHOWCLIENTGRID")
        m.AddNode("Add new client", , "CLIENTS", "CREATECLIENT")
        m.AddNode("ARTICLES", "ARTIC", "BILLING")
        m.AddNode("Articles (HTML)", , "ARTIC", "B3")
        m.AddNode("Articles (GRID)", , "ARTIC", "B4")
        m.AddNode("Add new article", , "ARTIC", "B5")
        m.AddNode("Delete articles", , "ARTIC", "B6")

        m.AddNode("Sample Invoice", , "BILLING", "INVOICE")
        ' m.AddNode("Sample option selector", , "BILLING", "114")
        m.AddNode("Select articles", , "BILLING", "SELARTIC")

        ' HTML

        m.AddNode("HTML", "HTML", Mobile1)
        m.AddNode("Show HTML", "HTML2", "HTML")
        m.AddNode("Rows with class", , "HTML2", "32B")
        m.AddNode("Columns with class", , "HTML2", "32C")


        m.AddNode("Show HTML (full screen)", , "HTML", "32A")
        m.AddNode("Show HTML (with link)", , "HTML", "33")
        m.AddNode("Show HTML (With invisible column)", , "HTML", "34")
        m.AddNode("Show HTML (With editable column)", , "HTML", "35")
        m.AddNode("Show HTML (With checkbox)", , "HTML", "36")
        m.AddNode("Show HTML (With toolbar)", "HTMTB", "HTML")
        m.AddNode("Show HTML (With image)", "", "HTML", "HTMIMAGE")
        m.AddNode("Left", , "HTMTB", "370")
        m.AddNode("Top", , "HTMTB", "371")
        m.AddNode("Right", , "HTMTB", "372")
        m.AddNode("Bottom", , "HTMTB", "373")

        ' DEMO

        m.AddNode("Demo", "DEMO", Mobile1)
        m.AddNode("VB.Net demo", , "DEMO", "VBDEMO")
        m.AddNode("C# demo", , "DEMO", "CSDEMO")
        m.AddNode("MVC demo", , "DEMO",,, "http://contanettools.cloudapp.net/mvcdemo/demo/mvcdemo.zip")
        m.AddNode("Most recent version of DLL", , "DEMO", "DLL")
        m.AddNode("Visit MVC demo page", , "DEMO",,, "http://contanettools.cloudapp.net/mvcdemo/webform1.aspx")
        m.AddNode("ContaNetTools.com", , , , , "http://www.contanettools.com")
        ' LOGOFF

        m.AddNode("Log off", , Mobile1, "1999")
        If m.MenuColor = "Transparent" And m.MenuGradientColor = "Transparent" Then m.TopMenuSeparator = False
        m.FontSize1 = 25
        m.FontSize2 = 20
        m.DropDownBorderStyle = NSDropDownMenu.DDBorderStyle.None
        '  m.Top = 800
        Return m

    End Function

    Function PageSetup() As NSStyles
        If Not IsLoading(Page) Then Return Nothing

        Dim nstyle As New ContaNet.Tools.NSStyles

        Dim config() As String = GetStyle()
        Dim regional As String = config(22) & ""
        If Not regional.Contains(";") Then
            regional = ""
        Else
            regional = regional.Substring(0, regional.IndexOf(";"))
        End If

        nstyle.RegionalSettings = New RegionalSettings(Page, regional, "en-US")

        Dim FontSize As Integer = 20
        Try
            Dim util As New NSUtil(Page)
            FontSize = CInt(Val(config(11)))
            If FontSize > 40 Then FontSize = 20
            If config(0).Trim.Length > 0 Then
                nstyle.BackGroundImage = "images/background/" & config(0)
            End If
            If config(1).Trim.Length > 0 Then
                nstyle.CenterBackGroundImage = CBool(config(1))
                nstyle.MenuBackGroundImage = "images/background/" & config(2)
            End If
            nstyle.DefaultMenuColor = config(3)
            nstyle.DefaultMenuGradientColor = config(16)
            nstyle.DefaultMenuBorderWidth = CInt(config(4))
            nstyle.DefaultMenuBorderStyle = CType(config(5), NSBorderStyle)
            nstyle.DefaultMenuFontColor = config(6)
            nstyle.NoScrollBars = CBool(config(7))
            nstyle.DefaultMenuBackgroundColor = config(8)
            nstyle.MenuBorderRadius = CInt(Val(config(9)))
            nstyle.DefaultMenuFontFamily = Trim(config(10))
            nstyle.DefaultMenuFontSize = FontSize
            nstyle.MenuBorderColor = config(12)
            nstyle.BackGroundColor = config(13)
            nstyle.Shadow = CBool(config(20))

            nstyle.NSHTMLBackGroundColor = "lightskyblue"

            If Not Mobile Then
                If config(21) = "1" And Not util.Cookie("LOGIN") = "FALSE" Then
                    Dim sspath As String = Page.Server.MapPath(".") & "\images\slideshow\english"
                    If My.Computer.FileSystem.DirectoryExists(sspath) Then
                        nstyle.AddSlideShow(sspath, "png", "TEST", "CENTER", "5%", "", "",, "30%", 3000, SlideShowStyles.inout, , , "box")
                    Else
                        nstyle.AddSlideShow(Page.Server.MapPath(".") & "\info\images\Cabo Verde", "jpg", "TEST", "25%", "", "", "20%", , , 2000, "fade", , , "box")
                    End If
                    nstyle.AddImage("images/tools-2017.png", "Test", , , "1%", "1%", , "100px", "160px")
                    nstyle.AddImage("images/partner.png", "Partner", "INFO", , , "1%", "1%", "5%", "10%")
                    '    nstyle.AddText("&nbsp;ContaNet Tools&nbsp;", "INFO", , "35px", "bold", "steelblue", "25%", "33%", , , , , , "CNTXT", "box")
                    nstyle.AddVideo("http://contanettools.cloudapp.net/demo/info/video/contanet tools.mp4", "images/tools-2017.png", True, True, True, True, "Video show", , "center", , , "5%", "30%", "30%", , , "box")
                    ' nstyle.AddTimer(1000, "Timer")
                End If
                nstyle.AddText("This demo illustrates many of the things you can do with ContaNet.Tools", , , "35px", , , "40%", "10%", , , , "80%", ,, "toolsmsg")
                ' nstyle.AddText("Test", , , "35px", "bold", "steelblue", "25%", "25%", , , "50px", "500px", , "TIMERTEST")
                nstyle.AddText("Centered Text", "Contact",, "20px", "bold", "Green", "50%", "50%",,, , ,, "Textx", "center")
            End If

            '  nstyle.AddWebPage("http://localhost:54860/Home/Index", "20%", "0%", , , "80%", "100%",, "MVCPAGE")


            ' nstyle.AddTimer(100, "LOGIN", 1)
            ' nstyle.RegionalSettings = New RegionalSettings(Page, "de-CH", "en-US")
            ' nstyle.CreateSiteMap(Page, New List(Of String)(New String() {"Data", "Bin"}))
            ' nstyle.CreateDirectoryTree(Page, "Contanet tools for Asp.net developers", "Directory tree", , , , , ShowDirectoryTree.Yes)

            'Dim lFile As String = Server.MapPath(".") & "\test\test.txt"
            'If My.Computer.FileSystem.FileExists(lFile) Then
            '    Dim B() As String = My.Computer.FileSystem.ReadAllText(lFile).Split(CChar(vbTab))
            '    For x As Integer = 0 To B.GetUpperBound(0)
            '        nstyle.AddTimer(10, "LOADLABEL" & x, 1)
            '    Next
            'End If


            nstyle.AddToolbar(ToolBar())
            'Dim tb2 As New NSToolBar
            'tb2 = ToolBar2(10)
            'tb2.Top = "50%"
            'tb2.Left = "50%"
            'nstyle.AddToolbar(tb2)
            ' nstyle.AddDropDownMenu(Menu2)
            nstyle.AddDropDownMenu(DropDownMenu)
            ' nstyle.AddVideo("images/video.mov",, True, True, False, True, "Test", "TEST4", "300px", "50px",,, "50px", "50px", "10000",, "box")
            ' nstyle.AddNSHTML(HTMImg2)
        Catch ex As Exception
            Return nstyle
        End Try

        '  nstyle.AddSlider(Page.Server.MapPath(".") & "\info\images\Imperial beach", "jpg", "500px", "100px",,, "400px", "600px", 2000, , , "box")

        Return nstyle
    End Function


    Function ToolBar() As NSToolBar
        Dim tb As New NSToolBar

        ' This show all default icons with their names
        'tb.ShowAllDefaultIcons()
        ' Return tb

        Dim util As New NSUtil(Page)

        Dim ruta As String = ""
        Dim config() As String = GetStyle()
        If config(14) > "1" Then
            ruta = "images/bt" & config(14) & "/"
        End If
        If config(15) = "" Then config(15) = "10"
        With tb
            If config(14) = "2" Then
                .Top = "60%"
                .Left = "3%"
            ElseIf Mobile Then
                .Top = "10px"
                .Left = "10px"
            Else
                .Top = "50px"
                .Left = "20px"
            End If
            .Caption = ""

            Dim cols As Integer = CInt(config(15))
            .Cols = cols
            If config(14) = "2" Then .Cols = 20
            If cols < 3 Then .AutoResize = False

            If util.Cookie("LOGIN") = "FALSE" Then
                .Top = "3%"
                .Left = "3%"
                .AddItem("LOGIN", "intro", "LOGIN")
            Else
                ' .AddItem("", ruta & "update.png", "nSTYLE")
                .AddItem("Page design", DefaultIcons.Delete, "nSTYLE",)
                .AddItem("Images", DefaultIcons.Photo, "302")
                .AddItem("ContaNet.Tools video", DefaultIcons.Video, "CNVideo")
                .AddItem("Consult excel files", DefaultIcons.Excel, "SHOWEXCELFILES")
                .AddItem("New", DefaultIcons.New_, "MULTIPDF")
                .AddItem("Show a grid", DefaultIcons.Grid, "SHOWCLIENTGRID")
                .AddItem("New Client", DefaultIcons.UserNew, "CREATECLIENT2", , , , "Funct2")
                .AddItem("Client list", DefaultIcons.Userdata, "HTMIMAGE")
                If Not Mobile Then .AddItem("Invoice", DefaultIcons.Invoice, "INVOICE")
                .AddItem("Data", DefaultIcons.GridAdd, "DATAENTRY1")

                .AddItem("Help?", DefaultIcons.Help, "ShowHelp")
                .AddItem("Info", DefaultIcons.About, "INFO")
                .AddItem("Search", DefaultIcons.Search, "LOCATE")
                If Not Mobile Then
                    If config(14) <= "1" Then .AddItem("Remove toolbar", DefaultIcons.Cut, "CUTTOOLBAR")
                End If
                .AddItem("Add label", DefaultIcons.NewDocument, "ADDLABEL")
                .AddItem("Save labels", DefaultIcons.Save, "SAVELABELS")
                .AddItem("Full Screen", DefaultIcons.Visualize,, "NS.toggleFullScreen()")
                .AddItem("Exit", DefaultIcons.Off, "1999")
                .AddItem("Annimated button", "images/button gif.gif", "CHANGE1",,,,, 60, 60)
                .Id = "mainTB"
            End If
        End With
        Return tb
    End Function

    Function ToolBar2(ByVal Cols As Integer) As NSToolBar
        Dim ruta As String = ""
        Dim config() As String = GetStyle()
        If config(14) = "2" Then ruta = "images/bt2/"

        Dim tb As New NSToolBar
        With tb
            .Cols = Cols
            .Id = "mainTB"
            .HiddenData = "Hidden data from toolbar"
            .AddItem("Camera", ruta & "camera", "52")
            .AddItem("Cart", ruta & "cart", "54")
            .AddItem("Consult excel files", ruta & "excel", "SHOWEXCELFILES")
            .AddItem("Tools", ruta & "tools", "CHANGE2")
            .AddItem("What?", ruta & "question", "58")
            .AddItem("New", ruta & "new", "53")
            .AddItem("Exit", ruta & "cancel", "999")
            Return tb
        End With
    End Function

    Function Menu2() As NSDropDownMenu
        Dim m As New NSDropDownMenu
        With m
            .AddNode("Test",, , "Test1")
            .AddNode("Test2",,, "Test2")
            .AddNode("Test3",,, "Test3")
            .AddNode("Test4",,, "Test4")
            .Top = 500
            .Left = 500
            .MenuColor = "blue"
            .MenuGradientColor = "blue"
            .TopMenuSeparator = False
            '  .Width = 100
        End With
        Return m
    End Function

    Function GetBackground() As String
        Dim sb As New System.Text.StringBuilder
        Dim Files As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(Server.MapPath(".") & "\images\background")
        Dim FileName As String = ""
        For Each FileName In Files
            sb.Append("," & My.Computer.FileSystem.GetName(FileName))
        Next
        Return sb.ToString
    End Function

    Function GetFiles(ByVal Folder As String, Optional ByVal Extension As String = "*.*", Optional ByVal NoExtension As Boolean = False) As String
        Dim sb As New System.Text.StringBuilder
        Dim pa(0) As String
        pa(0) = Extension
        Dim Files As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(Folder, FileIO.SearchOption.SearchTopLevelOnly, pa)
        Dim FileName As String = ""
        For Each FileName In Files
            If NoExtension Then
                Dim Name As String = My.Computer.FileSystem.GetName(FileName)
                Name = Name.Substring(0, Name.Length - 4)
                sb.Append(Name & ",")
            Else
                sb.Append(My.Computer.FileSystem.GetName(FileName) & ",")

            End If
        Next
        Return sb.ToString

    End Function
    Function GetMobile() As Boolean
        Dim strUserAgent As String = Request.UserAgent.ToString().ToLower()
        If strUserAgent.Contains("ipad") Then Return False
        If strUserAgent > "" Then
            If (Request.Browser.IsMobileDevice = True Or strUserAgent.Contains("iphone") Or
                  strUserAgent.Contains("blackberry") Or strUserAgent.Contains("mobile") Or
                  strUserAgent.Contains("windows ce") Or strUserAgent.Contains("opera mini") Or
                  strUserAgent.Contains("palm")) Then Return True
        End If

        Return False
    End Function

    Function GetStyle(Optional ByVal nStyle As String = "") As String()
        Dim config() As String
        Dim Util As New ContaNet.Tools.NSUtil(Page)
        Dim Style As String = Util.Cookie("STYLE")
        If nStyle <> "" Then Style = nStyle
        If Style = "" Then
            Style = Server.MapPath(".") & "\data\ContaNetTools.txt"
        ElseIf Style.ToUpper = "STYLE.TXT" Then
            Style = Server.MapPath(".") & "\data\STYLE.txt"
        Else
            Style = Server.MapPath(".") & "\data\styles\" & Style
        End If

        If My.Computer.FileSystem.FileExists(Style) Then
            config = My.Computer.FileSystem.ReadAllText(Style).Split(CChar(","))
        Else
            Util.Cookie("STYLE") = ""
            Style = Server.MapPath(".") & "\data\ContaNetTools.txt"
            config = My.Computer.FileSystem.ReadAllText(Style).Split(CChar(","))
        End If
        ReDim Preserve config(22)
        If config(15) = "" Then config(15) = "10"
        If config(16) = "" Then config(16) = "black"
        If config(17) = "" Then config(17) = "white"
        If config(18) = "" Then config(18) = "white"
        If config(19) = "" Then config(19) = "black"
        If config(20) = "" Then config(20) = "1"
        Return config
    End Function

    Function GetArticle(ByVal ID As String) As String
        Dim util As New ContaNet.Tools.NSUtil(Page)
        Dim Txt(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\artic.txt"))
        For x As Integer = 0 To Txt.GetUpperBound(0)
            If Txt(x, 0) = ID Then Return Txt(x, 1)
        Next
        Return ""
    End Function

    Private Function GetNextClient() As Integer
        Dim util As New ContaNet.Tools.NSUtil(Page)
        Dim AR(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
        Dim ClientNumber As Integer = 0
        For x As Integer = 0 To UBound(AR, 1)
            If ClientNumber < CInt(Val(AR(x, 0))) Then ClientNumber = CInt(AR(x, 0))
        Next
        ClientNumber += 1
        Return ClientNumber
    End Function

    Sub ShowTreeview(ByVal value As String)

        Dim TV As New ContaNet.Tools.NSTreeView
        With TV
            .Caption = "test"
            .AddButton("test", DefaultIcons.About, , "TESTBUTTON", "TREEVIEWTEST2")
            .FontSize = 20
            .UseIcons = True
            .HiddenData = "this is hidden data"
            For X As Integer = 1 To 5
                .AddNode("Top" & X, "TOP" & X)
                For Y As Integer = 1 To 5
                    .AddNode("SUB" & X & Y, "SUB" & X & Y, "TOP" & X)
                    For Z As Integer = 1 To 5
                        .AddNode("NODE " & value & X & Y & Z, , "SUB" & X & Y, "FUNCT" & X & Y & Z)
                    Next
                Next
            Next
            .Show(Page)
        End With


    End Sub

    Sub LoadHTMImage(Optional ByVal Search As String = "")
        Dim htm As New ContaNet.Tools.NSHTML
        htm = HTMImg(Search)
        htm.Show(Page)
    End Sub

    Function HTMImg2() As NSHTML
        Dim htm As NSHTML
        htm = HTMImg()
        htm.Top = "300px"
        htm.Left = "200px"
        htm.Height = "600px"
        htm.Width = "1500px"
        Return htm
    End Function

    Function HTMImg(Optional ByVal Search As String = "") As NSHTML
        Dim htm As New ContaNet.Tools.NSHTML With {
            .HelpFile = "info.html",
            .Modal = True,
            .Caption = "Clients",
            .HiddenData = "Data from HTML",
            .NewPageIcon = True,
            .BackgroundColor = "white",
            .TextColor = "black",
            .Header = Now.ToLongDateString,
            .Height = "300px"
        }
        htm.AddCancelFunction("CANCELHTM", "MYVALUE")
        htm.AddTextBox("Search first name", "", NSVars.Text, 30, , , , "SEARCHCLIENT")
        htm.AddButton("New Client", DefaultIcons.UserNew,, "CREATECLIENT2", "HTMIMAGE")
        '  htm.Funct = "TEST"
        Dim CurrentPath As String = Server.MapPath(".") & "\images\clients\"
        Dim util As New ContaNet.Tools.NSUtil(Page)
        Dim sb As New System.Text.StringBuilder
        Dim Txt(,) As String = util.Tab2Array(My.Computer.FileSystem.ReadAllText(Server.MapPath(".") & "\data\mytest.txt"))
        Dim ImageName As String = ""
        Search = Search.ToUpper
        For x As Integer = 0 To Txt.GetUpperBound(0)
            If Txt(x, 1).ToUpper.Contains(Search) Then
                If sb.Length > 0 Then sb.Append(vbNewLine)
                For y As Integer = 0 To Txt.GetUpperBound(1)
                    Select Case y
                        Case 0
                            If My.Computer.FileSystem.FileExists(CurrentPath & "PHOTO" & Txt(x, y) & ".JPG") Then
                                Dim rnd As Random = New Random
                                ImageName = "images/clients/photo" & Txt(x, y) & ".jpg" & "?" & CStr(rnd.Next(1000000))
                            Else
                                ImageName = "images/clients/photo.jpg"
                            End If
                            sb.Append(Txt(x, y) & vbTab & ImageName)
                        Case Else
                            sb.Append(vbTab & Txt(x, y))
                    End Select
                Next
                For z As Integer = Txt.GetUpperBound(1) To 8
                    sb.Append(vbTab)
                Next
                sb.Append("images/delete.png")
            End If
        Next

        htm.Text = sb.ToString
        htm.AddCol("ID", NSHTML.Types.Invisible)
        htm.AddImageCol("Photo", 50, 50, , 1, "333", "HTMIMAGE")
        htm.AddCol("First Name", NSHTML.Types.Text,,,, "SearchForName")
        htm.AddCol("Last Name", NSHTML.Types.Text)
        htm.AddCol("Phone", NSHTML.Types.Text)
        htm.AddCol("Title", NSHTML.Types.Text)
        htm.AddCol("Company", NSHTML.Types.Text)
        htm.AddCol("Sales", NSHTML.Types.Number)
        htm.AddCol("Ch", NSHTML.Types.Checkbox)
        htm.AddCol("Date", Types.Date_)
        htm.AddImageCol("X", 30, 30,, 1, "DELETECLIENT", "HTMIMAGE")
        htm.Reload = True
        htm.LockHeaders = True
        htm.AddButton("How to? (VB)", "images/vb.png", , "Code_to_show_HTML_client_data")
        htm.AddButton("How to? (C#)", "images/cs.png", , "Code_to_show_HTML_client_data")
        Return htm
    End Function
    Private Function GetLocalization() As String
        If Not My.Computer.FileSystem.FileExists(Page.Server.MapPath(".") & "\data\localization.csv") Then Return "Default"
        Dim txt As String = My.Computer.FileSystem.ReadAllText(Page.Server.MapPath(".") & "\data\localization.csv")
        Return "Default," & txt.Replace(vbNewLine, CChar(","))
    End Function

    Private Class ProgressCtrl
        Public Sub Progress(ByVal Page As Page, ByVal RV As ContaNet.Tools.NSCore)
            Dim updateTask As Task(Of Boolean) = ProgressTest(Page, RV)
        End Sub

        Private Function ProgressTest(ByVal Page As Page, ByVal RV As ContaNet.Tools.NSCore) As Task(Of Boolean)
            RV.StartProgress(Page)
            Return Task.Factory.StartNew(Of Boolean)(
                Function()
                    Dim pass() As String = "Pass 1,Pass 2, Pass 3, Pass 4".Split(CChar(","))
                    For y As Integer = 0 To 3
                        For X As Integer = 1 To 100
                            Threading.Thread.Sleep(100)
                            RV.Progress(X, 100, pass(y) & " - " & CStr(X) & "%")
                        Next
                    Next
                    RV.EndProgress()
                    Return True
                End Function)

        End Function
    End Class


End Class