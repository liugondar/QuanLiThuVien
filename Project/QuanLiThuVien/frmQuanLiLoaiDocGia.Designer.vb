<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanLiLoaiDocGia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuanLiLoaiDocGia))
        Me.dgvDanhSachLoaiDocGia = New System.Windows.Forms.DataGridView()
        Me.txtMaLoai = New System.Windows.Forms.TextBox()
        Me.txtTenLoai = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnXoa = New MetroFramework.Controls.MetroButton()
        Me.btnCapNhap = New MetroFramework.Controls.MetroButton()
        CType(Me.dgvDanhSachLoaiDocGia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDanhSachLoaiDocGia
        '
        Me.dgvDanhSachLoaiDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachLoaiDocGia.Location = New System.Drawing.Point(88, 97)
        Me.dgvDanhSachLoaiDocGia.Name = "dgvDanhSachLoaiDocGia"
        Me.dgvDanhSachLoaiDocGia.Size = New System.Drawing.Size(257, 206)
        Me.dgvDanhSachLoaiDocGia.TabIndex = 15
        '
        'txtMaLoai
        '
        Me.txtMaLoai.Enabled = False
        Me.txtMaLoai.Location = New System.Drawing.Point(203, 323)
        Me.txtMaLoai.Name = "txtMaLoai"
        Me.txtMaLoai.Size = New System.Drawing.Size(142, 20)
        Me.txtMaLoai.TabIndex = 1
        '
        'txtTenLoai
        '
        Me.txtTenLoai.Location = New System.Drawing.Point(203, 359)
        Me.txtTenLoai.Name = "txtTenLoai"
        Me.txtTenLoai.Size = New System.Drawing.Size(142, 20)
        Me.txtTenLoai.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 18)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Danh sách loại độc giả:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 325)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 18)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Mã loại độc giả:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(85, 361)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 18)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Tên loại độc giả:"
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(226, 400)
        Me.btnXoa.Margin = New System.Windows.Forms.Padding(2)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(80, 19)
        Me.btnXoa.TabIndex = 4
        Me.btnXoa.Text = "Xoá"
        '
        'btnCapNhap
        '
        Me.btnCapNhap.Location = New System.Drawing.Point(120, 400)
        Me.btnCapNhap.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCapNhap.Name = "btnCapNhap"
        Me.btnCapNhap.Size = New System.Drawing.Size(81, 19)
        Me.btnCapNhap.TabIndex = 3
        Me.btnCapNhap.Text = "Cập Nhập"
        '
        'frmQuanLiLoaiDocGia
        '
        Me.AcceptButton = Me.btnCapNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 441)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhap)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTenLoai)
        Me.Controls.Add(Me.txtMaLoai)
        Me.Controls.Add(Me.dgvDanhSachLoaiDocGia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuanLiLoaiDocGia"
        Me.Text = "Quản lí loại độc giả"
        CType(Me.dgvDanhSachLoaiDocGia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvDanhSachLoaiDocGia As DataGridView
    Friend WithEvents txtMaLoai As TextBox
    Friend WithEvents txtTenLoai As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnXoa As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCapNhap As MetroFramework.Controls.MetroButton
End Class
