'
' Created by SharpDevelop.
' User: peterelv
' Date: 31.01.2014 21:44
' Module: PZ - Partner module (party)
' Version: 1.0
' Description: Add/Edit existing Partners
' 
' 
'
Imports System.IO
Imports System.Data
Imports System.Resources
Imports FirebirdSql.Data.FirebirdClient

Public Partial Class pz_PartyEdit
	Dim p_party_id As Integer
	Dim p_party_type As String
	Dim p_party_type_name As String
	Dim p_action As Integer
	Dim FBDS As New DataSet
	Dim MsgTranslFND As New ResourceManager("STEP.resFNDMessages", GetType(fnd_Connections).Assembly)	
	Dim MsgTransl As New ResourceManager("STEP.resPZMessages", GetType(fnd_Connections).Assembly)
	
	Public Sub New(byval S_PARTYID As Integer, S_PARTYTYPE As String, S_PARTYTYPENAME As String)
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		' Receive provided data
		Me.p_party_id = S_PARTYID
		Me.p_party_type = S_PARTYTYPE
		Me.p_party_type_name = S_PARTYTYPENAME 
		If Me.p_party_id = Nothing Then
			p_action = 0
		Else
			p_action = 1
		End If
		' Load pictures
		Try
			Me.bt_Save.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\Save_PZ_32.png")
		Catch ex As System.IO.FileNotFoundException
			MessageBox.Show(MsgTranslFND.GetString("strMissingPics") + ex.Message, MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		End Try		
		' Load form data based on provided data
		Me.AjustForm()
		Me.LoadBasicData()
		Me.LoadPzTypes()
	End Sub
	
	Sub AjustForm
		Me.lb_TypeName.Text = Me.p_party_type_name
		
		If Me.p_party_type = "PAJ" Then
			Me.lb_FirstName.Visible = False
			Me.tb_FirstName.Visible = False
			Me.lb_LastName.Visible = False
			Me.tb_LastName.Visible = False
			Me.lb_name.Visible = True
			Me.tb_name.Visible = True
			Me.lb_group.Visible = True
			Me.cb_group.Visible = True
			Me.lb_title.Visible = False
			Me.tb_title.Visible = False
			Me.lb_TaxNum.Visible = True
			Me.tb_TaxNum.Visible = True
			Me.lb_RegNum.Text = MsgTransl.GetString("strPartyEditReg1") 
		Else
			Me.lb_FirstName.Visible = True
			Me.tb_FirstName.Visible = True
			Me.lb_LastName.Visible = True
			Me.tb_LastName.Visible = True
			Me.lb_name.Visible = False
			Me.tb_name.Visible = False
			Me.lb_group.Visible = False
			Me.cb_group.Visible = False
			Me.lb_title.Visible = True
			Me.tb_title.Visible = True
			Me.lb_TaxNum.Visible = False
			Me.tb_TaxNum.Visible = False
			Me.lb_RegNum.Text = MsgTransl.GetString("strPartyEditReg2") 
		End If
		
		If  p_action = 0 Then
			' New party
			' Load pictures
			Try
				Me.pb_logo.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\New_PZ_64.png")
			Catch ex As System.IO.FileNotFoundException
				MessageBox.Show(MsgTranslFND.GetString("strMissingPics") + ex.Message, MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
			End Try
			Me.Text = MsgTransl.GetString("strPartyEditNew") 
		Else
			' Editting party
			' Load pictures
			Try
				Me.pb_logo.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\Edit_PZ_64.png")
			Catch ex As System.IO.FileNotFoundException
				MessageBox.Show(MsgTranslFND.GetString("strMissingPics") + ex.Message, MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
			End Try
			Me.Text = MsgTransl.GetString("strPartyEditEdit") 
		End If
		
	End Sub
	
	Sub LoadBasicData
		Try
			Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
				conn.Open			
				Using command As New FbCommand("SELECT * FROM PRO_PZ_PARTIES(@P_ACTION, @P_PARTY_ID, @P_PARTY_NUMBER, @P_PARTY_TYPE, @P_PARTY_ORG_ID, @P_PARTY_NAME, @P_TAX_REFERENCE, " & _
					"@P_REG_REFERENCE, @P_PERSON_FIRST_NAME, @P_PERSON_LAST_NAME, @P_PARTY_GROUP_NAME, @P_COMMENTS, @P_STATUS_FLAG, " & _
					"@P_PARTY_TITLE, @P_PHONE_NUMBER, @P_FAX_NUMBER, @P_MOBILE_NUMBER, @P_EMAIL, @P_WWW, @P_SKYPE)", conn)
					command.Parameters.AddWithValue("@P_ACTION", 0)
					command.Parameters.AddWithValue("@P_PARTY_ID", Me.p_party_id)
					command.Parameters.AddWithValue("@P_PARTY_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_PARTY_TYPE",Me.p_party_type)
					command.Parameters.AddWithValue("@P_PARTY_ORG_ID",Nothing)
					command.Parameters.AddWithValue("@P_PARTY_NAME",Nothing)
					command.Parameters.AddWithValue("@P_TAX_REFERENCE",Nothing)
					command.Parameters.AddWithValue("@P_REG_REFERENCE",Nothing)
					command.Parameters.AddWithValue("@P_PERSON_FIRST_NAME",Nothing)
					command.Parameters.AddWithValue("@P_PERSON_LAST_NAME",Nothing)
					command.Parameters.AddWithValue("@P_PARTY_GROUP_NAME",Nothing)
					command.Parameters.AddWithValue("@P_COMMENTS",Nothing)
					command.Parameters.AddWithValue("@P_STATUS_FLAG", Nothing)
					command.Parameters.AddWithValue("@P_PARTY_TITLE",Nothing)
					command.Parameters.AddWithValue("@P_PHONE_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_FAX_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_MOBILE_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_EMAIL",Nothing)
					command.Parameters.AddWithValue("@P_WWW",Nothing)
					command.Parameters.AddWithValue("@P_SKYPE",Nothing)
					
					Using FbAdapterLIST As New FbDataAdapter(command)
						If Me.FBDS.Tables.IndexOf("PZ_PARTY_DATA") >-1 Then
							FBDS.Tables("PZ_PARTY_DATA").Clear	
						End if
						FbAdapterLIST.Fill( FBDS, "PZ_PARTY_DATA")
						If CType(FBDS.Tables("PZ_PARTY_DATA").Rows(0).Item(0), String) = "propzpartyerr0" Then
							Me.p_party_id = CType(FBDS.Tables("PZ_PARTY_DATA").Rows(0).Item(1), Integer)
							Me.tb_Number.DataBindings.Clear
							Me.tb_Number.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PARTY_NUMBER")
							Me.cb_Active.DataBindings.Clear
							Me.cb_Active.DataBindings.Add("Checked", Me.FBDS, "PZ_PARTY_DATA.R_STATUS_FLAG")				
							Me.tb_name.DataBindings.Clear
							Me.tb_name.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PARTY_NAME")				
							Me.tb_FirstName.DataBindings.Clear
							Me.tb_FirstName.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PERSON_FIRST_NAME")				
							Me.tb_LastName.DataBindings.Clear
							Me.tb_LastName.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PERSON_LAST_NAME")				
							Me.tb_TaxNum.DataBindings.Clear
							Me.tb_TaxNum.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_TAX_REFERENCE")
							Me.tb_RegNum.DataBindings.Clear
							Me.tb_RegNum.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_REG_REFERENCE")
							Me.cb_group.DataBindings.Clear
							Me.cb_group.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PARTY_GROUP_NAME")
							Me.tb_comments.DataBindings.Clear
							Me.tb_comments.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_COMMENTS")
							Me.tb_title.DataBindings.Clear
							Me.tb_title.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PARTY_TITLE")
							Me.tb_phone.DataBindings.Clear
							Me.tb_phone.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_PHONE_NUMBER")
							Me.tb_fax.DataBindings.Clear
							Me.tb_fax.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_FAX_NUMBER")
							Me.tb_mobile.DataBindings.Clear
							Me.tb_mobile.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_MOBILE_NUMBER")	
							Me.tb_email.DataBindings.Clear
							Me.tb_email.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_EMAIL")	
							Me.tb_www.DataBindings.Clear
							Me.tb_www.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_WWW")	
							Me.tb_skype.DataBindings.Clear
							Me.tb_skype.DataBindings.Add("Text", Me.FBDS, "PZ_PARTY_DATA.R_SKYPE")	
						Else
							MessageBox.Show(MsgTransl.GetString(CType(FBDS.Tables("PZ_PARTY_DATA").Rows(0).Item(0), String)), _
								MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, _
								MessageBoxDefaultButton.Button1)
						End If
					End Using
				End Using
				conn.Close
			End Using
			
		Catch ex As FbException
			MessageBox.Show(MsgTranslFND.GetString("strError") & ex.Message)
		End Try
	End Sub
	
	Sub LoadPzTypes
		Dim l_action As Integer
		If  p_action = 0 Then
			l_action = 0
		Else
			l_action = 1
		End If
		Try
			Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
				conn.Open			
				Using command As New FbCommand("SELECT * FROM PRO_PZ_TYPES (@P_ACTION, @P_TYPE_ID, @P_TYPE_SHT, @P_TYPE_NAME, " & _
					"@P_TYPE_OBJECT, @P_TYPE_OBJ_DATA, @P_TYPE_SOURCE, @P_TYPE_STATUS, @P_RELATED_TYPE_SHT)", conn)
					command.Parameters.AddWithValue("@P_ACTION", l_action )
					command.Parameters.AddWithValue("@P_TYPE_ID", Nothing)
					command.Parameters.AddWithValue("@P_TYPE_SHT",Nothing)
					command.Parameters.AddWithValue("@P_TYPE_NAME",Nothing)
					command.Parameters.AddWithValue("@P_TYPE_OBJECT","PZ_PARTIES_ALL")
					command.Parameters.AddWithValue("@P_TYPE_OBJ_DATA","PARTY_ORG_ID")
					command.Parameters.AddWithValue("@P_TYPE_SOURCE",Nothing)
					command.Parameters.AddWithValue("@P_TYPE_STATUS",1)
					command.Parameters.AddWithValue("@P_RELATED_TYPE_SHT",Me.p_party_type)
					
					Using FbAdapterTYPES As New FbDataAdapter(command)
						If Me.FBDS.Tables.IndexOf("PZ_PARTY_TYPES") >-1 Then
							FBDS.Tables("PZ_PARTY_TYPES").Clear
						End if
						FbAdapterTYPES.Fill( FBDS, "PZ_PARTY_TYPES")
						Me.cb_orgType.DataBindings.Clear
						Me.cb_orgType.ValueMember = "R_TYPE_ID"
						Me.cb_orgType.DisplayMember = "R_TYPE_SHT" 
						Me.cb_orgType.DataSource = FBDS.Tables("PZ_PARTY_TYPES")
						Me.cb_orgType.DataBindings.Add("SelectedValue", Me.FBDS, "PZ_PARTY_DATA.R_PARTY_ORG_ID")
					End Using
				End Using
				conn.Close
			End Using
		Catch ex As FbException
			MessageBox.Show(MsgTranslFND.GetString("strError") & ex.Message)
		End try
	End Sub
	
	
	
	Sub Bt_SaveClick(sender As Object, e As EventArgs)
		Try
			Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
				conn.Open			
				Using command As New FbCommand("SELECT * FROM PRO_PZ_PARTIES(@P_ACTION, @P_PARTY_ID, @P_PARTY_NUMBER, @P_PARTY_TYPE, @P_PARTY_ORG_ID, @P_PARTY_NAME, @P_TAX_REFERENCE, " & _
					"@P_REG_REFERENCE, @P_PERSON_FIRST_NAME, @P_PERSON_LAST_NAME, @P_PARTY_GROUP_NAME, @P_COMMENTS, @P_STATUS_FLAG, " & _
					"@P_PARTY_TITLE, @P_PHONE_NUMBER, @P_FAX_NUMBER, @P_MOBILE_NUMBER, @P_EMAIL, @P_WWW, @P_SKYPE)", conn)
					command.Parameters.AddWithValue("@P_ACTION", 3)
					command.Parameters.AddWithValue("@P_PARTY_ID", Me.p_party_id)
					command.Parameters.AddWithValue("@P_PARTY_NUMBER", Nothing)
					command.Parameters.AddWithValue("@P_PARTY_TYPE",Me.p_party_type)
					command.Parameters.AddWithValue("@P_PARTY_ORG_ID",Nothing)
					command.Parameters.AddWithValue("@P_PARTY_NAME",Me.tb_name.Text)
					command.Parameters.AddWithValue("@P_TAX_REFERENCE",Nothing)
					command.Parameters.AddWithValue("@P_REG_REFERENCE",Me.tb_RegNum.Text)
					command.Parameters.AddWithValue("@P_PERSON_FIRST_NAME",Me.tb_FirstName.Text)
					command.Parameters.AddWithValue("@P_PERSON_LAST_NAME",Me.tb_LastName.Text)
					command.Parameters.AddWithValue("@P_PARTY_GROUP_NAME",Nothing)
					command.Parameters.AddWithValue("@P_COMMENTS",Nothing)
					command.Parameters.AddWithValue("@P_STATUS_FLAG", Nothing)
					command.Parameters.AddWithValue("@P_PARTY_TITLE",Nothing)
					command.Parameters.AddWithValue("@P_PHONE_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_FAX_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_MOBILE_NUMBER",Nothing)
					command.Parameters.AddWithValue("@P_EMAIL",Nothing)
					command.Parameters.AddWithValue("@P_WWW",Nothing)
					command.Parameters.AddWithValue("@P_SKYPE",Nothing)
					Using FbAdapterLIST As New FbDataAdapter(command)
						If Me.FBDS.Tables.IndexOf("PZ_PARTY_VALID") >-1 Then
							FBDS.Tables("PZ_PARTY_VALID").Clear	
						End if
						FbAdapterLIST.Fill( FBDS, "PZ_PARTY_VALID")
						If Me.FBDS.Tables("PZ_PARTY_VALID").Rows.Count > 0 Then
							Dim result = MessageBox.Show(MsgTransl.GetString(CType(FBDS.Tables("PZ_PARTY_VALID").Rows(0).Item(0), String)) & vbNewLine & _
								MsgTransl.GetString("strPartyEditType") & CType(FBDS.Tables("PZ_PARTY_VALID").Rows(0).Item(7), String) & vbNewLine & _
								MsgTransl.GetString("strPartyEditName") & CType(FBDS.Tables("PZ_PARTY_VALID").Rows(0).Item(6), String) & vbNewLine & _
								MsgTransl.GetString("strPartyEditReg") & CType(FBDS.Tables("PZ_PARTY_VALID").Rows(0).Item(9), String) & vbNewLine & _
								MsgTransl.GetString("strPartyEditCont"), MsgTranslFND.GetString("strWarning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, _
								MessageBoxDefaultButton.Button1)
							If result = DialogResult.Yes Then
								Me.SavePartyData()
							End If
						Else
							Me.SavePartyData()
						End If
					End Using
				End Using
				conn.Close
			End Using
			
		Catch ex As FbException
			MessageBox.Show(MsgTranslFND.GetString("strError") & ex.Message)
		End Try		
	End Sub
	
	Sub SavePartyData
		Dim l_action As Integer
		If  p_action = 0 Then
			l_action = 1
		Else
			l_action = 2
		End If 
		Try
			Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
				conn.Open			
				Using command As New FbCommand("SELECT * FROM PRO_PZ_PARTIES(@P_ACTION, @P_PARTY_ID, @P_PARTY_NUMBER, @P_PARTY_TYPE, @P_PARTY_ORG_ID, @P_PARTY_NAME, @P_TAX_REFERENCE, " & _
					"@P_REG_REFERENCE, @P_PERSON_FIRST_NAME, @P_PERSON_LAST_NAME, @P_PARTY_GROUP_NAME, @P_COMMENTS, @P_STATUS_FLAG, " & _
					"@P_PARTY_TITLE, @P_PHONE_NUMBER, @P_FAX_NUMBER, @P_MOBILE_NUMBER, @P_EMAIL, @P_WWW, @P_SKYPE)", conn)
					command.Parameters.AddWithValue("@P_ACTION", l_action)
					command.Parameters.AddWithValue("@P_PARTY_ID", Me.p_party_id)
					command.Parameters.AddWithValue("@P_PARTY_NUMBER",Me.tb_Number.Text)
					command.Parameters.AddWithValue("@P_PARTY_TYPE",Me.p_party_type)
					command.Parameters.AddWithValue("@P_PARTY_ORG_ID",Me.cb_orgType.SelectedValue)
					command.Parameters.AddWithValue("@P_PARTY_NAME",Me.tb_name.Text)
					command.Parameters.AddWithValue("@P_TAX_REFERENCE",Me.tb_TaxNum.Text)
					command.Parameters.AddWithValue("@P_REG_REFERENCE",Me.tb_RegNum.Text)
					command.Parameters.AddWithValue("@P_PERSON_FIRST_NAME",Me.tb_FirstName.Text)
					command.Parameters.AddWithValue("@P_PERSON_LAST_NAME",Me.tb_LastName.Text)
					command.Parameters.AddWithValue("@P_PARTY_GROUP_NAME",Me.cb_group.SelectedText)
					command.Parameters.AddWithValue("@P_COMMENTS",Me.tb_comments.Text)
					command.Parameters.AddWithValue("@P_STATUS_FLAG", Me.cb_Active.Checked)
					command.Parameters.AddWithValue("@P_PARTY_TITLE",Me.tb_title.Text)
					command.Parameters.AddWithValue("@P_PHONE_NUMBER",Me.tb_phone.Text)
					command.Parameters.AddWithValue("@P_FAX_NUMBER",Me.tb_fax.Text)
					command.Parameters.AddWithValue("@P_MOBILE_NUMBER",Me.tb_mobile.Text)
					command.Parameters.AddWithValue("@P_EMAIL",Me.tb_email.Text)
					command.Parameters.AddWithValue("@P_WWW",Me.tb_www.Text)
					command.Parameters.AddWithValue("@P_SKYPE",Me.tb_skype.Text)
					Using FbAdapterLIST As New FbDataAdapter(command)
						If Me.FBDS.Tables.IndexOf("PZ_PARTY_DATA_TMP") >-1 Then
							FBDS.Tables("PZ_PARTY_DATA_TMP").Clear	
						End if
						FbAdapterLIST.Fill( FBDS, "PZ_PARTY_DATA_TMP")
						If CType(FBDS.Tables("PZ_PARTY_DATA_TMP").Rows(0).Item(0), String) = "propzpartyerr0" Then
							Me.p_party_id = CType(FBDS.Tables("PZ_PARTY_DATA_TMP").Rows(0).Item(1), Integer)
							Me.p_action = 1
							Me.AjustForm()
							Me.LoadBasicData()
							Me.LoadPzTypes()
						Else
							MessageBox.Show(MsgTransl.GetString(CType(FBDS.Tables("PZ_PARTY_DATA_TMP").Rows(0).Item(0), String)), _
								MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, _
								MessageBoxDefaultButton.Button1)
						End If
					End Using
				End Using
				conn.Close
			End Using
			
		Catch ex As FbException
			MessageBox.Show(MsgTranslFND.GetString("strError") & ex.Message)
		End Try
	End Sub
End Class
