<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmChoMuonSach
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
        Me.ReaderIdTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ExpirationTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.BorrowDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.UserNameTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListSachDaMuonDataGridView = New System.Windows.Forms.DataGridView()
        Me.ConfirmButton = New MetroFramework.Controls.MetroButton()
        Me.PhieuMuonSachIdTextBox = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.WarningValidateReaderIdLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvDanhSachCanMuon = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnXoa = New MetroFramework.Controls.MetroButton()
        Me.btnThem = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel9 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel7 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel11 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel10 = New MetroFramework.Controls.MetroLabel()
        Me.MetroLabel8 = New MetroFramework.Controls.MetroLabel()
        Me.txtTinhTrangSach = New System.Windows.Forms.TextBox()
        Me.txtTenSach = New System.Windows.Forms.TextBox()
        Me.txtTheLoai = New System.Windows.Forms.TextBox()
        Me.txtTacGia = New System.Windows.Forms.TextBox()
        Me.txtMaSach = New System.Windows.Forms.TextBox()
        CType(Me.ListSachDaMuonDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvDanhSachCanMuon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReaderIdTextBox
        '
        Me.ReaderIdTextBox.Location = New System.Drawing.Point(172, 64)
        Me.ReaderIdTextBox.Name = "ReaderIdTextBox"
        Me.ReaderIdTextBox.Size = New System.Drawing.Size(200, 20)
        Me.ReaderIdTextBox.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 20)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Mã thẻ độc giả:"
        '
        'ExpirationTimePicker
        '
        Me.ExpirationTimePicker.Enabled = False
        Me.ExpirationTimePicker.Location = New System.Drawing.Point(513, 134)
        Me.ExpirationTimePicker.Name = "ExpirationTimePicker"
        Me.ExpirationTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ExpirationTimePicker.TabIndex = 4
        '
        'BorrowDateTimePicker
        '
        Me.BorrowDateTimePicker.Location = New System.Drawing.Point(172, 134)
        Me.BorrowDateTimePicker.Name = "BorrowDateTimePicker"
        Me.BorrowDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.BorrowDateTimePicker.TabIndex = 3
        '
        'UserNameTextBox
        '
        Me.UserNameTextBox.Enabled = False
        Me.UserNameTextBox.Location = New System.Drawing.Point(172, 99)
        Me.UserNameTextBox.Name = "UserNameTextBox"
        Me.UserNameTextBox.Size = New System.Drawing.Size(200, 20)
        Me.UserNameTextBox.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Ngày mượn:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(400, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 20)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Ngày hết hạn:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Họ và tên:"
        '
        'ListSachDaMuonDataGridView
        '
        Me.ListSachDaMuonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListSachDaMuonDataGridView.Location = New System.Drawing.Point(29, 18)
        Me.ListSachDaMuonDataGridView.Name = "ListSachDaMuonDataGridView"
        Me.ListSachDaMuonDataGridView.Size = New System.Drawing.Size(684, 108)
        Me.ListSachDaMuonDataGridView.TabIndex = 51
        '
        'ConfirmButton
        '
        Me.ConfirmButton.Location = New System.Drawing.Point(316, 674)
        Me.ConfirmButton.Name = "ConfirmButton"
        Me.ConfirmButton.Size = New System.Drawing.Size(85, 23)
        Me.ConfirmButton.TabIndex = 12
        Me.ConfirmButton.Text = "Xác nhận"
        '
        'PhieuMuonSachIdTextBox
        '
        Me.PhieuMuonSachIdTextBox.Enabled = False
        Me.PhieuMuonSachIdTextBox.Location = New System.Drawing.Point(172, 24)
        Me.PhieuMuonSachIdTextBox.Name = "PhieuMuonSachIdTextBox"
        Me.PhieuMuonSachIdTextBox.Size = New System.Drawing.Size(200, 20)
        Me.PhieuMuonSachIdTextBox.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(156, 20)
        Me.Label12.TabIndex = 110
        Me.Label12.Text = "Mã phiếu mượn sách"
        '
        'WarningValidateReaderIdLabel
        '
        Me.WarningValidateReaderIdLabel.AutoSize = True
        Me.WarningValidateReaderIdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarningValidateReaderIdLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningValidateReaderIdLabel.Location = New System.Drawing.Point(400, 62)
        Me.WarningValidateReaderIdLabel.Name = "WarningValidateReaderIdLabel"
        Me.WarningValidateReaderIdLabel.Size = New System.Drawing.Size(179, 20)
        Me.WarningValidateReaderIdLabel.TabIndex = 111
        Me.WarningValidateReaderIdLabel.Text = "Warning validate mã thẻ"
        Me.WarningValidateReaderIdLabel.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.WarningValidateReaderIdLabel)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PhieuMuonSachIdTextBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.UserNameTextBox)
        Me.GroupBox1.Controls.Add(Me.BorrowDateTimePicker)
        Me.GroupBox1.Controls.Add(Me.ExpirationTimePicker)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ReaderIdTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 62)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(747, 168)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin phiếu mượn sách:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ListSachDaMuonDataGridView)
        Me.GroupBox3.Location = New System.Drawing.Point(38, 247)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Size = New System.Drawing.Size(747, 141)
        Me.GroupBox3.TabIndex = 112
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Danh sách mượn đã mượn:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvDanhSachCanMuon)
        Me.GroupBox4.Location = New System.Drawing.Point(316, 403)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox4.Size = New System.Drawing.Size(464, 264)
        Me.GroupBox4.TabIndex = 113
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Danh sách mượn"
        '
        'dgvDanhSachCanMuon
        '
        Me.dgvDanhSachCanMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDanhSachCanMuon.Location = New System.Drawing.Point(27, 31)
        Me.dgvDanhSachCanMuon.Name = "dgvDanhSachCanMuon"
        Me.dgvDanhSachCanMuon.Size = New System.Drawing.Size(408, 219)
        Me.dgvDanhSachCanMuon.TabIndex = 52
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnXoa)
        Me.GroupBox2.Controls.Add(Me.btnThem)
        Me.GroupBox2.Controls.Add(Me.MetroLabel9)
        Me.GroupBox2.Controls.Add(Me.MetroLabel7)
        Me.GroupBox2.Controls.Add(Me.MetroLabel11)
        Me.GroupBox2.Controls.Add(Me.MetroLabel10)
        Me.GroupBox2.Controls.Add(Me.MetroLabel8)
        Me.GroupBox2.Controls.Add(Me.txtTinhTrangSach)
        Me.GroupBox2.Controls.Add(Me.txtTenSach)
        Me.GroupBox2.Controls.Add(Me.txtTheLoai)
        Me.GroupBox2.Controls.Add(Me.txtTacGia)
        Me.GroupBox2.Controls.Add(Me.txtMaSach)
        Me.GroupBox2.Location = New System.Drawing.Point(38, 403)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(261, 264)
        Me.GroupBox2.TabIndex = 114
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thêm Sách Mượn"
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(141, 227)
        Me.btnXoa.Margin = New System.Windows.Forms.Padding(2)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(76, 23)
        Me.btnXoa.TabIndex = 11
        Me.btnXoa.Text = "Xoá"
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(37, 227)
        Me.btnThem.Margin = New System.Windows.Forms.Padding(2)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(80, 23)
        Me.btnThem.TabIndex = 10
        Me.btnThem.Text = "Thêm"
        '
        'MetroLabel9
        '
        Me.MetroLabel9.AutoSize = True
        Me.MetroLabel9.Location = New System.Drawing.Point(17, 73)
        Me.MetroLabel9.Name = "MetroLabel9"
        Me.MetroLabel9.Size = New System.Drawing.Size(59, 19)
        Me.MetroLabel9.TabIndex = 5
        Me.MetroLabel9.Text = "Tên sách"
        '
        'MetroLabel7
        '
        Me.MetroLabel7.AutoSize = True
        Me.MetroLabel7.Location = New System.Drawing.Point(15, 31)
        Me.MetroLabel7.Name = "MetroLabel7"
        Me.MetroLabel7.Size = New System.Drawing.Size(57, 19)
        Me.MetroLabel7.TabIndex = 5
        Me.MetroLabel7.Text = "Mã sách"
        '
        'MetroLabel11
        '
        Me.MetroLabel11.AutoSize = True
        Me.MetroLabel11.Location = New System.Drawing.Point(17, 150)
        Me.MetroLabel11.Name = "MetroLabel11"
        Me.MetroLabel11.Size = New System.Drawing.Size(58, 19)
        Me.MetroLabel11.TabIndex = 5
        Me.MetroLabel11.Text = "Thể Loại"
        '
        'MetroLabel10
        '
        Me.MetroLabel10.AutoSize = True
        Me.MetroLabel10.Location = New System.Drawing.Point(15, 189)
        Me.MetroLabel10.Name = "MetroLabel10"
        Me.MetroLabel10.Size = New System.Drawing.Size(102, 19)
        Me.MetroLabel10.TabIndex = 5
        Me.MetroLabel10.Text = "Tình Trạng Sách"
        '
        'MetroLabel8
        '
        Me.MetroLabel8.AutoSize = True
        Me.MetroLabel8.Location = New System.Drawing.Point(15, 109)
        Me.MetroLabel8.Name = "MetroLabel8"
        Me.MetroLabel8.Size = New System.Drawing.Size(52, 19)
        Me.MetroLabel8.TabIndex = 5
        Me.MetroLabel8.Text = "Tác Giả"
        '
        'txtTinhTrangSach
        '
        Me.txtTinhTrangSach.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTinhTrangSach.Location = New System.Drawing.Point(122, 189)
        Me.txtTinhTrangSach.Name = "txtTinhTrangSach"
        Me.txtTinhTrangSach.ReadOnly = True
        Me.txtTinhTrangSach.Size = New System.Drawing.Size(108, 20)
        Me.txtTinhTrangSach.TabIndex = 9
        '
        'txtTenSach
        '
        Me.txtTenSach.Location = New System.Drawing.Point(122, 73)
        Me.txtTenSach.Name = "txtTenSach"
        Me.txtTenSach.ReadOnly = True
        Me.txtTenSach.Size = New System.Drawing.Size(108, 20)
        Me.txtTenSach.TabIndex = 6
        '
        'txtTheLoai
        '
        Me.txtTheLoai.Location = New System.Drawing.Point(122, 150)
        Me.txtTheLoai.Name = "txtTheLoai"
        Me.txtTheLoai.ReadOnly = True
        Me.txtTheLoai.Size = New System.Drawing.Size(108, 20)
        Me.txtTheLoai.TabIndex = 8
        '
        'txtTacGia
        '
        Me.txtTacGia.Location = New System.Drawing.Point(122, 109)
        Me.txtTacGia.Name = "txtTacGia"
        Me.txtTacGia.ReadOnly = True
        Me.txtTacGia.Size = New System.Drawing.Size(108, 20)
        Me.txtTacGia.TabIndex = 7
        '
        'txtMaSach
        '
        Me.txtMaSach.Location = New System.Drawing.Point(122, 31)
        Me.txtMaSach.Name = "txtMaSach"
        Me.txtMaSach.Size = New System.Drawing.Size(108, 20)
        Me.txtMaSach.TabIndex = 5
        '
        'frmChoMuonSach
        '
        Me.AcceptButton = Me.ConfirmButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 708)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ConfirmButton)
        Me.Name = "frmChoMuonSach"
        Me.Text = "Mượn sách"
        CType(Me.ListSachDaMuonDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgvDanhSachCanMuon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReaderIdTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ExpirationTimePicker As DateTimePicker
    Friend WithEvents BorrowDateTimePicker As DateTimePicker
    Friend WithEvents UserNameTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ListSachDaMuonDataGridView As DataGridView
    Friend WithEvents ConfirmButton As MetroFramework.Controls.MetroButton
    Friend WithEvents PhieuMuonSachIdTextBox As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents WarningValidateReaderIdLabel As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvDanhSachCanMuon As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnXoa As MetroFramework.Controls.MetroButton
    Friend WithEvents btnThem As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel9 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel7 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel11 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel10 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroLabel8 As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtTenSach As TextBox
    Friend WithEvents txtTheLoai As TextBox
    Friend WithEvents txtTinhTrangSach As TextBox
    Friend WithEvents txtTacGia As TextBox
    Friend WithEvents txtMaSach As TextBox
End Class
