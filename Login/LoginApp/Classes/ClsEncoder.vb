Imports System.Text
Public Class ClsEncoder
    Public Shared Function Encrypter(User As String, Pass As String) As String
        Dim Encoder As New UnicodeEncoding()
        Dim EncodeToBytes() As Byte = Encoder.GetBytes(User & Pass)
        Dim ByteEncrypter As New System.Security.Cryptography.SHA256Managed()
        Dim Encrypted() As Byte = ByteEncrypter.ComputeHash(EncodeToBytes)
        Return Convert.ToBase64String(Encrypted)
    End Function

End Class
