'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 23:19
' Module: FND - Basic Module
' Version: 1.0
' Description: Manage Database/LogIn in database
' 
' 
'
Imports System
Imports System.Data
Imports System.IO
Imports System.Threading
Imports System.Resources
Imports System.Globalization
Imports System.IO.FileNotFoundException
Imports FirebirdSql.Data.FirebirdClient
Imports System.Security.Cryptography
Public Partial Class fnd_Connections
	Dim MsgTransl As New ResourceManager("STEP.resFNDMessages", GetType(fnd_Connections).Assembly)
	
	
	Public Sub New()
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		' Load images
		Try
			Me.pb_logo.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Connections_db_64.png")
			Me.bt_Connet.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Connect_db_32.png")
			Me.bt_NewDB.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\New_db_32.png")
			Me.bt_DropDB.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Drop_db_32.png")
			Me.bt_Add.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Add_db_32.png")
		Catch ex As System.IO.FileNotFoundException
			MessageBox.Show(MsgTransl.GetString("strMissingPics") + ex.Message, MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		End Try
		
		' Set default application language in choose list: Latvian (0)
		Me.cb_APPLanguage.SelectedIndex = 0 
		
		' Set APP name and Version
		Me.lb_APPVersion.Text = G_APPS_NAME & " " & G_APPS_VERS 
		
		' Load db list 
		GetDBlist()
		
	End Sub
	
	
	Sub Cb_APPLanguageSelectedIndexChanged(sender As Object, e As EventArgs)
		' Check choosen language
		If Me.cb_APPLanguage.SelectedIndex = 0 Then
			Thread.CurrentThread.CurrentUICulture = New CultureInfo("lv")
		End If
		
		' Change language of form
		ChangeLanguage()
		
	End Sub
	
	Sub ChangeLanguage
		' Change language of form 
		Dim LocRM As New ResourceManager(GetType(fnd_Connections))
		Me.bt_Connet.Text = LocRM.GetString("bt_Connet.Text") 
		Me.bt_DropDB.Text = LocRM.GetString("bt_DropDB.Text")
		Me.bt_NewDB.text = LocRM.GetString("bt_NewDB.Text")
		Me.bt_Add.Text = LocRM.GetString("bt_Add.Text")
		Me.gb_Menu.Text = LocRM.GetString("gb_Menu.Text")
		Me.lb_APPLanguagle.Text = LocRM.GetString("lb_APPLanguagle.Text")
		Me.lb_Password.Text = LocRM.GetString("lb_Password.Text")
		Me.lb_UserName.Text = LocRM.GetString("lb_UserName.Text")
		Me.Text = LocRM.GetString("$this.Text")
	End Sub
	
	Sub GetDBlist
		' Clean listview
		Me.lw_dblist.Items.Clear
		
		' Connect to local db and load data
		Dim dBaseConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " & _
			"Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & G_APPS_NAME & ";" & _
			"Extended Properties=dBase IV")
		dBaseConnection.Open()
		
		Dim SQLCreateCommand As String
		SQLCreateCommand = "SELECT DB_NAME, DB_ADDRESS, DB_TYPE, DB_HOST FROM STEPLIST"
		
		Dim dBaseCommand As New System.Data.OleDb.OleDbCommand(SQLCreateCommand, dBaseConnection)
		Dim dBaseDataReader As System.Data.OleDb.OleDbDataReader = dBaseCommand.ExecuteReader(CommandBehavior.SequentialAccess)
		While dBaseDataReader.Read
			Dim strn(5) As String
			strn(1) = dBaseDataReader(0).ToString
			strn(2) = dBaseDataReader(1).ToString
			strn(4) = dBaseDataReader(2).ToString
			strn(3) = dBaseDataReader(3).ToString			
			
			If strn(4) = "0" Then
				strn(0) = MsgTransl.GetString("strConnServer")
			Else
				strn(0) = MsgTransl.GetString("strConnLocal")
			End If
			
			
			Dim itm As New ListViewItem(strn)
			lw_dblist.items.Add(itm)
			
		End While
		dBaseConnection.Close()
	End Sub
	
	Sub Bt_AddClick(sender As Object, e As EventArgs)
		'0 - Add Database
		Dim s_db_acction As Integer = 0
		Dim oForm As New fnd_DBAddCreate(s_db_acction)
		oForm.MdiParent = fnd_MainForm
		oForm.Show()
		oForm = Nothing
	End Sub
	
	Sub Bt_DropDBClick(sender As Object, e As EventArgs)
		' Removing selected database from list
		If Me.lw_dblist.SelectedItems.Count = 0 Then
			MessageBox.Show(MsgTransl.GetString("strConnDropNoDB"), MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)	
		Else
			If Me.lw_dblist.SelectedItems.Count > 0 Then
				Dim drop_loc As String = ""
				Dim drop_name As String = ""
				For Each item As ListViewItem In lw_dblist.SelectedItems
					drop_loc = item.SubItems(2).Text
					drop_name = item.SubItems(1).Text
				Next
				
				Dim MsgResult = MessageBox.Show(MsgTransl.GetString("strConnDropWarn1") & drop_name & MsgTransl.GetString("strConnDropWarn2") & drop_loc, MsgTransl.GetString("strWarning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
				If MsgResult = DialogResult.Yes Then
					
					Dim dBaseConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " & _
						"Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & G_APPS_NAME & ";" & _
						"Extended Properties=dBase IV")
					dBaseConnection.Open()
					
					Dim SQLCreateCommand As String
					SQLCreateCommand = "DELETE FROM STEPLIST WHERE DB_NAME = '" & drop_name & "' AND DB_ADDRESS = '" & drop_loc & "'"
					
					Dim dBaseCommand As New System.Data.OleDb.OleDbCommand(SQLCreateCommand, dBaseConnection)
					dBaseCommand.ExecuteNonQuery()
					
					dBaseConnection.Close()
					'Reload db list
					GetDBlist()
				End if	
			End if
		End if
	End Sub
	
	Sub Bt_NewDBClick(sender As Object, e As EventArgs)
		'1 - New Database
		Dim s_db_acction As Integer = 1
		Dim oForm As New fnd_DBAddCreate(s_db_acction)
		oForm.MdiParent = fnd_MainForm
		oForm.Show()
		oForm = Nothing       
		
	End Sub
	
	Sub Bt_ConnetClick(sender As Object, e As EventArgs)
		'Call procedure pro_fnd_users to validate user data/login
		Using FBDS As New DataSet
			Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
				conn.Open			
				Using command As New FbCommand("SELECT R_ERROR_ID, R_USER_NAME FROM PRO_FND_USERS(@ACTION, @NAME, @PASSWORD, @STATUS);", conn)
					command.Parameters.AddWithValue("@ACTION", 3)
					command.Parameters.AddWithValue("@NAME", Me.tb_UserName.Text)
					Using md5Hash As MD5 = MD5.Create()
						Dim apppassmowrd As String = clsFNDMD5.GetMd5Hash(md5Hash, Me.tb_Password.Text)
						command.Parameters.AddWithValue("@PASSWORD", apppassmowrd)
					End Using 
					command.Parameters.AddWithValue("@STATUS", "")
					
					Using FbAdapterUSER As New FbDataAdapter(command)
						FbAdapterUSER.Fill( FBDS, "LogInResult")
						If CType(FBDS.Tables("LogInResult").Rows(0).Item(0), String) = "profnduserr0" Then
							G_US_NAME = CType(FBDS.Tables("LogInResult").Rows(0).Item(1), String)	
							G_FND_VALID = 1
							'	Me.ParentForm.Controls.
							Me.Close
						Else
							MessageBox.Show(MsgTransl.GetString(CType(FBDS.Tables("LogInResult").Rows(0).Item(0), String)), _
								MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, _
								MessageBoxDefaultButton.Button1)
							G_FND_VALID = 0
						End If
					End Using
				End Using
				conn.Close
			End Using
		End Using
	End Sub
	
	Sub Fnd_ConnectionsActivated(sender As Object, e As EventArgs)
		' When form has focuss - re-load db list and disable Connect button
		GetDBlist()
		Me.bt_Connet.Enabled = False
	End Sub
	
	
	Sub Lw_dblistSelectedIndexChanged(sender As Object, e As EventArgs)
		'Check {1} local database exist or {2} can connect to server database and enable/disable Connect button
		If Me.lw_dblist.SelectedItems.Count > 0 Then
			For Each item As ListViewItem In lw_dblist.SelectedItems
				G_APP_DB_NAME = item.SubItems(1).Text
				G_DB_LOCATION = item.SubItems(2).Text
				G_DB_SV_TYPE = item.SubItems(4).Text
				G_DB_HOST = item.SubItems(3).Text
			Next
			
			If G_DB_SV_TYPE = "1" Then
				If File.Exists(G_DB_LOCATION) Then
					Me.bt_Connet.Enabled = True
				Else
					Me.bt_Connet.Enabled = False
					MessageBox.Show(MsgTransl.GetString("strConnConnNoDB") & G_APP_DB_NAME & ": " & G_DB_LOCATION, MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
				End If
			Else
				Try				
					Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
						conn.Open
						conn.Close
						Me.bt_Connet.Enabled = True
					End Using
				Catch ex As FbException
					Me.bt_Connet.Enabled = False
					MessageBox.Show(MsgTransl.GetString("strConnConnFailed1") & G_APP_DB_NAME & MsgTransl.GetString("strConnConnFailed2") & ex.Message , MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
				End Try
			End If
		End If
	End Sub
	
	Sub Fnd_ConnectionsFormClosed(sender As Object, e As FormClosedEventArgs)
		modFNDOpenForms.fndOpenForms.Remove(Me.Name)
		Me.Dispose
	End Sub
	
	Sub Fnd_ConnectionsLoad(sender As Object, e As EventArgs)
		modFNDOpenForms.fndOpenForms.Add(Me.Name, Me)
	End Sub
End Class
