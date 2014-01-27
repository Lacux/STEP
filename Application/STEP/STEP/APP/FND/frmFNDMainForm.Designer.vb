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
Partial Class fnd_MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fnd_MainForm))
		Me.menu_MainMenu = New System.Windows.Forms.MenuStrip()
		Me.mi_stDataBase = New System.Windows.Forms.ToolStripMenuItem()
		Me.menu_MainMenu.SuspendLayout
		Me.SuspendLayout
		'
		'menu_MainMenu
		'
		resources.ApplyResources(Me.menu_MainMenu, "menu_MainMenu")
		Me.menu_MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_stDataBase})
		Me.menu_MainMenu.Name = "menu_MainMenu"
		'
		'mi_stDataBase
		'
		resources.ApplyResources(Me.mi_stDataBase, "mi_stDataBase")
		Me.mi_stDataBase.Name = "mi_stDataBase"
		AddHandler Me.mi_stDataBase.Click, AddressOf Me.Mi_stDataBaseClick
		'
		'fnd_MainForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.menu_MainMenu)
		Me.IsMdiContainer = true
		Me.MainMenuStrip = Me.menu_MainMenu
		Me.Name = "fnd_MainForm"
		AddHandler Load, AddressOf Me.Fnd_MainFormLoad
		Me.menu_MainMenu.ResumeLayout(false)
		Me.menu_MainMenu.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private mi_stDataBase As System.Windows.Forms.ToolStripMenuItem
	Private menu_MainMenu As System.Windows.Forms.MenuStrip
End Class
