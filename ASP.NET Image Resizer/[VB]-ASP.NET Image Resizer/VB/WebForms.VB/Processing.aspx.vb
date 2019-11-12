Imports System.Drawing
Imports System.Linq.Expressions
Imports GleamTech.ImageUltimate
Imports GleamTech.ImageUltimate.AspNet
Imports GleamTech.Util

Public Class ProcessingPage
    Inherits System.Web.UI.Page

    Protected ImagePath As String
    Protected TaskAction As Action(Of ImageWebTask)
    Protected CodeString As String

    Private Shared ReadOnly TaskExpressions As Expression(Of Action(Of ImageWebTask))() = {
        Function(task) task.ResizeWidth(300, ResizeMode.Max), 
        Function(task) task.ResizeHeight(200, ResizeMode.Max), 
        Function(task) task.Resize(300, 300, ResizeMode.Max), 
        Function(task) task.ResizeWidth(50, ResizeMode.Percentage), 
        Function(task) task.Resize(50, 60, ResizeMode.Percentage), 
        Function(task) task.Resize(300, 300, ResizeMode.Stretch),
        Function(task) task.LiquidResize(75, 100, ResizeMode.Percentage), 
        Function(task) task.Crop(0, 0, 150, 150), 
        Function(task) task.TrimBorders(Color.Black, 10),
        Function(task) task.Rotate(45, Color.Transparent), 
        Function(task) task.Rotate(-45, Color.Transparent), 
        Function(task) task.FlipHorizontal(),
        Function(task) task.FlipVertical(), 
        Function(task) task.Brightness(20), 
        Function(task) task.Brightness(-20), 
        Function(task) task.Contrast(20), 
        Function(task) task.Contrast(-20),
        Function(task) task.BrightnessContrast(20, 20),
        Function(task) task.Enhance(), 
        Function(task) task.Blur(1),
        Function(task) task.Sharpen(1),
        Function(task) task.Format(ImageWebSafeFormat.Png), 
        Function(task) task.FileName("CustomNameForSEO")
    }

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ImagePath = exampleFileSelector.SelectedFile

        If Not IsPostBack Then
            PopulateTaskSelector()
        End If

        Dim expression = TaskExpressions(Integer.Parse(TaskSelector.SelectedValue))
        Dim lambda = expression.Compile()

        TaskAction = Sub(task) 
            task.ResizeWidth(400)
            lambda(task)
        End Sub

        CodeString = String.Format(
            "<%=Me.ImageTag(""{0}"", {1})%>", 
            exampleFileSelector.SelectedFile.FileName, 
            ExpressionStringBuilder.ToString(expression))
    End Sub

    Private Sub PopulateTaskSelector()
        Dim i = 0
        While i < TaskExpressions.Length
            TaskSelector.Items.Add(
                New ListItem(
                    ExpressionStringBuilder.ToString(TaskExpressions(i)), 
                    i.ToString()
                )
            )
            i += 1
        End While
    End Sub

End Class