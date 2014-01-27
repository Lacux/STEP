'
' Created by SharpDevelop.
' User: peterelv
' Date: 05.01.2014 17:36
' Module:
' Version: 
' Description:  
' 
' 
'
Partial Class fnd_LoadApp
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
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fnd_LoadApp))
		Me.lb_AppName = New System.Windows.Forms.Label()
		Me.pb_AppLoad = New System.Windows.Forms.ProgressBar()
		Me.tm_App_Load = New System.Windows.Forms.Timer(Me.components)
		Me.lb_LoadInfo = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'lb_AppName
		'
		resources.ApplyResources(Me.lb_AppName, "lb_AppName")
		Me.lb_AppName.Name = "lb_AppName"
		'
		'pb_AppLoad
		'
		resources.ApplyResources(Me.pb_AppLoad, "pb_AppLoad")
		Me.pb_AppLoad.Name = "pb_AppLoad"
		'
		'tm_App_Load
		'
		AddHandler Me.tm_App_Load.Tick, AddressOf Me.Tm_App_LoadTick
		'
		'lb_LoadInfo
		'
		resources.ApplyResources(Me.lb_LoadInfo, "lb_LoadInfo")
		Me.lb_LoadInfo.Name = "lb_LoadInfo"
		'
		'fnd_LoadApp
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.lb_LoadInfo)
		Me.Controls.Add(Me.pb_AppLoad)
		Me.Controls.Add(Me.lb_AppName)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "fnd_LoadApp"
		AddHandler FormClosed, AddressOf Me.Fnd_LoadAppFormClosed
		AddHandler Load, AddressOf Me.Fnd_LoadAppLoad
		Me.ResumeLayout(false)
	End Sub
	Private lb_LoadInfo As System.Windows.Forms.Label
	Private tm_App_Load As System.Windows.Forms.Timer
	Private pb_AppLoad As System.Windows.Forms.ProgressBar
	Private lb_AppName As System.Windows.Forms.Label
End Class
