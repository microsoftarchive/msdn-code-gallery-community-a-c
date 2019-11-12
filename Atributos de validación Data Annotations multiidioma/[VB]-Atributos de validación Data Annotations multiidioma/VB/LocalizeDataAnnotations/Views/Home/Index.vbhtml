@ModelType LocalizeDataAnnotations.IPersona
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div> 
        @Using (Html.BeginForm())
            @Html.EditorForModel()
            @:<br />
            @:<input type="submit" value="Validar" />
        End Using
    </div>
</body>
</html>
