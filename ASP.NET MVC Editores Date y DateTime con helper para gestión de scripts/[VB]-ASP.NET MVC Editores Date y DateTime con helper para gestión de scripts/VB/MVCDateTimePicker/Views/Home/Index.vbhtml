@ModelType MVCDateTimePicker.Persona

@Using (Html.BeginForm())
    @Html.EditorForModel()
    @:<br />
    @:<input type="submit" value="Validar" />
End Using