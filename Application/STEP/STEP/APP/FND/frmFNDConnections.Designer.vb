'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 23:19
' Module:
' Version: 
' Description:  
' 
' 
'
Partial Class fnd_Connections
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fnd_Connections))
		Me.gb_Menu = New System.Windows.Forms.GroupBox()
		Me.bt_Add = New System.Windows.Forms.Button()
		Me.bt_DropDB = New System.Windows.Forms.Button()
		Me.bt_NewDB = New System.Windows.Forms.Button()
		Me.bt_Connet = New System.Windows.Forms.Button()
		Me.lb_UserName = New System.Windows.Forms.Label()
		Me.lb_Password = New System.Windows.Forms.Label()
		Me.tb_Password = New System.Windows.Forms.TextBox()
		Me.tb_UserName = New System.Windows.Forms.TextBox()
		Me.lb_APPVersion = New System.Windows.Forms.Label()
		Me.pb_logo = New System.Windows.Forms.PictureBox()
		Me.lb_APPLanguagle = New System.Windows.Forms.Label()
		Me.cb_APPLanguage = New System.Windows.Forms.ComboBox()
		Me.lw_dblist = New System.Windows.Forms.ListView()
		Me.db_type_v = New System.Windows.Forms.ColumnHeader()
		Me.db_name = New System.Windows.Forms.ColumnHeader()
		Me.db_address = New System.Windows.Forms.ColumnHeader()
		Me.db_host = New System.Windows.Forms.ColumnHeader()
		Me.db_type = New System.Windows.Forms.ColumnHeader()
		Me.gb_Menu.SuspendLayout
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'gb_Menu
		'
		Me.gb_Menu.BackColor = System.Drawing.SystemColors.Control
		Me.gb_Menu.Controls.Add(Me.bt_Add)
		Me.gb_Menu.Controls.Add(Me.bt_DropDB)
		Me.gb_Menu.Controls.Add(Me.bt_NewDB)
		Me.gb_Menu.Controls.Add(Me.bt_Connet)
		resources.ApplyResources(Me.gb_Menu, "gb_Menu")
		Me.gb_Menu.Name = "gb_Menu"
		Me.gb_Menu.TabStop = false
		'
		'bt_Add
		'
		resources.ApplyResources(Me.bt_Add, "bt_Add")
		Me.bt_Add.Name = "bt_Add"
		Me.bt_Add.UseVisualStyleBackColor = true
		AddHandler Me.bt_Add.Click, AddressOf Me.Bt_AddClick
		'
		'bt_DropDB
		'
		resources.ApplyResources(Me.bt_DropDB, "bt_DropDB")
		Me.bt_DropDB.Name = "bt_DropDB"
		Me.bt_DropDB.UseVisualStyleBackColor = true
		AddHandler Me.bt_DropDB.Click, AddressOf Me.Bt_DropDBClick
		'
		'bt_NewDB
		'
		resources.ApplyResources(Me.bt_NewDB, "bt_NewDB")
		Me.bt_NewDB.Name = "bt_NewDB"
		Me.bt_NewDB.UseVisualStyleBackColor = true
		AddHandler Me.bt_NewDB.Click, AddressOf Me.Bt_NewDBClick
		'
		'bt_Connet
		'
		Me.bt_Connet.BackColor = System.Drawing.SystemColors.Control
		resources.ApplyResources(Me.bt_Connet, "bt_Connet")
		Me.bt_Connet.Name = "bt_Connet"
		Me.bt_Connet.UseVisualStyleBackColor = true
		AddHandler Me.bt_Connet.Click, AddressOf Me.Bt_ConnetClick
		'
		'lb_UserName
		'
		resources.ApplyResources(Me.lb_UserName, "lb_UserName")
		Me.lb_UserName.Name = "lb_UserName"
		'
		'lb_Password
		'
		resources.ApplyResources(Me.lb_Password, "lb_Password")
		Me.lb_Password.Name = "lb_Password"
		'
		'tb_Password
		'
		resources.ApplyResources(Me.tb_Password, "tb_Password")
		Me.tb_Password.Name = "tb_Password"
		'
		'tb_UserName
		'
		resources.ApplyResources(Me.tb_UserName, "tb_UserName")
		Me.tb_UserName.Name = "tb_UserName"
		'
		'lb_APPVersion
		'
		resources.ApplyResources(Me.lb_APPVersion, "lb_APPVersion")
		Me.lb_APPVersion.Name = "lb_APPVersion"
		'
		'pb_logo
		'
		resources.ApplyResources(Me.pb_logo, "pb_logo")
		Me.pb_logo.Name = "pb_logo"
		Me.pb_logo.TabStop = false
		'
		'lb_APPLanguagle
		'
		resources.ApplyResources(Me.lb_APPLanguagle, "lb_APPLanguagle")
		Me.lb_APPLanguagle.Name = "lb_APPLanguagle"
		'
		'cb_APPLanguage
		'
		Me.cb_APPLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_APPLanguage.FormattingEnabled = true
		Me.cb_APPLanguage.Items.AddRange(New Object() {resources.GetString("cb_APPLanguage.Items")})
		resources.ApplyResources(Me.cb_APPLanguage, "cb_APPLanguage")
		Me.cb_APPLanguage.Name = "cb_APPLanguage"
		AddHandler Me.cb_APPLanguage.SelectedIndexChanged, AddressOf Me.Cb_APPLanguageSelectedIndexChanged
		'
		'lw_dblist
		'
		Me.lw_dblist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.db_type_v, Me.db_name, Me.db_address, Me.db_host, Me.db_type})
		Me.lw_dblist.FullRowSelect = true
		resources.ApplyResources(Me.lw_dblist, "lw_dblist")
		Me.lw_dblist.Name = "lw_dblist"
		Me.lw_dblist.UseCompatibleStateImageBehavior = false
		Me.lw_dblist.View = System.Windows.Forms.View.Details
		AddHandler Me.lw_dblist.SelectedIndexChanged, AddressOf Me.Lw_dblistSelectedIndexChanged
		'
		'db_type_v
		'
		resources.ApplyResources(Me.db_type_v, "db_type_v")
		'
		'db_name
		'
		resources.ApplyResources(Me.db_name, "db_name")
		'
		'db_address
		'
		resources.ApplyResources(Me.db_address, "db_address")
		'
		'db_host
		'
		resources.ApplyResources(Me.db_host, "db_host")
		'
		'db_type
		'
		resources.ApplyResources(Me.db_type, "db_type")
		'
		'fnd_Connections
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.lw_dblist)
		Me.Controls.Add(Me.cb_APPLanguage)
		Me.Controls.Add(Me.lb_APPLanguagle)
		Me.Controls.Add(Me.pb_logo)
		Me.Controls.Add(Me.lb_APPVersion)
		Me.Controls.Add(Me.tb_UserName)
		Me.Controls.Add(Me.tb_Password)
		Me.Controls.Add(Me.lb_Password)
		Me.Controls.Add(Me.lb_UserName)
		Me.Controls.Add(Me.gb_Menu)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "fnd_Connections"
		AddHandler Activated, AddressOf Me.Fnd_ConnectionsActivated
		AddHandler FormClosed, AddressOf Me.Fnd_ConnectionsFormClosed
		AddHandler Load, AddressOf Me.Fnd_ConnectionsLoad
		Me.gb_Menu.ResumeLayout(false)
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private db_type_v As System.Windows.Forms.ColumnHeader
	Private lw_dblist As System.Windows.Forms.ListView
	Private db_type As System.Windows.Forms.ColumnHeader
	Private db_host As System.Windows.Forms.ColumnHeader
	Private db_address As System.Windows.Forms.ColumnHeader
	Private db_name As System.Windows.Forms.ColumnHeader
	Private bt_Add As System.Windows.Forms.Button
	Private cb_APPLanguage As System.Windows.Forms.ComboBox
	Private lb_APPLanguagle As System.Windows.Forms.Label
	Private pb_logo As System.Windows.Forms.PictureBox
	Private lb_APPVersion As System.Windows.Forms.Label
	Private tb_UserName As System.Windows.Forms.TextBox
	Private tb_Password As System.Windows.Forms.TextBox
	Private lb_Password As System.Windows.Forms.Label
	Private lb_UserName As System.Windows.Forms.Label
	Private bt_Connet As System.Windows.Forms.Button
	Private bt_NewDB As System.Windows.Forms.Button
	Private bt_DropDB As System.Windows.Forms.Button
	Private gb_Menu As System.Windows.Forms.GroupBox
End Class
