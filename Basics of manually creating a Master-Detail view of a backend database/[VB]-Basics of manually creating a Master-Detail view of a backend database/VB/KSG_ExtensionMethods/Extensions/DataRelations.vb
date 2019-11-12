Public Module DataRelations
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub SetRelation(
        ByVal sender As DataSet,
        ByVal MasterTableName As String,
        ByVal ChildTableName As String,
        ByVal KeyColumn As String)

        sender.Relations.Add(
           New DataRelation(String.Concat(MasterTableName, ChildTableName),
              sender.Tables(MasterTableName).Columns(KeyColumn),
              sender.Tables(ChildTableName).Columns(KeyColumn)
           )
        )
    End Sub
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub SetRelation(
        ByVal sender As DataSet,
        ByVal MasterTableName As String,
        ByVal ChildTableName As String,
        ByVal KeyColumn As String,
        ByVal Contraints As Boolean)

        sender.Relations.Add(
           New DataRelation(String.Concat(MasterTableName, ChildTableName),
              sender.Tables(MasterTableName).Columns(KeyColumn),
              sender.Tables(ChildTableName).Columns(KeyColumn),
              Contraints
           )
        )
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="MasterTableName"></param>
    ''' <param name="ChildTableName"></param>
    ''' <param name="KeyColumn">Identifying column between master and child table</param>
    ''' <param name="Name">Relationship name</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub SetRelation(
        ByVal sender As DataSet,
        ByVal MasterTableName As String,
        ByVal ChildTableName As String,
        ByVal KeyColumn As String,
        ByVal Name As String)

        sender.Relations.Add(
           New DataRelation(Name,
              sender.Tables(MasterTableName).Columns(KeyColumn),
              sender.Tables(ChildTableName).Columns(KeyColumn)
           )
        )
    End Sub
End Module
