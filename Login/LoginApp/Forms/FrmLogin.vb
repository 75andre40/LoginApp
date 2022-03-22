Imports System.Text
Imports System.Data.SqlClient

Public Class FrmLogin
    Public Shared BoxTitle As String = "Login"

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me
            .txtUsernameR.Location = New System.Drawing.Point(257, 34)
            .lblUsernameR.Location = New System.Drawing.Point(215, 34)
            .txtEmailR.Location = New System.Drawing.Point(257, 66)
            .lblEmailR.Location = New System.Drawing.Point(205, 66)
            .txtPasswordR1.Location = New System.Drawing.Point(257, 99)
            .lblPasswordR1.Location = New System.Drawing.Point(187, 99)
            .lblPassInfo.Location = New System.Drawing.Point(257, 123)
            .txtPasswordR2.Location = New System.Drawing.Point(257, 143)
            .lblPasswordR2.Location = New System.Drawing.Point(144, 144)
            .btnSign_UpR.Location = New System.Drawing.Point(191, 178)
            .btnCancelR.Location = New System.Drawing.Point(272, 178)

            .txtUsername.Location = New System.Drawing.Point(241, 68)
            .lblUsername.Location = New System.Drawing.Point(199, 69)
            .txtPassword.Location = New System.Drawing.Point(241, 101)
            .lblPassword.Location = New System.Drawing.Point(171, 102)
            .btnLog_In.Location = New System.Drawing.Point(192, 134)
            .btnCancel.Location = New System.Drawing.Point(273, 134)

            .Size = New System.Drawing.Point(436, 280)
            .Visible = True
        End With


        ClsVisuals.StartVisible(False)
        ClsVisuals.LoginVisible(True)
        ClsVisuals.RegisterVisible(False)

        btnLogIn.Enabled = False
        btnRegister.Enabled = False

        If ClsSqlData.Validate_Connection() = 0 Then
            MsgBox("ETLA Database is now connected.")
        Else
            MsgBox("Your Database is now connected.")
        End If
        btnLogIn.Enabled = True
        btnRegister.Enabled = True
    End Sub

    Private Sub Login_Start_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        ClsVisuals.StartVisible(False)
        ClsVisuals.LoginVisible(True)
    End Sub

    Private Sub Register_Start_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ClsVisuals.StartVisible(False)
        ClsVisuals.RegisterVisible(True)
        lblPassInfo.Text = "Introduce a password."
        lblPassInfo.ForeColor = Color.White
    End Sub

    Private Sub Login_Confirm_Click(sender As Object, e As EventArgs) Handles btnLog_In.Click

        ClsVisuals.LogSecure(False)

        ClsValidates.LoginConfirmValidate()

        ClsVisuals.LogSecure(True)
    End Sub

    Private Sub Register_Confirm_Click(sender As Object, e As EventArgs) Handles btnSign_UpR.Click

        ClsVisuals.RegisterSecure(False)

        ClsValidates.RegisterConfirmValidate()

        ClsVisuals.RegisterSecure(True)

    End Sub

    Private Sub Cancel_Clicks(sender As Object, e As EventArgs) Handles btnCancel.Click, btnCancelR.Click

        txtUsernameR.Clear()
        txtEmailR.Clear()
        txtPasswordR1.Clear()
        txtPasswordR2.Clear()

        txtUsername.Clear()
        txtPassword.Clear()

        ClsVisuals.RegisterVisible(False)
        ClsVisuals.LoginVisible(False)
        ClsVisuals.StartVisible(True)

    End Sub

    Private Sub Password_Validate_R(sender As Object, e As EventArgs) Handles txtPasswordR1.TextChanged
        ClsValidates.Password_Validate_R(sender, e)
    End Sub

    Private Sub FormClose() Handles MyBase.Closed
        End
    End Sub
End Class
