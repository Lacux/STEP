'
' Created by SharpDevelop.
' User: Peterelv
' Date: 25.01.2014 13:49
' Module:
' Version: 
' Description:  
' 
' 
'
Partial Class fnd_DBAddCreate
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fnd_DBAddCreate))
		Me.lb_DB_name = New System.Windows.Forms.Label()
		Me.lb_DB_address = New System.Windows.Forms.Label()
		Me.lb_DB_host = New System.Windows.Forms.Label()
		Me.lb_DB_type = New System.Windows.Forms.Label()
		Me.cb_db_type = New System.Windows.Forms.ComboBox()
		Me.tb_db_name = New System.Windows.Forms.TextBox()
		Me.tb_db_address = New System.Windows.Forms.TextBox()
		Me.tb_db_host = New System.Windows.Forms.TextBox()
		Me.bt_add_address = New System.Windows.Forms.Button()
		Me.pg_bd_info = New System.Windows.Forms.ProgressBar()
		Me.lb_db_info = New System.Windows.Forms.Label()
		Me.bt_add_create = New System.Windows.Forms.Button()
		Me.lb_add_create_db = New System.Windows.Forms.Label()
		Me.pb_logo = New System.Windows.Forms.PictureBox()
		Me.bt_cancel = New System.Windows.Forms.Button()
		Me.ofd_open_db = New System.Windows.Forms.OpenFileDialog()
		Me.sfd_save_db = New System.Windows.Forms.SaveFileDialog()
		Me.bt_test_db = New System.Windows.Forms.Button()
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'lb_DB_name
		'
		resources.ApplyResources(Me.lb_DB_name, "lb_DB_name")
		Me.lb_DB_name.Name = "lb_DB_name"
		'
		'lb_DB_address
		'
		resources.ApplyResources(Me.lb_DB_address, "lb_DB_address")
		Me.lb_DB_address.Name = "lb_DB_address"
		'
		'lb_DB_host
		'
		resources.ApplyResources(Me.lb_DB_host, "lb_DB_host")
		Me.lb_DB_host.Name = "lb_DB_host"
		'
		'lb_DB_type
		'
		resources.ApplyResources(Me.lb_DB_type, "lb_DB_type")
		Me.lb_DB_type.Name = "lb_DB_type"
		'
		'cb_db_type
		'
		Me.cb_db_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_db_type.FormattingEnabled = true
		Me.cb_db_type.Items.AddRange(New Object() {resources.GetString("cb_db_type.Items"), resources.GetString("cb_db_type.Items1")})
		resources.ApplyResources(Me.cb_db_type, "cb_db_type")
		Me.cb_db_type.Name = "cb_db_type"
		AddHandler Me.cb_db_type.SelectedIndexChanged, AddressOf Me.Cb_DB_typeSelectedIndexChanged
		'
		'tb_db_name
		'
		resources.ApplyResources(Me.tb_db_name, "tb_db_name")
		Me.tb_db_name.Name = "tb_db_name"
		'
		'tb_db_address
		'
		resources.ApplyResources(Me.tb_db_address, "tb_db_address")
		Me.tb_db_address.Name = "tb_db_address"
		'
		'tb_db_host
		'
		resources.ApplyResources(Me.tb_db_host, "tb_db_host")
		Me.tb_db_host.Name = "tb_db_host"
		'
		'bt_add_address
		'
		resources.ApplyResources(Me.bt_add_address, "bt_add_address")
		Me.bt_add_address.Name = "bt_add_address"
		Me.bt_add_address.UseVisualStyleBackColor = true
		AddHandler Me.bt_add_address.Click, AddressOf Me.Bt_add_addressClick
		'
		'pg_bd_info
		'
		resources.ApplyResources(Me.pg_bd_info, "pg_bd_info")
		Me.pg_bd_info.Name = "pg_bd_info"
		'
		'lb_db_info
		'
		resources.ApplyResources(Me.lb_db_info, "lb_db_info")
		Me.lb_db_info.Name = "lb_db_info"
		'
		'bt_add_create
		'
		resources.ApplyResources(Me.bt_add_create, "bt_add_create")
		Me.bt_add_create.Name = "bt_add_create"
		Me.bt_add_create.UseVisualStyleBackColor = true
		AddHandler Me.bt_add_create.Click, AddressOf Me.Bt_add_createClick
		'
		'lb_add_create_db
		'
		Me.lb_add_create_db.BackColor = System.Drawing.SystemColors.Control
		resources.ApplyResources(Me.lb_add_create_db, "lb_add_create_db")
		Me.lb_add_create_db.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(0,Byte),Integer))
		Me.lb_add_create_db.Name = "lb_add_create_db"
		'
		'pb_logo
		'
		resources.ApplyResources(Me.pb_logo, "pb_logo")
		Me.pb_logo.Name = "pb_logo"
		Me.pb_logo.TabStop = false
		'
		'bt_cancel
		'
		resources.ApplyResources(Me.bt_cancel, "bt_cancel")
		Me.bt_cancel.Name = "bt_cancel"
		Me.bt_cancel.UseVisualStyleBackColor = true
		AddHandler Me.bt_cancel.Click, AddressOf Me.Bt_cancelClick
		'
		'bt_test_db
		'
		resources.ApplyResources(Me.bt_test_db, "bt_test_db")
		Me.bt_test_db.Name = "bt_test_db"
		Me.bt_test_db.UseVisualStyleBackColor = true
		AddHandler Me.bt_test_db.Click, AddressOf Me.Bt_test_dbClick
		'
		'fnd_DBAddCreate
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.bt_test_db)
		Me.Controls.Add(Me.bt_cancel)
		Me.Controls.Add(Me.pb_logo)
		Me.Controls.Add(Me.lb_add_create_db)
		Me.Controls.Add(Me.bt_add_create)
		Me.Controls.Add(Me.lb_db_info)
		Me.Controls.Add(Me.pg_bd_info)
		Me.Controls.Add(Me.bt_add_address)
		Me.Controls.Add(Me.tb_db_host)
		Me.Controls.Add(Me.tb_db_address)
		Me.Controls.Add(Me.tb_db_name)
		Me.Controls.Add(Me.cb_db_type)
		Me.Controls.Add(Me.lb_DB_type)
		Me.Controls.Add(Me.lb_DB_host)
		Me.Controls.Add(Me.lb_DB_address)
		Me.Controls.Add(Me.lb_DB_name)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = false
		Me.MinimizeBox = false
		Me.Name = "fnd_DBAddCreate"
		AddHandler FormClosed, AddressOf Me.Fnd_DBAddCreateFormClosed
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private bt_test_db As System.Windows.Forms.Button
	Private sfd_save_db As System.Windows.Forms.SaveFileDialog
	Private ofd_open_db As System.Windows.Forms.OpenFileDialog
	Private bt_cancel As System.Windows.Forms.Button
	Private pb_logo As System.Windows.Forms.PictureBox
	Private bt_add_create As System.Windows.Forms.Button
	Private lb_add_create_db As System.Windows.Forms.Label
	Private lb_db_info As System.Windows.Forms.Label
	Private pg_bd_info As System.Windows.Forms.ProgressBar
	Private bt_add_address As System.Windows.Forms.Button
	Private tb_db_host As System.Windows.Forms.TextBox
	Private tb_db_address As System.Windows.Forms.TextBox
	Private tb_db_name As System.Windows.Forms.TextBox
	Private cb_db_type As System.Windows.Forms.ComboBox
	Private lb_DB_type As System.Windows.Forms.Label
	Private lb_DB_host As System.Windows.Forms.Label
	Private lb_DB_address As System.Windows.Forms.Label
	Private lb_DB_name As System.Windows.Forms.Label
End Class
