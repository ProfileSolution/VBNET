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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        OpenFileDialog1 = New OpenFileDialog()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.ControlDarkDark
        Button1.Location = New Point(34, 43)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 48)
        Button1.TabIndex = 0
        Button1.Text = "Intialise solver"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = SystemColors.ControlDarkDark
        Button2.Location = New Point(228, 43)
        Button2.Name = "Button2"
        Button2.Size = New Size(81, 48)
        Button2.TabIndex = 1
        Button2.Text = "Set Unit"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = SystemColors.ControlDarkDark
        Button3.Location = New Point(446, 43)
        Button3.Name = "Button3"
        Button3.Size = New Size(81, 48)
        Button3.TabIndex = 2
        Button3.Text = "Create Material"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.ShowPreview = True
        OpenFileDialog1.Title = "File Dialog"
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.ControlDarkDark
        Button4.Location = New Point(651, 43)
        Button4.Name = "Button4"
        Button4.Size = New Size(81, 48)
        Button4.TabIndex = 3
        Button4.Text = "Load File "
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = SystemColors.ControlDarkDark
        Button5.Location = New Point(276, 130)
        Button5.Name = "Button5"
        Button5.Size = New Size(81, 48)
        Button5.TabIndex = 4
        Button5.Text = "Boundary Condition"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = SystemColors.ControlDarkDark
        Button6.Location = New Point(471, 130)
        Button6.Name = "Button6"
        Button6.Size = New Size(81, 48)
        Button6.TabIndex = 5
        Button6.Text = "Meshing Region"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackColor = SystemColors.ControlDarkDark
        Button7.Location = New Point(378, 207)
        Button7.Name = "Button7"
        Button7.Size = New Size(81, 48)
        Button7.TabIndex = 7
        Button7.Text = "Run Solver"
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(800, 450)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "Form1"
        Text = "Design Data Center with Profile Solutions"
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button

End Class
