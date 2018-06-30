<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThemLoaiDocGia
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
        Me.btnNhapVaDong = New MetroFramework.Controls.MetroButton()
        Me.btnNhap = New MetroFramework.Controls.MetroButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenLoaiDocGiaDocGia = New System.Windows.Forms.TextBox()
        Me.txtMaLoaiDocGia = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnNhapVaDong
        '
        Me.btnNhapVaDong.Location = New System.Drawing.Point(211, 147)
        Me.btnNhapVaDong.Name = "btnNhapVaDong"
        Me.btnNhapVaDong.Size = New System.Drawing.Size(95, 23)
        Me.btnNhapVaDong.TabIndex = 4
        Me.btnNhapVaDong.Text = "Nhập và Đóng"
        '
        'btnNhap
        '
        Me.btnNhap.Location = New System.Drawing.Point(78, 147)
        Me.btnNhap.Name = "btnNhap"
        Me.btnNhap.Size = New System.Drawing.Size(95, 23)
        Me.btnNhap.TabIndex = 3
        Me.btnNhap.Text = "Nhập"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 18)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Tên loại độc giả:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 18)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Mã loại độc giả:"
        '
        'txtTenLoaiDocGiaDocGia
        '
        Me.txtTenLoaiDocGiaDocGia.Location = New System.Drawing.Point(145, 107)
        Me.txtTenLoaiDocGiaDocGia.Name = "txtTenLoaiDocGiaDocGia"
        Me.txtTenLoaiDocGiaDocGia.Size = New System.Drawing.Size(195, 20)
        Me.txtTenLoaiDocGiaDocGia.TabIndex = 2
        '
        'txtMaLoaiDocGia
        '
        Me.txtMaLoaiDocGia.AcceptsTab = True
        Me.txtMaLoaiDocGia.Enabled = False
        Me.txtMaLoaiDocGia.Location = New System.Drawing.Point(145, 71)
        Me.txtMaLoaiDocGia.Name = "txtMaLoaiDocGia"
        Me.txtMaLoaiDocGia.Size = New System.Drawing.Size(195, 20)
        Me.txtMaLoaiDocGia.TabIndex = 1
        '
        'frmThemLoaiDocGia
        '
        Me.AcceptButton = Me.btnNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 199)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTenLoaiDocGiaDocGia)
        Me.Controls.Add(Me.txtMaLoaiDocGia)
        Me.Controls.Add(Me.btnNhapVaDong)
        Me.Controls.Add(Me.btnNhap)
        Me.Name = "frmThemLoaiDocGia"
        Me.Text = "Thêm loại độc giả"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNhapVaDong As MetroFramework.Controls.MetroButton
    Friend WithEvents btnNhap As MetroFramework.Controls.MetroButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTenLoaiDocGiaDocGia As TextBox
    Friend WithEvents txtMaLoaiDocGia As TextBox
End Class
