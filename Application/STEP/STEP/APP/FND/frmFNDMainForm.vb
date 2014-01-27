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

Public Partial Class fnd_MainForm	
	Public Sub New()
		
		
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		'
		' TODO : Add constructor code after InitializeComponents
		'
	End Sub
	
	
	
	Sub Mi_stDataBaseClick(sender As Object, e As EventArgs)
		Dim oForm As New fnd_Connections
		oForm.MdiParent = Me
		oForm.Show()
		oForm = Nothing			
	End Sub
	
	Sub Fnd_MainFormLoad(sender As Object, e As EventArgs)
		Me.menu_MainMenu.Hide
		Dim oForm As New fnd_LoadApp
		oForm.MdiParent = Me
		oForm.Show()
		oForm = Nothing
	End Sub
End Class
