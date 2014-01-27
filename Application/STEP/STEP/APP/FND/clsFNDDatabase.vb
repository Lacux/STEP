'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 23:19
' Module: FND - Basic Module
' Version: 1.0
' Description: Creation of new database
'  
' 
'
'Imports System
Imports System.IO
Imports FirebirdSql.Data.FirebirdClient

Public Class clsFNDDatabase
	
	Shared Function GetConnString() As FbConnectionStringBuilder
		Dim csb As New FbConnectionStringBuilder
		'Dim cl As String = Directory.GetCurrentDirectory
			csb.Database = G_DB_LOCATION
			csb.DataSource = G_DB_HOST
			csb.UserID = G_DB_NAME
			csb.Password = G_DB_PSW
			csb.ServerType = CType(G_DB_SV_TYPE,FbServerType)
			csb.ClientLibrary = G_DB_ClientLibrary
			csb.Dialect = 3
			csb.Charset = "UTF8"
			GetConnString = csb
	End Function
	
	
	'Create new database for application: Parameters DB_NAME and DB_ADDRESS
	'Returns Y - Created, if failed - error message
	Shared Function CreateNewDB () As String
				
		Try
			Dim csb As New FbConnectionStringBuilder
			csb.Database = G_DB_LOCATION
			csb.DataSource = G_DB_HOST
			csb.UserID = G_DB_NAME
			csb.Password = G_DB_PSW
			csb.ServerType = CType(G_DB_SV_TYPE,FbServerType)
			csb.ClientLibrary = G_DB_ClientLibrary
			csb.Dialect = 3
			csb.Charset = "UTF8"
			FbConnection.CreateDatabase(csb.ConnectionString)
			CreateNewDB = "Y"
		Catch ex As Exception
			CreateNewDB = ex.Message
		End Try
		
	End Function
	
	Shared Function CreateTables () As String
		Try
		  	 Dim csb As New FbConnectionStringBuilder
				 csb.Database =  G_DB_LOCATION
				 csb.DataSource = G_DB_HOST
				 csb.UserID = G_DB_NAME
				 csb.Password = G_DB_PSW
				 csb.ServerType = CType(G_DB_SV_TYPE,FbServerType)
				 csb.ClientLibrary = G_DB_ClientLibrary
				 csb.Dialect = 3
				 csb.Charset = "UTF8"
				 Using conn As New FbConnection(csb.ConnectionString)
				 	conn.Open
				 	Dim oAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
				 	Using reader As New StreamReader(oAsm.GetManifestResourceStream(oAsm.GetName.Name & ".NewDBTablesGen.txt"))
				 		Dim line As String
				 		Dim code As String
				 		line = ""
				 		code = ""
				 		Do While reader.Peek() <> -1
				 			line = reader.ReadLine() 
				 			If line = "[-end-]" Then
				 				'Show code
				 				Using create As New FbCommand(code, conn)
									  create.ExecuteNonQuery()
								End Using
				 			ElseIf line = "[-start-]"
				 				'Clean code
				 				code = ""
				 			Else 
				 				code = code & line & vbNewLine
				 			End If
				 		Loop
					End Using
					conn.Close			
				 End Using
	   	   CreateTables = "Y"
		Catch ex As FbException
			MessageBox.Show(ex.Message)
			CreateTables = ex.Message
		End Try
			
	End Function
	
	Shared Function InsertData () As String
		Try
		  	 Dim csb As New FbConnectionStringBuilder
				 csb.Database =  G_DB_LOCATION
				 csb.DataSource = G_DB_HOST
				 csb.UserID = G_DB_NAME
				 csb.Password = G_DB_PSW
				 csb.ServerType = CType(G_DB_SV_TYPE,FbServerType)
				 csb.ClientLibrary = G_DB_ClientLibrary
				 csb.Dialect = 3
				 csb.Charset = "UTF8"
				 Using conn As New FbConnection(csb.ConnectionString)
				 	conn.Open
				 	Dim oAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
				 	Using reader As New StreamReader(oAsm.GetManifestResourceStream(oAsm.GetName.Name & ".NewDBData.txt"))
				 		Dim line As String
				 		Dim code As String
				 		line = ""
				 		code = ""
				 		Do While reader.Peek() <> -1
				 			line = reader.ReadLine() 
				 			If line = "[-end-]" Then
				 				'Show code
				 				Using create As New FbCommand(code, conn)
									  create.ExecuteNonQuery()
								End Using
				 			ElseIf line = "[-start-]"
				 				'Clean code
				 				code = ""
				 			Else 
				 				code = code & line & vbNewLine
				 			End If
				 		Loop
					End Using
					conn.Close			
				 End Using
	   	   InsertData = "Y"
		Catch ex As FbException
			MessageBox.Show(ex.Message)
			InsertData = ex.Message
		End Try
	End Function
	
	Shared Function CreateProcedures () As String
		Try
		  	 Dim csb As New FbConnectionStringBuilder
				 csb.Database =  G_DB_LOCATION
				 csb.DataSource = G_DB_HOST
				 csb.UserID = G_DB_NAME
				 csb.Password = G_DB_PSW
				 csb.ServerType = CType(G_DB_SV_TYPE,FbServerType)
				 csb.ClientLibrary = G_DB_ClientLibrary
				 csb.Dialect = 3
				 csb.Charset = "UTF8"
				 Using conn As New FbConnection(csb.ConnectionString)
				 	conn.Open
				 	Dim oAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
				 	Using reader As New StreamReader(oAsm.GetManifestResourceStream(oAsm.GetName.Name & ".NewDBProcedures.txt"))
				 		Dim line As String
				 		Dim code As String
				 		line = ""
				 		code = ""
				 		Do While reader.Peek() <> -1
				 			line = reader.ReadLine() 
				 			If line = "[-end-]" Then
				 				'Show code
				 				Using create As New FbCommand(code, conn)
									  create.ExecuteNonQuery()
								End Using
				 			ElseIf line = "[-start-]"
				 				'Clean code
				 				code = ""
				 			Else 
				 				code = code & line & vbNewLine
				 			End If
				 		Loop
					End Using
					conn.Close			
				 End Using
	   	   CreateProcedures = "Y"
		Catch ex As FbException
			MessageBox.Show(ex.Message)
			CreateProcedures = ex.Message
		End Try
	End Function
	
	Shared Function CreateTriggers () As String
		Try
		  	 Dim csb As New FbConnectionStringBuilder
				 csb.Database =  G_DB_LOCATION
				 csb.DataSource = G_DB_HOST
				 csb.UserID = G_DB_NAME
				 csb.Password = G_DB_PSW
				 csb.ServerType = CType(G_DB_SV_TYPE,FbServerType)
				 csb.ClientLibrary = G_DB_ClientLibrary
				 csb.Dialect = 3
				 csb.Charset = "UTF8"
				 Using conn As New FbConnection(csb.ConnectionString)
				 	conn.Open
				 	Dim oAsm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
				 	Using reader As New StreamReader(oAsm.GetManifestResourceStream(oAsm.GetName.Name & ".NewDBTriggers.txt"))
				 		Dim line As String
				 		Dim code As String
				 		line = ""
				 		code = ""
				 		Do While reader.Peek() <> -1
				 			line = reader.ReadLine() 
				 			If line = "[-end-]" Then
				 				'Show code
				 				Using create As New FbCommand(code, conn)
									  create.ExecuteNonQuery()
								End Using
				 			ElseIf line = "[-start-]"
				 				'Clean code
				 				code = ""
				 			Else 
				 				code = code & line & vbNewLine
				 			End If
				 		Loop
					End Using
					conn.Close			
				 End Using
	   	   CreateTriggers = "Y"
		Catch ex As FbException
			MessageBox.Show(ex.Message)
			CreateTriggers = ex.Message
		End Try
	End Function
End Class
