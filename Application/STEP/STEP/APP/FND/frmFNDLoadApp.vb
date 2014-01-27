'
' Created by SharpDevelop.
' User: peterelv
' Date: 05.01.2014 17:36
' Module: FND - Basic Module
' Version: 1.0
' Description: Load App data 
' 
' 
'
Imports System.Threading
Imports System.Globalization
Imports System.Resources
Imports System.IO

Public Partial Class fnd_LoadApp
	Public Sub New()
				
		' Set default application language: Latvian
		Thread.CurrentThread.CurrentUICulture = New CultureInfo(G_APPS_LANG)
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	Sub Tm_App_LoadTick(sender As Object, e As EventArgs)
		Dim MsgTransl As New ResourceManager("STEP.resFNDMessages", GetType(fnd_LoadApp).Assembly)	
		Me.pb_AppLoad.Increment(10)
		Try
			If File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & G_APPS_NAME & "\" & "STEPLIST.DBF") Then
				If Me.pb_AppLoad.Value = Me.pb_AppLoad.Maximum Then
					Me.tm_App_Load.Stop
					Dim oForm As New fnd_Connections
					oForm.MdiParent = fnd_MainForm
					oForm.Show()
					oForm = Nothing
			   	    Me.Close
				End If		
			Else
				If Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + G_APPS_NAME) Then
				Else
					Me.lb_LoadInfo.Text = MsgTransl.GetString("strCreateDirDB")
					Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\" + G_APPS_NAME)
					Me.lb_LoadInfo.Text = MsgTransl.GetString("strDoneDirDB")
				End If
				
				Me.lb_LoadInfo.Text = MsgTransl.GetString("strCreatListDB")
			
				Dim dBaseConnection As New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " & _
					"Data Source=" & Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & G_APPS_NAME & ";" & _
					"Extended Properties=dBase IV")
					dBaseConnection.Open()

				Dim SQLCreateCommand As String
					SQLCreateCommand = "CREATE TABLE STEPLIST (DB_NAME Text(100), DB_ADDRESS MEMO, DB_HOST Text(40), DB_TYPE Text(10))"

				Dim dBaseCommand As New System.Data.OleDb.OleDbCommand(SQLCreateCommand, dBaseConnection)
					dBaseCommand.ExecuteNonQuery()
					
					dBaseConnection.Close()
				Me.lb_LoadInfo.Text =  MsgTransl.GetString("strDoneListDB")
			End If
		Catch ex As Exception
			Me.tm_App_Load.Stop
			MessageBox.Show(MsgTransl.GetString("strError") & Ex.Message)
			Close()
		End Try
	End Sub
	
	Sub Fnd_LoadAppLoad(sender As Object, e As EventArgs)
		Me.tm_App_Load.Start
	End Sub
	
	Sub Fnd_LoadAppFormClosed(sender As Object, e As FormClosedEventArgs)
		Me.Dispose
	End Sub
End Class
