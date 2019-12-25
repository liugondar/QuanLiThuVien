<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThemAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThemAccount))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnThem = New MetroFramework.Controls.MetroButton()
        Me.btnThemVaDong = New MetroFramework.Controls.MetroButton()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tên tài khoản:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tên hiển thị:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Loại tài khoản"
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(79, 221)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(113, 23)
        Me.btnThem.TabIndex = 4
        Me.btnThem.Text = "Thêm"
        '
        'btnThemVaDong
        '
        Me.btnThemVaDong.Location = New System.Drawing.Point(226, 221)
        Me.btnThemVaDong.Name = "btnThemVaDong"
        Me.btnThemVaDong.Size = New System.Drawing.Size(113, 23)
        Me.btnThemVaDong.TabIndex = 5
        Me.btnThemVaDong.Text = "Thêm và đóng"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(164, 73)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(201, 20)
        Me.txtUserName.TabIndex = 6
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Location = New System.Drawing.Point(164, 107)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(201, 20)
        Me.txtDisplayName.TabIndex = 7
        '
        'cbType
        '
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(164, 177)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(201, 21)
        Me.cbType.TabIndex = 9
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(164, 140)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(201, 20)
        Me.txtPassword.TabIndex = 10
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'frmThemAccount
        '
        Me.AcceptButton = Me.btnThem
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 257)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.txtDisplayName)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnThemVaDong)
        Me.Controls.Add(Me.btnThem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmThemAccount"
        Me.Text = "Thêm tài khoản"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnThem As MetroFramework.Controls.MetroButton
    Friend WithEvents btnThemVaDong As MetroFramework.Controls.MetroButton
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents txtDisplayName As TextBox
    Friend WithEvents cbType As ComboBox
    Private WithEvents txtPassword As TextBox
End Class
