'
' Created by SharpDevelop.
' User: peterelv
' Date: 29.01.2014 21:44
' Module: PZ - Partner module (party)
' Version: 1.0
' Description: Filter/Find existing Partners
' 
' 
'
Imports System.IO
Imports System.Data
Imports System.String
Imports System.Resources
Imports FirebirdSql.Data.FirebirdClient
Imports System.IO.FileNotFoundException
Public Partial Class pz_partyList
	Dim FBDSTYPES As New DataSet
	Dim MsgTranslFND As New ResourceManager("STEP.resFNDMessages", GetType(fnd_Connections).Assembly)	
	Dim MsgTransl As New ResourceManager("STEP.resPZMessages", GetType(fnd_Connections).Assembly)	
	Public Sub New()
		' The Me.InitializeComponent call is required for Windows Forms designer support.
		Me.InitializeComponent()
		
		' Load pictures
		Try
			Me.pb_logo.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\Search_PZ_64.png")
			Me.bt_Find.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\Search_PZ_32.png")
			Me.bt_New.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\New_PZ_32.png")
			Me.bt_Clear.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\Clean_PZ_32.png")
			Me.bt_Reports.Image = Image.FromFile(Directory.GetCurrentDirectory.ToString & "\APP\PZ\Images\Reports_PZ_32.png")
		Catch ex As System.IO.FileNotFoundException
			MessageBox.Show(MsgTranslFND.GetString("strMissingPics") + ex.Message, MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
		End Try
		
		Me.LoadPZType()
		Me.LoadNewPZMenu()
	End Sub
	
	Sub Bt_FindClick(sender As Object, e As EventArgs)
		Dim P_PARTY_TYPE As String
		Try
			P_PARTY_TYPE = Me.cb_type.SelectedValue.ToString
		Catch ex As NullReferenceException
			P_PARTY_TYPE = Nothing
		End Try
		Using FBDS As New DataSet
			Try
				Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
					conn.Open			
					Using command As New FbCommand("SELECT * FROM PRO_PZ_PARTIES(@P_ACTION, @P_PARTY_ID, @P_PARTY_NUMBER, @P_PARTY_TYPE, @P_PARTY_ORG_ID, @P_PARTY_NAME, @P_TAX_REFERENCE, " & _
						"@P_REG_REFERENCE, @P_PERSON_FIRST_NAME, @P_PERSON_LAST_NAME, @P_PARTY_GROUP_NAME, @P_COMMENTS, @P_STATUS_FLAG, " & _
						"@P_PARTY_TITLE, @P_PHONE_NUMBER, @P_FAX_NUMBER, @P_MOBILE_NUMBER, @P_EMAIL, @P_WWW, @P_SKYPE)", conn)
						command.Parameters.AddWithValue("@P_ACTION", 4)
						command.Parameters.AddWithValue("@P_PARTY_ID", Nothing)
						command.Parameters.AddWithValue("@P_PARTY_NUMBER",Nothing)
						command.Parameters.AddWithValue("@P_PARTY_TYPE",P_PARTY_TYPE)
						command.Parameters.AddWithValue("@P_PARTY_ORG_ID",Nothing)
						command.Parameters.AddWithValue("@P_PARTY_NAME",Me.tb_Name.Text)
						command.Parameters.AddWithValue("@P_TAX_REFERENCE",Nothing)
						command.Parameters.AddWithValue("@P_REG_REFERENCE",Me.tb_RegReference.text)
						command.Parameters.AddWithValue("@P_PERSON_FIRST_NAME",Nothing)
						command.Parameters.AddWithValue("@P_PERSON_LAST_NAME",Nothing)
						command.Parameters.AddWithValue("@P_PARTY_GROUP_NAME",Me.tb_Group.Text)
						command.Parameters.AddWithValue("@P_COMMENTS",Nothing)
						command.Parameters.AddWithValue("@P_STATUS_FLAG", Me.cb_Active.CheckState)
						command.Parameters.AddWithValue("@P_PARTY_TITLE",Nothing)
						command.Parameters.AddWithValue("@P_PHONE_NUMBER",Nothing)
						command.Parameters.AddWithValue("@P_FAX_NUMBER",Nothing)
						command.Parameters.AddWithValue("@P_MOBILE_NUMBER",Nothing)
						command.Parameters.AddWithValue("@P_EMAIL",Nothing)
						command.Parameters.AddWithValue("@P_WWW",Nothing)
						command.Parameters.AddWithValue("@P_SKYPE",Nothing)
						
						Using FbAdapterLIST As New FbDataAdapter(command)
							FbAdapterLIST.Fill( FBDS, "PZ_PARTY_LIST")
							If FBDS.Tables("PZ_PARTY_LIST").Rows.Count > 0 Then
								If CType(FBDS.Tables("PZ_PARTY_LIST").Rows(0).Item(0), String) = "propzpartyerr0" Then
								Me.dgv_partnerList.AutoGenerateColumns = False
								Me.PARTY_ID.DataPropertyName = "R_PARTY_ID"
								Me.PARTY_NUMBER.DataPropertyName = "R_PARTY_NUMBER"
								Me.PARTY_TYPE.DataPropertyName = "R_PARTY_TYPE"
								Me.PARTY_TYPE_NAME.DataPropertyName = "R_PARTY_TYPE_NAME"
								Me.PARTY_ORG_NAME.DataPropertyName = "R_PARTY_ORG_NAME"
								Me.PARTY_NAME.DataPropertyName = "R_PARTY_NAME"
								Me.REG_REFERENCE.DataPropertyName = "R_REG_REFERENCE"
								Me.TAX_REFERENCE.DataPropertyName = "R_TAX_REFERENCE"
								Me.PARTY_GROUP_NAME.DataPropertyName = "R_PARTY_GROUP_NAME"
								Me.STATUS_FLAG.DataPropertyName = "R_STATUS_FLAG"
								Me.dgv_partnerList.DataSource = FBDS
								Me.dgv_partnerList.DataMember = "PZ_PARTY_LIST"
								Else
								MessageBox.Show(MsgTransl.GetString(CType(FBDS.Tables("PZ_PARTY_LIST").Rows(0).Item(0), String)), _
									MsgTranslFND.GetString("strWarning"), MessageBoxButtons.OK, MessageBoxIcon.Warning, _
									MessageBoxDefaultButton.Button1)
								End If
							Else
								Me.dgv_partnerList.DataSource = Nothing
							End if
						End Using
					End Using
					conn.Close
				End Using
			Catch ex As FbException
				MessageBox.Show(MsgTranslFND.GetString("strError") & ex.Message)
			End Try
		End Using	
	End Sub
	
	Sub Bt_ClearClick(sender As Object, e As EventArgs)
		Me.cb_type.SelectedValue = -1
		Me.tb_Name.Text = ""
		Me.tb_RegReference.Text = ""
		Me.tb_Group.Text = ""
		Me.dgv_partnerList.DataSource = Nothing
	End Sub
	
	Sub LoadPZType
		Try
			Using conn As New FbConnection(clsFNDDatabase.GetConnString.ToString)
				conn.Open			
				Using command As New FbCommand("SELECT * FROM PRO_PZ_TYPES (@P_ACTION, @P_TYPE_ID, @P_TYPE_SHT, @P_TYPE_NAME, " & _
					"@P_TYPE_OBJECT, @P_TYPE_OBJ_DATA, @P_TYPE_SOURCE, @P_TYPE_STATUS, @P_RELATED_TYPE_SHT)", conn)
					command.Parameters.AddWithValue("@P_ACTION", 0)
					command.Parameters.AddWithValue("@P_TYPE_ID", Nothing)
					command.Parameters.AddWithValue("@P_TYPE_SHT",Nothing)
					command.Parameters.AddWithValue("@P_TYPE_NAME",Nothing)
					command.Parameters.AddWithValue("@P_TYPE_OBJECT","PZ_PARTIES_ALL")
					command.Parameters.AddWithValue("@P_TYPE_OBJ_DATA","PARTY_TYPE_ID")
					command.Parameters.AddWithValue("@P_TYPE_SOURCE",Nothing)
					command.Parameters.AddWithValue("@P_TYPE_STATUS",1)
					command.Parameters.AddWithValue("@P_RELATED_TYPE_SHT","SYS")
					
					Using FbAdapterTYPES As New FbDataAdapter(command)
						FbAdapterTYPES.Fill( FBDSTYPES, "PZ_PARTY_TYPES")
						If Me.FBDSTYPES.Tables("PZ_PARTY_TYPES").Rows.Count > 0 Then
							Me.cb_type.ValueMember = "R_TYPE_SHT"
							Me.cb_type.DisplayMember = "R_TYPE_NAME" 
							Me.cb_type.DataSource = FBDSTYPES.Tables("PZ_PARTY_TYPES")
							Me.cb_type.SelectedValue = -1
						End if
					End Using
				End Using
				conn.Close
			End Using
		Catch ex As FbException
			MessageBox.Show(MsgTranslFND.GetString("strError") & ex.Message)
		End try
		
	End Sub
	
	Sub LoadNewPZMenu
		For Each row As DataRow In FBDSTYPES.Tables("PZ_PARTY_TYPES").Rows
			Dim mnuitm As New ToolStripMenuItem
			mnuitm.Name = "mi_" & row.Item("R_TYPE_SHT").ToString
			mnuitm.Text = row.Item("R_TYPE_NAME").ToString
			mnuitm.Tag  = row.Item("R_TYPE_SHT").ToString
			AddHandler mnuitm.Click, AddressOf Me.OpenNewPZ
			Me.cms_newPZ.Items.Add(mnuitm)
		Next
	End Sub
	
	Sub Bt_NewClick(sender As Object, e As EventArgs)
		Me.cms_newPZ.Show(Me.bt_New, 0, Me.bt_New.Height)
	End Sub
	
	Sub OpenNewPZ(ByVal sender As Object, ByVal e As System.EventArgs)
		Dim action As ToolStripMenuItem
		action = CType(sender, ToolStripMenuItem)
		Dim S_PARTYID As Integer
		Dim S_PARTYTYPE As String
		Dim S_PARTYTYPENAME As String
		S_PARTYID = Nothing
		S_PARTYTYPE = action.Tag.ToString
		S_PARTYTYPENAME = action.Text.ToString
		Dim oForm As New pz_PartyEdit(S_PARTYID, S_PARTYTYPE, S_PARTYTYPENAME)
		oForm.MdiParent = fnd_MainForm
		oForm.Show()
		oForm = Nothing  		
	End Sub
	
	
	Sub Dgv_partnerListDoubleClick(sender As Object, e As EventArgs)
		Dim S_PARTYID As Integer
		Dim S_PARTYTYPE As String
		Dim S_PARTYTYPENAME As String
		S_PARTYID = CType(Me.dgv_partnerList.CurrentRow.Cells("PARTY_ID").Value, Integer)
		S_PARTYTYPE = CType(Me.dgv_partnerList.CurrentRow.Cells("PARTY_TYPE").Value, String)
		S_PARTYTYPENAME = CType(Me.dgv_partnerList.CurrentRow.Cells("PARTY_TYPE_NAME").Value, String)
		Dim oForm As New pz_PartyEdit(S_PARTYID, S_PARTYTYPE, S_PARTYTYPENAME)
		oForm.MdiParent = fnd_MainForm
		oForm.Show()
		oForm = Nothing  
	End Sub
End Class
