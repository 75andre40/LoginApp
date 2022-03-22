Imports System.Text
Imports System.Data.SqlClient

Public Class ClsSqlData
    'Connections'
    Public Shared ConnServer As String
    Public Shared ConnDatabase As String
    Public Shared ConnETLA As SqlConnection = New SqlConnection("Data Source=B450m;Initial Catalog=I2021_esiandco2;Integrated Security=True;")
    'Connections'

    Public Shared SQLConnect As SqlConnection = New SqlConnection(ConnETLA.ConnectionString)
    Public Shared SQLCommand As SqlCommand
    Public Shared SQLReader As SqlDataReader
    Public Shared SQL As String
    Public Shared SQLP As String
    Public Shared SQLResult As String

    Public Shared Sub SaveDataConnect(SQL As String)

        Try
            SQLConnect.Open()
            SQLCommand = New SqlCommand
            With SQLCommand
                .Connection = SQLConnect
                .CommandText = SQL
                SQLResult = .ExecuteNonQuery()
            End With
            If SQLResult > 0 Then
                MsgBox("You are now registered!", Title:=FrmLogin.BoxTitle)
                ClsVisuals.StartVisible(True)
                ClsVisuals.LoginVisible(False)
                ClsVisuals.RegisterVisible(False)
            End If

        Catch ex As Exception
            MsgBox("An error has occurred. Please contact the administrator.", Title:=FrmLogin.BoxTitle)
        Finally
            SQLConnect.Close()
        End Try

    End Sub

    Public Shared Sub ReadDataConnect(SQL As String, Info As String)
        Dim ValidateLogin As Integer = ClsValidates.ValidateLogin
        Try
            SQLConnect.Open()
            SQLCommand = New SqlCommand
            With SQLCommand
                .Connection = SQLConnect
                .CommandText = SQL
                SQLResult = .ExecuteScalar
            End With

            If SQLResult = Info Then
                ValidateLogin += 1
                ClsValidates.ValidateLogin = ValidateLogin
            End If

        Catch ex As Exception
            MsgBox("An error has occurred. Please contact the administrator.", Title:=FrmLogin.BoxTitle)
        Finally
            SQLConnect.Close()
        End Try

    End Sub

    Public Shared Function Validate_Connection() As Integer
        Try
            SQLConnect.Open()
            SQLConnect.Close()
            Return 0
        Catch ex As Exception
        End Try

ReEnter:
        ConnServer = InputBox("Enter your database server name:")
        ConnDatabase = InputBox("Enter your database name:")
        Dim ConnAnother As SqlConnection = New SqlConnection("Data Source=" & ConnServer & ";Initial Catalog=" & ConnDatabase & ";Integrated Security=True")
        SQLConnect = ConnAnother

        If ConnServer = "" Then
            MsgBox("You must enter a database server name.")
            GoTo ReEnter
        End If

        If ConnDatabase = "" Then
            MsgBox("You must enter a database name.", Title:=FrmLogin.BoxTitle)
            GoTo ReEnter
        End If

        Try
            SQLConnect.Open()
            SQLConnect.Close()
            Return 1
        Catch ex As Exception
            MsgBox("There was a problem connecting to your database.", Title:=FrmLogin.BoxTitle)
            GoTo ReEnter
        End Try
    End Function

    Public Shared Function AdminPIN() As Boolean
        Dim PIN As String = FrmLogin.txtAcessPIN.Text
        SQL = "SELECT PIN FROM AdminPIN WHERE PIN = ('" & PIN & "')"

        Try
            SQLConnect.Open()
            SQLCommand = New SqlCommand
            With SQLCommand
                .Connection = SQLConnect
                .CommandText = SQL
                SQLResult = .ExecuteScalar
            End With

            If SQLResult = PIN Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox("An error has occurred. Please contact the administrator.", Title:=FrmLogin.BoxTitle)
        Finally
            SQLConnect.Close()
        End Try

        Return False

    End Function

End Class
