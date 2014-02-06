'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 22:52
' Module: FND - Basic Module
' Version: 1.0
' Description: Main form of APP
' 
' 
'
Imports System.Resources
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public Partial Class fnd_MainForm	
	Dim MsgTransl As New ResourceManager("STEP.resFNDMessages", GetType(fnd_Connections).Assembly)	
	Public Sub New()
		' Set default application language: Latvian
		Thread.CurrentThread.CurrentUICulture = New CultureInfo(G_APPS_LANG)
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		
		' Load images
		Try
			Me.tssl_app_user.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\User_db_16.png")
			Me.tssl_app_db.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\FND\Images\Connections_db_16.png")
		Catch ex As System.IO.FileNotFoundException
			MessageBox.Show(MsgTransl.GetString("strMissingPics") + ex.Message, MsgTransl.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		End Try
		
		' Load ss_MainForm Text
		Me.tssl_app_user.Text = MsgTransl.GetString("strMainFormUser")
		Me.tssl_app_db.Text = MsgTransl.GetString("strMainFormDBName")
		Me.tssl_app_db_Loc.Text = MsgTransl.GetString("strMainFormDBLocation")
		
	End Sub
	
	
	
	Sub Mi_stDataBaseClick(sender As Object, e As EventArgs)
		Dim oForm As New fnd_Connections
		oForm.MdiParent = Me
		oForm.Show()
		oForm = Nothing	
		G_FND_VALID = 0
	End Sub
	
	Sub Fnd_MainFormLoad(sender As Object, e As EventArgs)
		Me.menu_MainMenu.Hide
		Dim oForm As New fnd_LoadApp
		oForm.MdiParent = Me
		oForm.Show()
		oForm = Nothing
	End Sub
	
	
	Sub Fnd_MainFormMdiChildActivate(sender As Object, e As EventArgs) 
		For each f as Form in System.Windows.Forms.Application.OpenForms
			If f.Name.ToString = "fnd_Connections" Or G_FND_VALID = 0 Then
				Me.menu_MainMenu.Hide
				Me.tssl_app_user_txt.Text = ""
				Me.tssl_app_db_txt.Text = ""
				Me.tssl_app_db_Loc_txt.Text = ""
			Else
				Me.menu_MainMenu.Show
				Me.tssl_app_user_txt.Text = G_US_NAME
				Me.tssl_app_db_txt.Text = G_APP_DB_NAME
				Me.tssl_app_db_Loc_txt.Text = G_DB_HOST & ":"& G_DB_LOCATION
			End if
		Next f	
		
	End Sub
	
	Sub Mi_stPartnersClick(sender As Object, e As EventArgs)
		Dim oForm As New pz_partyList
		oForm.MdiParent = Me
		oForm.Show()
		oForm = Nothing
	End Sub
End Class
