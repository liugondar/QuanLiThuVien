<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.btnLogin = New MetroFramework.Controls.MetroButton()
        Me.btnExit = New MetroFramework.Controls.MetroButton()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.panel1.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.btnLogin)
        Me.panel1.Controls.Add(Me.btnExit)
        Me.panel1.Controls.Add(Me.panel3)
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Location = New System.Drawing.Point(23, 63)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(449, 160)
        Me.panel1.TabIndex = 1
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(254, 133)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Đăng nhập"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(348, 133)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Thoát"
        '
        'panel3
        '
        Me.panel3.Controls.Add(Me.txtPassword)
        Me.panel3.Controls.Add(Me.label2)
        Me.panel3.Location = New System.Drawing.Point(3, 75)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(436, 44)
        Me.panel3.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(147, 6)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(289, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label2.Location = New System.Drawing.Point(9, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(84, 18)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Mật Khẩu:"
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.txtUsername)
        Me.panel2.Controls.Add(Me.label1)
        Me.panel2.Location = New System.Drawing.Point(3, 12)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(436, 57)
        Me.panel2.TabIndex = 0
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(147, 25)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(289, 20)
        Me.txtUsername.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label1.Location = New System.Drawing.Point(9, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(118, 18)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Tên đăng nhập"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(517, 242)
        Me.Controls.Add(Me.panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogin"
        Me.Text = "Đăng nhập"
        Me.panel1.ResumeLayout(False)
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panel1 As Panel
    Friend WithEvents btnLogin As MetroFramework.Controls.MetroButton
    Friend WithEvents btnExit As MetroFramework.Controls.MetroButton
    Private WithEvents panel3 As Panel
    Private WithEvents txtPassword As TextBox
    Private WithEvents label2 As Label
    Private WithEvents panel2 As Panel
    Private WithEvents txtUsername As TextBox
    Private WithEvents label1 As Label
End Class
