'
' Created by SharpDevelop.
' User: peterelv
' Date: 04.01.2014 23:19
' Module: FND - Basic Module
' Version: 1.0
' Description: MD5 Class Security.Cryptography
' 
' 
'

Imports System.Security.Cryptography
Imports System.Text

Public Class clsFNDMD5
	Shared Function GetMd5Hash(ByVal md5Hash As MD5, input As String) As String 

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer 
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function 'GetMd5Hash
        
End Class
