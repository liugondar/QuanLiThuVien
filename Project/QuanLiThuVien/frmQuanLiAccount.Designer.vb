<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanLiAccount
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
        Me.dgvListAccount = New System.Windows.Forms.DataGridView()
        Me.SelectedAccountGroupBox = New System.Windows.Forms.GroupBox()
        Me.cbUpdateType = New System.Windows.Forms.ComboBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnDelete = New MetroFramework.Controls.MetroButton()
        Me.cbDefaultType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvListAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SelectedAccountGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvListAccount
        '
        Me.dgvListAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListAccount.Location = New System.Drawing.Point(35, 107)
        Me.dgvListAccount.Name = "dgvListAccount"
        Me.dgvListAccount.Size = New System.Drawing.Size(379, 206)
        Me.dgvListAccount.TabIndex = 52
        '
        'SelectedAccountGroupBox
        '
        Me.SelectedAccountGroupBox.Controls.Add(Me.cbUpdateType)
        Me.SelectedAccountGroupBox.Controls.Add(Me.txtUserName)
        Me.SelectedAccountGroupBox.Controls.Add(Me.Label1)
        Me.SelectedAccountGroupBox.Controls.Add(Me.txtDisplayName)
        Me.SelectedAccountGroupBox.Controls.Add(Me.Label3)
        Me.SelectedAccountGroupBox.Controls.Add(Me.Label5)
        Me.SelectedAccountGroupBox.Location = New System.Drawing.Point(35, 335)
        Me.SelectedAccountGroupBox.Margin = New System.Windows.Forms.Padding(2)
        Me.SelectedAccountGroupBox.Name = "SelectedAccountGroupBox"
        Me.SelectedAccountGroupBox.Padding = New System.Windows.Forms.Padding(2)
        Me.SelectedAccountGroupBox.Size = New System.Drawing.Size(379, 144)
        Me.SelectedAccountGroupBox.TabIndex = 115
        Me.SelectedAccountGroupBox.TabStop = False
        Me.SelectedAccountGroupBox.Text = "Thông tin tài khoản"
        '
        'cbUpdateType
        '
        Me.cbUpdateType.FormattingEnabled = True
        Me.cbUpdateType.Location = New System.Drawing.Point(158, 113)
        Me.cbUpdateType.Name = "cbUpdateType"
        Me.cbUpdateType.Size = New System.Drawing.Size(190, 21)
        Me.cbUpdateType.TabIndex = 9
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Location = New System.Drawing.Point(158, 38)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(190, 20)
        Me.txtUserName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tên tài khoản"
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Enabled = False
        Me.txtDisplayName.Location = New System.Drawing.Point(158, 76)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(190, 20)
        Me.txtDisplayName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tên hiển thị"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Loại tài khoản"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(101, 501)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(113, 23)
        Me.btnUpdate.TabIndex = 116
        Me.btnUpdate.Text = "Cập nhật"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(238, 501)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(113, 23)
        Me.btnDelete.TabIndex = 117
        Me.btnDelete.Text = "Xoá"
        '
        'cbDefaultType
        '
        Me.cbDefaultType.FormattingEnabled = True
        Me.cbDefaultType.Location = New System.Drawing.Point(193, 66)
        Me.cbDefaultType.Name = "cbDefaultType"
        Me.cbDefaultType.Size = New System.Drawing.Size(129, 21)
        Me.cbDefaultType.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(71, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 18)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Loại tài khoản"
        '
        'frmQuanLiAccount
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(475, 547)
        Me.Controls.Add(Me.cbDefaultType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.SelectedAccountGroupBox)
        Me.Controls.Add(Me.dgvListAccount)
        Me.Name = "frmQuanLiAccount"
        Me.Text = "Quản lí tài khoản"
        CType(Me.dgvListAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SelectedAccountGroupBox.ResumeLayout(False)
        Me.SelectedAccountGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvListAccount As DataGridView
    Friend WithEvents SelectedAccountGroupBox As GroupBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDisplayName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnDelete As MetroFramework.Controls.MetroButton
    Friend WithEvents cbDefaultType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbUpdateType As ComboBox
End Class
