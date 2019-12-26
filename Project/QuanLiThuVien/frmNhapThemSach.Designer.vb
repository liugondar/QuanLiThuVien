<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNhapThemSach
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNhapThemSach))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CreateButton = New MetroFramework.Controls.MetroButton()
        Me.txtTitleBook = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateAndCloseButton = New MetroFramework.Controls.MetroButton()
        Me.nudSoLuong = New System.Windows.Forms.NumericUpDown()
        Me.txtTheLoai = New System.Windows.Forms.TextBox()
        Me.dtpkNgayNhap = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.nudSoLuong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(23, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 20)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Số lượng:"
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(150, 81)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(204, 20)
        Me.txtId.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(23, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Mã đầu sách:"
        '
        'CreateButton
        '
        Me.CreateButton.Location = New System.Drawing.Point(60, 301)
        Me.CreateButton.Name = "CreateButton"
        Me.CreateButton.Size = New System.Drawing.Size(121, 23)
        Me.CreateButton.TabIndex = 103
        Me.CreateButton.Text = "Cập nhật"
        '
        'txtTitleBook
        '
        Me.txtTitleBook.Enabled = False
        Me.txtTitleBook.Location = New System.Drawing.Point(150, 121)
        Me.txtTitleBook.Name = "txtTitleBook"
        Me.txtTitleBook.Size = New System.Drawing.Size(204, 20)
        Me.txtTitleBook.TabIndex = 107
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(23, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 20)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Thể loại:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(22, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Tên sách:"
        '
        'CreateAndCloseButton
        '
        Me.CreateAndCloseButton.Location = New System.Drawing.Point(214, 301)
        Me.CreateAndCloseButton.Name = "CreateAndCloseButton"
        Me.CreateAndCloseButton.Size = New System.Drawing.Size(121, 23)
        Me.CreateAndCloseButton.TabIndex = 113
        Me.CreateAndCloseButton.Text = "Cập nhật và đóng"
        '
        'nudSoLuong
        '
        Me.nudSoLuong.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudSoLuong.Location = New System.Drawing.Point(150, 244)
        Me.nudSoLuong.Maximum = New Decimal(New Integer() {1215752192, 23, 0, 0})
        Me.nudSoLuong.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudSoLuong.Name = "nudSoLuong"
        Me.nudSoLuong.Size = New System.Drawing.Size(204, 20)
        Me.nudSoLuong.TabIndex = 116
        Me.nudSoLuong.ThousandsSeparator = True
        Me.nudSoLuong.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtTheLoai
        '
        Me.txtTheLoai.Enabled = False
        Me.txtTheLoai.Location = New System.Drawing.Point(150, 166)
        Me.txtTheLoai.Name = "txtTheLoai"
        Me.txtTheLoai.Size = New System.Drawing.Size(204, 20)
        Me.txtTheLoai.TabIndex = 117
        '
        'dtpkNgayNhap
        '
        Me.dtpkNgayNhap.Location = New System.Drawing.Point(150, 204)
        Me.dtpkNgayNhap.Name = "dtpkNgayNhap"
        Me.dtpkNgayNhap.Size = New System.Drawing.Size(200, 20)
        Me.dtpkNgayNhap.TabIndex = 118
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(22, 204)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Ngày Nhập:"
        '
        'frmNhapThemSach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 360)
        Me.Controls.Add(Me.dtpkNgayNhap)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTheLoai)
        Me.Controls.Add(Me.nudSoLuong)
        Me.Controls.Add(Me.CreateAndCloseButton)
        Me.Controls.Add(Me.txtTitleBook)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CreateButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNhapThemSach"
        Me.Text = "Thêm sách vào kho"
        CType(Me.nudSoLuong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CreateButton As MetroFramework.Controls.MetroButton
    Friend WithEvents txtTitleBook As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CreateAndCloseButton As MetroFramework.Controls.MetroButton
    Friend WithEvents nudSoLuong As NumericUpDown
    Friend WithEvents txtTheLoai As TextBox
    Friend WithEvents dtpkNgayNhap As DateTimePicker
    Friend WithEvents Label8 As Label
End Class
