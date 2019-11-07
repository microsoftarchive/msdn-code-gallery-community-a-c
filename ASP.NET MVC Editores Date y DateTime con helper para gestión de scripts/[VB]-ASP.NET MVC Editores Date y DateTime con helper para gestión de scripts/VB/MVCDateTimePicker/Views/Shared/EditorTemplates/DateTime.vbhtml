@ModelType DateTime

@Html.AddScriptFile("datetimepicker_plugin", "~/Scripts/jquery.datetimepicker.js")
@Html.AddScript("init_DateTime_Editor" _
                     , "$(function () {" & vbCrLf &
                     "$('.datetimepicker').datetimepicker({" & vbCrLf &
                     "lang: 'es'," & vbCrLf &
                     "format: 'd/m/Y H:i'," & vbCrLf &
                     "formatDate: 'd/m/Y'," & vbCrLf &
                     "dayOfWeekStart: 1," & vbCrLf &
                     "mask: true" & vbCrLf &
                     "});" & vbCrLf &
                     "});" & vbCrLf)

@Html.TextBox("", IIf(Model = DateTime.MinValue, Nothing, Model.ToString("dd/MM/yyyy hh:mm")) _
                   , New With {.class = "datetimepicker"})
