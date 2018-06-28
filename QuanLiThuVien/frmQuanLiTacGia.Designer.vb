<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanLiTacGia
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenTacGia = New System.Windows.Forms.TextBox()
        Me.txtMaTacGia = New System.Windows.Forms.TextBox()
        Me.btnXoa = New MetroFramework.Controls.MetroButton()
        Me.btnCapNhap = New MetroFramework.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDanhSachTacGia = New System.Windows.Forms.DataGridView()
        CType(Me.dgvDanhSachTacGia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(115, 366)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Tên tác giả:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(115, 330)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 18)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Mã tác giả:"
        '
        'txtTenTacGia
        '
        Me.txtTenTacGia.Location = New System.Drawing.Point(255, 367)
        Me.txtTenTacGia.Name = "txtTenTacGia"
        Me.txtTenTacGia.Size = New System.Drawing.Size(195, 20)
        Me.txtTenTacGia.TabIndex = 40
        '
        'txtMaTacGia
        '
        Me.txtMaTacGia.AcceptsTab = True
        Me.txtMaTacGia.Enabled = False
        Me.txtMaTacGia.Location = New System.Drawing.Point(255, 331)
        Me.txtMaTacGia.Name = "txtMaTacGia"
        Me.txtMaTacGia.Size = New System.Drawing.Size(195, 20)
        Me.txtMaTacGia.TabIndex = 39
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(291, 403)
        Me.btnXoa.Margin = New System.Windows.Forms.Padding(2)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(80, 19)
        Me.btnXoa.TabIndex = 37
        Me.btnXoa.Text = "Xoá"
        '
        'btnCapNhap
        '
        Me.btnCapNhap.Location = New System.Drawing.Point(160, 403)
        Me.btnCapNhap.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCapNhap.Name = "btnCapNhap"
        Me.btnCapNhap.Size = New System.Drawing.Size(81, 19)
        Me.btnCapNhap.TabIndex = 38
        Me.btnCapNhap.Text = "Cập Nhập"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 18)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Danh sách tác giả :"
        '
        'dgvDanhSachTacGia
        '
        Me.dgvDanhSachTacGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachTacGia.Location = New System.Drawing.Point(109, 107)
        Me.dgvDanhSachTacGia.Name = "dgvDanhSachTacGia"
        Me.dgvDanhSachTacGia.Size = New System.Drawing.Size(341, 206)
        Me.dgvDanhSachTacGia.TabIndex = 35
        '
        'frmQuanLiTacGia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTenTacGia)
        Me.Controls.Add(Me.txtMaTacGia)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhap)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDanhSachTacGia)
        Me.Name = "frmQuanLiTacGia"
        Me.Text = "Quản lí tác giả"
        CType(Me.dgvDanhSachTacGia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTenTacGia As TextBox
    Friend WithEvents txtMaTacGia As TextBox
    Friend WithEvents btnXoa As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCapNhap As MetroFramework.Controls.MetroButton
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDanhSachTacGia As DataGridView
End Class
