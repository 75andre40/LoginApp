Public Class ClsVisuals
    Public Shared Sub LoginVisible(x As Boolean)
        With FrmLogin
            .btnCancel.Visible = x
            .btnLog_In.Visible = x
            .txtUsername.Visible = x
            .txtPassword.Visible = x
            .lblUsername.Visible = x
            .lblPassword.Visible = x
        End With
    End Sub

    Public Shared Sub RegisterVisible(x As Boolean)
        With FrmLogin
            .btnCancelR.Visible = x
            .btnSign_UpR.Visible = x
            .txtUsernameR.Visible = x
            .txtEmailR.Visible = x
            .txtPasswordR1.Visible = x
            .txtPasswordR2.Visible = x
            .lblUsernameR.Visible = x
            .lblPasswordR1.Visible = x
            .lblPasswordR2.Visible = x
            .lblEmailR.Visible = x
            .lblPassInfo.Visible = x
            .txtAcessPIN.Visible = x
            .lblAcessPIN.Visible = x
        End With
    End Sub

    Public Shared Sub StartVisible(x As Boolean)
        With FrmLogin
            .btnLogIn.Visible = x
            .btnRegister.Visible = x
        End With
    End Sub

    Public Shared Sub LogSecure(x As Boolean)
        With FrmLogin
            .txtUsername.Enabled = x
            .txtPassword.Enabled = x
            .btnLog_In.Enabled = x
            .btnCancel.Enabled = x
        End With
    End Sub

    Public Shared Sub RegisterSecure(x As Boolean)
        With FrmLogin
            .txtUsernameR.Enabled = x
            .txtEmailR.Enabled = x
            .txtPasswordR1.Enabled = x
            .txtPasswordR2.Enabled = x
            .btnSign_UpR.Enabled = x
            .btnCancelR.Enabled = x
            .txtAcessPIN.Enabled = x
        End With
    End Sub
End Class
