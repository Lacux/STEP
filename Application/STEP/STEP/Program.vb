'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 22:55
' Module:
' Version: 
' Description:  
' 
' 
'
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
	' This file controls the behaviour of the application.
	Partial Class MyApplication
		Public Sub New()
			MyBase.New(AuthenticationMode.Windows)
			Me.IsSingleInstance = False
			Me.EnableVisualStyles = True
			Me.SaveMySettingsOnExit = True
			Me.ShutDownStyle = ShutdownMode.AfterMainFormCloses
		End Sub
		
		Protected Overrides Sub OnCreateMainForm()
			Me.MainForm = My.Forms.fnd_MainForm
		End Sub
	End Class
End Namespace
