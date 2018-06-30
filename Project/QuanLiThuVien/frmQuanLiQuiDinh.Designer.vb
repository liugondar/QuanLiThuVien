<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuanLiQuiDinh
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
        Me.txtTuoiToiThieu = New System.Windows.Forms.TextBox()
        Me.txtTuoiToiDa = New System.Windows.Forms.TextBox()
        Me.txtThoiHanThe = New System.Windows.Forms.TextBox()
        Me.txtThoiHanNhanSach = New System.Windows.Forms.TextBox()
        Me.txtSoNgayMuonToiDa = New System.Windows.Forms.TextBox()
        Me.txtSoSachMuonToiDa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnUpdate = New MetroFramework.Controls.MetroButton()
        Me.btnUpdateVaDong = New MetroFramework.Controls.MetroButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTuoiToiThieu
        '
        Me.txtTuoiToiThieu.Location = New System.Drawing.Point(193, 38)
        Me.txtTuoiToiThieu.Name = "txtTuoiToiThieu"
        Me.txtTuoiToiThieu.Size = New System.Drawing.Size(307, 20)
        Me.txtTuoiToiThieu.TabIndex = 0
        '
        'txtTuoiToiDa
        '
        Me.txtTuoiToiDa.Location = New System.Drawing.Point(193, 76)
        Me.txtTuoiToiDa.Name = "txtTuoiToiDa"
        Me.txtTuoiToiDa.Size = New System.Drawing.Size(307, 20)
        Me.txtTuoiToiDa.TabIndex = 1
        '
        'txtThoiHanThe
        '
        Me.txtThoiHanThe.Location = New System.Drawing.Point(193, 117)
        Me.txtThoiHanThe.Name = "txtThoiHanThe"
        Me.txtThoiHanThe.Size = New System.Drawing.Size(307, 20)
        Me.txtThoiHanThe.TabIndex = 2
        '
        'txtThoiHanNhanSach
        '
        Me.txtThoiHanNhanSach.Location = New System.Drawing.Point(391, 29)
        Me.txtThoiHanNhanSach.Name = "txtThoiHanNhanSach"
        Me.txtThoiHanNhanSach.Size = New System.Drawing.Size(109, 20)
        Me.txtThoiHanNhanSach.TabIndex = 5
        '
        'txtSoNgayMuonToiDa
        '
        Me.txtSoNgayMuonToiDa.Location = New System.Drawing.Point(270, 82)
        Me.txtSoNgayMuonToiDa.Name = "txtSoNgayMuonToiDa"
        Me.txtSoNgayMuonToiDa.Size = New System.Drawing.Size(234, 20)
        Me.txtSoNgayMuonToiDa.TabIndex = 4
        '
        'txtSoSachMuonToiDa
        '
        Me.txtSoSachMuonToiDa.Location = New System.Drawing.Point(270, 44)
        Me.txtSoSachMuonToiDa.Name = "txtSoSachMuonToiDa"
        Me.txtSoSachMuonToiDa.Size = New System.Drawing.Size(234, 20)
        Me.txtSoSachMuonToiDa.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tuổi tối thiểu:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Tuổi tối đa:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 18)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Thời hạn thẻ ( tháng) :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(347, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Thời hạn nhận sách cách thời điểm xuất bản (năm ):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Số ngày mượn tối đa:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(246, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Số lượng sách mượn tối đa ( quyển):"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTuoiToiThieu)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTuoiToiDa)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtThoiHanThe)
        Me.GroupBox1.Location = New System.Drawing.Point(49, 77)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(542, 164)
        Me.GroupBox1.TabIndex = 114
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Qui định thẻ độc giả:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtSoSachMuonToiDa)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtSoNgayMuonToiDa)
        Me.GroupBox2.Location = New System.Drawing.Point(49, 258)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(546, 128)
        Me.GroupBox2.TabIndex = 115
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Qui định mượn sách:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtThoiHanNhanSach)
        Me.GroupBox3.Location = New System.Drawing.Point(49, 407)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(542, 79)
        Me.GroupBox3.TabIndex = 116
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Qui định nhập sách:"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(177, 503)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(121, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Cập nhật"
        '
        'btnUpdateVaDong
        '
        Me.btnUpdateVaDong.Location = New System.Drawing.Point(341, 503)
        Me.btnUpdateVaDong.Name = "btnUpdateVaDong"
        Me.btnUpdateVaDong.Size = New System.Drawing.Size(121, 23)
        Me.btnUpdateVaDong.TabIndex = 7
        Me.btnUpdateVaDong.Text = "Cập nhật và đóng"
        '
        'frmQuanLiQuiDinh
        '
        Me.AcceptButton = Me.btnUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 540)
        Me.Controls.Add(Me.btnUpdateVaDong)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmQuanLiQuiDinh"
        Me.Text = "Quản lí qui định"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtTuoiToiThieu As TextBox
    Friend WithEvents txtTuoiToiDa As TextBox
    Friend WithEvents txtThoiHanThe As TextBox
    Friend WithEvents txtThoiHanNhanSach As TextBox
    Friend WithEvents txtSoNgayMuonToiDa As TextBox
    Friend WithEvents txtSoSachMuonToiDa As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnUpdate As MetroFramework.Controls.MetroButton
    Friend WithEvents btnUpdateVaDong As MetroFramework.Controls.MetroButton
End Class
