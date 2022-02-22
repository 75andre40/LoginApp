<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.btnLogIn = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblUsernameR = New System.Windows.Forms.Label()
        Me.lblPasswordR1 = New System.Windows.Forms.Label()
        Me.txtUsernameR = New System.Windows.Forms.TextBox()
        Me.txtPasswordR1 = New System.Windows.Forms.TextBox()
        Me.lblPasswordR2 = New System.Windows.Forms.Label()
        Me.txtPasswordR2 = New System.Windows.Forms.TextBox()
        Me.lblEmailR = New System.Windows.Forms.Label()
        Me.txtEmailR = New System.Windows.Forms.TextBox()
        Me.btnLog_In = New System.Windows.Forms.Button()
        Me.btnSign_UpR = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCancelR = New System.Windows.Forms.Button()
        Me.lblPassInfo = New System.Windows.Forms.Label()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLogIn
        '
        Me.btnLogIn.BackColor = System.Drawing.SystemColors.Control
        Me.btnLogIn.Location = New System.Drawing.Point(234, 75)
        Me.btnLogIn.Name = "btnLogIn"
        Me.btnLogIn.Size = New System.Drawing.Size(75, 23)
        Me.btnLogIn.TabIndex = 0
        Me.btnLogIn.Text = "Log In"
        Me.btnLogIn.UseVisualStyleBackColor = False
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.SystemColors.Control
        Me.btnRegister.Location = New System.Drawing.Point(234, 127)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(75, 23)
        Me.btnRegister.TabIndex = 1
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.BackgroundImage = Global.LoginApp.My.Resources.Resources.Locker
        Me.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picLogo.Location = New System.Drawing.Point(28, 63)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(100, 100)
        Me.picLogo.TabIndex = 2
        Me.picLogo.TabStop = False
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblUsername.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUsername.Location = New System.Drawing.Point(199, 69)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(36, 15)
        Me.lblUsername.TabIndex = 3
        Me.lblUsername.Text = "User:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPassword.Location = New System.Drawing.Point(171, 102)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(64, 15)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Password:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(241, 68)
        Me.txtUsername.MaxLength = 16
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(132, 20)
        Me.txtUsername.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(241, 101)
        Me.txtPassword.MaxLength = 60
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(132, 20)
        Me.txtPassword.TabIndex = 4
        '
        'lblUsernameR
        '
        Me.lblUsernameR.AutoSize = True
        Me.lblUsernameR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblUsernameR.ForeColor = System.Drawing.SystemColors.Control
        Me.lblUsernameR.Location = New System.Drawing.Point(215, 34)
        Me.lblUsernameR.Name = "lblUsernameR"
        Me.lblUsernameR.Size = New System.Drawing.Size(36, 15)
        Me.lblUsernameR.TabIndex = 3
        Me.lblUsernameR.Text = "User:"
        '
        'lblPasswordR1
        '
        Me.lblPasswordR1.AutoSize = True
        Me.lblPasswordR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPasswordR1.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPasswordR1.Location = New System.Drawing.Point(187, 99)
        Me.lblPasswordR1.Name = "lblPasswordR1"
        Me.lblPasswordR1.Size = New System.Drawing.Size(64, 15)
        Me.lblPasswordR1.TabIndex = 3
        Me.lblPasswordR1.Text = "Password:"
        '
        'txtUsernameR
        '
        Me.txtUsernameR.Location = New System.Drawing.Point(257, 34)
        Me.txtUsernameR.MaxLength = 16
        Me.txtUsernameR.Name = "txtUsernameR"
        Me.txtUsernameR.Size = New System.Drawing.Size(132, 20)
        Me.txtUsernameR.TabIndex = 4
        '
        'txtPasswordR1
        '
        Me.txtPasswordR1.Location = New System.Drawing.Point(257, 99)
        Me.txtPasswordR1.MaxLength = 60
        Me.txtPasswordR1.Name = "txtPasswordR1"
        Me.txtPasswordR1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordR1.Size = New System.Drawing.Size(132, 20)
        Me.txtPasswordR1.TabIndex = 4
        '
        'lblPasswordR2
        '
        Me.lblPasswordR2.AutoSize = True
        Me.lblPasswordR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPasswordR2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPasswordR2.Location = New System.Drawing.Point(144, 144)
        Me.lblPasswordR2.Name = "lblPasswordR2"
        Me.lblPasswordR2.Size = New System.Drawing.Size(107, 15)
        Me.lblPasswordR2.TabIndex = 3
        Me.lblPasswordR2.Text = "Repeat Password:"
        '
        'txtPasswordR2
        '
        Me.txtPasswordR2.Location = New System.Drawing.Point(257, 143)
        Me.txtPasswordR2.MaxLength = 60
        Me.txtPasswordR2.Name = "txtPasswordR2"
        Me.txtPasswordR2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordR2.Size = New System.Drawing.Size(132, 20)
        Me.txtPasswordR2.TabIndex = 4
        '
        'lblEmailR
        '
        Me.lblEmailR.AutoSize = True
        Me.lblEmailR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblEmailR.ForeColor = System.Drawing.SystemColors.Control
        Me.lblEmailR.Location = New System.Drawing.Point(205, 66)
        Me.lblEmailR.Name = "lblEmailR"
        Me.lblEmailR.Size = New System.Drawing.Size(46, 15)
        Me.lblEmailR.TabIndex = 3
        Me.lblEmailR.Text = "E-mail:"
        '
        'txtEmailR
        '
        Me.txtEmailR.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtEmailR.Location = New System.Drawing.Point(257, 66)
        Me.txtEmailR.MaxLength = 100
        Me.txtEmailR.Name = "txtEmailR"
        Me.txtEmailR.Size = New System.Drawing.Size(132, 20)
        Me.txtEmailR.TabIndex = 4
        '
        'btnLog_In
        '
        Me.btnLog_In.BackColor = System.Drawing.SystemColors.Control
        Me.btnLog_In.Location = New System.Drawing.Point(192, 134)
        Me.btnLog_In.Name = "btnLog_In"
        Me.btnLog_In.Size = New System.Drawing.Size(75, 23)
        Me.btnLog_In.TabIndex = 0
        Me.btnLog_In.Text = "Log In"
        Me.btnLog_In.UseVisualStyleBackColor = False
        '
        'btnSign_UpR
        '
        Me.btnSign_UpR.BackColor = System.Drawing.SystemColors.Control
        Me.btnSign_UpR.Location = New System.Drawing.Point(191, 178)
        Me.btnSign_UpR.Name = "btnSign_UpR"
        Me.btnSign_UpR.Size = New System.Drawing.Size(75, 23)
        Me.btnSign_UpR.TabIndex = 0
        Me.btnSign_UpR.Text = "Sign Up"
        Me.btnSign_UpR.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(273, 134)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnCancelR
        '
        Me.btnCancelR.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelR.Location = New System.Drawing.Point(272, 178)
        Me.btnCancelR.Name = "btnCancelR"
        Me.btnCancelR.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelR.TabIndex = 0
        Me.btnCancelR.Text = "Cancel"
        Me.btnCancelR.UseVisualStyleBackColor = False
        '
        'lblPassInfo
        '
        Me.lblPassInfo.AutoSize = True
        Me.lblPassInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPassInfo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblPassInfo.Location = New System.Drawing.Point(257, 123)
        Me.lblPassInfo.Name = "lblPassInfo"
        Me.lblPassInfo.Size = New System.Drawing.Size(127, 15)
        Me.lblPassInfo.TabIndex = 3
        Me.lblPassInfo.Text = "Introduce a password."
        '
        'FrmLogin
        '
        Me.AcceptButton = Me.btnLog_In
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(420, 241)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.btnLogIn)
        Me.Controls.Add(Me.lblPasswordR2)
        Me.Controls.Add(Me.lblPasswordR1)
        Me.Controls.Add(Me.lblEmailR)
        Me.Controls.Add(Me.lblUsernameR)
        Me.Controls.Add(Me.lblPassInfo)
        Me.Controls.Add(Me.txtUsernameR)
        Me.Controls.Add(Me.txtEmailR)
        Me.Controls.Add(Me.txtPasswordR1)
        Me.Controls.Add(Me.txtPasswordR2)
        Me.Controls.Add(Me.btnSign_UpR)
        Me.Controls.Add(Me.btnCancelR)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.btnLog_In)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmLogin"
        Me.Text = "Login - App"
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnLogIn As Button
    Friend WithEvents btnRegister As Button
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblUsernameR As Label
    Friend WithEvents lblPasswordR1 As Label
    Friend WithEvents txtUsernameR As TextBox
    Friend WithEvents txtPasswordR1 As TextBox
    Friend WithEvents lblPasswordR2 As Label
    Friend WithEvents txtPasswordR2 As TextBox
    Friend WithEvents lblEmailR As Label
    Friend WithEvents txtEmailR As TextBox
    Friend WithEvents btnLog_In As Button
    Friend WithEvents btnSign_UpR As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnCancelR As Button
    Friend WithEvents lblPassInfo As Label
End Class
