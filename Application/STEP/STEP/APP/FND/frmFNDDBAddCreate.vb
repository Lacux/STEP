'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 23:19
' Module: FND - Basic Module
' Version: 1.0
' Description: Creation/Add database
' 
' 
'
Imports System.IO
Imports System.Resources
Imports System.String
Public Partial Class fnd_DBAddCreate
	Dim MsgTransl As New ResourceManager("STEP.resFNDMessages", GetType(fnd_Connections).Assembly)
	Dim db_acction As Integer
	Dim field_validation As Integer
	
	Public Sub New(ByVal s_db_acction As Integer)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		'
		' TODO : Add constructor code after InitializeComponents
		'
		db_acction = s_db_acction
		
		'Load Images and dinamic namings
		Try
			If db_acction = 0 Then	
				Me.pb_logo.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Add_db_64.png")
				Me.bt_add_create.Text = MsgTransl.GetString("strAddCreatebtAdd") 
				Me.lb_add_create_db.Text = MsgTransl.GetString("strAddCreatelbAdd")
				Me.Text = MsgTransl.GetString("strAddCreatelbAdd")
			ElseIf db_acction = 1 Then
				Me.pb_logo.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\New_db_64.png")
				Me.bt_add_create.Text = MsgTransl.GetString("strAddCreatebtCreate")
				Me.lb_add_create_db.Text = MsgTransl.GetString("strAddCreatelbCreate")
				Me.Text = MsgTransl.GetString("strAddCreatelbCreate")
			End If
			
			Me.bt_add_address.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\OpenFile_24.png")
			Me.bt_add_create.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Done_24.png")
			Me.bt_cancel.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Cancel_24.png")
		Catch ex As System.IO.FileNotFoundException
			MessageBox.Show(MsgTransl.GetString("strMissingPics") + ex.Message, MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		End Try
		
		Dim LocRM As New ResourceManager(GetType(fnd_DBAddCreate))
		Me.ofd_open_db.Title = LocRM.GetString("ofd_open_db.Title") 
		Me.ofd_open_db.Filter = LocRM.GetString("ofd_open_db.Filter")
		Me.sfd_save_db.Title = LocRM.GetString("sfd_save_db.Title")
		Me.sfd_save_db.Filter = LocRM.GetString("sfd_save_db.Filter")
		
	End Sub
	
	Sub Bt_add_addressClick(sender As Object, e As EventArgs)
		If db_acction = 0 Then
			If ofd_open_db.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Me.tb_db_address.Text = ofd_open_db.FileName
			End If
		ElseIf db_acction = 1 Then
			If sfd_save_db.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Me.tb_db_address.Text = sfd_save_db.FileName
			End If
		End If
	End Sub
	
	Sub Cb_DB_typeSelectedIndexChanged(sender As Object, e As EventArgs)
		If Me.cb_db_type.SelectedIndex = 0 Then
			Me.tb_db_host.Enabled = False
			Me.tb_db_host.Text = "localhost"
			Me.tb_db_address.Enabled = False
		ElseIf Me.cb_db_type.SelectedIndex = 1 Then
			Me.tb_db_host.Enabled = True
			Me.tb_db_host.Text = ""
			Me.tb_db_address.Enabled = True
		End If		
	End Sub
	
	Sub Bt_add_createClick(sender As Object, e As EventArgs)
		Validation()
		If field_validation = 1 Then
			If db_acction = 0 Then
				Dim dBaseConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " & _
					"Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & G_APPS_NAME & ";" & _
					"Extended Properties=dBase IV")
				dBaseConnection.Open()
				
				Dim SQLCreateCommand As String
				SQLCreateCommand = "INSERT INTO STEPLIST (DB_NAME, DB_ADDRESS, DB_HOST, DB_TYPE) VALUES ('" & Me.tb_db_name.Text & "', '" & G_DB_LOCATION & "', '"& G_DB_HOST &"', '" & G_DB_SV_TYPE & "')"
				
				Dim dBaseCommand As New System.Data.OleDb.OleDbCommand(SQLCreateCommand, dBaseConnection)
				dBaseCommand.ExecuteNonQuery()
				
				dBaseConnection.Close()
				
				Me.lb_db_info.Text = MsgTransl.GetString("strConnInfoDBAdd") & "(" & Me.tb_db_name.text & ")"
				Me.pg_bd_info.Increment(100)			
			Else 
				
				
				Dim resultDB As String
				Me.lb_db_info.Text = MsgTransl.GetString("strCreatListDB")
				resultDB = clsFNDDatabase.CreateNewDB()
				
				If resultDB = "Y" Then
					Me.pg_bd_info.Increment(16)
					Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBTables")
					resultDB = clsFNDDatabase.CreateTables()
					If resultDB = "Y" Then
						Me.pg_bd_info.Increment(17)
						Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBData")
						resultDB = clsFNDDatabase.InsertData()
						If resultDB = "Y" Then
							Me.pg_bd_info.Increment(17)
							Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBProc")
							resultDB = clsFNDDatabase.CreateProcedures()  
							If resultDB = "Y" Then
								Me.pg_bd_info.Increment(17)
								Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBTrigg")
								resultDB = clsFNDDatabase.CreateTriggers() 
								If resultDB = "Y" then
									Me.pg_bd_info.Increment(17)
									Dim dBaseConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " & _
										"Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & G_APPS_NAME & ";" & _
										"Extended Properties=dBase IV")
									dBaseConnection.Open()
									
									Dim SQLCreateCommand As String
									SQLCreateCommand = "INSERT INTO STEPLIST (DB_NAME, DB_ADDRESS, DB_HOST, DB_TYPE) VALUES ('" & Me.tb_db_name.Text & "', '" & G_DB_LOCATION & "', '"& G_DB_HOST &"', '" & G_DB_SV_TYPE & "')"
									
									Dim dBaseCommand As New System.Data.OleDb.OleDbCommand(SQLCreateCommand, dBaseConnection)
									dBaseCommand.ExecuteNonQuery()
									
									dBaseConnection.Close()
									
									Me.lb_db_info.Text = MsgTransl.GetString("strConnInfoDBAdd") & "(" & Me.tb_db_name.Text & ")"
									Me.pg_bd_info.Increment(16)
									
								Else
									Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBTrigger")
									File.Delete(G_DB_LOCATION)
								End if
							Else
								Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBProcer") & resultDB
								File.Delete(G_DB_LOCATION)
							End If
						Else
							Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBDataer") & resultDB
							File.Delete(G_DB_LOCATION)
						End If
					Else
						Me.lb_db_info.Text = MsgTransl.GetString("strCreatDBTableser") & resultDB
						File.Delete(G_DB_LOCATION)
					End If
				Else
					Me.lb_db_info.Text = MsgTransl.GetString("strCreatListDBer") & resultDB
					File.Delete(G_DB_LOCATION)
				End If		
			End If
		End if
	End Sub
	
	Sub Validation
		If	Me.cb_db_type.SelectedIndex < 0 Then
			Me.field_validation = 0
			MessageBox.Show(MsgTransl.GetString("strAddCreateMissType"), MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		ElseIf IsNullOrEmpty(Me.tb_db_name.Text) Then
			Me.field_validation = 0
			MessageBox.Show(MsgTransl.GetString("strAddCreateMissName"), MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		ElseIf IsNullOrEmpty(Me.tb_db_address.Text) Then
			Me.field_validation = 0 
			MessageBox.Show(MsgTransl.GetString("strAddCreateMissLocation"), MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		ElseIf IsNullOrEmpty(Me.tb_db_host.Text) Then
			Me.field_validation = 0
			MessageBox.Show(MsgTransl.GetString("strAddCreateMissHost"), MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		Else
			Me.field_validation = 1
			G_DB_LOCATION = Me.tb_db_address.Text
			G_DB_HOST = Me.tb_db_host.Text
			If Me.cb_db_type.SelectedIndex = 0 Then
				G_DB_SV_TYPE = "1"
			Else
				G_DB_SV_TYPE = "0"
			End If
		End If
	End Sub
	
	Sub Fnd_DBAddCreateFormClosed(sender As Object, e As FormClosedEventArgs)
		Me.Dispose
	End Sub
	
	Sub Bt_cancelClick(sender As Object, e As EventArgs)
		Me.Close		
	End Sub
End Class
