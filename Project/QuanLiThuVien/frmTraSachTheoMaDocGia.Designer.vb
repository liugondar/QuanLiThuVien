<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSachTheoMaDocGia
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
        Me.cbDocGiaId = New System.Windows.Forms.ComboBox()
        Me.btnPayOne = New MetroFramework.Controls.MetroButton()
        Me.dtgSachDangMuon = New System.Windows.Forms.DataGridView()
        Me.txtNameDg = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpkNgayTra = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dtgSachDangMuon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbDocGiaId
        '
        Me.cbDocGiaId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDocGiaId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDocGiaId.FormattingEnabled = True
        Me.cbDocGiaId.Location = New System.Drawing.Point(181, 84)
        Me.cbDocGiaId.Name = "cbDocGiaId"
        Me.cbDocGiaId.Size = New System.Drawing.Size(200, 21)
        Me.cbDocGiaId.TabIndex = 96
        '
        'btnPayOne
        '
        Me.btnPayOne.Location = New System.Drawing.Point(319, 416)
        Me.btnPayOne.Name = "btnPayOne"
        Me.btnPayOne.Size = New System.Drawing.Size(144, 28)
        Me.btnPayOne.TabIndex = 95
        Me.btnPayOne.Text = "Trả quyển đang chọn"
        '
        'dtgSachDangMuon
        '
        Me.dtgSachDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSachDangMuon.Location = New System.Drawing.Point(51, 164)
        Me.dtgSachDangMuon.Name = "dtgSachDangMuon"
        Me.dtgSachDangMuon.Size = New System.Drawing.Size(697, 228)
        Me.dtgSachDangMuon.TabIndex = 94
        '
        'txtNameDg
        '
        Me.txtNameDg.Enabled = False
        Me.txtNameDg.Location = New System.Drawing.Point(181, 122)
        Me.txtNameDg.Name = "txtNameDg"
        Me.txtNameDg.Size = New System.Drawing.Size(200, 20)
        Me.txtNameDg.TabIndex = 92
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(48, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 18)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Họ tên độc giả:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 18)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Mã thẻ độc giả:"
        '
        'dtpkNgayTra
        '
        Me.dtpkNgayTra.Location = New System.Drawing.Point(548, 124)
        Me.dtpkNgayTra.Name = "dtpkNgayTra"
        Me.dtpkNgayTra.Size = New System.Drawing.Size(200, 20)
        Me.dtpkNgayTra.TabIndex = 99
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(461, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 18)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Ngày trả:"
        '
        'frmTraSachTheoMaDocGia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 467)
        Me.Controls.Add(Me.dtpkNgayTra)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbDocGiaId)
        Me.Controls.Add(Me.btnPayOne)
        Me.Controls.Add(Me.dtgSachDangMuon)
        Me.Controls.Add(Me.txtNameDg)
        Me.Name = "frmTraSachTheoMaDocGia"
        Me.Text = "Trả sách theo mã độc giả"
        CType(Me.dtgSachDangMuon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbDocGiaId As ComboBox
    Friend WithEvents btnPayOne As MetroFramework.Controls.MetroButton
    Friend WithEvents dtgSachDangMuon As DataGridView
    Friend WithEvents txtNameDg As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpkNgayTra As DateTimePicker
    Friend WithEvents Label4 As Label
End Class
