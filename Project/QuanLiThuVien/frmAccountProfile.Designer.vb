<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAccountProfile
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountProfile))
        Me.panel5 = New System.Windows.Forms.Panel()
        Me.txtNewPasswordConfirm = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.panel4 = New System.Windows.Forms.Panel()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnExit = New MetroFramework.Controls.MetroButton()
        Me.panel5.SuspendLayout()
        Me.panel4.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel5
        '
        Me.panel5.Controls.Add(Me.txtNewPasswordConfirm)
        Me.panel5.Controls.Add(Me.label5)
        Me.panel5.Location = New System.Drawing.Point(40, 324)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(460, 57)
        Me.panel5.TabIndex = 10
        '
        'txtNewPasswordConfirm
        '
        Me.txtNewPasswordConfirm.Location = New System.Drawing.Point(191, 25)
        Me.txtNewPasswordConfirm.Name = "txtNewPasswordConfirm"
        Me.txtNewPasswordConfirm.Size = New System.Drawing.Size(254, 20)
        Me.txtNewPasswordConfirm.TabIndex = 1
        Me.txtNewPasswordConfirm.UseSystemPasswordChar = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label5.Location = New System.Drawing.Point(9, 24)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(155, 18)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Nhập lại mật khẩu mới"
        '
        'panel4
        '
        Me.panel4.Controls.Add(Me.txtNewPassword)
        Me.panel4.Controls.Add(Me.label4)
        Me.panel4.Location = New System.Drawing.Point(40, 261)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(460, 57)
        Me.panel4.TabIndex = 9
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(191, 25)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.Size = New System.Drawing.Size(254, 20)
        Me.txtNewPassword.TabIndex = 1
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label4.Location = New System.Drawing.Point(9, 24)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 18)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Mật khẩu mới :"
        '
        'panel3
        '
        Me.panel3.Controls.Add(Me.txtPassword)
        Me.panel3.Controls.Add(Me.label3)
        Me.panel3.Location = New System.Drawing.Point(40, 198)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(460, 57)
        Me.panel3.TabIndex = 8
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(191, 25)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(254, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label3.Location = New System.Drawing.Point(9, 24)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(73, 18)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Mật khẩu:"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.txtDisplayName)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Location = New System.Drawing.Point(40, 135)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(460, 57)
        Me.panel1.TabIndex = 7
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Location = New System.Drawing.Point(191, 22)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(254, 20)
        Me.txtDisplayName.TabIndex = 1
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label2.Location = New System.Drawing.Point(9, 24)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(87, 18)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Tên hiển thị:"
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.txtUserName)
        Me.panel2.Controls.Add(Me.label1)
        Me.panel2.Location = New System.Drawing.Point(40, 72)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(460, 57)
        Me.panel2.TabIndex = 6
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(191, 24)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(254, 20)
        Me.txtUserName.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.label1.Location = New System.Drawing.Point(9, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(109, 18)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Tên đăng nhập:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(263, 407)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 12
        Me.btnUpdate.Text = "Cập nhật"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(366, 407)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 13
        Me.btnExit.Text = "Thoát"
        '
        'frmAccountProfile
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(523, 453)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.panel5)
        Me.Controls.Add(Me.panel4)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAccountProfile"
        Me.Text = "Thông tin tài khoản"
        Me.panel5.ResumeLayout(False)
        Me.panel5.PerformLayout()
        Me.panel4.ResumeLayout(False)
        Me.panel4.PerformLayout()
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panel5 As Panel
    Private WithEvents txtNewPasswordConfirm As TextBox
    Private WithEvents label5 As Label
    Private WithEvents panel4 As Panel
    Private WithEvents txtNewPassword As TextBox
    Private WithEvents label4 As Label
    Private WithEvents panel3 As Panel
    Private WithEvents txtPassword As TextBox
    Private WithEvents label3 As Label
    Private WithEvents panel1 As Panel
    Private WithEvents txtDisplayName As TextBox
    Private WithEvents label2 As Label
    Private WithEvents panel2 As Panel
    Private WithEvents txtUserName As TextBox
    Private WithEvents label1 As Label
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnExit As MetroFramework.Controls.MetroButton
End Class
