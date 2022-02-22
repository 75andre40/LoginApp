Imports System.Text
Imports System.Data.SqlClient

Public Class FrmLogin
    Dim BoxTitle As String = "Login"
    Dim SecurityPoints As Integer = 0
    Dim ValidateLogin As Integer = 0
    Dim EncryptedPassword As String

    'Connections'
    Dim ConnServer As String
    Dim ConnDatabase As String
    Dim ConnETLA As SqlConnection = New SqlConnection("Data Source=DATASERVER02;Initial Catalog=I2021_esiandco;Integrated Security=True")
    'Connections'

    Dim SQLConnect As SqlConnection = New SqlConnection(ConnETLA.ConnectionString)
    Dim SQLCommand As SqlCommand
    Dim SQLReader As SqlDataReader
    Dim SQL As String
    Dim SQLP As String
    Dim SQLResult As String

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Criar um loop para dar load no programa

        Me.Visible = True
        StartVisible(True)
        LoginVisible(False)
        RegisterVisible(False)
        btnLogIn.Enabled = False
        btnRegister.Enabled = False

        If Validate_Connection() = 0 Then
            MsgBox("ETLA Database is now connected.")
        Else
            MsgBox("Your Database is now connected.")
        End If
        btnLogIn.Enabled = True
        btnRegister.Enabled = True
    End Sub

    Private Function Validate_Connection() As Integer

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

        Try
            SQLConnect.Open()
            SQLConnect.Close()
            Return 1
        Catch ex As Exception
            MsgBox("There was a problem connecting to your database.")
            GoTo ReEnter
        End Try
    End Function

    Private Sub Login_Start_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click 'Open Login Button
        StartVisible(False)
        LoginVisible(True)
    End Sub

    Private Sub Register_Start_Click(sender As Object, e As EventArgs) Handles btnRegister.Click 'Open Register Button
        StartVisible(False)
        RegisterVisible(True)
        lblPassInfo.Text = "Introduce a password."
        lblPassInfo.ForeColor = Color.White
    End Sub

    Private Sub Login_Confirm_Click(sender As Object, e As EventArgs) Handles btnLog_In.Click

        EncryptedPassword = Encrypter(txtUsername.Text, txtPassword.Text)

        LogSecure(False)
        ValidateLogin = 0

        SQL = "SELECT Login_UserName FROM Logins WHERE Login_UserName = ('" & txtUsername.Text & "') AND Login_Password = ('" & EncryptedPassword & "')"
        ReadDataConnect(SQL, txtUsername.Text)

        SQLP = "SELECT Login_Password FROM Logins WHERE Login_Password = ('" & EncryptedPassword & "') AND Login_UserName = ('" & txtUsername.Text & "')"
        ReadDataConnect(SQLP, EncryptedPassword)

        If ValidateLogin >= 2 Then
            MsgBox("You are now autenticated!", Title:=BoxTitle)
            ValidateLogin = 0
            StartVisible(True)
            LoginVisible(False)
            RegisterVisible(False)
            'Frm.Visible = True ------------------------------Join the application
            Me.Visible = False
        Else
            ValidateLogin = 0
            MsgBox("Someting went wrong! Check your username and password again.", Title:=BoxTitle)
        End If

        LogSecure(True)
    End Sub

    Private Sub Register_Confirm_Click(sender As Object, e As EventArgs) Handles btnSign_UpR.Click 'Real Register Button
        Dim RegisterPoints As Integer = 0
        RegisterSecure(False)

        If User_Validate_R() = False Then
            If Email_Validate_R() = False Then

                '----------------------------------------------------------------------------------------
                If SecurityPoints >= 4 Then
                    If txtPasswordR1.Text = txtPasswordR2.Text Then

                        EncryptedPassword = Encrypter(txtUsernameR.Text, txtPasswordR1.Text)

                        SQL = "INSERT INTO Logins (Login_UserName,Login_Email,Login_Password) VALUES ('" & txtUsernameR.Text & "','" & txtEmailR.Text & "','" & EncryptedPassword & "')"
                        SaveDataConnect(SQL)

                        txtUsernameR.Clear()
                        txtEmailR.Clear()
                        txtPasswordR1.Clear()
                        txtPasswordR2.Clear()

                        StartVisible(True)
                        RegisterVisible(False)

                    Else
                        MsgBox("Please introduce the same password twice.", Title:=BoxTitle)
                    End If
                Else
                    MsgBox("Your password is not secure enough!", Title:=BoxTitle)
                End If
                '----------------------------------------------------------------------------------------
            Else
                MsgBox("Your e-mail is too short, and/or contain invalid characters!", Title:=BoxTitle)
            End If
        Else
            MsgBox("Your username is too short, and/or cannot contain any special characters!", Title:=BoxTitle)
        End If

        RegisterSecure(True)

    End Sub

    Private Sub SaveDataConnect(SQL As String)

        Try
            SQLConnect.Open()
            SQLCommand = New SqlCommand
            With SQLCommand
                .Connection = SQLConnect
                .CommandText = SQL
                SQLResult = .ExecuteNonQuery()
            End With
            If SQLResult > 0 Then
                MsgBox("You are now registered!", Title:=BoxTitle)
                StartVisible(True)
                LoginVisible(False)
                RegisterVisible(False)
            End If

        Catch ex As Exception
            MsgBox("An error has occurred. Please contact the administrator.", Title:=BoxTitle)
        Finally
            SQLConnect.Close()
        End Try

    End Sub

    Private Sub ReadDataConnect(SQL As String, Info As String)

        Try
            SQLConnect.Open()
            SQLCommand = New SqlCommand
            With SQLCommand
                .Connection = SQLConnect
                .CommandText = SQL
                SQLResult = .ExecuteScalar
            End With

            Dim chars() As Char = Info
            Info = ""

            For Each c As Char In chars
                If c = "�" Or c = "" Or c = "˽" Or c = "ڀ" Then
                    c = "?"
                End If
                Info += c
            Next


            If SQLResult = Info Then
                ValidateLogin += 1
            End If

        Catch ex As Exception
            MsgBox("An error has occurred. Please contact the administrator.", Title:=BoxTitle)
        Finally
            SQLConnect.Close()
        End Try

    End Sub

    Public Function Encrypter(User As String, Pass As String) As String
        Dim Encoder As New UnicodeEncoding()
        Dim EncodeToBytes() As Byte = Encoder.GetBytes(User & Pass)
        Dim ByteEncrypter As New System.Security.Cryptography.SHA256Managed()
        Dim Encrypted() As Byte = ByteEncrypter.ComputeHash(EncodeToBytes)
        Return Convert.ToBase64String(Encrypted)
    End Function

    Private Sub LoginVisible(x As Boolean)
        btnCancel.Visible = x
        btnLog_In.Visible = x
        txtUsername.Visible = x
        txtPassword.Visible = x
        lblUsername.Visible = x
        lblPassword.Visible = x
    End Sub

    Private Sub RegisterVisible(x As Boolean)
        btnCancelR.Visible = x
        btnSign_UpR.Visible = x
        txtUsernameR.Visible = x
        txtEmailR.Visible = x
        txtPasswordR1.Visible = x
        txtPasswordR2.Visible = x
        lblUsernameR.Visible = x
        lblPasswordR1.Visible = x
        lblPasswordR2.Visible = x
        lblEmailR.Visible = x
        lblPassInfo.Visible = x
    End Sub

    Private Sub StartVisible(x As Boolean)
        btnLogIn.Visible = x
        btnRegister.Visible = x
    End Sub

    Private Sub Cancel_Clicks(sender As Object, e As EventArgs) Handles btnCancel.Click, btnCancelR.Click

        txtUsernameR.Clear()
        txtEmailR.Clear()
        txtPasswordR1.Clear()
        txtPasswordR2.Clear()

        txtUsername.Clear()
        txtPassword.Clear()

        RegisterVisible(False)
        LoginVisible(False)
        StartVisible(True)

    End Sub

    Private Sub LogSecure(x As Boolean)
        txtUsername.Enabled = x
        txtPassword.Enabled = x
        btnLog_In.Enabled = x
        btnCancel.Enabled = x
    End Sub

    Private Sub RegisterSecure(x As Boolean)
        txtUsernameR.Enabled = x
        txtEmailR.Enabled = x
        txtPasswordR1.Enabled = x
        txtPasswordR2.Enabled = x
        btnSign_UpR.Enabled = x
        btnCancelR.Enabled = x
    End Sub

    Private Sub Password_Validate_R(sender As Object, e As EventArgs) Handles txtPasswordR1.TextChanged
        Dim chars() As Char = txtPasswordR1.Text
        Dim ContainNumbers As Boolean
        Dim ContainUpper As Boolean
        Dim ContainLower As Boolean
        Dim ContainSpecial As Boolean
        ContainNumbers = False
        ContainUpper = False
        ContainLower = False
        ContainSpecial = False
        SecurityPoints = 1

        For Each c As Char In chars
            If IsNumeric(c) Then
                ContainNumbers = True
            End If

            If Char.IsLetter(c) Then
                If Char.IsUpper(c) Then
                    ContainUpper = True
                End If
                If Char.IsLower(c) Then
                    ContainLower = True
                End If
            End If

            If c = " " Or c = "!" Or c = Chr(34) Or c = "#" Or c = "$" Or c = "%" Or c = "&" Or c = "'" Or c = "(" Or c = ")" Or c = "*" Or c = "+" Or c = "," Or c = "-" Or c = "." Or c = "/" Or c = ":" Or c = ";" Or c = "<" Or c = "=" Or c = ">" Or c = "?" Or c = "@" Or c = "[" Or c = "\" Or c = "]" Or c = "^" Or c = "_" Or c = "`" Or c = "{" Or c = "|" Or c = "}" Or c = "~" Or c = "´" Then
                ContainSpecial = True
            End If

        Next

        If ContainNumbers = True Then
            SecurityPoints += 1
        End If

        If ContainSpecial = True Then
            SecurityPoints += 1
        End If

        If ContainUpper = True Then
            SecurityPoints += 1
        End If

        If ContainLower = True Then
            SecurityPoints += 1
        End If

        If txtPasswordR1.TextLength >= 6 Then
            SecurityPoints += 1
        End If

        If txtPasswordR1.TextLength >= 12 Then
            SecurityPoints += 1
        End If



        If SecurityPoints <= 3 Then
            lblPassInfo.Text = "Weak"
            lblPassInfo.ForeColor = Color.DarkRed
        End If

        If SecurityPoints >= 4 Then
            lblPassInfo.Text = "Normal"
            lblPassInfo.ForeColor = Color.Yellow
        End If

        If SecurityPoints >= 6 Then
            lblPassInfo.Text = "Strong"
            lblPassInfo.ForeColor = Color.LightGreen
        End If

        If txtPasswordR1.TextLength = 0 Then 'Não contém nada
            SecurityPoints = 0
            lblPassInfo.Text = "Introduce a password."
            lblPassInfo.ForeColor = Color.White
        End If

    End Sub

    Private Function User_Validate_R() As Boolean
        Dim ValidatePoints As Integer = 0
        Dim Validate1 As Boolean = True
        Dim Validate2 As Boolean = True
        Dim chars() As Char = txtUsernameR.Text
        Dim BoolReturn As Boolean

        For Each c As Char In chars
            If c = " " Or c = "!" Or c = Chr(34) Or c = "#" Or c = "$" Or c = "%" Or c = "&" Or c = "'" Or c = "(" Or c = ")" Or c = "*" Or c = "+" Or c = "," Or c = "-" Or c = "." Or c = "/" Or c = ":" Or c = ";" Or c = "<" Or c = "=" Or c = ">" Or c = "?" Or c = "@" Or c = "[" Or c = "\" Or c = "]" Or c = "^" Or c = "`" Or c = "{" Or c = "|" Or c = "}" Or c = "~" Or c = "´" Then
                Validate1 = True
                Exit For
            Else
                Validate1 = False
            End If
        Next

        If txtUsernameR.TextLength >= 4 Then
            Validate2 = False
        Else
            Validate2 = True
        End If

        If Validate1 = False Then
            If Validate2 = False Then
                BoolReturn = False
            Else
                BoolReturn = True
            End If
        Else
            BoolReturn = True
        End If

        Return BoolReturn
    End Function

    Private Function Email_Validate_R() As Boolean
        Dim ValidatePoints As Integer = 0
        Dim Validate1 As Boolean = True
        Dim Validate2 As Boolean = True
        Dim Validate3 As Boolean = True
        Dim chars() As Char = txtEmailR.Text
        Dim BoolReturn As Boolean

        For Each c As Char In chars
            If c = " " Or c = "!" Or c = Chr(34) Or c = "#" Or c = "$" Or c = "%" Or c = "&" Or c = "'" Or c = "(" Or c = ")" Or c = "*" Or c = "+" Or c = "," Or c = "/" Or c = ":" Or c = ";" Or c = "<" Or c = "=" Or c = ">" Or c = "?" Or c = "[" Or c = "\" Or c = "]" Or c = "^" Or c = "`" Or c = "{" Or c = "|" Or c = "}" Or c = "~" Or c = "´" Then
                Validate1 = True
                Exit For
            Else
                Validate1 = False
            End If
        Next

        For Each c As Char In chars
            If c = "@" Then
                Validate2 = False
                Exit For
            Else
                Validate2 = True
            End If
        Next

        If txtEmailR.TextLength >= 10 Then
            Validate3 = False
        Else
            Validate3 = True
        End If

        If Validate1 = False Then
            If Validate2 = False Then
                If Validate3 = False Then
                    BoolReturn = False
                Else
                    BoolReturn = True
                End If
            Else
                BoolReturn = True
            End If
        Else
            BoolReturn = True
        End If

        Return BoolReturn
    End Function

    Private Sub FormClose() Handles MyBase.Closed
        End
    End Sub
End Class
