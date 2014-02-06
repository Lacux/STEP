'
' Created by SharpDevelop.
' User: peterelv
' Date: 05.01.2014 20:37
' Module: FND - Basic Module
' Version: 1.0 
' Description: Global variables  
' 
' 
'
Public Module fnd_AppData
	Public G_APPS_NAME As String = "STEP"
	Public G_APPS_VERS As String = "0.9.0"
	Public G_DB_VERS   As String = "1.0.0"
	Public G_APPS_LANG As String = "lv"
	Public G_DB_LOCATION As String
	Public G_DB_HOST As String
	Public G_DB_NAME As String = "APPSTEP"
	Public G_DB_PSW As String = "gF196dhV"
	Public G_APP_DB_NAME As String
	Public G_DB_SV_TYPE As String
	Public G_DB_ClientLibrary As String = "\FbDataBase\FbEmbed\fbembed.dll"
	Public G_US_NAME As String
	Public G_FND_VALID As Integer = 0
	
End Module
