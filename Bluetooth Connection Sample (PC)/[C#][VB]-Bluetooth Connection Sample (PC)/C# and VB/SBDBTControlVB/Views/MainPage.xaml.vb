Namespace Views
    Public NotInheritable Class MainPage
        Inherits Page

        Public Sub New()
            ' この呼び出しはデザイナーで必要です。
            InitializeComponent()
            ' InitializeComponent() 呼び出しの後で初期化を追加します。
            Me.DataContext = App.MainVM
        End Sub
    End Class
End Namespace
