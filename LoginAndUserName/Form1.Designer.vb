<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        textUser = New Label()
        textPass = New Label()
        txtUsr = New TextBox()
        txtPass = New TextBox()
        Button1 = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' textUser
        ' 
        textUser.AutoSize = True
        textUser.BackColor = SystemColors.Control
        textUser.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        textUser.Location = New Point(112, 83)
        textUser.Name = "textUser"
        textUser.Size = New Size(81, 21)
        textUser.TabIndex = 0
        textUser.Text = "Username"
        ' 
        ' textPass
        ' 
        textPass.AutoSize = True
        textPass.Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        textPass.Location = New Point(112, 150)
        textPass.Name = "textPass"
        textPass.Size = New Size(76, 21)
        textPass.TabIndex = 1
        textPass.Text = "Password"
        ' 
        ' txtUsr
        ' 
        txtUsr.AcceptsReturn = True
        txtUsr.Location = New Point(290, 81)
        txtUsr.Name = "txtUsr"
        txtUsr.Size = New Size(100, 23)
        txtUsr.TabIndex = 2
        ' 
        ' txtPass
        ' 
        txtPass.Location = New Point(290, 152)
        txtPass.Name = "txtPass"
        txtPass.PasswordChar = "*"c
        txtPass.Size = New Size(100, 23)
        txtPass.TabIndex = 3
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.GradientActiveCaption
        Button1.Location = New Point(204, 226)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 4
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(80, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(347, 32)
        Label1.TabIndex = 5
        Label1.Text = "Welcome to Profile Solutions"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(513, 284)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(txtPass)
        Controls.Add(txtUsr)
        Controls.Add(textPass)
        Controls.Add(textUser)
        Location = New Point(15, 15)
        Name = "Form1"
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents textUser As Label
    Friend WithEvents textPass As Label
    Friend WithEvents txtUsr As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label

End Class
