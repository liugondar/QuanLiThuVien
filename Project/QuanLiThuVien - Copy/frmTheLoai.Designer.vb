<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTheLoai
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
<<<<<<< HEAD:Project/QuanLiThuVien/frmTheLoai.Designer.vb
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTheLoai))
=======
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuanLiTheLoaiSach))
>>>>>>> loc:Project/QuanLiThuVien/frmQuanLiTheLoaiSach.Designer.vb
        Me.btnXoa = New MetroFramework.Controls.MetroButton()
        Me.btnCapNhap = New MetroFramework.Controls.MetroButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDanhSachTheLoaiSach = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenTheLoaiSach = New System.Windows.Forms.TextBox()
        Me.txtMaTheLoaiSach = New System.Windows.Forms.TextBox()
        CType(Me.dgvDanhSachTheLoaiSach, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(270, 394)
        Me.btnXoa.Margin = New System.Windows.Forms.Padding(2)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(80, 19)
        Me.btnXoa.TabIndex = 4
        Me.btnXoa.Text = "Xoá"
        '
        'btnCapNhap
        '
        Me.btnCapNhap.Location = New System.Drawing.Point(139, 394)
        Me.btnCapNhap.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCapNhap.Name = "btnCapNhap"
        Me.btnCapNhap.Size = New System.Drawing.Size(81, 19)
        Me.btnCapNhap.TabIndex = 3
        Me.btnCapNhap.Text = "Cập Nhập"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(104, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 18)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Danh sách thể loại sách:"
        '
        'dgvDanhSachTheLoaiSach
        '
        Me.dgvDanhSachTheLoaiSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachTheLoaiSach.Location = New System.Drawing.Point(88, 98)
        Me.dgvDanhSachTheLoaiSach.Name = "dgvDanhSachTheLoaiSach"
        Me.dgvDanhSachTheLoaiSach.Size = New System.Drawing.Size(341, 206)
        Me.dgvDanhSachTheLoaiSach.TabIndex = 23
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(94, 357)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 18)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Tên thể loại sách:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(94, 321)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 18)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Mã thể loại sách:"
        '
        'txtTenTheLoaiSach
        '
        Me.txtTenTheLoaiSach.Location = New System.Drawing.Point(234, 358)
        Me.txtTenTheLoaiSach.Name = "txtTenTheLoaiSach"
        Me.txtTenTheLoaiSach.Size = New System.Drawing.Size(195, 20)
        Me.txtTenTheLoaiSach.TabIndex = 2
        '
        'txtMaTheLoaiSach
        '
        Me.txtMaTheLoaiSach.AcceptsTab = True
        Me.txtMaTheLoaiSach.Enabled = False
        Me.txtMaTheLoaiSach.Location = New System.Drawing.Point(234, 322)
        Me.txtMaTheLoaiSach.Name = "txtMaTheLoaiSach"
        Me.txtMaTheLoaiSach.Size = New System.Drawing.Size(195, 20)
        Me.txtMaTheLoaiSach.TabIndex = 1
        '
        'frmQuanLiTheLoaiSach
        '
        Me.AcceptButton = Me.btnCapNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 435)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTenTheLoaiSach)
        Me.Controls.Add(Me.txtMaTheLoaiSach)
        Me.Controls.Add(Me.btnXoa)
        Me.Controls.Add(Me.btnCapNhap)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDanhSachTheLoaiSach)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQuanLiTheLoaiSach"
        Me.Text = "Quản lí thể loại sách"
        CType(Me.dgvDanhSachTheLoaiSach, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnXoa As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCapNhap As MetroFramework.Controls.MetroButton
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvDanhSachTheLoaiSach As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTenTheLoaiSach As TextBox
    Friend WithEvents txtMaTheLoaiSach As TextBox
End Class
