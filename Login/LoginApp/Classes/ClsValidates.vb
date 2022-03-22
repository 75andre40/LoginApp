Public Class ClsValidates
    Public Shared ValidateLogin As Integer = 0
    Public Shared EncryptedPassword As String
    Public Shared SecurityPoints As Integer = 0

    Public Shared Sub LoginConfirmValidate()
        ValidateLogin = 0

        Dim Username As String = FrmLogin.txtUsername.Text
        Dim Password As String = FrmLogin.txtPassword.Text

        EncryptedPassword = ClsEncoder.Encrypter(Username, Password)

        ClsSqlData.SQL = "SELECT Login_UserName FROM Logins WHERE Login_UserName = ('" & Username & "') AND Login_Password = ('" & EncryptedPassword & "')"
        ClsSqlData.ReadDataConnect(ClsSqlData.SQL, Username)

        ClsSqlData.SQLP = "SELECT Login_Password FROM Logins WHERE Login_Password = ('" & EncryptedPassword & "') AND Login_UserName = ('" & Username & "')"
        ClsSqlData.ReadDataConnect(ClsSqlData.SQLP, EncryptedPassword)

        If ValidateLogin >= 2 Then
            MsgBox("You are now autenticated!", Title:=FrmLogin.BoxTitle)
            ValidateLogin = 0
            ClsVisuals.StartVisible(True)
            ClsVisuals.LoginVisible(False)
            ClsVisuals.RegisterVisible(False)
            'Frm.Visible = True ------------------------------Join the application
            FrmLogin.Visible = False
        Else
            ValidateLogin = 0
            MsgBox("Someting went wrong! Check your username and password again.", Title:=FrmLogin.BoxTitle)
        End If

        Username = ""
        Password = ""

    End Sub

    Public Shared Sub RegisterConfirmValidate()
        Dim RegisterPoints As Integer = 0

        Dim Username As String = FrmLogin.txtUsernameR.Text
        Dim Email As String = FrmLogin.txtEmailR.Text
        Dim Password As String = FrmLogin.txtPasswordR1.Text

        If ClsSqlData.AdminPIN = True Then
            If User_Validate_R() = False Then
                If Email_Validate_R() = False Then

                    '----------------------------------------------------------------------------------------
                    If SecurityPoints >= 4 Then
                        If FrmLogin.txtPasswordR1.Text = FrmLogin.txtPasswordR2.Text Then

                            EncryptedPassword = ClsEncoder.Encrypter(Username, Password)

                            ClsSqlData.SQL = "INSERT INTO Logins (Login_UserName,Login_Email,Login_Password) VALUES ('" & Username & "','" & Email & "','" & EncryptedPassword & "')"
                            ClsSqlData.SaveDataConnect(ClsSqlData.SQL)

                            FrmLogin.txtUsernameR.Clear()
                            FrmLogin.txtEmailR.Clear()
                            FrmLogin.txtPasswordR1.Clear()
                            FrmLogin.txtPasswordR2.Clear()
                            FrmLogin.txtAcessPIN.Clear()

                            ClsVisuals.StartVisible(True)
                            ClsVisuals.RegisterVisible(False)

                        Else
                            MsgBox("Please introduce the same password twice.", Title:=FrmLogin.BoxTitle)
                        End If
                    Else
                        MsgBox("Your password is not secure enough!", Title:=FrmLogin.BoxTitle)
                    End If
                    '----------------------------------------------------------------------------------------
                Else
                    MsgBox("Your e-mail is too short, and/or contain invalid characters!", Title:=FrmLogin.BoxTitle)
                End If
            Else
                MsgBox("Your username is too short, and/or cannot contain any special characters!", Title:=FrmLogin.BoxTitle)
            End If
        Else
            MsgBox("The admin pin is wrong.", Title:=FrmLogin.BoxTitle)
        End If


        Username = ""
        Password = ""
    End Sub

    Public Shared Sub Password_Validate_R(sender As Object, e As EventArgs)
        Dim chars() As Char = sender.text
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

        If sender.TextLength >= 6 Then
            SecurityPoints += 1
        End If

        If sender.TextLength >= 12 Then
            SecurityPoints += 1
        End If

        If SecurityPoints <= 3 Then
            FrmLogin.lblPassInfo.Text = "Weak"
            FrmLogin.lblPassInfo.ForeColor = Color.DarkRed
        End If

        If SecurityPoints >= 4 Then
            FrmLogin.lblPassInfo.Text = "Normal"
            FrmLogin.lblPassInfo.ForeColor = Color.Yellow
        End If

        If SecurityPoints >= 6 Then
            FrmLogin.lblPassInfo.Text = "Strong"
            FrmLogin.lblPassInfo.ForeColor = Color.LightGreen
        End If

        If FrmLogin.txtPasswordR1.TextLength = 0 Then
            SecurityPoints = 0
            FrmLogin.lblPassInfo.Text = "Introduce a password."
            FrmLogin.lblPassInfo.ForeColor = Color.White
        End If

    End Sub


    Public Shared Function User_Validate_R() As Boolean
        Dim ValidatePoints As Integer = 0
        Dim Validate1 As Boolean = True
        Dim Validate2 As Boolean = True
        Dim chars() As Char = FrmLogin.txtUsernameR.Text
        Dim BoolReturn As Boolean

        For Each c As Char In chars
            If c = " " Or c = "!" Or c = Chr(34) Or c = "#" Or c = "$" Or c = "%" Or c = "&" Or c = "'" Or c = "(" Or c = ")" Or c = "*" Or c = "+" Or c = "," Or c = "-" Or c = "." Or c = "/" Or c = ":" Or c = ";" Or c = "<" Or c = "=" Or c = ">" Or c = "?" Or c = "@" Or c = "[" Or c = "\" Or c = "]" Or c = "^" Or c = "`" Or c = "{" Or c = "|" Or c = "}" Or c = "~" Or c = "´" Then
                Validate1 = True
                Exit For
            Else
                Validate1 = False
            End If
        Next

        If FrmLogin.txtUsernameR.TextLength >= 4 Then
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

    Public Shared Function Email_Validate_R() As Boolean
        Dim ValidatePoints As Integer = 0
        Dim Validate1 As Boolean = True
        Dim Validate2 As Boolean = True
        Dim Validate3 As Boolean = True
        Dim chars() As Char = FrmLogin.txtEmailR.Text
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

        If FrmLogin.txtEmailR.TextLength >= 10 Then
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

End Class
