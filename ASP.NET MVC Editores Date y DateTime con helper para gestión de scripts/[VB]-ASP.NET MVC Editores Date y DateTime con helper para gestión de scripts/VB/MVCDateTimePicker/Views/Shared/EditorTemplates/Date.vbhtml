@ModelType DateTime

@Html.AddScriptFile("datetimepicker_plugin", "~/Scripts/jquery.datetimepicker.js")
@Html.AddScript("init_Date_Editor" _
                     , "$(function () {" & vbCrLf &
                     "$('.datepicker').datetimepicker({" & vbCrLf &
                     "lang: 'es'," & vbCrLf &
                     "format: 'd/m/Y'," & vbCrLf &
                     "formatDate: 'd/m/Y'," & vbCrLf &
                     "dayOfWeekStart: 1," & vbCrLf &
                     "mask: true," & vbCrLf &
                     "timepicker: false" & vbCrLf &
                     "});" & vbCrLf &
                     "});" & vbCrLf)

@Html.TextBox("", IIf(Model = DateTime.MinValue, Nothing, Model.ToString("dd/MM/yyyy")) _
                   , New With {.class = "datepicker"})


