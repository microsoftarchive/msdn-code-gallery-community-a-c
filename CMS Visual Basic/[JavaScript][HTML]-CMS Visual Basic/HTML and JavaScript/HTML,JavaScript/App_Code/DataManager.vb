'© By Andrea Bruno
'Open source, but: This source code (or part of this code) is not usable in other applications

Imports Microsoft.VisualBasic
Namespace WebApplication
	Public Module DataManager
		Public Function Table(ByVal FileDataBase As String, ByVal Name As String, Optional ByVal Where As String = Nothing, Optional ByVal OrderBy As String = Nothing, Optional ByVal OrderDesc As Boolean = False, Optional ByVal CommandBehavior As Data.CommandBehavior = Data.CommandBehavior.CloseConnection) As Data.OleDb.OleDbDataReader
			'connessione al database
			Dim strConn As String
			If InStr(FileDataBase, "=") Then
				strConn = FileDataBase
			Else
				strConn = "PROVIDER=" & DataProvider & ";" & KeyDataSource & "=" & FileDataBase & ""
			End If

			Dim objConn As New System.Data.OleDb.OleDbConnection(strConn)

      objConn.Open() 'Run only is the Trust Mode = Full
			If Not Where Is Nothing Then
				Where = " WHERE " & Where
			Else
				Where = ""
			End If
      Dim Order As String = Nothing
			If OrderBy <> "" Then
				Order = " ORDER BY " & OrderBy
				If OrderDesc Then
					Order &= " DESC"
				End If
			End If

			Dim Parameters As String = Where & Order
			Dim strSQL As String = "SELECT * FROM " & Name & Parameters	 '& " WHERE ID = " & Index
			Dim objCommand As New System.Data.OleDb.OleDbCommand(strSQL, objConn)
			Dim objDataReader As System.Data.OleDb.OleDbDataReader
			objDataReader = objCommand.ExecuteReader(CommandBehavior)
			'objDataReader = objCommand.ExecuteReader(CommandBehavior.SingleRow)
			'objDataReader.Read()
			'objConn.Close()
			'objDataReader.Close()
			SyncLock SyncLockConnections
				Connections.Add(objDataReader, objConn)
			End SyncLock
			Return objDataReader
		End Function

		Private SyncLockConnections As New Object

		Private Connections As New Collections.Generic.Dictionary(Of System.Data.OleDb.OleDbDataReader, System.Data.OleDb.OleDbConnection)

    Public Sub CloseConnection(ByVal DataReader As System.Data.OleDb.OleDbDataReader)
      SyncLock SyncLockConnections
        If Connections.ContainsKey(DataReader) Then
          Dim Connection As System.Data.OleDb.OleDbConnection = Connections(DataReader)
          Connections.Remove(DataReader)
          Connection.Close()
          Connection.Dispose()
          Connection = Nothing
          DataReader.Close()
          DataReader.Dispose()
          DataReader = Nothing
        End If
      End SyncLock
    End Sub

		Private DataCollections As New Collections.Generic.Dictionary(Of String, ObjData)

		Public Function AddRecord(ByVal FileDataBase As String, ByVal TableName As String, ByVal KeysValues As Collections.Specialized.HybridDictionary, Optional ByVal NameIndex As String = "ID", Optional ByVal ReplaceIndex As Integer = -1, Optional ByVal ReturnIndex As Boolean = True, Optional ByVal CloseConnection As Boolean = True) As Integer	'Return ID (Primary Key)
			'Use CloseConnection options for not close connecrion ("False" value) if is is necessary add more records in database
			'To close connection use CloseConnection function

			Dim objDataSet As New Data.DataSet
      Dim objDataAdapter As Data.OleDb.OleDbDataAdapter = Nothing
      Dim objConn As System.Data.OleDb.OleDbConnection = Nothing

			Dim KeyCollections As String = FileDataBase & "," & TableName
      Dim ObjData As ObjData = Nothing
			If DataCollections.ContainsKey(KeyCollections) Then
				ObjData = DataCollections(KeyCollections)
				objDataSet = ObjData.objDataSet
				objDataAdapter = ObjData.objDataAdapter
				objConn = ObjData.objConn
			End If

			If ObjData Is Nothing Then

				DataManager.NameIndex = NameIndex
				' query
				Dim strSQL As String
				strSQL = "SELECT * FROM " & TableName		'Select a table
				If ReplaceIndex >= 0 Then
					'replace
					strSQL &= " WHERE " & NameIndex & " = " & ReplaceIndex
				End If

				' string of connection
				Dim strConn As String
				If InStr(FileDataBase, "=") Then
					strConn = FileDataBase
				Else
					strConn = "PROVIDER=" & DataProvider & ";" & KeyDataSource & "=" & FileDataBase
				End If

				'Try
				objConn = New System.Data.OleDb.OleDbConnection(strConn)
				'apro l`oggetto objConn
				objConn.Open()
				' DataAdapter
				objDataAdapter = New Data.OleDb.OleDbDataAdapter(strSQL, objConn)
				' riempio il dataSet con i dati del dataAdapter
				objDataAdapter.Fill(objDataSet)
			End If

			Dim Table As System.Data.DataTable
			Table = objDataSet.Tables(0)
			Dim Row As System.Data.DataRow
			If ReplaceIndex >= 0 Then
				'Replace
				Row = Table.Rows(0)
			Else
				'add
				Row = Table.NewRow
			End If

			For Each Key As String In KeysValues.Keys
				Row(Key) = KeysValues(Key)
			Next

			If ReplaceIndex < 0 Then
				'add
				Table.Rows.Add(Row)
			End If

			Dim objCommandBuilder As New System.Data.OleDb.OleDbCommandBuilder(objDataAdapter)
			objDataAdapter.InsertCommand = objCommandBuilder.GetInsertCommand()
			If ReturnIndex Then
				If ReplaceIndex < 0 Then
					' Create another Command to get IDENTITY Value
					DataManager.cmdGetIdentity = New System.Data.OleDb.OleDbCommand
					DataManager.cmdGetIdentity.CommandText = "SELECT @@IDENTITY"
					DataManager.cmdGetIdentity.Connection = objConn
					AddHandler objDataAdapter.RowUpdated, AddressOf DataManager.HandleRowUpdated
				End If
			End If

			objDataAdapter.Update(objDataSet)

			'Dim ID As Integer

			If CloseConnection Then
				If DataManager.CloseConnection(FileDataBase, TableName) = False Then
					objConn.Close()
					objDataSet.Dispose()
					objDataAdapter.Dispose()
					objConn.Dispose()
				End If
			ElseIf Not DataCollections.ContainsKey(KeyCollections) Then
				ObjData = New ObjData
				ObjData.objDataSet = objDataSet
				ObjData.objDataAdapter = objDataAdapter
				ObjData.objConn = objConn
				DataCollections.Add(KeyCollections, ObjData)
			End If

			objCommandBuilder.Dispose()

			If ReturnIndex Then
				If ReplaceIndex >= 0 Then
					Return ReplaceIndex
				Else
					Return Row(NameIndex)
				End If
			End If
      Return 0
    End Function
		Public Function CloseConnection(ByVal FileDataBase As String, ByVal TableName As String) As Boolean
			Dim KeyCollections As String = FileDataBase & "," & TableName
			If DataCollections.ContainsKey(KeyCollections) Then
				Dim ObjData As ObjData = DataCollections(KeyCollections)
				CloseConnection(ObjData)
				DataCollections.Remove(KeyCollections)
				Return True
			Else
				Return False
			End If
		End Function
    Private Sub CloseConnection(ByVal ObjData As ObjData)
      Dim objDataSet As Data.DataSet = ObjData.objDataSet
      Dim objDataAdapter As Data.OleDb.OleDbDataAdapter = ObjData.objDataAdapter
      Dim objConn As System.Data.OleDb.OleDbConnection = ObjData.objConn
      objConn.Close()
      objDataSet.Dispose()
      objDataAdapter.Dispose()
      objConn.Dispose()
    End Sub
    Public Sub CloseAllConnections()
      For Each ObjData As ObjData In DataCollections.Values
        CloseConnection(ObjData)
      Next
    End Sub
		Private Class ObjData
			Public objDataSet As Data.DataSet
			Public objDataAdapter As Data.OleDb.OleDbDataAdapter
			Public objConn As System.Data.OleDb.OleDbConnection
		End Class
		Public Function AddRow(ByVal FileDataBase As String, ByVal TableName As String, ByVal Cells() As Cell, Optional ByVal NameIndex As String = "ID", Optional ByVal ReplaceIndex As Integer = -1, Optional ByVal ReturnIndex As Boolean = True) As Integer	'Return ID (Primary Key)
			Dim KeysValues As New Collections.Specialized.HybridDictionary
			Dim Element As Cell
			For Each Element In Cells
				If Element.Name <> "" Then
					KeysValues.Add(Element.Name, Element.Value)
				End If
			Next
			Return AddRecord(FileDataBase, TableName, KeysValues, NameIndex, ReplaceIndex, ReturnIndex)
		End Function

		Private NameIndex As String
		Private cmdGetIdentity As System.Data.OleDb.OleDbCommand
		Private Sub HandleRowUpdated(ByVal sender As Object, ByVal e As System.Data.OleDb.OleDbRowUpdatedEventArgs)
			If e.Status = Data.UpdateStatus.[Continue] AndAlso e.StatementType = Data.StatementType.Insert Then
				' Get the Identity column value
				e.Row(DataManager.NameIndex) = Int32.Parse(cmdGetIdentity.ExecuteScalar().ToString())
				'Dim ID As Integer = e.Row(DataManager.NameIndex)
				e.Row.AcceptChanges()
			End If
		End Sub

		Function DataReaderToCells(ByVal Source As Data.OleDb.OleDbDataReader) As Cell()
			Dim Values(Source.FieldCount - 1) As Object
			Source.GetValues(Values)
			Dim Cells(UBound(Values)) As Cell
			For N As Integer = 0 To UBound(Values)
				Dim Cell As New Cell
				Cell.Name = Source.GetName(N)
				Cell.Value = Values(N)
				Cells(N) = Cell
			Next
			Return Cells
		End Function

		Public Class Cell
			Public Name As String
			Public Value As Object
			Public Sub SetValue(ByVal Name As String, ByVal Value As Object)
				Me.Name = Name
				Me.Value = Value
			End Sub
		End Class

	End Module

End Namespace
