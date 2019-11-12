Imports System.Web.Mvc
Imports System.Runtime.CompilerServices

Public Module ScriptHelper

    Private Const ScriptItemsKey As String = "ScriptBlocks"

    Private Enum ScriptType
        Code
        File
    End Enum

    Private Class ScriptBlock
        Property ScriptType As ScriptType
        Property Script As String
    End Class

    Private Function ScriptCollection(html As HtmlHelper) As Dictionary(Of String, ScriptBlock)
        Dim _httpContext As HttpContextBase = html.ViewContext.HttpContext
        If Not _httpContext.Items.Contains(ScriptItemsKey) Then
            _httpContext.Items(ScriptItemsKey) = New Dictionary(Of String, ScriptBlock)
        End If
        Return CType(_httpContext.Items(ScriptItemsKey), Dictionary(Of String, ScriptBlock))
    End Function

    <Extension> _
    Public Function AddScript(html As HtmlHelper, key As String, scriptCode As String) As MvcHtmlString
        Dim scripts As Dictionary(Of String, ScriptBlock) = ScriptCollection(html)
        If Not scripts.ContainsKey(key) Then
            scripts.Add(key _
                        , New ScriptBlock() With {.ScriptType = ScriptType.Code, .Script = scriptCode})
        End If
        Return MvcHtmlString.Empty
    End Function

    <Extension> _
    Public Function AddScriptFile(html As HtmlHelper, key As String, scriptFile As String) As MvcHtmlString
        Dim scripts As Dictionary(Of String, ScriptBlock) = ScriptCollection(html)
        If Not scripts.ContainsKey(key) Then
            scripts.Add(key _
                        , New ScriptBlock() With {.ScriptType = ScriptType.File, .Script = scriptFile})
        End If
        Return MvcHtmlString.Empty
    End Function

    <Extension> _
    Public Function RenderScripts(html As HtmlHelper) As MvcHtmlString
        Dim scripts As Dictionary(Of String, ScriptBlock) = ScriptCollection(html)
        Dim result As String = String.Empty
        For Each item As ScriptBlock In scripts.Values
            Dim scriptTag As TagBuilder = New TagBuilder("script")
            scriptTag.MergeAttribute("type", "text/javascript")
            If item.ScriptType = ScriptType.File Then
                scriptTag.MergeAttribute("src", UrlHelper.GenerateContentUrl(item.Script, html.ViewContext.HttpContext))
            Else
                scriptTag.InnerHtml = Environment.NewLine & item.Script & Environment.NewLine
            End If
            result = result & scriptTag.ToString(TagRenderMode.Normal) & Environment.NewLine
        Next
        html.ViewContext.HttpContext.Items.Remove(ScriptItemsKey)
        Return MvcHtmlString.Create(result)
    End Function

End Module
