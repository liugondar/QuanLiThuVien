<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraSach
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraSach))
        Me.MaPhieuMuonTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BorrowDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.HoTenDocGiaMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
        Me.NgayTraDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.dtgSachDangMuon = New System.Windows.Forms.DataGridView()
        Me.btnTraHet = New MetroFramework.Controls.MetroButton()
        Me.WarningUnavailableMaPhieuMuonLabel = New System.Windows.Forms.Label()
        Me.btnPayOne = New MetroFramework.Controls.MetroButton()
        Me.cbDocGiaId = New System.Windows.Forms.ComboBox()
        CType(Me.dtgSachDangMuon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MaPhieuMuonTextBox
        '
        Me.MaPhieuMuonTextBox.Location = New System.Drawing.Point(154, 85)
        Me.MaPhieuMuonTextBox.Name = "MaPhieuMuonTextBox"
        Me.MaPhieuMuonTextBox.Size = New System.Drawing.Size(200, 20)
        Me.MaPhieuMuonTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 18)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mã phiếu mượn:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Mã thẻ độc giả:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(33, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 18)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ngày mượn:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(397, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 18)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Ngày trả:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(397, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 18)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Họ tên độc giả:"
        '
        'BorrowDateTimePicker
        '
        Me.BorrowDateTimePicker.Enabled = False
        Me.BorrowDateTimePicker.Location = New System.Drawing.Point(154, 158)
        Me.BorrowDateTimePicker.Name = "BorrowDateTimePicker"
        Me.BorrowDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.BorrowDateTimePicker.TabIndex = 4
        '
        'HoTenDocGiaMaskedTextBox
        '
        Me.HoTenDocGiaMaskedTextBox.Enabled = False
        Me.HoTenDocGiaMaskedTextBox.Location = New System.Drawing.Point(511, 122)
        Me.HoTenDocGiaMaskedTextBox.Name = "HoTenDocGiaMaskedTextBox"
        Me.HoTenDocGiaMaskedTextBox.Size = New System.Drawing.Size(200, 20)
        Me.HoTenDocGiaMaskedTextBox.TabIndex = 3
        '
        'NgayTraDateTimePicker
        '
        Me.NgayTraDateTimePicker.Location = New System.Drawing.Point(511, 158)
        Me.NgayTraDateTimePicker.Name = "NgayTraDateTimePicker"
        Me.NgayTraDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.NgayTraDateTimePicker.TabIndex = 5
        '
        'dtgSachDangMuon
        '
        Me.dtgSachDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgSachDangMuon.Location = New System.Drawing.Point(36, 205)
        Me.dtgSachDangMuon.Name = "dtgSachDangMuon"
        Me.dtgSachDangMuon.Size = New System.Drawing.Size(675, 150)
        Me.dtgSachDangMuon.TabIndex = 11
        '
        'btnTraHet
        '
        Me.btnTraHet.Location = New System.Drawing.Point(210, 373)
        Me.btnTraHet.Name = "btnTraHet"
        Me.btnTraHet.Size = New System.Drawing.Size(144, 28)
        Me.btnTraHet.TabIndex = 6
        Me.btnTraHet.Text = "Trả hết"
        '
        'WarningUnavailableMaPhieuMuonLabel
        '
        Me.WarningUnavailableMaPhieuMuonLabel.AutoSize = True
        Me.WarningUnavailableMaPhieuMuonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WarningUnavailableMaPhieuMuonLabel.ForeColor = System.Drawing.Color.Red
        Me.WarningUnavailableMaPhieuMuonLabel.Location = New System.Drawing.Point(397, 89)
        Me.WarningUnavailableMaPhieuMuonLabel.Name = "WarningUnavailableMaPhieuMuonLabel"
        Me.WarningUnavailableMaPhieuMuonLabel.Size = New System.Drawing.Size(58, 16)
        Me.WarningUnavailableMaPhieuMuonLabel.TabIndex = 12
        Me.WarningUnavailableMaPhieuMuonLabel.Text = "Warning"
        Me.WarningUnavailableMaPhieuMuonLabel.Visible = False
        '
        'btnPayOne
        '
        Me.btnPayOne.Location = New System.Drawing.Point(387, 373)
        Me.btnPayOne.Name = "btnPayOne"
        Me.btnPayOne.Size = New System.Drawing.Size(144, 28)
        Me.btnPayOne.TabIndex = 13
        Me.btnPayOne.Text = "Trả quyển đang chọn"
        '
        'cbDocGiaId
        '
        Me.cbDocGiaId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbDocGiaId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbDocGiaId.FormattingEnabled = True
        Me.cbDocGiaId.Location = New System.Drawing.Point(154, 119)
        Me.cbDocGiaId.Name = "cbDocGiaId"
        Me.cbDocGiaId.Size = New System.Drawing.Size(200, 21)
        Me.cbDocGiaId.TabIndex = 91
        '
        'frmTraSach
        '
        Me.AcceptButton = Me.btnTraHet
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 415)
        Me.Controls.Add(Me.cbDocGiaId)
        Me.Controls.Add(Me.btnPayOne)
        Me.Controls.Add(Me.WarningUnavailableMaPhieuMuonLabel)
        Me.Controls.Add(Me.btnTraHet)
        Me.Controls.Add(Me.dtgSachDangMuon)
        Me.Controls.Add(Me.NgayTraDateTimePicker)
        Me.Controls.Add(Me.HoTenDocGiaMaskedTextBox)
        Me.Controls.Add(Me.BorrowDateTimePicker)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaPhieuMuonTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTraSach"
        Me.Text = "Trả sách"
        CType(Me.dtgSachDangMuon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MaPhieuMuonTextBox As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BorrowDateTimePicker As DateTimePicker
    Friend WithEvents HoTenDocGiaMaskedTextBox As MaskedTextBox
    Friend WithEvents NgayTraDateTimePicker As DateTimePicker
    Friend WithEvents dtgSachDangMuon As DataGridView
    Friend WithEvents btnTraHet As MetroFramework.Controls.MetroButton
    Friend WithEvents WarningUnavailableMaPhieuMuonLabel As Label
    Friend WithEvents btnPayOne As MetroFramework.Controls.MetroButton
    Friend WithEvents cbDocGiaId As ComboBox
End Class
