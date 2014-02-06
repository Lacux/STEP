'
' Created by SharpDevelop.
' User: peterelv
' Date: 31.01.2014 14:03
' Module:
' Version: 
' Description:  
' 
' 
'
Partial Class pz_PartyEdit
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pz_PartyEdit))
		Me.pb_logo = New System.Windows.Forms.PictureBox()
		Me.gb_Menu = New System.Windows.Forms.GroupBox()
		Me.bt_Save = New System.Windows.Forms.Button()
		Me.tc_PartyData = New System.Windows.Forms.TabControl()
		Me.tp_BasicInfo = New System.Windows.Forms.TabPage()
		Me.tb_skype = New System.Windows.Forms.TextBox()
		Me.lb_skype = New System.Windows.Forms.Label()
		Me.lb_comments = New System.Windows.Forms.Label()
		Me.tb_comments = New System.Windows.Forms.TextBox()
		Me.tb_www = New System.Windows.Forms.TextBox()
		Me.lb_www = New System.Windows.Forms.Label()
		Me.lb_email = New System.Windows.Forms.Label()
		Me.tb_email = New System.Windows.Forms.TextBox()
		Me.lb_fax = New System.Windows.Forms.Label()
		Me.lb_mobile = New System.Windows.Forms.Label()
		Me.tb_fax = New System.Windows.Forms.TextBox()
		Me.tb_mobile = New System.Windows.Forms.TextBox()
		Me.tb_phone = New System.Windows.Forms.TextBox()
		Me.lb_phone = New System.Windows.Forms.Label()
		Me.tb_title = New System.Windows.Forms.TextBox()
		Me.lb_title = New System.Windows.Forms.Label()
		Me.cb_group = New System.Windows.Forms.ComboBox()
		Me.lb_group = New System.Windows.Forms.Label()
		Me.lb_TaxNum = New System.Windows.Forms.Label()
		Me.tb_TaxNum = New System.Windows.Forms.TextBox()
		Me.tb_RegNum = New System.Windows.Forms.TextBox()
		Me.lb_RegNum = New System.Windows.Forms.Label()
		Me.lb_LastName = New System.Windows.Forms.Label()
		Me.tb_LastName = New System.Windows.Forms.TextBox()
		Me.tb_FirstName = New System.Windows.Forms.TextBox()
		Me.lb_FirstName = New System.Windows.Forms.Label()
		Me.tb_name = New System.Windows.Forms.TextBox()
		Me.lb_name = New System.Windows.Forms.Label()
		Me.lb_orgType = New System.Windows.Forms.Label()
		Me.cb_orgType = New System.Windows.Forms.ComboBox()
		Me.cb_Active = New System.Windows.Forms.CheckBox()
		Me.tb_Number = New System.Windows.Forms.TextBox()
		Me.lb_Number = New System.Windows.Forms.Label()
		Me.lb_TypeName = New System.Windows.Forms.Label()
		Me.lb_type = New System.Windows.Forms.Label()
		Me.tabPage2 = New System.Windows.Forms.TabPage()
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).BeginInit
		Me.gb_Menu.SuspendLayout
		Me.tc_PartyData.SuspendLayout
		Me.tp_BasicInfo.SuspendLayout
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
		Me.gb_Menu.Controls.Add(Me.bt_Save)
		resources.ApplyResources(Me.gb_Menu, "gb_Menu")
		Me.gb_Menu.Name = "gb_Menu"
		Me.gb_Menu.TabStop = false
		'
		'bt_Save
		'
		Me.bt_Save.BackColor = System.Drawing.SystemColors.Control
		resources.ApplyResources(Me.bt_Save, "bt_Save")
		Me.bt_Save.Name = "bt_Save"
		Me.bt_Save.UseVisualStyleBackColor = true
		AddHandler Me.bt_Save.Click, AddressOf Me.Bt_SaveClick
		'
		'tc_PartyData
		'
		Me.tc_PartyData.Controls.Add(Me.tp_BasicInfo)
		Me.tc_PartyData.Controls.Add(Me.tabPage2)
		resources.ApplyResources(Me.tc_PartyData, "tc_PartyData")
		Me.tc_PartyData.Name = "tc_PartyData"
		Me.tc_PartyData.SelectedIndex = 0
		'
		'tp_BasicInfo
		'
		Me.tp_BasicInfo.Controls.Add(Me.tb_skype)
		Me.tp_BasicInfo.Controls.Add(Me.lb_skype)
		Me.tp_BasicInfo.Controls.Add(Me.lb_comments)
		Me.tp_BasicInfo.Controls.Add(Me.tb_comments)
		Me.tp_BasicInfo.Controls.Add(Me.tb_www)
		Me.tp_BasicInfo.Controls.Add(Me.lb_www)
		Me.tp_BasicInfo.Controls.Add(Me.lb_email)
		Me.tp_BasicInfo.Controls.Add(Me.tb_email)
		Me.tp_BasicInfo.Controls.Add(Me.lb_fax)
		Me.tp_BasicInfo.Controls.Add(Me.lb_mobile)
		Me.tp_BasicInfo.Controls.Add(Me.tb_fax)
		Me.tp_BasicInfo.Controls.Add(Me.tb_mobile)
		Me.tp_BasicInfo.Controls.Add(Me.tb_phone)
		Me.tp_BasicInfo.Controls.Add(Me.lb_phone)
		Me.tp_BasicInfo.Controls.Add(Me.tb_title)
		Me.tp_BasicInfo.Controls.Add(Me.lb_title)
		Me.tp_BasicInfo.Controls.Add(Me.cb_group)
		Me.tp_BasicInfo.Controls.Add(Me.lb_group)
		Me.tp_BasicInfo.Controls.Add(Me.lb_TaxNum)
		Me.tp_BasicInfo.Controls.Add(Me.tb_TaxNum)
		Me.tp_BasicInfo.Controls.Add(Me.tb_RegNum)
		Me.tp_BasicInfo.Controls.Add(Me.lb_RegNum)
		Me.tp_BasicInfo.Controls.Add(Me.lb_LastName)
		Me.tp_BasicInfo.Controls.Add(Me.tb_LastName)
		Me.tp_BasicInfo.Controls.Add(Me.tb_FirstName)
		Me.tp_BasicInfo.Controls.Add(Me.lb_FirstName)
		Me.tp_BasicInfo.Controls.Add(Me.tb_name)
		Me.tp_BasicInfo.Controls.Add(Me.lb_name)
		Me.tp_BasicInfo.Controls.Add(Me.lb_orgType)
		Me.tp_BasicInfo.Controls.Add(Me.cb_orgType)
		Me.tp_BasicInfo.Controls.Add(Me.cb_Active)
		Me.tp_BasicInfo.Controls.Add(Me.tb_Number)
		Me.tp_BasicInfo.Controls.Add(Me.lb_Number)
		Me.tp_BasicInfo.Controls.Add(Me.lb_TypeName)
		Me.tp_BasicInfo.Controls.Add(Me.lb_type)
		resources.ApplyResources(Me.tp_BasicInfo, "tp_BasicInfo")
		Me.tp_BasicInfo.Name = "tp_BasicInfo"
		Me.tp_BasicInfo.UseVisualStyleBackColor = true
		'
		'tb_skype
		'
		resources.ApplyResources(Me.tb_skype, "tb_skype")
		Me.tb_skype.Name = "tb_skype"
		'
		'lb_skype
		'
		resources.ApplyResources(Me.lb_skype, "lb_skype")
		Me.lb_skype.Name = "lb_skype"
		'
		'lb_comments
		'
		resources.ApplyResources(Me.lb_comments, "lb_comments")
		Me.lb_comments.Name = "lb_comments"
		'
		'tb_comments
		'
		resources.ApplyResources(Me.tb_comments, "tb_comments")
		Me.tb_comments.Name = "tb_comments"
		'
		'tb_www
		'
		resources.ApplyResources(Me.tb_www, "tb_www")
		Me.tb_www.Name = "tb_www"
		'
		'lb_www
		'
		resources.ApplyResources(Me.lb_www, "lb_www")
		Me.lb_www.Name = "lb_www"
		'
		'lb_email
		'
		resources.ApplyResources(Me.lb_email, "lb_email")
		Me.lb_email.Name = "lb_email"
		'
		'tb_email
		'
		resources.ApplyResources(Me.tb_email, "tb_email")
		Me.tb_email.Name = "tb_email"
		'
		'lb_fax
		'
		resources.ApplyResources(Me.lb_fax, "lb_fax")
		Me.lb_fax.Name = "lb_fax"
		'
		'lb_mobile
		'
		resources.ApplyResources(Me.lb_mobile, "lb_mobile")
		Me.lb_mobile.Name = "lb_mobile"
		'
		'tb_fax
		'
		resources.ApplyResources(Me.tb_fax, "tb_fax")
		Me.tb_fax.Name = "tb_fax"
		'
		'tb_mobile
		'
		resources.ApplyResources(Me.tb_mobile, "tb_mobile")
		Me.tb_mobile.Name = "tb_mobile"
		'
		'tb_phone
		'
		resources.ApplyResources(Me.tb_phone, "tb_phone")
		Me.tb_phone.Name = "tb_phone"
		'
		'lb_phone
		'
		resources.ApplyResources(Me.lb_phone, "lb_phone")
		Me.lb_phone.Name = "lb_phone"
		'
		'tb_title
		'
		resources.ApplyResources(Me.tb_title, "tb_title")
		Me.tb_title.Name = "tb_title"
		'
		'lb_title
		'
		resources.ApplyResources(Me.lb_title, "lb_title")
		Me.lb_title.Name = "lb_title"
		'
		'cb_group
		'
		Me.cb_group.FormattingEnabled = true
		resources.ApplyResources(Me.cb_group, "cb_group")
		Me.cb_group.Name = "cb_group"
		'
		'lb_group
		'
		resources.ApplyResources(Me.lb_group, "lb_group")
		Me.lb_group.Name = "lb_group"
		'
		'lb_TaxNum
		'
		resources.ApplyResources(Me.lb_TaxNum, "lb_TaxNum")
		Me.lb_TaxNum.Name = "lb_TaxNum"
		'
		'tb_TaxNum
		'
		resources.ApplyResources(Me.tb_TaxNum, "tb_TaxNum")
		Me.tb_TaxNum.Name = "tb_TaxNum"
		'
		'tb_RegNum
		'
		resources.ApplyResources(Me.tb_RegNum, "tb_RegNum")
		Me.tb_RegNum.Name = "tb_RegNum"
		'
		'lb_RegNum
		'
		resources.ApplyResources(Me.lb_RegNum, "lb_RegNum")
		Me.lb_RegNum.Name = "lb_RegNum"
		'
		'lb_LastName
		'
		resources.ApplyResources(Me.lb_LastName, "lb_LastName")
		Me.lb_LastName.Name = "lb_LastName"
		'
		'tb_LastName
		'
		resources.ApplyResources(Me.tb_LastName, "tb_LastName")
		Me.tb_LastName.Name = "tb_LastName"
		'
		'tb_FirstName
		'
		resources.ApplyResources(Me.tb_FirstName, "tb_FirstName")
		Me.tb_FirstName.Name = "tb_FirstName"
		'
		'lb_FirstName
		'
		resources.ApplyResources(Me.lb_FirstName, "lb_FirstName")
		Me.lb_FirstName.Name = "lb_FirstName"
		'
		'tb_name
		'
		resources.ApplyResources(Me.tb_name, "tb_name")
		Me.tb_name.Name = "tb_name"
		'
		'lb_name
		'
		resources.ApplyResources(Me.lb_name, "lb_name")
		Me.lb_name.Name = "lb_name"
		'
		'lb_orgType
		'
		resources.ApplyResources(Me.lb_orgType, "lb_orgType")
		Me.lb_orgType.Name = "lb_orgType"
		'
		'cb_orgType
		'
		Me.cb_orgType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cb_orgType.FormattingEnabled = true
		resources.ApplyResources(Me.cb_orgType, "cb_orgType")
		Me.cb_orgType.Name = "cb_orgType"
		'
		'cb_Active
		'
		resources.ApplyResources(Me.cb_Active, "cb_Active")
		Me.cb_Active.Name = "cb_Active"
		Me.cb_Active.UseVisualStyleBackColor = true
		'
		'tb_Number
		'
		resources.ApplyResources(Me.tb_Number, "tb_Number")
		Me.tb_Number.Name = "tb_Number"
		'
		'lb_Number
		'
		resources.ApplyResources(Me.lb_Number, "lb_Number")
		Me.lb_Number.Name = "lb_Number"
		'
		'lb_TypeName
		'
		resources.ApplyResources(Me.lb_TypeName, "lb_TypeName")
		Me.lb_TypeName.Name = "lb_TypeName"
		'
		'lb_type
		'
		resources.ApplyResources(Me.lb_type, "lb_type")
		Me.lb_type.Name = "lb_type"
		'
		'tabPage2
		'
		resources.ApplyResources(Me.tabPage2, "tabPage2")
		Me.tabPage2.Name = "tabPage2"
		Me.tabPage2.UseVisualStyleBackColor = true
		'
		'pz_PartyEdit
		'
		resources.ApplyResources(Me, "$this")
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Controls.Add(Me.tc_PartyData)
		Me.Controls.Add(Me.gb_Menu)
		Me.Controls.Add(Me.pb_logo)
		Me.Name = "pz_PartyEdit"
		CType(Me.pb_logo,System.ComponentModel.ISupportInitialize).EndInit
		Me.gb_Menu.ResumeLayout(false)
		Me.tc_PartyData.ResumeLayout(false)
		Me.tp_BasicInfo.ResumeLayout(false)
		Me.tp_BasicInfo.PerformLayout
		Me.ResumeLayout(false)
	End Sub
	Private lb_skype As System.Windows.Forms.Label
	Private tb_skype As System.Windows.Forms.TextBox
	Private tb_comments As System.Windows.Forms.TextBox
	Private lb_comments As System.Windows.Forms.Label
	Private lb_fax As System.Windows.Forms.Label
	Private tb_email As System.Windows.Forms.TextBox
	Private lb_email As System.Windows.Forms.Label
	Private lb_www As System.Windows.Forms.Label
	Private tb_www As System.Windows.Forms.TextBox
	Private lb_phone As System.Windows.Forms.Label
	Private tb_phone As System.Windows.Forms.TextBox
	Private tb_mobile As System.Windows.Forms.TextBox
	Private tb_fax As System.Windows.Forms.TextBox
	Private lb_mobile As System.Windows.Forms.Label
	Private lb_title As System.Windows.Forms.Label
	Private tb_title As System.Windows.Forms.TextBox
	Private lb_group As System.Windows.Forms.Label
	Private cb_group As System.Windows.Forms.ComboBox
	Private lb_RegNum As System.Windows.Forms.Label
	Private tb_RegNum As System.Windows.Forms.TextBox
	Private lb_TaxNum As System.Windows.Forms.Label
	Private tb_TaxNum As System.Windows.Forms.TextBox
	Private tabPage2 As System.Windows.Forms.TabPage
	Private lb_type As System.Windows.Forms.Label
	Private lb_TypeName As System.Windows.Forms.Label
	Private lb_Number As System.Windows.Forms.Label
	Private tb_Number As System.Windows.Forms.TextBox
	Private cb_Active As System.Windows.Forms.CheckBox
	Private cb_orgType As System.Windows.Forms.ComboBox
	Private lb_orgType As System.Windows.Forms.Label
	Private lb_name As System.Windows.Forms.Label
	Private tb_name As System.Windows.Forms.TextBox
	Private lb_FirstName As System.Windows.Forms.Label
	Private tb_FirstName As System.Windows.Forms.TextBox
	Private tb_LastName As System.Windows.Forms.TextBox
	Private lb_LastName As System.Windows.Forms.Label
	Private tp_BasicInfo As System.Windows.Forms.TabPage
	Private tc_PartyData As System.Windows.Forms.TabControl
	Private bt_Save As System.Windows.Forms.Button
	Private gb_Menu As System.Windows.Forms.GroupBox
	Private pb_logo As System.Windows.Forms.PictureBox
End Class
