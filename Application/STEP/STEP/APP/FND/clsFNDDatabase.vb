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
Imports System.IO
Imports System.String
Imports System.Data
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
	
	Shared Function RunSQLFFDB (ByVal FileName As String) As String
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
				Using reader As New StreamReader(oAsm.GetManifestResourceStream(oAsm.GetName.Name & "." & FileName))
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
			RunSQLFFDB = "Y"
		Catch ex As FbException
			RunSQLFFDB = ex.Message
		End Try
		
	End Function
	
	Public Structure CheckCompabilityStructure
		Public p_app_error As String
		Public p_app_validation As Integer
		Public p_app_version As String
		Public p_db_version As String
		
	End Structure		
	
	Shared Function CheckCompability () As CheckCompabilityStructure
		Dim Result As CheckCompabilityStructure		
		Result.p_app_error = Nothing
		Result.p_app_validation = Nothing
		Result.p_app_version = Nothing
		Result.p_db_version = Nothing
		Try
			Using FBDS As New DataSet
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
					Using command As New FbCommand("SELECT R_ERROR_ID, R_DB_VERSION, R_APP_VERSION FROM PRO_FND_COM_DB_APP (@P_ACTION, @P_DB_VERSION, @P_APP_VERSION)", conn)
						command.Parameters.AddWithValue("@P_ACTION", 0)
						command.Parameters.AddWithValue("@P_DB_VERSION", G_DB_VERS)
						command.Parameters.AddWithValue("@P_APP_VERSION", G_APPS_VERS)
						
						Using FbAdapterDBAPPCOM As New FbDataAdapter(command)
							FbAdapterDBAPPCOM.Fill( FBDS, "APP_DB_LIST")
							Result.p_app_validation = 1
							Result.p_app_error = CType(FBDS.Tables("APP_DB_LIST").Rows(0).Item(0), String)
							If Not FBDS.Tables("APP_DB_LIST").Rows(0).Item(1).Equals(DBNull.Value) then
								Result.p_db_version = CType(FBDS.Tables("APP_DB_LIST").Rows(0).Item(1), String)
							End if
							If Not FBDS.Tables("APP_DB_LIST").Rows(0).Item(2).Equals(DBNull.Value) then
								Result.p_app_version = CType(FBDS.Tables("APP_DB_LIST").Rows(0).Item(2), String)
							End if
						End Using
					End Using
					conn.Close
				End Using
			End Using
		Catch ex As FbException
			Result.p_app_validation = 0
			Result.p_app_error = ex.Message
		End try
		Return Result
		
	End Function
	
	Shared Function UpgradeDB (ByVal Version As String) As Integer
		Dim logFile As StreamWriter
		logFile = My.Computer.FileSystem.OpenTextFileWriter(Path.GetDirectoryName(G_DB_LOCATION) & _
			"\log"& Version & "_" & Date.Now.ToString("ddMMMyyyyHm") & ".txt", True)
		
		Dim resultDB As String
		
		logFile.WriteLine("Upgrade to " & Version)
		logFile.WriteLine("Start Update tables and generators ... ")
		resultDB = clsFNDDatabase.RunSQLFFDB("UpdDBTablesGen" & Version & ".txt")
		If resultDB = "Y" Then
			logFile.WriteLine("Start insert data ... ")
			resultDB = clsFNDDatabase.RunSQLFFDB("UpdDBDataLV" & Version & ".txt")
			If resultDB = "Y" Then
				logFile.WriteLine("Start create procedures ... ")
				resultDB = clsFNDDatabase.RunSQLFFDB("UpdDBProcedures" & Version & ".txt")
				If resultDB = "Y" Then
					logFile.WriteLine("Start create triggers ... ")
					resultDB = clsFNDDatabase.RunSQLFFDB("UpdDBTriggers" & Version & ".txt")
					If resultDB = "Y" then
						'Update compleated
						UpgradeDB = 1
						
					Else
						logFile.WriteLine("Failed create triggers ... " & resultDB)
						UpgradeDB = 0
					End if
				Else
					logFile.WriteLine("Failed create procedures ... " & resultDB)
					UpgradeDB = 0
				End If
			Else
				logFile.WriteLine("Failed insert data ... " & resultDB)
				UpgradeDB = 0
			End If
		Else
			logFile.WriteLine("Failed create tables and generators ... " & resultDB)
			UpgradeDB = 0
		End If
		logFile.Close()
	End Function
	
	Shared Function UpgradeDBVersioning(ByVal DBVersion As String) As String
		Dim UpdDBVers As String = Nothing
		Select Case DBVersion
			Case "0.9.0"
				UpdDBVers = "0.9.1"
			Case "0.9.1"
				UpdDBVers	= "1.0.0"
			Case "1.0.0"
				UpdDBVers = "Final"
		End Select	
		Return UpdDBVers
	End Function
	
	Shared Function FBBackMode (ByVal FBBCMo As Integer) As String
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
				Dim code As String = ""
				
				If FBBCMo = 0 Then
					code = "ALTER DATABASE BEGIN BACKUP"
				Else If FBBCMo = 1 Then
					code = "ALTER DATABASE END BACKUP"
				End If
				
				Using create As New FbCommand(code, conn)
					create.ExecuteNonQuery()
				End Using
				
				conn.Close			
			End Using
			FBBackMode = "Y"
		Catch ex As FbException
			FBBackMode = ex.Message
		End Try
		
	End Function	
	
	Shared Function BackUPDB As String
		Dim backup As String = Path.GetDirectoryName(G_DB_LOCATION) & "\DB_Backup"
		Dim Exten As String = Path.GetExtension(G_DB_LOCATION)
		Dim file As String = Path.GetFileNameWithoutExtension(G_DB_LOCATION)
		Dim backupName As String = "BK_" & file & Date.Now.ToString("ddMMMyyyyHm") & Exten
		Dim copyPlase As New FileInfo(G_DB_LOCATION)
		try
			If Directory.Exists(backup) Then
				copyPlase.CopyTo(Path.Combine(backup, backupName))
				BackUPDB = "Y"
			Else
				Directory.CreateDirectory(backup)
				copyPlase.CopyTo(Path.Combine(backup, backupName))
				BackUPDB = "Y"
			End If
		Catch ex As IOException
			BackUPDB = ex.Message
		End Try
		
		Return BackUPDB
	End Function
End Class
