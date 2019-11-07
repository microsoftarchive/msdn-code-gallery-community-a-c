Imports WebApplication

Partial Class PhotoOperations
  Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub


  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
  End Sub

  Private Property OperationName() As String
    Get
      Return _OperationName.Text
    End Get
    Set(ByVal Value As String)
      _OperationName.Text = Value
    End Set
  End Property

  Sub Operation(ByVal TypeObject As PhotoManager.TypeObject, ByVal Operation As PhotoManager.Operations, ByVal Language As LanguageManager.Language)
    OperationName = PhotoManager.DescriptionOperation(Operation, TypeObject, Language)
    Select Case Operation
      Case PhotoManager.Operations.Edit, PhotoManager.Operations.CreateSubFotoAlbum
        _Alert.Visible = False
        _Reset1.Visible = True
        _Table1.Visible = True
      Case Else
        _Alert.Visible = True
        _Reset1.Visible = False
        _Table1.Visible = False
    End Select
  End Sub

  Public Property PhraseTitle() As String
    Get
      Return Label1.Text
    End Get
    Set(ByVal Value As String)
      Label1.Text = Value
    End Set
  End Property

  Public Property PhraseDescription() As String
    Get
      Return Label2.Text
    End Get
    Set(ByVal Value As String)
      Label2.Text = Value
    End Set
  End Property

  Public Property Alert() As String
    Get
      Return _Alert.Text
    End Get
    Set(ByVal Value As String)
      _Alert.Text = Value
    End Set
  End Property

  Public Property TitleValue() As String
    Get
      Return title.Value
    End Get
    Set(ByVal Value As String)
      title.Value = Value
    End Set
  End Property
  Public Property DescriptionValue() As String
    Get
      Return description.Value
    End Get
    Set(ByVal Value As String)
      description.Value = Value
    End Set
  End Property

  Public Function TitleName() As String
    Return title.Name
  End Function

  Public Function DescriptionName() As String
    Return description.Name
  End Function

  Protected Sub Page_PreRender(sender As Object, e As System.EventArgs) Handles Me.PreRender
    If CurrentSetting.Aspect.SuggestTheBestChoiceByTheBlink Then
      Dim MasterPage As MasterPage = Page.Master
      MasterPage.Blink(Submit1)
    End If
  End Sub
End Class


