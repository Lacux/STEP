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
		Me.mi_stWindows = New System.Windows.Forms.ToolStripMenuItem()
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.tssl_app_user = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tssl_app_user_txt = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tssl_app_db = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tssl_app_db_txt = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tssl_app_db_Loc = New System.Windows.Forms.ToolStripStatusLabel()
		Me.tssl_app_db_Loc_txt = New System.Windows.Forms.ToolStripStatusLabel()
		Me.menu_MainMenu.SuspendLayout
		Me.statusStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'menu_MainMenu
		'
		resources.ApplyResources(Me.menu_MainMenu, "menu_MainMenu")
		Me.menu_MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi_stDataBase, Me.mi_stWindows})
		Me.menu_MainMenu.MdiWindowListItem = Me.mi_stWindows
		Me.menu_MainMenu.Name = "menu_MainMenu"
		Me.menu_MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		'
		'mi_stDataBase
		'
		resources.ApplyResources(Me.mi_stDataBase, "mi_stDataBase")
		Me.mi_stDataBase.Name = "mi_stDataBase"
		AddHandler Me.mi_stDataBase.Click, AddressOf Me.Mi_stDataBaseClick
		'
		'mi_stWindows
		'
		resources.ApplyResources(Me.mi_stWindows, "mi_stWindows")
		Me.mi_stWindows.Name = "mi_stWindows"
		'
		'statusStrip1
		'
		resources.ApplyResources(Me.statusStrip1, "statusStrip1")
		Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssl_app_user, Me.tssl_app_user_txt, Me.tssl_app_db, Me.tssl_app_db_txt, Me.tssl_app_db_Loc, Me.tssl_app_db_Loc_txt})
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
		'
		'tssl_app_user
		'
		resources.ApplyResources(Me.tssl_app_user, "tssl_app_user")
		Me.tssl_app_user.Name = "tssl_app_user"
		'
		'tssl_app_user_txt
		'
		resources.ApplyResources(Me.tssl_app_user_txt, "tssl_app_user_txt")
		Me.tssl_app_user_txt.ForeColor = System.Drawing.Color.Crimson
		Me.tssl_app_user_txt.Name = "tssl_app_user_txt"
		'
		'tssl_app_db
		'
		resources.ApplyResources(Me.tssl_app_db, "tssl_app_db")
		Me.tssl_app_db.Name = "tssl_app_db"
		'
		'tssl_app_db_txt
		'
		resources.ApplyResources(Me.tssl_app_db_txt, "tssl_app_db_txt")
		Me.tssl_app_db_txt.ForeColor = System.Drawing.Color.Crimson
		Me.tssl_app_db_txt.Name = "tssl_app_db_txt"
		'
		'tssl_app_db_Loc
		'
		resources.ApplyResources(Me.tssl_app_db_Loc, "tssl_app_db_Loc")
		Me.tssl_app_db_Loc.Name = "tssl_app_db_Loc"
		'
		'tssl_app_db_Loc_txt
		'
		resources.ApplyResources(Me.tssl_app_db_Loc_txt, "tssl_app_db_Loc_txt")
		Me.tssl_app_db_Loc_txt.ForeColor = System.Drawing.Color.Crimson
		Me.tssl_app_db_Loc_txt.Name = "tssl_app_db_Loc_txt"
		'
		'fnd_MainForm
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.statusStrip1)
		Me.Controls.Add(Me.menu_MainMenu)
		Me.IsMdiContainer = true
		Me.MainMenuStrip = Me.menu_MainMenu
		Me.Name = "fnd_MainForm"
		AddHandler Load, AddressOf Me.Fnd_MainFormLoad
		AddHandler MdiChildActivate, AddressOf Me.Fnd_MainFormMdiChildActivate
		Me.menu_MainMenu.ResumeLayout(false)
		Me.menu_MainMenu.PerformLayout
		Me.statusStrip1.ResumeLayout(false)
		Me.statusStrip1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private tssl_app_db_Loc_txt As System.Windows.Forms.ToolStripStatusLabel
	Private tssl_app_db_Loc As System.Windows.Forms.ToolStripStatusLabel
	Private tssl_app_db_txt As System.Windows.Forms.ToolStripStatusLabel
	Private tssl_app_user_txt As System.Windows.Forms.ToolStripStatusLabel
	Private mi_stWindows As System.Windows.Forms.ToolStripMenuItem
	Private tssl_app_db As System.Windows.Forms.ToolStripStatusLabel
	Private tssl_app_user As System.Windows.Forms.ToolStripStatusLabel
	Private statusStrip1 As System.Windows.Forms.StatusStrip
	Private mi_stDataBase As System.Windows.Forms.ToolStripMenuItem
	Private menu_MainMenu As System.Windows.Forms.MenuStrip
End Class
