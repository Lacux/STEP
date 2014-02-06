'
' Created by SharpDevelop.
' User: peterelv
' Date: 29.01.2014 21:44
' Module:
' Version: 
' Description:  
' 
' 
'
Partial Class pz_partyList
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pz_partyList))
		Me.pb_logo = New System.Windows.Forms.PictureBox()
		Me.gb_Menu = New System.Windows.Forms.GroupBox()
		Me.lb_Group = New System.Windows.Forms.Label()
		Me.tb_Group = New System.Windows.Forms.TextBox()
		Me.bt_Reports = New System.Windows.Forms.Button()
		Me.lb_RegReference = New System.Windows.Forms.Label()
		Me.lb_name = New System.Windows.Forms.Label()
		Me.cb_Active = New System.Windows.Forms.CheckBox()
		Me.tb_RegReference = New System.Windows.Forms.TextBox()
		Me.tb_Name = New System.Windows.Forms.TextBox()
		Me.lb_type = New System.Windows.Forms.Label()
		Me.cb_type = New System.Windows.Forms.ComboBox()
		Me.bt_New = New System.Windows.Forms.Button()
		Me.bt_Clear = New System.Windows.Forms.Button()
		Me.bt_Find = New System.Windows.Forms.Button()
		Me.dgv_partnerList = New System.Windows.Forms.DataGridView()
		Me.PARTY_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_NUMBER = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_TYPE_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_ORG_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.REG_REFERENCE = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.TAX_REFERENCE = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_GROUP_NAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.PARTY_GENERAL_ADDRESS = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.STATUS_FLAG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
		Me.cms_newPZ = New System.Windows.Forms.ContextMenuStrip(Me.components)
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.gb_Menu.SuspendLayout
		CType(Me.dgv_partnerList,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'pb_logo
		'
		resources.ApplyResources(Me.pb_logo, "pb_logo")
		Me.pb_logo.Name = "pb_logo"
		Me.pb_logo.TabStop = false
		'
		'gb_Menu
		'
		Me.gb_Menu.BackColor = System.Drawing.SystemColors.Control
		Me.gb_Menu.Controls.Add(Me.lb_Group)
		Me.gb_Menu.Controls.Add(Me.tb_Group)
		Me.gb_Menu.Controls.Add(Me.bt_Reports)
		Me.gb_Menu.Controls.Add(Me.lb_RegReference)
		Me.gb_Menu.Controls.Add(Me.lb_name)
		Me.gb_Menu.Controls.Add(Me.cb_Active)
		Me.gb_Menu.Controls.Add(Me.tb_RegReference)
		Me.gb_Menu.Controls.Add(Me.tb_Name)
		Me.gb_Menu.Controls.Add(Me.lb_type)
		Me.gb_Menu.Controls.Add(Me.cb_type)
		Me.gb_Menu.Controls.Add(Me.bt_New)
		Me.gb_Menu.Controls.Add(Me.bt_Clear)
		Me.gb_Menu.Controls.Add(Me.bt_Find)
		resources.ApplyResources(Me.gb_Menu, "gb_Menu")
		Me.gb_Menu.Name = "gb_Menu"
		Me.gb_Menu.TabStop = false
		'
		'lb_Group
		'
		resources.ApplyResources(Me.lb_Group, "lb_Group")
		Me.lb_Group.Name = "lb_Group"
		'
		'tb_Group
		'
		resources.ApplyResources(Me.tb_Group, "tb_Group")
		Me.tb_Group.Name = "tb_Group"
		'
		'bt_Reports
		'
		resources.ApplyResources(Me.bt_Reports, "bt_Reports")
		Me.bt_Reports.Name = "bt_Reports"
		Me.bt_Reports.UseVisualStyleBackColor = true
		'
		'lb_RegReference
		'
		resources.ApplyResources(Me.lb_RegReference, "lb_RegReference")
		Me.lb_RegReference.Name = "lb_RegReference"
		'
		'lb_name
		'
		resources.ApplyResources(Me.lb_name, "lb_name")
		Me.lb_name.Name = "lb_name"
		'
		'cb_Active
		'
		resources.ApplyResources(Me.cb_Active, "cb_Active")
		Me.cb_Active.Checked = true
		Me.cb_Active.CheckState = System.Windows.Forms.CheckState.Checked
		Me.cb_Active.Name = "cb_Active"
		Me.cb_Active.UseVisualStyleBackColor = true
		'
		'tb_RegReference
		'
		resources.ApplyResources(Me.tb_RegReference, "tb_RegReference")
		Me.tb_RegReference.Name = "tb_RegReference"
		'
		'tb_Name
		'
		resources.ApplyResources(Me.tb_Name, "tb_Name")
		Me.tb_Name.Name = "tb_Name"
		'
		'lb_type
		'
		resources.ApplyResources(Me.lb_type, "lb_type")
		Me.lb_type.Name = "lb_type"
		'
		'cb_type
		'
		Me.cb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_type.FormattingEnabled = true
		resources.ApplyResources(Me.cb_type, "cb_type")
		Me.cb_type.Name = "cb_type"
		'
		'bt_New
		'
		resources.ApplyResources(Me.bt_New, "bt_New")
		Me.bt_New.Name = "bt_New"
		Me.bt_New.UseVisualStyleBackColor = true
		AddHandler Me.bt_New.Click, AddressOf Me.Bt_NewClick
		'
		'bt_Clear
		'
		resources.ApplyResources(Me.bt_Clear, "bt_Clear")
		Me.bt_Clear.Name = "bt_Clear"
		Me.bt_Clear.UseVisualStyleBackColor = true
		AddHandler Me.bt_Clear.Click, AddressOf Me.Bt_ClearClick
		'
		'bt_Find
		'
		Me.bt_Find.BackColor = System.Drawing.SystemColors.Control
		resources.ApplyResources(Me.bt_Find, "bt_Find")
		Me.bt_Find.Name = "bt_Find"
		Me.bt_Find.UseVisualStyleBackColor = true
		AddHandler Me.bt_Find.Click, AddressOf Me.Bt_FindClick
		'
		'dgv_partnerList
		'
		Me.dgv_partnerList.AllowUserToAddRows = false
		Me.dgv_partnerList.AllowUserToDeleteRows = false
		Me.dgv_partnerList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dgv_partnerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgv_partnerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PARTY_ID, Me.PARTY_NUMBER, Me.PARTY_TYPE, Me.PARTY_TYPE_NAME, Me.PARTY_ORG_NAME, Me.PARTY_NAME, Me.REG_REFERENCE, Me.TAX_REFERENCE, Me.PARTY_GROUP_NAME, Me.PARTY_GENERAL_ADDRESS, Me.STATUS_FLAG})
		resources.ApplyResources(Me.dgv_partnerList, "dgv_partnerList")
		Me.dgv_partnerList.MultiSelect = false
		Me.dgv_partnerList.Name = "dgv_partnerList"
		Me.dgv_partnerList.ReadOnly = true
		Me.dgv_partnerList.RowTemplate.Height = 24
		AddHandler Me.dgv_partnerList.DoubleClick, AddressOf Me.Dgv_partnerListDoubleClick
		'
		'PARTY_ID
		'
		resources.ApplyResources(Me.PARTY_ID, "PARTY_ID")
		Me.PARTY_ID.Name = "PARTY_ID"
		Me.PARTY_ID.ReadOnly = true
		'
		'PARTY_NUMBER
		'
		resources.ApplyResources(Me.PARTY_NUMBER, "PARTY_NUMBER")
		Me.PARTY_NUMBER.Name = "PARTY_NUMBER"
		Me.PARTY_NUMBER.ReadOnly = true
		'
		'PARTY_TYPE
		'
		resources.ApplyResources(Me.PARTY_TYPE, "PARTY_TYPE")
		Me.PARTY_TYPE.Name = "PARTY_TYPE"
		Me.PARTY_TYPE.ReadOnly = true
		'
		'PARTY_TYPE_NAME
		'
		resources.ApplyResources(Me.PARTY_TYPE_NAME, "PARTY_TYPE_NAME")
		Me.PARTY_TYPE_NAME.Name = "PARTY_TYPE_NAME"
		Me.PARTY_TYPE_NAME.ReadOnly = true
		'
		'PARTY_ORG_NAME
		'
		resources.ApplyResources(Me.PARTY_ORG_NAME, "PARTY_ORG_NAME")
		Me.PARTY_ORG_NAME.Name = "PARTY_ORG_NAME"
		Me.PARTY_ORG_NAME.ReadOnly = true
		'
		'PARTY_NAME
		'
		resources.ApplyResources(Me.PARTY_NAME, "PARTY_NAME")
		Me.PARTY_NAME.Name = "PARTY_NAME"
		Me.PARTY_NAME.ReadOnly = true
		'
		'REG_REFERENCE
		'
		resources.ApplyResources(Me.REG_REFERENCE, "REG_REFERENCE")
		Me.REG_REFERENCE.Name = "REG_REFERENCE"
		Me.REG_REFERENCE.ReadOnly = true
		'
		'TAX_REFERENCE
		'
		resources.ApplyResources(Me.TAX_REFERENCE, "TAX_REFERENCE")
		Me.TAX_REFERENCE.Name = "TAX_REFERENCE"
		Me.TAX_REFERENCE.ReadOnly = true
		'
		'PARTY_GROUP_NAME
		'
		resources.ApplyResources(Me.PARTY_GROUP_NAME, "PARTY_GROUP_NAME")
		Me.PARTY_GROUP_NAME.Name = "PARTY_GROUP_NAME"
		Me.PARTY_GROUP_NAME.ReadOnly = true
		'
		'PARTY_GENERAL_ADDRESS
		'
		resources.ApplyResources(Me.PARTY_GENERAL_ADDRESS, "PARTY_GENERAL_ADDRESS")
		Me.PARTY_GENERAL_ADDRESS.Name = "PARTY_GENERAL_ADDRESS"
		Me.PARTY_GENERAL_ADDRESS.ReadOnly = true
		'
		'STATUS_FLAG
		'
		resources.ApplyResources(Me.STATUS_FLAG, "STATUS_FLAG")
		Me.STATUS_FLAG.Name = "STATUS_FLAG"
		Me.STATUS_FLAG.ReadOnly = true
		'
		'cms_newPZ
		'
		Me.cms_newPZ.Name = "cms_newPZ"
		resources.ApplyResources(Me.cms_newPZ, "cms_newPZ")
		'
		'pz_partyList
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.dgv_partnerList)
		Me.Controls.Add(Me.gb_Menu)
		Me.Controls.Add(Me.pb_logo)
		Me.Name = "pz_partyList"
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).EndInit
		Me.gb_Menu.ResumeLayout(false)
		Me.gb_Menu.PerformLayout
		CType(Me.dgv_partnerList,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
	Private PARTY_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
	Private PARTY_GENERAL_ADDRESS As System.Windows.Forms.DataGridViewTextBoxColumn
	Private tb_Group As System.Windows.Forms.TextBox
	Private lb_Group As System.Windows.Forms.Label
	Private bt_Reports As System.Windows.Forms.Button
	Private cms_newPZ As System.Windows.Forms.ContextMenuStrip
	Private PARTY_ORG_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
	Private STATUS_FLAG As System.Windows.Forms.DataGridViewCheckBoxColumn
	Private TAX_REFERENCE As System.Windows.Forms.DataGridViewTextBoxColumn
	Private PARTY_GROUP_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
	Private REG_REFERENCE As System.Windows.Forms.DataGridViewTextBoxColumn
	Private PARTY_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
	Private PARTY_TYPE_NAME As System.Windows.Forms.DataGridViewTextBoxColumn
	Private PARTY_NUMBER As System.Windows.Forms.DataGridViewTextBoxColumn
	Private PARTY_ID As System.Windows.Forms.DataGridViewTextBoxColumn
	Private dgv_partnerList As System.Windows.Forms.DataGridView
	Private cb_type As System.Windows.Forms.ComboBox
	Private lb_type As System.Windows.Forms.Label
	Private tb_Name As System.Windows.Forms.TextBox
	Private tb_RegReference As System.Windows.Forms.TextBox
	Private cb_Active As System.Windows.Forms.CheckBox
	Private lb_name As System.Windows.Forms.Label
	Private lb_RegReference As System.Windows.Forms.Label
	Private bt_Find As System.Windows.Forms.Button
	Private bt_Clear As System.Windows.Forms.Button
	Private bt_New As System.Windows.Forms.Button
	Private gb_Menu As System.Windows.Forms.GroupBox
	Private pb_logo As System.Windows.Forms.PictureBox
End Class
