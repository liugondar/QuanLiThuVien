<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmXoaSach
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTheLoai = New System.Windows.Forms.TextBox()
        Me.txtTitleBook = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDauSachId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSachId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPayOne = New MetroFramework.Controls.MetroButton()
        Me.btnTraHet = New MetroFramework.Controls.MetroButton()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.lbAuthor = New System.Windows.Forms.Label()
        Me.txtNgayNhap = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(36, 291)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 20)
        Me.Label8.TabIndex = 127
        Me.Label8.Text = "Ngày Nhập:"
        '
        'txtTheLoai
        '
        Me.txtTheLoai.Enabled = False
        Me.txtTheLoai.Location = New System.Drawing.Point(164, 253)
        Me.txtTheLoai.Name = "txtTheLoai"
        Me.txtTheLoai.Size = New System.Drawing.Size(204, 20)
        Me.txtTheLoai.TabIndex = 125
        '
        'txtTitleBook
        '
        Me.txtTitleBook.Enabled = False
        Me.txtTitleBook.Location = New System.Drawing.Point(164, 208)
        Me.txtTitleBook.Name = "txtTitleBook"
        Me.txtTitleBook.Size = New System.Drawing.Size(204, 20)
        Me.txtTitleBook.TabIndex = 122
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(37, 251)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 20)
        Me.Label6.TabIndex = 124
        Me.Label6.Text = "Thể loại:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(36, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Tên sách:"
        '
        'txtDauSachId
        '
        Me.txtDauSachId.Enabled = False
        Me.txtDauSachId.Location = New System.Drawing.Point(164, 126)
        Me.txtDauSachId.Name = "txtDauSachId"
        Me.txtDauSachId.Size = New System.Drawing.Size(204, 20)
        Me.txtDauSachId.TabIndex = 120
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(37, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Mã đầu sách:"
        '
        'txtSachId
        '
        Me.txtSachId.Location = New System.Drawing.Point(164, 87)
        Me.txtSachId.Name = "txtSachId"
        Me.txtSachId.Size = New System.Drawing.Size(204, 20)
        Me.txtSachId.TabIndex = 128
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(37, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 20)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Mã  sách:"
        '
        'btnPayOne
        '
        Me.btnPayOne.Location = New System.Drawing.Point(218, 350)
        Me.btnPayOne.Name = "btnPayOne"
        Me.btnPayOne.Size = New System.Drawing.Size(144, 28)
        Me.btnPayOne.TabIndex = 131
        Me.btnPayOne.Text = "Xóa sách và đóng"
        '
        'btnTraHet
        '
        Me.btnTraHet.Location = New System.Drawing.Point(41, 350)
        Me.btnTraHet.Name = "btnTraHet"
        Me.btnTraHet.Size = New System.Drawing.Size(144, 28)
        Me.btnTraHet.TabIndex = 130
        Me.btnTraHet.Text = "Xoá sách"
        '
        'txtAuthor
        '
        Me.txtAuthor.Enabled = False
        Me.txtAuthor.Location = New System.Drawing.Point(164, 166)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(204, 20)
        Me.txtAuthor.TabIndex = 132
        '
        'lbAuthor
        '
        Me.lbAuthor.AutoSize = True
        Me.lbAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAuthor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbAuthor.Location = New System.Drawing.Point(36, 164)
        Me.lbAuthor.Name = "lbAuthor"
        Me.lbAuthor.Size = New System.Drawing.Size(64, 20)
        Me.lbAuthor.TabIndex = 133
        Me.lbAuthor.Text = "Tác giả:"
        '
        'txtNgayNhap
        '
        Me.txtNgayNhap.Enabled = False
        Me.txtNgayNhap.Location = New System.Drawing.Point(164, 293)
        Me.txtNgayNhap.Name = "txtNgayNhap"
        Me.txtNgayNhap.Size = New System.Drawing.Size(204, 20)
        Me.txtNgayNhap.TabIndex = 134
        '
        'frmXoaSach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 419)
        Me.Controls.Add(Me.txtNgayNhap)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.lbAuthor)
        Me.Controls.Add(Me.btnPayOne)
        Me.Controls.Add(Me.btnTraHet)
        Me.Controls.Add(Me.txtSachId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTheLoai)
        Me.Controls.Add(Me.txtTitleBook)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDauSachId)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmXoaSach"
        Me.Text = "Xóa sách"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTheLoai As TextBox
    Friend WithEvents txtTitleBook As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDauSachId As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSachId As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnPayOne As MetroFramework.Controls.MetroButton
    Friend WithEvents btnTraHet As MetroFramework.Controls.MetroButton
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents lbAuthor As Label
    Friend WithEvents txtNgayNhap As TextBox
End Class
