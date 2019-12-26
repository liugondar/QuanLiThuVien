<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThemTheLoaiSach
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThemTheLoaiSach))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenTheLoaiSach = New System.Windows.Forms.TextBox()
        Me.txtMaTheLoaiSach = New System.Windows.Forms.TextBox()
        Me.btnNhapVaDong = New MetroFramework.Controls.MetroButton()
        Me.btnNhap = New MetroFramework.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 18)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Tên thể loại sách:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 18)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Mã thể loại sách:"
        '
        'txtTenTheLoaiSach
        '
        Me.txtTenTheLoaiSach.Location = New System.Drawing.Point(178, 120)
        Me.txtTenTheLoaiSach.Name = "txtTenTheLoaiSach"
        Me.txtTenTheLoaiSach.Size = New System.Drawing.Size(195, 20)
        Me.txtTenTheLoaiSach.TabIndex = 2
        '
        'txtMaTheLoaiSach
        '
        Me.txtMaTheLoaiSach.AcceptsTab = True
        Me.txtMaTheLoaiSach.Enabled = False
        Me.txtMaTheLoaiSach.Location = New System.Drawing.Point(178, 84)
        Me.txtMaTheLoaiSach.Name = "txtMaTheLoaiSach"
        Me.txtMaTheLoaiSach.Size = New System.Drawing.Size(195, 20)
        Me.txtMaTheLoaiSach.TabIndex = 1
        '
        'btnNhapVaDong
        '
        Me.btnNhapVaDong.Location = New System.Drawing.Point(226, 160)
        Me.btnNhapVaDong.Name = "btnNhapVaDong"
        Me.btnNhapVaDong.Size = New System.Drawing.Size(95, 23)
        Me.btnNhapVaDong.TabIndex = 4
        Me.btnNhapVaDong.Text = "Nhập và Đóng"
        '
        'btnNhap
        '
        Me.btnNhap.Location = New System.Drawing.Point(93, 160)
        Me.btnNhap.Name = "btnNhap"
        Me.btnNhap.Size = New System.Drawing.Size(95, 23)
        Me.btnNhap.TabIndex = 3
        Me.btnNhap.Text = "Nhập"
        '
        'frmThemTheLoaiSach
        '
        Me.AcceptButton = Me.btnNhap
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 211)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTenTheLoaiSach)
        Me.Controls.Add(Me.txtMaTheLoaiSach)
        Me.Controls.Add(Me.btnNhapVaDong)
        Me.Controls.Add(Me.btnNhap)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmThemTheLoaiSach"
        Me.Text = "Thêm thể loại sách"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTenTheLoaiSach As TextBox
    Friend WithEvents txtMaTheLoaiSach As TextBox
    Friend WithEvents btnNhapVaDong As MetroFramework.Controls.MetroButton
    Friend WithEvents btnNhap As MetroFramework.Controls.MetroButton
End Class
