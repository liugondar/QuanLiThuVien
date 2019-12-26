<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaoCaoTinhHinhMuonSachTheoTheLoai
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaoCaoTinhHinhMuonSachTheoTheLoai))
        Me.ThoiGianCanTimDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChiTietBaoCaoDataGridView = New System.Windows.Forms.DataGridView()
        Me.ConfirmMetroButton = New MetroFramework.Controls.MetroButton()
        Me.TongLuotMuonLabel = New System.Windows.Forms.Label()
        Me.ExportButton = New MetroFramework.Controls.MetroButton()
        CType(Me.ChiTietBaoCaoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ThoiGianCanTimDateTimePicker
        '
        Me.ThoiGianCanTimDateTimePicker.Location = New System.Drawing.Point(106, 103)
        Me.ThoiGianCanTimDateTimePicker.Name = "ThoiGianCanTimDateTimePicker"
        Me.ThoiGianCanTimDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ThoiGianCanTimDateTimePicker.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Thời gian:"
        '
        'ChiTietBaoCaoDataGridView
        '
        Me.ChiTietBaoCaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ChiTietBaoCaoDataGridView.Location = New System.Drawing.Point(36, 141)
        Me.ChiTietBaoCaoDataGridView.Name = "ChiTietBaoCaoDataGridView"
        Me.ChiTietBaoCaoDataGridView.Size = New System.Drawing.Size(741, 238)
        Me.ChiTietBaoCaoDataGridView.TabIndex = 2
        '
        'ConfirmMetroButton
        '
        Me.ConfirmMetroButton.Location = New System.Drawing.Point(401, 412)
        Me.ConfirmMetroButton.Name = "ConfirmMetroButton"
        Me.ConfirmMetroButton.Size = New System.Drawing.Size(75, 23)
        Me.ConfirmMetroButton.TabIndex = 2
        Me.ConfirmMetroButton.Text = "Xác nhận"
        '
        'TongLuotMuonLabel
        '
        Me.TongLuotMuonLabel.AutoSize = True
        Me.TongLuotMuonLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TongLuotMuonLabel.Location = New System.Drawing.Point(566, 395)
        Me.TongLuotMuonLabel.Name = "TongLuotMuonLabel"
        Me.TongLuotMuonLabel.Size = New System.Drawing.Size(128, 18)
        Me.TongLuotMuonLabel.TabIndex = 4
        Me.TongLuotMuonLabel.Text = "Tổng lượt mượn: 0"
        '
        'ExportButton
        '
        Me.ExportButton.Location = New System.Drawing.Point(262, 412)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(75, 23)
        Me.ExportButton.TabIndex = 5
        Me.ExportButton.Text = "Export"
        '
        'frmBaoCaoTinhHinhMuonSachTheoTheLoai
        '
        Me.AcceptButton = Me.ConfirmMetroButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 458)
        Me.Controls.Add(Me.ExportButton)
        Me.Controls.Add(Me.TongLuotMuonLabel)
        Me.Controls.Add(Me.ConfirmMetroButton)
        Me.Controls.Add(Me.ChiTietBaoCaoDataGridView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ThoiGianCanTimDateTimePicker)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBaoCaoTinhHinhMuonSachTheoTheLoai"
        Me.Text = "Báo cáo tình hình mượn sách theo thể loại"
        CType(Me.ChiTietBaoCaoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ThoiGianCanTimDateTimePicker As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents ChiTietBaoCaoDataGridView As DataGridView
    Friend WithEvents ConfirmMetroButton As MetroFramework.Controls.MetroButton
    Friend WithEvents TongLuotMuonLabel As Label
    Friend WithEvents ExportButton As MetroFramework.Controls.MetroButton
End Class
